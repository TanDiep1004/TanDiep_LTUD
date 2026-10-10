using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using MiniSupermarket.WinForms.Models;

namespace MiniSupermarket.WinForms {
    public partial class FormPOS : Form {
        private readonly List<CartItemDto> _cart = new();

        public FormPOS() {
            InitializeComponent();
            SetupCartGrid();
            this.Load += FormPOS_Load;
        }

        private void FormPOS_Load(object? sender, EventArgs e) {
            if (string.Equals(SessionManager.CurrentRole, "Warehouse", StringComparison.OrdinalIgnoreCase)) {
                MessageBox.Show("Thủ kho không có quyền truy cập quầy thu ngân POS!", "Từ chối truy cập", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                this.Close();
            }
        }

        private void SetupCartGrid() {
            dgvCart.AutoGenerateColumns = false;
            dgvCart.Columns.Clear();
            dgvCart.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "ProductId", HeaderText = "Mã SP", Width = 80 });
            dgvCart.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "ProductName", HeaderText = "Tên Sản Phẩm", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvCart.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "UnitPriceStr", HeaderText = "Đơn Giá", Width = 110 });
            dgvCart.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Quantity", HeaderText = "SL", Width = 70 });
            dgvCart.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "TotalPriceStr", HeaderText = "Thành Tiền", Width = 120 });
        }

        // Bắt sự kiện quét mã Barcode
        private async void txtBarcode_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter && !string.IsNullOrWhiteSpace(txtBarcode.Text)) {
                e.Handled = true;
                e.SuppressKeyPress = true;
                string barcode = txtBarcode.Text.Trim();
                txtBarcode.Clear();
                await AddProductToCartByBarcodeAsync(barcode);
            }
        }

        private async Task AddProductToCartByBarcodeAsync(string barcode) {
            try {
                // Gọi API tra cứu sản phẩm theo Barcode
                using var client = ApiClientService.CreateClient();
                var product = await client.GetFromJsonAsync<PosProductDto>($"products/barcode/{Uri.EscapeDataString(barcode)}");
                if (product == null) {
                    MessageBox.Show("Không tìm thấy sản phẩm có mã vạch này!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var existingItem = _cart.FirstOrDefault(c => c.ProductId == product.ProductId);
                if (existingItem != null) {
                    existingItem.Quantity++;
                } else {
                    _cart.Add(new CartItemDto {
                        ProductId = product.ProductId,
                        ProductName = product.ProductName,
                        UnitPrice = product.Price,
                        Quantity = 1
                    });
                }

                UpdateCartDisplay();
            } catch (Exception ex) {
                MessageBox.Show("Lỗi kết nối máy chủ hoặc mã vạch không hợp lệ: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateCartDisplay() {
            dgvCart.DataSource = null;
            dgvCart.DataSource = _cart.ToList();

            decimal total = _cart.Sum(x => x.TotalPrice);
            lblTotalAmount.Text = $"{total:N0} đ";
            CalculateChange();
        }

        private void txtCashReceived_TextChanged(object sender, EventArgs e) {
            CalculateChange();
        }

        private void CalculateChange() {
            decimal total = _cart.Sum(x => x.TotalPrice);
            string rawText = txtCashReceived.Text.Replace(",", "").Replace(".", "").Trim();
            if (decimal.TryParse(rawText, out decimal cashReceived)) {
                decimal change = cashReceived - total;
                if (change >= 0) {
                    lblChange.Text = $"{change:N0} đ";
                    lblChange.ForeColor = Color.FromArgb(40, 167, 69);
                } else {
                    lblChange.Text = $"Thiếu: {Math.Abs(change):N0} đ";
                    lblChange.ForeColor = Color.Red;
                }
            } else {
                lblChange.Text = "0 đ";
                lblChange.ForeColor = Color.Black;
            }
        }

        private async void btnFindCustomer_Click(object sender, EventArgs e) {
            string phone = txtCustomerPhone.Text.Trim();
            if (string.IsNullOrEmpty(phone)) {
                lblCustomerName.Text = "Khách hàng: Khách vãng lai";
                return;
            }

            try {
                using var client = ApiClientService.CreateClient();
                var customers = await client.GetFromJsonAsync<List<Customer>>($"customers/search?keyword={Uri.EscapeDataString(phone)}");
                var cust = customers?.FirstOrDefault(c => c.PhoneNumber == phone);
                if (cust != null) {
                    lblCustomerName.Text = $"Khách: {cust.CustomerName} | Hạng: {cust.MembershipRank} ({cust.RewardPoints}đ)";
                    lblCustomerName.ForeColor = Color.FromArgb(0, 123, 255);
                } else {
                    lblCustomerName.Text = "SĐT chưa đăng ký thành viên (Khách mới)";
                    lblCustomerName.ForeColor = Color.FromArgb(255, 133, 27);
                }
            } catch (Exception) {
                lblCustomerName.Text = "Khách hàng: Khách vãng lai";
            }
        }

        private async void btnCheckout_Click(object sender, EventArgs e) {
            if (_cart.Count == 0) {
                MessageBox.Show("Giỏ hàng đang trống! Vui lòng quét mã sản phẩm trước khi thanh toán.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal total = _cart.Sum(x => x.TotalPrice);
            string rawText = txtCashReceived.Text.Replace(",", "").Replace(".", "").Trim();
            if (!decimal.TryParse(rawText, out decimal cashReceived) || cashReceived < total) {
                MessageBox.Show($"Khách đưa tiền chưa đủ để thanh toán đơn hàng ({total:N0} đ)!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCashReceived.Focus();
                return;
            }

            var orderRequest = new {
                CashierUsername = SessionManager.CurrentUsername,
                CustomerPhone = txtCustomerPhone.Text.Trim(),
                Items = _cart.Select(i => new { i.ProductId, i.Quantity, i.UnitPrice }).ToList()
            };

            try {
                using var client = ApiClientService.CreateClient();
                var response = await client.PostAsJsonAsync("orders/checkout", orderRequest);
                if (response.IsSuccessStatusCode) {
                    decimal change = cashReceived - total;
                    MessageBox.Show($"Thanh toán thành công!\nTổng tiền: {total:N0} đ\nKhách đưa: {cashReceived:N0} đ\nTiền thừa: {change:N0} đ", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _cart.Clear();
                    UpdateCartDisplay();
                    txtCashReceived.Clear();
                    txtCustomerPhone.Clear();
                    lblCustomerName.Text = "Khách hàng: Khách vãng lai";
                    lblCustomerName.ForeColor = Color.FromArgb(40, 167, 69);
                    txtBarcode.Focus();
                } else {
                    MessageBox.Show("Thanh toán thất bại từ máy chủ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            } catch (Exception ex) {
                MessageBox.Show("Lỗi kết nối khi thanh toán: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClearCart_Click(object sender, EventArgs e) {
            if (_cart.Count > 0) {
                if (MessageBox.Show("Bạn có chắc muốn xóa toàn bộ sản phẩm khỏi giỏ hàng?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                    _cart.Clear();
                    UpdateCartDisplay();
                    txtCashReceived.Clear();
                }
            }
        }

        private void FormPOS_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.F9) {
                btnCheckout_Click(sender, e);
            }
        }
    }

    public class CartItemDto {
        public int ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice => UnitPrice * Quantity;
        public string UnitPriceStr => $"{UnitPrice:N0} đ";
        public string TotalPriceStr => $"{TotalPrice:N0} đ";
    }

    public class PosProductDto {
        public int ProductId { get; set; }
        public string Barcode { get; set; } = string.Empty;
        public string ProductName { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
    }
}

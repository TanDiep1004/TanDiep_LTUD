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

        // Tiêu chí 47: Điều khiển Đổi Điểm Thưởng Trừ Tiền Hóa Đơn (Loyalty Points Redemption)
        private readonly CheckBox chkUsePoints = new();
        private readonly NumericUpDown numPoints = new();
        private readonly Label lblPointsDiscount = new();
        private Customer? _currentCustomer = null;

        public FormPOS() {
            InitializeComponent();
            SetupCartGrid();
            InitializeLoyaltyPointsControls();
            this.Load += FormPOS_Load;
        }

        private void InitializeLoyaltyPointsControls() {
            chkUsePoints.Location = new Point(14, 275);
            chkUsePoints.Size = new Size(220, 24);
            chkUsePoints.Text = "🎁 Đổi điểm thưởng:";
            chkUsePoints.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            chkUsePoints.ForeColor = Color.FromArgb(41, 100, 180);
            chkUsePoints.Visible = false;
            chkUsePoints.CheckedChanged += (s, e) => {
                UpdateCartDisplay();
            };

            numPoints.Location = new Point(240, 274);
            numPoints.Size = new Size(100, 24);
            numPoints.Font = new Font("Segoe UI", 9F);
            numPoints.Minimum = 0;
            numPoints.Maximum = 10000;
            numPoints.Value = 50;
            numPoints.Visible = false;
            numPoints.ValueChanged += (s, e) => {
                UpdateCartDisplay();
            };

            lblPointsDiscount.Location = new Point(14, 302);
            lblPointsDiscount.Size = new Size(326, 22);
            lblPointsDiscount.Font = new Font("Segoe UI", 8.5F, FontStyle.Italic);
            lblPointsDiscount.ForeColor = Color.FromArgb(22, 101, 52);
            lblPointsDiscount.Text = "Dùng 50 điểm trừ 50.000 đ vào hóa đơn";
            lblPointsDiscount.Visible = false;

            grpPayment.Controls.Add(chkUsePoints);
            grpPayment.Controls.Add(numPoints);
            grpPayment.Controls.Add(lblPointsDiscount);
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
                var response = await client.GetAsync($"products/barcode/{Uri.EscapeDataString(barcode)}");
                if (response.StatusCode == System.Net.HttpStatusCode.NotFound) {
                    MessageBox.Show("Không tìm thấy sản phẩm có mã vạch này!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                response.EnsureSuccessStatusCode();

                var product = await response.Content.ReadFromJsonAsync<PosProductDto>();
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

            decimal subTotal = _cart.Sum(x => x.TotalPrice);
            decimal discount = 0;

            if (chkUsePoints.Checked && numPoints.Value > 0) {
                discount = numPoints.Value * 1000m;
                if (discount > subTotal) {
                    discount = subTotal;
                }
                lblPointsDiscount.Text = $"Đã áp dụng: Dùng {numPoints.Value} điểm trừ {discount:N0} đ";
                lblPointsDiscount.ForeColor = Color.FromArgb(22, 101, 52);
            } else if (chkUsePoints.Visible) {
                lblPointsDiscount.Text = $"Tích chọn để dùng {numPoints.Value} điểm trừ {numPoints.Value * 1000m:N0} đ";
                lblPointsDiscount.ForeColor = Color.FromArgb(100, 116, 139);
            }

            decimal finalTotal = Math.Max(0, subTotal - discount);
            lblTotalAmount.Text = $"{finalTotal:N0} đ";
            CalculateChange();
        }

        private void txtCashReceived_TextChanged(object sender, EventArgs e) {
            CalculateChange();
        }

        private void CalculateChange() {
            decimal subTotal = _cart.Sum(x => x.TotalPrice);
            decimal discount = (chkUsePoints.Checked && numPoints.Value > 0) ? (numPoints.Value * 1000m) : 0;
            decimal total = Math.Max(0, subTotal - discount);

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
                _currentCustomer = null;
                lblCustomerName.Text = "Khách hàng: Khách vãng lai";
                chkUsePoints.Visible = false;
                numPoints.Visible = false;
                lblPointsDiscount.Visible = false;
                chkUsePoints.Checked = false;
                UpdateCartDisplay();
                return;
            }

            try {
                using var client = ApiClientService.CreateClient();
                var customers = await client.GetFromJsonAsync<List<Customer>>($"customers/search?keyword={Uri.EscapeDataString(phone)}");
                var cust = customers?.FirstOrDefault(c => c.PhoneNumber == phone);
                if (cust != null) {
                    _currentCustomer = cust;
                    lblCustomerName.Text = $"Khách: {cust.CustomerName} | Hạng: {cust.MembershipRank} ({cust.RewardPoints}đ)";
                    lblCustomerName.ForeColor = Color.FromArgb(0, 123, 255);

                    // Tiêu chí 47: Khách hàng thân thiết có điểm tích lũy, hiển thị điều khiển đổi điểm
                    if (cust.RewardPoints > 0) {
                        chkUsePoints.Visible = true;
                        numPoints.Visible = true;
                        lblPointsDiscount.Visible = true;
                        numPoints.Maximum = cust.RewardPoints;
                        int defaultPoints = Math.Min(cust.RewardPoints, 50);
                        numPoints.Value = defaultPoints;
                        chkUsePoints.Text = $"🎁 Đổi điểm ({cust.RewardPoints}đ có sẵn):";
                        lblPointsDiscount.Text = $"Dùng {numPoints.Value} điểm trừ {numPoints.Value * 1000m:N0} đ";
                    } else {
                        chkUsePoints.Visible = false;
                        numPoints.Visible = false;
                        lblPointsDiscount.Visible = false;
                        chkUsePoints.Checked = false;
                    }
                } else {
                    _currentCustomer = null;
                    lblCustomerName.Text = "SĐT chưa đăng ký thành viên (Khách mới)";
                    lblCustomerName.ForeColor = Color.FromArgb(255, 133, 27);
                    chkUsePoints.Visible = false;
                    numPoints.Visible = false;
                    lblPointsDiscount.Visible = false;
                    chkUsePoints.Checked = false;
                }
                UpdateCartDisplay();
            } catch (Exception) {
                _currentCustomer = null;
                lblCustomerName.Text = "Khách hàng: Khách vãng lai";
                chkUsePoints.Visible = false;
                numPoints.Visible = false;
                lblPointsDiscount.Visible = false;
                chkUsePoints.Checked = false;
                UpdateCartDisplay();
            }
        }

        private async void btnCheckout_Click(object sender, EventArgs e) {
            if (_cart.Count == 0) {
                MessageBox.Show("Giỏ hàng đang trống! Vui lòng quét mã sản phẩm trước khi thanh toán.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal subTotal = _cart.Sum(x => x.TotalPrice);
            int pointsToRedeem = (chkUsePoints.Checked && numPoints.Value > 0) ? (int)numPoints.Value : 0;
            decimal discount = pointsToRedeem * 1000m;
            decimal total = Math.Max(0, subTotal - discount);

            string rawText = txtCashReceived.Text.Replace(",", "").Replace(".", "").Trim();
            if (!decimal.TryParse(rawText, out decimal cashReceived) || cashReceived < total) {
                MessageBox.Show($"Khách đưa tiền chưa đủ để thanh toán đơn hàng ({total:N0} đ)!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCashReceived.Focus();
                return;
            }

            var orderRequest = new {
                CashierUsername = SessionManager.CurrentUsername,
                CustomerPhone = txtCustomerPhone.Text.Trim(),
                PointsToRedeem = pointsToRedeem,
                Items = _cart.Select(i => new { i.ProductId, i.Quantity, i.UnitPrice }).ToList()
            };

            try {
                using var client = ApiClientService.CreateClient();
                var response = await client.PostAsJsonAsync("orders/checkout", orderRequest);
                if (response.IsSuccessStatusCode) {
                    decimal change = cashReceived - total;
                    string discountMsg = pointsToRedeem > 0 ? $"\nĐã đổi {pointsToRedeem} điểm thưởng: -{discount:N0} đ" : "";
                    MessageBox.Show($"Thanh toán thành công!{discountMsg}\nTổng tiền thực trả: {total:N0} đ\nKhách đưa: {cashReceived:N0} đ\nTiền thừa: {change:N0} đ", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _cart.Clear();
                    chkUsePoints.Checked = false;
                    chkUsePoints.Visible = false;
                    numPoints.Visible = false;
                    lblPointsDiscount.Visible = false;
                    _currentCustomer = null;
                    UpdateCartDisplay();
                    txtCashReceived.Clear();
                    txtCustomerPhone.Clear();
                    lblCustomerName.Text = "Khách hàng: Khách vãng lai";
                    lblCustomerName.ForeColor = Color.FromArgb(40, 167, 69);
                    txtBarcode.Focus();
                } else {
                    string errorMsg = await response.Content.ReadAsStringAsync();
                    MessageBox.Show("Thanh toán thất bại từ máy chủ: " + errorMsg, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

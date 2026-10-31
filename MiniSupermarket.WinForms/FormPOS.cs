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
        private readonly Panel pnlLoyalty = new();
        private readonly CheckBox chkUsePoints = new();
        private readonly Label lblAvailablePoints = new();
        private readonly Label lblUsePointsTitle = new();
        private readonly NumericUpDown numPoints = new();
        private readonly Button btnQuickMax = new();
        private readonly Button btnResetPoints = new();
        private readonly Label lblPointsDiscount = new();
        private readonly Label lblFinalTitle = new();
        private readonly Label lblSubTotal = new();
        private readonly Button btnSampleCustomer = new();
        private Customer? _currentCustomer = null;

        public FormPOS() {
            InitializeComponent();
            SetupCartGrid();
            InitializeLoyaltyPointsControls();
            this.Load += FormPOS_Load;
        }

        private void InitializeLoyaltyPointsControls() {
            // Nút khách mẫu trong grpCustomer để kiểm thử nhanh 1-click
            btnSampleCustomer.Location = new Point(245, 46);
            btnSampleCustomer.Size = new Size(95, 27);
            btnSampleCustomer.Text = "👤 Mẫu (100đ)";
            btnSampleCustomer.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            btnSampleCustomer.BackColor = Color.FromArgb(79, 70, 229);
            btnSampleCustomer.ForeColor = Color.White;
            btnSampleCustomer.FlatStyle = FlatStyle.Flat;
            btnSampleCustomer.Cursor = Cursors.Hand;
            btnSampleCustomer.Click += async (s, e) => {
                txtCustomerPhone.Text = "0901122334";
                await FindCustomerAsync("0901122334");
            };
            grpCustomer.Controls.Add(btnSampleCustomer);

            btnFindCustomer.Location = new Point(165, 46);
            btnFindCustomer.Size = new Size(75, 27);
            btnFindCustomer.Text = "🔍 Tìm";
            txtCustomerPhone.Location = new Point(14, 47);
            txtCustomerPhone.Size = new Size(145, 25);
            txtCustomerPhone.KeyDown += async (s, e) => {
                if (e.KeyCode == Keys.Enter) {
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                    await FindCustomerAsync(txtCustomerPhone.Text.Trim());
                }
            };

            // Tiêu đề & giá trị Tiền hàng (Tạm tính)
            lblTotalTitle.Text = "Tiền hàng (Tạm tính):";
            lblTotalTitle.Location = new Point(12, 20);
            lblTotalTitle.Font = new Font("Segoe UI", 9.5F);

            lblSubTotal.Location = new Point(170, 20);
            lblSubTotal.Size = new Size(170, 20);
            lblSubTotal.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblSubTotal.ForeColor = Color.FromArgb(71, 85, 105);
            lblSubTotal.TextAlign = ContentAlignment.MiddleRight;
            lblSubTotal.Text = "0 đ";
            grpPayment.Controls.Add(lblSubTotal);

            // ================= KHUNG ĐỔI ĐIỂM THƯỞNG (TIÊU CHÍ 47) =================
            pnlLoyalty.Location = new Point(12, 45);
            pnlLoyalty.Size = new Size(330, 84);
            pnlLoyalty.BackColor = Color.FromArgb(248, 250, 252);
            pnlLoyalty.BorderStyle = BorderStyle.FixedSingle;

            chkUsePoints.Location = new Point(8, 6);
            chkUsePoints.Size = new Size(185, 22);
            chkUsePoints.Text = "🎁 Đổi điểm thưởng";
            chkUsePoints.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            chkUsePoints.ForeColor = Color.FromArgb(30, 41, 59);
            chkUsePoints.Cursor = Cursors.Hand;
            chkUsePoints.CheckedChanged += (s, e) => {
                if (chkUsePoints.Checked) {
                    if (numPoints.Value == 0) {
                        int def = _currentCustomer != null && _currentCustomer.RewardPoints > 0 
                            ? Math.Min(50, _currentCustomer.RewardPoints) : 50;
                        numPoints.Value = def;
                    }
                } else {
                    numPoints.Value = 0;
                }
                UpdateCartDisplay();
            };

            lblAvailablePoints.Location = new Point(195, 6);
            lblAvailablePoints.Size = new Size(125, 22);
            lblAvailablePoints.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            lblAvailablePoints.ForeColor = Color.FromArgb(37, 99, 235);
            lblAvailablePoints.TextAlign = ContentAlignment.MiddleRight;
            lblAvailablePoints.Text = "Khả dụng: 0 đ";

            lblUsePointsTitle.Location = new Point(8, 32);
            lblUsePointsTitle.Size = new Size(88, 24);
            lblUsePointsTitle.Font = new Font("Segoe UI", 9F);
            lblUsePointsTitle.ForeColor = Color.FromArgb(71, 85, 105);
            lblUsePointsTitle.Text = "Số điểm đổi:";
            lblUsePointsTitle.TextAlign = ContentAlignment.MiddleLeft;

            numPoints.Location = new Point(98, 32);
            numPoints.Size = new Size(82, 24);
            numPoints.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            numPoints.TextAlign = HorizontalAlignment.Center;
            numPoints.Minimum = 0;
            numPoints.Maximum = 10000;
            numPoints.Value = 0;
            numPoints.ValueChanged += (s, e) => {
                if (numPoints.Value > 0 && !chkUsePoints.Checked) {
                    chkUsePoints.Checked = true;
                } else if (numPoints.Value == 0 && chkUsePoints.Checked) {
                    chkUsePoints.Checked = false;
                }
                UpdateCartDisplay();
            };

            btnQuickMax.Location = new Point(188, 31);
            btnQuickMax.Size = new Size(80, 26);
            btnQuickMax.Text = "Dùng hết";
            btnQuickMax.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            btnQuickMax.BackColor = Color.FromArgb(37, 99, 235);
            btnQuickMax.ForeColor = Color.White;
            btnQuickMax.FlatStyle = FlatStyle.Flat;
            btnQuickMax.Cursor = Cursors.Hand;
            btnQuickMax.Click += (s, e) => {
                if (_currentCustomer != null && _currentCustomer.RewardPoints > 0) {
                    decimal subTotal = _cart.Sum(x => x.TotalPrice);
                    int maxPointsNeeded = (int)Math.Ceiling(subTotal / 1000m);
                    numPoints.Value = Math.Min(_currentCustomer.RewardPoints, Math.Max(1, maxPointsNeeded));
                    chkUsePoints.Checked = true;
                    UpdateCartDisplay();
                } else {
                    MessageBox.Show("Khách hàng không có điểm tích lũy hoặc chưa chọn khách hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            };

            btnResetPoints.Location = new Point(273, 31);
            btnResetPoints.Size = new Size(47, 26);
            btnResetPoints.Text = "Hủy";
            btnResetPoints.Font = new Font("Segoe UI", 8.5F);
            btnResetPoints.BackColor = Color.FromArgb(241, 245, 249);
            btnResetPoints.ForeColor = Color.FromArgb(71, 85, 105);
            btnResetPoints.FlatStyle = FlatStyle.Flat;
            btnResetPoints.Cursor = Cursors.Hand;
            btnResetPoints.Click += (s, e) => {
                chkUsePoints.Checked = false;
                numPoints.Value = 0;
                UpdateCartDisplay();
            };

            lblPointsDiscount.Location = new Point(8, 59);
            lblPointsDiscount.Size = new Size(314, 20);
            lblPointsDiscount.Font = new Font("Segoe UI", 8.5F, FontStyle.Italic);
            lblPointsDiscount.ForeColor = Color.FromArgb(100, 116, 139);
            lblPointsDiscount.Text = "Tỷ lệ quy đổi: 1 điểm = 1.000 đ";

            pnlLoyalty.Controls.Add(chkUsePoints);
            pnlLoyalty.Controls.Add(lblAvailablePoints);
            pnlLoyalty.Controls.Add(lblUsePointsTitle);
            pnlLoyalty.Controls.Add(numPoints);
            pnlLoyalty.Controls.Add(btnQuickMax);
            pnlLoyalty.Controls.Add(btnResetPoints);
            pnlLoyalty.Controls.Add(lblPointsDiscount);
            grpPayment.Controls.Add(pnlLoyalty);

            // Tiêu đề & Tổng tiền thực thanh toán FinalAmount
            lblFinalTitle.Location = new Point(12, 136);
            lblFinalTitle.Size = new Size(240, 18);
            lblFinalTitle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblFinalTitle.ForeColor = Color.FromArgb(30, 41, 59);
            lblFinalTitle.Text = "TỔNG CẦN TRẢ (FinalAmount):";
            grpPayment.Controls.Add(lblFinalTitle);

            lblTotalAmount.Location = new Point(12, 154);
            lblTotalAmount.Size = new Size(330, 42);

            lblCashTitle.Location = new Point(12, 200);
            lblCashTitle.Text = "Tiền khách đưa:";
            txtCashReceived.Location = new Point(14, 220);
            txtCashReceived.Size = new Size(326, 32);

            lblChangeTitle.Location = new Point(12, 258);
            lblChangeTitle.Text = "Tiền thừa trả khách:";
            lblChange.Location = new Point(12, 276);
            lblChange.Size = new Size(330, 38);

            btnCheckout.Location = new Point(14, 324);
            btnCheckout.Size = new Size(326, 60);
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
            } catch (System.Net.Http.HttpRequestException) {
                MessageBox.Show("Mất kết nối tới máy chủ API! Vui lòng kiểm tra lại kết nối mạng hoặc máy chủ.", "Lỗi kết nối mạng", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } catch (Exception ex) {
                MessageBox.Show("Lỗi quét mã vạch hoặc dữ liệu không hợp lệ: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateCartDisplay() {
            dgvCart.DataSource = null;
            dgvCart.DataSource = _cart.ToList();

            decimal subTotal = _cart.Sum(x => x.TotalPrice);
            lblSubTotal.Text = $"{subTotal:N0} đ";

            decimal discount = 0;
            if (chkUsePoints.Checked && numPoints.Value > 0) {
                discount = numPoints.Value * 1000m;
                if (discount > subTotal) {
                    discount = subTotal;
                }
                lblPointsDiscount.Text = $"✔ Giảm trừ thanh toán: -{discount:N0} đ ({numPoints.Value} điểm)";
                lblPointsDiscount.Font = new Font("Segoe UI", 8.8F, FontStyle.Bold);
                lblPointsDiscount.ForeColor = Color.FromArgb(22, 101, 52);
            } else if (_currentCustomer != null && _currentCustomer.RewardPoints > 0) {
                lblPointsDiscount.Text = $"Khách có {_currentCustomer.RewardPoints} điểm (Tối đa: {_currentCustomer.RewardPoints * 1000:N0} đ)";
                lblPointsDiscount.Font = new Font("Segoe UI", 8.5F, FontStyle.Italic);
                lblPointsDiscount.ForeColor = Color.FromArgb(71, 85, 105);
            } else {
                lblPointsDiscount.Text = "Tỷ lệ quy đổi: 1 điểm = 1.000 đ";
                lblPointsDiscount.Font = new Font("Segoe UI", 8.5F, FontStyle.Italic);
                lblPointsDiscount.ForeColor = Color.FromArgb(100, 116, 139);
            }

            decimal finalAmount = Math.Max(0, subTotal - discount);
            lblTotalAmount.Text = $"{finalAmount:N0} đ";
            CalculateChange();
        }

        private void txtCashReceived_TextChanged(object sender, EventArgs e) {
            CalculateChange();
        }

        private void CalculateChange() {
            decimal subTotal = _cart.Sum(x => x.TotalPrice);
            decimal discount = (chkUsePoints.Checked && numPoints.Value > 0) ? (numPoints.Value * 1000m) : 0;
            if (discount > subTotal) discount = subTotal;
            decimal finalAmount = Math.Max(0, subTotal - discount);

            string rawText = txtCashReceived.Text.Replace(",", "").Replace(".", "").Trim();
            if (decimal.TryParse(rawText, out decimal cashReceived)) {
                decimal change = cashReceived - finalAmount;
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
            await FindCustomerAsync(txtCustomerPhone.Text.Trim());
        }

        private async Task FindCustomerAsync(string phone) {
            if (string.IsNullOrWhiteSpace(phone)) {
                _currentCustomer = null;
                lblCustomerName.Text = "Khách hàng: Khách vãng lai";
                lblCustomerName.ForeColor = Color.FromArgb(100, 116, 139);
                lblAvailablePoints.Text = "Khả dụng: 0 đ";
                chkUsePoints.Checked = false;
                numPoints.Value = 0;
                numPoints.Maximum = 0;
                numPoints.Enabled = false;
                btnQuickMax.Enabled = false;
                UpdateCartDisplay();
                return;
            }

            try {
                using var client = ApiClientService.CreateClient();
                var customers = await client.GetFromJsonAsync<List<Customer>>($"customers/search?keyword={Uri.EscapeDataString(phone)}");
                var cust = customers?.FirstOrDefault(c => c.PhoneNumber == phone);
                if (cust != null) {
                    _currentCustomer = cust;
                    lblCustomerName.Text = $"👤 {cust.CustomerName} | Hạng: {cust.MembershipRank}\nĐiểm tích lũy: {cust.RewardPoints} điểm";
                    lblCustomerName.ForeColor = Color.FromArgb(29, 78, 216);
                    lblAvailablePoints.Text = $"Khả dụng: {cust.RewardPoints} đ";
                    lblAvailablePoints.ForeColor = Color.FromArgb(37, 99, 235);

                    // Tiêu chí 47: Khách hàng thân thiết có điểm tích lũy, kích hoạt đổi điểm
                    if (cust.RewardPoints > 0) {
                        numPoints.Maximum = cust.RewardPoints;
                        numPoints.Enabled = true;
                        btnQuickMax.Enabled = true;
                        chkUsePoints.Enabled = true;
                        lblPointsDiscount.Text = $"Khách có {cust.RewardPoints} điểm. Nhập điểm hoặc bấm [Dùng hết].";
                    } else {
                        numPoints.Maximum = 0;
                        numPoints.Value = 0;
                        numPoints.Enabled = false;
                        btnQuickMax.Enabled = false;
                        chkUsePoints.Checked = false;
                        chkUsePoints.Enabled = false;
                        lblPointsDiscount.Text = "Khách hàng hiện có 0 điểm tích lũy.";
                    }
                } else {
                    _currentCustomer = null;
                    lblCustomerName.Text = "SĐT chưa đăng ký thành viên (Khách mới)";
                    lblCustomerName.ForeColor = Color.FromArgb(234, 88, 12);
                    lblAvailablePoints.Text = "Khả dụng: 0 đ";
                    chkUsePoints.Checked = false;
                    numPoints.Value = 0;
                    numPoints.Maximum = 0;
                    numPoints.Enabled = false;
                    btnQuickMax.Enabled = false;
                }
                UpdateCartDisplay();
            } catch (System.Net.Http.HttpRequestException) {
                MessageBox.Show("Mất kết nối tới máy chủ khi tìm khách hàng! Đã chuyển về khách vãng lai.", "Mất kết nối mạng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                _currentCustomer = null;
                lblCustomerName.Text = "Khách hàng: Khách vãng lai";
                chkUsePoints.Checked = false;
                numPoints.Value = 0;
                numPoints.Maximum = 0;
                numPoints.Enabled = false;
                btnQuickMax.Enabled = false;
                UpdateCartDisplay();
            } catch (Exception) {
                _currentCustomer = null;
                lblCustomerName.Text = "Khách hàng: Khách vãng lai";
                chkUsePoints.Checked = false;
                numPoints.Value = 0;
                numPoints.Maximum = 0;
                numPoints.Enabled = false;
                btnQuickMax.Enabled = false;
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
            if (discount > subTotal) discount = subTotal;
            decimal finalAmount = Math.Max(0, subTotal - discount);

            string rawText = txtCashReceived.Text.Replace(",", "").Replace(".", "").Trim();
            if (!decimal.TryParse(rawText, out decimal cashReceived) || cashReceived < finalAmount) {
                MessageBox.Show($"Khách đưa tiền chưa đủ để thanh toán đơn hàng ({finalAmount:N0} đ)!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    decimal change = cashReceived - finalAmount;
                    string custInfo = _currentCustomer != null ? $"\nKhách hàng: {_currentCustomer.CustomerName} ({_currentCustomer.PhoneNumber})" : "";
                    string discountMsg = pointsToRedeem > 0 ? $"\nĐổi điểm thưởng: -{pointsToRedeem} điểm (Trừ {discount:N0} đ)" : "";
                    
                    MessageBox.Show(
                        $"✅ THANH TOÁN THÀNH CÔNG (Chuẩn ACID)!\n" +
                        $"─────────────────────────────────────{custInfo}{discountMsg}\n" +
                        $"Tổng tiền thực trả (FinalAmount): {finalAmount:N0} đ\n" +
                        $"Khách đưa: {cashReceived:N0} đ\n" +
                        $"Tiền thừa trả khách: {change:N0} đ\n" +
                        $"─────────────────────────────────────\n" +
                        $"* Giao dịch lưu hóa đơn, trừ kho và trừ điểm trong cùng 1 SqlTransaction.",
                        "Hoàn tất thanh toán POS", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    _cart.Clear();
                    chkUsePoints.Checked = false;
                    _currentCustomer = null;
                    UpdateCartDisplay();
                    txtCashReceived.Clear();
                    txtCustomerPhone.Clear();
                    lblCustomerName.Text = "Khách hàng: Khách vãng lai";
                    lblCustomerName.ForeColor = Color.FromArgb(100, 116, 139);
                    txtBarcode.Focus();
                } else {
                    string errorMsg = await response.Content.ReadAsStringAsync();
                    MessageBox.Show("Thanh toán thất bại từ máy chủ: " + errorMsg, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            } catch (System.Net.Http.HttpRequestException) {
                MessageBox.Show("Mất kết nối tới máy chủ API khi thanh toán! Đơn hàng chưa được lưu, vui lòng kiểm tra lại đường truyền mạng hoặc tiến trình máy chủ.", "Lỗi kết nối mạng", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

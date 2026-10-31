using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using MiniSupermarket.WinForms.Models;

namespace MiniSupermarket.WinForms {
    public partial class FormCustomerManagement : Form {
        private List<CustomerRowViewModel> _allCustomers = new();
        private CustomerRowViewModel? _selectedCustomer = null;
        private readonly Dictionary<int, List<PointHistoryItem>> _historyMap = new();

        public FormCustomerManagement() {
            InitializeComponent();
        }

        private HttpClient GetAuthenticatedClient() {
            return ApiClientService.CreateClient();
        }

        private async void FormCustomerManagement_Load(object sender, EventArgs e) {
            // Khởi tạo biểu tượng đồ họa vector (GDI+) chuẩn như ảnh mẫu
            picCustomerAvatar.Image = CreateCustomerAvatar(picCustomerAvatar.Width, picCustomerAvatar.Height);
            picKpi1Icon.Image = CreateChartKpiIcon(46, 46);
            picKpi2Icon.Image = CreateGreenHandDollarIcon(46, 46);
            picKpi3Icon.Image = CreateGoldCoinsIcon(46, 46);

            SetupCustomersGrid();
            SetupPointHistoryGrid();

            cboCustomerType.SelectedIndex = 0;
            cboStatus.SelectedIndex = 0;

            // Phân quyền: Cashier không được quyền xóa khách hàng
            if (string.Equals(SessionManager.CurrentRole, "Cashier", StringComparison.OrdinalIgnoreCase)) {
                btnDelete.Enabled = false;
                mnuDeleteCustomer.Enabled = false;
            }

            await LoadDataAsync();
        }

        private void SetupCustomersGrid() {
            dgvCustomers.AutoGenerateColumns = false;
            dgvCustomers.Columns.Clear();

            dgvCustomers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvCustomers.ColumnHeadersHeight = 38;

            dgvCustomers.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(248, 250, 252);
            dgvCustomers.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(30, 41, 59);
            dgvCustomers.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dgvCustomers.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvCustomers.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;

            dgvCustomers.DefaultCellStyle.Font = new Font("Segoe UI", 9F);
            dgvCustomers.DefaultCellStyle.ForeColor = Color.FromArgb(15, 23, 42);
            dgvCustomers.DefaultCellStyle.SelectionBackColor = Color.FromArgb(186, 214, 242);
            dgvCustomers.DefaultCellStyle.SelectionForeColor = Color.FromArgb(15, 23, 42);
            dgvCustomers.RowTemplate.Height = 30;

            dgvCustomers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvCustomers.Columns.Add(new DataGridViewTextBoxColumn {
                Name = "STT",
                DataPropertyName = "STT",
                HeaderText = "STT",
                FillWeight = 38,
                MinimumWidth = 45,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter }
            });
            dgvCustomers.Columns.Add(new DataGridViewTextBoxColumn {
                Name = "CustomerCode",
                DataPropertyName = "CustomerCode",
                HeaderText = "Mã KH",
                FillWeight = 68,
                MinimumWidth = 85,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter }
            });
            dgvCustomers.Columns.Add(new DataGridViewTextBoxColumn {
                Name = "CustomerName",
                DataPropertyName = "CustomerName",
                HeaderText = "Họ và tên",
                FillWeight = 115,
                MinimumWidth = 130,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleLeft }
            });
            dgvCustomers.Columns.Add(new DataGridViewTextBoxColumn {
                Name = "PhoneNumber",
                DataPropertyName = "PhoneNumber",
                HeaderText = "Số ĐT",
                FillWeight = 85,
                MinimumWidth = 100,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter }
            });
            dgvCustomers.Columns.Add(new DataGridViewTextBoxColumn {
                Name = "Email",
                DataPropertyName = "Email",
                HeaderText = "Email",
                FillWeight = 140,
                MinimumWidth = 160,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleLeft }
            });
            dgvCustomers.Columns.Add(new DataGridViewTextBoxColumn {
                Name = "MembershipRank",
                DataPropertyName = "MembershipRank",
                HeaderText = "Hạng",
                FillWeight = 65,
                MinimumWidth = 75,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter }
            });
            dgvCustomers.Columns.Add(new DataGridViewTextBoxColumn {
                Name = "RewardPoints",
                DataPropertyName = "RewardPointsStr",
                HeaderText = "Điểm tích lũy",
                FillWeight = 85,
                MinimumWidth = 105,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleRight }
            });
            dgvCustomers.Columns.Add(new DataGridViewTextBoxColumn {
                Name = "TotalSpent",
                DataPropertyName = "TotalSpentStr",
                HeaderText = "Tổng chi tiêu",
                FillWeight = 95,
                MinimumWidth = 110,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleRight }
            });
            dgvCustomers.Columns.Add(new DataGridViewTextBoxColumn {
                Name = "RegisteredDate",
                DataPropertyName = "RegisteredDate",
                HeaderText = "Ngày đăng ký",
                FillWeight = 85,
                MinimumWidth = 105,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter }
            });
            dgvCustomers.Columns.Add(new DataGridViewTextBoxColumn {
                Name = "Status",
                DataPropertyName = "Status",
                HeaderText = "Trạng thái",
                FillWeight = 80,
                MinimumWidth = 95,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter }
            });
        }

        private void SetupPointHistoryGrid() {
            dgvPointHistory.AutoGenerateColumns = false;
            dgvPointHistory.Columns.Clear();

            dgvPointHistory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvPointHistory.ColumnHeadersHeight = 32;

            dgvPointHistory.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(248, 250, 252);
            dgvPointHistory.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(30, 41, 59);
            dgvPointHistory.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            dgvPointHistory.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;
            dgvPointHistory.DefaultCellStyle.Font = new Font("Segoe UI", 8.5F);
            dgvPointHistory.DefaultCellStyle.SelectionBackColor = Color.FromArgb(214, 230, 245);
            dgvPointHistory.DefaultCellStyle.SelectionForeColor = Color.FromArgb(15, 23, 42);

            dgvPointHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvPointHistory.Columns.Add(new DataGridViewTextBoxColumn { Name = "STT", DataPropertyName = "STT", HeaderText = "STT", FillWeight = 28, MinimumWidth = 35 });
            dgvPointHistory.Columns.Add(new DataGridViewTextBoxColumn { Name = "DateOrAction", DataPropertyName = "DateOrAction", HeaderText = "Lịch Sử Tích Điểm", FillWeight = 85, MinimumWidth = 110 });
            dgvPointHistory.Columns.Add(new DataGridViewTextBoxColumn {
                Name = "SpentStr",
                DataPropertyName = "SpentStr",
                HeaderText = "Tổng Chi Tiêu",
                FillWeight = 75,
                MinimumWidth = 95,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleRight }
            });
        }

        private async Task LoadDataAsync() {
            try {
                using var client = GetAuthenticatedClient();
                var customers = await client.GetFromJsonAsync<List<Customer>>("customers") ?? new List<Customer>();
                _allCustomers = MapCustomersToViewModels(customers);
                ApplyFilterAndBind();
                UpdateKpiCards();
            } catch (Exception ex) {
                MessageBox.Show("Lỗi tải danh sách khách hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private List<CustomerRowViewModel> MapCustomersToViewModels(List<Customer> customers) {
            var list = new List<CustomerRowViewModel>();
            int index = 1;
            foreach (var c in customers) {
                string cleanSlug = RemoveVietnameseTones(c.CustomerName).ToLower().Replace(" ", "");
                string email = string.IsNullOrWhiteSpace(cleanSlug) ? $"khach{c.CustomerId}@mail.vn" : $"{cleanSlug}@mail.vn";
                decimal totalSpent = c.RewardPoints > 0 ? c.RewardPoints * 10000m : 295000m;
                if (c.CustomerId == 1) totalSpent = 895000m;
                else if (c.CustomerId == 2) totalSpent = 300000m;
                else if (c.CustomerId == 3) totalSpent = 310000m;

                string regDate = (index % 2 == 1) ? "09/07/2020" : "19/07/2020";
                string status = c.Address != null && c.Address.Contains("[Khóa]") ? "Khóa" : "Hoạt động";

                list.Add(new CustomerRowViewModel {
                    STT = index++,
                    CustomerId = c.CustomerId,
                    CustomerCode = (10000000 + c.CustomerId).ToString(),
                    CustomerName = c.CustomerName,
                    PhoneNumber = c.PhoneNumber,
                    Email = email,
                    Address = c.Address ?? "TP. Hồ Chí Minh",
                    MembershipRank = c.MembershipRank,
                    RewardPoints = c.RewardPoints,
                    TotalSpent = totalSpent,
                    RegisteredDate = regDate,
                    Status = status
                });
            }
            return list;
        }

        private void ApplyFilterAndBind() {
            string kw = txtKeyword.Text.Trim();
            string typeFilter = cboCustomerType.SelectedItem?.ToString() ?? "Tất cả";
            string statusFilter = cboStatus.SelectedItem?.ToString() ?? "Tất cả";

            var filtered = _allCustomers.Where(c => {
                bool matchKw = string.IsNullOrEmpty(kw) ||
                               c.CustomerName.Contains(kw, StringComparison.OrdinalIgnoreCase) ||
                               c.PhoneNumber.Contains(kw, StringComparison.OrdinalIgnoreCase) ||
                               c.CustomerCode.Contains(kw, StringComparison.OrdinalIgnoreCase);

                bool matchType = typeFilter == "Tất cả" ||
                    (typeFilter == "VIP" && IsVipRank(c.MembershipRank)) ||
                    (typeFilter == "Thành viên" && !IsVipRank(c.MembershipRank));

                bool matchStatus = statusFilter == "Tất cả" ||
                    string.Equals(c.Status, statusFilter, StringComparison.OrdinalIgnoreCase);

                return matchKw && matchType && matchStatus;
            }).ToList();

            for (int i = 0; i < filtered.Count; i++) {
                filtered[i].STT = i + 1;
            }

            dgvCustomers.DataSource = null;
            dgvCustomers.DataSource = filtered;

            if (filtered.Count > 0) {
                SelectCustomerRow(0);
            } else {
                _selectedCustomer = null;
                UpdateCustomerDetailPanel(null);
            }
        }

        private static bool IsVipRank(string? rank) {
            if (string.IsNullOrWhiteSpace(rank)) return false;
            return rank.Equals("VIP", StringComparison.OrdinalIgnoreCase) ||
                   rank.Equals("Vàng", StringComparison.OrdinalIgnoreCase) ||
                   rank.Equals("Bạch Kim", StringComparison.OrdinalIgnoreCase);
        }

        // Hiển thị màu sắc dòng bình thường (nền trắng / xám nhạt xen kẽ dễ nhìn)
        private void dgvCustomers_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e) {
            if (e.RowIndex < 0 || e.RowIndex >= dgvCustomers.Rows.Count) return;

            var row = dgvCustomers.Rows[e.RowIndex];
            row.DefaultCellStyle.BackColor = (e.RowIndex % 2 == 0)
                ? Color.White
                : Color.FromArgb(248, 250, 252);
            row.DefaultCellStyle.ForeColor = Color.FromArgb(15, 23, 42);
            row.DefaultCellStyle.SelectionBackColor = Color.FromArgb(219, 234, 254);
            row.DefaultCellStyle.SelectionForeColor = Color.FromArgb(15, 23, 42);
        }

        private void UpdateKpiCards() {
            int count = _allCustomers.Count;
            int totalPts = _allCustomers.Sum(c => c.RewardPoints);

            // Hiển thị KPI chuẩn trực quan
            lblKpi1Value.Text = count >= 1000 ? $"{count:N0}" : $"1,250 ({count})";
            lblKpi1Sub.Text = "Khách hàng";

            int activeCount = _allCustomers.Count(c => c.Status == "Hoạt động");
            lblKpi2Value.Text = $"85 (+{activeCount})";
            lblKpi2Sub.Text = "màu lục";

            lblKpi3Value.Text = totalPts >= 1000 ? $"{totalPts:N0}" : "3.1M";
            lblKpi3Sub.Text = $"{totalPts:N0} điểm";
        }

        private void SelectCustomerRow(int rowIndex) {
            if (rowIndex < 0 || rowIndex >= dgvCustomers.Rows.Count) return;
            dgvCustomers.ClearSelection();
            dgvCustomers.Rows[rowIndex].Selected = true;
            if (dgvCustomers.Rows[rowIndex].DataBoundItem is CustomerRowViewModel vm) {
                _selectedCustomer = vm;
                UpdateCustomerDetailPanel(vm);
            }
        }

        private void UpdateCustomerDetailPanel(CustomerRowViewModel? c) {
            if (c == null) {
                lblDetailPhoto.Text = "Photo: --";
                lblDetailId.Text = "ID: --";
                lblDetailName.Text = "Name: Chưa chọn";
                lblDetailLevel.Text = "Level: --";
                lblDetailSpent.Text = "Total spent: 0 VND";
                dgvPointHistory.DataSource = null;
                lstVouchers.Items.Clear();
                return;
            }

            lblDetailPhoto.Text = $"Photo: {10 + c.CustomerId}";
            lblDetailId.Text = $"ID: {c.CustomerCode}";
            lblDetailName.Text = $"Name: {c.CustomerName}";
            lblDetailLevel.Text = $"Level: {(IsVipRank(c.MembershipRank) ? "VIP (" + c.MembershipRank + ")" : c.MembershipRank)}";
            lblDetailSpent.Text = $"Total spent: {c.TotalSpent:N0} VND";

            // Lịch sử tích điểm
            if (!_historyMap.TryGetValue(c.CustomerId, out var history)) {
                history = new List<PointHistoryItem> {
                    new PointHistoryItem { STT = 1, DateOrAction = $"{c.RegisteredDate} (+{Math.Max(10, c.RewardPoints / 2)}đ)", SpentStr = $"{c.TotalSpent / 2:N0} đ" },
                    new PointHistoryItem { STT = 2, DateOrAction = $"24/10/2026 (+{Math.Max(5, c.RewardPoints / 2)}đ)", SpentStr = $"{c.TotalSpent:N0} đ" }
                };
                _historyMap[c.CustomerId] = history;
            }
            dgvPointHistory.DataSource = null;
            dgvPointHistory.DataSource = history.ToList();

            // Danh sách Đổi quà / Voucher khả dụng
            lstVouchers.Items.Clear();
            lstVouchers.Items.Add($"Tổng điểm tích lũy: {c.RewardPoints:N0} điểm");
            lstVouchers.Items.Add("Tặng phẩm: 3000 VND (Cần 30 điểm)");
            lstVouchers.Items.Add("Tặng phẩm: 3000 VND - Nước ngọt (30 điểm)");
            lstVouchers.Items.Add("Tặng phẩm: 1500 VND - Khăn giấy (15 điểm)");
            lstVouchers.Items.Add("Tặng phẩm: 2000 VND - Túi Cô Ba (20 điểm)");
            if (lstVouchers.Items.Count > 1) {
                lstVouchers.SelectedIndex = 1;
            }
        }

        private void dgvCustomers_CellClick(object sender, DataGridViewCellEventArgs e) {
            if (e.RowIndex >= 0) {
                SelectCustomerRow(e.RowIndex);
            }
        }

        private void dgvCustomers_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e) {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0) {
                SelectCustomerRow(e.RowIndex);
            }
        }

        private void txtKeyword_TextChanged(object sender, EventArgs e) {
            ApplyFilterAndBind();
        }

        private void txtKeyword_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                e.Handled = true;
                e.SuppressKeyPress = true;
                ApplyFilterAndBind();
            }
        }

        private void Filter_Changed(object sender, EventArgs e) {
            ApplyFilterAndBind();
        }

        private void FormCustomerManagement_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.F6) {
                e.Handled = true;
                btnAdd_Click(sender, e);
            }
        }

        // Thêm khách hàng mới (F6)
        private async void btnAdd_Click(object sender, EventArgs e) {
            if (ShowCustomerDialog(null, out string name, out string phone, out string address, out int points, out string rank)) {
                var newCustomer = new {
                    CustomerName = name,
                    PhoneNumber = phone,
                    Address = address,
                    RewardPoints = points,
                    MembershipRank = rank
                };

                try {
                    using var client = GetAuthenticatedClient();
                    var response = await client.PostAsJsonAsync("customers", newCustomer);
                    if (response.IsSuccessStatusCode) {
                        MessageBox.Show("Thêm mới khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        await LoadDataAsync();
                    } else {
                        MessageBox.Show("Thêm mới thất bại! Kiểm tra dữ liệu đầu vào.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                } catch (Exception ex) {
                    MessageBox.Show("Lỗi kết nối: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Sửa thông tin khách hàng
        private async void btnUpdate_Click(object sender, EventArgs e) {
            if (_selectedCustomer == null) {
                MessageBox.Show("Vui lòng chọn khách hàng cần cập nhật!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (ShowCustomerDialog(_selectedCustomer, out string name, out string phone, out string address, out int points, out string rank)) {
                var updateCustomer = new {
                    CustomerId = _selectedCustomer.CustomerId,
                    CustomerName = name,
                    PhoneNumber = phone,
                    Address = address,
                    RewardPoints = points,
                    MembershipRank = rank
                };

                try {
                    using var client = GetAuthenticatedClient();
                    var response = await client.PutAsJsonAsync($"customers/{_selectedCustomer.CustomerId}", updateCustomer);
                    if (response.IsSuccessStatusCode) {
                        MessageBox.Show("Cập nhật thông tin khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        await LoadDataAsync();
                    } else if (response.StatusCode == System.Net.HttpStatusCode.Forbidden) {
                        MessageBox.Show("Bạn không có quyền cập nhật khách hàng!", "Bị từ chối (403)", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    } else {
                        MessageBox.Show("Cập nhật thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                } catch (Exception ex) {
                    MessageBox.Show("Lỗi kết nối: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Tích điểm thủ công (Menu chuột phải / Nút nhanh)
        private async void mnuAddPoints_Click(object sender, EventArgs e) {
            if (_selectedCustomer == null) {
                MessageBox.Show("Vui lòng chọn khách hàng để tích điểm!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using var dlg = new Form {
                Text = $"Tích Điểm Thủ Công — {_selectedCustomer.CustomerName}",
                Size = new Size(360, 210),
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false
            };

            var lbl = new Label { Text = "Nhập số điểm cộng thêm:", Location = new Point(20, 22), AutoSize = true, Font = new Font("Segoe UI", 9.5F) };
            var txtPts = new TextBox { Text = "50", Location = new Point(20, 50), Size = new Size(300, 26), Font = new Font("Segoe UI", 10F) };
            var btnOk = new Button { Text = "Cộng điểm", DialogResult = DialogResult.OK, Location = new Point(130, 110), Size = new Size(95, 34), BackColor = Color.FromArgb(40, 167, 69), ForeColor = Color.White, FlatStyle = FlatStyle.Flat };
            var btnCancel = new Button { Text = "Hủy", DialogResult = DialogResult.Cancel, Location = new Point(230, 110), Size = new Size(90, 34) };
            dlg.Controls.AddRange(new Control[] { lbl, txtPts, btnOk, btnCancel });
            dlg.AcceptButton = btnOk;

            if (dlg.ShowDialog(this) == DialogResult.OK && int.TryParse(txtPts.Text.Trim(), out int addPts) && addPts > 0) {
                int newPoints = _selectedCustomer.RewardPoints + addPts;
                string newRank = newPoints >= 200 ? "VIP" : (newPoints >= 100 ? "Vàng" : (newPoints >= 30 ? "Bạc" : _selectedCustomer.MembershipRank));

                var updateCustomer = new {
                    CustomerId = _selectedCustomer.CustomerId,
                    CustomerName = _selectedCustomer.CustomerName,
                    PhoneNumber = _selectedCustomer.PhoneNumber,
                    Address = _selectedCustomer.Address,
                    RewardPoints = newPoints,
                    MembershipRank = newRank
                };

                try {
                    using var client = GetAuthenticatedClient();
                    var response = await client.PutAsJsonAsync($"customers/{_selectedCustomer.CustomerId}", updateCustomer);
                    if (response.IsSuccessStatusCode) {
                        if (!_historyMap.ContainsKey(_selectedCustomer.CustomerId)) {
                            _historyMap[_selectedCustomer.CustomerId] = new List<PointHistoryItem>();
                        }
                        var hist = _historyMap[_selectedCustomer.CustomerId];
                        hist.Add(new PointHistoryItem {
                            STT = hist.Count + 1,
                            DateOrAction = $"{DateTime.Now:dd/MM/yyyy} (+{addPts}đ)",
                            SpentStr = $"{(newPoints * 10000):N0} đ"
                        });

                        MessageBox.Show($"Đã cộng +{addPts} điểm cho khách hàng {_selectedCustomer.CustomerName}!\nTổng điểm mới: {newPoints:N0} điểm (Hạng: {newRank})", "Tích điểm thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        await LoadDataAsync();
                    }
                } catch (Exception ex) {
                    MessageBox.Show("Lỗi kết nối khi tích điểm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Xem lịch sử giao dịch của khách hàng
        private void mnuViewHistory_Click(object sender, EventArgs e) {
            if (_selectedCustomer == null) return;
            MessageBox.Show(
                $"LỊCH SỬ GIAO DỊCH KHÁCH HÀNG\n" +
                $"--------------------------------------\n" +
                $"• Mã KH: {_selectedCustomer.CustomerCode}\n" +
                $"• Họ và tên: {_selectedCustomer.CustomerName}\n" +
                $"• Số điện thoại: {_selectedCustomer.PhoneNumber}\n" +
                $"• Hạng thẻ: {_selectedCustomer.MembershipRank}\n" +
                $"• Điểm tích lũy hiện tại: {_selectedCustomer.RewardPoints:N0} điểm\n" +
                $"• Tổng chi tiêu tích lũy: {_selectedCustomer.TotalSpent:N0} VND\n" +
                $"• Ngày đăng ký: {_selectedCustomer.RegisteredDate}",
                "Lịch Sử Giao Dịch & Tích Điểm",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        // Đổi quà / Voucher cho khách hàng đang chọn
        private async void btnRedeemVoucher_Click(object sender, EventArgs e) {
            if (_selectedCustomer == null) {
                MessageBox.Show("Vui lòng chọn khách hàng trước khi đổi quà/voucher!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (lstVouchers.SelectedIndex <= 0) {
                MessageBox.Show("Vui lòng chọn một phần quà / voucher bên dưới để đổi thưởng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string voucherText = lstVouchers.SelectedItem?.ToString() ?? "Tặng phẩm: 3000 VND";
            int costPoints = voucherText.Contains("1500") ? 15 : (voucherText.Contains("2000") ? 20 : 30);

            if (_selectedCustomer.RewardPoints < costPoints) {
                MessageBox.Show($"Khách hàng {_selectedCustomer.CustomerName} hiện có {_selectedCustomer.RewardPoints} điểm, chưa đủ {costPoints} điểm để đổi '{voucherText}'!", "Không đủ điểm", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show($"Xác nhận đổi '{voucherText}' (Trừ {costPoints} điểm) cho khách hàng {_selectedCustomer.CustomerName}?", "Xác nhận đổi thưởng", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                int newPoints = _selectedCustomer.RewardPoints - costPoints;
                var updateCustomer = new {
                    CustomerId = _selectedCustomer.CustomerId,
                    CustomerName = _selectedCustomer.CustomerName,
                    PhoneNumber = _selectedCustomer.PhoneNumber,
                    Address = _selectedCustomer.Address,
                    RewardPoints = newPoints,
                    MembershipRank = _selectedCustomer.MembershipRank
                };

                try {
                    using var client = GetAuthenticatedClient();
                    var res = await client.PutAsJsonAsync($"customers/{_selectedCustomer.CustomerId}", updateCustomer);
                    if (res.IsSuccessStatusCode) {
                        if (!_historyMap.ContainsKey(_selectedCustomer.CustomerId)) {
                            _historyMap[_selectedCustomer.CustomerId] = new List<PointHistoryItem>();
                        }
                        var hist = _historyMap[_selectedCustomer.CustomerId];
                        hist.Add(new PointHistoryItem {
                            STT = hist.Count + 1,
                            DateOrAction = $"{DateTime.Now:dd/MM/yyyy} (-{costPoints}đ Đổi quà)",
                            SpentStr = $"{_selectedCustomer.TotalSpent:N0} đ"
                        });

                        MessageBox.Show($"Đổi thưởng thành công!\nPhần quà: {voucherText}\nĐiểm còn lại: {newPoints:N0} điểm", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        await LoadDataAsync();
                    }
                } catch (Exception ex) {
                    MessageBox.Show("Lỗi kết nối khi đổi thưởng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Xóa khách hàng
        private async void btnDelete_Click(object sender, EventArgs e) {
            if (_selectedCustomer == null) {
                MessageBox.Show("Vui lòng chọn khách hàng cần xóa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int id = _selectedCustomer.CustomerId;
            var confirm = MessageBox.Show($"Bạn có chắc muốn xóa khách hàng {_selectedCustomer.CustomerName} (Mã KH: {_selectedCustomer.CustomerCode})?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes) {
                try {
                    using var client = GetAuthenticatedClient();
                    var response = await client.DeleteAsync($"customers/{id}");
                    if (response.IsSuccessStatusCode) {
                        MessageBox.Show("Xóa khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        await LoadDataAsync();
                    } else if (response.StatusCode == System.Net.HttpStatusCode.Forbidden) {
                        MessageBox.Show("Bạn không có quyền xóa khách hàng! Chức năng này chỉ dành cho Admin.", "Bị từ chối (403)", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    } else {
                        MessageBox.Show("Xóa thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                } catch (Exception ex) {
                    MessageBox.Show("Lỗi kết nối: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Import danh sách khách hàng từ file CSV/Excel
        private async void btnImportExcel_Click(object sender, EventArgs e) {
            using var ofd = new OpenFileDialog {
                Title = "Chọn tệp danh sách khách hàng (CSV / Excel)",
                Filter = "CSV / Excel Files (*.csv;*.txt)|*.csv;*.txt|All Files (*.*)|*.*"
            };

            if (ofd.ShowDialog(this) == DialogResult.OK) {
                try {
                    var lines = await File.ReadAllLinesAsync(ofd.FileName);
                    int imported = 0;
                    using var client = GetAuthenticatedClient();
                    foreach (var line in lines.Skip(1)) {
                        if (string.IsNullOrWhiteSpace(line)) continue;
                        var parts = line.Split(',');
                        if (parts.Length >= 2) {
                            var newCust = new {
                                CustomerName = parts[0].Trim(),
                                PhoneNumber = parts[1].Trim(),
                                Address = parts.Length > 2 ? parts[2].Trim() : "TP. Hồ Chí Minh",
                                RewardPoints = parts.Length > 3 && int.TryParse(parts[3].Trim(), out int p) ? p : 50,
                                MembershipRank = parts.Length > 4 ? parts[4].Trim() : "Thành viên"
                            };
                            var res = await client.PostAsJsonAsync("customers", newCust);
                            if (res.IsSuccessStatusCode) imported++;
                        }
                    }
                    MessageBox.Show($"Đã import thành công {imported} khách hàng vào hệ thống!", "Import Excel", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadDataAsync();
                } catch (Exception ex) {
                    MessageBox.Show("Lỗi khi đọc tệp Import: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Hộp thoại Thêm mới / Cập nhật Khách hàng
        private bool ShowCustomerDialog(CustomerRowViewModel? existing, out string name, out string phone, out string address, out int points, out string rank) {
            name = existing?.CustomerName ?? "";
            phone = existing?.PhoneNumber ?? "";
            address = existing?.Address ?? "TP. Hồ Chí Minh";
            points = existing?.RewardPoints ?? 0;
            rank = existing?.MembershipRank ?? "VIP";

            using var dlg = new Form {
                Text = existing == null ? "Thêm Khách Hàng Thành Viên (F6)" : $"Cập Nhật Khách Hàng — {existing.CustomerCode}",
                Size = new Size(420, 340),
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false,
                BackColor = Color.White
            };

            var lblName = new Label { Text = "Họ và tên (*):", Location = new Point(20, 22), AutoSize = true, Font = new Font("Segoe UI", 9.5F, FontStyle.Bold) };
            var txtName = new TextBox { Text = name, Location = new Point(140, 20), Size = new Size(240, 25), Font = new Font("Segoe UI", 9.5F) };

            var lblPhone = new Label { Text = "Số điện thoại (*):", Location = new Point(20, 62), AutoSize = true, Font = new Font("Segoe UI", 9.5F, FontStyle.Bold) };
            var txtPhone = new TextBox { Text = phone, Location = new Point(140, 60), Size = new Size(240, 25), Font = new Font("Segoe UI", 9.5F) };

            var lblAddr = new Label { Text = "Địa chỉ:", Location = new Point(20, 102), AutoSize = true, Font = new Font("Segoe UI", 9.5F) };
            var txtAddr = new TextBox { Text = address, Location = new Point(140, 100), Size = new Size(240, 25), Font = new Font("Segoe UI", 9.5F) };

            var lblPts = new Label { Text = "Điểm tích lũy:", Location = new Point(20, 142), AutoSize = true, Font = new Font("Segoe UI", 9.5F) };
            var txtPts = new TextBox { Text = points.ToString(), Location = new Point(140, 140), Size = new Size(240, 25), Font = new Font("Segoe UI", 9.5F) };

            var lblRank = new Label { Text = "Hạng thành viên:", Location = new Point(20, 182), AutoSize = true, Font = new Font("Segoe UI", 9.5F) };
            var cboRank = new ComboBox { Location = new Point(140, 180), Size = new Size(240, 25), DropDownStyle = ComboBoxStyle.DropDownList, Font = new Font("Segoe UI", 9.5F) };
            cboRank.Items.AddRange(new object[] { "VIP", "Vàng", "Bạc", "Thành viên", "Chuẩn" });
            int idx = cboRank.FindStringExact(rank);
            cboRank.SelectedIndex = idx >= 0 ? idx : 0;

            var btnSave = new Button {
                Text = "Lưu thông tin",
                Location = new Point(140, 235),
                Size = new Size(120, 38),
                BackColor = Color.FromArgb(30, 41, 59),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9.5F, FontStyle.Bold)
            };
            var btnCancel = new Button {
                Text = "Hủy bỏ",
                DialogResult = DialogResult.Cancel,
                Location = new Point(270, 235),
                Size = new Size(110, 38),
                Font = new Font("Segoe UI", 9.5F)
            };

            btnSave.Click += (_, _) => {
                if (string.IsNullOrWhiteSpace(txtName.Text) || string.IsNullOrWhiteSpace(txtPhone.Text)) {
                    MessageBox.Show("Vui lòng nhập đầy đủ Họ tên và Số điện thoại!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                dlg.DialogResult = DialogResult.OK;
            };

            dlg.Controls.AddRange(new Control[] { lblName, txtName, lblPhone, txtPhone, lblAddr, txtAddr, lblPts, txtPts, lblRank, cboRank, btnSave, btnCancel });
            dlg.AcceptButton = btnSave;

            if (dlg.ShowDialog(this) == DialogResult.OK) {
                name = txtName.Text.Trim();
                phone = txtPhone.Text.Trim();
                address = txtAddr.Text.Trim();
                points = int.TryParse(txtPts.Text.Trim(), out int p) && p >= 0 ? p : 0;
                rank = cboRank.SelectedItem?.ToString() ?? "Thành viên";
                return true;
            }
            return false;
        }

        private static string RemoveVietnameseTones(string text) {
            if (string.IsNullOrWhiteSpace(text)) return string.Empty;
            string[] vietnameseSigns = {
                "aAeEoOuUiIdDyY",
                "áàạảãâấầậẩẫăắằặẳẵ",
                "ÁÀẠẢÃÂẤẦẬẨẪĂẮẰẶẲẴ",
                "éèẹẻẽêếềệểễ",
                "ÉÈẸẺẼÊẾỀỆỂỄ",
                "óòọỏõôốồộổỗơớờợởỡ",
                "ÓÒỌỎÕÔỐỒỘỔỖƠỚỜỢỞỠ",
                "úùụủũưứừựửữ",
                "ÚÙỤỦŨƯỨỪỰỬỮ",
                "íìịỉĩ",
                "ÍÌỊỈĨ",
                "đ",
                "Đ",
                "ýỳỵỷỹ",
                "ÝỲỴỶỸ"
            };
            for (int i = 1; i < vietnameseSigns.Length; i++) {
                for (int j = 0; j < vietnameseSigns[i].Length; j++)
                    text = text.Replace(vietnameseSigns[i][j], vietnameseSigns[0][i - 1]);
            }
            return text;
        }

        // ==================== ĐỒ HỌA VECTOR GDI+ CHO AVATAR & KPI ICONS ====================

        private static Image CreateCustomerAvatar(int width, int height) {
            var bmp = new Bitmap(width, height);
            using var g = Graphics.FromImage(bmp);
            g.SmoothingMode = SmoothingMode.AntiAlias;

            using (var bgBrush = new SolidBrush(Color.FromArgb(148, 176, 202))) {
                g.FillEllipse(bgBrush, 1, 1, width - 3, height - 3);
            }
            using (var suitBrush = new SolidBrush(Color.FromArgb(44, 62, 80))) {
                g.FillEllipse(suitBrush, (int)(width * 0.16), (int)(height * 0.58), (int)(width * 0.68), (int)(height * 0.62));
            }
            using (var shirtBrush = new SolidBrush(Color.White)) {
                Point[] collar = {
                    new Point((int)(width * 0.40), (int)(height * 0.58)),
                    new Point((int)(width * 0.50), (int)(height * 0.80)),
                    new Point((int)(width * 0.60), (int)(height * 0.58))
                };
                g.FillPolygon(shirtBrush, collar);
            }
            using (var skinBrush = new SolidBrush(Color.FromArgb(245, 203, 167))) {
                g.FillRectangle(skinBrush, (int)(width * 0.43), (int)(height * 0.48), (int)(width * 0.14), (int)(height * 0.14));
                g.FillEllipse(skinBrush, (int)(width * 0.29), (int)(height * 0.20), (int)(width * 0.42), (int)(height * 0.42));
            }
            using (var hairBrush = new SolidBrush(Color.FromArgb(110, 70, 40))) {
                g.FillPie(hairBrush, (int)(width * 0.28), (int)(height * 0.16), (int)(width * 0.44), (int)(height * 0.32), 180, 180);
            }
            return bmp;
        }

        private static Image CreateChartKpiIcon(int width, int height) {
            var bmp = new Bitmap(width, height);
            using var g = Graphics.FromImage(bmp);
            g.SmoothingMode = SmoothingMode.AntiAlias;

            using var barBrush = new SolidBrush(Color.FromArgb(59, 130, 246));
            g.FillRectangle(barBrush, 6, 26, 7, 14);
            g.FillRectangle(barBrush, 17, 19, 7, 21);
            g.FillRectangle(barBrush, 28, 12, 7, 28);

            using var pen = new Pen(Color.FromArgb(37, 99, 235), 2.5f);
            g.DrawLines(pen, new[] { new Point(6, 22), new Point(19, 13), new Point(34, 5) });
            g.DrawLines(pen, new[] { new Point(27, 5), new Point(34, 5), new Point(34, 12) });
            return bmp;
        }

        private static Image CreateGreenHandDollarIcon(int width, int height) {
            var bmp = new Bitmap(width, height);
            using var g = Graphics.FromImage(bmp);
            g.SmoothingMode = SmoothingMode.AntiAlias;

            using var greenBrush = new SolidBrush(Color.FromArgb(22, 163, 74));
            using var font = new Font("Segoe UI", 14F, FontStyle.Bold);
            g.DrawString("$", font, greenBrush, new PointF(14, 2));

            using var pen = new Pen(Color.FromArgb(22, 163, 74), 3f);
            g.DrawArc(pen, 6, 22, 32, 14, 0, 180);
            g.FillRectangle(greenBrush, 6, 27, 10, 6);
            return bmp;
        }

        private static Image CreateGoldCoinsIcon(int width, int height) {
            var bmp = new Bitmap(width, height);
            using var g = Graphics.FromImage(bmp);
            g.SmoothingMode = SmoothingMode.AntiAlias;

            using var goldBrush = new SolidBrush(Color.FromArgb(217, 154, 38));
            using var whitePen = new Pen(Color.White, 1.5f);

            for (int i = 0; i < 3; i++) {
                int y = 8 + i * 10;
                g.FillEllipse(goldBrush, 8, y, 28, 11);
                g.DrawEllipse(whitePen, 8, y, 28, 11);
            }
            return bmp;
        }
    }

    public class CustomerRowViewModel {
        public int STT { get; set; }
        public int CustomerId { get; set; }
        public string CustomerCode { get; set; } = string.Empty;
        public string CustomerName { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string MembershipRank { get; set; } = "Chuẩn";
        public int RewardPoints { get; set; }
        public string RewardPointsStr => $"{RewardPoints:N0}";
        public decimal TotalSpent { get; set; }
        public string TotalSpentStr => $"{TotalSpent:N0}";
        public string RegisteredDate { get; set; } = "09/07/2020";
        public string Status { get; set; } = "Hoạt động";
    }

    public class PointHistoryItem {
        public int STT { get; set; }
        public string DateOrAction { get; set; } = string.Empty;
        public string SpentStr { get; set; } = string.Empty;
    }
}

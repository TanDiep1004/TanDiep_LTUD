using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniSupermarket.WinForms {
    public partial class FormUserManagement : Form {
        private BindingList<UserGridRow> _userRows = new();
        private readonly List<string> _activityHistory = new() {
            $"{DateTime.Now:dd/MM/yyyy 08:00} - Hệ thống khởi tạo phân quyền RBAC mặc định.",
            $"{DateTime.Now:dd/MM/yyyy 08:15} - Tài khoản 'admin' đăng nhập vào phân hệ Quản trị."
        };

        // Cấu hình cửa hàng & POS lưu trong phiên
        private string _storeName = "Siêu Thị Mini Cô Ba Sài Gòn";
        private string _storeAddress = "123 Nguyễn Huệ, Quận 1, TP. Hồ Chí Minh";
        private string _storeHotline = "0901 122 334";
        private string _posPrinterPort = "USB001 - Máy in nhiệt K80";
        private bool _autoPrintReceipt = true;

        public FormUserManagement() {
            InitializeComponent();
        }

        private async void FormUserManagement_Load(object sender, EventArgs e) {
            if (!string.Equals(SessionManager.CurrentRole, "Admin", StringComparison.OrdinalIgnoreCase)) {
                MessageBox.Show("Bạn không có quyền quản trị tài khoản hệ thống!", "Từ chối truy cập", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                this.Close();
                return;
            }

            // Vẽ 3 biểu tượng đồ họa cho khu vực "CÁC CÀI ĐẶT KHÁCH"
            btnStoreProfile.Image = CreateStoreIcon(36, 36);
            btnPosConfig.Image = CreatePosConfigIcon(36, 36);
            btnHistoryLog.Image = CreateHistoryClockIcon(36, 36);

            SetupUsersGrid();
            await LoadUsersAsync();
        }

        /// <summary>
        /// Khởi tạo bảng Users với chính xác 6 cột: UserId, Username, Password (********), Full Name, Role (ComboBox), IsActive (CheckBox)
        /// </summary>
        private void SetupUsersGrid() {
            dgvUsers.AutoGenerateColumns = false;
            dgvUsers.Columns.Clear();

            dgvUsers.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(248, 250, 252);
            dgvUsers.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(30, 41, 59);
            dgvUsers.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
            dgvUsers.DefaultCellStyle.Font = new Font("Segoe UI", 9.5F);
            dgvUsers.DefaultCellStyle.ForeColor = Color.FromArgb(15, 23, 42);
            dgvUsers.DefaultCellStyle.SelectionBackColor = Color.FromArgb(199, 218, 238);
            dgvUsers.DefaultCellStyle.SelectionForeColor = Color.FromArgb(15, 23, 42);

            // 1. UserId
            dgvUsers.Columns.Add(new DataGridViewTextBoxColumn {
                Name = "UserId",
                DataPropertyName = "UserId",
                HeaderText = "UserId",
                ReadOnly = true,
                Width = 95
            });

            // 2. Username
            dgvUsers.Columns.Add(new DataGridViewTextBoxColumn {
                Name = "Username",
                DataPropertyName = "Username",
                HeaderText = "Username",
                ReadOnly = true,
                Width = 175
            });

            // 3. Password (dấu hoa thị ******** bảo mật cho PasswordHash)
            dgvUsers.Columns.Add(new DataGridViewTextBoxColumn {
                Name = "PasswordMask",
                DataPropertyName = "PasswordMask",
                HeaderText = "Password",
                ReadOnly = true,
                Width = 175
            });

            // 4. Full Name
            dgvUsers.Columns.Add(new DataGridViewTextBoxColumn {
                Name = "FullName",
                DataPropertyName = "FullName",
                HeaderText = "Full Name",
                ReadOnly = false,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            // 5. Role (Drop-down chỉnh sửa nhanh: Admin, Thu ngân, Kiểm kho)
            var roleCol = new DataGridViewComboBoxColumn {
                Name = "RoleDisplay",
                DataPropertyName = "RoleDisplay",
                HeaderText = "Role",
                Width = 185,
                FlatStyle = FlatStyle.Standard,
                DisplayStyle = DataGridViewComboBoxDisplayStyle.DropDownButton
            };
            roleCol.Items.AddRange("Admin", "Thu ngân", "Kiểm kho");
            dgvUsers.Columns.Add(roleCol);

            // 6. IsActive (Checkbox)
            dgvUsers.Columns.Add(new DataGridViewCheckBoxColumn {
                Name = "IsActive",
                DataPropertyName = "IsActive",
                HeaderText = "IsActive",
                Width = 105
            });

            dgvUsers.RowPostPaint += DgvUsers_RowPostPaint;
        }

        // Vẽ số thứ tự dòng (1, 2, 3...) ở cột đầu bảng giống ảnh mẫu
        private void DgvUsers_RowPostPaint(object? sender, DataGridViewRowPostPaintEventArgs e) {
            string rowIdx = (e.RowIndex + 1).ToString();
            var centerFormat = new StringFormat {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };
            var headerBounds = new Rectangle(e.RowBounds.Left, e.RowBounds.Top, dgvUsers.RowHeadersWidth, e.RowBounds.Height);
            using var brush = new SolidBrush(Color.FromArgb(51, 65, 85));
            e.Graphics.DrawString(rowIdx, dgvUsers.Font, brush, headerBounds, centerFormat);
        }

        private async Task LoadUsersAsync() {
            try {
                using var client = ApiClientService.CreateClient();
                var users = await client.GetFromJsonAsync<List<UserDto>>("users") ?? new List<UserDto>();

                var mapped = users.Select(u => new UserGridRow {
                    UserId = u.Id,
                    Username = u.Username,
                    PasswordMask = "********",
                    FullName = u.FullName,
                    RoleDisplay = MapDbRoleToDisplay(u.Role),
                    IsActive = u.IsActive,
                    IsDirty = false
                }).ToList();

                _userRows = new BindingList<UserGridRow>(mapped);
                dgvUsers.DataSource = _userRows;

                if (_userRows.Count > 0) {
                    dgvUsers.ClearSelection();
                    dgvUsers.Rows[0].Selected = true;
                    UpdateSelectedUserBanner(_userRows[0]);
                }
            } catch (Exception ex) {
                MessageBox.Show("Lỗi lấy danh sách tài khoản: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static string MapDbRoleToDisplay(string? dbRole) {
            if (string.IsNullOrWhiteSpace(dbRole)) return "Thu ngân";
            return dbRole.Trim().ToUpperInvariant() switch {
                "ADMIN" => "Admin",
                "CASHIER" or "THU NGÂN" => "Thu ngân",
                "WAREHOUSE" or "KIỂM KHO" => "Kiểm kho",
                _ => "Admin"
            };
        }

        private static string MapDisplayRoleToDb(string? displayRole) {
            if (string.IsNullOrWhiteSpace(displayRole)) return "Cashier";
            return displayRole.Trim() switch {
                "Admin" => "Admin",
                "Thu ngân" => "Cashier",
                "Kiểm kho" => "Warehouse",
                _ => "Cashier"
            };
        }

        private UserGridRow? GetSelectedUserRow() {
            if (dgvUsers.CurrentRow?.DataBoundItem is UserGridRow row) {
                return row;
            }
            if (dgvUsers.SelectedRows.Count > 0 && dgvUsers.SelectedRows[0].DataBoundItem is UserGridRow selRow) {
                return selRow;
            }
            return _userRows.FirstOrDefault();
        }

        private void UpdateSelectedUserBanner(UserGridRow? user) {
            if (user == null) {
                lblSelectedHeader.Text = "THÔNG TIN TÀI KHOẢN ĐANG CHỌN (0)";
                lblSelectedUserDetails.Text = "User details: Chưa chọn tài khoản";
                return;
            }

            lblSelectedHeader.Text = $"THÔNG TIN TÀI KHOẢN ĐANG CHỌN ({user.UserId})";
            lblSelectedUserDetails.Text = $"User details: {user.Username} | {user.RoleDisplay}";
        }

        private void dgvUsers_CellClick(object sender, DataGridViewCellEventArgs e) {
            if (e.RowIndex >= 0 && e.RowIndex < _userRows.Count) {
                UpdateSelectedUserBanner(_userRows[e.RowIndex]);
            }
        }

        private void dgvUsers_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e) {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0 && e.RowIndex < dgvUsers.Rows.Count) {
                dgvUsers.ClearSelection();
                dgvUsers.Rows[e.RowIndex].Selected = true;
                dgvUsers.CurrentCell = dgvUsers.Rows[e.RowIndex].Cells[0];
                UpdateSelectedUserBanner(_userRows[e.RowIndex]);
            }
        }

        private void dgvUsers_CurrentCellDirtyStateChanged(object sender, EventArgs e) {
            if (dgvUsers.IsCurrentCellDirty) {
                dgvUsers.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void dgvUsers_CellValueChanged(object sender, DataGridViewCellEventArgs e) {
            if (e.RowIndex >= 0 && e.RowIndex < _userRows.Count) {
                var row = _userRows[e.RowIndex];
                row.IsDirty = true;
                UpdateSelectedUserBanner(row);
            }
        }

        private void dgvUsers_DataError(object sender, DataGridViewDataErrorEventArgs e) {
            e.ThrowException = false;
        }

        private void FormUserManagement_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.F2) {
                e.Handled = true;
                btnAddUser_Click(sender, e);
            }
        }

        // ================= THÊM TÀI KHOẢN MỚI (F2) =================
        private async void btnAddUser_Click(object sender, EventArgs e) {
            await ShowUserEditorDialogAsync(null);
        }

        // ================= MENU CHUỘT PHẢI (4 TÁC VỤ ĐƠN GIẢN) =================
        private void mnuViewDetail_Click(object sender, EventArgs e) {
            var u = GetSelectedUserRow();
            if (u == null) return;

            UpdateSelectedUserBanner(u);
            MessageBox.Show(
                $"• UserId: {u.UserId}\n" +
                $"• Username: {u.Username}\n" +
                $"• Password: {u.PasswordMask} (Đã mã hóa/ẩn bảo mật)\n" +
                $"• Full Name: {u.FullName}\n" +
                $"• Role: {u.RoleDisplay} ({MapDisplayRoleToDb(u.RoleDisplay)})\n" +
                $"• Trạng thái (IsActive): {(u.IsActive ? "Đang hoạt động" : "Đã vô hiệu hóa")}",
                $"Chi tiết tài khoản — {u.Username}",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private async void mnuEditUser_Click(object sender, EventArgs e) {
            var u = GetSelectedUserRow();
            if (u == null) return;
            await ShowUserEditorDialogAsync(u);
        }

        private async void mnuResetPassword_Click(object sender, EventArgs e) {
            var u = GetSelectedUserRow();
            if (u == null) return;

            if (MessageBox.Show(
                $"Xác nhận Reset mật khẩu cho tài khoản '{u.Username}' ({u.FullName}) về mặc định '123456'?",
                "Reset mật khẩu",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes) {
                try {
                    using var client = ApiClientService.CreateClient();
                    var res = await client.PutAsJsonAsync($"users/{Uri.EscapeDataString(u.Username)}/reset-password", new { });
                    if (res.IsSuccessStatusCode) {
                        _activityHistory.Add($"{DateTime.Now:dd/MM/yyyy HH:mm} - Reset mật khẩu cho tài khoản '{u.Username}'.");
                        MessageBox.Show($"Đã Reset mật khẩu cho '{u.Username}' về mặc định (123456)!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    } else {
                        MessageBox.Show("Không thể đặt lại mật khẩu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                } catch (Exception ex) {
                    MessageBox.Show("Lỗi kết nối: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void mnuDisableUser_Click(object sender, EventArgs e) {
            var u = GetSelectedUserRow();
            if (u == null) return;

            try {
                using var client = ApiClientService.CreateClient();
                u.IsActive = false;
                var updateDto = new {
                    FullName = u.FullName,
                    Role = MapDisplayRoleToDb(u.RoleDisplay),
                    IsActive = false
                };
                var res = await client.PutAsJsonAsync($"users/{u.UserId}", updateDto);
                if (res.IsSuccessStatusCode) {
                    u.IsDirty = false;
                    dgvUsers.Refresh();
                    _activityHistory.Add($"{DateTime.Now:dd/MM/yyyy HH:mm} - Vô hiệu hóa tài khoản '{u.Username}'.");
                    MessageBox.Show($"Đã vô hiệu hóa tài khoản '{u.Username}'!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                } else {
                    MessageBox.Show("Không thể vô hiệu hóa tài khoản!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            } catch (Exception ex) {
                MessageBox.Show("Lỗi kết nối: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ================= LƯU THAY ĐỔI TRÊN BẢNG =================
        private async void btnSaveChanges_Click(object sender, EventArgs e) {
            dgvUsers.EndEdit();
            var dirtyRows = _userRows.Where(r => r.IsDirty).ToList();

            try {
                using var client = ApiClientService.CreateClient();
                int updatedCount = 0;

                foreach (var row in dirtyRows.Count > 0 ? dirtyRows : _userRows.ToList()) {
                    var payload = new {
                        FullName = row.FullName,
                        Role = MapDisplayRoleToDb(row.RoleDisplay),
                        IsActive = row.IsActive
                    };
                    var res = await client.PutAsJsonAsync($"users/{row.UserId}", payload);
                    if (res.IsSuccessStatusCode) {
                        row.IsDirty = false;
                        updatedCount++;
                    }
                }

                _activityHistory.Add($"{DateTime.Now:dd/MM/yyyy HH:mm} - Lưu cập nhật phân quyền cho {updatedCount} tài khoản.");
                MessageBox.Show("Đã lưu toàn bộ thay đổi phân quyền và trạng thái tài khoản thành công!", "Lưu thay đổi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await LoadUsersAsync();
            } catch (Exception ex) {
                MessageBox.Show("Lỗi khi lưu thay đổi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ================= HỘP THOẠI THÊM / SỬA NGƯỜI DÙNG =================
        private async Task ShowUserEditorDialogAsync(UserGridRow? existing) {
            bool isEdit = existing != null;
            using var dlg = new Form {
                Text = isEdit ? $"Sửa người dùng — {existing!.Username}" : "Thêm tài khoản mới (F2)",
                Size = new Size(410, isEdit ? 300 : 350),
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false,
                BackColor = Color.White,
                Font = new Font("Segoe UI", 9.5F)
            };

            var lblU = new Label { Text = "Username:", Location = new Point(20, 22), AutoSize = true };
            var txtU = new TextBox { Location = new Point(130, 19), Width = 235, Text = existing?.Username ?? "", ReadOnly = isEdit };

            var lblF = new Label { Text = "Full Name:", Location = new Point(20, 64), AutoSize = true };
            var txtF = new TextBox { Location = new Point(130, 61), Width = 235, Text = existing?.FullName ?? "" };

            var lblR = new Label { Text = "Role:", Location = new Point(20, 106), AutoSize = true };
            var cboR = new ComboBox { Location = new Point(130, 103), Width = 235, DropDownStyle = ComboBoxStyle.DropDownList };
            cboR.Items.AddRange(new object[] { "Admin", "Thu ngân", "Kiểm kho" });
            cboR.SelectedItem = existing?.RoleDisplay ?? "Thu ngân";

            var chkActive = new CheckBox {
                Text = "Kích hoạt tài khoản (IsActive)",
                Location = new Point(130, 145),
                AutoSize = true,
                Checked = existing?.IsActive ?? true
            };

            var lblP = new Label { Text = "Password:", Location = new Point(20, 182), AutoSize = true, Visible = !isEdit };
            var txtP = new TextBox { Location = new Point(130, 179), Width = 235, PasswordChar = '*', Text = "123456", Visible = !isEdit };

            var btnOk = new Button {
                Text = isEdit ? "Lưu cập nhật" : "Tạo tài khoản",
                BackColor = Color.FromArgb(30, 41, 59),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Location = new Point(130, isEdit ? 195 : 235),
                Size = new Size(125, 36),
                DialogResult = DialogResult.OK
            };
            btnOk.FlatAppearance.BorderSize = 0;

            var btnCancel = new Button {
                Text = "Hủy",
                Location = new Point(265, isEdit ? 195 : 235),
                Size = new Size(100, 36),
                DialogResult = DialogResult.Cancel
            };

            dlg.Controls.AddRange(new Control[] { lblU, txtU, lblF, txtF, lblR, cboR, chkActive, lblP, txtP, btnOk, btnCancel });
            dlg.AcceptButton = btnOk;
            dlg.CancelButton = btnCancel;

            if (dlg.ShowDialog(this) != DialogResult.OK) return;

            string username = txtU.Text.Trim();
            string fullName = txtF.Text.Trim();
            string roleDisplay = cboR.SelectedItem?.ToString() ?? "Thu ngân";
            string dbRole = MapDisplayRoleToDb(roleDisplay);

            if (string.IsNullOrEmpty(username)) {
                MessageBox.Show("Username không được để trống!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try {
                using var client = ApiClientService.CreateClient();
                if (!isEdit) {
                    string pwd = string.IsNullOrWhiteSpace(txtP.Text) ? "123456" : txtP.Text.Trim();
                    var createDto = new {
                        Username = username,
                        Password = pwd,
                        FullName = string.IsNullOrEmpty(fullName) ? username : fullName,
                        Role = dbRole
                    };
                    var res = await client.PostAsJsonAsync("users", createDto);
                    if (res.IsSuccessStatusCode) {
                        _activityHistory.Add($"{DateTime.Now:dd/MM/yyyy HH:mm} - Tạo mới tài khoản '{username}' ({roleDisplay}).");
                        MessageBox.Show("Thêm tài khoản mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        await LoadUsersAsync();
                    } else {
                        MessageBox.Show("Username đã tồn tại hoặc dữ liệu không hợp lệ!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                } else {
                    var updateDto = new {
                        FullName = string.IsNullOrEmpty(fullName) ? username : fullName,
                        Role = dbRole,
                        IsActive = chkActive.Checked
                    };
                    var res = await client.PutAsJsonAsync($"users/{existing!.UserId}", updateDto);
                    if (res.IsSuccessStatusCode) {
                        _activityHistory.Add($"{DateTime.Now:dd/MM/yyyy HH:mm} - Cập nhật thông tin tài khoản '{username}'.");
                        MessageBox.Show("Cập nhật người dùng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        await LoadUsersAsync();
                    } else {
                        MessageBox.Show("Cập nhật người dùng thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            } catch (Exception ex) {
                MessageBox.Show("Lỗi kết nối: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ================= 3 NÚT KHU VỰC "CÁC CÀI ĐẶT KHÁCH" =================
        private void btnStoreProfile_Click(object sender, EventArgs e) {
            using var dlg = new Form {
                Text = "Hồ sơ cửa hàng",
                Size = new Size(420, 260),
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false,
                BackColor = Color.White,
                Font = new Font("Segoe UI", 9.5F)
            };

            var l1 = new Label { Text = "Tên cửa hàng:", Location = new Point(20, 22), AutoSize = true };
            var t1 = new TextBox { Location = new Point(135, 19), Width = 245, Text = _storeName };

            var l2 = new Label { Text = "Địa chỉ:", Location = new Point(20, 64), AutoSize = true };
            var t2 = new TextBox { Location = new Point(135, 61), Width = 245, Text = _storeAddress };

            var l3 = new Label { Text = "Hotline:", Location = new Point(20, 106), AutoSize = true };
            var t3 = new TextBox { Location = new Point(135, 103), Width = 245, Text = _storeHotline };

            var btnSave = new Button {
                Text = "Lưu hồ sơ",
                BackColor = Color.FromArgb(30, 41, 59),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Location = new Point(135, 155),
                Size = new Size(120, 36),
                DialogResult = DialogResult.OK
            };
            btnSave.FlatAppearance.BorderSize = 0;

            dlg.Controls.AddRange(new Control[] { l1, t1, l2, t2, l3, t3, btnSave });
            if (dlg.ShowDialog(this) == DialogResult.OK) {
                _storeName = t1.Text.Trim();
                _storeAddress = t2.Text.Trim();
                _storeHotline = t3.Text.Trim();
                _activityHistory.Add($"{DateTime.Now:dd/MM/yyyy HH:mm} - Cập nhật Hồ sơ cửa hàng ({_storeName}).");
                MessageBox.Show("Đã lưu thông tin Hồ sơ cửa hàng!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnPosConfig_Click(object sender, EventArgs e) {
            using var dlg = new Form {
                Text = "Cấu hình POS",
                Size = new Size(420, 230),
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false,
                BackColor = Color.White,
                Font = new Font("Segoe UI", 9.5F)
            };

            var l1 = new Label { Text = "Cổng máy in:", Location = new Point(20, 25), AutoSize = true };
            var t1 = new TextBox { Location = new Point(135, 22), Width = 245, Text = _posPrinterPort };

            var chk = new CheckBox {
                Text = "Tự động in phiếu tính tiền sau khi thanh toán",
                Location = new Point(24, 68),
                AutoSize = true,
                Checked = _autoPrintReceipt
            };

            var btnSave = new Button {
                Text = "Lưu cấu hình",
                BackColor = Color.FromArgb(30, 41, 59),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Location = new Point(135, 120),
                Size = new Size(130, 36),
                DialogResult = DialogResult.OK
            };
            btnSave.FlatAppearance.BorderSize = 0;

            dlg.Controls.AddRange(new Control[] { l1, t1, chk, btnSave });
            if (dlg.ShowDialog(this) == DialogResult.OK) {
                _posPrinterPort = t1.Text.Trim();
                _autoPrintReceipt = chk.Checked;
                _activityHistory.Add($"{DateTime.Now:dd/MM/yyyy HH:mm} - Cập nhật Cấu hình POS ({_posPrinterPort}).");
                MessageBox.Show("Đã lưu Cấu hình POS!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnHistoryLog_Click(object sender, EventArgs e) {
            string msg = string.Join("\n• ", _activityHistory);
            MessageBox.Show("• " + msg, "Lịch sử thao tác & phân quyền hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // ================= VẼ ICON GDI+ CHO 3 NÚT CÀI ĐẶT =================
        private Image CreateStoreIcon(int w, int h) {
            var bmp = new Bitmap(w, h);
            using var g = Graphics.FromImage(bmp);
            g.SmoothingMode = SmoothingMode.AntiAlias;

            using var darkBrush = new SolidBrush(Color.FromArgb(30, 41, 59));
            using var darkPen = new Pen(Color.FromArgb(30, 41, 59), 2.2f);

            // Mái hiên cửa hàng
            g.FillPolygon(darkBrush, new[] {
                new Point(4, 12),
                new Point(8, 5),
                new Point(w - 8, 5),
                new Point(w - 4, 12)
            });

            // Thân cửa hàng
            g.DrawRectangle(darkPen, 7, 13, w - 14, h - 18);
            g.FillRectangle(darkBrush, 14, 20, w - 28, h - 25);

            return bmp;
        }

        private Image CreatePosConfigIcon(int w, int h) {
            var bmp = new Bitmap(w, h);
            using var g = Graphics.FromImage(bmp);
            g.SmoothingMode = SmoothingMode.AntiAlias;

            using var darkBrush = new SolidBrush(Color.FromArgb(30, 41, 59));
            using var whiteBrush = new SolidBrush(Color.White);

            // 3 thanh thiết bị server/POS xếp chồng
            for (int i = 0; i < 3; i++) {
                int y = 6 + i * 9;
                g.FillRectangle(darkBrush, 6, y, w - 12, 7);
                g.FillEllipse(whiteBrush, 9, y + 2, 3, 3);
                g.FillEllipse(whiteBrush, 14, y + 2, 3, 3);
            }

            return bmp;
        }

        private Image CreateHistoryClockIcon(int w, int h) {
            var bmp = new Bitmap(w, h);
            using var g = Graphics.FromImage(bmp);
            g.SmoothingMode = SmoothingMode.AntiAlias;

            using var pen = new Pen(Color.FromArgb(30, 41, 59), 2.4f);
            g.DrawArc(pen, 6, 6, w - 12, h - 12, -60, 300);

            // Mũi tên ngược chiều kim đồng hồ
            g.DrawLines(pen, new[] {
                new Point(8, 7),
                new Point(8, 14),
                new Point(15, 14)
            });

            // Kim đồng hồ
            int cx = w / 2;
            int cy = h / 2;
            g.DrawLine(pen, cx, cy - 6, cx, cy);
            g.DrawLine(pen, cx, cy, cx + 5, cy + 3);

            return bmp;
        }
    }

    public class UserGridRow {
        public int UserId { get; set; }
        public string Username { get; set; } = string.Empty;
        public string PasswordMask { get; set; } = "********";
        public string FullName { get; set; } = string.Empty;
        public string RoleDisplay { get; set; } = "Thu ngân";
        public bool IsActive { get; set; } = true;
        public bool IsDirty { get; set; } = false;
    }

    public class UserDto {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
    }
}

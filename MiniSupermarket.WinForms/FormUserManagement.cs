using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniSupermarket.WinForms {
    public partial class FormUserManagement : Form {
        public FormUserManagement() {
            InitializeComponent();
            cboRole.Items.AddRange(new object[] { "Admin", "Cashier", "Warehouse" });
            cboRole.SelectedIndex = 1;
        }

        private async void FormUserManagement_Load(object sender, EventArgs e) {
            if (!string.Equals(SessionManager.CurrentRole, "Admin", StringComparison.OrdinalIgnoreCase)) {
                MessageBox.Show("Bạn không có quyền quản trị tài khoản hệ thống!", "Từ chối truy cập", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                this.Close();
                return;
            }
            await LoadUsersAsync();
        }

        private async Task LoadUsersAsync() {
            try {
                using var client = ApiClientService.CreateClient();
                var users = await client.GetFromJsonAsync<List<UserDto>>("users");
                dgvUsers.DataSource = users;
                FormatUserGrid();
            } catch (Exception ex) {
                MessageBox.Show("Lỗi lấy danh sách tài khoản: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormatUserGrid() {
            if (dgvUsers.Columns.Count == 0) return;
            if (dgvUsers.Columns["Id"] is DataGridViewColumn colId) colId.Width = 60;
            if (dgvUsers.Columns["Username"] is DataGridViewColumn colUser) colUser.HeaderText = "Tài khoản";
            if (dgvUsers.Columns["FullName"] is DataGridViewColumn colName) colName.HeaderText = "Họ và tên";
            if (dgvUsers.Columns["Role"] is DataGridViewColumn colRole) colRole.HeaderText = "Vai trò (Role)";
            if (dgvUsers.Columns["IsActive"] is DataGridViewColumn colActive) colActive.HeaderText = "Hoạt động";
        }

        private void dgvUsers_CellClick(object sender, DataGridViewCellEventArgs e) {
            if (e.RowIndex >= 0) {
                var row = dgvUsers.Rows[e.RowIndex];
                txtUsername.Text = row.Cells["Username"].Value?.ToString() ?? string.Empty;
                txtFullName.Text = row.Cells["FullName"].Value?.ToString() ?? string.Empty;
                string role = row.Cells["Role"].Value?.ToString() ?? "Cashier";
                int idx = cboRole.FindStringExact(role);
                if (idx >= 0) cboRole.SelectedIndex = idx;
            }
        }

        private async void btnAddUser_Click(object sender, EventArgs e) {
            if (string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtPassword.Text)) {
                MessageBox.Show("Tên đăng nhập và mật khẩu không được để trống!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var newUser = new {
                Username = txtUsername.Text.Trim(),
                Password = txtPassword.Text.Trim(),
                FullName = txtFullName.Text.Trim(),
                Role = cboRole.SelectedItem?.ToString() ?? "Cashier"
            };

            try {
                using var client = ApiClientService.CreateClient();
                var res = await client.PostAsJsonAsync("users", newUser);
                if (res.IsSuccessStatusCode) {
                    MessageBox.Show("Tạo tài khoản mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadUsersAsync();
                    txtUsername.Clear();
                    txtPassword.Clear();
                    txtFullName.Clear();
                } else {
                    MessageBox.Show("Tên đăng nhập đã tồn tại hoặc dữ liệu không hợp lệ!", "Thất bại", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            } catch (Exception ex) {
                MessageBox.Show("Lỗi kết nối: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnResetPassword_Click(object sender, EventArgs e) {
            if (string.IsNullOrWhiteSpace(txtUsername.Text)) {
                MessageBox.Show("Vui lòng chọn tài khoản cần đặt lại mật khẩu!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string username = txtUsername.Text.Trim();
            if (MessageBox.Show($"Xác nhận đặt lại mật khẩu cho tài khoản '{username}' về mặc định (123456)?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                try {
                    using var client = ApiClientService.CreateClient();
                    var res = await client.PutAsJsonAsync($"users/{Uri.EscapeDataString(username)}/reset-password", new { });
                    if (res.IsSuccessStatusCode) {
                        MessageBox.Show($"Đặt lại mật khẩu thành công cho tài khoản '{username}'!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    } else {
                        MessageBox.Show("Không thể đặt lại mật khẩu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                } catch (Exception ex) {
                    MessageBox.Show("Lỗi kết nối: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void btnToggleLock_Click(object sender, EventArgs e) {
            if (string.IsNullOrWhiteSpace(txtUsername.Text)) {
                MessageBox.Show("Vui lòng chọn tài khoản cần khóa/mở khóa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string username = txtUsername.Text.Trim();
            try {
                using var client = ApiClientService.CreateClient();
                var res = await client.PutAsJsonAsync($"users/{Uri.EscapeDataString(username)}/toggle-status", new { });
                if (res.IsSuccessStatusCode) {
                    MessageBox.Show($"Cập nhật trạng thái tài khoản '{username}' thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadUsersAsync();
                } else {
                    MessageBox.Show("Không thể thay đổi trạng thái tài khoản!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            } catch (Exception ex) {
                MessageBox.Show("Lỗi kết nối: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    public class UserDto {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
    }
}

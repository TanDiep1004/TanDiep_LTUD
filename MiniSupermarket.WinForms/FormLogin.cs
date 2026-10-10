using System.Net.Http.Json;
using System.Text.Json;

namespace MiniSupermarket.WinForms {
    public partial class FormLogin : Form {
        // Sử dụng ApiClientService để kết nối an toàn với Web API Backend
        private HttpClient GetClient() => ApiClientService.CreateClient();

        public FormLogin() {
            InitializeComponent();
        }

        // Sự kiện khi người dùng bấm nút Đăng nhập
        private async void btnLogin_Click(object sender, EventArgs e) {
            string username = txtUser.Text.Trim();
            string password = txtPass.Text.Trim();

            // Kiểm tra ràng buộc cơ bản phía Client
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password)) {
                MessageBox.Show("Vui lòng nhập đầy đủ tài khoản và mật khẩu!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try {
                // Đóng gói dữ liệu gửi lên endpoint POST /api/auth/login
                var loginData = new { Username = username, Password = password };
                using var client = GetClient();
                var response = await client.PostAsJsonAsync("auth/login", loginData);

                if (response.IsSuccessStatusCode) {
                    // Đọc chuỗi JSON trả về từ Server khi đăng nhập thành công
                    var jsonString = await response.Content.ReadAsStringAsync();
                    using var doc = JsonDocument.Parse(jsonString);

                    // Trích xuất Token, Role và Thông tin nhân sự lưu vào SessionManager
                    SessionManager.JwtToken = doc.RootElement.GetProperty("token").GetString() ?? string.Empty;
                    SessionManager.CurrentRole = doc.RootElement.GetProperty("role").GetString() ?? string.Empty;
                    SessionManager.CurrentUsername = username;
                    if (doc.RootElement.TryGetProperty("fullName", out var fnProp)) {
                        SessionManager.CurrentFullName = fnProp.GetString() ?? username;
                    } else {
                        SessionManager.CurrentFullName = username;
                    }

                    MessageBox.Show($"Đăng nhập thành công với quyền: {SessionManager.CurrentRole}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Mở Form giao diện chính hiện đại (FormMainShell) và ẩn Form đăng nhập đi
                    FormMainShell mainShell = new FormMainShell();
                    this.Hide();
                    mainShell.ShowDialog();
                    this.Close(); // Đóng hẳn ứng dụng khi shell chính tắt
                } else {
                    MessageBox.Show("Sai tài khoản hoặc mật khẩu!", "Đăng nhập thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            } catch (Exception ex) {
                MessageBox.Show("Lỗi kết nối đến Server: " + ex.Message, "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

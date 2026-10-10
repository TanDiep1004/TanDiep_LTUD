using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace MiniSupermarket.WinForms {
    public static class SessionManager {
        // Lưu trữ JWT Token nhận từ Server
        public static string JwtToken { get; set; } = string.Empty;
        // Lưu trữ vai trò người dùng (Admin / Cashier / Warehouse) để phân quyền giao diện
        public static string CurrentRole { get; set; } = string.Empty;
        // Lưu trữ tên tài khoản đang đăng nhập
        public static string CurrentUsername { get; set; } = string.Empty;
        // Lưu trữ họ và tên nhân viên
        public static string CurrentFullName { get; set; } = string.Empty;
    }

    public static class ApiClientService {
        public static readonly string BaseApiUrl = "https://localhost:7299/api/";

        // Handler cấu hình cho phép kết nối an toàn với chứng chỉ SSL phát triển (dev-certs)
        public static HttpClientHandler CreateHandler() {
            return new HttpClientHandler {
                ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
            };
        }

        // Tạo đối tượng HttpClient đã được cấu hình sẵn BaseAddress và Token
        public static HttpClient CreateClient() {
            var client = new HttpClient(CreateHandler()) {
                BaseAddress = new Uri(BaseApiUrl)
            };
            if (!string.IsNullOrEmpty(SessionManager.JwtToken)) {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", SessionManager.JwtToken);
            }
            return client;
        }

        // Cung cấp thuộc tính Client dùng nhanh
        public static HttpClient Client => CreateClient();

        // Hàm gọi API đăng nhập lấy Token
        public static async Task<bool> LoginAsync(string username, string password) {
            using var client = CreateClient();
            var loginObj = new { Username = username, Password = password };
            var response = await client.PostAsJsonAsync("auth/login", loginObj);
            
            if (response.IsSuccessStatusCode) {
                var jsonString = await response.Content.ReadAsStringAsync();
                using var doc = JsonDocument.Parse(jsonString);
                SessionManager.JwtToken = doc.RootElement.GetProperty("token").GetString() ?? string.Empty;
                SessionManager.CurrentRole = doc.RootElement.GetProperty("role").GetString() ?? string.Empty;
                SessionManager.CurrentUsername = username;
                if (doc.RootElement.TryGetProperty("fullName", out var fnProp)) {
                    SessionManager.CurrentFullName = fnProp.GetString() ?? username;
                } else {
                    SessionManager.CurrentFullName = username;
                }
                return true;
            }
            return false;
        }

        // Hàm gọi API lấy dữ liệu có gắn kèm Bearer Token bảo mật
        public static async Task<string> GetDataWithTokenAsync(string endpoint) {
            using var client = CreateClient();
            var response = await client.GetAsync(endpoint);
            
            if (response.IsSuccessStatusCode) {
                return await response.Content.ReadAsStringAsync();
            } else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized) {
                throw new Exception("Phiên làm việc hết hạn hoặc chưa đăng nhập!");
            }
            throw new Exception("Lỗi khi gọi dữ liệu từ Server.");
        }
    }
}

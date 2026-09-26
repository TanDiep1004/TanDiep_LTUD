using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniSupermarket.WinForms {
    public partial class FormCategoryManagement : Form {
        
        public FormCategoryManagement() {
            InitializeComponent();
        }

        // Bổ sung phương thức cấu hình HttpClient có gắn kèm Token bảo mật
        private HttpClient GetAuthenticatedClient() {
            var client = new HttpClient {
                BaseAddress = new Uri("https://localhost:7299/api/")
            };
            if (!string.IsNullOrEmpty(SessionManager.JwtToken)) {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", SessionManager.JwtToken);
            }
            return client;
        }

        private async void FormCategoryManagement_Load(object sender, EventArgs e) {
            // Phân quyền giao diện: Thu ngân (Cashier) không có quyền xóa sản phẩm/nhóm hàng
            if (string.Equals(SessionManager.CurrentRole, "Cashier", StringComparison.OrdinalIgnoreCase)) {
                btnDelete.Enabled = false;
                btnDelete.Text = "Xóa (Chỉ Admin)";
            }
            await LoadDataAsync();
        }

        private async Task LoadDataAsync() {
            try {
                using var client = GetAuthenticatedClient();
                var categories = await client.GetFromJsonAsync<List<CategoryDto>>("categories");
                dgvCategories.DataSource = categories;
            } catch (Exception ex) {
                MessageBox.Show("Lỗi kết nối Server: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnLoad_Click(object sender, EventArgs e) {
            await LoadDataAsync();
        }

        private void dgvCategories_CellClick(object sender, DataGridViewCellEventArgs e) {
            if (e.RowIndex >= 0) {
                DataGridViewRow row = dgvCategories.Rows[e.RowIndex];
                txtId.Text = row.Cells["CategoryId"].Value.ToString();
                txtCategoryName.Text = row.Cells["CategoryName"].Value.ToString();
                txtDescription.Text = row.Cells["Description"]?.Value?.ToString() ?? string.Empty;
            }
        }

        private async void btnAdd_Click(object sender, EventArgs e) {
            var newCat = new { 
                CategoryName = txtCategoryName.Text, 
                Description = txtDescription.Text 
            };

            using var client = GetAuthenticatedClient();
            var response = await client.PostAsJsonAsync("categories", newCat);
            if (response.IsSuccessStatusCode) {
                MessageBox.Show("Thêm mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await LoadDataAsync();
                ClearInputs();
            } else {
                MessageBox.Show("Thêm mới thất bại! Không đủ quyền hoặc lỗi server.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async void btnUpdate_Click(object sender, EventArgs e) {
            if (string.IsNullOrEmpty(txtId.Text)) {
                MessageBox.Show("Vui lòng chọn nhóm hàng cần sửa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int id = int.Parse(txtId.Text);
            var updateCat = new { 
                CategoryId = id, 
                CategoryName = txtCategoryName.Text, 
                Description = txtDescription.Text 
            };

            using var client = GetAuthenticatedClient();
            var response = await client.PutAsJsonAsync($"categories/{id}", updateCat);
            if (response.IsSuccessStatusCode) {
                MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await LoadDataAsync();
                ClearInputs();
            } else {
                MessageBox.Show("Cập nhật thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e) {
            if (string.IsNullOrEmpty(txtId.Text)) {
                MessageBox.Show("Vui lòng chọn nhóm hàng cần xóa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int id = int.Parse(txtId.Text);
            var confirm = MessageBox.Show($"Bạn có chắc muốn xóa nhóm hàng ID = {id}?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes) {
                using var client = GetAuthenticatedClient();
                var response = await client.DeleteAsync($"categories/{id}");
                if (response.IsSuccessStatusCode) {
                    MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadDataAsync();
                    ClearInputs();
                } else if (response.StatusCode == System.Net.HttpStatusCode.Forbidden) {
                    MessageBox.Show("Bạn không có quyền xóa sản phẩm/nhóm hàng! Chức năng này chỉ dành cho Admin.", "Bị từ chối truy cập (403)", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                } else {
                    MessageBox.Show("Xóa thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private async void btnSearch_Click(object sender, EventArgs e) {
            string keyword = txtKeyword.Text.Trim();
            if (string.IsNullOrEmpty(keyword)) {
                await LoadDataAsync();
                return;
            }

            try {
                using var client = GetAuthenticatedClient();
                var result = await client.GetFromJsonAsync<List<CategoryDto>>($"categories/search?keyword={keyword}");
                dgvCategories.DataSource = result;
            } catch (Exception) {
                MessageBox.Show("Không tìm thấy kết quả phù hợp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ClearInputs() {
            txtId.Text = "";
            txtCategoryName.Text = "";
            txtDescription.Text = "";
        }
    }

    public class CategoryDto {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public string? Description { get; set; }
    }
}

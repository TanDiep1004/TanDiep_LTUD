using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using MiniSupermarket.WinForms.Models;

namespace MiniSupermarket.WinForms {
    public partial class FormCustomerManagement : Form {
        public FormCustomerManagement() {
            InitializeComponent();
        }

        private HttpClient GetAuthenticatedClient() {
            var client = new HttpClient {
                BaseAddress = new Uri("https://localhost:7299/api/")
            };
            if (!string.IsNullOrEmpty(SessionManager.JwtToken)) {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", SessionManager.JwtToken);
            }
            return client;
        }

        private async void FormCustomerManagement_Load(object sender, EventArgs e) {
            // Phân quyền: Cashier không được quyền xóa khách hàng
            if (string.Equals(SessionManager.CurrentRole, "Cashier", StringComparison.OrdinalIgnoreCase)) {
                btnDelete.Enabled = false;
                btnDelete.Text = "Xóa (Chỉ Admin)";
            }
            await LoadDataAsync();
        }

        private async Task LoadDataAsync() {
            try {
                using var client = GetAuthenticatedClient();
                var customers = await client.GetFromJsonAsync<List<Customer>>("customers");
                dgvCustomers.DataSource = customers;
            } catch (Exception ex) {
                MessageBox.Show("Lỗi tải danh sách khách hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnLoad_Click(object sender, EventArgs e) {
            await LoadDataAsync();
        }

        private void dgvCustomers_CellClick(object sender, DataGridViewCellEventArgs e) {
            if (e.RowIndex >= 0) {
                DataGridViewRow row = dgvCustomers.Rows[e.RowIndex];
                txtCustomerId.Text = row.Cells["CustomerId"]?.Value?.ToString() ?? string.Empty;
                txtCustomerName.Text = row.Cells["CustomerName"]?.Value?.ToString() ?? string.Empty;
                txtPhoneNumber.Text = row.Cells["PhoneNumber"]?.Value?.ToString() ?? string.Empty;
                txtAddress.Text = row.Cells["Address"]?.Value?.ToString() ?? string.Empty;
                txtRewardPoints.Text = row.Cells["RewardPoints"]?.Value?.ToString() ?? "0";
                txtMembershipRank.Text = row.Cells["MembershipRank"]?.Value?.ToString() ?? "Chuẩn";
            }
        }

        private async void btnAdd_Click(object sender, EventArgs e) {
            string name = txtCustomerName.Text.Trim();
            string phone = txtPhoneNumber.Text.Trim();

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(phone)) {
                MessageBox.Show("Vui lòng nhập Tên và Số điện thoại khách hàng!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int points = int.TryParse(txtRewardPoints.Text.Trim(), out int p) ? p : 0;
            string rank = string.IsNullOrWhiteSpace(txtMembershipRank.Text.Trim()) ? "Chuẩn" : txtMembershipRank.Text.Trim();

            var newCustomer = new {
                CustomerName = name,
                PhoneNumber = phone,
                Address = txtAddress.Text.Trim(),
                RewardPoints = points,
                MembershipRank = rank
            };

            try {
                using var client = GetAuthenticatedClient();
                var response = await client.PostAsJsonAsync("customers", newCustomer);
                if (response.IsSuccessStatusCode) {
                    MessageBox.Show("Thêm mới khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadDataAsync();
                    ClearInputs();
                } else {
                    MessageBox.Show("Thêm mới thất bại! Kiểm tra dữ liệu đầu vào.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            } catch (Exception ex) {
                MessageBox.Show("Lỗi kết nối: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnUpdate_Click(object sender, EventArgs e) {
            if (string.IsNullOrEmpty(txtCustomerId.Text)) {
                MessageBox.Show("Vui lòng chọn khách hàng cần cập nhật!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int id = int.Parse(txtCustomerId.Text);
            int points = int.TryParse(txtRewardPoints.Text.Trim(), out int p) ? p : 0;
            string rank = string.IsNullOrWhiteSpace(txtMembershipRank.Text.Trim()) ? "Chuẩn" : txtMembershipRank.Text.Trim();

            var updateCustomer = new {
                CustomerId = id,
                CustomerName = txtCustomerName.Text.Trim(),
                PhoneNumber = txtPhoneNumber.Text.Trim(),
                Address = txtAddress.Text.Trim(),
                RewardPoints = points,
                MembershipRank = rank
            };

            try {
                using var client = GetAuthenticatedClient();
                var response = await client.PutAsJsonAsync($"customers/{id}", updateCustomer);
                if (response.IsSuccessStatusCode) {
                    MessageBox.Show("Cập nhật thông tin khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadDataAsync();
                    ClearInputs();
                } else if (response.StatusCode == System.Net.HttpStatusCode.Forbidden) {
                    MessageBox.Show("Bạn không có quyền cập nhật khách hàng! Chức năng này chỉ dành cho Admin.", "Bị từ chối (403)", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                } else {
                    MessageBox.Show("Cập nhật thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            } catch (Exception ex) {
                MessageBox.Show("Lỗi kết nối: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e) {
            if (string.IsNullOrEmpty(txtCustomerId.Text)) {
                MessageBox.Show("Vui lòng chọn khách hàng cần xóa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int id = int.Parse(txtCustomerId.Text);
            var confirm = MessageBox.Show($"Bạn có chắc muốn xóa khách hàng ID = {id}?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes) {
                try {
                    using var client = GetAuthenticatedClient();
                    var response = await client.DeleteAsync($"customers/{id}");
                    if (response.IsSuccessStatusCode) {
                        MessageBox.Show("Xóa khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        await LoadDataAsync();
                        ClearInputs();
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

        private async void btnSearch_Click(object sender, EventArgs e) {
            string keyword = txtKeyword.Text.Trim();
            if (string.IsNullOrEmpty(keyword)) {
                await LoadDataAsync();
                return;
            }

            try {
                using var client = GetAuthenticatedClient();
                var result = await client.GetFromJsonAsync<List<Customer>>($"customers/search?keyword={Uri.EscapeDataString(keyword)}");
                dgvCustomers.DataSource = result;
            } catch (Exception) {
                MessageBox.Show("Không tìm thấy kết quả phù hợp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ClearInputs() {
            txtCustomerId.Text = "";
            txtCustomerName.Text = "";
            txtPhoneNumber.Text = "";
            txtAddress.Text = "";
            txtRewardPoints.Text = "";
            txtMembershipRank.Text = "";
        }
    }
}

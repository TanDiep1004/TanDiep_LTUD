using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using MiniSupermarket.WinForms.Models;

namespace MiniSupermarket.WinForms {
    public partial class FormProductManagement : Form {
        public FormProductManagement() {
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

        private async void FormProductManagement_Load(object sender, EventArgs e) {
            // Phân quyền: Cashier không được quyền xóa sản phẩm
            if (string.Equals(SessionManager.CurrentRole, "Cashier", StringComparison.OrdinalIgnoreCase)) {
                btnDelete.Enabled = false;
                btnDelete.Text = "Xóa (Chỉ Admin)";
            }

            await LoadCategoriesAsync();
            await LoadDataAsync();
        }

        private async Task LoadCategoriesAsync() {
            try {
                using var client = GetAuthenticatedClient();
                var categories = await client.GetFromJsonAsync<List<Category>>("categories");
                cboCategory.DataSource = categories;
                cboCategory.DisplayMember = "CategoryName";
                cboCategory.ValueMember = "CategoryId";
            } catch (Exception ex) {
                MessageBox.Show("Lỗi tải danh mục nhóm hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task LoadDataAsync() {
            try {
                using var client = GetAuthenticatedClient();
                var products = await client.GetFromJsonAsync<List<Product>>("products");
                dgvProducts.DataSource = products;
                FormatProductGrid();
            } catch (Exception ex) {
                MessageBox.Show("Lỗi tải danh sách sản phẩm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormatProductGrid() {
            if (dgvProducts.Columns.Count == 0) return;

            if (dgvProducts.Columns["ProductId"] is DataGridViewColumn colId) {
                colId.HeaderText = "Mã SP";
                colId.FillWeight = 45;
                colId.MinimumWidth = 40;
            }
            if (dgvProducts.Columns["Barcode"] is DataGridViewColumn colBarcode) {
                colBarcode.HeaderText = "Mã Vạch";
                colBarcode.FillWeight = 90;
                colBarcode.MinimumWidth = 80;
            }
            if (dgvProducts.Columns["ProductName"] is DataGridViewColumn colName) {
                colName.HeaderText = "Tên Sản Phẩm";
                colName.FillWeight = 160;
                colName.MinimumWidth = 140;
            }
            if (dgvProducts.Columns["Price"] is DataGridViewColumn colPrice) {
                colPrice.HeaderText = "Đơn Giá";
                colPrice.FillWeight = 75;
                colPrice.MinimumWidth = 70;
                colPrice.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                colPrice.DefaultCellStyle.Format = "#,##0 'đ'";
            }
            if (dgvProducts.Columns["StockQuantity"] is DataGridViewColumn colStock) {
                colStock.HeaderText = "Tồn Kho";
                colStock.FillWeight = 55;
                colStock.MinimumWidth = 50;
                colStock.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
            if (dgvProducts.Columns["CategoryName"] is DataGridViewColumn colCatName) {
                colCatName.HeaderText = "Nhóm Hàng";
                colCatName.FillWeight = 110;
                colCatName.MinimumWidth = 90;
            }
            if (dgvProducts.Columns["CategoryId"] is DataGridViewColumn colCatId) {
                colCatId.Visible = false;
            }
        }

        private async void btnLoad_Click(object sender, EventArgs e) {
            await LoadDataAsync();
        }

        private void dgvProducts_CellClick(object sender, DataGridViewCellEventArgs e) {
            if (e.RowIndex >= 0) {
                DataGridViewRow row = dgvProducts.Rows[e.RowIndex];
                txtProductId.Text = row.Cells["ProductId"]?.Value?.ToString() ?? string.Empty;
                txtBarcode.Text = row.Cells["Barcode"]?.Value?.ToString() ?? string.Empty;
                txtProductName.Text = row.Cells["ProductName"]?.Value?.ToString() ?? string.Empty;
                txtPrice.Text = row.Cells["Price"]?.Value?.ToString() ?? "0";
                txtStockQuantity.Text = row.Cells["StockQuantity"]?.Value?.ToString() ?? "0";

                if (row.Cells["CategoryId"]?.Value != null && int.TryParse(row.Cells["CategoryId"]?.Value?.ToString(), out int catId)) {
                    cboCategory.SelectedValue = catId;
                }
            }
        }

        private async void btnAdd_Click(object sender, EventArgs e) {
            string barcode = txtBarcode.Text.Trim();
            string name = txtProductName.Text.Trim();

            if (string.IsNullOrEmpty(barcode) || string.IsNullOrEmpty(name)) {
                MessageBox.Show("Vui lòng nhập Mã vạch và Tên sản phẩm!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtPrice.Text.Trim(), out decimal price) || price < 0) {
                MessageBox.Show("Đơn giá không hợp lệ!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtStockQuantity.Text.Trim(), out int stock) || stock < 0) {
                MessageBox.Show("Số lượng tồn kho không hợp lệ!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cboCategory.SelectedValue == null) {
                MessageBox.Show("Vui lòng chọn Nhóm hàng cho sản phẩm!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var newProduct = new {
                Barcode = barcode,
                ProductName = name,
                Price = price,
                StockQuantity = stock,
                CategoryId = (int)cboCategory.SelectedValue
            };

            try {
                using var client = GetAuthenticatedClient();
                var response = await client.PostAsJsonAsync("products", newProduct);
                if (response.IsSuccessStatusCode) {
                    MessageBox.Show("Thêm mới sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            if (string.IsNullOrEmpty(txtProductId.Text)) {
                MessageBox.Show("Vui lòng chọn sản phẩm cần cập nhật từ danh sách!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int id = int.Parse(txtProductId.Text);
            string barcode = txtBarcode.Text.Trim();
            string name = txtProductName.Text.Trim();

            if (string.IsNullOrEmpty(barcode) || string.IsNullOrEmpty(name)) {
                MessageBox.Show("Vui lòng nhập Mã vạch và Tên sản phẩm!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtPrice.Text.Trim(), out decimal price) || price < 0) {
                MessageBox.Show("Đơn giá không hợp lệ!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtStockQuantity.Text.Trim(), out int stock) || stock < 0) {
                MessageBox.Show("Số lượng tồn kho không hợp lệ!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cboCategory.SelectedValue == null) {
                MessageBox.Show("Vui lòng chọn Nhóm hàng!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var updateProduct = new {
                ProductId = id,
                Barcode = barcode,
                ProductName = name,
                Price = price,
                StockQuantity = stock,
                CategoryId = (int)cboCategory.SelectedValue
            };

            try {
                using var client = GetAuthenticatedClient();
                var response = await client.PutAsJsonAsync($"products/{id}", updateProduct);
                if (response.IsSuccessStatusCode) {
                    MessageBox.Show("Cập nhật thông tin sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadDataAsync();
                    ClearInputs();
                } else if (response.StatusCode == System.Net.HttpStatusCode.Forbidden) {
                    MessageBox.Show("Bạn không có quyền cập nhật sản phẩm!", "Bị từ chối (403)", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                } else {
                    MessageBox.Show("Cập nhật sản phẩm thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            } catch (Exception ex) {
                MessageBox.Show("Lỗi kết nối: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e) {
            if (string.IsNullOrEmpty(txtProductId.Text)) {
                MessageBox.Show("Vui lòng chọn sản phẩm cần xóa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int id = int.Parse(txtProductId.Text);
            var confirm = MessageBox.Show($"Bạn có chắc chắn muốn xóa sản phẩm ID = {id} ({txtProductName.Text})?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes) {
                try {
                    using var client = GetAuthenticatedClient();
                    var response = await client.DeleteAsync($"products/{id}");
                    if (response.IsSuccessStatusCode) {
                        MessageBox.Show("Xóa sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        await LoadDataAsync();
                        ClearInputs();
                    } else if (response.StatusCode == System.Net.HttpStatusCode.Forbidden) {
                        MessageBox.Show("Bạn không có quyền xóa sản phẩm! Chức năng này chỉ dành cho Admin.", "Bị từ chối (403)", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    } else {
                        MessageBox.Show("Xóa sản phẩm thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                var result = await client.GetFromJsonAsync<List<Product>>($"products/search?keyword={Uri.EscapeDataString(keyword)}");
                dgvProducts.DataSource = result;
                FormatProductGrid();
            } catch (Exception) {
                MessageBox.Show("Không tìm thấy kết quả phù hợp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ClearInputs() {
            txtProductId.Text = "";
            txtBarcode.Text = "";
            txtProductName.Text = "";
            txtPrice.Text = "";
            txtStockQuantity.Text = "";
            if (cboCategory.Items.Count > 0) {
                cboCategory.SelectedIndex = 0;
            }
        }
    }
}

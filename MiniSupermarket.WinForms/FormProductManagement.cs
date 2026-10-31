using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MiniSupermarket.WinForms.Models;

namespace MiniSupermarket.WinForms {
    public partial class FormProductManagement : Form {
        private bool _isSuppressingFilterEvents = false;
        private List<Product> _cachedAllProducts = new();
        private List<Category> _categories = new();
        private readonly Dictionary<int, decimal> _customImportPrices = new();
        private readonly Dictionary<int, decimal> _customWholesalePrices = new();
        private readonly Dictionary<int, string> _customUnits = new();
        private readonly Dictionary<int, string> _customStatuses = new();
        private readonly Dictionary<int, string> _customDescriptions = new();

        private int _currentPage = 1;
        private const int PageSize = 10;
        private int _totalPages = 1;
        private int _totalItems = 0;
        private Product? _selectedProduct = null;

        public FormProductManagement() {
            InitializeComponent();
            ConfigureGridAppearance();
        }

        private HttpClient GetAuthenticatedClient() {
            return ApiClientService.CreateClient();
        }

        private void ConfigureGridAppearance() {
            dgvProducts.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(241, 245, 249);
            dgvProducts.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(30, 41, 59);
            dgvProducts.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 8.8F, FontStyle.Bold);
            dgvProducts.DefaultCellStyle.Font = new Font("Segoe UI", 9F);
            dgvProducts.DefaultCellStyle.ForeColor = Color.FromArgb(15, 23, 42);
            dgvProducts.DefaultCellStyle.SelectionBackColor = Color.FromArgb(219, 234, 254);
            dgvProducts.DefaultCellStyle.SelectionForeColor = Color.FromArgb(15, 23, 42);
            dgvProducts.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 250, 252);
            dgvProducts.CellFormatting += DgvProducts_CellFormatting;
        }

        private async void FormProductManagement_Load(object sender, EventArgs e) {
            if (string.Equals(SessionManager.CurrentRole, "Cashier", StringComparison.OrdinalIgnoreCase)) {
                btnAdd.Enabled = false;
                btnUpdate.Enabled = false;
                btnHeaderEdit.Enabled = false;
                btnHeaderPrice.Enabled = false;
                btnDelete.Enabled = false;
                btnImportExcel.Enabled = false;
                btnUpdateWholesale.Enabled = false;
                mnuEditProduct.Enabled = false;
                mnuUpdatePrice.Enabled = false;
                mnuDeleteProduct.Enabled = false;
            } else if (!string.Equals(SessionManager.CurrentRole, "Admin", StringComparison.OrdinalIgnoreCase)) {
                // Thủ kho (Warehouse): Có quyền xem, thêm, sửa, nhập kho nhưng KHÔNG được xóa sản phẩm (chỉ Admin)
                btnDelete.Enabled = false;
                mnuDeleteProduct.Enabled = false;
            }

            _isSuppressingFilterEvents = true;
            if (cboFilterStatus.Items.Count > 0) {
                cboFilterStatus.SelectedIndex = 0;
            }
            _isSuppressingFilterEvents = false;

            await LoadCategoriesAsync();
            await LoadDataAsync(1);
        }

        private void FormProductManagement_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.F3 && btnAdd.Enabled) {
                e.Handled = true;
                btnAdd_Click(this, EventArgs.Empty);
            }
        }

        private async Task LoadCategoriesAsync() {
            try {
                _isSuppressingFilterEvents = true;
                using var client = GetAuthenticatedClient();
                _categories = await client.GetFromJsonAsync<List<Category>>("categories") ?? new List<Category>();

                cboFilterCategory.Items.Clear();
                cboFilterCategory.Items.Add("All");

                var defaultGroups = new[] { "Bánh kẹo", "Nước giải khát", "Gia vị", "Đồ tươi sống", "Khác" };
                foreach (var g in defaultGroups) {
                    if (!cboFilterCategory.Items.Contains(g)) {
                        cboFilterCategory.Items.Add(g);
                    }
                }
                foreach (var cat in _categories) {
                    if (!string.IsNullOrWhiteSpace(cat.CategoryName) && !cboFilterCategory.Items.Contains(cat.CategoryName)) {
                        cboFilterCategory.Items.Add(cat.CategoryName);
                    }
                }
                cboFilterCategory.SelectedIndex = 0;
            } catch (Exception ex) {
                MessageBox.Show("Lỗi tải danh mục ngành hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } finally {
                _isSuppressingFilterEvents = false;
            }
        }

        private async Task LoadDataAsync(int page = 1) {
            try {
                using var client = GetAuthenticatedClient();
                var allProducts = await client.GetFromJsonAsync<List<Product>>("products") ?? new List<Product>();
                _cachedAllProducts = allProducts;

                if (IsDefaultUnfilteredState()) {
                    await LoadPagedFromServerAsync(page);
                } else {
                    _currentPage = page;
                    FilterCachedProductsImmediately(resetPage: false);
                }
            } catch (Exception ex) {
                MessageBox.Show("Lỗi tải danh sách sản phẩm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool IsDefaultUnfilteredState() {
            string kw = txtKeyword.Text.Trim();
            string cat = cboFilterCategory.SelectedItem?.ToString() ?? "All";
            string status = cboFilterStatus.SelectedItem?.ToString() ?? "All";
            return string.IsNullOrEmpty(kw) && cat == "All" && status == "All";
        }

        private async Task LoadPagedFromServerAsync(int page) {
            using var client = GetAuthenticatedClient();
            string keyword = txtKeyword.Text.Trim();
            string url = $"products/paged?page={page}&pageSize={PageSize}";
            if (!string.IsNullOrEmpty(keyword)) {
                url += $"&keyword={Uri.EscapeDataString(keyword)}";
            }

            var paged = await client.GetFromJsonAsync<PagedProductResponse>(url);
            if (paged != null) {
                _currentPage = paged.Page;
                _totalPages = Math.Max(1, paged.TotalPages);
                _totalItems = paged.TotalItems;

                BindProductsToGrid(paged.Items, (_currentPage - 1) * PageSize);
                UpdatePaginationControls();
            }
        }

        private void BindProductsToGrid(List<Product> products, int startIndexOffset) {
            var rows = new List<ProductGridRowViewModel>(products.Count);
            for (int i = 0; i < products.Count; i++) {
                var p = products[i];
                decimal retailPrice = p.Price;
                decimal importPrice = GetImportPrice(p);
                decimal wholesalePrice = GetWholesalePrice(p);
                string unit = GetProductUnit(p);
                string status = GetProductStatus(p);
                string catDisplay = GetDisplayCategory(p);

                rows.Add(new ProductGridRowViewModel {
                    ProductId = p.ProductId,
                    STT = startIndexOffset + i + 1,
                    ProductCode = $"SP{p.ProductId:D3}",
                    Barcode = string.IsNullOrWhiteSpace(p.Barcode) ? $"893456{p.ProductId:D4}" : p.Barcode,
                    ProductName = p.ProductName,
                    Unit = unit,
                    ImportPriceStr = $"{importPrice:#,##0} đ  ✎",
                    RetailPriceStr = $"{retailPrice:#,##0} đ  ✎",
                    WholesalePriceStr = $"{wholesalePrice:#,##0} đ",
                    CategoryName = catDisplay,
                    Status = status,
                    StockQuantity = p.StockQuantity,
                    Thumbnail = CreateThumbnailBitmap(p.ProductName, catDisplay)
                });
            }

            dgvProducts.DataSource = null;
            dgvProducts.DataSource = rows;
            FormatProductGrid();

            if (products.Count > 0) {
                int selectIdx = 0;
                if (_selectedProduct != null) {
                    int found = products.FindIndex(x => x.ProductId == _selectedProduct.ProductId);
                    if (found >= 0) selectIdx = found;
                }
                if (selectIdx < dgvProducts.Rows.Count) {
                    dgvProducts.ClearSelection();
                    dgvProducts.Rows[selectIdx].Selected = true;
                }
                SelectProductAndPopulateDetail(products[selectIdx]);
            } else {
                SelectProductAndPopulateDetail(null);
            }
        }

        private void FormatProductGrid() {
            if (dgvProducts.Columns.Count == 0) return;

            dgvProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            if (dgvProducts.Columns["ProductId"] is DataGridViewColumn colHiddenId) {
                colHiddenId.Visible = false;
            }
            if (dgvProducts.Columns["STT"] is DataGridViewColumn colStt) {
                colStt.HeaderText = "STT";
                colStt.FillWeight = 34;
                colStt.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            if (dgvProducts.Columns["ProductCode"] is DataGridViewColumn colCode) {
                colCode.HeaderText = "Mã SP";
                colCode.FillWeight = 55;
                colCode.DefaultCellStyle.Font = new Font("Segoe UI", 8.8F, FontStyle.Bold);
            }
            if (dgvProducts.Columns["Barcode"] is DataGridViewColumn colBarcode) {
                colBarcode.HeaderText = "Mã vạch";
                colBarcode.FillWeight = 85;
            }
            if (dgvProducts.Columns["ProductName"] is DataGridViewColumn colName) {
                colName.HeaderText = "Tên sản phẩm";
                colName.FillWeight = 155;
            }
            if (dgvProducts.Columns["Unit"] is DataGridViewColumn colUnit) {
                colUnit.HeaderText = "ĐVT";
                colUnit.FillWeight = 44;
                colUnit.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            if (dgvProducts.Columns["ImportPriceStr"] is DataGridViewColumn colImp) {
                colImp.HeaderText = "Giá nhập";
                colImp.FillWeight = 82;
                colImp.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                colImp.ToolTipText = "Nhấn vào biểu tượng ✎ để sửa nhanh Giá nhập";
            }
            if (dgvProducts.Columns["RetailPriceStr"] is DataGridViewColumn colRet) {
                colRet.HeaderText = "Giá bán lẻ";
                colRet.FillWeight = 85;
                colRet.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                colRet.DefaultCellStyle.Font = new Font("Segoe UI", 8.8F, FontStyle.Bold);
                colRet.ToolTipText = "Nhấn vào biểu tượng ✎ để sửa nhanh Giá bán lẻ";
            }
            if (dgvProducts.Columns["WholesalePriceStr"] is DataGridViewColumn colWho) {
                colWho.HeaderText = "Giá bán sỉ";
                colWho.FillWeight = 78;
                colWho.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
            if (dgvProducts.Columns["CategoryName"] is DataGridViewColumn colCat) {
                colCat.HeaderText = "Ngành hàng";
                colCat.FillWeight = 90;
            }
            if (dgvProducts.Columns["Status"] is DataGridViewColumn colStatus) {
                colStatus.HeaderText = "Trạng thái";
                colStatus.FillWeight = 72;
                colStatus.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            if (dgvProducts.Columns["StockQuantity"] is DataGridViewColumn colStock) {
                colStock.HeaderText = "Tồn kho";
                colStock.FillWeight = 58;
                colStock.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                colStock.DefaultCellStyle.Font = new Font("Segoe UI", 8.8F, FontStyle.Bold);
            }
            if (dgvProducts.Columns["Thumbnail"] is DataGridViewImageColumn colImg) {
                colImg.HeaderText = "Hình ảnh";
                colImg.FillWeight = 52;
                colImg.ImageLayout = DataGridViewImageCellLayout.Normal;
                colImg.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        private void DgvProducts_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e) {
            if (e.RowIndex < 0 || e.ColumnIndex < 0 || e.CellStyle == null) return;
            string colName = dgvProducts.Columns[e.ColumnIndex].Name;

            // Tiêu chí 43: Bắt sự kiện CellFormatting của DataGridView: nếu cột StockQuantity <= 10 thì đổi e.CellStyle.BackColor = Color.LightCoral
            if (colName == "StockQuantity" && e.Value != null && int.TryParse(e.Value.ToString(), out int stockQty)) {
                if (stockQty <= 10) {
                    e.CellStyle.BackColor = Color.LightCoral;
                    e.CellStyle.ForeColor = Color.White;
                    e.CellStyle.Font = new Font("Segoe UI", 8.8F, FontStyle.Bold);
                } else {
                    e.CellStyle.ForeColor = Color.FromArgb(15, 23, 42);
                }
            } else if (colName == "Status" && e.Value is string statusVal) {
                if (statusVal == "Đang bán") {
                    e.CellStyle.ForeColor = Color.FromArgb(22, 101, 52);
                    e.CellStyle.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
                } else {
                    e.CellStyle.ForeColor = Color.FromArgb(185, 28, 28);
                    e.CellStyle.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
                }
            } else if (colName == "RetailPriceStr") {
                e.CellStyle.ForeColor = Color.FromArgb(29, 78, 216);
            } else if (colName == "ImportPriceStr") {
                e.CellStyle.ForeColor = Color.FromArgb(51, 65, 85);
            }
        }

        private decimal GetImportPrice(Product p) {
            if (_customImportPrices.TryGetValue(p.ProductId, out decimal custom)) {
                return custom;
            }
            return Math.Round((p.Price * 0.80m) / 500m, 0) * 500m;
        }

        private decimal GetWholesalePrice(Product p) {
            if (_customWholesalePrices.TryGetValue(p.ProductId, out decimal custom)) {
                return custom;
            }
            return Math.Round((p.Price * 0.92m) / 500m, 0) * 500m;
        }

        private string GetProductUnit(Product p) {
            if (_customUnits.TryGetValue(p.ProductId, out string? custom) && !string.IsNullOrWhiteSpace(custom)) {
                return custom;
            }
            string name = p.ProductName.ToLowerInvariant();
            if (name.Contains("bánh") || name.Contains("kẹo") || name.Contains("mì") || name.Contains("bim") || name.Contains("snack"))
                return "Gói";
            if (name.Contains("bia") || name.Contains("coca") || name.Contains("pepsi") || name.Contains("redbull") || name.Contains("lon"))
                return "Lon";
            if (name.Contains("nước") || name.Contains("dầu") || name.Contains("tương") || name.Contains("chai") || name.Contains("trà"))
                return "Chai";
            if (name.Contains("sữa") || name.Contains("hộp") || name.Contains("trứng"))
                return "Hộp";
            if (name.Contains("gạo") || name.Contains("đường") || name.Contains("muối"))
                return "Túi";
            return "Gói";
        }

        private string GetProductStatus(Product p) {
            if (_customStatuses.TryGetValue(p.ProductId, out string? status) && !string.IsNullOrWhiteSpace(status)) {
                return status;
            }
            return p.StockQuantity > 0 ? "Đang bán" : "Ngừng bán";
        }

        private string GetDisplayCategory(Product p) {
            if (!string.IsNullOrWhiteSpace(p.CategoryName)) {
                return p.CategoryName;
            }
            var found = _categories.FirstOrDefault(c => c.CategoryId == p.CategoryId);
            if (found != null && !string.IsNullOrWhiteSpace(found.CategoryName)) {
                return found.CategoryName;
            }
            string n = p.ProductName.ToLowerInvariant();
            if (n.Contains("bánh") || n.Contains("kẹo") || n.Contains("snack")) return "Bánh kẹo";
            if (n.Contains("nước") || n.Contains("sữa") || n.Contains("bia") || n.Contains("trà") || n.Contains("pepsi") || n.Contains("coca")) return "Nước giải khát";
            if (n.Contains("dầu") || n.Contains("mắm") || n.Contains("muối") || n.Contains("đường") || n.Contains("hạt nêm")) return "Gia vị";
            return "Bánh kẹo";
        }

        private string GetProductDescription(Product p) {
            if (_customDescriptions.TryGetValue(p.ProductId, out string? desc) && !string.IsNullOrWhiteSpace(desc)) {
                return desc;
            }
            string unit = GetProductUnit(p);
            string cat = GetDisplayCategory(p);
            return $"{p.ProductName} thuộc ngành hàng {cat}. Quy cách đóng gói: {unit} tiêu chuẩn chính hãng, mã vạch {p.Barcode}. Tồn kho hiện tại: {p.StockQuantity} {unit.ToLowerInvariant()}. Bảo quản nơi khô ráo, thoáng mát, tránh ánh nắng trực tiếp.";
        }

        private static Bitmap CreateThumbnailBitmap(string productName, string categoryName) {
            Bitmap bmp = new Bitmap(22, 22);
            using (Graphics g = Graphics.FromImage(bmp)) {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                Color bg = Color.FromArgb(219, 234, 254);
                Color fg = Color.FromArgb(29, 78, 216);

                string cat = (categoryName ?? "").ToLowerInvariant();
                if (cat.Contains("bánh") || productName.Contains("Bánh", StringComparison.OrdinalIgnoreCase)) {
                    bg = Color.FromArgb(254, 243, 199);
                    fg = Color.FromArgb(180, 83, 9);
                } else if (cat.Contains("nước") || cat.Contains("sữa") || cat.Contains("giải khát")) {
                    bg = Color.FromArgb(220, 252, 231);
                    fg = Color.FromArgb(21, 128, 61);
                } else if (cat.Contains("gia vị")) {
                    bg = Color.FromArgb(254, 226, 226);
                    fg = Color.FromArgb(185, 28, 28);
                }

                using var brush = new SolidBrush(bg);
                using var pen = new Pen(fg, 1.3f);
                g.FillRectangle(brush, 1, 1, 19, 19);
                g.DrawRectangle(pen, 1, 1, 19, 19);

                string initial = string.IsNullOrWhiteSpace(productName) ? "SP" : productName.Trim().Substring(0, 1).ToUpperInvariant();
                using var font = new Font("Segoe UI", 8F, FontStyle.Bold);
                using var textBrush = new SolidBrush(fg);
                var sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
                g.DrawString(initial, font, textBrush, new RectangleF(1, 1, 20, 20), sf);
            }
            return bmp;
        }

        private static Bitmap CreateDetailPreviewBitmap(Product p, string categoryName) {
            Bitmap bmp = new Bitmap(84, 84);
            using (Graphics g = Graphics.FromImage(bmp)) {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.Clear(Color.FromArgb(248, 250, 252));

                Color accent = Color.FromArgb(37, 99, 235);
                if (categoryName.Contains("Bánh", StringComparison.OrdinalIgnoreCase) || p.ProductName.Contains("Bánh", StringComparison.OrdinalIgnoreCase)) {
                    accent = Color.FromArgb(217, 119, 6);
                } else if (categoryName.Contains("Nước", StringComparison.OrdinalIgnoreCase) || categoryName.Contains("Sữa", StringComparison.OrdinalIgnoreCase)) {
                    accent = Color.FromArgb(22, 163, 74);
                }

                using var bgBrush = new SolidBrush(Color.FromArgb(25, accent));
                g.FillEllipse(bgBrush, 10, 8, 64, 52);

                using var borderPen = new Pen(accent, 2f);
                g.DrawRectangle(borderPen, 24, 16, 36, 34);
                g.DrawLine(borderPen, 24, 26, 60, 26);

                using var codeFont = new Font("Segoe UI", 8.5F, FontStyle.Bold);
                using var textBrush = new SolidBrush(Color.FromArgb(30, 41, 59));
                var sf = new StringFormat { Alignment = StringAlignment.Center };
                g.DrawString($"SP{p.ProductId:D3}", codeFont, textBrush, new RectangleF(0, 62, 84, 18), sf);
            }
            return bmp;
        }

        private void SelectProductAndPopulateDetail(Product? p) {
            _selectedProduct = p;
            if (p == null) {
                txtDetailProductName.Text = string.Empty;
                txtDetailRetailPrice.Text = string.Empty;
                txtDetailWholesalePrice.Text = string.Empty;
                txtDetailDescription.Text = string.Empty;
                lblQuickStockInfo.Text = "Không có sản phẩm nào được chọn.";
                picProductDetail.Image = null;
                return;
            }

            string unit = GetProductUnit(p);
            decimal retail = p.Price;
            decimal wholesale = GetWholesalePrice(p);
            decimal importPrice = GetImportPrice(p);
            string cat = GetDisplayCategory(p);
            string status = GetProductStatus(p);

            txtDetailProductName.Text = p.ProductName;
            txtDetailRetailPrice.Text = $"{retail:#,##0} đ / {unit}";
            txtDetailWholesalePrice.Text = $"{wholesale:#,##0} đ / Thùng (24 {unit.ToLowerInvariant()})";
            txtDetailDescription.Text = GetProductDescription(p);

            picProductDetail.Image?.Dispose();
            picProductDetail.Image = CreateDetailPreviewBitmap(p, cat);

            lblQuickStockInfo.Text =
                $"• Mã SP: SP{p.ProductId:D3}\r\n" +
                $"• Mã vạch: {p.Barcode}\r\n" +
                $"• Tồn kho: {p.StockQuantity} {unit}\r\n" +
                $"• Giá nhập: {importPrice:#,##0} đ\r\n" +
                $"• Trạng thái: {status}";
        }

        private void UpdatePaginationControls() {
            lblPageInfo.Text = $"Trang {_currentPage} / {_totalPages}";
            btnPrevPage.Enabled = _currentPage > 1;
            btnNextPage.Enabled = _currentPage < _totalPages;
        }

        private async void btnPrevPage_Click(object sender, EventArgs e) {
            if (_currentPage > 1) {
                if (IsDefaultUnfilteredState()) {
                    await LoadPagedFromServerAsync(_currentPage - 1);
                } else {
                    _currentPage--;
                    FilterCachedProductsImmediately(resetPage: false);
                }
            }
        }

        private async void btnNextPage_Click(object sender, EventArgs e) {
            if (_currentPage < _totalPages) {
                if (IsDefaultUnfilteredState()) {
                    await LoadPagedFromServerAsync(_currentPage + 1);
                } else {
                    _currentPage++;
                    FilterCachedProductsImmediately(resetPage: false);
                }
            }
        }

        private async void btnLoad_Click(object sender, EventArgs e) {
            _isSuppressingFilterEvents = true;
            txtKeyword.Clear();
            if (cboFilterCategory.Items.Count > 0) cboFilterCategory.SelectedIndex = 0;
            if (cboFilterStatus.Items.Count > 0) cboFilterStatus.SelectedIndex = 0;
            _isSuppressingFilterEvents = false;
            await LoadDataAsync(1);
        }

        private void txtKeyword_TextChanged(object sender, EventArgs e) {
            if (_isSuppressingFilterEvents) return;
            FilterCachedProductsImmediately(resetPage: true);
        }

        private async void txtKeyword_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                e.Handled = true;
                e.SuppressKeyPress = true;
                await ExecuteSearchAndFilterAsync();
            }
        }

        private async void btnSearch_Click(object sender, EventArgs e) {
            await ExecuteSearchAndFilterAsync();
        }

        private void FilterCombo_SelectedIndexChanged(object sender, EventArgs e) {
            if (_isSuppressingFilterEvents) return;
            FilterCachedProductsImmediately(resetPage: true);
        }

        /// <summary>
        /// Lọc tức thì (0ms) theo Từ khóa (ưu tiên chữ bắt đầu như "Bánh..."), Ngành hàng và Trạng thái, kết hợp phân trang .Skip()/.Take()
        /// </summary>
        private void FilterCachedProductsImmediately(bool resetPage = true) {
            if (_cachedAllProducts.Count == 0) return;

            if (resetPage) _currentPage = 1;
            string keyword = txtKeyword.Text.Trim();
            string selectedCat = cboFilterCategory.SelectedItem?.ToString() ?? "All";
            string selectedStatus = cboFilterStatus.SelectedItem?.ToString() ?? "All";

            IEnumerable<Product> query = _cachedAllProducts;

            if (!string.IsNullOrEmpty(selectedCat) && selectedCat != "All") {
                string catNorm = RemoveDiacritics(selectedCat);
                query = query.Where(p => {
                    string pCat = GetDisplayCategory(p);
                    return pCat.Contains(selectedCat, StringComparison.OrdinalIgnoreCase) ||
                           RemoveDiacritics(pCat).Contains(catNorm, StringComparison.OrdinalIgnoreCase) ||
                           (selectedCat == "Bánh kẹo" && RemoveDiacritics(p.ProductName).Contains("banh", StringComparison.OrdinalIgnoreCase));
                });
            }

            if (!string.IsNullOrEmpty(selectedStatus) && selectedStatus != "All") {
                query = query.Where(p => string.Equals(GetProductStatus(p), selectedStatus, StringComparison.OrdinalIgnoreCase));
            }

            if (!string.IsNullOrEmpty(keyword)) {
                string kwUnsigned = RemoveDiacritics(keyword);
                query = query
                    .Where(p => p.ProductName.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                                RemoveDiacritics(p.ProductName).Contains(kwUnsigned, StringComparison.OrdinalIgnoreCase) ||
                                p.Barcode.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                                $"SP{p.ProductId:D3}".Contains(keyword, StringComparison.OrdinalIgnoreCase))
                    .OrderByDescending(p => p.ProductName.StartsWith(keyword, StringComparison.OrdinalIgnoreCase) ||
                                            RemoveDiacritics(p.ProductName).StartsWith(kwUnsigned, StringComparison.OrdinalIgnoreCase))
                    .ThenBy(p => p.ProductId);
            } else {
                query = query.OrderBy(p => p.ProductId);
            }

            var allMatched = query.ToList();
            _totalItems = allMatched.Count;
            _totalPages = Math.Max(1, (int)Math.Ceiling(_totalItems / (double)PageSize));
            if (_currentPage > _totalPages) _currentPage = _totalPages;

            int offset = (_currentPage - 1) * PageSize;
            var pagedItems = allMatched
                .Skip(offset)
                .Take(PageSize)
                .ToList();

            BindProductsToGrid(pagedItems, offset);
            UpdatePaginationControls();
        }

        private async Task ExecuteSearchAndFilterAsync() {
            string keyword = txtKeyword.Text.Trim();
            if (IsDefaultUnfilteredState()) {
                await LoadDataAsync(1);
                return;
            }

            try {
                if (!string.IsNullOrEmpty(keyword)) {
                    using var client = GetAuthenticatedClient();
                    string url = $"products/search?keyword={Uri.EscapeDataString(keyword)}";
                    var apiResult = await client.GetFromJsonAsync<List<Product>>(url) ?? new List<Product>();
                    if (apiResult.Count > 0 && _cachedAllProducts.Count == 0) {
                        _cachedAllProducts = apiResult;
                    }
                }
                FilterCachedProductsImmediately(resetPage: true);
            } catch (Exception ex) {
                MessageBox.Show("Lỗi khi tìm kiếm sản phẩm: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private static string RemoveDiacritics(string text) {
            if (string.IsNullOrWhiteSpace(text)) return string.Empty;
            var normalized = text.Normalize(NormalizationForm.FormD);
            var sb = new StringBuilder();
            foreach (var c in normalized) {
                if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark) {
                    sb.Append(c);
                }
            }
            return sb.ToString().Normalize(NormalizationForm.FormC).Replace('đ', 'd').Replace('Đ', 'D');
        }

        private Product? GetProductByRowIndex(int rowIndex) {
            if (rowIndex < 0 || rowIndex >= dgvProducts.Rows.Count) return null;
            var rowObj = dgvProducts.Rows[rowIndex].DataBoundItem as ProductGridRowViewModel;
            if (rowObj == null) return null;
            return _cachedAllProducts.FirstOrDefault(p => p.ProductId == rowObj.ProductId);
        }

        private async void dgvProducts_CellClick(object sender, DataGridViewCellEventArgs e) {
            if (e.RowIndex < 0) return;
            var product = GetProductByRowIndex(e.RowIndex);
            SelectProductAndPopulateDetail(product);

            if (product != null && e.ColumnIndex >= 0) {
                string colName = dgvProducts.Columns[e.ColumnIndex].Name;
                if ((colName == "ImportPriceStr" || colName == "RetailPriceStr") && btnUpdate.Enabled) {
                    await ShowQuickPriceDialogAsync(product, focusImport: colName == "ImportPriceStr");
                }
            }
        }

        private void dgvProducts_CellDoubleClick(object sender, DataGridViewCellEventArgs e) {
            if (e.RowIndex < 0) return;
            var product = GetProductByRowIndex(e.RowIndex);
            if (product != null && btnUpdate.Enabled) {
                btnUpdate_Click(sender, EventArgs.Empty);
            }
        }

        private void dgvProducts_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e) {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0) {
                dgvProducts.ClearSelection();
                dgvProducts.Rows[e.RowIndex].Selected = true;
                var product = GetProductByRowIndex(e.RowIndex);
                SelectProductAndPopulateDetail(product);
            }
        }

        private async void mnuUpdatePrice_Click(object sender, EventArgs e) {
            if (_selectedProduct == null) {
                MessageBox.Show("Vui lòng chọn một sản phẩm trên bảng để cập nhật giá!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            await ShowQuickPriceDialogAsync(_selectedProduct, focusImport: false);
        }

        private void mnuViewDetail_Click(object sender, EventArgs e) {
            if (_selectedProduct == null) {
                MessageBox.Show("Vui lòng chọn một sản phẩm trên bảng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            SelectProductAndPopulateDetail(_selectedProduct);
            txtDetailDescription.Focus();
            MessageBox.Show(
                $"Mã sản phẩm: SP{_selectedProduct.ProductId:D3}\n" +
                $"Mã vạch: {_selectedProduct.Barcode}\n" +
                $"Tên sản phẩm: {_selectedProduct.ProductName}\n" +
                $"Ngành hàng: {GetDisplayCategory(_selectedProduct)}\n" +
                $"Đơn vị tính: {GetProductUnit(_selectedProduct)}\n" +
                $"Giá nhập: {GetImportPrice(_selectedProduct):#,##0} đ\n" +
                $"Giá bán lẻ: {_selectedProduct.Price:#,##0} đ\n" +
                $"Giá bán sỉ: {GetWholesalePrice(_selectedProduct):#,##0} đ\n" +
                $"Tồn kho: {_selectedProduct.StockQuantity}\n" +
                $"Trạng thái: {GetProductStatus(_selectedProduct)}\n\n" +
                $"Mô tả: {GetProductDescription(_selectedProduct)}",
                "Chi tiết Sản phẩm",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private async Task ShowQuickPriceDialogAsync(Product product, bool focusImport) {
            using var dlg = new Form {
                Text = $"Cập nhật Giá nhanh - SP{product.ProductId:D3} ({product.ProductName})",
                Size = new Size(420, 290),
                FormBorderStyle = FormBorderStyle.FixedDialog,
                StartPosition = FormStartPosition.CenterParent,
                MaximizeBox = false,
                MinimizeBox = false,
                BackColor = Color.White,
                Font = new Font("Segoe UI", 9.5F)
            };

            var lblTitle = new Label {
                Text = $"✎ ĐIỀU CHỈNH GIÁ: {product.ProductName}",
                Font = new Font("Segoe UI", 10.5F, FontStyle.Bold),
                ForeColor = Color.FromArgb(15, 23, 42),
                Location = new Point(20, 16),
                AutoSize = true
            };

            var lblImp = new Label { Text = "Giá nhập (đ):", Location = new Point(20, 56), AutoSize = true };
            var txtImp = new TextBox {
                Text = GetImportPrice(product).ToString("0"),
                Location = new Point(155, 52),
                Size = new Size(220, 26)
            };

            var lblRet = new Label { Text = "Giá bán lẻ (đ):", Location = new Point(20, 96), AutoSize = true };
            var txtRet = new TextBox {
                Text = product.Price.ToString("0"),
                Location = new Point(155, 92),
                Size = new Size(220, 26)
            };

            var lblWho = new Label { Text = "Giá bán sỉ (đ):", Location = new Point(20, 136), AutoSize = true };
            var txtWho = new TextBox {
                Text = GetWholesalePrice(product).ToString("0"),
                Location = new Point(155, 132),
                Size = new Size(220, 26)
            };

            var btnSave = new Button {
                Text = "Lưu thay đổi",
                BackColor = Color.FromArgb(29, 112, 184),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9.5F, FontStyle.Bold),
                Location = new Point(155, 188),
                Size = new Size(115, 36),
                DialogResult = DialogResult.OK
            };
            btnSave.FlatAppearance.BorderSize = 0;

            var btnCancel = new Button {
                Text = "Hủy",
                BackColor = Color.FromArgb(226, 232, 240),
                ForeColor = Color.FromArgb(30, 41, 59),
                FlatStyle = FlatStyle.Flat,
                Location = new Point(280, 188),
                Size = new Size(95, 36),
                DialogResult = DialogResult.Cancel
            };
            btnCancel.FlatAppearance.BorderSize = 0;

            dlg.Controls.AddRange(new Control[] { lblTitle, lblImp, txtImp, lblRet, txtRet, lblWho, txtWho, btnSave, btnCancel });
            dlg.AcceptButton = btnSave;
            dlg.CancelButton = btnCancel;
            dlg.Shown += (_, _) => {
                if (focusImport) { txtImp.Focus(); txtImp.SelectAll(); }
                else { txtRet.Focus(); txtRet.SelectAll(); }
            };

            if (dlg.ShowDialog(this) == DialogResult.OK) {
                decimal.TryParse(txtImp.Text.Replace(",", "").Replace(".", "").Trim(), out decimal newImp);
                decimal.TryParse(txtRet.Text.Replace(",", "").Replace(".", "").Trim(), out decimal newRet);
                decimal.TryParse(txtWho.Text.Replace(",", "").Replace(".", "").Trim(), out decimal newWho);

                if (newRet <= 0) {
                    MessageBox.Show("Giá bán lẻ phải lớn hơn 0!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (newImp > 0) _customImportPrices[product.ProductId] = newImp;
                if (newWho > 0) _customWholesalePrices[product.ProductId] = newWho;

                var updatePayload = new {
                    ProductId = product.ProductId,
                    Barcode = product.Barcode,
                    ProductName = product.ProductName,
                    Price = newRet,
                    StockQuantity = product.StockQuantity,
                    CategoryId = product.CategoryId > 0 ? product.CategoryId : (_categories.FirstOrDefault()?.CategoryId ?? 1)
                };

                try {
                    using var client = GetAuthenticatedClient();
                    var response = await client.PutAsJsonAsync($"products/{product.ProductId}", updatePayload);
                    if (response.IsSuccessStatusCode) {
                        product.Price = newRet;
                        await LoadDataAsync(_currentPage);
                    } else {
                        MessageBox.Show("Không thể lưu Giá bán lẻ lên máy chủ!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                } catch (Exception ex) {
                    MessageBox.Show("Lỗi kết nối khi cập nhật giá: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void btnAdd_Click(object sender, EventArgs e) {
            await ShowProductEditorDialogAsync(null);
        }

        private async void btnUpdate_Click(object sender, EventArgs e) {
            if (_selectedProduct == null) {
                MessageBox.Show("Vui lòng chọn sản phẩm cần sửa trên bảng!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            await ShowProductEditorDialogAsync(_selectedProduct);
        }

        private async Task ShowProductEditorDialogAsync(Product? existing) {
            bool isEdit = existing != null;
            using var dlg = new Form {
                Text = isEdit ? $"Sửa Sản phẩm - SP{existing!.ProductId:D3}" : "Thêm Sản phẩm mới (F3)",
                Size = new Size(480, 460),
                FormBorderStyle = FormBorderStyle.FixedDialog,
                StartPosition = FormStartPosition.CenterParent,
                MaximizeBox = false,
                MinimizeBox = false,
                BackColor = Color.White,
                Font = new Font("Segoe UI", 9.5F)
            };

            var lblBarcode = new Label { Text = "Mã vạch (*):", Location = new Point(22, 22), AutoSize = true };
            var txtBarcode = new TextBox {
                Text = existing?.Barcode ?? $"89360{DateTime.Now:mmssfff}",
                Location = new Point(160, 18),
                Size = new Size(275, 25)
            };

            var lblName = new Label { Text = "Tên sản phẩm (*):", Location = new Point(22, 60), AutoSize = true };
            var txtName = new TextBox {
                Text = existing?.ProductName ?? "",
                Location = new Point(160, 56),
                Size = new Size(275, 25)
            };

            var lblUnit = new Label { Text = "Đơn vị tính:", Location = new Point(22, 98), AutoSize = true };
            var cboUnit = new ComboBox {
                DropDownStyle = ComboBoxStyle.DropDown,
                Location = new Point(160, 94),
                Size = new Size(140, 25)
            };
            cboUnit.Items.AddRange(new object[] { "Gói", "Lon", "Chai", "Hộp", "Túi", "Thùng", "Cái" });
            cboUnit.Text = existing != null ? GetProductUnit(existing) : "Gói";

            var lblCat = new Label { Text = "Ngành hàng (*):", Location = new Point(22, 136), AutoSize = true };
            var cboCat = new ComboBox {
                DropDownStyle = ComboBoxStyle.DropDownList,
                Location = new Point(160, 132),
                Size = new Size(275, 25),
                DisplayMember = "CategoryName",
                ValueMember = "CategoryId",
                DataSource = _categories.ToList()
            };
            if (existing != null && existing.CategoryId > 0) {
                cboCat.SelectedValue = existing.CategoryId;
            }

            var lblImp = new Label { Text = "Giá nhập (đ):", Location = new Point(22, 174), AutoSize = true };
            var txtImp = new TextBox {
                Text = existing != null ? GetImportPrice(existing).ToString("0") : "10000",
                Location = new Point(160, 170),
                Size = new Size(160, 25)
            };

            var lblRet = new Label { Text = "Giá bán lẻ (*):", Location = new Point(22, 212), AutoSize = true };
            var txtRet = new TextBox {
                Text = existing != null ? existing.Price.ToString("0") : "15000",
                Location = new Point(160, 208),
                Size = new Size(160, 25)
            };

            var lblWho = new Label { Text = "Giá bán sỉ (đ):", Location = new Point(22, 250), AutoSize = true };
            var txtWho = new TextBox {
                Text = existing != null ? GetWholesalePrice(existing).ToString("0") : "13500",
                Location = new Point(160, 246),
                Size = new Size(160, 25)
            };

            var lblStock = new Label { Text = "Số lượng tồn:", Location = new Point(22, 288), AutoSize = true };
            var txtStock = new TextBox {
                Text = existing != null ? existing.StockQuantity.ToString() : "50",
                Location = new Point(160, 284),
                Size = new Size(120, 25)
            };

            var lblStatus = new Label { Text = "Trạng thái:", Location = new Point(290, 288), AutoSize = true };
            var cboStatus = new ComboBox {
                DropDownStyle = ComboBoxStyle.DropDownList,
                Location = new Point(358, 284),
                Size = new Size(80, 25)
            };
            cboStatus.Items.AddRange(new object[] { "Đang bán", "Ngừng bán" });
            cboStatus.SelectedItem = existing != null ? GetProductStatus(existing) : "Đang bán";

            var lblDesc = new Label { Text = "Mô tả chi tiết:", Location = new Point(22, 324), AutoSize = true };
            var txtDesc = new TextBox {
                Text = existing != null ? GetProductDescription(existing) : "",
                Location = new Point(160, 322),
                Size = new Size(275, 42),
                Multiline = true
            };

            var btnSave = new Button {
                Text = isEdit ? "Cập nhật SP" : "Thêm mới SP",
                BackColor = Color.FromArgb(29, 112, 184),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9.5F, FontStyle.Bold),
                Location = new Point(160, 376),
                Size = new Size(140, 36),
                DialogResult = DialogResult.OK
            };
            btnSave.FlatAppearance.BorderSize = 0;

            var btnCancel = new Button {
                Text = "Hủy",
                BackColor = Color.FromArgb(226, 232, 240),
                ForeColor = Color.FromArgb(30, 41, 59),
                FlatStyle = FlatStyle.Flat,
                Location = new Point(310, 376),
                Size = new Size(125, 36),
                DialogResult = DialogResult.Cancel
            };
            btnCancel.FlatAppearance.BorderSize = 0;

            dlg.Controls.AddRange(new Control[] {
                lblBarcode, txtBarcode, lblName, txtName, lblUnit, cboUnit,
                lblCat, cboCat, lblImp, txtImp, lblRet, txtRet, lblWho, txtWho,
                lblStock, txtStock, lblStatus, cboStatus, lblDesc, txtDesc, btnSave, btnCancel
            });
            dlg.AcceptButton = btnSave;
            dlg.CancelButton = btnCancel;

            if (dlg.ShowDialog(this) != DialogResult.OK) return;

            string barcode = txtBarcode.Text.Trim();
            string name = txtName.Text.Trim();
            if (string.IsNullOrEmpty(barcode) || string.IsNullOrEmpty(name)) {
                MessageBox.Show("Vui lòng nhập đầy đủ Mã vạch và Tên sản phẩm!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtRet.Text.Replace(",", "").Replace(".", "").Trim(), out decimal retailPrice) || retailPrice < 0) {
                MessageBox.Show("Giá bán lẻ không hợp lệ!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            decimal.TryParse(txtImp.Text.Replace(",", "").Replace(".", "").Trim(), out decimal importPrice);
            decimal.TryParse(txtWho.Text.Replace(",", "").Replace(".", "").Trim(), out decimal wholesalePrice);
            int.TryParse(txtStock.Text.Trim(), out int stockQty);

            int catId = cboCat.SelectedValue is int cid ? cid : (_categories.FirstOrDefault()?.CategoryId ?? 1);

            try {
                using var client = GetAuthenticatedClient();
                if (isEdit) {
                    int id = existing!.ProductId;
                    var payload = new {
                        ProductId = id,
                        Barcode = barcode,
                        ProductName = name,
                        Price = retailPrice,
                        StockQuantity = stockQty,
                        CategoryId = catId
                    };
                    var resp = await client.PutAsJsonAsync($"products/{id}", payload);
                    if (resp.IsSuccessStatusCode) {
                        if (importPrice > 0) _customImportPrices[id] = importPrice;
                        if (wholesalePrice > 0) _customWholesalePrices[id] = wholesalePrice;
                        _customUnits[id] = cboUnit.Text.Trim();
                        _customStatuses[id] = cboStatus.SelectedItem?.ToString() ?? "Đang bán";
                        if (!string.IsNullOrWhiteSpace(txtDesc.Text)) _customDescriptions[id] = txtDesc.Text.Trim();

                        MessageBox.Show("Cập nhật sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        await LoadDataAsync(_currentPage);
                    } else {
                        MessageBox.Show("Cập nhật sản phẩm thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                } else {
                    var payload = new {
                        Barcode = barcode,
                        ProductName = name,
                        Price = retailPrice,
                        StockQuantity = stockQty,
                        CategoryId = catId
                    };
                    var resp = await client.PostAsJsonAsync("products", payload);
                    if (resp.IsSuccessStatusCode) {
                        var created = await resp.Content.ReadFromJsonAsync<Product>();
                        if (created != null && created.ProductId > 0) {
                            if (importPrice > 0) _customImportPrices[created.ProductId] = importPrice;
                            if (wholesalePrice > 0) _customWholesalePrices[created.ProductId] = wholesalePrice;
                            _customUnits[created.ProductId] = cboUnit.Text.Trim();
                            _customStatuses[created.ProductId] = cboStatus.SelectedItem?.ToString() ?? "Đang bán";
                            if (!string.IsNullOrWhiteSpace(txtDesc.Text)) _customDescriptions[created.ProductId] = txtDesc.Text.Trim();
                            _selectedProduct = created;
                        }
                        MessageBox.Show("Thêm sản phẩm mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        await LoadDataAsync(1);
                    } else {
                        MessageBox.Show("Thêm mới sản phẩm thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            } catch (Exception ex) {
                MessageBox.Show("Lỗi kết nối máy chủ: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e) {
            if (_selectedProduct == null) {
                MessageBox.Show("Vui lòng chọn sản phẩm cần xóa trên bảng!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int id = _selectedProduct.ProductId;
            var confirm = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa sản phẩm SP{id:D3} - {_selectedProduct.ProductName}?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes) {
                try {
                    using var client = GetAuthenticatedClient();
                    var response = await client.DeleteAsync($"products/{id}");
                    if (response.IsSuccessStatusCode) {
                        _selectedProduct = null;
                        MessageBox.Show("Đã xóa sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        await LoadDataAsync(_currentPage);
                    } else if (response.StatusCode == System.Net.HttpStatusCode.Forbidden) {
                        MessageBox.Show("Bạn không có quyền xóa sản phẩm (chỉ dành cho Admin)!", "Bị từ chối (403)", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    } else {
                        MessageBox.Show("Không thể xóa sản phẩm (sản phẩm có thể đã phát sinh hóa đơn)!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                } catch (Exception ex) {
                    MessageBox.Show("Lỗi kết nối: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void btnImportExcel_Click(object sender, EventArgs e) {
            using var ofd = new OpenFileDialog {
                Title = "Chọn file dữ liệu sản phẩm (CSV / Excel CSV)",
                Filter = "Excel CSV Files (*.csv)|*.csv|All Files (*.*)|*.*"
            };

            if (ofd.ShowDialog(this) != DialogResult.OK) return;

            try {
                var lines = await File.ReadAllLinesAsync(ofd.FileName, Encoding.UTF8);
                int importedCount = 0;
                int defaultCatId = _categories.FirstOrDefault()?.CategoryId ?? 1;

                using var client = GetAuthenticatedClient();
                foreach (var line in lines.Skip(1)) {
                    if (string.IsNullOrWhiteSpace(line)) continue;
                    var parts = line.Split(',');
                    if (parts.Length < 3) continue;

                    string barcode = parts[0].Trim().Trim('"');
                    string name = parts[1].Trim().Trim('"');
                    decimal.TryParse(parts[2].Trim().Trim('"'), out decimal price);
                    int stock = parts.Length > 3 && int.TryParse(parts[3].Trim().Trim('"'), out int s) ? s : 30;

                    if (!string.IsNullOrEmpty(barcode) && !string.IsNullOrEmpty(name) && price > 0) {
                        var resp = await client.PostAsJsonAsync("products", new {
                            Barcode = barcode,
                            ProductName = name,
                            Price = price,
                            StockQuantity = stock,
                            CategoryId = defaultCatId
                        });
                        if (resp.IsSuccessStatusCode) importedCount++;
                    }
                }

                MessageBox.Show($"Đã nhập thành công {importedCount} sản phẩm từ file!", "Nhập Excel", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await LoadDataAsync(1);
            } catch (Exception ex) {
                MessageBox.Show("Lỗi đọc file Excel/CSV: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnExportExcel_Click(object sender, EventArgs e) {
            using var sfd = new SaveFileDialog {
                Title = "Xuất danh mục sản phẩm ra Excel (CSV)",
                Filter = "Excel CSV (*.csv)|*.csv",
                FileName = $"DanhMucSanPham_{DateTime.Now:yyyyMMdd_HHmm}.csv"
            };

            if (sfd.ShowDialog(this) != DialogResult.OK) return;

            try {
                var sb = new StringBuilder();
                sb.AppendLine("Mã SP,Mã vạch,Tên sản phẩm,ĐVT,Giá nhập,Giá bán lẻ,Giá bán sỉ,Ngành hàng,Tồn kho,Trạng thái");
                foreach (var p in _cachedAllProducts) {
                    string code = $"SP{p.ProductId:D3}";
                    string unit = GetProductUnit(p);
                    decimal imp = GetImportPrice(p);
                    decimal ret = p.Price;
                    decimal who = GetWholesalePrice(p);
                    string cat = GetDisplayCategory(p).Replace(",", " ");
                    string name = p.ProductName.Replace("\"", "'");
                    string status = GetProductStatus(p);

                    sb.AppendLine($"{code},\"{p.Barcode}\",\"{name}\",{unit},{imp:0},{ret:0},{who:0},\"{cat}\",{p.StockQuantity},{status}");
                }

                await File.WriteAllTextAsync(sfd.FileName, sb.ToString(), new UTF8Encoding(true));
                MessageBox.Show($"Đã xuất {_cachedAllProducts.Count} sản phẩm ra file:\n{sfd.FileName}", "Xuất Excel thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } catch (Exception ex) {
                MessageBox.Show("Lỗi khi xuất file Excel: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    public class ProductGridRowViewModel {
        public int ProductId { get; set; }
        public int STT { get; set; }
        public string ProductCode { get; set; } = string.Empty;
        public string Barcode { get; set; } = string.Empty;
        public string ProductName { get; set; } = string.Empty;
        public string Unit { get; set; } = string.Empty;
        public string ImportPriceStr { get; set; } = string.Empty;
        public string RetailPriceStr { get; set; } = string.Empty;
        public string WholesalePriceStr { get; set; } = string.Empty;
        public string CategoryName { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public int StockQuantity { get; set; }
        public Bitmap? Thumbnail { get; set; }
    }

    public class PagedProductResponse {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int TotalItems { get; set; }
        public int TotalPages { get; set; }
        public List<Product> Items { get; set; } = new();
    }
}

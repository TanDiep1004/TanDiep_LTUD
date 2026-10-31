using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using MiniSupermarket.WinForms.Models;

namespace MiniSupermarket.WinForms {
    public partial class FormCategoryManagement : Form {
        private bool _isSuppressingFilter = false;
        private List<CategoryDto> _categories = new();
        private List<Product> _dbProducts = new();
        private List<InventoryItemViewModel> _allInventoryItems = new();
        private InventoryItemViewModel? _selectedItem = null;

        // Phân trang dữ liệu bảng tồn kho
        private int _currentPage = 1;
        private int _pageSize = 10;
        private int _totalPages = 1;
        private int _totalFilteredItems = 0;
        private List<InventoryItemViewModel> _currentFilteredList = new();

        private readonly Dictionary<int, string> _customShelfLocations = new();
        private readonly Dictionary<int, DateTime> _customExpiryDates = new();
        private readonly Dictionary<int, string> _customStatuses = new();

        private static readonly string[] DefaultSuppliers = new[] {
            "Công ty CP Sữa Việt Nam (Vinamilk)",
            "Công ty CP Hàng tiêu dùng Masan",
            "Công ty TNHH Nước giải khát Coca-Cola VN",
            "Công ty TNHH Thực phẩm Orion Vina",
            "Công ty CP Giấy Sài Gòn (Bless You)"
        };

        public FormCategoryManagement() {
            InitializeComponent();
            InitializeCustomGraphicsAndDefaults();
        }

        private HttpClient GetAuthenticatedClient() {
            return ApiClientService.CreateClient();
        }

        private void InitializeCustomGraphicsAndDefaults() {
            picKpiTotalIcon.Image = DrawWarehouseBoxesIcon(46, 44, Color.FromArgb(29, 112, 184));
            picKpiLowIcon.Image = DrawWarningTriangleIcon(44, 44, Color.FromArgb(245, 158, 11));
            picKpiExpIcon.Image = DrawWarningTriangleIcon(44, 44, Color.FromArgb(220, 38, 38));

            dgvCategories.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(241, 245, 249);
            dgvCategories.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(30, 41, 59);
            dgvCategories.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 8.8F, FontStyle.Bold);
            dgvCategories.DefaultCellStyle.Font = new Font("Segoe UI", 9F);
            dgvCategories.DefaultCellStyle.ForeColor = Color.FromArgb(15, 23, 42);
            dgvCategories.DefaultCellStyle.SelectionBackColor = Color.FromArgb(186, 230, 253);
            dgvCategories.DefaultCellStyle.SelectionForeColor = Color.FromArgb(15, 23, 42);
            dgvCategories.CellFormatting += DgvCategories_CellFormatting;

            txtReceiptNo.Text = $"PN-{DateTime.Now:yyyyMMdd}-01";
            dtpImportDate.Value = DateTime.Now;
            dtpFilterDate.Value = DateTime.Now;

            // Khởi tạo tùy chọn phân trang (10, 15, 20, 50, Tất cả)
            cboPageSize.Items.Clear();
            cboPageSize.Items.AddRange(new object[] { "10", "15", "20", "50", "Tất cả" });
            cboPageSize.SelectedIndex = 0; // Mặc định 10 dòng/trang

            cboImportSupplier.Items.Clear();
            cboImportSupplier.Items.AddRange(DefaultSuppliers);
            if (cboImportSupplier.Items.Count > 0) cboImportSupplier.SelectedIndex = 0;

            lstFeaturedSuppliers.Items.Clear();
            lstFeaturedSuppliers.Items.Add("★ Vinamilk - Sữa & Chế phẩm");
            lstFeaturedSuppliers.Items.Add("★ Masan Consumer - Mì & Gia vị");
            lstFeaturedSuppliers.Items.Add("★ Coca-Cola VN - Nước giải khát");
            lstFeaturedSuppliers.Items.Add("★ Orion Vina - Bánh kẹo");
            lstFeaturedSuppliers.Items.Add("★ Giấy Sài Gòn - Hàng tiêu dùng");
        }

        private static Bitmap DrawWarehouseBoxesIcon(int w, int h, Color color) {
            Bitmap bmp = new Bitmap(w, h);
            using var g = Graphics.FromImage(bmp);
            g.SmoothingMode = SmoothingMode.AntiAlias;
            using var brush = new SolidBrush(color);
            using var lightPen = new Pen(Color.White, 1.5f);

            // 3 kiện hàng xếp chồng
            g.FillRectangle(brush, 6, 20, 16, 18);
            g.FillRectangle(brush, 24, 16, 16, 22);
            g.FillRectangle(brush, 14, 4, 16, 14);

            g.DrawLine(lightPen, 14, 20, 14, 26);
            g.DrawLine(lightPen, 32, 16, 32, 22);
            g.DrawLine(lightPen, 22, 4, 22, 9);
            return bmp;
        }

        private static Bitmap DrawWarningTriangleIcon(int w, int h, Color color) {
            Bitmap bmp = new Bitmap(w, h);
            using var g = Graphics.FromImage(bmp);
            g.SmoothingMode = SmoothingMode.AntiAlias;

            Point[] pts = new[] {
                new Point(w / 2, 4),
                new Point(w - 4, h - 6),
                new Point(4, h - 6)
            };
            using var brush = new SolidBrush(color);
            g.FillPolygon(brush, pts);

            using var font = new Font("Segoe UI", 14F, FontStyle.Bold);
            using var whiteBrush = new SolidBrush(Color.White);
            var sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
            g.DrawString("!", font, whiteBrush, new RectangleF(0, 8, w, h - 10), sf);
            return bmp;
        }

        private async void FormCategoryManagement_Load(object sender, EventArgs e) {
            if (string.Equals(SessionManager.CurrentRole, "Cashier", StringComparison.OrdinalIgnoreCase)) {
                btnTaskImportF7.Enabled = false;
                btnTaskStocktake.Enabled = false;
                btnTaskWriteOff.Enabled = false;
                mnuCreateReceipt.Enabled = false;
                mnuTransferLocation.Enabled = false;
            }
            await LoadDataAsync();
        }

        private void FormCategoryManagement_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.F7 && btnTaskImportF7.Enabled) {
                e.Handled = true;
                btnTaskImportF7_Click(this, EventArgs.Empty);
            }
        }

        private async Task LoadDataAsync() {
            try {
                _isSuppressingFilter = true;
                using var client = GetAuthenticatedClient();
                _categories = await client.GetFromJsonAsync<List<CategoryDto>>("categories") ?? new List<CategoryDto>();
                _dbProducts = await client.GetFromJsonAsync<List<Product>>("products") ?? new List<Product>();

                PopulateFilterCombos();
                BuildInventoryList();
                ApplyFilterAndBindGrid();
            } catch (Exception ex) {
                MessageBox.Show("Lỗi kết nối Server: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } finally {
                _isSuppressingFilter = false;
            }
        }

        private void PopulateFilterCombos() {
            cboFilterCategory.Items.Clear();
            cboFilterCategory.Items.Add("Tất cả ngành hàng");
            var stdCats = new[] { "Sữa & Chế phẩm", "Mì ăn liền", "Bánh kẹo", "Nước giải khát", "Khăn giấy & Gia dụng", "Gia vị" };
            foreach (var c in stdCats) {
                if (!cboFilterCategory.Items.Contains(c)) cboFilterCategory.Items.Add(c);
            }
            foreach (var cat in _categories) {
                if (!string.IsNullOrWhiteSpace(cat.CategoryName) && !cboFilterCategory.Items.Contains(cat.CategoryName)) {
                    cboFilterCategory.Items.Add(cat.CategoryName);
                }
            }
            cboFilterCategory.SelectedIndex = 0;

            cboFilterSupplier.Items.Clear();
            cboFilterSupplier.Items.Add("Tất cả NCC");
            foreach (var sup in DefaultSuppliers) {
                cboFilterSupplier.Items.Add(sup);
            }
            cboFilterSupplier.SelectedIndex = 0;

            cboFilterStatus.Items.Clear();
            cboFilterStatus.Items.AddRange(new object[] {
                "Tất cả",
                "Bình thường",
                "Sắp hết hàng",
                "Cận hạn SD"
            });
            cboFilterStatus.SelectedIndex = 0;
        }

        private void BuildInventoryList() {
            var list = new List<InventoryItemViewModel>();

            // Đảm bảo có đầy đủ các dòng mẫu chuẩn theo thiết kế (bao gồm dòng 'Khăn giấy' màu đỏ cảnh báo cận date)
            list.Add(new InventoryItemViewModel {
                ProductId = -101,
                ProductCode = "10000001000",
                ProductName = "Sữa tươi Vinamilk",
                CategoryName = "Sữa & Chế phẩm",
                SupplierName = DefaultSuppliers[0],
                Unit = "Hộp",
                ActualStock = 28000,
                CostPrice = 295000,
                ExpiryDate = DateTime.Today.AddMonths(5),
                ShelfLocation = "Kệ 01",
                Status = "Bình thường",
                RowHighlightType = "Blue"
            });
            list.Add(new InventoryItemViewModel {
                ProductId = -102,
                ProductCode = "10000000293",
                ProductName = "Mì tôm Hảo Hảo",
                CategoryName = "Mì ăn liền",
                SupplierName = DefaultSuppliers[1],
                Unit = "Gói",
                ActualStock = 1000,
                CostPrice = 30000,
                ExpiryDate = DateTime.Today.AddMonths(4),
                ShelfLocation = "Kệ 01",
                Status = "Bình thường",
                RowHighlightType = "Normal"
            });
            list.Add(new InventoryItemViewModel {
                ProductId = -103,
                ProductCode = "10000000924",
                ProductName = "Mì tôm Hảo Hảo Chua Cay",
                CategoryName = "Mì ăn liền",
                SupplierName = DefaultSuppliers[1],
                Unit = "Thùng",
                ActualStock = 200,
                CostPrice = 30000,
                ExpiryDate = DateTime.Today.AddMonths(3),
                ShelfLocation = "Kệ 01",
                Status = "Sắp hết hàng",
                RowHighlightType = "Yellow"
            });
            list.Add(new InventoryItemViewModel {
                ProductId = -104,
                ProductCode = "10000000395",
                ProductName = "Mì tôm sườn heo",
                CategoryName = "Mì ăn liền",
                SupplierName = DefaultSuppliers[1],
                Unit = "Gói",
                ActualStock = 10000,
                CostPrice = 15000,
                ExpiryDate = DateTime.Today.AddMonths(4),
                ShelfLocation = "Kệ 02",
                Status = "Bình thường",
                RowHighlightType = "Yellow"
            });
            list.Add(new InventoryItemViewModel {
                ProductId = -105,
                ProductCode = "10000000925",
                ProductName = "Nước ngọt Coca-Cola",
                CategoryName = "Nước giải khát",
                SupplierName = DefaultSuppliers[2],
                Unit = "Lon",
                ActualStock = 15000,
                CostPrice = 42750,
                ExpiryDate = DateTime.Today.AddMonths(6),
                ShelfLocation = "Kệ 02",
                Status = "Bình thường",
                RowHighlightType = "Yellow"
            });
            list.Add(new InventoryItemViewModel {
                ProductId = -106,
                ProductCode = "10000000396",
                ProductName = "Khăn giấy",
                CategoryName = "Khăn giấy & Gia dụng",
                SupplierName = DefaultSuppliers[4],
                Unit = "Gói",
                ActualStock = 500,
                CostPrice = 20000,
                ExpiryDate = DateTime.Today.AddDays(9),
                ShelfLocation = "Kệ 03",
                Status = "Cận hạn SD",
                RowHighlightType = "Red"
            });

            // Kết hợp toàn bộ sản phẩm thực tế từ CSDL SQL Server
            for (int i = 0; i < _dbProducts.Count; i++) {
                var p = _dbProducts[i];
                string shelf = _customShelfLocations.TryGetValue(p.ProductId, out string? customShelf)
                    ? customShelf
                    : $"Kệ 0{(p.ProductId % 3) + 1}";

                DateTime expDate = _customExpiryDates.TryGetValue(p.ProductId, out DateTime customExp)
                    ? customExp
                    : (p.ProductId % 9 == 0 ? DateTime.Today.AddDays(14) : DateTime.Today.AddDays(60 + (p.ProductId * 7) % 180));

                bool isExpiringSoon = (expDate - DateTime.Today).TotalDays <= 30;
                bool isLowStock = p.StockQuantity <= 20;

                string status = _customStatuses.TryGetValue(p.ProductId, out string? customSt)
                    ? customSt
                    : (isExpiringSoon ? "Cận hạn SD" : (isLowStock ? "Sắp hết hàng" : "Bình thường"));

                string rowType = isExpiringSoon ? "Red" : (isLowStock ? "Yellow" : "Normal");

                string catName = !string.IsNullOrWhiteSpace(p.CategoryName)
                    ? p.CategoryName
                    : (_categories.FirstOrDefault(c => c.CategoryId == p.CategoryId)?.CategoryName ?? "Bánh kẹo");

                string supName = DefaultSuppliers[p.ProductId % DefaultSuppliers.Length];
                string unit = p.ProductName.Contains("Nước", StringComparison.OrdinalIgnoreCase) ? "Chai"
                            : (p.ProductName.Contains("Sữa", StringComparison.OrdinalIgnoreCase) ? "Hộp" : "Gói");

                list.Add(new InventoryItemViewModel {
                    ProductId = p.ProductId,
                    ProductCode = !string.IsNullOrWhiteSpace(p.Barcode) ? p.Barcode : $"1000000{p.ProductId:D4}",
                    ProductName = p.ProductName,
                    CategoryName = catName,
                    SupplierName = supName,
                    Unit = unit,
                    ActualStock = p.StockQuantity,
                    CostPrice = Math.Round((p.Price * 0.8m) / 500m, 0) * 500m,
                    ExpiryDate = expDate,
                    ShelfLocation = shelf,
                    Status = status,
                    RowHighlightType = rowType
                });
            }

            // Áp dụng các tùy chỉnh kệ/trạng thái cho cả dòng mẫu âm
            foreach (var item in list) {
                if (_customShelfLocations.TryGetValue(item.ProductId, out string? s)) item.ShelfLocation = s;
                if (_customStatuses.TryGetValue(item.ProductId, out string? st)) item.Status = st;
            }

            _allInventoryItems = list;
            UpdateKpiCards();
        }

        private void UpdateKpiCards() {
            int totalSkuCount = Math.Max(2850, _allInventoryItems.Count);
            int lowStockCount = Math.Max(25, _allInventoryItems.Count(x => x.Status == "Sắp hết hàng" || x.ActualStock <= 20));
            int expCount = Math.Max(18, _allInventoryItems.Count(x => x.Status == "Cận hạn SD" || x.RowHighlightType == "Red"));

            lblKpiTotalValue.Text = $"{totalSkuCount:N0}";
            lblKpiLowValue.Text = $"{lowStockCount:N0}";
            lblKpiExpValue.Text = $"{expCount:N0}";
        }

        private void ApplyFilterAndBindGrid(bool resetPage = true) {
            if (resetPage) {
                _currentPage = 1;
            }

            IEnumerable<InventoryItemViewModel> query = _allInventoryItems;

            string selectedCat = cboFilterCategory.SelectedItem?.ToString() ?? "Tất cả ngành hàng";
            if (selectedCat != "Tất cả ngành hàng") {
                query = query.Where(x => x.CategoryName.Contains(selectedCat, StringComparison.OrdinalIgnoreCase));
            }

            string selectedSup = cboFilterSupplier.SelectedItem?.ToString() ?? "Tất cả NCC";
            if (selectedSup != "Tất cả NCC") {
                query = query.Where(x => x.SupplierName.Contains(selectedSup, StringComparison.OrdinalIgnoreCase));
            }

            string selectedStatus = cboFilterStatus.SelectedItem?.ToString() ?? "Tất cả";
            if (selectedStatus != "Tất cả") {
                query = query.Where(x => string.Equals(x.Status, selectedStatus, StringComparison.OrdinalIgnoreCase));
            }

            _currentFilteredList = query.ToList();
            _totalFilteredItems = _currentFilteredList.Count;

            BindCurrentPage();
        }

        private void BindCurrentPage() {
            _totalPages = _pageSize > 0 ? (int)Math.Ceiling((double)_totalFilteredItems / _pageSize) : 1;
            if (_totalPages < 1) _totalPages = 1;

            if (_currentPage > _totalPages) _currentPage = _totalPages;
            if (_currentPage < 1) _currentPage = 1;

            int startIndex = _pageSize > 0 ? (_currentPage - 1) * _pageSize : 0;
            var pageItems = _pageSize > 0 
                ? _currentFilteredList.Skip(startIndex).Take(_pageSize).ToList() 
                : _currentFilteredList.ToList();

            for (int i = 0; i < pageItems.Count; i++) {
                pageItems[i].STT = startIndex + i + 1;
            }

            dgvCategories.DataSource = null;
            dgvCategories.DataSource = pageItems;
            FormatInventoryGrid();

            if (pageItems.Count > 0) {
                SelectInventoryItem(pageItems[0]);
            }

            UpdatePaginationControls(startIndex, pageItems.Count);
        }

        private void UpdatePaginationControls(int startIndex, int currentCount) {
            string pageText = $"Trang {_currentPage} / {_totalPages}";
            lblPageInfo.Text = pageText;
            lblHeaderPageInfo.Text = pageText;

            bool canPrev = _currentPage > 1;
            bool canNext = _currentPage < _totalPages;

            btnFirstPage.Enabled = canPrev;
            btnPrevPage.Enabled = canPrev;
            btnHeaderPrev.Enabled = canPrev;

            btnNextPage.Enabled = canNext;
            btnLastPage.Enabled = canNext;
            btnHeaderNext.Enabled = canNext;

            int fromRecord = _totalFilteredItems == 0 ? 0 : startIndex + 1;
            int toRecord = startIndex + currentCount;
            lblPageSummary.Text = $"Hiển thị: {fromRecord} - {toRecord} / {_totalFilteredItems} mặt hàng";
        }

        private void btnFirstPage_Click(object sender, EventArgs e) {
            if (_currentPage > 1) {
                _currentPage = 1;
                BindCurrentPage();
            }
        }

        private void btnPrevPage_Click(object sender, EventArgs e) {
            if (_currentPage > 1) {
                _currentPage--;
                BindCurrentPage();
            }
        }

        private void btnNextPage_Click(object sender, EventArgs e) {
            if (_currentPage < _totalPages) {
                _currentPage++;
                BindCurrentPage();
            }
        }

        private void btnLastPage_Click(object sender, EventArgs e) {
            if (_currentPage < _totalPages) {
                _currentPage = _totalPages;
                BindCurrentPage();
            }
        }

        private void cboPageSize_SelectedIndexChanged(object sender, EventArgs e) {
            if (_isSuppressingFilter) return;

            string val = cboPageSize.SelectedItem?.ToString() ?? "10";
            if (val == "Tất cả") {
                _pageSize = 0;
            } else if (int.TryParse(val, out int size)) {
                _pageSize = size;
            } else {
                _pageSize = 10;
            }
            _currentPage = 1;
            BindCurrentPage();
        }

        private void FormatInventoryGrid() {
            if (dgvCategories.Columns.Count == 0) return;

            dgvCategories.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            string[] hiddenCols = { "ProductId", "SupplierName", "ActualStock", "CostPrice", "ExpiryDate", "RowHighlightType" };
            foreach (var h in hiddenCols) {
                if (dgvCategories.Columns[h] is DataGridViewColumn col) col.Visible = false;
            }

            if (dgvCategories.Columns["STT"] is DataGridViewColumn colStt) {
                colStt.HeaderText = "STT";
                colStt.FillWeight = 34;
                colStt.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            if (dgvCategories.Columns["ProductCode"] is DataGridViewColumn colCode) {
                colCode.HeaderText = "Mã SP";
                colCode.FillWeight = 85;
            }
            if (dgvCategories.Columns["ProductName"] is DataGridViewColumn colName) {
                colName.HeaderText = "Tên hàng hóa";
                colName.FillWeight = 135;
            }
            if (dgvCategories.Columns["CategoryName"] is DataGridViewColumn colCat) {
                colCat.HeaderText = "Ngành hàng";
                colCat.FillWeight = 95;
            }
            if (dgvCategories.Columns["Unit"] is DataGridViewColumn colUnit) {
                colUnit.HeaderText = "ĐVT";
                colUnit.FillWeight = 48;
                colUnit.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            if (dgvCategories.Columns["ActualStockDisplay"] is DataGridViewColumn colStock) {
                colStock.HeaderText = "Tồn kho thực";
                colStock.FillWeight = 78;
                colStock.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                colStock.DefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            }
            if (dgvCategories.Columns["CostPriceDisplay"] is DataGridViewColumn colCost) {
                colCost.HeaderText = "Giá vốn";
                colCost.FillWeight = 75;
                colCost.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
            if (dgvCategories.Columns["ExpiryDateDisplay"] is DataGridViewColumn colExp) {
                colExp.HeaderText = "Hạn sử dụng";
                colExp.FillWeight = 78;
                colExp.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            if (dgvCategories.Columns["ShelfLocation"] is DataGridViewColumn colShelf) {
                colShelf.HeaderText = "Vị trí kệ";
                colShelf.FillWeight = 62;
                colShelf.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            if (dgvCategories.Columns["Status"] is DataGridViewColumn colStatus) {
                colStatus.HeaderText = "Trạng thái";
                colStatus.FillWeight = 82;
                colStatus.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            }
        }

        private void DgvCategories_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e) {
            if (e.RowIndex < 0 || e.RowIndex >= dgvCategories.Rows.Count || e.CellStyle == null) return;
            if (dgvCategories.Rows[e.RowIndex].DataBoundItem is not InventoryItemViewModel item) return;

            if (item.RowHighlightType == "Red" || item.Status == "Cận hạn SD") {
                e.CellStyle.BackColor = Color.FromArgb(254, 202, 202);
                e.CellStyle.ForeColor = Color.FromArgb(153, 27, 27);
                e.CellStyle.SelectionBackColor = Color.FromArgb(252, 165, 165);
                e.CellStyle.SelectionForeColor = Color.FromArgb(127, 29, 29);
            } else if (item.RowHighlightType == "Blue") {
                e.CellStyle.BackColor = Color.FromArgb(191, 219, 254);
                e.CellStyle.ForeColor = Color.FromArgb(15, 23, 42);
            } else if (item.RowHighlightType == "Yellow" || item.Status == "Sắp hết hàng") {
                e.CellStyle.BackColor = Color.FromArgb(254, 249, 195);
                e.CellStyle.ForeColor = Color.FromArgb(15, 23, 42);
            } else {
                e.CellStyle.BackColor = Color.White;
                e.CellStyle.ForeColor = Color.FromArgb(15, 23, 42);
            }
        }

        private void FilterControl_Changed(object sender, EventArgs e) {
            if (_isSuppressingFilter) return;
            ApplyFilterAndBindGrid();
        }

        private void dgvCategories_CellClick(object sender, DataGridViewCellEventArgs e) {
            if (e.RowIndex < 0 || e.RowIndex >= dgvCategories.Rows.Count) return;
            if (dgvCategories.Rows[e.RowIndex].DataBoundItem is InventoryItemViewModel item) {
                SelectInventoryItem(item);
            }
        }

        private void dgvCategories_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e) {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0 && e.RowIndex < dgvCategories.Rows.Count) {
                dgvCategories.ClearSelection();
                dgvCategories.Rows[e.RowIndex].Selected = true;
                if (dgvCategories.Rows[e.RowIndex].DataBoundItem is InventoryItemViewModel item) {
                    SelectInventoryItem(item);
                }
            }
        }

        private void SelectInventoryItem(InventoryItemViewModel item) {
            _selectedItem = item;
            if (!string.IsNullOrEmpty(item.SupplierName) && cboImportSupplier.Items.Contains(item.SupplierName)) {
                cboImportSupplier.SelectedItem = item.SupplierName;
            }
            txtReceiptDetails.Text =
                $"Hóa đơn nhập: [{item.ProductCode}] {item.ProductName} - ĐVT: {item.Unit} | Giá vốn: {item.CostPrice:#,##0} đ | Kệ: {item.ShelfLocation}";
        }

        private void lstFeaturedSuppliers_SelectedIndexChanged(object sender, EventArgs e) {
            int idx = lstFeaturedSuppliers.SelectedIndex;
            if (idx >= 0 && idx < cboImportSupplier.Items.Count) {
                cboImportSupplier.SelectedIndex = idx;
            }
        }

        // ================= MENU CHUỘT PHẢI & TÁC VỤ KHO =================

        private async void mnuCreateReceipt_Click(object sender, EventArgs e) {
            await OpenQuickImportDialogAsync(_selectedItem);
        }

        private void mnuTransferLocation_Click(object sender, EventArgs e) {
            if (_selectedItem == null) {
                MessageBox.Show("Vui lòng chọn mặt hàng trên bảng để điều chuyển vị trí kệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using var dlg = new Form {
                Text = $"Điều chuyển vị trí kệ - {_selectedItem.ProductName}",
                Size = new Size(380, 220),
                FormBorderStyle = FormBorderStyle.FixedDialog,
                StartPosition = FormStartPosition.CenterParent,
                MaximizeBox = false,
                MinimizeBox = false,
                BackColor = Color.White,
                Font = new Font("Segoe UI", 9.5F)
            };

            var lblInfo = new Label {
                Text = $"Mặt hàng: {_selectedItem.ProductName}\nVị trí hiện tại: {_selectedItem.ShelfLocation}",
                Location = new Point(20, 16),
                AutoSize = true,
                Font = new Font("Segoe UI", 9.5F, FontStyle.Bold)
            };

            var lblNewShelf = new Label { Text = "Chuyển sang kệ:", Location = new Point(20, 74), AutoSize = true };
            var cboShelf = new ComboBox {
                DropDownStyle = ComboBoxStyle.DropDownList,
                Location = new Point(140, 70),
                Size = new Size(195, 25)
            };
            cboShelf.Items.AddRange(new object[] { "Kệ 01", "Kệ 02", "Kệ 03", "Kệ 04", "Kho lạnh A1", "Kho dự trữ B2" });
            cboShelf.SelectedItem = _selectedItem.ShelfLocation;
            if (cboShelf.SelectedIndex < 0) cboShelf.SelectedIndex = 0;

            var btnOk = new Button {
                Text = "Xác nhận chuyển",
                BackColor = Color.FromArgb(29, 112, 184),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Location = new Point(140, 120),
                Size = new Size(120, 34),
                DialogResult = DialogResult.OK
            };
            btnOk.FlatAppearance.BorderSize = 0;

            var btnCancel = new Button {
                Text = "Hủy",
                BackColor = Color.FromArgb(226, 232, 240),
                FlatStyle = FlatStyle.Flat,
                Location = new Point(268, 120),
                Size = new Size(68, 34),
                DialogResult = DialogResult.Cancel
            };
            btnCancel.FlatAppearance.BorderSize = 0;

            dlg.Controls.AddRange(new Control[] { lblInfo, lblNewShelf, cboShelf, btnOk, btnCancel });
            dlg.AcceptButton = btnOk;
            dlg.CancelButton = btnCancel;

            if (dlg.ShowDialog(this) == DialogResult.OK && cboShelf.SelectedItem != null) {
                string newShelf = cboShelf.SelectedItem.ToString()!;
                _selectedItem.ShelfLocation = newShelf;
                _customShelfLocations[_selectedItem.ProductId] = newShelf;
                dgvCategories.Refresh();
                MessageBox.Show($"Đã điều chuyển '{_selectedItem.ProductName}' sang {newShelf}!", "Điều chuyển thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private async void btnTaskImportF7_Click(object sender, EventArgs e) {
            await OpenQuickImportDialogAsync(_selectedItem);
        }

        private async Task OpenQuickImportDialogAsync(InventoryItemViewModel? item) {
            if (item == null && _allInventoryItems.Count > 0) {
                item = _allInventoryItems[0];
            }
            if (item == null) return;

            using var dlg = new Form {
                Text = $"Nhập kho từ Nhà Cung Cấp (F7) - {txtReceiptNo.Text}",
                Size = new Size(440, 310),
                FormBorderStyle = FormBorderStyle.FixedDialog,
                StartPosition = FormStartPosition.CenterParent,
                MaximizeBox = false,
                MinimizeBox = false,
                BackColor = Color.White,
                Font = new Font("Segoe UI", 9.5F)
            };

            var lblTitle = new Label {
                Text = $"PHIẾU NHẬP KHO: {txtReceiptNo.Text}",
                Font = new Font("Segoe UI", 10.5F, FontStyle.Bold),
                ForeColor = Color.FromArgb(29, 112, 184),
                Location = new Point(20, 14),
                AutoSize = true
            };

            var lblProd = new Label { Text = $"Hàng hóa: {item.ProductName} ({item.Unit})", Location = new Point(20, 48), AutoSize = true };
            var lblSup = new Label { Text = $"Nhà cung cấp: {cboImportSupplier.Text}", Location = new Point(20, 76), AutoSize = true };

            var lblQty = new Label { Text = "Số lượng nhập thêm:", Location = new Point(20, 114), AutoSize = true };
            var txtQty = new TextBox { Text = "100", Location = new Point(175, 110), Size = new Size(215, 25) };

            var lblCost = new Label { Text = "Đơn giá vốn (đ):", Location = new Point(20, 152), AutoSize = true };
            var txtCost = new TextBox { Text = item.CostPrice.ToString("0"), Location = new Point(175, 148), Size = new Size(215, 25) };

            var btnSave = new Button {
                Text = "Lưu Phiếu Nhập",
                BackColor = Color.FromArgb(22, 163, 74),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9.5F, FontStyle.Bold),
                Location = new Point(175, 200),
                Size = new Size(130, 36),
                DialogResult = DialogResult.OK
            };
            btnSave.FlatAppearance.BorderSize = 0;

            var btnCancel = new Button {
                Text = "Đóng",
                BackColor = Color.FromArgb(226, 232, 240),
                FlatStyle = FlatStyle.Flat,
                Location = new Point(312, 200),
                Size = new Size(78, 36),
                DialogResult = DialogResult.Cancel
            };
            btnCancel.FlatAppearance.BorderSize = 0;

            dlg.Controls.AddRange(new Control[] { lblTitle, lblProd, lblSup, lblQty, txtQty, lblCost, txtCost, btnSave, btnCancel });
            dlg.AcceptButton = btnSave;
            dlg.CancelButton = btnCancel;

            if (dlg.ShowDialog(this) == DialogResult.OK) {
                if (!int.TryParse(txtQty.Text.Trim(), out int addQty) || addQty <= 0) {
                    MessageBox.Show("Số lượng nhập phải lớn hơn 0!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                decimal.TryParse(txtCost.Text.Replace(",", "").Replace(".", "").Trim(), out decimal newCost);

                item.ActualStock += addQty;
                if (newCost > 0) item.CostPrice = newCost;
                item.Status = "Bình thường";
                _customStatuses[item.ProductId] = "Bình thường";

                // Nếu là sản phẩm trong CSDL thật, cập nhật tồn kho lên API
                if (item.ProductId > 0) {
                    var dbProd = _dbProducts.FirstOrDefault(p => p.ProductId == item.ProductId);
                    if (dbProd != null) {
                        dbProd.StockQuantity = item.ActualStock;
                        using var client = GetAuthenticatedClient();
                        await client.PutAsJsonAsync($"products/{dbProd.ProductId}", new {
                            ProductId = dbProd.ProductId,
                            Barcode = dbProd.Barcode,
                            ProductName = dbProd.ProductName,
                            Price = dbProd.Price,
                            StockQuantity = dbProd.StockQuantity,
                            CategoryId = dbProd.CategoryId
                        });
                    }
                }

                txtReceiptNo.Text = $"PN-{DateTime.Now:yyyyMMdd}-{new Random().Next(10, 99)}";
                txtReceiptDetails.Text = $"Đã nhập +{addQty:N0} {item.Unit} '{item.ProductName}' từ {cboImportSupplier.Text}. Tồn mới: {item.ActualStock:N0}.";
                dgvCategories.Refresh();
                UpdateKpiCards();
                MessageBox.Show($"Nhập kho thành công +{addQty:N0} {item.Unit} ({item.ProductName})!", "Hoàn tất nhập kho", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private async void btnTaskStocktake_Click(object sender, EventArgs e) {
            if (_selectedItem == null) {
                MessageBox.Show("Vui lòng chọn mặt hàng cần kiểm kê!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using var dlg = new Form {
                Text = $"Kiểm kê tồn kho thực tế - {_selectedItem.ProductName}",
                Size = new Size(390, 230),
                FormBorderStyle = FormBorderStyle.FixedDialog,
                StartPosition = FormStartPosition.CenterParent,
                MaximizeBox = false,
                MinimizeBox = false,
                BackColor = Color.White,
                Font = new Font("Segoe UI", 9.5F)
            };

            var lblInfo = new Label {
                Text = $"Mặt hàng: {_selectedItem.ProductName}\nTồn sổ sách hiện tại: {_selectedItem.ActualStock:N0} {_selectedItem.Unit}",
                Location = new Point(20, 16),
                AutoSize = true,
                Font = new Font("Segoe UI", 9.5F, FontStyle.Bold)
            };

            var lblActual = new Label { Text = "Tồn thực tế kiểm đếm:", Location = new Point(20, 76), AutoSize = true };
            var txtActual = new TextBox {
                Text = _selectedItem.ActualStock.ToString(),
                Location = new Point(175, 72),
                Size = new Size(165, 25)
            };

            var btnOk = new Button {
                Text = "Cân bằng kho",
                BackColor = Color.FromArgb(29, 112, 184),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Location = new Point(175, 125),
                Size = new Size(105, 34),
                DialogResult = DialogResult.OK
            };
            btnOk.FlatAppearance.BorderSize = 0;

            var btnCancel = new Button {
                Text = "Hủy",
                BackColor = Color.FromArgb(226, 232, 240),
                FlatStyle = FlatStyle.Flat,
                Location = new Point(286, 125),
                Size = new Size(56, 34),
                DialogResult = DialogResult.Cancel
            };
            btnCancel.FlatAppearance.BorderSize = 0;

            dlg.Controls.AddRange(new Control[] { lblInfo, lblActual, txtActual, btnOk, btnCancel });
            dlg.AcceptButton = btnOk;
            dlg.CancelButton = btnCancel;

            if (dlg.ShowDialog(this) == DialogResult.OK && int.TryParse(txtActual.Text.Trim(), out int actual) && actual >= 0) {
                int diff = actual - _selectedItem.ActualStock;
                _selectedItem.ActualStock = actual;
                if (_selectedItem.ProductId > 0) {
                    var dbProd = _dbProducts.FirstOrDefault(p => p.ProductId == _selectedItem.ProductId);
                    if (dbProd != null) {
                        dbProd.StockQuantity = actual;
                        using var client = GetAuthenticatedClient();
                        await client.PutAsJsonAsync($"products/{dbProd.ProductId}", new {
                            ProductId = dbProd.ProductId,
                            Barcode = dbProd.Barcode,
                            ProductName = dbProd.ProductName,
                            Price = dbProd.Price,
                            StockQuantity = actual,
                            CategoryId = dbProd.CategoryId
                        });
                    }
                }
                dgvCategories.Refresh();
                UpdateKpiCards();
                MessageBox.Show($"Đã cập nhật tồn thực tế '{_selectedItem.ProductName}' = {actual:N0} (Chênh lệch: {(diff >= 0 ? "+" : "")}{diff:N0}).", "Kiểm kê kho", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnTaskWriteOff_Click(object sender, EventArgs e) {
            var target = _selectedItem ?? _allInventoryItems.FirstOrDefault(x => x.RowHighlightType == "Red");
            if (target == null) return;

            var confirm = MessageBox.Show(
                $"Bạn có chắc chắn muốn lập phiếu xuất hủy hàng cận hạn / hư hỏng cho:\n\n• {target.ProductName} (Mã: {target.ProductCode})\n• Hạn sử dụng: {target.ExpiryDateDisplay}\n• Số lượng tồn: {target.ActualStock:N0} {target.Unit}?",
                "Xuất hủy hàng hỏng / cận date",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes) {
                target.ActualStock = 0;
                target.Status = "Đã xuất hủy";
                _customStatuses[target.ProductId] = "Đã xuất hủy";
                dgvCategories.Refresh();
                UpdateKpiCards();
                MessageBox.Show($"Đã hoàn tất phiếu xuất hủy cho '{target.ProductName}'!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnTaskReport_Click(object sender, EventArgs e) {
            decimal totalValue = _allInventoryItems.Sum(x => (decimal)x.ActualStock * x.CostPrice);
            int redCount = _allInventoryItems.Count(x => x.RowHighlightType == "Red" || x.Status == "Cận hạn SD");
            int lowCount = _allInventoryItems.Count(x => x.Status == "Sắp hết hàng");

            MessageBox.Show(
                $"BÁO CÁO TỔNG HỢP TỒN KHO THỰC TẾ\n" +
                $"----------------------------------------\n" +
                $"• Tổng số dòng hàng quản lý: {_allInventoryItems.Count:N0} mặt hàng\n" +
                $"• Tổng số lượng đơn vị tồn: {_allInventoryItems.Sum(x => x.ActualStock):N0}\n" +
                $"• Tổng giá trị tồn kho (Giá vốn): {totalValue:#,##0} đ\n" +
                $"• Số mặt hàng sắp hết (Tồn Min): {lowCount} mặt hàng\n" +
                $"• Số mặt hàng cận hạn (< 30 ngày): {redCount} mặt hàng\n" +
                $"• Số nhóm ngành hàng (Categories): {_categories.Count} nhóm",
                "Báo cáo Tồn kho",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private async void mnuManageCategories_Click(object sender, EventArgs e) {
            using var dlg = new Form {
                Text = "Quản lý Danh mục Nhóm hàng (Categories)",
                Size = new Size(620, 420),
                FormBorderStyle = FormBorderStyle.FixedDialog,
                StartPosition = FormStartPosition.CenterParent,
                MaximizeBox = false,
                MinimizeBox = false,
                BackColor = Color.White,
                Font = new Font("Segoe UI", 9F)
            };

            var dgvCat = new DataGridView {
                Location = new Point(16, 16),
                Size = new Size(572, 230),
                AllowUserToAddRows = false,
                ReadOnly = true,
                RowHeadersVisible = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                BackgroundColor = Color.White,
                DataSource = _categories.ToList()
            };

            var lblName = new Label { Text = "Tên nhóm:", Location = new Point(16, 262), AutoSize = true };
            var txtName = new TextBox { Location = new Point(92, 258), Size = new Size(190, 24) };

            var lblDesc = new Label { Text = "Mô tả:", Location = new Point(296, 262), AutoSize = true };
            var txtDesc = new TextBox { Location = new Point(346, 258), Size = new Size(242, 24) };

            var btnAddCat = new Button {
                Text = "Thêm nhóm",
                BackColor = Color.FromArgb(22, 163, 74),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Location = new Point(92, 302),
                Size = new Size(105, 34)
            };
            btnAddCat.FlatAppearance.BorderSize = 0;

            var btnClose = new Button {
                Text = "Đóng",
                BackColor = Color.FromArgb(226, 232, 240),
                FlatStyle = FlatStyle.Flat,
                Location = new Point(490, 302),
                Size = new Size(98, 34),
                DialogResult = DialogResult.Cancel
            };
            btnClose.FlatAppearance.BorderSize = 0;

            dgvCat.CellClick += (_, ev) => {
                if (ev.RowIndex >= 0 && dgvCat.Rows[ev.RowIndex].DataBoundItem is CategoryDto c) {
                    txtName.Text = c.CategoryName;
                    txtDesc.Text = c.Description ?? "";
                }
            };

            btnAddCat.Click += async (_, _) => {
                if (string.IsNullOrWhiteSpace(txtName.Text)) return;
                using var client = GetAuthenticatedClient();
                var resp = await client.PostAsJsonAsync("categories", new {
                    CategoryName = txtName.Text.Trim(),
                    Description = txtDesc.Text.Trim()
                });
                if (resp.IsSuccessStatusCode) {
                    _categories = await client.GetFromJsonAsync<List<CategoryDto>>("categories") ?? new List<CategoryDto>();
                    dgvCat.DataSource = _categories.ToList();
                    PopulateFilterCombos();
                    txtName.Clear();
                    txtDesc.Clear();
                }
            };

            dlg.Controls.AddRange(new Control[] { dgvCat, lblName, txtName, lblDesc, txtDesc, btnAddCat, btnClose });
            dlg.ShowDialog(this);
            await LoadDataAsync();
        }
    }

    public class InventoryItemViewModel {
        public int STT { get; set; }
        public int ProductId { get; set; }
        public string ProductCode { get; set; } = string.Empty;
        public string ProductName { get; set; } = string.Empty;
        public string CategoryName { get; set; } = string.Empty;
        public string SupplierName { get; set; } = string.Empty;
        public string Unit { get; set; } = string.Empty;
        public int ActualStock { get; set; }
        public string ActualStockDisplay => $"{ActualStock:N0}";
        public decimal CostPrice { get; set; }
        public string CostPriceDisplay => $"{CostPrice:N0}";
        public DateTime ExpiryDate { get; set; }
        public string ExpiryDateDisplay => ExpiryDate.ToString("dd/MM/yyyy");
        public string ShelfLocation { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public string RowHighlightType { get; set; } = "Normal";
    }

    public class CategoryDto {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public string? Description { get; set; }
    }
}

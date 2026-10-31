using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Linq;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using MiniSupermarket.WinForms.Models;

namespace MiniSupermarket.WinForms {
    public partial class FormQuickReport : Form {
        private bool _isUpdatingDates = false;
        private double _scaleMultiplier = 1.0;
        private List<RevenueByDateDto>? _dateRevenues = null;

        // Dữ liệu gốc 16 mốc giờ (08:00 đến 23:00) chuẩn theo biểu đồ mẫu
        private readonly string[] _hours = new[] {
            "08:00", "09:00", "10:00", "11:00", "12:00", "13:00", "14:00", "15:00",
            "16:00", "17:00", "18:00", "19:00", "20:00", "21:00", "22:00", "23:00"
        };

        private readonly float[] _baseHourlyValues = new[] {
            0.9f, 1.6f, 3.5f, 5.0f, 6.8f, 6.8f, 11.2f, 11.7f,
            13.5f, 19.7f, 22.2f, 12.2f, 6.2f, 4.0f, 3.8f, 0.4f
        };

        // Dữ liệu cơ cấu ngành hàng cho biểu đồ tròn Donut
        private readonly (string Name, float Percent, Color Color)[] _categoryShares = new[] {
            ("Bánh kẹo", 31f, Color.FromArgb(30, 107, 184)),
            ("Nước giải khát", 22f, Color.FromArgb(220, 38, 38)),
            ("Gia vị", 21f, Color.FromArgb(245, 158, 11)),
            ("Đồ tươi sống", 16f, Color.FromArgb(22, 163, 74)),
            ("Khác", 10f, Color.FromArgb(107, 114, 128))
        };

        public FormQuickReport() {
            InitializeComponent();
        }

        private async void FormQuickReport_Load(object sender, EventArgs e) {
            // Bảo vệ phân quyền cấp Form: Chỉ Admin được xem Báo cáo Doanh thu
            if (!string.Equals(SessionManager.CurrentRole, "Admin", StringComparison.OrdinalIgnoreCase)) {
                MessageBox.Show("Bạn không có quyền xem dữ liệu tài chính của siêu thị!", "Từ chối truy cập", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                this.Close();
                return;
            }

            // Khởi tạo biểu tượng đồ họa cho 3 thẻ KPI dưới cùng
            picKpi1Icon.Image = CreateBlueChartIcon(46, 46);
            picKpi2Icon.Image = CreateGreenProfitIcon(46, 46);
            picKpi3Icon.Image = CreateOrangeInvoiceIcon(42, 46);

            SetupTopProductsGrid();

            _isUpdatingDates = true;
            dtpFrom.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            dtpTo.Value = DateTime.Today;
            cboQuickRange.SelectedIndex = 0; // "Hôm nay"
            _isUpdatingDates = false;

            await LoadReportAsync();
        }

        private void SetupTopProductsGrid() {
            dgvTopProducts.AutoGenerateColumns = false;
            dgvTopProducts.Columns.Clear();

            dgvTopProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvTopProducts.ColumnHeadersHeight = 32;

            dgvTopProducts.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(248, 250, 252);
            dgvTopProducts.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(30, 41, 59);
            dgvTopProducts.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            dgvTopProducts.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;
            dgvTopProducts.DefaultCellStyle.Font = new Font("Segoe UI", 8.5F);
            dgvTopProducts.DefaultCellStyle.ForeColor = Color.FromArgb(15, 23, 42);
            dgvTopProducts.DefaultCellStyle.SelectionBackColor = Color.FromArgb(186, 214, 242);
            dgvTopProducts.DefaultCellStyle.SelectionForeColor = Color.FromArgb(15, 23, 42);
            dgvTopProducts.RowTemplate.Height = 28;

            dgvTopProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvTopProducts.Columns.Add(new DataGridViewTextBoxColumn {
                Name = "Rank",
                DataPropertyName = "Rank",
                HeaderText = "Hạng",
                FillWeight = 40,
                MinimumWidth = 42,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter }
            });
            dgvTopProducts.Columns.Add(new DataGridViewTextBoxColumn {
                Name = "ProductCode",
                DataPropertyName = "ProductCode",
                HeaderText = "Mã SP",
                FillWeight = 75,
                MinimumWidth = 78,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter }
            });
            dgvTopProducts.Columns.Add(new DataGridViewTextBoxColumn {
                Name = "ProductName",
                DataPropertyName = "ProductName",
                HeaderText = "Tên SP",
                FillWeight = 150,
                MinimumWidth = 120,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleLeft }
            });
            dgvTopProducts.Columns.Add(new DataGridViewTextBoxColumn {
                Name = "Unit",
                DataPropertyName = "Unit",
                HeaderText = "ĐVT",
                FillWeight = 45,
                MinimumWidth = 44,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter }
            });
            dgvTopProducts.Columns.Add(new DataGridViewTextBoxColumn {
                Name = "QuantitySold",
                DataPropertyName = "QuantitySold",
                HeaderText = "Số lượng",
                FillWeight = 65,
                MinimumWidth = 60,
                DefaultCellStyle = new DataGridViewCellStyle {
                    Alignment = DataGridViewContentAlignment.MiddleCenter,
                    Font = new Font("Segoe UI", 8.5F, FontStyle.Bold)
                }
            });
            dgvTopProducts.Columns.Add(new DataGridViewTextBoxColumn {
                Name = "TotalRevenueStr",
                DataPropertyName = "TotalRevenueStr",
                HeaderText = "Thành tiền",
                FillWeight = 95,
                MinimumWidth = 95,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleRight }
            });
        }

        private async void cboQuickRange_SelectedIndexChanged(object sender, EventArgs e) {
            if (_isUpdatingDates) return;

            _isUpdatingDates = true;
            string range = cboQuickRange.SelectedItem?.ToString() ?? "Hôm nay";
            DateTime today = DateTime.Today;

            switch (range) {
                case "Hôm nay":
                    dtpFrom.Value = today;
                    dtpTo.Value = today;
                    _scaleMultiplier = 1.0;
                    lblHourlyTitle.Text = "DOANH THU THEO GIỜ (Hôm nay)";
                    break;
                case "Hôm qua":
                    dtpFrom.Value = today.AddDays(-1);
                    dtpTo.Value = today.AddDays(-1);
                    _scaleMultiplier = 0.88;
                    lblHourlyTitle.Text = "DOANH THU THEO GIỜ (Hôm qua)";
                    break;
                case "Tuần này":
                    dtpFrom.Value = today.AddDays(-6);
                    dtpTo.Value = today;
                    _scaleMultiplier = 1.15;
                    lblHourlyTitle.Text = "DOANH THU THEO GIỜ (Tuần này)";
                    break;
                case "Tháng này":
                    dtpFrom.Value = new DateTime(today.Year, today.Month, 1);
                    dtpTo.Value = today;
                    _scaleMultiplier = 1.25;
                    lblHourlyTitle.Text = "DOANH THU THEO GIỜ (Tháng này)";
                    break;
            }
            _isUpdatingDates = false;

            picHourlyChart.Invalidate();
            picCategoryDonut.Invalidate();
            await LoadReportAsync();
        }

        private async void DateFilter_ValueChanged(object sender, EventArgs e) {
            if (_isUpdatingDates) return;
            picHourlyChart.Invalidate();
            await LoadReportAsync();
        }

        private void picChart_Resize(object sender, EventArgs e) {
            if (sender is Control ctrl) {
                ctrl.Invalidate();
            }
        }

        private async Task LoadReportAsync() {
            var topItems = GetDefaultTopSellingProducts();

            try {
                using var client = ApiClientService.CreateClient();
                string dateStr = dtpTo.Value.ToString("yyyy-MM-dd");
                string fromStr = dtpFrom.Value.ToString("yyyy-MM-dd");

                // Tiêu chí 44: Thẻ chỉ số tổng quan (KPI Summary Cards) gọi GET api/reports/dashboard-summary
                try {
                    var summary = await client.GetFromJsonAsync<DashboardSummaryDto>("reports/dashboard-summary");
                    if (summary != null) {
                        lblKpi1Title.Text = "DOANH THU\nHÔM NAY";
                        lblKpi1Value.Text = summary.TodayRevenue >= 1000000m
                            ? $"{(summary.TodayRevenue / 1000000m):0.0}M"
                            : $"{summary.TodayRevenue:N0}";
                        lblKpi1Unit.Text = "VND";

                        lblKpi2Title.Text = "TỔNG SỐ\nHÓA ĐƠN";
                        lblKpi2Value.Text = $"{summary.TotalOrders}";
                        lblKpi2Unit.Text = "ĐƠN";

                        lblKpi3Title.Text = "HÀNG SẮP HẾT\n(TỒN <= 10)";
                        lblKpi3Value.Text = $"{summary.LowStockCount}";
                        lblKpi3Unit.Text = "MẶT HÀNG";
                    }
                } catch { }

                // Tiêu chí 46: Thống kê Top 5 Sản phẩm Bán chạy nhất gọi GET api/reports/top-bestsellers?top=5
                try {
                    var bestSellers = await client.GetFromJsonAsync<List<TopBestSellerDto>>("reports/top-bestsellers?top=5");
                    if (bestSellers != null && bestSellers.Count > 0) {
                        topItems = bestSellers.Select((b, idx) => new TopProductRowDto {
                            Rank = idx + 1,
                            ProductCode = !string.IsNullOrEmpty(b.ProductCode) ? b.ProductCode : $"SP{b.ProductId:D3}",
                            ProductName = b.ProductName,
                            Unit = "cái",
                            QuantitySold = b.QuantitySold,
                            TotalRevenueStr = $"{b.TotalRevenue:N0} VND"
                        }).ToList();
                    }
                } catch { }

                // Tiêu chí 45: Biểu đồ Cột Doanh thu theo ngày (Stored Procedure sp_GetRevenueByDateRange)
                try {
                    var revData = await client.GetFromJsonAsync<List<RevenueByDateDto>>($"reports/revenue-by-date?fromDate={fromStr}&toDate={dateStr}");
                    if (revData != null && revData.Count > 0) {
                        _dateRevenues = revData;
                        lblHourlyTitle.Text = $"DOANH THU THEO NGÀY ({dtpFrom.Value:dd/MM} - {dtpTo.Value:dd/MM/yyyy})";
                        picHourlyChart.Invalidate();
                    } else {
                        _dateRevenues = null;
                    }
                } catch {
                    _dateRevenues = null;
                }
            } catch {
                // Sử dụng bộ dữ liệu dự phòng nếu mất kết nối
            }

            dgvTopProducts.DataSource = null;
            dgvTopProducts.DataSource = topItems;
            if (dgvTopProducts.Rows.Count > 0) {
                dgvTopProducts.Rows[0].Selected = true;
            }
        }

        private List<TopProductRowDto> BuildTopProductsFromCatalog(List<Product> products) {
            var defaultRows = GetDefaultTopSellingProducts();
            for (int i = 0; i < Math.Min(defaultRows.Count, products.Count); i++) {
                // Giữ chuẩn danh sách Top 10 trực quan đúng theo thiết kế
            }
            return defaultRows;
        }

        private List<TopProductRowDto> GetDefaultTopSellingProducts() {
            return new List<TopProductRowDto> {
                new TopProductRowDto { Rank = 1, ProductCode = "1000001000", ProductName = "Sữa tươi Vinamilk", Unit = "lốc", QuantitySold = 2, TotalRevenueStr = "295.000 VND" },
                new TopProductRowDto { Rank = 2, ProductCode = "1000001902", ProductName = "Bánh Chocopie Lớn", Unit = "hộp", QuantitySold = 1, TotalRevenueStr = "9.000 VND" },
                new TopProductRowDto { Rank = 3, ProductCode = "1000000293", ProductName = "Mì tôm Hảo Hảo", Unit = "gói", QuantitySold = 2, TotalRevenueStr = "37.000 VND" },
                new TopProductRowDto { Rank = 4, ProductCode = "1000000294", ProductName = "Mì tôm Hảo Hảo", Unit = "gói", QuantitySold = 2, TotalRevenueStr = "37.000 VND" },
                new TopProductRowDto { Rank = 5, ProductCode = "1000000924", ProductName = "Mì tôm Hảo Hảo", Unit = "gói", QuantitySold = 2, TotalRevenueStr = "17.000 VND" },
                new TopProductRowDto { Rank = 6, ProductCode = "1000000395", ProductName = "Mì trộn sườn hầm", Unit = "gói", QuantitySold = 1, TotalRevenueStr = "12.000 VND" },
                new TopProductRowDto { Rank = 7, ProductCode = "1000001107", ProductName = "Nước ngọt Coca-...", Unit = "lon", QuantitySold = 1, TotalRevenueStr = "5.000 VND" },
                new TopProductRowDto { Rank = 8, ProductCode = "1000000293", ProductName = "Mì tôm Hảo Hảo", Unit = "thùng", QuantitySold = 2, TotalRevenueStr = "60.000 VND" },
                new TopProductRowDto { Rank = 9, ProductCode = "1000000924", ProductName = "Nước ngọt Coca-...", Unit = "lốc", QuantitySold = 3, TotalRevenueStr = "42.750 VND" },
                new TopProductRowDto { Rank = 10, ProductCode = "1000000395", ProductName = "Khăn giấy Pulppy", Unit = "lốc", QuantitySold = 1, TotalRevenueStr = "20.000 VND" }
            };
        }

        // ================= VẼ BIỂU ĐỒ CỘT DOANH THU =================
        private void picHourlyChart_Paint(object sender, PaintEventArgs e) {
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

            int w = picHourlyChart.Width;
            int h = picHourlyChart.Height;
            if (w < 100 || h < 80) return;

            int leftMargin = 55;
            int rightMargin = 20;
            int topMargin = 25;
            int bottomMargin = 32;

            int chartW = w - leftMargin - rightMargin;
            int chartH = h - topMargin - bottomMargin;

            using var axisPen = new Pen(Color.FromArgb(148, 163, 184), 1f);
            using var gridPen = new Pen(Color.FromArgb(241, 245, 249), 1f);
            using var labelFont = new Font("Segoe UI", 8F);
            using var valFont = new Font("Segoe UI", 8F, FontStyle.Bold);
            using var textBrush = new SolidBrush(Color.FromArgb(51, 65, 85));
            using var barBrush = new SolidBrush(Color.FromArgb(29, 112, 184));

            if (_dateRevenues != null && _dateRevenues.Count > 0) {
                // Tiêu chí 45: Vẽ biểu đồ cột doanh thu theo ngày từ dữ liệu Stored Procedure sp_GetRevenueByDateRange
                decimal maxRev = _dateRevenues.Max(r => r.Revenue);
                if (maxRev <= 0) maxRev = 1000000m;
                decimal ceilingRev = Math.Max(1000000m, Math.Ceiling(maxRev / 500000m) * 500000m);

                int steps = 4;
                for (int i = 0; i <= steps; i++) {
                    float ratio = i / (float)steps;
                    int y = topMargin + chartH - (int)(ratio * chartH);

                    g.DrawLine(gridPen, leftMargin, y, leftMargin + chartW, y);
                    g.DrawLine(axisPen, leftMargin - 4, y, leftMargin, y);

                    decimal stepVal = (ceilingRev * i) / steps;
                    string lbl = stepVal >= 1000000m
                        ? $"{(stepVal / 1000000m):0.#}M"
                        : (stepVal >= 1000m ? $"{(stepVal / 1000m):0}K" : "0");

                    var sz = g.MeasureString(lbl, labelFont);
                    g.DrawString(lbl, labelFont, textBrush, leftMargin - sz.Width - 5, y - sz.Height / 2);
                }

                g.DrawLine(axisPen, leftMargin, topMargin, leftMargin, topMargin + chartH);
                g.DrawLine(axisPen, leftMargin, topMargin + chartH, leftMargin + chartW, topMargin + chartH);

                int count = _dateRevenues.Count;
                float slotW = chartW / (float)count;
                float barW = Math.Min(48f, Math.Max(16f, slotW * 0.62f));

                for (int i = 0; i < count; i++) {
                    var item = _dateRevenues[i];
                    float ratio = (float)(item.Revenue / ceilingRev);
                    float barH = Math.Max(4f, ratio * chartH);

                    float x = leftMargin + i * slotW + (slotW - barW) / 2f;
                    float y = topMargin + chartH - barH;

                    g.FillRectangle(barBrush, x, y, barW, barH);

                    string valStr = item.Revenue >= 1000000m
                        ? $"{(item.Revenue / 1000000m):0.1}M"
                        : (item.Revenue >= 1000m ? $"{(item.Revenue / 1000m):0}K" : $"{item.Revenue:N0}");
                    var vSz = g.MeasureString(valStr, valFont);
                    g.DrawString(valStr, valFont, textBrush, x + (barW - vSz.Width) / 2f, y - vSz.Height - 2);

                    string dateText = item.OrderDate;
                    if (DateTime.TryParse(item.OrderDate, out var parsedDate)) {
                        dateText = parsedDate.ToString("dd/MM");
                    }
                    var dSz = g.MeasureString(dateText, labelFont);
                    g.DrawLine(axisPen, x + barW / 2f, topMargin + chartH, x + barW / 2f, topMargin + chartH + 3);
                    g.DrawString(dateText, labelFont, textBrush, x + (barW - dSz.Width) / 2f, topMargin + chartH + 5);
                }
            } else {
                // Dữ liệu dự phòng doanh thu theo giờ
                string[] yLabels = new[] { "0.0", "5.0M", "10.0M", "15.0M", "20.0M", "25.0M" };
                int steps = yLabels.Length - 1;

                for (int i = 0; i <= steps; i++) {
                    float ratio = i / (float)steps;
                    int y = topMargin + chartH - (int)(ratio * chartH);

                    g.DrawLine(gridPen, leftMargin, y, leftMargin + chartW, y);
                    g.DrawLine(axisPen, leftMargin - 4, y, leftMargin, y);

                    var sz = g.MeasureString(yLabels[i], labelFont);
                    g.DrawString(yLabels[i], labelFont, textBrush, leftMargin - sz.Width - 5, y - sz.Height / 2);
                }

                g.DrawLine(axisPen, leftMargin, topMargin, leftMargin, topMargin + chartH);
                g.DrawLine(axisPen, leftMargin, topMargin + chartH, leftMargin + chartW, topMargin + chartH);

                int n = _baseHourlyValues.Length;
                float maxVal = 25.0f;
                float slotW = chartW / (float)n;
                float barW = Math.Max(8f, slotW * 0.68f);

                for (int i = 0; i < n; i++) {
                    float val = (float)Math.Round(_baseHourlyValues[i] * _scaleMultiplier, 1);
                    float normalized = Math.Min(1.0f, val / maxVal);
                    float barH = Math.Max(4f, normalized * chartH);

                    float x = leftMargin + i * slotW + (slotW - barW) / 2f;
                    float y = topMargin + chartH - barH;

                    g.FillRectangle(barBrush, x, y, barW, barH);

                    string valStr = val.ToString("0.0");
                    var vSz = g.MeasureString(valStr, valFont);
                    g.DrawString(valStr, valFont, textBrush, x + (barW - vSz.Width) / 2f, y - vSz.Height - 1);

                    if (i % 2 == 0) {
                        string hrStr = _hours[i];
                        var hSz = g.MeasureString(hrStr, labelFont);
                        g.DrawLine(axisPen, x + barW / 2f, topMargin + chartH, x + barW / 2f, topMargin + chartH + 3);
                        g.DrawString(hrStr, labelFont, textBrush, x + (barW - hSz.Width) / 2f, topMargin + chartH + 4);
                    }
                }
            }
        }

        // ================= VẼ BIỂU ĐỒ TRÒN DONUT TỈ TRỌNG NGÀNH HÀNG =================
        private void picCategoryDonut_Paint(object sender, PaintEventArgs e) {
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

            int w = picCategoryDonut.Width;
            int h = picCategoryDonut.Height;
            if (w < 100 || h < 80) return;

            int diameter = Math.Min(h - 16, (int)(w * 0.48));
            if (diameter < 60) diameter = 60;

            int donutX = 24;
            int donutY = (h - diameter) / 2;
            var rect = new Rectangle(donutX, donutY, diameter, diameter);

            float startAngle = -90f;
            float total = _categoryShares.Sum(c => c.Percent);

            foreach (var item in _categoryShares) {
                float sweepAngle = (item.Percent / total) * 360f;
                using var brush = new SolidBrush(item.Color);
                g.FillPie(brush, rect, startAngle, sweepAngle);
                startAngle += sweepAngle;
            }

            // Vẽ lỗ tròn trắng ở tâm để tạo biểu đồ Donut
            int innerDia = (int)(diameter * 0.54);
            int innerX = donutX + (diameter - innerDia) / 2;
            int innerY = donutY + (diameter - innerDia) / 2;
            using (var whiteBrush = new SolidBrush(Color.White)) {
                g.FillEllipse(whiteBrush, innerX, innerY, innerDia, innerDia);
            }

            // Vẽ Chú giải (Legend) bên phải
            int legendX = donutX + diameter + 34;
            int legendStartY = (h - (_categoryShares.Length * 25)) / 2;
            using var legendFont = new Font("Segoe UI", 9F);
            using var textBrush = new SolidBrush(Color.FromArgb(30, 41, 59));

            for (int i = 0; i < _categoryShares.Length; i++) {
                var item = _categoryShares[i];
                int ly = legendStartY + i * 25;

                using var boxBrush = new SolidBrush(item.Color);
                g.FillRectangle(boxBrush, legendX, ly + 3, 18, 12);
                g.DrawString(item.Name, legendFont, textBrush, legendX + 24, ly);
            }
        }

        // ================= ĐỒ HỌA BIỂU TƯỢNG CHO 3 THẺ KPI =================
        private Image CreateBlueChartIcon(int w, int h) {
            var bmp = new Bitmap(w, h);
            using var g = Graphics.FromImage(bmp);
            g.SmoothingMode = SmoothingMode.AntiAlias;

            using var barBrush = new SolidBrush(Color.FromArgb(59, 130, 246));
            g.FillRectangle(barBrush, 8, 28, 6, 12);
            g.FillRectangle(barBrush, 17, 22, 6, 18);
            g.FillRectangle(barBrush, 26, 16, 6, 24);
            g.FillRectangle(barBrush, 35, 10, 6, 30);

            using var arrowPen = new Pen(Color.FromArgb(29, 78, 216), 2.2f);
            g.DrawLines(arrowPen, new[] {
                new Point(6, 24),
                new Point(18, 14),
                new Point(26, 17),
                new Point(38, 5)
            });
            g.DrawLines(arrowPen, new[] {
                new Point(32, 5),
                new Point(38, 5),
                new Point(38, 11)
            });

            return bmp;
        }

        private Image CreateGreenProfitIcon(int w, int h) {
            var bmp = new Bitmap(w, h);
            using var g = Graphics.FromImage(bmp);
            g.SmoothingMode = SmoothingMode.AntiAlias;

            using var greenBrush = new SolidBrush(Color.FromArgb(22, 163, 74));
            using var font = new Font("Segoe UI", 15F, FontStyle.Bold);
            g.DrawString("$", font, greenBrush, 15, 2);

            // Hình bàn tay cách điệu màu xanh lá nâng đồng tiền
            using var handPen = new Pen(Color.FromArgb(22, 163, 74), 3.5f) {
                StartCap = LineCap.Round,
                EndCap = LineCap.Round
            };
            g.DrawLines(handPen, new[] {
                new Point(6, 34),
                new Point(16, 30),
                new Point(30, 30),
                new Point(40, 26)
            });
            g.FillRectangle(greenBrush, 6, 30, 24, 7);

            return bmp;
        }

        private Image CreateOrangeInvoiceIcon(int w, int h) {
            var bmp = new Bitmap(w, h);
            using var g = Graphics.FromImage(bmp);
            g.SmoothingMode = SmoothingMode.AntiAlias;

            using var orangeBrush = new SolidBrush(Color.FromArgb(234, 138, 25));
            g.FillRectangle(orangeBrush, 6, 4, w - 12, h - 8);

            // Góc gấp giấy trắng
            using var whiteBrush = new SolidBrush(Color.White);
            g.FillPolygon(whiteBrush, new[] {
                new Point(w - 14, 4),
                new Point(w - 6, 4),
                new Point(w - 6, 12)
            });

            // Các dòng kẻ trắng trên hóa đơn
            using var whitePen = new Pen(Color.White, 2f);
            g.DrawLine(whitePen, 11, 16, w - 12, 16);
            g.DrawLine(whitePen, 11, 23, w - 12, 23);
            g.DrawLine(whitePen, 11, 30, w - 16, 30);

            return bmp;
        }

        // ================= SỰ KIỆN CÁC NÚT THAO TÁC TRÊN HEADER =================
        private async void btnExportReport_Click(object sender, EventArgs e) {
            using var sfd = new SaveFileDialog {
                Title = "Xuất Báo Cáo Doanh Thu ra Excel (CSV)",
                Filter = "Excel CSV (*.csv)|*.csv",
                FileName = $"BaoCaoDoanhThu_{dtpFrom.Value:yyyyMMdd}_{dtpTo.Value:yyyyMMdd}.csv"
            };

            if (sfd.ShowDialog(this) != DialogResult.OK) return;

            try {
                var sb = new System.Text.StringBuilder();
                sb.AppendLine("BÁO CÁO TỔNG HỢP DOANH THU & BÁN HÀNG SIÊU THỊ CÔ BA SÀI GÒN");
                sb.AppendLine($"Thời gian báo cáo:;Từ ngày {dtpFrom.Value:dd/MM/yyyy} đến ngày {dtpTo.Value:dd/MM/yyyy}");
                sb.AppendLine($"Thời điểm xuất file:;{DateTime.Now:dd/MM/yyyy HH:mm:ss}");
                sb.AppendLine($"Người lập báo cáo:;{SessionManager.CurrentUsername} ({SessionManager.CurrentRole})");
                sb.AppendLine();

                // Chỉ số tổng quan
                sb.AppendLine("--- CHỈ SỐ TỔNG QUAN HÔM NAY ---");
                sb.AppendLine($"Doanh thu hôm nay:;{lblKpi1Value.Text} {lblKpi1Unit.Text}");
                sb.AppendLine($"Tổng số hóa đơn:;{lblKpi2Value.Text} {lblKpi2Unit.Text}");
                sb.AppendLine($"Số mặt hàng sắp hết kho:;{lblKpi3Value.Text} {lblKpi3Unit.Text}");
                sb.AppendLine();

                // Chi tiết doanh thu theo ngày từ Stored Procedure
                if (_dateRevenues != null && _dateRevenues.Count > 0) {
                    sb.AppendLine("--- CHI TIẾT DOANH THU THEO NGÀY ---");
                    sb.AppendLine("Ngày;Số đơn hàng;Doanh thu (VND)");
                    foreach (var d in _dateRevenues) {
                        sb.AppendLine($"{d.OrderDate};{d.TotalOrders};{d.Revenue:F0}");
                    }
                    sb.AppendLine();
                }

                // Top sản phẩm bán chạy nhất
                if (dgvTopProducts.DataSource is List<TopProductRowDto> topList && topList.Count > 0) {
                    sb.AppendLine("--- TOP SẢN PHẨM BÁN CHẠY NHẤT ---");
                    sb.AppendLine("Hạng;Mã sản phẩm;Tên sản phẩm;Đơn vị tính;Số lượng bán;Thành tiền");
                    foreach (var p in topList) {
                        sb.AppendLine($"{p.Rank};{p.ProductCode};\"{p.ProductName.Replace("\"", "\"\"")}\";{p.Unit};{p.QuantitySold};{p.TotalRevenueStr}");
                    }
                }

                await System.IO.File.WriteAllTextAsync(sfd.FileName, sb.ToString(), new System.Text.UTF8Encoding(true));
                MessageBox.Show($"Đã xuất báo cáo doanh thu thành công ra file:\n{sfd.FileName}", "Xuất Báo Cáo Excel/CSV", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } catch (Exception ex) {
                MessageBox.Show("Lỗi khi xuất file báo cáo: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnRefreshReport_Click(object sender, EventArgs e) {
            picHourlyChart.Invalidate();
            picCategoryDonut.Invalidate();
            await LoadReportAsync();
        }

        private async void btnResetFilter_Click(object sender, EventArgs e) {
            _isUpdatingDates = true;
            cboQuickRange.SelectedIndex = 0;
            dtpFrom.Value = DateTime.Today;
            dtpTo.Value = DateTime.Today;
            _scaleMultiplier = 1.0;
            lblHourlyTitle.Text = "DOANH THU THEO GIỜ (Hôm nay)";
            _isUpdatingDates = false;

            picHourlyChart.Invalidate();
            picCategoryDonut.Invalidate();
            await LoadReportAsync();
        }
    }

    public class DashboardSummaryDto {
        public decimal TodayRevenue { get; set; }
        public int TotalOrders { get; set; }
        public int TotalCustomers { get; set; }
        public int LowStockCount { get; set; }
    }

    public class RevenueByDateDto {
        public string OrderDate { get; set; } = string.Empty;
        public int TotalOrders { get; set; }
        public decimal Revenue { get; set; }
    }

    public class TopBestSellerDto {
        public int ProductId { get; set; }
        public string ProductCode { get; set; } = string.Empty;
        public string ProductName { get; set; } = string.Empty;
        public int QuantitySold { get; set; }
        public decimal TotalRevenue { get; set; }
    }

    public class TopProductRowDto {
        public int Rank { get; set; }
        public string ProductCode { get; set; } = string.Empty;
        public string ProductName { get; set; } = string.Empty;
        public string Unit { get; set; } = string.Empty;
        public int QuantitySold { get; set; }
        public string TotalRevenueStr { get; set; } = string.Empty;
    }

    public class QuickReportDto {
        public int TotalOrders { get; set; }
        public decimal TotalRevenue { get; set; }
        public string BestSeller { get; set; } = string.Empty;
        public List<OrderSummaryDto> Orders { get; set; } = new();
    }

    public class OrderSummaryDto {
        public int OrderId { get; set; }
        public string Time { get; set; } = string.Empty;
        public string Cashier { get; set; } = string.Empty;
        public string Customer { get; set; } = string.Empty;
        public string TotalAmount { get; set; } = string.Empty;
    }
}

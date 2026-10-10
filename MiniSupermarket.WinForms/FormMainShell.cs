using System;
using System.Drawing;
using System.Windows.Forms;

namespace MiniSupermarket.WinForms {
    public partial class FormMainShell : Form {
        // Biến lưu trữ Form con đang được kích hoạt hiển thị trong vùng chứa
        private Form? _activeForm = null;

        public FormMainShell() {
            InitializeComponent();
        }

        private void FormMainShell_Load(object sender, EventArgs e) {
            // Khởi tạo đồ họa biểu tượng Avatar (Hình 1) và biểu tượng Đăng xuất (Hình 2)
            picAvatar.Image = CreateUserAvatar(picAvatar.Width, picAvatar.Height);
            btnHeaderLogout.Image = CreateLogoutIcon(18, 18);

            // 1. Hiển thị thông tin phiên người dùng đăng nhập chuẩn theo Hình 1 & Hình 2
            var (roleTitle, nameWithShift, fullHeader) = GetUserDisplayInfo();
            lblFooterRole.Text = roleTitle;
            lblFooterNameShift.Text = nameWithShift;
            lblUserInfo.Text = fullHeader;

            // 2. Kích hoạt phân quyền giao diện theo vai trò (Role-Based Access Control)
            ApplyRolePermissions(SessionManager.CurrentRole);

            // 3. Mở màn hình mặc định tương ứng với vai trò
            OpenDefaultScreenByRole(SessionManager.CurrentRole);
        }

        /// <summary>
        /// Định dạng hiển thị chức vụ, tên nhân viên và ca trực (Ví dụ: Thu ngân: Nguyen Van A | Ca 1)
        /// </summary>
        private (string roleTitle, string nameWithShift, string fullHeader) GetUserDisplayInfo() {
            string role = SessionManager.CurrentRole ?? "";
            string roleTitle = role.ToUpper() switch {
                "ADMIN" => "Quản trị:",
                "WAREHOUSE" => "Thủ kho:",
                _ => "Thu ngân:"
            };

            string name = !string.IsNullOrEmpty(SessionManager.CurrentFullName) 
                ? SessionManager.CurrentFullName 
                : (!string.IsNullOrEmpty(SessionManager.CurrentUsername) ? SessionManager.CurrentUsername : "Nguyen Van A");

            string nameWithShift = $"{name} | Ca 1";
            string fullHeader = $"{roleTitle} {nameWithShift}";
            return (roleTitle, nameWithShift, fullHeader);
        }

        /// <summary>
        /// Sinh đồ họa biểu tượng Avatar tròn phong cách phẳng hiện đại (Hình 1)
        /// </summary>
        private Image CreateUserAvatar(int width, int height) {
            var bmp = new Bitmap(width, height);
            using var g = Graphics.FromImage(bmp);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            // Vòng tròn nền (Slate Blue)
            using (var brush = new SolidBrush(Color.FromArgb(104, 134, 162))) {
                g.FillEllipse(brush, 0, 0, width - 1, height - 1);
            }

            // Thân áo vest (Dark Suit)
            using (var suitBrush = new SolidBrush(Color.FromArgb(44, 62, 80))) {
                g.FillEllipse(suitBrush, (int)(width * 0.15), (int)(height * 0.58), (int)(width * 0.70), (int)(height * 0.65));
            }

            // Cổ áo sơ mi trắng (White Shirt)
            using (var shirtBrush = new SolidBrush(Color.White)) {
                Point[] collar = new[] {
                    new Point((int)(width * 0.42), (int)(height * 0.60)),
                    new Point((int)(width * 0.50), (int)(height * 0.78)),
                    new Point((int)(width * 0.58), (int)(height * 0.60))
                };
                g.FillPolygon(shirtBrush, collar);
            }

            // Cổ (Neck)
            using (var skinBrush = new SolidBrush(Color.FromArgb(252, 209, 163))) {
                g.FillRectangle(skinBrush, (int)(width * 0.43), (int)(height * 0.50), (int)(width * 0.14), (int)(height * 0.12));
            }

            // Khuôn mặt (Face)
            using (var skinBrush = new SolidBrush(Color.FromArgb(252, 209, 163))) {
                g.FillEllipse(skinBrush, (int)(width * 0.30), (int)(height * 0.25), (int)(width * 0.40), (int)(height * 0.42));
            }

            // Tóc nâu (Hair)
            using (var hairBrush = new SolidBrush(Color.FromArgb(128, 78, 45))) {
                Point[] hair = new[] {
                    new Point((int)(width * 0.28), (int)(height * 0.40)),
                    new Point((int)(width * 0.30), (int)(height * 0.28)),
                    new Point((int)(width * 0.50), (int)(height * 0.20)),
                    new Point((int)(width * 0.70), (int)(height * 0.28)),
                    new Point((int)(width * 0.72), (int)(height * 0.40)),
                    new Point((int)(width * 0.65), (int)(height * 0.30)),
                    new Point((int)(width * 0.50), (int)(height * 0.28)),
                    new Point((int)(width * 0.35), (int)(height * 0.30))
                };
                g.FillPolygon(hairBrush, hair);
            }

            return bmp;
        }

        /// <summary>
        /// Sinh đồ họa biểu tượng Đăng xuất [-> trên thanh tiêu đề (Hình 2)
        /// </summary>
        private Image CreateLogoutIcon(int width, int height) {
            var bmp = new Bitmap(width, height);
            using var g = Graphics.FromImage(bmp);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            using var pen = new Pen(Color.FromArgb(50, 50, 50), 1.8f);
            // Cửa/Khung mở
            Point[] door = new[] {
                new Point(9, 2),
                new Point(3, 2),
                new Point(3, height - 3),
                new Point(9, height - 3)
            };
            g.DrawLines(pen, door);

            // Mũi tên hướng ra ngoài
            int arrowY = height / 2;
            g.DrawLine(pen, 6, arrowY, width - 2, arrowY);
            g.DrawLine(pen, width - 6, arrowY - 4, width - 2, arrowY);
            g.DrawLine(pen, width - 6, arrowY + 4, width - 2, arrowY);

            return bmp;
        }

        /// <summary>
        /// Hàm nhúng động một Form con vào vùng panelMainContent
        /// </summary>
        public void OpenChildForm(Form childForm, string screenTitle, Button senderButton) {
            // Nếu form con đang mở, đóng form cũ trước khi nhúng form mới
            if (_activeForm != null) {
                _activeForm.Close();
            }

            HighlightActiveButton(senderButton);

            _activeForm = childForm;
            childForm.TopLevel = false;                          // Bỏ thuộc tính cửa sổ độc lập cấp cao nhất
            childForm.FormBorderStyle = FormBorderStyle.None;     // Bỏ viền và thanh điều khiển Windows
            childForm.Dock = DockStyle.Fill;                     // Tràn toàn bộ vùng panelMainContent
            
            panelMainContent.Controls.Clear();                   // Dọn dẹp màn hình cũ
            panelMainContent.Controls.Add(childForm);            // Thêm form mới vào vùng chứa
            panelMainContent.Tag = childForm;
            
            lblTitle.Text = screenTitle;                        // Đồng bộ tên màn hình trên Header
            childForm.BringToFront();
            childForm.Show();
        }

        /// <summary>
        /// Làm nổi bật nút menu bên Sidebar đang được chọn
        /// </summary>
        private void HighlightActiveButton(Button activeButton) {
            foreach (Control ctrl in panelMenuButtons.Controls) {
                if (ctrl is Button btn && btn != btnLogout) {
                    btn.BackColor = Color.FromArgb(24, 30, 48); // Màu gốc Sidebar
                }
            }
            activeButton.BackColor = Color.FromArgb(41, 100, 180); // Màu xanh active nổi bật
        }

        /// <summary>
        /// Phân định quyền truy cập hiển thị theo vai trò người dùng (Admin / Cashier / Warehouse)
        /// </summary>
        private void ApplyRolePermissions(string role) {
            switch (role.ToUpper()) {
                case "ADMIN":
                    // Quản trị viên: Có toàn quyền sử dụng tất cả các nút
                    btnPOS.Visible = true;
                    btnCategory.Visible = true;
                    btnProduct.Visible = true;
                    btnCustomer.Visible = true;
                    btnReports.Visible = true;
                    btnUserManage.Visible = true;
                    break;

                case "CASHIER":
                    // Thu ngân: Chỉ truy cập màn hình Bán hàng (POS) và Khách hàng
                    btnPOS.Visible = true;
                    btnCustomer.Visible = true;
                    btnCategory.Visible = false;
                    btnProduct.Visible = false;
                    btnReports.Visible = false;
                    btnUserManage.Visible = false;
                    break;

                case "WAREHOUSE":
                    // Thủ kho: Chỉ quản lý Danh mục nhóm hàng và Sản phẩm tồn kho
                    btnPOS.Visible = false;
                    btnCustomer.Visible = false;
                    btnReports.Visible = false;
                    btnUserManage.Visible = false;
                    btnCategory.Visible = true;
                    btnProduct.Visible = true;
                    break;

                default:
                    // Vai trò không xác định: Khóa toàn bộ
                    MessageBox.Show("Tài khoản chưa được cấp quyền hạn hợp lệ trong hệ thống!", "Cảnh báo phân quyền", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.Close();
                    break;
            }
        }

        /// <summary>
        /// Điều hướng ngay vào màn hình đúng chuyên môn của từng vai trò khi mở Shell
        /// </summary>
        private void OpenDefaultScreenByRole(string role) {
            switch (role.ToUpper()) {
                case "ADMIN":
                    OpenChildForm(new FormCategoryManagement(), "QUẢN LÝ DANH MỤC NHÓM HÀNG", btnCategory);
                    break;
                case "CASHIER":
                    OpenChildForm(new FormPOS(), "HỆ THỐNG QUẦY BÁN HÀNG & THU NGÂN (POS)", btnPOS);
                    break;
                case "WAREHOUSE":
                    OpenChildForm(new FormProductManagement(), "QUẢN LÝ THÔNG TIN SẢN PHẨM & KHO HÀNG", btnProduct);
                    break;
            }
        }

        // ================= CÁC SỰ KIỆN CLICK NÚT TRÊN SIDEBAR =================

        // 1. Quản lý Danh mục (Admin & Warehouse)
        private void btnCategory_Click(object sender, EventArgs e) {
            if (string.Equals(SessionManager.CurrentRole, "Cashier", StringComparison.OrdinalIgnoreCase)) {
                MessageBox.Show("Nhân viên thu ngân không có quyền truy cập quản lý nhóm hàng!", "Từ chối truy cập", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            OpenChildForm(new FormCategoryManagement(), "QUẢN LÝ DANH MỤC NHÓM HÀNG", btnCategory);
        }

        // 2. Bán hàng POS (Admin & Cashier)
        private void btnPOS_Click(object sender, EventArgs e) {
            if (string.Equals(SessionManager.CurrentRole, "Warehouse", StringComparison.OrdinalIgnoreCase)) {
                MessageBox.Show("Thủ kho không có quyền truy cập quầy thu ngân POS!", "Từ chối truy cập", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            OpenChildForm(new FormPOS(), "HỆ THỐNG QUẦY BÁN HÀNG & THU NGÂN (POS)", btnPOS);
        }

        // 3. Quản lý Sản phẩm (Admin & Warehouse)
        private void btnProduct_Click(object sender, EventArgs e) {
            if (string.Equals(SessionManager.CurrentRole, "Cashier", StringComparison.OrdinalIgnoreCase)) {
                MessageBox.Show("Nhân viên thu ngân không có quyền truy cập quản lý sản phẩm!", "Từ chối truy cập", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            OpenChildForm(new FormProductManagement(), "QUẢN LÝ THÔNG TIN SẢN PHẨM & KHO HÀNG", btnProduct);
        }

        // 4. Quản lý Khách hàng (Admin & Cashier)
        private void btnCustomer_Click(object sender, EventArgs e) {
            if (string.Equals(SessionManager.CurrentRole, "Warehouse", StringComparison.OrdinalIgnoreCase)) {
                MessageBox.Show("Thủ kho không có quyền truy cập quản lý khách hàng!", "Từ chối truy cập", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            OpenChildForm(new FormCustomerManagement(), "QUẢN LÝ KHÁCH HÀNG & TÍCH ĐIỂM", btnCustomer);
        }

        // 5. Báo cáo Doanh thu (Chỉ Admin - Cơ chế bảo vệ 2 lớp)
        private void btnReports_Click(object sender, EventArgs e) {
            if (!string.Equals(SessionManager.CurrentRole, "Admin", StringComparison.OrdinalIgnoreCase)) {
                MessageBox.Show("Bạn không có quyền xem dữ liệu tài chính của siêu thị!", "Từ chối truy cập", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            OpenChildForm(new FormQuickReport(), "BÁO CÁO DOANH THU & HIỆU SUẤT CA BÁN", btnReports);
        }

        // 6. Quản trị Tài khoản Người dùng (Chỉ Admin - Cơ chế bảo vệ 2 lớp)
        private void btnUserManage_Click(object sender, EventArgs e) {
            if (!string.Equals(SessionManager.CurrentRole, "Admin", StringComparison.OrdinalIgnoreCase)) {
                MessageBox.Show("Bạn không có quyền quản trị tài khoản hệ thống!", "Từ chối truy cập", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            OpenChildForm(new FormUserManagement(), "QUẢN TRỊ TÀI KHOẢN VÀ PHÂN QUYỀN HỆ THỐNG", btnUserManage);
        }

        // 7. Đăng xuất khỏi hệ thống
        private void btnLogout_Click(object sender, EventArgs e) {
            var confirm = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất phiên làm việc?", "Xác nhận đăng xuất", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes) {
                SessionManager.JwtToken = string.Empty;
                SessionManager.CurrentUsername = string.Empty;
                SessionManager.CurrentFullName = string.Empty;
                SessionManager.CurrentRole = string.Empty;

                this.Hide();
                new FormLogin().ShowDialog();
                this.Close();
            }
        }
    }
}

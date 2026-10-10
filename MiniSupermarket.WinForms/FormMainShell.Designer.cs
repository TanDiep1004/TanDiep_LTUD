namespace MiniSupermarket.WinForms
{
    partial class FormMainShell
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.panelSidebar = new System.Windows.Forms.Panel();
            this.panelMenuButtons = new System.Windows.Forms.Panel();
            this.btnUserManage = new System.Windows.Forms.Button();
            this.btnReports = new System.Windows.Forms.Button();
            this.btnCustomer = new System.Windows.Forms.Button();
            this.btnProduct = new System.Windows.Forms.Button();
            this.btnCategory = new System.Windows.Forms.Button();
            this.btnPOS = new System.Windows.Forms.Button();
            this.panelUserFooter = new System.Windows.Forms.Panel();
            this.picAvatar = new System.Windows.Forms.PictureBox();
            this.lblFooterRole = new System.Windows.Forms.Label();
            this.lblFooterNameShift = new System.Windows.Forms.Label();
            this.btnLogout = new System.Windows.Forms.Button();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.lblLogo = new System.Windows.Forms.Label();
            this.panelTopHeader = new System.Windows.Forms.Panel();
            this.lblUserInfo = new System.Windows.Forms.Label();
            this.btnHeaderLogout = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelMainContent = new System.Windows.Forms.Panel();
            this.panelSidebar.SuspendLayout();
            this.panelMenuButtons.SuspendLayout();
            this.panelUserFooter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).BeginInit();
            this.panelLogo.SuspendLayout();
            this.panelTopHeader.SuspendLayout();
            this.SuspendLayout();

            // panelSidebar
            this.panelSidebar.BackColor = System.Drawing.Color.FromArgb(24, 30, 48);
            this.panelSidebar.Controls.Add(this.panelMenuButtons);
            this.panelSidebar.Controls.Add(this.panelUserFooter);
            this.panelSidebar.Controls.Add(this.panelLogo);
            this.panelSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSidebar.Location = new System.Drawing.Point(0, 0);
            this.panelSidebar.Name = "panelSidebar";
            this.panelSidebar.Size = new System.Drawing.Size(230, 720);
            this.panelSidebar.TabIndex = 0;

            // panelLogo
            this.panelLogo.Controls.Add(this.lblLogo);
            this.panelLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLogo.Location = new System.Drawing.Point(0, 0);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Size = new System.Drawing.Size(230, 70);
            this.panelLogo.TabIndex = 0;

            // lblLogo
            this.lblLogo.AutoSize = true;
            this.lblLogo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblLogo.ForeColor = System.Drawing.Color.White;
            this.lblLogo.Location = new System.Drawing.Point(18, 22);
            this.lblLogo.Name = "lblLogo";
            this.lblLogo.Size = new System.Drawing.Size(176, 25);
            this.lblLogo.TabIndex = 0;
            this.lblLogo.Text = "🛒 Cô Ba Sài Gòn";

            // panelUserFooter
            this.panelUserFooter.BackColor = System.Drawing.Color.FromArgb(22, 26, 40);
            this.panelUserFooter.Controls.Add(this.btnLogout);
            this.panelUserFooter.Controls.Add(this.lblFooterNameShift);
            this.panelUserFooter.Controls.Add(this.lblFooterRole);
            this.panelUserFooter.Controls.Add(this.picAvatar);
            this.panelUserFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelUserFooter.Location = new System.Drawing.Point(0, 620);
            this.panelUserFooter.Name = "panelUserFooter";
            this.panelUserFooter.Size = new System.Drawing.Size(230, 100);
            this.panelUserFooter.TabIndex = 1;

            // picAvatar
            this.picAvatar.Location = new System.Drawing.Point(14, 12);
            this.picAvatar.Name = "picAvatar";
            this.picAvatar.Size = new System.Drawing.Size(38, 38);
            this.picAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picAvatar.TabIndex = 1;
            this.picAvatar.TabStop = false;

            // lblFooterRole
            this.lblFooterRole.AutoSize = true;
            this.lblFooterRole.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.lblFooterRole.ForeColor = System.Drawing.Color.FromArgb(170, 175, 190);
            this.lblFooterRole.Location = new System.Drawing.Point(58, 12);
            this.lblFooterRole.Name = "lblFooterRole";
            this.lblFooterRole.Size = new System.Drawing.Size(60, 15);
            this.lblFooterRole.TabIndex = 2;
            this.lblFooterRole.Text = "Thu ngân:";

            // lblFooterNameShift
            this.lblFooterNameShift.AutoSize = true;
            this.lblFooterNameShift.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblFooterNameShift.ForeColor = System.Drawing.Color.White;
            this.lblFooterNameShift.Location = new System.Drawing.Point(58, 30);
            this.lblFooterNameShift.Name = "lblFooterNameShift";
            this.lblFooterNameShift.Size = new System.Drawing.Size(125, 15);
            this.lblFooterNameShift.TabIndex = 3;
            this.lblFooterNameShift.Text = "Nguyen Van A | Ca 1";

            // btnLogout
            this.btnLogout.BackColor = System.Drawing.Color.FromArgb(36, 40, 56);
            this.btnLogout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnLogout.ForeColor = System.Drawing.Color.FromArgb(220, 225, 235);
            this.btnLogout.Location = new System.Drawing.Point(14, 58);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(202, 32);
            this.btnLogout.TabIndex = 0;
            this.btnLogout.Text = "Đăng xuất";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);

            // panelMenuButtons
            this.panelMenuButtons.Controls.Add(this.btnUserManage);
            this.panelMenuButtons.Controls.Add(this.btnReports);
            this.panelMenuButtons.Controls.Add(this.btnCustomer);
            this.panelMenuButtons.Controls.Add(this.btnProduct);
            this.panelMenuButtons.Controls.Add(this.btnCategory);
            this.panelMenuButtons.Controls.Add(this.btnPOS);
            this.panelMenuButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMenuButtons.Location = new System.Drawing.Point(0, 70);
            this.panelMenuButtons.Name = "panelMenuButtons";
            this.panelMenuButtons.Size = new System.Drawing.Size(230, 590);
            this.panelMenuButtons.TabIndex = 2;

            // btnPOS
            this.btnPOS.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPOS.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnPOS.FlatAppearance.BorderSize = 0;
            this.btnPOS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPOS.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnPOS.ForeColor = System.Drawing.Color.White;
            this.btnPOS.Location = new System.Drawing.Point(0, 0);
            this.btnPOS.Name = "btnPOS";
            this.btnPOS.Padding = new System.Windows.Forms.Padding(18, 0, 0, 0);
            this.btnPOS.Size = new System.Drawing.Size(230, 48);
            this.btnPOS.TabIndex = 0;
            this.btnPOS.Text = "🛒  Bán hàng (POS)";
            this.btnPOS.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPOS.UseVisualStyleBackColor = true;
            this.btnPOS.Click += new System.EventHandler(this.btnPOS_Click);

            // btnCategory
            this.btnCategory.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCategory.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCategory.FlatAppearance.BorderSize = 0;
            this.btnCategory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCategory.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnCategory.ForeColor = System.Drawing.Color.White;
            this.btnCategory.Location = new System.Drawing.Point(0, 48);
            this.btnCategory.Name = "btnCategory";
            this.btnCategory.Padding = new System.Windows.Forms.Padding(18, 0, 0, 0);
            this.btnCategory.Size = new System.Drawing.Size(230, 48);
            this.btnCategory.TabIndex = 1;
            this.btnCategory.Text = "📁  Quản lý Danh mục";
            this.btnCategory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCategory.UseVisualStyleBackColor = true;
            this.btnCategory.Click += new System.EventHandler(this.btnCategory_Click);

            // btnProduct
            this.btnProduct.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnProduct.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnProduct.FlatAppearance.BorderSize = 0;
            this.btnProduct.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProduct.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnProduct.ForeColor = System.Drawing.Color.White;
            this.btnProduct.Location = new System.Drawing.Point(0, 96);
            this.btnProduct.Name = "btnProduct";
            this.btnProduct.Padding = new System.Windows.Forms.Padding(18, 0, 0, 0);
            this.btnProduct.Size = new System.Drawing.Size(230, 48);
            this.btnProduct.TabIndex = 2;
            this.btnProduct.Text = "📦  Quản lý Sản phẩm";
            this.btnProduct.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProduct.UseVisualStyleBackColor = true;
            this.btnProduct.Click += new System.EventHandler(this.btnProduct_Click);

            // btnCustomer
            this.btnCustomer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCustomer.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCustomer.FlatAppearance.BorderSize = 0;
            this.btnCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCustomer.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnCustomer.ForeColor = System.Drawing.Color.White;
            this.btnCustomer.Location = new System.Drawing.Point(0, 144);
            this.btnCustomer.Name = "btnCustomer";
            this.btnCustomer.Padding = new System.Windows.Forms.Padding(18, 0, 0, 0);
            this.btnCustomer.Size = new System.Drawing.Size(230, 48);
            this.btnCustomer.TabIndex = 3;
            this.btnCustomer.Text = "👥  Quản lý Khách hàng";
            this.btnCustomer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCustomer.UseVisualStyleBackColor = true;
            this.btnCustomer.Click += new System.EventHandler(this.btnCustomer_Click);

            // btnReports
            this.btnReports.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReports.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnReports.FlatAppearance.BorderSize = 0;
            this.btnReports.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReports.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnReports.ForeColor = System.Drawing.Color.White;
            this.btnReports.Location = new System.Drawing.Point(0, 192);
            this.btnReports.Name = "btnReports";
            this.btnReports.Padding = new System.Windows.Forms.Padding(18, 0, 0, 0);
            this.btnReports.Size = new System.Drawing.Size(230, 48);
            this.btnReports.TabIndex = 4;
            this.btnReports.Text = "📊  Báo cáo Doanh thu";
            this.btnReports.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReports.UseVisualStyleBackColor = true;
            this.btnReports.Click += new System.EventHandler(this.btnReports_Click);

            // btnUserManage
            this.btnUserManage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUserManage.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnUserManage.FlatAppearance.BorderSize = 0;
            this.btnUserManage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUserManage.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnUserManage.ForeColor = System.Drawing.Color.White;
            this.btnUserManage.Location = new System.Drawing.Point(0, 240);
            this.btnUserManage.Name = "btnUserManage";
            this.btnUserManage.Padding = new System.Windows.Forms.Padding(18, 0, 0, 0);
            this.btnUserManage.Size = new System.Drawing.Size(230, 48);
            this.btnUserManage.TabIndex = 5;
            this.btnUserManage.Text = "🛡  Quản trị Tài khoản";
            this.btnUserManage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUserManage.UseVisualStyleBackColor = true;
            this.btnUserManage.Click += new System.EventHandler(this.btnUserManage_Click);

            // panelTopHeader
            this.panelTopHeader.BackColor = System.Drawing.Color.White;
            this.panelTopHeader.Controls.Add(this.btnHeaderLogout);
            this.panelTopHeader.Controls.Add(this.lblUserInfo);
            this.panelTopHeader.Controls.Add(this.lblTitle);
            this.panelTopHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTopHeader.Location = new System.Drawing.Point(230, 0);
            this.panelTopHeader.Name = "panelTopHeader";
            this.panelTopHeader.Size = new System.Drawing.Size(1050, 60);
            this.panelTopHeader.TabIndex = 1;

            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(24, 30, 48);
            this.lblTitle.Location = new System.Drawing.Point(20, 17);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(248, 25);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "BÀN LÀM VIỆC HỆ THỐNG — CÔ BA SÀI GÒN";

            // lblUserInfo
            this.lblUserInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUserInfo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular);
            this.lblUserInfo.ForeColor = System.Drawing.Color.FromArgb(50, 50, 50);
            this.lblUserInfo.Location = new System.Drawing.Point(580, 18);
            this.lblUserInfo.Name = "lblUserInfo";
            this.lblUserInfo.Size = new System.Drawing.Size(425, 24);
            this.lblUserInfo.TabIndex = 1;
            this.lblUserInfo.Text = "Thu ngân: Nguyen Van A | Ca 1";
            this.lblUserInfo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            // btnHeaderLogout
            this.btnHeaderLogout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHeaderLogout.BackColor = System.Drawing.Color.Transparent;
            this.btnHeaderLogout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHeaderLogout.FlatAppearance.BorderSize = 0;
            this.btnHeaderLogout.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(240, 242, 245);
            this.btnHeaderLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHeaderLogout.Location = new System.Drawing.Point(1010, 16);
            this.btnHeaderLogout.Name = "btnHeaderLogout";
            this.btnHeaderLogout.Size = new System.Drawing.Size(28, 28);
            this.btnHeaderLogout.TabIndex = 2;
            this.btnHeaderLogout.UseVisualStyleBackColor = false;
            this.btnHeaderLogout.Click += new System.EventHandler(this.btnLogout_Click);

            // panelMainContent
            this.panelMainContent.BackColor = System.Drawing.Color.FromArgb(244, 245, 247);
            this.panelMainContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMainContent.Location = new System.Drawing.Point(230, 60);
            this.panelMainContent.Name = "panelMainContent";
            this.panelMainContent.Size = new System.Drawing.Size(1050, 660);
            this.panelMainContent.TabIndex = 2;

            // FormMainShell
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1280, 720);
            this.Controls.Add(this.panelMainContent);
            this.Controls.Add(this.panelTopHeader);
            this.Controls.Add(this.panelSidebar);
            this.MinimumSize = new System.Drawing.Size(1024, 600);
            this.Name = "FormMainShell";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hệ thống Quản lý Bán lẻ & Tồn kho — Cửa hàng Cô Ba Sài Gòn";
            this.Load += new System.EventHandler(this.FormMainShell_Load);
            this.panelSidebar.ResumeLayout(false);
            this.panelMenuButtons.ResumeLayout(false);
            this.panelUserFooter.ResumeLayout(false);
            this.panelUserFooter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).EndInit();
            this.panelLogo.ResumeLayout(false);
            this.panelLogo.PerformLayout();
            this.panelTopHeader.ResumeLayout(false);
            this.panelTopHeader.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel panelSidebar;
        private System.Windows.Forms.Panel panelLogo;
        private System.Windows.Forms.Label lblLogo;
        private System.Windows.Forms.Panel panelMenuButtons;
        private System.Windows.Forms.Button btnPOS;
        private System.Windows.Forms.Button btnCategory;
        private System.Windows.Forms.Button btnProduct;
        private System.Windows.Forms.Button btnCustomer;
        private System.Windows.Forms.Button btnReports;
        private System.Windows.Forms.Button btnUserManage;
        private System.Windows.Forms.Panel panelUserFooter;
        private System.Windows.Forms.PictureBox picAvatar;
        private System.Windows.Forms.Label lblFooterRole;
        private System.Windows.Forms.Label lblFooterNameShift;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Panel panelTopHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblUserInfo;
        private System.Windows.Forms.Button btnHeaderLogout;
        private System.Windows.Forms.Panel panelMainContent;
    }
}

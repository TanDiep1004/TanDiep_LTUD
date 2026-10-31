namespace MiniSupermarket.WinForms
{
    partial class FormProductManagement
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
            this.components = new System.ComponentModel.Container();
            this.panelTopBanner = new System.Windows.Forms.Panel();
            this.lblPageTitle = new System.Windows.Forms.Label();

            this.panelBottomDetail = new System.Windows.Forms.Panel();
            this.lblDetailCardTitle = new System.Windows.Forms.Label();
            this.lblDetailImgLabel = new System.Windows.Forms.Label();
            this.picProductDetail = new System.Windows.Forms.PictureBox();
            this.txtDetailProductName = new System.Windows.Forms.TextBox();
            this.lblDetailRetail = new System.Windows.Forms.Label();
            this.txtDetailRetailPrice = new System.Windows.Forms.TextBox();
            this.lblDetailWholesale = new System.Windows.Forms.Label();
            this.txtDetailWholesalePrice = new System.Windows.Forms.TextBox();
            this.lblDetailDesc = new System.Windows.Forms.Label();
            this.txtDetailDescription = new System.Windows.Forms.TextBox();

            this.panelBottomSpacer = new System.Windows.Forms.Panel();

            this.panelUpperArea = new System.Windows.Forms.Panel();
            this.panelCenterArea = new System.Windows.Forms.Panel();
            this.panelRightCol = new System.Windows.Forms.Panel();

            // Filter Bar (Top of Center Area)
            this.panelFilterBar = new System.Windows.Forms.Panel();
            this.lblSearchBarTitle = new System.Windows.Forms.Label();
            this.txtKeyword = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.lblFilterCatTitle = new System.Windows.Forms.Label();
            this.cboFilterCategory = new System.Windows.Forms.ComboBox();
            this.lblFilterStatusTitle = new System.Windows.Forms.Label();
            this.cboFilterStatus = new System.Windows.Forms.ComboBox();

            this.panelCenterSpacer = new System.Windows.Forms.Panel();

            // Grid Card (Fill of Center Area)
            this.panelGridCard = new System.Windows.Forms.Panel();
            this.panelGridHeader = new System.Windows.Forms.Panel();
            this.lblGridTitle = new System.Windows.Forms.Label();
            this.btnPrevPage = new System.Windows.Forms.Button();
            this.lblPageInfo = new System.Windows.Forms.Label();
            this.btnNextPage = new System.Windows.Forms.Button();
            this.btnHeaderEdit = new System.Windows.Forms.Button();
            this.btnHeaderPrice = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.dgvProducts = new System.Windows.Forms.DataGridView();

            // Right Column (Quick Actions + Quick Info)
            this.panelQuickActionsCard = new System.Windows.Forms.Panel();
            this.lblQuickActionsTitle = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnImportExcel = new System.Windows.Forms.Button();
            this.btnExportExcel = new System.Windows.Forms.Button();
            this.btnUpdateWholesale = new System.Windows.Forms.Button();

            this.panelRightSpacer = new System.Windows.Forms.Panel();

            this.panelQuickPreviewCard = new System.Windows.Forms.Panel();
            this.lblQuickPreviewTitle = new System.Windows.Forms.Label();
            this.lblQuickStockInfo = new System.Windows.Forms.Label();
            this.btnUpdate = new System.Windows.Forms.Button();

            // Context Menu
            this.cmsProductActions = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuEditProduct = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuUpdatePrice = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuViewDetail = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDeleteProduct = new System.Windows.Forms.ToolStripMenuItem();

            this.panelTopBanner.SuspendLayout();
            this.panelBottomDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picProductDetail)).BeginInit();
            this.panelUpperArea.SuspendLayout();
            this.panelCenterArea.SuspendLayout();
            this.panelRightCol.SuspendLayout();
            this.panelFilterBar.SuspendLayout();
            this.panelGridCard.SuspendLayout();
            this.panelGridHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).BeginInit();
            this.panelQuickActionsCard.SuspendLayout();
            this.panelQuickPreviewCard.SuspendLayout();
            this.cmsProductActions.SuspendLayout();
            this.SuspendLayout();

            // panelTopBanner
            this.panelTopBanner.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            this.panelTopBanner.Controls.Add(this.lblPageTitle);
            this.panelTopBanner.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTopBanner.Location = new System.Drawing.Point(12, 4);
            this.panelTopBanner.Name = "panelTopBanner";
            this.panelTopBanner.Size = new System.Drawing.Size(1026, 36);
            this.panelTopBanner.TabIndex = 0;

            // lblPageTitle
            this.lblPageTitle.AutoSize = true;
            this.lblPageTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblPageTitle.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.lblPageTitle.Location = new System.Drawing.Point(2, 4);
            this.lblPageTitle.Name = "lblPageTitle";
            this.lblPageTitle.Size = new System.Drawing.Size(272, 25);
            this.lblPageTitle.TabIndex = 0;
            this.lblPageTitle.Text = "DANH MỤC SẢN PHẨM & GIÁ";

            // panelBottomDetail
            this.panelBottomDetail.BackColor = System.Drawing.Color.White;
            this.panelBottomDetail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelBottomDetail.Controls.Add(this.txtDetailDescription);
            this.panelBottomDetail.Controls.Add(this.lblDetailDesc);
            this.panelBottomDetail.Controls.Add(this.txtDetailWholesalePrice);
            this.panelBottomDetail.Controls.Add(this.lblDetailWholesale);
            this.panelBottomDetail.Controls.Add(this.txtDetailRetailPrice);
            this.panelBottomDetail.Controls.Add(this.lblDetailRetail);
            this.panelBottomDetail.Controls.Add(this.txtDetailProductName);
            this.panelBottomDetail.Controls.Add(this.picProductDetail);
            this.panelBottomDetail.Controls.Add(this.lblDetailImgLabel);
            this.panelBottomDetail.Controls.Add(this.lblDetailCardTitle);
            this.panelBottomDetail.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottomDetail.Location = new System.Drawing.Point(12, 474);
            this.panelBottomDetail.Name = "panelBottomDetail";
            this.panelBottomDetail.Padding = new System.Windows.Forms.Padding(12, 8, 12, 8);
            this.panelBottomDetail.Size = new System.Drawing.Size(1026, 158);
            this.panelBottomDetail.TabIndex = 2;

            // lblDetailCardTitle
            this.lblDetailCardTitle.AutoSize = true;
            this.lblDetailCardTitle.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.lblDetailCardTitle.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.lblDetailCardTitle.Location = new System.Drawing.Point(12, 8);
            this.lblDetailCardTitle.Name = "lblDetailCardTitle";
            this.lblDetailCardTitle.Size = new System.Drawing.Size(124, 19);
            this.lblDetailCardTitle.TabIndex = 0;
            this.lblDetailCardTitle.Text = "Xem chi tiết SP";

            // lblDetailImgLabel
            this.lblDetailImgLabel.AutoSize = true;
            this.lblDetailImgLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDetailImgLabel.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
            this.lblDetailImgLabel.Location = new System.Drawing.Point(14, 34);
            this.lblDetailImgLabel.Name = "lblDetailImgLabel";
            this.lblDetailImgLabel.Size = new System.Drawing.Size(76, 15);
            this.lblDetailImgLabel.TabIndex = 1;
            this.lblDetailImgLabel.Text = "Hình ảnh SP:";

            // picProductDetail
            this.picProductDetail.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            this.picProductDetail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picProductDetail.Location = new System.Drawing.Point(16, 54);
            this.picProductDetail.Name = "picProductDetail";
            this.picProductDetail.Size = new System.Drawing.Size(88, 88);
            this.picProductDetail.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picProductDetail.TabIndex = 2;
            this.picProductDetail.TabStop = false;

            // txtDetailProductName
            this.txtDetailProductName.BackColor = System.Drawing.Color.White;
            this.txtDetailProductName.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.txtDetailProductName.Location = new System.Drawing.Point(124, 30);
            this.txtDetailProductName.Name = "txtDetailProductName";
            this.txtDetailProductName.ReadOnly = true;
            this.txtDetailProductName.Size = new System.Drawing.Size(260, 24);
            this.txtDetailProductName.TabIndex = 3;

            // lblDetailRetail
            this.lblDetailRetail.AutoSize = true;
            this.lblDetailRetail.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDetailRetail.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
            this.lblDetailRetail.Location = new System.Drawing.Point(400, 34);
            this.lblDetailRetail.Name = "lblDetailRetail";
            this.lblDetailRetail.Size = new System.Drawing.Size(65, 15);
            this.lblDetailRetail.TabIndex = 4;
            this.lblDetailRetail.Text = "Giá bán lẻ:";

            // txtDetailRetailPrice
            this.txtDetailRetailPrice.BackColor = System.Drawing.Color.White;
            this.txtDetailRetailPrice.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.txtDetailRetailPrice.ForeColor = System.Drawing.Color.FromArgb(22, 101, 52);
            this.txtDetailRetailPrice.Location = new System.Drawing.Point(470, 30);
            this.txtDetailRetailPrice.Name = "txtDetailRetailPrice";
            this.txtDetailRetailPrice.ReadOnly = true;
            this.txtDetailRetailPrice.Size = new System.Drawing.Size(210, 24);
            this.txtDetailRetailPrice.TabIndex = 5;

            // lblDetailWholesale
            this.lblDetailWholesale.AutoSize = true;
            this.lblDetailWholesale.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDetailWholesale.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
            this.lblDetailWholesale.Location = new System.Drawing.Point(700, 34);
            this.lblDetailWholesale.Name = "lblDetailWholesale";
            this.lblDetailWholesale.Size = new System.Drawing.Size(64, 15);
            this.lblDetailWholesale.TabIndex = 6;
            this.lblDetailWholesale.Text = "Giá bán sỉ:";

            // txtDetailWholesalePrice
            this.txtDetailWholesalePrice.BackColor = System.Drawing.Color.White;
            this.txtDetailWholesalePrice.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtDetailWholesalePrice.Location = new System.Drawing.Point(770, 30);
            this.txtDetailWholesalePrice.Name = "txtDetailWholesalePrice";
            this.txtDetailWholesalePrice.ReadOnly = true;
            this.txtDetailWholesalePrice.Size = new System.Drawing.Size(235, 24);
            this.txtDetailWholesalePrice.TabIndex = 7;

            // lblDetailDesc
            this.lblDetailDesc.AutoSize = true;
            this.lblDetailDesc.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDetailDesc.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
            this.lblDetailDesc.Location = new System.Drawing.Point(124, 62);
            this.lblDetailDesc.Name = "lblDetailDesc";
            this.lblDetailDesc.Size = new System.Drawing.Size(83, 15);
            this.lblDetailDesc.TabIndex = 8;
            this.lblDetailDesc.Text = "Mô tả chi tiết:";

            // txtDetailDescription
            this.txtDetailDescription.BackColor = System.Drawing.Color.White;
            this.txtDetailDescription.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtDetailDescription.Location = new System.Drawing.Point(124, 82);
            this.txtDetailDescription.Multiline = true;
            this.txtDetailDescription.Name = "txtDetailDescription";
            this.txtDetailDescription.ReadOnly = true;
            this.txtDetailDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDetailDescription.Size = new System.Drawing.Size(881, 60);
            this.txtDetailDescription.TabIndex = 9;

            // panelBottomSpacer
            this.panelBottomSpacer.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottomSpacer.Location = new System.Drawing.Point(12, 464);
            this.panelBottomSpacer.Name = "panelBottomSpacer";
            this.panelBottomSpacer.Size = new System.Drawing.Size(1026, 10);
            this.panelBottomSpacer.TabIndex = 3;

            // panelUpperArea
            this.panelUpperArea.Controls.Add(this.panelCenterArea);
            this.panelUpperArea.Controls.Add(this.panelRightCol);
            this.panelUpperArea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelUpperArea.Location = new System.Drawing.Point(12, 40);
            this.panelUpperArea.Name = "panelUpperArea";
            this.panelUpperArea.Size = new System.Drawing.Size(1026, 424);
            this.panelUpperArea.TabIndex = 1;

            // panelCenterArea
            this.panelCenterArea.Controls.Add(this.panelGridCard);
            this.panelCenterArea.Controls.Add(this.panelCenterSpacer);
            this.panelCenterArea.Controls.Add(this.panelFilterBar);
            this.panelCenterArea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCenterArea.Location = new System.Drawing.Point(0, 0);
            this.panelCenterArea.Name = "panelCenterArea";
            this.panelCenterArea.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.panelCenterArea.Size = new System.Drawing.Size(844, 424);
            this.panelCenterArea.TabIndex = 0;

            // panelFilterBar
            this.panelFilterBar.BackColor = System.Drawing.Color.White;
            this.panelFilterBar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelFilterBar.Controls.Add(this.cboFilterStatus);
            this.panelFilterBar.Controls.Add(this.lblFilterStatusTitle);
            this.panelFilterBar.Controls.Add(this.cboFilterCategory);
            this.panelFilterBar.Controls.Add(this.lblFilterCatTitle);
            this.panelFilterBar.Controls.Add(this.btnLoad);
            this.panelFilterBar.Controls.Add(this.btnSearch);
            this.panelFilterBar.Controls.Add(this.txtKeyword);
            this.panelFilterBar.Controls.Add(this.lblSearchBarTitle);
            this.panelFilterBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelFilterBar.Location = new System.Drawing.Point(0, 0);
            this.panelFilterBar.Name = "panelFilterBar";
            this.panelFilterBar.Size = new System.Drawing.Size(834, 92);
            this.panelFilterBar.TabIndex = 0;

            // lblSearchBarTitle
            this.lblSearchBarTitle.AutoSize = true;
            this.lblSearchBarTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblSearchBarTitle.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.lblSearchBarTitle.Location = new System.Drawing.Point(12, 8);
            this.lblSearchBarTitle.Name = "lblSearchBarTitle";
            this.lblSearchBarTitle.Size = new System.Drawing.Size(79, 19);
            this.lblSearchBarTitle.TabIndex = 0;
            this.lblSearchBarTitle.Text = "Search Bar";

            // txtKeyword
            this.txtKeyword.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtKeyword.Location = new System.Drawing.Point(14, 30);
            this.txtKeyword.Name = "txtKeyword";
            this.txtKeyword.PlaceholderText = "🔍 Quét mã, nhập tên SP hoặc mã vạch...";
            this.txtKeyword.Size = new System.Drawing.Size(370, 24);
            this.txtKeyword.TabIndex = 1;
            this.txtKeyword.TextChanged += new System.EventHandler(this.txtKeyword_TextChanged);
            this.txtKeyword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtKeyword_KeyDown);

            // btnSearch
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(29, 112, 184);
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(216, 58);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(86, 26);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);

            // btnLoad
            this.btnLoad.BackColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.btnLoad.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLoad.FlatAppearance.BorderSize = 0;
            this.btnLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoad.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnLoad.ForeColor = System.Drawing.Color.White;
            this.btnLoad.Location = new System.Drawing.Point(308, 58);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(76, 26);
            this.btnLoad.TabIndex = 3;
            this.btnLoad.Text = "Clear";
            this.btnLoad.UseVisualStyleBackColor = false;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);

            // lblFilterCatTitle
            this.lblFilterCatTitle.AutoSize = true;
            this.lblFilterCatTitle.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblFilterCatTitle.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
            this.lblFilterCatTitle.Location = new System.Drawing.Point(412, 8);
            this.lblFilterCatTitle.Name = "lblFilterCatTitle";
            this.lblFilterCatTitle.Size = new System.Drawing.Size(82, 17);
            this.lblFilterCatTitle.TabIndex = 4;
            this.lblFilterCatTitle.Text = "Ngành hàng:";

            // cboFilterCategory
            this.cboFilterCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFilterCategory.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cboFilterCategory.FormattingEnabled = true;
            this.cboFilterCategory.Location = new System.Drawing.Point(414, 30);
            this.cboFilterCategory.Name = "cboFilterCategory";
            this.cboFilterCategory.Size = new System.Drawing.Size(205, 25);
            this.cboFilterCategory.TabIndex = 5;
            this.cboFilterCategory.SelectedIndexChanged += new System.EventHandler(this.FilterCombo_SelectedIndexChanged);

            // lblFilterStatusTitle
            this.lblFilterStatusTitle.AutoSize = true;
            this.lblFilterStatusTitle.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblFilterStatusTitle.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
            this.lblFilterStatusTitle.Location = new System.Drawing.Point(642, 8);
            this.lblFilterStatusTitle.Name = "lblFilterStatusTitle";
            this.lblFilterStatusTitle.Size = new System.Drawing.Size(68, 17);
            this.lblFilterStatusTitle.TabIndex = 6;
            this.lblFilterStatusTitle.Text = "Trạng thái:";

            // cboFilterStatus
            this.cboFilterStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFilterStatus.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cboFilterStatus.FormattingEnabled = true;
            this.cboFilterStatus.Items.AddRange(new object[] {
                "All",
                "Đang bán",
                "Ngừng bán"
            });
            this.cboFilterStatus.Location = new System.Drawing.Point(644, 30);
            this.cboFilterStatus.Name = "cboFilterStatus";
            this.cboFilterStatus.Size = new System.Drawing.Size(172, 25);
            this.cboFilterStatus.TabIndex = 7;
            this.cboFilterStatus.SelectedIndexChanged += new System.EventHandler(this.FilterCombo_SelectedIndexChanged);

            // panelCenterSpacer
            this.panelCenterSpacer.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelCenterSpacer.Location = new System.Drawing.Point(0, 92);
            this.panelCenterSpacer.Name = "panelCenterSpacer";
            this.panelCenterSpacer.Size = new System.Drawing.Size(834, 8);
            this.panelCenterSpacer.TabIndex = 1;

            // panelGridCard
            this.panelGridCard.BackColor = System.Drawing.Color.White;
            this.panelGridCard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelGridCard.Controls.Add(this.dgvProducts);
            this.panelGridCard.Controls.Add(this.panelGridHeader);
            this.panelGridCard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelGridCard.Location = new System.Drawing.Point(0, 100);
            this.panelGridCard.Name = "panelGridCard";
            this.panelGridCard.Padding = new System.Windows.Forms.Padding(10, 6, 10, 8);
            this.panelGridCard.Size = new System.Drawing.Size(834, 324);
            this.panelGridCard.TabIndex = 2;

            // panelGridHeader
            this.panelGridHeader.Controls.Add(this.btnNextPage);
            this.panelGridHeader.Controls.Add(this.lblPageInfo);
            this.panelGridHeader.Controls.Add(this.btnPrevPage);
            this.panelGridHeader.Controls.Add(this.btnDelete);
            this.panelGridHeader.Controls.Add(this.btnHeaderPrice);
            this.panelGridHeader.Controls.Add(this.btnHeaderEdit);
            this.panelGridHeader.Controls.Add(this.lblGridTitle);
            this.panelGridHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelGridHeader.Location = new System.Drawing.Point(10, 6);
            this.panelGridHeader.Name = "panelGridHeader";
            this.panelGridHeader.Size = new System.Drawing.Size(812, 32);
            this.panelGridHeader.TabIndex = 0;

            // lblGridTitle
            this.lblGridTitle.AutoSize = true;
            this.lblGridTitle.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.lblGridTitle.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.lblGridTitle.Location = new System.Drawing.Point(0, 5);
            this.lblGridTitle.Name = "lblGridTitle";
            this.lblGridTitle.Size = new System.Drawing.Size(222, 19);
            this.lblGridTitle.TabIndex = 0;
            this.lblGridTitle.Text = "BẢNG DANH MỤC SẢN PHẨM";

            // btnPrevPage
            this.btnPrevPage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrevPage.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            this.btnPrevPage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrevPage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrevPage.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.btnPrevPage.Location = new System.Drawing.Point(478, 3);
            this.btnPrevPage.Name = "btnPrevPage";
            this.btnPrevPage.Size = new System.Drawing.Size(64, 25);
            this.btnPrevPage.TabIndex = 1;
            this.btnPrevPage.Text = "◀ Trước";
            this.btnPrevPage.UseVisualStyleBackColor = false;
            this.btnPrevPage.Click += new System.EventHandler(this.btnPrevPage_Click);

            // lblPageInfo
            this.lblPageInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPageInfo.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblPageInfo.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.lblPageInfo.Location = new System.Drawing.Point(544, 5);
            this.lblPageInfo.Name = "lblPageInfo";
            this.lblPageInfo.Size = new System.Drawing.Size(80, 20);
            this.lblPageInfo.TabIndex = 2;
            this.lblPageInfo.Text = "Trang 1 / 4";
            this.lblPageInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // btnNextPage
            this.btnNextPage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNextPage.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            this.btnNextPage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNextPage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNextPage.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.btnNextPage.Location = new System.Drawing.Point(626, 3);
            this.btnNextPage.Name = "btnNextPage";
            this.btnNextPage.Size = new System.Drawing.Size(64, 25);
            this.btnNextPage.TabIndex = 3;
            this.btnNextPage.Text = "Sau ▶";
            this.btnNextPage.UseVisualStyleBackColor = false;
            this.btnNextPage.Click += new System.EventHandler(this.btnNextPage_Click);

            // btnHeaderEdit
            this.btnHeaderEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHeaderEdit.BackColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.btnHeaderEdit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHeaderEdit.FlatAppearance.BorderSize = 0;
            this.btnHeaderEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHeaderEdit.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.btnHeaderEdit.ForeColor = System.Drawing.Color.White;
            this.btnHeaderEdit.Location = new System.Drawing.Point(710, 3);
            this.btnHeaderEdit.Name = "btnHeaderEdit";
            this.btnHeaderEdit.Size = new System.Drawing.Size(30, 25);
            this.btnHeaderEdit.TabIndex = 4;
            this.btnHeaderEdit.Text = "✎";
            this.btnHeaderEdit.UseVisualStyleBackColor = false;
            this.btnHeaderEdit.Click += new System.EventHandler(this.btnUpdate_Click);

            // btnHeaderPrice
            this.btnHeaderPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHeaderPrice.BackColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.btnHeaderPrice.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHeaderPrice.FlatAppearance.BorderSize = 0;
            this.btnHeaderPrice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHeaderPrice.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.btnHeaderPrice.ForeColor = System.Drawing.Color.White;
            this.btnHeaderPrice.Location = new System.Drawing.Point(744, 3);
            this.btnHeaderPrice.Name = "btnHeaderPrice";
            this.btnHeaderPrice.Size = new System.Drawing.Size(30, 25);
            this.btnHeaderPrice.TabIndex = 5;
            this.btnHeaderPrice.Text = "☰";
            this.btnHeaderPrice.UseVisualStyleBackColor = false;
            this.btnHeaderPrice.Click += new System.EventHandler(this.mnuUpdatePrice_Click);

            // btnDelete
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(778, 3);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(30, 25);
            this.btnDelete.TabIndex = 6;
            this.btnDelete.Text = "🗑";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);

            // dgvProducts
            this.dgvProducts.AllowUserToAddRows = false;
            this.dgvProducts.AllowUserToDeleteRows = false;
            this.dgvProducts.AllowUserToResizeRows = false;
            this.dgvProducts.BackgroundColor = System.Drawing.Color.White;
            this.dgvProducts.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dgvProducts.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Single;
            this.dgvProducts.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvProducts.ColumnHeadersHeight = 30;
            this.dgvProducts.ContextMenuStrip = this.cmsProductActions;
            this.dgvProducts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvProducts.EnableHeadersVisualStyles = false;
            this.dgvProducts.GridColor = System.Drawing.Color.FromArgb(226, 232, 240);
            this.dgvProducts.Location = new System.Drawing.Point(10, 38);
            this.dgvProducts.MultiSelect = false;
            this.dgvProducts.Name = "dgvProducts";
            this.dgvProducts.ReadOnly = true;
            this.dgvProducts.RowHeadersVisible = false;
            this.dgvProducts.RowTemplate.Height = 28;
            this.dgvProducts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProducts.Size = new System.Drawing.Size(812, 276);
            this.dgvProducts.TabIndex = 1;
            this.dgvProducts.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProducts_CellClick);
            this.dgvProducts.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProducts_CellDoubleClick);
            this.dgvProducts.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvProducts_CellMouseDown);

            // panelRightCol
            this.panelRightCol.Controls.Add(this.panelQuickPreviewCard);
            this.panelRightCol.Controls.Add(this.panelRightSpacer);
            this.panelRightCol.Controls.Add(this.panelQuickActionsCard);
            this.panelRightCol.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelRightCol.Location = new System.Drawing.Point(844, 0);
            this.panelRightCol.Name = "panelRightCol";
            this.panelRightCol.Size = new System.Drawing.Size(182, 424);
            this.panelRightCol.TabIndex = 1;

            // panelQuickActionsCard
            this.panelQuickActionsCard.BackColor = System.Drawing.Color.White;
            this.panelQuickActionsCard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelQuickActionsCard.Controls.Add(this.btnUpdateWholesale);
            this.panelQuickActionsCard.Controls.Add(this.btnExportExcel);
            this.panelQuickActionsCard.Controls.Add(this.btnImportExcel);
            this.panelQuickActionsCard.Controls.Add(this.btnAdd);
            this.panelQuickActionsCard.Controls.Add(this.lblQuickActionsTitle);
            this.panelQuickActionsCard.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelQuickActionsCard.Location = new System.Drawing.Point(0, 0);
            this.panelQuickActionsCard.Name = "panelQuickActionsCard";
            this.panelQuickActionsCard.Padding = new System.Windows.Forms.Padding(12, 10, 12, 10);
            this.panelQuickActionsCard.Size = new System.Drawing.Size(182, 206);
            this.panelQuickActionsCard.TabIndex = 0;

            // lblQuickActionsTitle
            this.lblQuickActionsTitle.AutoSize = true;
            this.lblQuickActionsTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblQuickActionsTitle.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.lblQuickActionsTitle.Location = new System.Drawing.Point(10, 10);
            this.lblQuickActionsTitle.Name = "lblQuickActionsTitle";
            this.lblQuickActionsTitle.Size = new System.Drawing.Size(134, 19);
            this.lblQuickActionsTitle.TabIndex = 0;
            this.lblQuickActionsTitle.Text = "THAO TÁC NHANH";

            // btnAdd
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(229, 231, 235);
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdd.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(209, 213, 219);
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnAdd.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.btnAdd.Location = new System.Drawing.Point(12, 36);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(156, 34);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "Thêm SP mới (F3)";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);

            // btnImportExcel
            this.btnImportExcel.BackColor = System.Drawing.Color.FromArgb(229, 231, 235);
            this.btnImportExcel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnImportExcel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(209, 213, 219);
            this.btnImportExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImportExcel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnImportExcel.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.btnImportExcel.Location = new System.Drawing.Point(12, 76);
            this.btnImportExcel.Name = "btnImportExcel";
            this.btnImportExcel.Size = new System.Drawing.Size(156, 34);
            this.btnImportExcel.TabIndex = 2;
            this.btnImportExcel.Text = "Nhập Excel";
            this.btnImportExcel.UseVisualStyleBackColor = false;
            this.btnImportExcel.Click += new System.EventHandler(this.btnImportExcel_Click);

            // btnExportExcel
            this.btnExportExcel.BackColor = System.Drawing.Color.FromArgb(229, 231, 235);
            this.btnExportExcel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExportExcel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(209, 213, 219);
            this.btnExportExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportExcel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnExportExcel.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.btnExportExcel.Location = new System.Drawing.Point(12, 116);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Size = new System.Drawing.Size(156, 34);
            this.btnExportExcel.TabIndex = 3;
            this.btnExportExcel.Text = "Xuất Excel";
            this.btnExportExcel.UseVisualStyleBackColor = false;
            this.btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click);

            // btnUpdateWholesale
            this.btnUpdateWholesale.BackColor = System.Drawing.Color.FromArgb(229, 231, 235);
            this.btnUpdateWholesale.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUpdateWholesale.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(209, 213, 219);
            this.btnUpdateWholesale.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdateWholesale.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnUpdateWholesale.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.btnUpdateWholesale.Location = new System.Drawing.Point(12, 156);
            this.btnUpdateWholesale.Name = "btnUpdateWholesale";
            this.btnUpdateWholesale.Size = new System.Drawing.Size(156, 34);
            this.btnUpdateWholesale.TabIndex = 4;
            this.btnUpdateWholesale.Text = "Cập nhật Giá sỉ";
            this.btnUpdateWholesale.UseVisualStyleBackColor = false;
            this.btnUpdateWholesale.Click += new System.EventHandler(this.mnuUpdatePrice_Click);

            // panelRightSpacer
            this.panelRightSpacer.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelRightSpacer.Location = new System.Drawing.Point(0, 206);
            this.panelRightSpacer.Name = "panelRightSpacer";
            this.panelRightSpacer.Size = new System.Drawing.Size(182, 8);
            this.panelRightSpacer.TabIndex = 1;

            // panelQuickPreviewCard
            this.panelQuickPreviewCard.BackColor = System.Drawing.Color.White;
            this.panelQuickPreviewCard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelQuickPreviewCard.Controls.Add(this.btnUpdate);
            this.panelQuickPreviewCard.Controls.Add(this.lblQuickStockInfo);
            this.panelQuickPreviewCard.Controls.Add(this.lblQuickPreviewTitle);
            this.panelQuickPreviewCard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelQuickPreviewCard.Location = new System.Drawing.Point(0, 214);
            this.panelQuickPreviewCard.Name = "panelQuickPreviewCard";
            this.panelQuickPreviewCard.Padding = new System.Windows.Forms.Padding(12, 10, 12, 10);
            this.panelQuickPreviewCard.Size = new System.Drawing.Size(182, 210);
            this.panelQuickPreviewCard.TabIndex = 2;

            // lblQuickPreviewTitle
            this.lblQuickPreviewTitle.AutoSize = true;
            this.lblQuickPreviewTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblQuickPreviewTitle.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.lblQuickPreviewTitle.Location = new System.Drawing.Point(10, 10);
            this.lblQuickPreviewTitle.Name = "lblQuickPreviewTitle";
            this.lblQuickPreviewTitle.Size = new System.Drawing.Size(96, 19);
            this.lblQuickPreviewTitle.TabIndex = 0;
            this.lblQuickPreviewTitle.Text = "Xem nhanh SP";

            // lblQuickStockInfo
            this.lblQuickStockInfo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblQuickStockInfo.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
            this.lblQuickStockInfo.Location = new System.Drawing.Point(10, 38);
            this.lblQuickStockInfo.Name = "lblQuickStockInfo";
            this.lblQuickStockInfo.Size = new System.Drawing.Size(158, 110);
            this.lblQuickStockInfo.TabIndex = 1;
            this.lblQuickStockInfo.Text = "Chọn sản phẩm trên bảng để xem tồn kho & sửa nhanh.";

            // btnUpdate
            this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnUpdate.BackColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.btnUpdate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUpdate.FlatAppearance.BorderSize = 0;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnUpdate.ForeColor = System.Drawing.Color.White;
            this.btnUpdate.Location = new System.Drawing.Point(12, 160);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(156, 36);
            this.btnUpdate.TabIndex = 2;
            this.btnUpdate.Text = "✎ Sửa sản phẩm";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);

            // cmsProductActions
            this.cmsProductActions.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmsProductActions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.mnuEditProduct,
                this.mnuUpdatePrice,
                this.mnuViewDetail,
                this.mnuDeleteProduct
            });
            this.cmsProductActions.Name = "cmsProductActions";
            this.cmsProductActions.Size = new System.Drawing.Size(165, 92);

            // mnuEditProduct
            this.mnuEditProduct.Name = "mnuEditProduct";
            this.mnuEditProduct.Size = new System.Drawing.Size(164, 22);
            this.mnuEditProduct.Text = "Sửa sản phẩm";
            this.mnuEditProduct.Click += new System.EventHandler(this.btnUpdate_Click);

            // mnuUpdatePrice
            this.mnuUpdatePrice.Name = "mnuUpdatePrice";
            this.mnuUpdatePrice.Size = new System.Drawing.Size(164, 22);
            this.mnuUpdatePrice.Text = "Cập nhật giá";
            this.mnuUpdatePrice.Click += new System.EventHandler(this.mnuUpdatePrice_Click);

            // mnuViewDetail
            this.mnuViewDetail.Name = "mnuViewDetail";
            this.mnuViewDetail.Size = new System.Drawing.Size(164, 22);
            this.mnuViewDetail.Text = "Xem chi tiết";
            this.mnuViewDetail.Click += new System.EventHandler(this.mnuViewDetail_Click);

            // mnuDeleteProduct
            this.mnuDeleteProduct.Name = "mnuDeleteProduct";
            this.mnuDeleteProduct.Size = new System.Drawing.Size(164, 22);
            this.mnuDeleteProduct.Text = "Xóa sản phẩm";
            this.mnuDeleteProduct.Click += new System.EventHandler(this.btnDelete_Click);

            // FormProductManagement
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            this.ClientSize = new System.Drawing.Size(1050, 640);
            this.Controls.Add(this.panelUpperArea);
            this.Controls.Add(this.panelBottomSpacer);
            this.Controls.Add(this.panelBottomDetail);
            this.Controls.Add(this.panelTopBanner);
            this.KeyPreview = true;
            this.Name = "FormProductManagement";
            this.Padding = new System.Windows.Forms.Padding(12, 4, 12, 8);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DANH MỤC SẢN PHẨM & GIÁ";
            this.Load += new System.EventHandler(this.FormProductManagement_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormProductManagement_KeyDown);

            this.panelTopBanner.ResumeLayout(false);
            this.panelTopBanner.PerformLayout();
            this.panelBottomDetail.ResumeLayout(false);
            this.panelBottomDetail.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picProductDetail)).EndInit();
            this.panelUpperArea.ResumeLayout(false);
            this.panelCenterArea.ResumeLayout(false);
            this.panelRightCol.ResumeLayout(false);
            this.panelFilterBar.ResumeLayout(false);
            this.panelFilterBar.PerformLayout();
            this.panelGridCard.ResumeLayout(false);
            this.panelGridHeader.ResumeLayout(false);
            this.panelGridHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).EndInit();
            this.panelQuickActionsCard.ResumeLayout(false);
            this.panelQuickActionsCard.PerformLayout();
            this.panelQuickPreviewCard.ResumeLayout(false);
            this.panelQuickPreviewCard.PerformLayout();
            this.cmsProductActions.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel panelTopBanner;
        private System.Windows.Forms.Label lblPageTitle;
        private System.Windows.Forms.Panel panelBottomDetail;
        private System.Windows.Forms.Label lblDetailCardTitle;
        private System.Windows.Forms.Label lblDetailImgLabel;
        private System.Windows.Forms.PictureBox picProductDetail;
        private System.Windows.Forms.TextBox txtDetailProductName;
        private System.Windows.Forms.Label lblDetailRetail;
        private System.Windows.Forms.TextBox txtDetailRetailPrice;
        private System.Windows.Forms.Label lblDetailWholesale;
        private System.Windows.Forms.TextBox txtDetailWholesalePrice;
        private System.Windows.Forms.Label lblDetailDesc;
        private System.Windows.Forms.TextBox txtDetailDescription;
        private System.Windows.Forms.Panel panelBottomSpacer;
        private System.Windows.Forms.Panel panelUpperArea;
        private System.Windows.Forms.Panel panelCenterArea;
        private System.Windows.Forms.Panel panelRightCol;
        private System.Windows.Forms.Panel panelFilterBar;
        private System.Windows.Forms.Label lblSearchBarTitle;
        private System.Windows.Forms.TextBox txtKeyword;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Label lblFilterCatTitle;
        private System.Windows.Forms.ComboBox cboFilterCategory;
        private System.Windows.Forms.Label lblFilterStatusTitle;
        private System.Windows.Forms.ComboBox cboFilterStatus;
        private System.Windows.Forms.Panel panelCenterSpacer;
        private System.Windows.Forms.Panel panelGridCard;
        private System.Windows.Forms.Panel panelGridHeader;
        private System.Windows.Forms.Label lblGridTitle;
        private System.Windows.Forms.Button btnPrevPage;
        private System.Windows.Forms.Label lblPageInfo;
        private System.Windows.Forms.Button btnNextPage;
        private System.Windows.Forms.Button btnHeaderEdit;
        private System.Windows.Forms.Button btnHeaderPrice;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.DataGridView dgvProducts;
        private System.Windows.Forms.Panel panelQuickActionsCard;
        private System.Windows.Forms.Label lblQuickActionsTitle;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnImportExcel;
        private System.Windows.Forms.Button btnExportExcel;
        private System.Windows.Forms.Button btnUpdateWholesale;
        private System.Windows.Forms.Panel panelRightSpacer;
        private System.Windows.Forms.Panel panelQuickPreviewCard;
        private System.Windows.Forms.Label lblQuickPreviewTitle;
        private System.Windows.Forms.Label lblQuickStockInfo;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.ContextMenuStrip cmsProductActions;
        private System.Windows.Forms.ToolStripMenuItem mnuEditProduct;
        private System.Windows.Forms.ToolStripMenuItem mnuUpdatePrice;
        private System.Windows.Forms.ToolStripMenuItem mnuViewDetail;
        private System.Windows.Forms.ToolStripMenuItem mnuDeleteProduct;
    }
}

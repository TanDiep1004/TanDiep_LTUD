namespace MiniSupermarket.WinForms
{
    partial class FormCategoryManagement
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

            // KPI Row (3 Cards)
            this.tlpKpiRow = new System.Windows.Forms.TableLayoutPanel();
            this.cardKpiTotal = new System.Windows.Forms.Panel();
            this.lblKpiTotalTitle = new System.Windows.Forms.Label();
            this.lblKpiTotalValue = new System.Windows.Forms.Label();
            this.lblKpiTotalSub = new System.Windows.Forms.Label();
            this.picKpiTotalIcon = new System.Windows.Forms.PictureBox();

            this.cardKpiLowStock = new System.Windows.Forms.Panel();
            this.lblKpiLowTitle = new System.Windows.Forms.Label();
            this.lblKpiLowValue = new System.Windows.Forms.Label();
            this.lblKpiLowSub = new System.Windows.Forms.Label();
            this.picKpiLowIcon = new System.Windows.Forms.PictureBox();

            this.cardKpiExpiring = new System.Windows.Forms.Panel();
            this.lblKpiExpTitle = new System.Windows.Forms.Label();
            this.lblKpiExpValue = new System.Windows.Forms.Label();
            this.lblKpiExpSub = new System.Windows.Forms.Label();
            this.picKpiExpIcon = new System.Windows.Forms.PictureBox();

            this.panelTopSpacer = new System.Windows.Forms.Panel();

            // Bottom Area (3 Cards: Màn hình nhập hàng, Nhà cung cấp nổi bật, Danh mục tác vụ)
            this.panelBottomArea = new System.Windows.Forms.Panel();
            this.panelImportScreenCard = new System.Windows.Forms.Panel();
            this.lblImportScreenTitle = new System.Windows.Forms.Label();
            this.lblReceiptNo = new System.Windows.Forms.Label();
            this.txtReceiptNo = new System.Windows.Forms.TextBox();
            this.lblSupplierSelect = new System.Windows.Forms.Label();
            this.cboImportSupplier = new System.Windows.Forms.ComboBox();
            this.lblImportDate = new System.Windows.Forms.Label();
            this.dtpImportDate = new System.Windows.Forms.DateTimePicker();
            this.txtReceiptDetails = new System.Windows.Forms.TextBox();

            this.panelBottomLeftSpacer = new System.Windows.Forms.Panel();

            this.panelFeaturedSupplierCard = new System.Windows.Forms.Panel();
            this.lblFeaturedSupplierTitle = new System.Windows.Forms.Label();
            this.lstFeaturedSuppliers = new System.Windows.Forms.ListBox();

            this.panelBottomRightSpacer = new System.Windows.Forms.Panel();

            this.panelTaskMenuCard = new System.Windows.Forms.Panel();
            this.lblTaskMenuTitle = new System.Windows.Forms.Label();
            this.btnTaskImportF7 = new System.Windows.Forms.Button();
            this.btnTaskStocktake = new System.Windows.Forms.Button();
            this.btnTaskWriteOff = new System.Windows.Forms.Button();
            this.btnTaskReport = new System.Windows.Forms.Button();

            this.panelBottomSpacer = new System.Windows.Forms.Panel();

            // Center Inventory Table Card
            this.panelInventoryCard = new System.Windows.Forms.Panel();
            this.panelGridHeader = new System.Windows.Forms.Panel();
            this.lblGridTitle = new System.Windows.Forms.Label();
            this.btnHeaderPrev = new System.Windows.Forms.Button();
            this.lblHeaderPageInfo = new System.Windows.Forms.Label();
            this.btnHeaderNext = new System.Windows.Forms.Button();
            this.btnHeaderTransfer = new System.Windows.Forms.Button();
            this.btnHeaderCategoryMgr = new System.Windows.Forms.Button();
            this.btnHeaderDelete = new System.Windows.Forms.Button();

            this.panelFilterBar = new System.Windows.Forms.Panel();
            this.lblFilterCat = new System.Windows.Forms.Label();
            this.cboFilterCategory = new System.Windows.Forms.ComboBox();
            this.lblFilterSupplier = new System.Windows.Forms.Label();
            this.cboFilterSupplier = new System.Windows.Forms.ComboBox();
            this.lblFilterStatus = new System.Windows.Forms.Label();
            this.cboFilterStatus = new System.Windows.Forms.ComboBox();
            this.lblFilterDate = new System.Windows.Forms.Label();
            this.dtpFilterDate = new System.Windows.Forms.DateTimePicker();

            this.dgvCategories = new System.Windows.Forms.DataGridView();

            this.panelPagination = new System.Windows.Forms.Panel();
            this.lblPageSummary = new System.Windows.Forms.Label();
            this.lblPageSize = new System.Windows.Forms.Label();
            this.cboPageSize = new System.Windows.Forms.ComboBox();
            this.btnFirstPage = new System.Windows.Forms.Button();
            this.btnPrevPage = new System.Windows.Forms.Button();
            this.lblPageInfo = new System.Windows.Forms.Label();
            this.btnNextPage = new System.Windows.Forms.Button();
            this.btnLastPage = new System.Windows.Forms.Button();

            // Context Menu Strip
            this.cmsInventoryActions = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuCreateReceipt = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTransferLocation = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuQuickStocktake = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuManageCategories = new System.Windows.Forms.ToolStripMenuItem();

            this.panelTopBanner.SuspendLayout();
            this.tlpKpiRow.SuspendLayout();
            this.cardKpiTotal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picKpiTotalIcon)).BeginInit();
            this.cardKpiLowStock.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picKpiLowIcon)).BeginInit();
            this.cardKpiExpiring.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picKpiExpIcon)).BeginInit();
            this.panelBottomArea.SuspendLayout();
            this.panelImportScreenCard.SuspendLayout();
            this.panelFeaturedSupplierCard.SuspendLayout();
            this.panelTaskMenuCard.SuspendLayout();
            this.panelInventoryCard.SuspendLayout();
            this.panelGridHeader.SuspendLayout();
            this.panelFilterBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategories)).BeginInit();
            this.cmsInventoryActions.SuspendLayout();
            this.SuspendLayout();

            // panelTopBanner
            this.panelTopBanner.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            this.panelTopBanner.Controls.Add(this.lblPageTitle);
            this.panelTopBanner.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTopBanner.Location = new System.Drawing.Point(12, 4);
            this.panelTopBanner.Name = "panelTopBanner";
            this.panelTopBanner.Size = new System.Drawing.Size(1026, 34);
            this.panelTopBanner.TabIndex = 0;

            // lblPageTitle
            this.lblPageTitle.AutoSize = true;
            this.lblPageTitle.Font = new System.Drawing.Font("Segoe UI", 13.5F, System.Drawing.FontStyle.Bold);
            this.lblPageTitle.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.lblPageTitle.Location = new System.Drawing.Point(2, 4);
            this.lblPageTitle.Name = "lblPageTitle";
            this.lblPageTitle.Size = new System.Drawing.Size(492, 25);
            this.lblPageTitle.TabIndex = 0;
            this.lblPageTitle.Text = "QUẢN LÝ KHO & NHẬP HÀNG (Inventory & Warehouse)";

            // tlpKpiRow
            this.tlpKpiRow.ColumnCount = 3;
            this.tlpKpiRow.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpKpiRow.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpKpiRow.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpKpiRow.Controls.Add(this.cardKpiTotal, 0, 0);
            this.tlpKpiRow.Controls.Add(this.cardKpiLowStock, 1, 0);
            this.tlpKpiRow.Controls.Add(this.cardKpiExpiring, 2, 0);
            this.tlpKpiRow.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlpKpiRow.Location = new System.Drawing.Point(12, 38);
            this.tlpKpiRow.Name = "tlpKpiRow";
            this.tlpKpiRow.RowCount = 1;
            this.tlpKpiRow.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpKpiRow.Size = new System.Drawing.Size(1026, 92);
            this.tlpKpiRow.TabIndex = 1;

            // cardKpiTotal
            this.cardKpiTotal.BackColor = System.Drawing.Color.White;
            this.cardKpiTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cardKpiTotal.Controls.Add(this.picKpiTotalIcon);
            this.cardKpiTotal.Controls.Add(this.lblKpiTotalSub);
            this.cardKpiTotal.Controls.Add(this.lblKpiTotalValue);
            this.cardKpiTotal.Controls.Add(this.lblKpiTotalTitle);
            this.cardKpiTotal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cardKpiTotal.Location = new System.Drawing.Point(0, 0);
            this.cardKpiTotal.Margin = new System.Windows.Forms.Padding(0, 0, 8, 0);
            this.cardKpiTotal.Name = "cardKpiTotal";
            this.cardKpiTotal.Size = new System.Drawing.Size(334, 92);
            this.cardKpiTotal.TabIndex = 0;

            // lblKpiTotalTitle
            this.lblKpiTotalTitle.AutoSize = true;
            this.lblKpiTotalTitle.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblKpiTotalTitle.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
            this.lblKpiTotalTitle.Location = new System.Drawing.Point(12, 8);
            this.lblKpiTotalTitle.Name = "lblKpiTotalTitle";
            this.lblKpiTotalTitle.Size = new System.Drawing.Size(118, 17);
            this.lblKpiTotalTitle.TabIndex = 0;
            this.lblKpiTotalTitle.Text = "TỔNG MẶT HÀNG";

            // lblKpiTotalValue
            this.lblKpiTotalValue.AutoSize = true;
            this.lblKpiTotalValue.Font = new System.Drawing.Font("Segoe UI", 19F, System.Drawing.FontStyle.Bold);
            this.lblKpiTotalValue.ForeColor = System.Drawing.Color.FromArgb(29, 112, 184);
            this.lblKpiTotalValue.Location = new System.Drawing.Point(10, 27);
            this.lblKpiTotalValue.Name = "lblKpiTotalValue";
            this.lblKpiTotalValue.Size = new System.Drawing.Size(81, 36);
            this.lblKpiTotalValue.TabIndex = 1;
            this.lblKpiTotalValue.Text = "2,850";

            // lblKpiTotalSub
            this.lblKpiTotalSub.AutoSize = true;
            this.lblKpiTotalSub.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Italic);
            this.lblKpiTotalSub.ForeColor = System.Drawing.Color.FromArgb(29, 112, 184);
            this.lblKpiTotalSub.Location = new System.Drawing.Point(14, 65);
            this.lblKpiTotalSub.Name = "lblKpiTotalSub";
            this.lblKpiTotalSub.Size = new System.Drawing.Size(92, 15);
            this.lblKpiTotalSub.TabIndex = 2;
            this.lblKpiTotalSub.Text = "màu xanh dương";

            // picKpiTotalIcon
            this.picKpiTotalIcon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picKpiTotalIcon.Location = new System.Drawing.Point(272, 26);
            this.picKpiTotalIcon.Name = "picKpiTotalIcon";
            this.picKpiTotalIcon.Size = new System.Drawing.Size(46, 44);
            this.picKpiTotalIcon.TabIndex = 3;
            this.picKpiTotalIcon.TabStop = false;

            // cardKpiLowStock
            this.cardKpiLowStock.BackColor = System.Drawing.Color.White;
            this.cardKpiLowStock.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cardKpiLowStock.Controls.Add(this.picKpiLowIcon);
            this.cardKpiLowStock.Controls.Add(this.lblKpiLowSub);
            this.cardKpiLowStock.Controls.Add(this.lblKpiLowValue);
            this.cardKpiLowStock.Controls.Add(this.lblKpiLowTitle);
            this.cardKpiLowStock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cardKpiLowStock.Location = new System.Drawing.Point(346, 0);
            this.cardKpiLowStock.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.cardKpiLowStock.Name = "cardKpiLowStock";
            this.cardKpiLowStock.Size = new System.Drawing.Size(334, 92);
            this.cardKpiLowStock.TabIndex = 1;

            // lblKpiLowTitle
            this.lblKpiLowTitle.AutoSize = true;
            this.lblKpiLowTitle.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblKpiLowTitle.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
            this.lblKpiLowTitle.Location = new System.Drawing.Point(12, 8);
            this.lblKpiLowTitle.Name = "lblKpiLowTitle";
            this.lblKpiLowTitle.Size = new System.Drawing.Size(230, 17);
            this.lblKpiLowTitle.TabIndex = 0;
            this.lblKpiLowTitle.Text = "SẢN PHẨM SẮP HẾT HÀNG (Tồn Min)";

            // lblKpiLowValue
            this.lblKpiLowValue.AutoSize = true;
            this.lblKpiLowValue.Font = new System.Drawing.Font("Segoe UI", 19F, System.Drawing.FontStyle.Bold);
            this.lblKpiLowValue.ForeColor = System.Drawing.Color.FromArgb(245, 158, 11);
            this.lblKpiLowValue.Location = new System.Drawing.Point(10, 27);
            this.lblKpiLowValue.Name = "lblKpiLowValue";
            this.lblKpiLowValue.Size = new System.Drawing.Size(44, 36);
            this.lblKpiLowValue.TabIndex = 1;
            this.lblKpiLowValue.Text = "25";

            // lblKpiLowSub
            this.lblKpiLowSub.AutoSize = true;
            this.lblKpiLowSub.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Italic);
            this.lblKpiLowSub.ForeColor = System.Drawing.Color.FromArgb(245, 158, 11);
            this.lblKpiLowSub.Location = new System.Drawing.Point(14, 65);
            this.lblKpiLowSub.Name = "lblKpiLowSub";
            this.lblKpiLowSub.Size = new System.Drawing.Size(55, 15);
            this.lblKpiLowSub.TabIndex = 2;
            this.lblKpiLowSub.Text = "màu cam";

            // picKpiLowIcon
            this.picKpiLowIcon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picKpiLowIcon.Location = new System.Drawing.Point(274, 26);
            this.picKpiLowIcon.Name = "picKpiLowIcon";
            this.picKpiLowIcon.Size = new System.Drawing.Size(44, 44);
            this.picKpiLowIcon.TabIndex = 3;
            this.picKpiLowIcon.TabStop = false;

            // cardKpiExpiring
            this.cardKpiExpiring.BackColor = System.Drawing.Color.White;
            this.cardKpiExpiring.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cardKpiExpiring.Controls.Add(this.picKpiExpIcon);
            this.cardKpiExpiring.Controls.Add(this.lblKpiExpSub);
            this.cardKpiExpiring.Controls.Add(this.lblKpiExpValue);
            this.cardKpiExpiring.Controls.Add(this.lblKpiExpTitle);
            this.cardKpiExpiring.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cardKpiExpiring.Location = new System.Drawing.Point(692, 0);
            this.cardKpiExpiring.Margin = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.cardKpiExpiring.Name = "cardKpiExpiring";
            this.cardKpiExpiring.Size = new System.Drawing.Size(334, 92);
            this.cardKpiExpiring.TabIndex = 2;

            // lblKpiExpTitle
            this.lblKpiExpTitle.AutoSize = true;
            this.lblKpiExpTitle.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblKpiExpTitle.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
            this.lblKpiExpTitle.Location = new System.Drawing.Point(12, 8);
            this.lblKpiExpTitle.Name = "lblKpiExpTitle";
            this.lblKpiExpTitle.Size = new System.Drawing.Size(222, 17);
            this.lblKpiExpTitle.TabIndex = 0;
            this.lblKpiExpTitle.Text = "SẢN PHẨM CẬN HẠN (Dưới 30 ngày)";

            // lblKpiExpValue
            this.lblKpiExpValue.AutoSize = true;
            this.lblKpiExpValue.Font = new System.Drawing.Font("Segoe UI", 19F, System.Drawing.FontStyle.Bold);
            this.lblKpiExpValue.ForeColor = System.Drawing.Color.FromArgb(220, 38, 38);
            this.lblKpiExpValue.Location = new System.Drawing.Point(10, 27);
            this.lblKpiExpValue.Name = "lblKpiExpValue";
            this.lblKpiExpValue.Size = new System.Drawing.Size(44, 36);
            this.lblKpiExpValue.TabIndex = 1;
            this.lblKpiExpValue.Text = "18";

            // lblKpiExpSub
            this.lblKpiExpSub.AutoSize = true;
            this.lblKpiExpSub.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Italic);
            this.lblKpiExpSub.ForeColor = System.Drawing.Color.FromArgb(220, 38, 38);
            this.lblKpiExpSub.Location = new System.Drawing.Point(14, 65);
            this.lblKpiExpSub.Name = "lblKpiExpSub";
            this.lblKpiExpSub.Size = new System.Drawing.Size(96, 15);
            this.lblKpiExpSub.TabIndex = 2;
            this.lblKpiExpSub.Text = "màu đỏ cảnh báo";

            // picKpiExpIcon
            this.picKpiExpIcon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picKpiExpIcon.Location = new System.Drawing.Point(274, 26);
            this.picKpiExpIcon.Name = "picKpiExpIcon";
            this.picKpiExpIcon.Size = new System.Drawing.Size(44, 44);
            this.picKpiExpIcon.TabIndex = 3;
            this.picKpiExpIcon.TabStop = false;

            // panelTopSpacer
            this.panelTopSpacer.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTopSpacer.Location = new System.Drawing.Point(12, 130);
            this.panelTopSpacer.Name = "panelTopSpacer";
            this.panelTopSpacer.Size = new System.Drawing.Size(1026, 8);
            this.panelTopSpacer.TabIndex = 2;

            // panelBottomArea
            this.panelBottomArea.Controls.Add(this.panelFeaturedSupplierCard);
            this.panelBottomArea.Controls.Add(this.panelBottomLeftSpacer);
            this.panelBottomArea.Controls.Add(this.panelImportScreenCard);
            this.panelBottomArea.Controls.Add(this.panelBottomRightSpacer);
            this.panelBottomArea.Controls.Add(this.panelTaskMenuCard);
            this.panelBottomArea.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottomArea.Location = new System.Drawing.Point(12, 464);
            this.panelBottomArea.Name = "panelBottomArea";
            this.panelBottomArea.Size = new System.Drawing.Size(1026, 168);
            this.panelBottomArea.TabIndex = 3;

            // panelImportScreenCard (Left of Bottom Area)
            this.panelImportScreenCard.BackColor = System.Drawing.Color.White;
            this.panelImportScreenCard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelImportScreenCard.Controls.Add(this.txtReceiptDetails);
            this.panelImportScreenCard.Controls.Add(this.dtpImportDate);
            this.panelImportScreenCard.Controls.Add(this.lblImportDate);
            this.panelImportScreenCard.Controls.Add(this.cboImportSupplier);
            this.panelImportScreenCard.Controls.Add(this.lblSupplierSelect);
            this.panelImportScreenCard.Controls.Add(this.txtReceiptNo);
            this.panelImportScreenCard.Controls.Add(this.lblReceiptNo);
            this.panelImportScreenCard.Controls.Add(this.lblImportScreenTitle);
            this.panelImportScreenCard.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelImportScreenCard.Location = new System.Drawing.Point(0, 0);
            this.panelImportScreenCard.Name = "panelImportScreenCard";
            this.panelImportScreenCard.Size = new System.Drawing.Size(580, 168);
            this.panelImportScreenCard.TabIndex = 0;

            // lblImportScreenTitle
            this.lblImportScreenTitle.AutoSize = true;
            this.lblImportScreenTitle.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.lblImportScreenTitle.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.lblImportScreenTitle.Location = new System.Drawing.Point(10, 8);
            this.lblImportScreenTitle.Name = "lblImportScreenTitle";
            this.lblImportScreenTitle.Size = new System.Drawing.Size(150, 19);
            this.lblImportScreenTitle.TabIndex = 0;
            this.lblImportScreenTitle.Text = "Màn hình nhập hàng";

            // lblReceiptNo
            this.lblReceiptNo.AutoSize = true;
            this.lblReceiptNo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblReceiptNo.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
            this.lblReceiptNo.Location = new System.Drawing.Point(10, 36);
            this.lblReceiptNo.Name = "lblReceiptNo";
            this.lblReceiptNo.Size = new System.Drawing.Size(84, 15);
            this.lblReceiptNo.TabIndex = 1;
            this.lblReceiptNo.Text = "Số phiếu nhập:";

            // txtReceiptNo
            this.txtReceiptNo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtReceiptNo.Location = new System.Drawing.Point(100, 32);
            this.txtReceiptNo.Name = "txtReceiptNo";
            this.txtReceiptNo.Size = new System.Drawing.Size(340, 23);
            this.txtReceiptNo.TabIndex = 2;

            // lblSupplierSelect
            this.lblSupplierSelect.AutoSize = true;
            this.lblSupplierSelect.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSupplierSelect.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
            this.lblSupplierSelect.Location = new System.Drawing.Point(10, 68);
            this.lblSupplierSelect.Name = "lblSupplierSelect";
            this.lblSupplierSelect.Size = new System.Drawing.Size(83, 15);
            this.lblSupplierSelect.TabIndex = 3;
            this.lblSupplierSelect.Text = "Nhà cung cấp:";

            // cboImportSupplier
            this.cboImportSupplier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboImportSupplier.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cboImportSupplier.FormattingEnabled = true;
            this.cboImportSupplier.Location = new System.Drawing.Point(100, 64);
            this.cboImportSupplier.Name = "cboImportSupplier";
            this.cboImportSupplier.Size = new System.Drawing.Size(340, 23);
            this.cboImportSupplier.TabIndex = 4;

            // lblImportDate
            this.lblImportDate.AutoSize = true;
            this.lblImportDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblImportDate.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
            this.lblImportDate.Location = new System.Drawing.Point(450, 36);
            this.lblImportDate.Name = "lblImportDate";
            this.lblImportDate.Size = new System.Drawing.Size(65, 15);
            this.lblImportDate.TabIndex = 5;
            this.lblImportDate.Text = "Ngày nhập:";

            // dtpImportDate
            this.dtpImportDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpImportDate.CustomFormat = "dd/MM/yyyy";
            this.dtpImportDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpImportDate.Location = new System.Drawing.Point(450, 64);
            this.dtpImportDate.Name = "dtpImportDate";
            this.dtpImportDate.Size = new System.Drawing.Size(116, 23);
            this.dtpImportDate.TabIndex = 6;

            // txtReceiptDetails
            this.txtReceiptDetails.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtReceiptDetails.Location = new System.Drawing.Point(12, 96);
            this.txtReceiptDetails.Multiline = true;
            this.txtReceiptDetails.Name = "txtReceiptDetails";
            this.txtReceiptDetails.PlaceholderText = "Hóa đơn nhập";
            this.txtReceiptDetails.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtReceiptDetails.Size = new System.Drawing.Size(554, 60);
            this.txtReceiptDetails.TabIndex = 7;

            // panelBottomLeftSpacer
            this.panelBottomLeftSpacer.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelBottomLeftSpacer.Location = new System.Drawing.Point(580, 0);
            this.panelBottomLeftSpacer.Name = "panelBottomLeftSpacer";
            this.panelBottomLeftSpacer.Size = new System.Drawing.Size(8, 168);
            this.panelBottomLeftSpacer.TabIndex = 1;

            // panelFeaturedSupplierCard (Center of Bottom Area)
            this.panelFeaturedSupplierCard.BackColor = System.Drawing.Color.White;
            this.panelFeaturedSupplierCard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelFeaturedSupplierCard.Controls.Add(this.lstFeaturedSuppliers);
            this.panelFeaturedSupplierCard.Controls.Add(this.lblFeaturedSupplierTitle);
            this.panelFeaturedSupplierCard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFeaturedSupplierCard.Location = new System.Drawing.Point(588, 0);
            this.panelFeaturedSupplierCard.Name = "panelFeaturedSupplierCard";
            this.panelFeaturedSupplierCard.Size = new System.Drawing.Size(222, 168);
            this.panelFeaturedSupplierCard.TabIndex = 2;

            // lblFeaturedSupplierTitle
            this.lblFeaturedSupplierTitle.AutoSize = true;
            this.lblFeaturedSupplierTitle.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.lblFeaturedSupplierTitle.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.lblFeaturedSupplierTitle.Location = new System.Drawing.Point(10, 8);
            this.lblFeaturedSupplierTitle.Name = "lblFeaturedSupplierTitle";
            this.lblFeaturedSupplierTitle.Size = new System.Drawing.Size(150, 19);
            this.lblFeaturedSupplierTitle.TabIndex = 0;
            this.lblFeaturedSupplierTitle.Text = "Nhà cung cấp nổi bật";

            // lstFeaturedSuppliers
            this.lstFeaturedSuppliers.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstFeaturedSuppliers.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lstFeaturedSuppliers.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
            this.lstFeaturedSuppliers.FormattingEnabled = true;
            this.lstFeaturedSuppliers.ItemHeight = 19;
            this.lstFeaturedSuppliers.Location = new System.Drawing.Point(12, 34);
            this.lstFeaturedSuppliers.Name = "lstFeaturedSuppliers";
            this.lstFeaturedSuppliers.Size = new System.Drawing.Size(196, 122);
            this.lstFeaturedSuppliers.TabIndex = 1;
            this.lstFeaturedSuppliers.SelectedIndexChanged += new System.EventHandler(this.lstFeaturedSuppliers_SelectedIndexChanged);

            // panelBottomRightSpacer
            this.panelBottomRightSpacer.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelBottomRightSpacer.Location = new System.Drawing.Point(810, 0);
            this.panelBottomRightSpacer.Name = "panelBottomRightSpacer";
            this.panelBottomRightSpacer.Size = new System.Drawing.Size(8, 168);
            this.panelBottomRightSpacer.TabIndex = 3;

            // panelTaskMenuCard (Right of Bottom Area)
            this.panelTaskMenuCard.BackColor = System.Drawing.Color.White;
            this.panelTaskMenuCard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelTaskMenuCard.Controls.Add(this.btnTaskReport);
            this.panelTaskMenuCard.Controls.Add(this.btnTaskWriteOff);
            this.panelTaskMenuCard.Controls.Add(this.btnTaskStocktake);
            this.panelTaskMenuCard.Controls.Add(this.btnTaskImportF7);
            this.panelTaskMenuCard.Controls.Add(this.lblTaskMenuTitle);
            this.panelTaskMenuCard.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelTaskMenuCard.Location = new System.Drawing.Point(818, 0);
            this.panelTaskMenuCard.Name = "panelTaskMenuCard";
            this.panelTaskMenuCard.Size = new System.Drawing.Size(208, 168);
            this.panelTaskMenuCard.TabIndex = 4;

            // lblTaskMenuTitle
            this.lblTaskMenuTitle.AutoSize = true;
            this.lblTaskMenuTitle.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.lblTaskMenuTitle.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.lblTaskMenuTitle.Location = new System.Drawing.Point(10, 8);
            this.lblTaskMenuTitle.Name = "lblTaskMenuTitle";
            this.lblTaskMenuTitle.Size = new System.Drawing.Size(124, 19);
            this.lblTaskMenuTitle.TabIndex = 0;
            this.lblTaskMenuTitle.Text = "Danh mục tác vụ";

            // btnTaskImportF7
            this.btnTaskImportF7.BackColor = System.Drawing.Color.FromArgb(229, 231, 235);
            this.btnTaskImportF7.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTaskImportF7.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(209, 213, 219);
            this.btnTaskImportF7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTaskImportF7.Font = new System.Drawing.Font("Segoe UI", 8.8F);
            this.btnTaskImportF7.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.btnTaskImportF7.Location = new System.Drawing.Point(12, 32);
            this.btnTaskImportF7.Name = "btnTaskImportF7";
            this.btnTaskImportF7.Size = new System.Drawing.Size(182, 28);
            this.btnTaskImportF7.TabIndex = 1;
            this.btnTaskImportF7.Text = "Nhập kho từ NCC (F7)";
            this.btnTaskImportF7.UseVisualStyleBackColor = false;
            this.btnTaskImportF7.Click += new System.EventHandler(this.btnTaskImportF7_Click);

            // btnTaskStocktake
            this.btnTaskStocktake.BackColor = System.Drawing.Color.FromArgb(229, 231, 235);
            this.btnTaskStocktake.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTaskStocktake.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(209, 213, 219);
            this.btnTaskStocktake.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTaskStocktake.Font = new System.Drawing.Font("Segoe UI", 8.8F);
            this.btnTaskStocktake.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.btnTaskStocktake.Location = new System.Drawing.Point(12, 64);
            this.btnTaskStocktake.Name = "btnTaskStocktake";
            this.btnTaskStocktake.Size = new System.Drawing.Size(182, 28);
            this.btnTaskStocktake.TabIndex = 2;
            this.btnTaskStocktake.Text = "Kiểm kê kho";
            this.btnTaskStocktake.UseVisualStyleBackColor = false;
            this.btnTaskStocktake.Click += new System.EventHandler(this.btnTaskStocktake_Click);

            // btnTaskWriteOff
            this.btnTaskWriteOff.BackColor = System.Drawing.Color.FromArgb(229, 231, 235);
            this.btnTaskWriteOff.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTaskWriteOff.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(209, 213, 219);
            this.btnTaskWriteOff.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTaskWriteOff.Font = new System.Drawing.Font("Segoe UI", 8.8F);
            this.btnTaskWriteOff.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.btnTaskWriteOff.Location = new System.Drawing.Point(12, 96);
            this.btnTaskWriteOff.Name = "btnTaskWriteOff";
            this.btnTaskWriteOff.Size = new System.Drawing.Size(182, 28);
            this.btnTaskWriteOff.TabIndex = 3;
            this.btnTaskWriteOff.Text = "Xuất hủy hàng hỏng";
            this.btnTaskWriteOff.UseVisualStyleBackColor = false;
            this.btnTaskWriteOff.Click += new System.EventHandler(this.btnTaskWriteOff_Click);

            // btnTaskReport
            this.btnTaskReport.BackColor = System.Drawing.Color.FromArgb(229, 231, 235);
            this.btnTaskReport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTaskReport.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(209, 213, 219);
            this.btnTaskReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTaskReport.Font = new System.Drawing.Font("Segoe UI", 8.8F);
            this.btnTaskReport.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.btnTaskReport.Location = new System.Drawing.Point(12, 128);
            this.btnTaskReport.Name = "btnTaskReport";
            this.btnTaskReport.Size = new System.Drawing.Size(182, 28);
            this.btnTaskReport.TabIndex = 4;
            this.btnTaskReport.Text = "Xem báo cáo tồn";
            this.btnTaskReport.UseVisualStyleBackColor = false;
            this.btnTaskReport.Click += new System.EventHandler(this.btnTaskReport_Click);

            // panelBottomSpacer
            this.panelBottomSpacer.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottomSpacer.Location = new System.Drawing.Point(12, 456);
            this.panelBottomSpacer.Name = "panelBottomSpacer";
            this.panelBottomSpacer.Size = new System.Drawing.Size(1026, 8);
            this.panelBottomSpacer.TabIndex = 4;

            // panelInventoryCard (Center Fill)
            this.panelInventoryCard.BackColor = System.Drawing.Color.White;
            this.panelInventoryCard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelInventoryCard.Controls.Add(this.dgvCategories);
            this.panelInventoryCard.Controls.Add(this.panelPagination);
            this.panelInventoryCard.Controls.Add(this.panelFilterBar);
            this.panelInventoryCard.Controls.Add(this.panelGridHeader);
            this.panelInventoryCard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelInventoryCard.Location = new System.Drawing.Point(12, 138);
            this.panelInventoryCard.Name = "panelInventoryCard";
            this.panelInventoryCard.Padding = new System.Windows.Forms.Padding(10, 6, 10, 8);
            this.panelInventoryCard.Size = new System.Drawing.Size(1026, 318);
            this.panelInventoryCard.TabIndex = 5;

            // panelGridHeader
            this.panelGridHeader.Controls.Add(this.btnHeaderDelete);
            this.panelGridHeader.Controls.Add(this.btnHeaderCategoryMgr);
            this.panelGridHeader.Controls.Add(this.btnHeaderTransfer);
            this.panelGridHeader.Controls.Add(this.btnHeaderNext);
            this.panelGridHeader.Controls.Add(this.lblHeaderPageInfo);
            this.panelGridHeader.Controls.Add(this.btnHeaderPrev);
            this.panelGridHeader.Controls.Add(this.lblGridTitle);
            this.panelGridHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelGridHeader.Location = new System.Drawing.Point(10, 6);
            this.panelGridHeader.Name = "panelGridHeader";
            this.panelGridHeader.Size = new System.Drawing.Size(1004, 30);
            this.panelGridHeader.TabIndex = 0;

            // lblGridTitle
            this.lblGridTitle.AutoSize = true;
            this.lblGridTitle.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.lblGridTitle.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.lblGridTitle.Location = new System.Drawing.Point(0, 4);
            this.lblGridTitle.Name = "lblGridTitle";
            this.lblGridTitle.Size = new System.Drawing.Size(348, 19);
            this.lblGridTitle.TabIndex = 0;
            this.lblGridTitle.Text = "BẢNG TỒN KHO THỰC TẾ (Real-time Inventory)";

            // btnHeaderPrev
            this.btnHeaderPrev.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHeaderPrev.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            this.btnHeaderPrev.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHeaderPrev.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHeaderPrev.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(203, 213, 225);
            this.btnHeaderPrev.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.btnHeaderPrev.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.btnHeaderPrev.Location = new System.Drawing.Point(674, 2);
            this.btnHeaderPrev.Name = "btnHeaderPrev";
            this.btnHeaderPrev.Size = new System.Drawing.Size(64, 25);
            this.btnHeaderPrev.TabIndex = 4;
            this.btnHeaderPrev.Text = "◀ Trước";
            this.btnHeaderPrev.UseVisualStyleBackColor = false;
            this.btnHeaderPrev.Click += new System.EventHandler(this.btnPrevPage_Click);

            // lblHeaderPageInfo
            this.lblHeaderPageInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblHeaderPageInfo.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblHeaderPageInfo.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.lblHeaderPageInfo.Location = new System.Drawing.Point(742, 5);
            this.lblHeaderPageInfo.Name = "lblHeaderPageInfo";
            this.lblHeaderPageInfo.Size = new System.Drawing.Size(80, 20);
            this.lblHeaderPageInfo.TabIndex = 5;
            this.lblHeaderPageInfo.Text = "Trang 1 / 4";
            this.lblHeaderPageInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // btnHeaderNext
            this.btnHeaderNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHeaderNext.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            this.btnHeaderNext.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHeaderNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHeaderNext.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(203, 213, 225);
            this.btnHeaderNext.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.btnHeaderNext.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.btnHeaderNext.Location = new System.Drawing.Point(826, 2);
            this.btnHeaderNext.Name = "btnHeaderNext";
            this.btnHeaderNext.Size = new System.Drawing.Size(64, 25);
            this.btnHeaderNext.TabIndex = 6;
            this.btnHeaderNext.Text = "Sau ▶";
            this.btnHeaderNext.UseVisualStyleBackColor = false;
            this.btnHeaderNext.Click += new System.EventHandler(this.btnNextPage_Click);

            // btnHeaderTransfer
            this.btnHeaderTransfer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHeaderTransfer.BackColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.btnHeaderTransfer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHeaderTransfer.FlatAppearance.BorderSize = 0;
            this.btnHeaderTransfer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHeaderTransfer.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.btnHeaderTransfer.ForeColor = System.Drawing.Color.White;
            this.btnHeaderTransfer.Location = new System.Drawing.Point(902, 2);
            this.btnHeaderTransfer.Name = "btnHeaderTransfer";
            this.btnHeaderTransfer.Size = new System.Drawing.Size(30, 25);
            this.btnHeaderTransfer.TabIndex = 1;
            this.btnHeaderTransfer.Text = "⇄";
            this.btnHeaderTransfer.UseVisualStyleBackColor = false;
            this.btnHeaderTransfer.Click += new System.EventHandler(this.mnuTransferLocation_Click);

            // btnHeaderCategoryMgr
            this.btnHeaderCategoryMgr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHeaderCategoryMgr.BackColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.btnHeaderCategoryMgr.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHeaderCategoryMgr.FlatAppearance.BorderSize = 0;
            this.btnHeaderCategoryMgr.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHeaderCategoryMgr.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.btnHeaderCategoryMgr.ForeColor = System.Drawing.Color.White;
            this.btnHeaderCategoryMgr.Location = new System.Drawing.Point(936, 2);
            this.btnHeaderCategoryMgr.Name = "btnHeaderCategoryMgr";
            this.btnHeaderCategoryMgr.Size = new System.Drawing.Size(30, 25);
            this.btnHeaderCategoryMgr.TabIndex = 2;
            this.btnHeaderCategoryMgr.Text = "☰";
            this.btnHeaderCategoryMgr.UseVisualStyleBackColor = false;
            this.btnHeaderCategoryMgr.Click += new System.EventHandler(this.mnuManageCategories_Click);

            // btnHeaderDelete
            this.btnHeaderDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHeaderDelete.BackColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.btnHeaderDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHeaderDelete.FlatAppearance.BorderSize = 0;
            this.btnHeaderDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHeaderDelete.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.btnHeaderDelete.ForeColor = System.Drawing.Color.White;
            this.btnHeaderDelete.Location = new System.Drawing.Point(970, 2);
            this.btnHeaderDelete.Name = "btnHeaderDelete";
            this.btnHeaderDelete.Size = new System.Drawing.Size(30, 25);
            this.btnHeaderDelete.TabIndex = 3;
            this.btnHeaderDelete.Text = "🗑";
            this.btnHeaderDelete.UseVisualStyleBackColor = false;
            this.btnHeaderDelete.Click += new System.EventHandler(this.btnTaskWriteOff_Click);

            // panelFilterBar
            this.panelFilterBar.Controls.Add(this.dtpFilterDate);
            this.panelFilterBar.Controls.Add(this.lblFilterDate);
            this.panelFilterBar.Controls.Add(this.cboFilterStatus);
            this.panelFilterBar.Controls.Add(this.lblFilterStatus);
            this.panelFilterBar.Controls.Add(this.cboFilterSupplier);
            this.panelFilterBar.Controls.Add(this.lblFilterSupplier);
            this.panelFilterBar.Controls.Add(this.cboFilterCategory);
            this.panelFilterBar.Controls.Add(this.lblFilterCat);
            this.panelFilterBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelFilterBar.Location = new System.Drawing.Point(10, 36);
            this.panelFilterBar.Name = "panelFilterBar";
            this.panelFilterBar.Size = new System.Drawing.Size(1004, 34);
            this.panelFilterBar.TabIndex = 1;

            // lblFilterCat
            this.lblFilterCat.AutoSize = true;
            this.lblFilterCat.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblFilterCat.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
            this.lblFilterCat.Location = new System.Drawing.Point(0, 7);
            this.lblFilterCat.Name = "lblFilterCat";
            this.lblFilterCat.Size = new System.Drawing.Size(76, 15);
            this.lblFilterCat.TabIndex = 0;
            this.lblFilterCat.Text = "Ngành hàng:";

            // cboFilterCategory
            this.cboFilterCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFilterCategory.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cboFilterCategory.FormattingEnabled = true;
            this.cboFilterCategory.Location = new System.Drawing.Point(80, 4);
            this.cboFilterCategory.Name = "cboFilterCategory";
            this.cboFilterCategory.Size = new System.Drawing.Size(220, 23);
            this.cboFilterCategory.TabIndex = 1;
            this.cboFilterCategory.SelectedIndexChanged += new System.EventHandler(this.FilterControl_Changed);

            // lblFilterSupplier
            this.lblFilterSupplier.AutoSize = true;
            this.lblFilterSupplier.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblFilterSupplier.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
            this.lblFilterSupplier.Location = new System.Drawing.Point(314, 7);
            this.lblFilterSupplier.Name = "lblFilterSupplier";
            this.lblFilterSupplier.Size = new System.Drawing.Size(83, 15);
            this.lblFilterSupplier.TabIndex = 2;
            this.lblFilterSupplier.Text = "Nhà cung cấp:";

            // cboFilterSupplier
            this.cboFilterSupplier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFilterSupplier.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cboFilterSupplier.FormattingEnabled = true;
            this.cboFilterSupplier.Location = new System.Drawing.Point(400, 4);
            this.cboFilterSupplier.Name = "cboFilterSupplier";
            this.cboFilterSupplier.Size = new System.Drawing.Size(200, 23);
            this.cboFilterSupplier.TabIndex = 3;
            this.cboFilterSupplier.SelectedIndexChanged += new System.EventHandler(this.FilterControl_Changed);

            // lblFilterStatus
            this.lblFilterStatus.AutoSize = true;
            this.lblFilterStatus.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblFilterStatus.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
            this.lblFilterStatus.Location = new System.Drawing.Point(614, 7);
            this.lblFilterStatus.Name = "lblFilterStatus";
            this.lblFilterStatus.Size = new System.Drawing.Size(63, 15);
            this.lblFilterStatus.TabIndex = 4;
            this.lblFilterStatus.Text = "Trạng thái:";

            // cboFilterStatus
            this.cboFilterStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFilterStatus.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cboFilterStatus.FormattingEnabled = true;
            this.cboFilterStatus.Location = new System.Drawing.Point(682, 4);
            this.cboFilterStatus.Name = "cboFilterStatus";
            this.cboFilterStatus.Size = new System.Drawing.Size(145, 23);
            this.cboFilterStatus.TabIndex = 5;
            this.cboFilterStatus.SelectedIndexChanged += new System.EventHandler(this.FilterControl_Changed);

            // lblFilterDate
            this.lblFilterDate.AutoSize = true;
            this.lblFilterDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblFilterDate.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
            this.lblFilterDate.Location = new System.Drawing.Point(840, 7);
            this.lblFilterDate.Name = "lblFilterDate";
            this.lblFilterDate.Size = new System.Drawing.Size(38, 15);
            this.lblFilterDate.TabIndex = 6;
            this.lblFilterDate.Text = "Ngày:";

            // dtpFilterDate
            this.dtpFilterDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFilterDate.CustomFormat = "dd/MM/yyyy";
            this.dtpFilterDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpFilterDate.Location = new System.Drawing.Point(882, 4);
            this.dtpFilterDate.Name = "dtpFilterDate";
            this.dtpFilterDate.Size = new System.Drawing.Size(118, 23);
            this.dtpFilterDate.TabIndex = 7;

            // dgvCategories
            this.dgvCategories.AllowUserToAddRows = false;
            this.dgvCategories.AllowUserToDeleteRows = false;
            this.dgvCategories.AllowUserToResizeRows = false;
            this.dgvCategories.BackgroundColor = System.Drawing.Color.White;
            this.dgvCategories.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dgvCategories.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Single;
            this.dgvCategories.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvCategories.ColumnHeadersHeight = 30;
            this.dgvCategories.ContextMenuStrip = this.cmsInventoryActions;
            this.dgvCategories.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCategories.EnableHeadersVisualStyles = false;
            this.dgvCategories.GridColor = System.Drawing.Color.FromArgb(203, 213, 225);
            this.dgvCategories.Location = new System.Drawing.Point(10, 70);
            this.dgvCategories.MultiSelect = false;
            this.dgvCategories.Name = "dgvCategories";
            this.dgvCategories.ReadOnly = true;
            this.dgvCategories.RowHeadersVisible = false;
            this.dgvCategories.RowTemplate.Height = 28;
            this.dgvCategories.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCategories.Size = new System.Drawing.Size(1004, 238);
            this.dgvCategories.TabIndex = 2;
            this.dgvCategories.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCategories_CellClick);
            this.dgvCategories.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvCategories_CellMouseDown);

            // panelPagination (Dock = Bottom of panelInventoryCard)
            this.panelPagination.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            this.panelPagination.Controls.Add(this.lblPageSummary);
            this.panelPagination.Controls.Add(this.lblPageSize);
            this.panelPagination.Controls.Add(this.cboPageSize);
            this.panelPagination.Controls.Add(this.btnFirstPage);
            this.panelPagination.Controls.Add(this.btnPrevPage);
            this.panelPagination.Controls.Add(this.lblPageInfo);
            this.panelPagination.Controls.Add(this.btnNextPage);
            this.panelPagination.Controls.Add(this.btnLastPage);
            this.panelPagination.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelPagination.Location = new System.Drawing.Point(10, 276);
            this.panelPagination.Name = "panelPagination";
            this.panelPagination.Size = new System.Drawing.Size(1004, 32);
            this.panelPagination.TabIndex = 3;

            // lblPageSummary
            this.lblPageSummary.AutoSize = true;
            this.lblPageSummary.Font = new System.Drawing.Font("Segoe UI", 8.8F);
            this.lblPageSummary.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.lblPageSummary.Location = new System.Drawing.Point(2, 8);
            this.lblPageSummary.Name = "lblPageSummary";
            this.lblPageSummary.Size = new System.Drawing.Size(185, 15);
            this.lblPageSummary.TabIndex = 0;
            this.lblPageSummary.Text = "Hiển thị: 1 - 10 / 36 mặt hàng";

            // lblPageSize
            this.lblPageSize.AutoSize = true;
            this.lblPageSize.Font = new System.Drawing.Font("Segoe UI", 8.8F);
            this.lblPageSize.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.lblPageSize.Location = new System.Drawing.Point(230, 8);
            this.lblPageSize.Name = "lblPageSize";
            this.lblPageSize.Size = new System.Drawing.Size(85, 15);
            this.lblPageSize.TabIndex = 1;
            this.lblPageSize.Text = "Số dòng/trang:";

            // cboPageSize
            this.cboPageSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPageSize.Font = new System.Drawing.Font("Segoe UI", 8.8F);
            this.cboPageSize.FormattingEnabled = true;
            this.cboPageSize.Location = new System.Drawing.Point(320, 5);
            this.cboPageSize.Name = "cboPageSize";
            this.cboPageSize.Size = new System.Drawing.Size(70, 23);
            this.cboPageSize.TabIndex = 2;
            this.cboPageSize.SelectedIndexChanged += new System.EventHandler(this.cboPageSize_SelectedIndexChanged);

            // btnFirstPage
            this.btnFirstPage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFirstPage.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            this.btnFirstPage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFirstPage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFirstPage.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(203, 213, 225);
            this.btnFirstPage.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.btnFirstPage.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.btnFirstPage.Location = new System.Drawing.Point(650, 3);
            this.btnFirstPage.Name = "btnFirstPage";
            this.btnFirstPage.Size = new System.Drawing.Size(58, 25);
            this.btnFirstPage.TabIndex = 3;
            this.btnFirstPage.Text = "⏮ Đầu";
            this.btnFirstPage.UseVisualStyleBackColor = false;
            this.btnFirstPage.Click += new System.EventHandler(this.btnFirstPage_Click);

            // btnPrevPage
            this.btnPrevPage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrevPage.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            this.btnPrevPage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrevPage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrevPage.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(203, 213, 225);
            this.btnPrevPage.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.btnPrevPage.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.btnPrevPage.Location = new System.Drawing.Point(714, 3);
            this.btnPrevPage.Name = "btnPrevPage";
            this.btnPrevPage.Size = new System.Drawing.Size(65, 25);
            this.btnPrevPage.TabIndex = 4;
            this.btnPrevPage.Text = "◀ Trước";
            this.btnPrevPage.UseVisualStyleBackColor = false;
            this.btnPrevPage.Click += new System.EventHandler(this.btnPrevPage_Click);

            // lblPageInfo
            this.lblPageInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPageInfo.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblPageInfo.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.lblPageInfo.Location = new System.Drawing.Point(783, 6);
            this.lblPageInfo.Name = "lblPageInfo";
            this.lblPageInfo.Size = new System.Drawing.Size(80, 20);
            this.lblPageInfo.TabIndex = 5;
            this.lblPageInfo.Text = "Trang 1 / 4";
            this.lblPageInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // btnNextPage
            this.btnNextPage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNextPage.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            this.btnNextPage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNextPage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNextPage.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(203, 213, 225);
            this.btnNextPage.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.btnNextPage.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.btnNextPage.Location = new System.Drawing.Point(867, 3);
            this.btnNextPage.Name = "btnNextPage";
            this.btnNextPage.Size = new System.Drawing.Size(65, 25);
            this.btnNextPage.TabIndex = 6;
            this.btnNextPage.Text = "Sau ▶";
            this.btnNextPage.UseVisualStyleBackColor = false;
            this.btnNextPage.Click += new System.EventHandler(this.btnNextPage_Click);

            // btnLastPage
            this.btnLastPage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLastPage.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            this.btnLastPage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLastPage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLastPage.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(203, 213, 225);
            this.btnLastPage.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.btnLastPage.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.btnLastPage.Location = new System.Drawing.Point(936, 3);
            this.btnLastPage.Name = "btnLastPage";
            this.btnLastPage.Size = new System.Drawing.Size(65, 25);
            this.btnLastPage.TabIndex = 7;
            this.btnLastPage.Text = "Cuối ⏭";
            this.btnLastPage.UseVisualStyleBackColor = false;
            this.btnLastPage.Click += new System.EventHandler(this.btnLastPage_Click);

            // cmsInventoryActions
            this.cmsInventoryActions.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmsInventoryActions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.mnuCreateReceipt,
                this.mnuTransferLocation,
                this.mnuQuickStocktake,
                this.mnuManageCategories
            });
            this.cmsInventoryActions.Name = "cmsInventoryActions";
            this.cmsInventoryActions.Size = new System.Drawing.Size(210, 92);

            // mnuCreateReceipt
            this.mnuCreateReceipt.Name = "mnuCreateReceipt";
            this.mnuCreateReceipt.Size = new System.Drawing.Size(209, 22);
            this.mnuCreateReceipt.Text = "Tạo phiếu nhập";
            this.mnuCreateReceipt.Click += new System.EventHandler(this.mnuCreateReceipt_Click);

            // mnuTransferLocation
            this.mnuTransferLocation.Name = "mnuTransferLocation";
            this.mnuTransferLocation.Size = new System.Drawing.Size(209, 22);
            this.mnuTransferLocation.Text = "Điều chuyển vị trí";
            this.mnuTransferLocation.Click += new System.EventHandler(this.mnuTransferLocation_Click);

            // mnuQuickStocktake
            this.mnuQuickStocktake.Name = "mnuQuickStocktake";
            this.mnuQuickStocktake.Size = new System.Drawing.Size(209, 22);
            this.mnuQuickStocktake.Text = "Kiểm kê mặt hàng này";
            this.mnuQuickStocktake.Click += new System.EventHandler(this.btnTaskStocktake_Click);

            // mnuManageCategories
            this.mnuManageCategories.Name = "mnuManageCategories";
            this.mnuManageCategories.Size = new System.Drawing.Size(209, 22);
            this.mnuManageCategories.Text = "Quản lý Nhóm hàng...";
            this.mnuManageCategories.Click += new System.EventHandler(this.mnuManageCategories_Click);

            // FormCategoryManagement
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            this.ClientSize = new System.Drawing.Size(1050, 640);
            this.Controls.Add(this.panelInventoryCard);
            this.Controls.Add(this.panelBottomSpacer);
            this.Controls.Add(this.panelBottomArea);
            this.Controls.Add(this.panelTopSpacer);
            this.Controls.Add(this.tlpKpiRow);
            this.Controls.Add(this.panelTopBanner);
            this.KeyPreview = true;
            this.Name = "FormCategoryManagement";
            this.Padding = new System.Windows.Forms.Padding(12, 4, 12, 8);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "QUẢN LÝ KHO & NHẬP HÀNG (Inventory & Warehouse)";
            this.Load += new System.EventHandler(this.FormCategoryManagement_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormCategoryManagement_KeyDown);

            this.panelTopBanner.ResumeLayout(false);
            this.panelTopBanner.PerformLayout();
            this.tlpKpiRow.ResumeLayout(false);
            this.cardKpiTotal.ResumeLayout(false);
            this.cardKpiTotal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picKpiTotalIcon)).EndInit();
            this.cardKpiLowStock.ResumeLayout(false);
            this.cardKpiLowStock.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picKpiLowIcon)).EndInit();
            this.cardKpiExpiring.ResumeLayout(false);
            this.cardKpiExpiring.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picKpiExpIcon)).EndInit();
            this.panelBottomArea.ResumeLayout(false);
            this.panelImportScreenCard.ResumeLayout(false);
            this.panelImportScreenCard.PerformLayout();
            this.panelFeaturedSupplierCard.ResumeLayout(false);
            this.panelFeaturedSupplierCard.PerformLayout();
            this.panelTaskMenuCard.ResumeLayout(false);
            this.panelTaskMenuCard.PerformLayout();
            this.panelInventoryCard.ResumeLayout(false);
            this.panelPagination.ResumeLayout(false);
            this.panelPagination.PerformLayout();
            this.panelGridHeader.ResumeLayout(false);
            this.panelGridHeader.PerformLayout();
            this.panelFilterBar.ResumeLayout(false);
            this.panelFilterBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategories)).EndInit();
            this.cmsInventoryActions.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel panelTopBanner;
        private System.Windows.Forms.Label lblPageTitle;
        private System.Windows.Forms.TableLayoutPanel tlpKpiRow;
        private System.Windows.Forms.Panel cardKpiTotal;
        private System.Windows.Forms.Label lblKpiTotalTitle;
        private System.Windows.Forms.Label lblKpiTotalValue;
        private System.Windows.Forms.Label lblKpiTotalSub;
        private System.Windows.Forms.PictureBox picKpiTotalIcon;
        private System.Windows.Forms.Panel cardKpiLowStock;
        private System.Windows.Forms.Label lblKpiLowTitle;
        private System.Windows.Forms.Label lblKpiLowValue;
        private System.Windows.Forms.Label lblKpiLowSub;
        private System.Windows.Forms.PictureBox picKpiLowIcon;
        private System.Windows.Forms.Panel cardKpiExpiring;
        private System.Windows.Forms.Label lblKpiExpTitle;
        private System.Windows.Forms.Label lblKpiExpValue;
        private System.Windows.Forms.Label lblKpiExpSub;
        private System.Windows.Forms.PictureBox picKpiExpIcon;
        private System.Windows.Forms.Panel panelTopSpacer;
        private System.Windows.Forms.Panel panelBottomArea;
        private System.Windows.Forms.Panel panelImportScreenCard;
        private System.Windows.Forms.Label lblImportScreenTitle;
        private System.Windows.Forms.Label lblReceiptNo;
        private System.Windows.Forms.TextBox txtReceiptNo;
        private System.Windows.Forms.Label lblSupplierSelect;
        private System.Windows.Forms.ComboBox cboImportSupplier;
        private System.Windows.Forms.Label lblImportDate;
        private System.Windows.Forms.DateTimePicker dtpImportDate;
        private System.Windows.Forms.TextBox txtReceiptDetails;
        private System.Windows.Forms.Panel panelBottomLeftSpacer;
        private System.Windows.Forms.Panel panelFeaturedSupplierCard;
        private System.Windows.Forms.Label lblFeaturedSupplierTitle;
        private System.Windows.Forms.ListBox lstFeaturedSuppliers;
        private System.Windows.Forms.Panel panelBottomRightSpacer;
        private System.Windows.Forms.Panel panelTaskMenuCard;
        private System.Windows.Forms.Label lblTaskMenuTitle;
        private System.Windows.Forms.Button btnTaskImportF7;
        private System.Windows.Forms.Button btnTaskStocktake;
        private System.Windows.Forms.Button btnTaskWriteOff;
        private System.Windows.Forms.Button btnTaskReport;
        private System.Windows.Forms.Panel panelBottomSpacer;
        private System.Windows.Forms.Panel panelInventoryCard;
        private System.Windows.Forms.Panel panelGridHeader;
        private System.Windows.Forms.Label lblGridTitle;
        private System.Windows.Forms.Button btnHeaderPrev;
        private System.Windows.Forms.Label lblHeaderPageInfo;
        private System.Windows.Forms.Button btnHeaderNext;
        private System.Windows.Forms.Button btnHeaderTransfer;
        private System.Windows.Forms.Button btnHeaderCategoryMgr;
        private System.Windows.Forms.Button btnHeaderDelete;
        private System.Windows.Forms.Panel panelPagination;
        private System.Windows.Forms.Label lblPageSummary;
        private System.Windows.Forms.Label lblPageSize;
        private System.Windows.Forms.ComboBox cboPageSize;
        private System.Windows.Forms.Button btnFirstPage;
        private System.Windows.Forms.Button btnPrevPage;
        private System.Windows.Forms.Label lblPageInfo;
        private System.Windows.Forms.Button btnNextPage;
        private System.Windows.Forms.Button btnLastPage;
        private System.Windows.Forms.Panel panelFilterBar;
        private System.Windows.Forms.Label lblFilterCat;
        private System.Windows.Forms.ComboBox cboFilterCategory;
        private System.Windows.Forms.Label lblFilterSupplier;
        private System.Windows.Forms.ComboBox cboFilterSupplier;
        private System.Windows.Forms.Label lblFilterStatus;
        private System.Windows.Forms.ComboBox cboFilterStatus;
        private System.Windows.Forms.Label lblFilterDate;
        private System.Windows.Forms.DateTimePicker dtpFilterDate;
        private System.Windows.Forms.DataGridView dgvCategories;
        private System.Windows.Forms.ContextMenuStrip cmsInventoryActions;
        private System.Windows.Forms.ToolStripMenuItem mnuCreateReceipt;
        private System.Windows.Forms.ToolStripMenuItem mnuTransferLocation;
        private System.Windows.Forms.ToolStripMenuItem mnuQuickStocktake;
        private System.Windows.Forms.ToolStripMenuItem mnuManageCategories;
    }
}

namespace MiniSupermarket.WinForms
{
    partial class FormCustomerManagement
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
            this.panelActionBar = new System.Windows.Forms.Panel();
            this.lblSearchTitle = new System.Windows.Forms.Label();
            this.txtKeyword = new System.Windows.Forms.TextBox();
            this.lblTypeFilter = new System.Windows.Forms.Label();
            this.cboCustomerType = new System.Windows.Forms.ComboBox();
            this.lblStatusFilter = new System.Windows.Forms.Label();
            this.cboStatus = new System.Windows.Forms.ComboBox();
            this.btnImportExcel = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.panelMainBody = new System.Windows.Forms.Panel();
            this.panelLeftArea = new System.Windows.Forms.Panel();
            this.panelGridCard = new System.Windows.Forms.Panel();
            this.panelGridHeader = new System.Windows.Forms.Panel();
            this.lblGridTitle = new System.Windows.Forms.Label();
            this.btnQuickEdit = new System.Windows.Forms.Button();
            this.btnQuickPoints = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.dgvCustomers = new System.Windows.Forms.DataGridView();
            this.panelKpiSection = new System.Windows.Forms.Panel();
            this.lblKpiHeader = new System.Windows.Forms.Label();
            this.tlpKpiCards = new System.Windows.Forms.TableLayoutPanel();
            this.pnlKpiTotalCustomers = new System.Windows.Forms.Panel();
            this.lblKpi1Title = new System.Windows.Forms.Label();
            this.lblKpi1Value = new System.Windows.Forms.Label();
            this.lblKpi1Sub = new System.Windows.Forms.Label();
            this.picKpi1Icon = new System.Windows.Forms.PictureBox();
            this.pnlKpiNewMembers = new System.Windows.Forms.Panel();
            this.lblKpi2Title = new System.Windows.Forms.Label();
            this.lblKpi2Value = new System.Windows.Forms.Label();
            this.lblKpi2Sub = new System.Windows.Forms.Label();
            this.picKpi2Icon = new System.Windows.Forms.PictureBox();
            this.pnlKpiTotalPoints = new System.Windows.Forms.Panel();
            this.lblKpi3Title = new System.Windows.Forms.Label();
            this.lblKpi3Value = new System.Windows.Forms.Label();
            this.lblKpi3Sub = new System.Windows.Forms.Label();
            this.picKpi3Icon = new System.Windows.Forms.PictureBox();
            this.panelRightArea = new System.Windows.Forms.Panel();
            this.panelDetailCard = new System.Windows.Forms.Panel();
            this.lblDetailTitle = new System.Windows.Forms.Label();
            this.picCustomerAvatar = new System.Windows.Forms.PictureBox();
            this.lblDetailPhoto = new System.Windows.Forms.Label();
            this.lblDetailId = new System.Windows.Forms.Label();
            this.lblDetailName = new System.Windows.Forms.Label();
            this.lblDetailLevel = new System.Windows.Forms.Label();
            this.lblDetailSpent = new System.Windows.Forms.Label();
            this.lblHistoryTitle = new System.Windows.Forms.Label();
            this.dgvPointHistory = new System.Windows.Forms.DataGridView();
            this.panelVoucherCard = new System.Windows.Forms.Panel();
            this.lblVoucherTitle = new System.Windows.Forms.Label();
            this.btnRedeemVoucher = new System.Windows.Forms.Button();
            this.lstVouchers = new System.Windows.Forms.ListBox();
            this.cmsCustomerActions = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuEditCustomer = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAddPoints = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuViewHistory = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.mnuDeleteCustomer = new System.Windows.Forms.ToolStripMenuItem();

            this.panelActionBar.SuspendLayout();
            this.panelMainBody.SuspendLayout();
            this.panelLeftArea.SuspendLayout();
            this.panelGridCard.SuspendLayout();
            this.panelGridHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomers)).BeginInit();
            this.panelKpiSection.SuspendLayout();
            this.tlpKpiCards.SuspendLayout();
            this.pnlKpiTotalCustomers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picKpi1Icon)).BeginInit();
            this.pnlKpiNewMembers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picKpi2Icon)).BeginInit();
            this.pnlKpiTotalPoints.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picKpi3Icon)).BeginInit();
            this.panelRightArea.SuspendLayout();
            this.panelDetailCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCustomerAvatar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPointHistory)).BeginInit();
            this.panelVoucherCard.SuspendLayout();
            this.cmsCustomerActions.SuspendLayout();
            this.SuspendLayout();

            // panelActionBar
            this.panelActionBar.BackColor = System.Drawing.Color.White;
            this.panelActionBar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelActionBar.Controls.Add(this.btnAdd);
            this.panelActionBar.Controls.Add(this.btnImportExcel);
            this.panelActionBar.Controls.Add(this.cboStatus);
            this.panelActionBar.Controls.Add(this.lblStatusFilter);
            this.panelActionBar.Controls.Add(this.cboCustomerType);
            this.panelActionBar.Controls.Add(this.lblTypeFilter);
            this.panelActionBar.Controls.Add(this.txtKeyword);
            this.panelActionBar.Controls.Add(this.lblSearchTitle);
            this.panelActionBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelActionBar.Location = new System.Drawing.Point(12, 8);
            this.panelActionBar.Name = "panelActionBar";
            this.panelActionBar.Size = new System.Drawing.Size(1026, 72);
            this.panelActionBar.TabIndex = 0;

            // lblSearchTitle
            this.lblSearchTitle.AutoSize = true;
            this.lblSearchTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblSearchTitle.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.lblSearchTitle.Location = new System.Drawing.Point(14, 10);
            this.lblSearchTitle.Name = "lblSearchTitle";
            this.lblSearchTitle.Size = new System.Drawing.Size(185, 19);
            this.lblSearchTitle.TabIndex = 0;
            this.lblSearchTitle.Text = "Thanh tìm kiếm & Thao tác";

            // txtKeyword
            this.txtKeyword.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtKeyword.Location = new System.Drawing.Point(16, 34);
            this.txtKeyword.Name = "txtKeyword";
            this.txtKeyword.PlaceholderText = "🔍 Nhập SĐT hoặc Tên khách hàng...";
            this.txtKeyword.Size = new System.Drawing.Size(270, 25);
            this.txtKeyword.TabIndex = 1;
            this.txtKeyword.TextChanged += new System.EventHandler(this.txtKeyword_TextChanged);
            this.txtKeyword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtKeyword_KeyDown);

            // lblTypeFilter
            this.lblTypeFilter.AutoSize = true;
            this.lblTypeFilter.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblTypeFilter.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
            this.lblTypeFilter.Location = new System.Drawing.Point(305, 11);
            this.lblTypeFilter.Name = "lblTypeFilter";
            this.lblTypeFilter.Size = new System.Drawing.Size(96, 17);
            this.lblTypeFilter.TabIndex = 2;
            this.lblTypeFilter.Text = "Loại khách hàng";

            // cboCustomerType
            this.cboCustomerType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCustomerType.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboCustomerType.FormattingEnabled = true;
            this.cboCustomerType.Items.AddRange(new object[] {
                "Tất cả",
                "Thành viên",
                "VIP"
            });
            this.cboCustomerType.Location = new System.Drawing.Point(305, 34);
            this.cboCustomerType.Name = "cboCustomerType";
            this.cboCustomerType.Size = new System.Drawing.Size(155, 25);
            this.cboCustomerType.TabIndex = 3;
            this.cboCustomerType.SelectedIndexChanged += new System.EventHandler(this.Filter_Changed);

            // lblStatusFilter
            this.lblStatusFilter.AutoSize = true;
            this.lblStatusFilter.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblStatusFilter.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
            this.lblStatusFilter.Location = new System.Drawing.Point(478, 11);
            this.lblStatusFilter.Name = "lblStatusFilter";
            this.lblStatusFilter.Size = new System.Drawing.Size(63, 17);
            this.lblStatusFilter.TabIndex = 4;
            this.lblStatusFilter.Text = "Trạng thái";

            // cboStatus
            this.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStatus.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboStatus.FormattingEnabled = true;
            this.cboStatus.Items.AddRange(new object[] {
                "Tất cả",
                "Hoạt động",
                "Khóa"
            });
            this.cboStatus.Location = new System.Drawing.Point(478, 34);
            this.cboStatus.Name = "cboStatus";
            this.cboStatus.Size = new System.Drawing.Size(145, 25);
            this.cboStatus.TabIndex = 5;
            this.cboStatus.SelectedIndexChanged += new System.EventHandler(this.Filter_Changed);

            // btnImportExcel
            this.btnImportExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImportExcel.BackColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.btnImportExcel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnImportExcel.FlatAppearance.BorderSize = 0;
            this.btnImportExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImportExcel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnImportExcel.ForeColor = System.Drawing.Color.White;
            this.btnImportExcel.Location = new System.Drawing.Point(650, 16);
            this.btnImportExcel.Name = "btnImportExcel";
            this.btnImportExcel.Size = new System.Drawing.Size(150, 42);
            this.btnImportExcel.TabIndex = 6;
            this.btnImportExcel.Text = "Import Excel";
            this.btnImportExcel.UseVisualStyleBackColor = false;
            this.btnImportExcel.Click += new System.EventHandler(this.btnImportExcel_Click);

            // btnAdd
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(812, 16);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(198, 42);
            this.btnAdd.TabIndex = 7;
            this.btnAdd.Text = "Thêm Khách Hàng (F6)";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);

            // panelMainBody
            this.panelMainBody.Controls.Add(this.panelLeftArea);
            this.panelMainBody.Controls.Add(this.panelRightArea);
            this.panelMainBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMainBody.Location = new System.Drawing.Point(12, 80);
            this.panelMainBody.Name = "panelMainBody";
            this.panelMainBody.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.panelMainBody.Size = new System.Drawing.Size(1026, 568);
            this.panelMainBody.TabIndex = 1;

            // panelLeftArea
            this.panelLeftArea.Controls.Add(this.panelGridCard);
            this.panelLeftArea.Controls.Add(this.panelKpiSection);
            this.panelLeftArea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelLeftArea.Location = new System.Drawing.Point(0, 10);
            this.panelLeftArea.Name = "panelLeftArea";
            this.panelLeftArea.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.panelLeftArea.Size = new System.Drawing.Size(716, 558);
            this.panelLeftArea.TabIndex = 0;

            // panelGridCard
            this.panelGridCard.BackColor = System.Drawing.Color.White;
            this.panelGridCard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelGridCard.Controls.Add(this.dgvCustomers);
            this.panelGridCard.Controls.Add(this.panelGridHeader);
            this.panelGridCard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelGridCard.Location = new System.Drawing.Point(0, 0);
            this.panelGridCard.Name = "panelGridCard";
            this.panelGridCard.Padding = new System.Windows.Forms.Padding(10);
            this.panelGridCard.Size = new System.Drawing.Size(706, 408);
            this.panelGridCard.TabIndex = 0;

            // panelGridHeader
            this.panelGridHeader.Controls.Add(this.btnDelete);
            this.panelGridHeader.Controls.Add(this.btnQuickPoints);
            this.panelGridHeader.Controls.Add(this.btnQuickEdit);
            this.panelGridHeader.Controls.Add(this.lblGridTitle);
            this.panelGridHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelGridHeader.Location = new System.Drawing.Point(10, 10);
            this.panelGridHeader.Name = "panelGridHeader";
            this.panelGridHeader.Size = new System.Drawing.Size(684, 34);
            this.panelGridHeader.TabIndex = 0;

            // lblGridTitle
            this.lblGridTitle.AutoSize = true;
            this.lblGridTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblGridTitle.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.lblGridTitle.Location = new System.Drawing.Point(2, 6);
            this.lblGridTitle.Name = "lblGridTitle";
            this.lblGridTitle.Size = new System.Drawing.Size(277, 20);
            this.lblGridTitle.TabIndex = 0;
            this.lblGridTitle.Text = "DANH SÁCH KHÁCH HÀNG THÀNH VIÊN";

            // btnQuickEdit
            this.btnQuickEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnQuickEdit.BackColor = System.Drawing.Color.FromArgb(44, 53, 75);
            this.btnQuickEdit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnQuickEdit.FlatAppearance.BorderSize = 0;
            this.btnQuickEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuickEdit.Font = new System.Drawing.Font("Segoe UI Symbol", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnQuickEdit.ForeColor = System.Drawing.Color.White;
            this.btnQuickEdit.Location = new System.Drawing.Point(578, 3);
            this.btnQuickEdit.Name = "btnQuickEdit";
            this.btnQuickEdit.Size = new System.Drawing.Size(32, 26);
            this.btnQuickEdit.TabIndex = 1;
            this.btnQuickEdit.Text = "✎";
            this.btnQuickEdit.UseVisualStyleBackColor = false;
            this.btnQuickEdit.Click += new System.EventHandler(this.btnUpdate_Click);

            // btnQuickPoints
            this.btnQuickPoints.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnQuickPoints.BackColor = System.Drawing.Color.FromArgb(44, 53, 75);
            this.btnQuickPoints.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnQuickPoints.FlatAppearance.BorderSize = 0;
            this.btnQuickPoints.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuickPoints.Font = new System.Drawing.Font("Segoe UI Symbol", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnQuickPoints.ForeColor = System.Drawing.Color.White;
            this.btnQuickPoints.Location = new System.Drawing.Point(614, 3);
            this.btnQuickPoints.Name = "btnQuickPoints";
            this.btnQuickPoints.Size = new System.Drawing.Size(32, 26);
            this.btnQuickPoints.TabIndex = 2;
            this.btnQuickPoints.Text = "☰";
            this.btnQuickPoints.UseVisualStyleBackColor = false;
            this.btnQuickPoints.Click += new System.EventHandler(this.mnuAddPoints_Click);

            // btnDelete
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(44, 53, 75);
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI Symbol", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(650, 3);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(32, 26);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "🗑";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);

            // dgvCustomers
            this.dgvCustomers.AllowUserToAddRows = false;
            this.dgvCustomers.AllowUserToDeleteRows = false;
            this.dgvCustomers.BackgroundColor = System.Drawing.Color.White;
            this.dgvCustomers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dgvCustomers.ColumnHeadersHeight = 38;
            this.dgvCustomers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvCustomers.ContextMenuStrip = this.cmsCustomerActions;
            this.dgvCustomers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCustomers.EnableHeadersVisualStyles = false;
            this.dgvCustomers.GridColor = System.Drawing.Color.FromArgb(226, 232, 240);
            this.dgvCustomers.Location = new System.Drawing.Point(10, 44);
            this.dgvCustomers.MultiSelect = false;
            this.dgvCustomers.Name = "dgvCustomers";
            this.dgvCustomers.ReadOnly = true;
            this.dgvCustomers.RowHeadersVisible = false;
            this.dgvCustomers.RowTemplate.Height = 30;
            this.dgvCustomers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCustomers.Size = new System.Drawing.Size(684, 352);
            this.dgvCustomers.TabIndex = 1;
            this.dgvCustomers.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCustomers_CellClick);
            this.dgvCustomers.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvCustomers_CellMouseDown);
            this.dgvCustomers.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dgvCustomers_RowPrePaint);

            // panelKpiSection
            this.panelKpiSection.Controls.Add(this.tlpKpiCards);
            this.panelKpiSection.Controls.Add(this.lblKpiHeader);
            this.panelKpiSection.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelKpiSection.Location = new System.Drawing.Point(0, 408);
            this.panelKpiSection.Name = "panelKpiSection";
            this.panelKpiSection.Padding = new System.Windows.Forms.Padding(0, 8, 0, 0);
            this.panelKpiSection.Size = new System.Drawing.Size(706, 150);
            this.panelKpiSection.TabIndex = 1;

            // lblKpiHeader
            this.lblKpiHeader.AutoSize = true;
            this.lblKpiHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblKpiHeader.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.lblKpiHeader.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.lblKpiHeader.Location = new System.Drawing.Point(0, 8);
            this.lblKpiHeader.Name = "lblKpiHeader";
            this.lblKpiHeader.Size = new System.Drawing.Size(73, 19);
            this.lblKpiHeader.TabIndex = 0;
            this.lblKpiHeader.Text = "KPI Cards";

            // tlpKpiCards
            this.tlpKpiCards.ColumnCount = 3;
            this.tlpKpiCards.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tlpKpiCards.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tlpKpiCards.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.34F));
            this.tlpKpiCards.Controls.Add(this.pnlKpiTotalCustomers, 0, 0);
            this.tlpKpiCards.Controls.Add(this.pnlKpiNewMembers, 1, 0);
            this.tlpKpiCards.Controls.Add(this.pnlKpiTotalPoints, 2, 0);
            this.tlpKpiCards.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpKpiCards.Location = new System.Drawing.Point(0, 27);
            this.tlpKpiCards.Name = "tlpKpiCards";
            this.tlpKpiCards.RowCount = 1;
            this.tlpKpiCards.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpKpiCards.Size = new System.Drawing.Size(706, 123);
            this.tlpKpiCards.TabIndex = 1;

            // pnlKpiTotalCustomers
            this.pnlKpiTotalCustomers.BackColor = System.Drawing.Color.White;
            this.pnlKpiTotalCustomers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlKpiTotalCustomers.Controls.Add(this.picKpi1Icon);
            this.pnlKpiTotalCustomers.Controls.Add(this.lblKpi1Sub);
            this.pnlKpiTotalCustomers.Controls.Add(this.lblKpi1Value);
            this.pnlKpiTotalCustomers.Controls.Add(this.lblKpi1Title);
            this.pnlKpiTotalCustomers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlKpiTotalCustomers.Location = new System.Drawing.Point(0, 4);
            this.pnlKpiTotalCustomers.Margin = new System.Windows.Forms.Padding(0, 4, 6, 4);
            this.pnlKpiTotalCustomers.Name = "pnlKpiTotalCustomers";
            this.pnlKpiTotalCustomers.Size = new System.Drawing.Size(229, 115);
            this.pnlKpiTotalCustomers.TabIndex = 0;

            // lblKpi1Title
            this.lblKpi1Title.AutoSize = true;
            this.lblKpi1Title.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblKpi1Title.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
            this.lblKpi1Title.Location = new System.Drawing.Point(12, 10);
            this.lblKpi1Title.Name = "lblKpi1Title";
            this.lblKpi1Title.Size = new System.Drawing.Size(134, 17);
            this.lblKpi1Title.TabIndex = 0;
            this.lblKpi1Title.Text = "TỔNG KHÁCH HÀNG";

            // lblKpi1Value
            this.lblKpi1Value.AutoSize = true;
            this.lblKpi1Value.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblKpi1Value.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.lblKpi1Value.Location = new System.Drawing.Point(10, 34);
            this.lblKpi1Value.Name = "lblKpi1Value";
            this.lblKpi1Value.Size = new System.Drawing.Size(92, 41);
            this.lblKpi1Value.TabIndex = 1;
            this.lblKpi1Value.Text = "1,250";

            // lblKpi1Sub
            this.lblKpi1Sub.AutoSize = true;
            this.lblKpi1Sub.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblKpi1Sub.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.lblKpi1Sub.Location = new System.Drawing.Point(14, 80);
            this.lblKpi1Sub.Name = "lblKpi1Sub";
            this.lblKpi1Sub.Size = new System.Drawing.Size(36, 17);
            this.lblKpi1Sub.TabIndex = 2;
            this.lblKpi1Sub.Text = "VND";

            // picKpi1Icon
            this.picKpi1Icon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picKpi1Icon.Location = new System.Drawing.Point(168, 42);
            this.picKpi1Icon.Name = "picKpi1Icon";
            this.picKpi1Icon.Size = new System.Drawing.Size(46, 46);
            this.picKpi1Icon.TabIndex = 3;
            this.picKpi1Icon.TabStop = false;

            // pnlKpiNewMembers
            this.pnlKpiNewMembers.BackColor = System.Drawing.Color.White;
            this.pnlKpiNewMembers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlKpiNewMembers.Controls.Add(this.picKpi2Icon);
            this.pnlKpiNewMembers.Controls.Add(this.lblKpi2Sub);
            this.pnlKpiNewMembers.Controls.Add(this.lblKpi2Value);
            this.pnlKpiNewMembers.Controls.Add(this.lblKpi2Title);
            this.pnlKpiNewMembers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlKpiNewMembers.Location = new System.Drawing.Point(241, 4);
            this.pnlKpiNewMembers.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.pnlKpiNewMembers.Name = "pnlKpiNewMembers";
            this.pnlKpiNewMembers.Size = new System.Drawing.Size(223, 115);
            this.pnlKpiNewMembers.TabIndex = 1;

            // lblKpi2Title
            this.lblKpi2Title.AutoSize = true;
            this.lblKpi2Title.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblKpi2Title.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
            this.lblKpi2Title.Location = new System.Drawing.Point(12, 10);
            this.lblKpi2Title.Name = "lblKpi2Title";
            this.lblKpi2Title.Size = new System.Drawing.Size(166, 17);
            this.lblKpi2Title.TabIndex = 0;
            this.lblKpi2Title.Text = "THÀNH VIÊN MỚI (Tháng)";

            // lblKpi2Value
            this.lblKpi2Value.AutoSize = true;
            this.lblKpi2Value.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblKpi2Value.ForeColor = System.Drawing.Color.FromArgb(22, 163, 74);
            this.lblKpi2Value.Location = new System.Drawing.Point(10, 34);
            this.lblKpi2Value.Name = "lblKpi2Value";
            this.lblKpi2Value.Size = new System.Drawing.Size(49, 41);
            this.lblKpi2Value.TabIndex = 1;
            this.lblKpi2Value.Text = "85";

            // lblKpi2Sub
            this.lblKpi2Sub.AutoSize = true;
            this.lblKpi2Sub.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblKpi2Sub.ForeColor = System.Drawing.Color.FromArgb(22, 163, 74);
            this.lblKpi2Sub.Location = new System.Drawing.Point(14, 80);
            this.lblKpi2Sub.Name = "lblKpi2Sub";
            this.lblKpi2Sub.Size = new System.Drawing.Size(55, 17);
            this.lblKpi2Sub.TabIndex = 2;
            this.lblKpi2Sub.Text = "màu lục";

            // picKpi2Icon
            this.picKpi2Icon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picKpi2Icon.Location = new System.Drawing.Point(162, 42);
            this.picKpi2Icon.Name = "picKpi2Icon";
            this.picKpi2Icon.Size = new System.Drawing.Size(46, 46);
            this.picKpi2Icon.TabIndex = 3;
            this.picKpi2Icon.TabStop = false;

            // pnlKpiTotalPoints
            this.pnlKpiTotalPoints.BackColor = System.Drawing.Color.White;
            this.pnlKpiTotalPoints.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlKpiTotalPoints.Controls.Add(this.picKpi3Icon);
            this.pnlKpiTotalPoints.Controls.Add(this.lblKpi3Sub);
            this.pnlKpiTotalPoints.Controls.Add(this.lblKpi3Value);
            this.pnlKpiTotalPoints.Controls.Add(this.lblKpi3Title);
            this.pnlKpiTotalPoints.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlKpiTotalPoints.Location = new System.Drawing.Point(476, 4);
            this.pnlKpiTotalPoints.Margin = new System.Windows.Forms.Padding(6, 4, 0, 4);
            this.pnlKpiTotalPoints.Name = "pnlKpiTotalPoints";
            this.pnlKpiTotalPoints.Size = new System.Drawing.Size(230, 115);
            this.pnlKpiTotalPoints.TabIndex = 2;

            // lblKpi3Title
            this.lblKpi3Title.AutoSize = true;
            this.lblKpi3Title.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblKpi3Title.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
            this.lblKpi3Title.Location = new System.Drawing.Point(12, 10);
            this.lblKpi3Title.Name = "lblKpi3Title";
            this.lblKpi3Title.Size = new System.Drawing.Size(141, 17);
            this.lblKpi3Title.TabIndex = 0;
            this.lblKpi3Title.Text = "TỔNG ĐIỂM TÍCH LŨY";

            // lblKpi3Value
            this.lblKpi3Value.AutoSize = true;
            this.lblKpi3Value.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblKpi3Value.ForeColor = System.Drawing.Color.FromArgb(217, 154, 38);
            this.lblKpi3Value.Location = new System.Drawing.Point(10, 34);
            this.lblKpi3Value.Name = "lblKpi3Value";
            this.lblKpi3Value.Size = new System.Drawing.Size(83, 41);
            this.lblKpi3Value.TabIndex = 1;
            this.lblKpi3Value.Text = "3.1M";

            // lblKpi3Sub
            this.lblKpi3Sub.AutoSize = true;
            this.lblKpi3Sub.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblKpi3Sub.ForeColor = System.Drawing.Color.FromArgb(217, 154, 38);
            this.lblKpi3Sub.Location = new System.Drawing.Point(14, 80);
            this.lblKpi3Sub.Name = "lblKpi3Sub";
            this.lblKpi3Sub.Size = new System.Drawing.Size(36, 17);
            this.lblKpi3Sub.TabIndex = 2;
            this.lblKpi3Sub.Text = "VND";

            // picKpi3Icon
            this.picKpi3Icon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picKpi3Icon.Location = new System.Drawing.Point(168, 42);
            this.picKpi3Icon.Name = "picKpi3Icon";
            this.picKpi3Icon.Size = new System.Drawing.Size(46, 46);
            this.picKpi3Icon.TabIndex = 3;
            this.picKpi3Icon.TabStop = false;

            // panelRightArea
            this.panelRightArea.Controls.Add(this.panelDetailCard);
            this.panelRightArea.Controls.Add(this.panelVoucherCard);
            this.panelRightArea.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelRightArea.Location = new System.Drawing.Point(716, 10);
            this.panelRightArea.Name = "panelRightArea";
            this.panelRightArea.Size = new System.Drawing.Size(310, 558);
            this.panelRightArea.TabIndex = 1;

            // panelDetailCard
            this.panelDetailCard.BackColor = System.Drawing.Color.White;
            this.panelDetailCard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelDetailCard.Controls.Add(this.dgvPointHistory);
            this.panelDetailCard.Controls.Add(this.lblHistoryTitle);
            this.panelDetailCard.Controls.Add(this.lblDetailSpent);
            this.panelDetailCard.Controls.Add(this.lblDetailLevel);
            this.panelDetailCard.Controls.Add(this.lblDetailName);
            this.panelDetailCard.Controls.Add(this.lblDetailId);
            this.panelDetailCard.Controls.Add(this.lblDetailPhoto);
            this.panelDetailCard.Controls.Add(this.picCustomerAvatar);
            this.panelDetailCard.Controls.Add(this.lblDetailTitle);
            this.panelDetailCard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDetailCard.Location = new System.Drawing.Point(0, 0);
            this.panelDetailCard.Name = "panelDetailCard";
            this.panelDetailCard.Padding = new System.Windows.Forms.Padding(12);
            this.panelDetailCard.Size = new System.Drawing.Size(310, 348);
            this.panelDetailCard.TabIndex = 0;

            // lblDetailTitle
            this.lblDetailTitle.AutoSize = true;
            this.lblDetailTitle.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.lblDetailTitle.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.lblDetailTitle.Location = new System.Drawing.Point(10, 10);
            this.lblDetailTitle.Name = "lblDetailTitle";
            this.lblDetailTitle.Size = new System.Drawing.Size(222, 19);
            this.lblDetailTitle.TabIndex = 0;
            this.lblDetailTitle.Text = "Chi Tiết Khách Hàng / Đổi Thưởng";

            // picCustomerAvatar
            this.picCustomerAvatar.Location = new System.Drawing.Point(14, 40);
            this.picCustomerAvatar.Name = "picCustomerAvatar";
            this.picCustomerAvatar.Size = new System.Drawing.Size(86, 86);
            this.picCustomerAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picCustomerAvatar.TabIndex = 1;
            this.picCustomerAvatar.TabStop = false;

            // lblDetailPhoto
            this.lblDetailPhoto.AutoSize = true;
            this.lblDetailPhoto.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblDetailPhoto.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
            this.lblDetailPhoto.Location = new System.Drawing.Point(110, 38);
            this.lblDetailPhoto.Name = "lblDetailPhoto";
            this.lblDetailPhoto.Size = new System.Drawing.Size(63, 17);
            this.lblDetailPhoto.TabIndex = 2;
            this.lblDetailPhoto.Text = "Photo: 10";

            // lblDetailId
            this.lblDetailId.AutoSize = true;
            this.lblDetailId.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblDetailId.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
            this.lblDetailId.Location = new System.Drawing.Point(110, 58);
            this.lblDetailId.Name = "lblDetailId";
            this.lblDetailId.Size = new System.Drawing.Size(96, 17);
            this.lblDetailId.TabIndex = 3;
            this.lblDetailId.Text = "ID: 1000000003";

            // lblDetailName
            this.lblDetailName.AutoSize = true;
            this.lblDetailName.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblDetailName.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.lblDetailName.Location = new System.Drawing.Point(110, 78);
            this.lblDetailName.Name = "lblDetailName";
            this.lblDetailName.Size = new System.Drawing.Size(134, 17);
            this.lblDetailName.TabIndex = 4;
            this.lblDetailName.Text = "Name: Nguyen Van A";

            // lblDetailLevel
            this.lblDetailLevel.AutoSize = true;
            this.lblDetailLevel.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblDetailLevel.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
            this.lblDetailLevel.Location = new System.Drawing.Point(110, 98);
            this.lblDetailLevel.Name = "lblDetailLevel";
            this.lblDetailLevel.Size = new System.Drawing.Size(63, 17);
            this.lblDetailLevel.TabIndex = 5;
            this.lblDetailLevel.Text = "Level: VIP";

            // lblDetailSpent
            this.lblDetailSpent.AutoSize = true;
            this.lblDetailSpent.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblDetailSpent.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
            this.lblDetailSpent.Location = new System.Drawing.Point(110, 118);
            this.lblDetailSpent.Name = "lblDetailSpent";
            this.lblDetailSpent.Size = new System.Drawing.Size(156, 17);
            this.lblDetailSpent.TabIndex = 6;
            this.lblDetailSpent.Text = "Total spent: 895.000 VND";

            // lblHistoryTitle
            this.lblHistoryTitle.AutoSize = true;
            this.lblHistoryTitle.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.lblHistoryTitle.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.lblHistoryTitle.Location = new System.Drawing.Point(10, 150);
            this.lblHistoryTitle.Name = "lblHistoryTitle";
            this.lblHistoryTitle.Size = new System.Drawing.Size(123, 19);
            this.lblHistoryTitle.TabIndex = 7;
            this.lblHistoryTitle.Text = "Lịch Sử Tích Điểm";

            // dgvPointHistory
            this.dgvPointHistory.AllowUserToAddRows = false;
            this.dgvPointHistory.AllowUserToDeleteRows = false;
            this.dgvPointHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPointHistory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPointHistory.BackgroundColor = System.Drawing.Color.White;
            this.dgvPointHistory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dgvPointHistory.ColumnHeadersHeight = 28;
            this.dgvPointHistory.EnableHeadersVisualStyles = false;
            this.dgvPointHistory.GridColor = System.Drawing.Color.FromArgb(226, 232, 240);
            this.dgvPointHistory.Location = new System.Drawing.Point(12, 175);
            this.dgvPointHistory.Name = "dgvPointHistory";
            this.dgvPointHistory.ReadOnly = true;
            this.dgvPointHistory.RowHeadersVisible = false;
            this.dgvPointHistory.RowTemplate.Height = 24;
            this.dgvPointHistory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPointHistory.Size = new System.Drawing.Size(284, 158);
            this.dgvPointHistory.TabIndex = 8;

            // panelVoucherCard
            this.panelVoucherCard.BackColor = System.Drawing.Color.White;
            this.panelVoucherCard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelVoucherCard.Controls.Add(this.btnRedeemVoucher);
            this.panelVoucherCard.Controls.Add(this.lstVouchers);
            this.panelVoucherCard.Controls.Add(this.lblVoucherTitle);
            this.panelVoucherCard.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelVoucherCard.Location = new System.Drawing.Point(0, 348);
            this.panelVoucherCard.Name = "panelVoucherCard";
            this.panelVoucherCard.Padding = new System.Windows.Forms.Padding(12);
            this.panelVoucherCard.Size = new System.Drawing.Size(310, 210);
            this.panelVoucherCard.TabIndex = 1;

            // lblVoucherTitle
            this.lblVoucherTitle.AutoSize = true;
            this.lblVoucherTitle.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.lblVoucherTitle.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.lblVoucherTitle.Location = new System.Drawing.Point(10, 10);
            this.lblVoucherTitle.Name = "lblVoucherTitle";
            this.lblVoucherTitle.Size = new System.Drawing.Size(147, 19);
            this.lblVoucherTitle.TabIndex = 0;
            this.lblVoucherTitle.Text = "ĐỔI QUÀ / VOUCHER";

            // btnRedeemVoucher
            this.btnRedeemVoucher.BackColor = System.Drawing.Color.FromArgb(41, 100, 180);
            this.btnRedeemVoucher.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRedeemVoucher.FlatAppearance.BorderSize = 0;
            this.btnRedeemVoucher.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRedeemVoucher.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.btnRedeemVoucher.ForeColor = System.Drawing.Color.White;
            this.btnRedeemVoucher.Location = new System.Drawing.Point(198, 7);
            this.btnRedeemVoucher.Name = "btnRedeemVoucher";
            this.btnRedeemVoucher.Size = new System.Drawing.Size(98, 25);
            this.btnRedeemVoucher.TabIndex = 2;
            this.btnRedeemVoucher.Text = "🎁 Đổi thưởng";
            this.btnRedeemVoucher.UseVisualStyleBackColor = false;
            this.btnRedeemVoucher.Click += new System.EventHandler(this.btnRedeemVoucher_Click);

            // lstVouchers
            this.lstVouchers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstVouchers.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lstVouchers.FormattingEnabled = true;
            this.lstVouchers.ItemHeight = 24;
            this.lstVouchers.Location = new System.Drawing.Point(12, 36);
            this.lstVouchers.Name = "lstVouchers";
            this.lstVouchers.Size = new System.Drawing.Size(284, 160);
            this.lstVouchers.TabIndex = 1;
            this.lstVouchers.DoubleClick += new System.EventHandler(this.btnRedeemVoucher_Click);

            // cmsCustomerActions
            this.cmsCustomerActions.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmsCustomerActions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.mnuEditCustomer,
                this.mnuAddPoints,
                this.mnuViewHistory,
                this.mnuSeparator,
                this.mnuDeleteCustomer
            });
            this.cmsCustomerActions.Name = "cmsCustomerActions";
            this.cmsCustomerActions.Size = new System.Drawing.Size(205, 98);

            // mnuEditCustomer
            this.mnuEditCustomer.Name = "mnuEditCustomer";
            this.mnuEditCustomer.Size = new System.Drawing.Size(204, 22);
            this.mnuEditCustomer.Text = "✎   Sửa";
            this.mnuEditCustomer.Click += new System.EventHandler(this.btnUpdate_Click);

            // mnuAddPoints
            this.mnuAddPoints.Name = "mnuAddPoints";
            this.mnuAddPoints.Size = new System.Drawing.Size(204, 22);
            this.mnuAddPoints.Text = "➕   Tích Điểm Thủ Công";
            this.mnuAddPoints.Click += new System.EventHandler(this.mnuAddPoints_Click);

            // mnuViewHistory
            this.mnuViewHistory.Name = "mnuViewHistory";
            this.mnuViewHistory.Size = new System.Drawing.Size(204, 22);
            this.mnuViewHistory.Text = "🕒   Xem Lịch Sử Giao Dịch";
            this.mnuViewHistory.Click += new System.EventHandler(this.mnuViewHistory_Click);

            // mnuSeparator
            this.mnuSeparator.Name = "mnuSeparator";
            this.mnuSeparator.Size = new System.Drawing.Size(201, 6);

            // mnuDeleteCustomer
            this.mnuDeleteCustomer.ForeColor = System.Drawing.Color.FromArgb(193, 54, 52);
            this.mnuDeleteCustomer.Name = "mnuDeleteCustomer";
            this.mnuDeleteCustomer.Size = new System.Drawing.Size(204, 22);
            this.mnuDeleteCustomer.Text = "✖   Xóa";
            this.mnuDeleteCustomer.Click += new System.EventHandler(this.btnDelete_Click);

            // FormCustomerManagement
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            this.ClientSize = new System.Drawing.Size(1050, 660);
            this.Controls.Add(this.panelMainBody);
            this.Controls.Add(this.panelActionBar);
            this.KeyPreview = true;
            this.Name = "FormCustomerManagement";
            this.Padding = new System.Windows.Forms.Padding(12, 8, 12, 12);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "QUẢN LÝ KHÁCH HÀNG & TÍCH ĐIỂM";
            this.Load += new System.EventHandler(this.FormCustomerManagement_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormCustomerManagement_KeyDown);

            this.panelActionBar.ResumeLayout(false);
            this.panelActionBar.PerformLayout();
            this.panelMainBody.ResumeLayout(false);
            this.panelLeftArea.ResumeLayout(false);
            this.panelGridCard.ResumeLayout(false);
            this.panelGridHeader.ResumeLayout(false);
            this.panelGridHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomers)).EndInit();
            this.panelKpiSection.ResumeLayout(false);
            this.panelKpiSection.PerformLayout();
            this.tlpKpiCards.ResumeLayout(false);
            this.pnlKpiTotalCustomers.ResumeLayout(false);
            this.pnlKpiTotalCustomers.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picKpi1Icon)).EndInit();
            this.pnlKpiNewMembers.ResumeLayout(false);
            this.pnlKpiNewMembers.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picKpi2Icon)).EndInit();
            this.pnlKpiTotalPoints.ResumeLayout(false);
            this.pnlKpiTotalPoints.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picKpi3Icon)).EndInit();
            this.panelRightArea.ResumeLayout(false);
            this.panelDetailCard.ResumeLayout(false);
            this.panelDetailCard.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCustomerAvatar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPointHistory)).EndInit();
            this.panelVoucherCard.ResumeLayout(false);
            this.panelVoucherCard.PerformLayout();
            this.cmsCustomerActions.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel panelActionBar;
        private System.Windows.Forms.Label lblSearchTitle;
        private System.Windows.Forms.TextBox txtKeyword;
        private System.Windows.Forms.Label lblTypeFilter;
        private System.Windows.Forms.ComboBox cboCustomerType;
        private System.Windows.Forms.Label lblStatusFilter;
        private System.Windows.Forms.ComboBox cboStatus;
        private System.Windows.Forms.Button btnImportExcel;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Panel panelMainBody;
        private System.Windows.Forms.Panel panelLeftArea;
        private System.Windows.Forms.Panel panelGridCard;
        private System.Windows.Forms.Panel panelGridHeader;
        private System.Windows.Forms.Label lblGridTitle;
        private System.Windows.Forms.Button btnQuickEdit;
        private System.Windows.Forms.Button btnQuickPoints;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.DataGridView dgvCustomers;
        private System.Windows.Forms.Panel panelKpiSection;
        private System.Windows.Forms.Label lblKpiHeader;
        private System.Windows.Forms.TableLayoutPanel tlpKpiCards;
        private System.Windows.Forms.Panel pnlKpiTotalCustomers;
        private System.Windows.Forms.Label lblKpi1Title;
        private System.Windows.Forms.Label lblKpi1Value;
        private System.Windows.Forms.Label lblKpi1Sub;
        private System.Windows.Forms.PictureBox picKpi1Icon;
        private System.Windows.Forms.Panel pnlKpiNewMembers;
        private System.Windows.Forms.Label lblKpi2Title;
        private System.Windows.Forms.Label lblKpi2Value;
        private System.Windows.Forms.Label lblKpi2Sub;
        private System.Windows.Forms.PictureBox picKpi2Icon;
        private System.Windows.Forms.Panel pnlKpiTotalPoints;
        private System.Windows.Forms.Label lblKpi3Title;
        private System.Windows.Forms.Label lblKpi3Value;
        private System.Windows.Forms.Label lblKpi3Sub;
        private System.Windows.Forms.PictureBox picKpi3Icon;
        private System.Windows.Forms.Panel panelRightArea;
        private System.Windows.Forms.Panel panelDetailCard;
        private System.Windows.Forms.Label lblDetailTitle;
        private System.Windows.Forms.PictureBox picCustomerAvatar;
        private System.Windows.Forms.Label lblDetailPhoto;
        private System.Windows.Forms.Label lblDetailId;
        private System.Windows.Forms.Label lblDetailName;
        private System.Windows.Forms.Label lblDetailLevel;
        private System.Windows.Forms.Label lblDetailSpent;
        private System.Windows.Forms.Label lblHistoryTitle;
        private System.Windows.Forms.DataGridView dgvPointHistory;
        private System.Windows.Forms.Panel panelVoucherCard;
        private System.Windows.Forms.Label lblVoucherTitle;
        private System.Windows.Forms.Button btnRedeemVoucher;
        private System.Windows.Forms.ListBox lstVouchers;
        private System.Windows.Forms.ContextMenuStrip cmsCustomerActions;
        private System.Windows.Forms.ToolStripMenuItem mnuEditCustomer;
        private System.Windows.Forms.ToolStripMenuItem mnuAddPoints;
        private System.Windows.Forms.ToolStripMenuItem mnuViewHistory;
        private System.Windows.Forms.ToolStripSeparator mnuSeparator;
        private System.Windows.Forms.ToolStripMenuItem mnuDeleteCustomer;
    }
}

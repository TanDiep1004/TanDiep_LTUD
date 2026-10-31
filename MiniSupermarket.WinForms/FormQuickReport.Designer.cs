namespace MiniSupermarket.WinForms
{
    partial class FormQuickReport
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
            this.panelTopBanner = new System.Windows.Forms.Panel();
            this.lblBannerTitle = new System.Windows.Forms.Label();
            this.btnTopPrint = new System.Windows.Forms.Button();
            this.btnTopExport = new System.Windows.Forms.Button();
            this.btnTopReset = new System.Windows.Forms.Button();

            this.panelMainBody = new System.Windows.Forms.Panel();
            this.panelLeftCol = new System.Windows.Forms.Panel();
            this.panelRightCol = new System.Windows.Forms.Panel();

            // Left Column Controls
            this.panelFilterCard = new System.Windows.Forms.Panel();
            this.lblFilterCardTitle = new System.Windows.Forms.Label();
            this.lblFrom = new System.Windows.Forms.Label();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.lblTo = new System.Windows.Forms.Label();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.lblQuickRange = new System.Windows.Forms.Label();
            this.cboQuickRange = new System.Windows.Forms.ComboBox();

            this.panelLeftSpacer1 = new System.Windows.Forms.Panel();

            this.panelHourlyChartCard = new System.Windows.Forms.Panel();
            this.lblHourlyTitle = new System.Windows.Forms.Label();
            this.picHourlyChart = new System.Windows.Forms.PictureBox();

            this.panelLeftSpacer2 = new System.Windows.Forms.Panel();

            this.tlpBottomKpis = new System.Windows.Forms.TableLayoutPanel();
            this.pnlKpiMonthlyRev = new System.Windows.Forms.Panel();
            this.lblKpi1Title = new System.Windows.Forms.Label();
            this.lblKpi1Value = new System.Windows.Forms.Label();
            this.lblKpi1Unit = new System.Windows.Forms.Label();
            this.picKpi1Icon = new System.Windows.Forms.PictureBox();

            this.pnlKpiProfit = new System.Windows.Forms.Panel();
            this.lblKpi2Title = new System.Windows.Forms.Label();
            this.lblKpi2Value = new System.Windows.Forms.Label();
            this.lblKpi2Unit = new System.Windows.Forms.Label();
            this.picKpi2Icon = new System.Windows.Forms.PictureBox();

            this.pnlKpiAvgBill = new System.Windows.Forms.Panel();
            this.lblKpi3Title = new System.Windows.Forms.Label();
            this.lblKpi3Value = new System.Windows.Forms.Label();
            this.lblKpi3Unit = new System.Windows.Forms.Label();
            this.picKpi3Icon = new System.Windows.Forms.PictureBox();

            // Right Column Controls
            this.panelCategoryDonutCard = new System.Windows.Forms.Panel();
            this.lblDonutTitle = new System.Windows.Forms.Label();
            this.picCategoryDonut = new System.Windows.Forms.PictureBox();

            this.panelRightSpacer = new System.Windows.Forms.Panel();

            this.panelTopProductsCard = new System.Windows.Forms.Panel();
            this.panelTopProductsHeader = new System.Windows.Forms.Panel();
            this.lblTopProductsTitle = new System.Windows.Forms.Label();
            this.btnGridAction1 = new System.Windows.Forms.Button();
            this.btnGridAction2 = new System.Windows.Forms.Button();
            this.btnGridAction3 = new System.Windows.Forms.Button();
            this.dgvTopProducts = new System.Windows.Forms.DataGridView();

            this.panelTopBanner.SuspendLayout();
            this.panelMainBody.SuspendLayout();
            this.panelLeftCol.SuspendLayout();
            this.panelRightCol.SuspendLayout();
            this.panelFilterCard.SuspendLayout();
            this.panelHourlyChartCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picHourlyChart)).BeginInit();
            this.tlpBottomKpis.SuspendLayout();
            this.pnlKpiMonthlyRev.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picKpi1Icon)).BeginInit();
            this.pnlKpiProfit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picKpi2Icon)).BeginInit();
            this.pnlKpiAvgBill.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picKpi3Icon)).BeginInit();
            this.panelCategoryDonutCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCategoryDonut)).BeginInit();
            this.panelTopProductsCard.SuspendLayout();
            this.panelTopProductsHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTopProducts)).BeginInit();
            this.SuspendLayout();

            // panelTopBanner
            this.panelTopBanner.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            this.panelTopBanner.Controls.Add(this.btnTopReset);
            this.panelTopBanner.Controls.Add(this.btnTopExport);
            this.panelTopBanner.Controls.Add(this.btnTopPrint);
            this.panelTopBanner.Controls.Add(this.lblBannerTitle);
            this.panelTopBanner.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTopBanner.Location = new System.Drawing.Point(12, 6);
            this.panelTopBanner.Name = "panelTopBanner";
            this.panelTopBanner.Size = new System.Drawing.Size(1026, 40);
            this.panelTopBanner.TabIndex = 0;

            // lblBannerTitle
            this.lblBannerTitle.AutoSize = true;
            this.lblBannerTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblBannerTitle.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.lblBannerTitle.Location = new System.Drawing.Point(2, 6);
            this.lblBannerTitle.Name = "lblBannerTitle";
            this.lblBannerTitle.Size = new System.Drawing.Size(345, 25);
            this.lblBannerTitle.TabIndex = 0;
            this.lblBannerTitle.Text = "BÁO CÁO & THỐNG KÊ DOANH THU";

            // btnTopPrint
            this.btnTopPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTopPrint.BackColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.btnTopPrint.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTopPrint.FlatAppearance.BorderSize = 0;
            this.btnTopPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTopPrint.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnTopPrint.ForeColor = System.Drawing.Color.White;
            this.btnTopPrint.Location = new System.Drawing.Point(912, 5);
            this.btnTopPrint.Name = "btnTopPrint";
            this.btnTopPrint.Size = new System.Drawing.Size(34, 30);
            this.btnTopPrint.TabIndex = 1;
            this.btnTopPrint.Text = "🖨";
            this.btnTopPrint.UseVisualStyleBackColor = false;
            this.btnTopPrint.Click += new System.EventHandler(this.btnExportReport_Click);

            // btnTopExport
            this.btnTopExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTopExport.BackColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.btnTopExport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTopExport.FlatAppearance.BorderSize = 0;
            this.btnTopExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTopExport.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnTopExport.ForeColor = System.Drawing.Color.White;
            this.btnTopExport.Location = new System.Drawing.Point(950, 5);
            this.btnTopExport.Name = "btnTopExport";
            this.btnTopExport.Size = new System.Drawing.Size(34, 30);
            this.btnTopExport.TabIndex = 2;
            this.btnTopExport.Text = "☰";
            this.btnTopExport.UseVisualStyleBackColor = false;
            this.btnTopExport.Click += new System.EventHandler(this.btnRefreshReport_Click);

            // btnTopReset
            this.btnTopReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTopReset.BackColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.btnTopReset.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTopReset.FlatAppearance.BorderSize = 0;
            this.btnTopReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTopReset.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnTopReset.ForeColor = System.Drawing.Color.White;
            this.btnTopReset.Location = new System.Drawing.Point(988, 5);
            this.btnTopReset.Name = "btnTopReset";
            this.btnTopReset.Size = new System.Drawing.Size(34, 30);
            this.btnTopReset.TabIndex = 3;
            this.btnTopReset.Text = "🗑";
            this.btnTopReset.UseVisualStyleBackColor = false;
            this.btnTopReset.Click += new System.EventHandler(this.btnResetFilter_Click);

            // panelMainBody
            this.panelMainBody.Controls.Add(this.panelLeftCol);
            this.panelMainBody.Controls.Add(this.panelRightCol);
            this.panelMainBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMainBody.Location = new System.Drawing.Point(12, 46);
            this.panelMainBody.Name = "panelMainBody";
            this.panelMainBody.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.panelMainBody.Size = new System.Drawing.Size(1026, 586);
            this.panelMainBody.TabIndex = 1;

            // panelLeftCol
            this.panelLeftCol.Controls.Add(this.panelHourlyChartCard);
            this.panelLeftCol.Controls.Add(this.panelLeftSpacer2);
            this.panelLeftCol.Controls.Add(this.tlpBottomKpis);
            this.panelLeftCol.Controls.Add(this.panelLeftSpacer1);
            this.panelLeftCol.Controls.Add(this.panelFilterCard);
            this.panelLeftCol.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelLeftCol.Location = new System.Drawing.Point(0, 4);
            this.panelLeftCol.Name = "panelLeftCol";
            this.panelLeftCol.Padding = new System.Windows.Forms.Padding(0, 0, 12, 0);
            this.panelLeftCol.Size = new System.Drawing.Size(606, 582);
            this.panelLeftCol.TabIndex = 0;

            // panelFilterCard
            this.panelFilterCard.BackColor = System.Drawing.Color.White;
            this.panelFilterCard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelFilterCard.Controls.Add(this.cboQuickRange);
            this.panelFilterCard.Controls.Add(this.lblQuickRange);
            this.panelFilterCard.Controls.Add(this.dtpTo);
            this.panelFilterCard.Controls.Add(this.lblTo);
            this.panelFilterCard.Controls.Add(this.dtpFrom);
            this.panelFilterCard.Controls.Add(this.lblFrom);
            this.panelFilterCard.Controls.Add(this.lblFilterCardTitle);
            this.panelFilterCard.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelFilterCard.Location = new System.Drawing.Point(0, 0);
            this.panelFilterCard.Name = "panelFilterCard";
            this.panelFilterCard.Size = new System.Drawing.Size(594, 78);
            this.panelFilterCard.TabIndex = 0;

            // lblFilterCardTitle
            this.lblFilterCardTitle.AutoSize = true;
            this.lblFilterCardTitle.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.lblFilterCardTitle.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.lblFilterCardTitle.Location = new System.Drawing.Point(12, 8);
            this.lblFilterCardTitle.Name = "lblFilterCardTitle";
            this.lblFilterCardTitle.Size = new System.Drawing.Size(112, 19);
            this.lblFilterCardTitle.TabIndex = 0;
            this.lblFilterCardTitle.Text = "Thanh thời gian";

            // lblFrom
            this.lblFrom.AutoSize = true;
            this.lblFrom.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblFrom.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
            this.lblFrom.Location = new System.Drawing.Point(12, 42);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(40, 17);
            this.lblFrom.TabIndex = 1;
            this.lblFrom.Text = "From:";

            // dtpFrom
            this.dtpFrom.CustomFormat = "dd/MM/yyyy";
            this.dtpFrom.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFrom.Location = new System.Drawing.Point(56, 38);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(122, 25);
            this.dtpFrom.TabIndex = 2;
            this.dtpFrom.ValueChanged += new System.EventHandler(this.DateFilter_ValueChanged);

            // lblTo
            this.lblTo.AutoSize = true;
            this.lblTo.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblTo.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
            this.lblTo.Location = new System.Drawing.Point(190, 42);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(25, 17);
            this.lblTo.TabIndex = 3;
            this.lblTo.Text = "To:";

            // dtpTo
            this.dtpTo.CustomFormat = "dd/MM/yyyy";
            this.dtpTo.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTo.Location = new System.Drawing.Point(218, 38);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(122, 25);
            this.dtpTo.TabIndex = 4;
            this.dtpTo.ValueChanged += new System.EventHandler(this.DateFilter_ValueChanged);

            // lblQuickRange
            this.lblQuickRange.AutoSize = true;
            this.lblQuickRange.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblQuickRange.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
            this.lblQuickRange.Location = new System.Drawing.Point(352, 42);
            this.lblQuickRange.Name = "lblQuickRange";
            this.lblQuickRange.Size = new System.Drawing.Size(35, 17);
            this.lblQuickRange.TabIndex = 5;
            this.lblQuickRange.Text = "Tạm:";

            // cboQuickRange
            this.cboQuickRange.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboQuickRange.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cboQuickRange.FormattingEnabled = true;
            this.cboQuickRange.Items.AddRange(new object[] {
                "Hôm nay",
                "Hôm qua",
                "Tuần này",
                "Tháng này"
            });
            this.cboQuickRange.Location = new System.Drawing.Point(392, 38);
            this.cboQuickRange.Name = "cboQuickRange";
            this.cboQuickRange.Size = new System.Drawing.Size(185, 25);
            this.cboQuickRange.TabIndex = 6;
            this.cboQuickRange.SelectedIndexChanged += new System.EventHandler(this.cboQuickRange_SelectedIndexChanged);

            // panelLeftSpacer1
            this.panelLeftSpacer1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLeftSpacer1.Location = new System.Drawing.Point(0, 78);
            this.panelLeftSpacer1.Name = "panelLeftSpacer1";
            this.panelLeftSpacer1.Size = new System.Drawing.Size(594, 10);
            this.panelLeftSpacer1.TabIndex = 1;

            // tlpBottomKpis
            this.tlpBottomKpis.ColumnCount = 3;
            this.tlpBottomKpis.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tlpBottomKpis.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tlpBottomKpis.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.34F));
            this.tlpBottomKpis.Controls.Add(this.pnlKpiMonthlyRev, 0, 0);
            this.tlpBottomKpis.Controls.Add(this.pnlKpiProfit, 1, 0);
            this.tlpBottomKpis.Controls.Add(this.pnlKpiAvgBill, 2, 0);
            this.tlpBottomKpis.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tlpBottomKpis.Location = new System.Drawing.Point(0, 456);
            this.tlpBottomKpis.Name = "tlpBottomKpis";
            this.tlpBottomKpis.RowCount = 1;
            this.tlpBottomKpis.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpBottomKpis.Size = new System.Drawing.Size(594, 126);
            this.tlpBottomKpis.TabIndex = 3;

            // pnlKpiMonthlyRev
            this.pnlKpiMonthlyRev.BackColor = System.Drawing.Color.White;
            this.pnlKpiMonthlyRev.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlKpiMonthlyRev.Controls.Add(this.picKpi1Icon);
            this.pnlKpiMonthlyRev.Controls.Add(this.lblKpi1Unit);
            this.pnlKpiMonthlyRev.Controls.Add(this.lblKpi1Value);
            this.pnlKpiMonthlyRev.Controls.Add(this.lblKpi1Title);
            this.pnlKpiMonthlyRev.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlKpiMonthlyRev.Location = new System.Drawing.Point(0, 0);
            this.pnlKpiMonthlyRev.Margin = new System.Windows.Forms.Padding(0, 0, 6, 0);
            this.pnlKpiMonthlyRev.Name = "pnlKpiMonthlyRev";
            this.pnlKpiMonthlyRev.Size = new System.Drawing.Size(192, 126);
            this.pnlKpiMonthlyRev.TabIndex = 0;

            // lblKpi1Title
            this.lblKpi1Title.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblKpi1Title.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.lblKpi1Title.Location = new System.Drawing.Point(10, 8);
            this.lblKpi1Title.Name = "lblKpi1Title";
            this.lblKpi1Title.Size = new System.Drawing.Size(172, 38);
            this.lblKpi1Title.TabIndex = 0;
            this.lblKpi1Title.Text = "TỔNG DOANH THU\r\nTHÁNG NÀY";

            // lblKpi1Value
            this.lblKpi1Value.AutoSize = true;
            this.lblKpi1Value.Font = new System.Drawing.Font("Segoe UI", 19F, System.Drawing.FontStyle.Bold);
            this.lblKpi1Value.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.lblKpi1Value.Location = new System.Drawing.Point(8, 48);
            this.lblKpi1Value.Name = "lblKpi1Value";
            this.lblKpi1Value.Size = new System.Drawing.Size(102, 36);
            this.lblKpi1Value.TabIndex = 1;
            this.lblKpi1Value.Text = "215.8M";

            // lblKpi1Unit
            this.lblKpi1Unit.AutoSize = true;
            this.lblKpi1Unit.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblKpi1Unit.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
            this.lblKpi1Unit.Location = new System.Drawing.Point(12, 88);
            this.lblKpi1Unit.Name = "lblKpi1Unit";
            this.lblKpi1Unit.Size = new System.Drawing.Size(37, 19);
            this.lblKpi1Unit.TabIndex = 2;
            this.lblKpi1Unit.Text = "VND";

            // picKpi1Icon
            this.picKpi1Icon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.picKpi1Icon.Location = new System.Drawing.Point(134, 52);
            this.picKpi1Icon.Name = "picKpi1Icon";
            this.picKpi1Icon.Size = new System.Drawing.Size(46, 46);
            this.picKpi1Icon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picKpi1Icon.TabIndex = 3;
            this.picKpi1Icon.TabStop = false;

            // pnlKpiProfit
            this.pnlKpiProfit.BackColor = System.Drawing.Color.White;
            this.pnlKpiProfit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlKpiProfit.Controls.Add(this.picKpi2Icon);
            this.pnlKpiProfit.Controls.Add(this.lblKpi2Unit);
            this.pnlKpiProfit.Controls.Add(this.lblKpi2Value);
            this.pnlKpiProfit.Controls.Add(this.lblKpi2Title);
            this.pnlKpiProfit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlKpiProfit.Location = new System.Drawing.Point(201, 0);
            this.pnlKpiProfit.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.pnlKpiProfit.Name = "pnlKpiProfit";
            this.pnlKpiProfit.Size = new System.Drawing.Size(192, 126);
            this.pnlKpiProfit.TabIndex = 1;

            // lblKpi2Title
            this.lblKpi2Title.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblKpi2Title.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.lblKpi2Title.Location = new System.Drawing.Point(10, 8);
            this.lblKpi2Title.Name = "lblKpi2Title";
            this.lblKpi2Title.Size = new System.Drawing.Size(172, 38);
            this.lblKpi2Title.TabIndex = 0;
            this.lblKpi2Title.Text = "TỔNG LỢI NHUẬN";

            // lblKpi2Value
            this.lblKpi2Value.AutoSize = true;
            this.lblKpi2Value.Font = new System.Drawing.Font("Segoe UI", 19F, System.Drawing.FontStyle.Bold);
            this.lblKpi2Value.ForeColor = System.Drawing.Color.FromArgb(22, 163, 74);
            this.lblKpi2Value.Location = new System.Drawing.Point(8, 48);
            this.lblKpi2Value.Name = "lblKpi2Value";
            this.lblKpi2Value.Size = new System.Drawing.Size(87, 36);
            this.lblKpi2Value.TabIndex = 1;
            this.lblKpi2Value.Text = "32.1M";

            // lblKpi2Unit
            this.lblKpi2Unit.AutoSize = true;
            this.lblKpi2Unit.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblKpi2Unit.ForeColor = System.Drawing.Color.FromArgb(22, 163, 74);
            this.lblKpi2Unit.Location = new System.Drawing.Point(12, 88);
            this.lblKpi2Unit.Name = "lblKpi2Unit";
            this.lblKpi2Unit.Size = new System.Drawing.Size(37, 19);
            this.lblKpi2Unit.TabIndex = 2;
            this.lblKpi2Unit.Text = "VND";

            // picKpi2Icon
            this.picKpi2Icon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.picKpi2Icon.Location = new System.Drawing.Point(134, 52);
            this.picKpi2Icon.Name = "picKpi2Icon";
            this.picKpi2Icon.Size = new System.Drawing.Size(46, 46);
            this.picKpi2Icon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picKpi2Icon.TabIndex = 3;
            this.picKpi2Icon.TabStop = false;

            // pnlKpiAvgBill
            this.pnlKpiAvgBill.BackColor = System.Drawing.Color.White;
            this.pnlKpiAvgBill.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlKpiAvgBill.Controls.Add(this.picKpi3Icon);
            this.pnlKpiAvgBill.Controls.Add(this.lblKpi3Unit);
            this.pnlKpiAvgBill.Controls.Add(this.lblKpi3Value);
            this.pnlKpiAvgBill.Controls.Add(this.lblKpi3Title);
            this.pnlKpiAvgBill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlKpiAvgBill.Location = new System.Drawing.Point(402, 0);
            this.pnlKpiAvgBill.Margin = new System.Windows.Forms.Padding(6, 0, 0, 0);
            this.pnlKpiAvgBill.Name = "pnlKpiAvgBill";
            this.pnlKpiAvgBill.Size = new System.Drawing.Size(192, 126);
            this.pnlKpiAvgBill.TabIndex = 2;

            // lblKpi3Title
            this.lblKpi3Title.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblKpi3Title.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.lblKpi3Title.Location = new System.Drawing.Point(10, 8);
            this.lblKpi3Title.Name = "lblKpi3Title";
            this.lblKpi3Title.Size = new System.Drawing.Size(172, 38);
            this.lblKpi3Title.TabIndex = 0;
            this.lblKpi3Title.Text = "HÓA ĐƠN\r\nTRUNG BÌNH";

            // lblKpi3Value
            this.lblKpi3Value.AutoSize = true;
            this.lblKpi3Value.Font = new System.Drawing.Font("Segoe UI", 19F, System.Drawing.FontStyle.Bold);
            this.lblKpi3Value.ForeColor = System.Drawing.Color.FromArgb(217, 119, 6);
            this.lblKpi3Value.Location = new System.Drawing.Point(8, 48);
            this.lblKpi3Value.Name = "lblKpi3Value";
            this.lblKpi3Value.Size = new System.Drawing.Size(108, 36);
            this.lblKpi3Value.TabIndex = 1;
            this.lblKpi3Value.Text = "185.000";

            // lblKpi3Unit
            this.lblKpi3Unit.AutoSize = true;
            this.lblKpi3Unit.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblKpi3Unit.ForeColor = System.Drawing.Color.FromArgb(217, 119, 6);
            this.lblKpi3Unit.Location = new System.Drawing.Point(12, 88);
            this.lblKpi3Unit.Name = "lblKpi3Unit";
            this.lblKpi3Unit.Size = new System.Drawing.Size(37, 19);
            this.lblKpi3Unit.TabIndex = 2;
            this.lblKpi3Unit.Text = "VND";

            // picKpi3Icon
            this.picKpi3Icon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.picKpi3Icon.Location = new System.Drawing.Point(138, 52);
            this.picKpi3Icon.Name = "picKpi3Icon";
            this.picKpi3Icon.Size = new System.Drawing.Size(42, 46);
            this.picKpi3Icon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picKpi3Icon.TabIndex = 3;
            this.picKpi3Icon.TabStop = false;

            // panelLeftSpacer2
            this.panelLeftSpacer2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelLeftSpacer2.Location = new System.Drawing.Point(0, 446);
            this.panelLeftSpacer2.Name = "panelLeftSpacer2";
            this.panelLeftSpacer2.Size = new System.Drawing.Size(594, 10);
            this.panelLeftSpacer2.TabIndex = 4;

            // panelHourlyChartCard
            this.panelHourlyChartCard.BackColor = System.Drawing.Color.White;
            this.panelHourlyChartCard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelHourlyChartCard.Controls.Add(this.picHourlyChart);
            this.panelHourlyChartCard.Controls.Add(this.lblHourlyTitle);
            this.panelHourlyChartCard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelHourlyChartCard.Location = new System.Drawing.Point(0, 88);
            this.panelHourlyChartCard.Name = "panelHourlyChartCard";
            this.panelHourlyChartCard.Padding = new System.Windows.Forms.Padding(10, 8, 10, 8);
            this.panelHourlyChartCard.Size = new System.Drawing.Size(594, 358);
            this.panelHourlyChartCard.TabIndex = 2;

            // lblHourlyTitle
            this.lblHourlyTitle.AutoSize = true;
            this.lblHourlyTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblHourlyTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblHourlyTitle.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.lblHourlyTitle.Location = new System.Drawing.Point(10, 8);
            this.lblHourlyTitle.Name = "lblHourlyTitle";
            this.lblHourlyTitle.Padding = new System.Windows.Forms.Padding(2, 0, 0, 4);
            this.lblHourlyTitle.Size = new System.Drawing.Size(268, 24);
            this.lblHourlyTitle.TabIndex = 0;
            this.lblHourlyTitle.Text = "DOANH THU THEO GIỜ (Hôm nay)";

            // picHourlyChart
            this.picHourlyChart.BackColor = System.Drawing.Color.White;
            this.picHourlyChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picHourlyChart.Location = new System.Drawing.Point(10, 32);
            this.picHourlyChart.Name = "picHourlyChart";
            this.picHourlyChart.Size = new System.Drawing.Size(572, 316);
            this.picHourlyChart.TabIndex = 1;
            this.picHourlyChart.TabStop = false;
            this.picHourlyChart.Paint += new System.Windows.Forms.PaintEventHandler(this.picHourlyChart_Paint);
            this.picHourlyChart.Resize += new System.EventHandler(this.picChart_Resize);

            // panelRightCol
            this.panelRightCol.Controls.Add(this.panelTopProductsCard);
            this.panelRightCol.Controls.Add(this.panelRightSpacer);
            this.panelRightCol.Controls.Add(this.panelCategoryDonutCard);
            this.panelRightCol.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelRightCol.Location = new System.Drawing.Point(606, 4);
            this.panelRightCol.Name = "panelRightCol";
            this.panelRightCol.Size = new System.Drawing.Size(420, 582);
            this.panelRightCol.TabIndex = 1;

            // panelCategoryDonutCard
            this.panelCategoryDonutCard.BackColor = System.Drawing.Color.White;
            this.panelCategoryDonutCard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelCategoryDonutCard.Controls.Add(this.picCategoryDonut);
            this.panelCategoryDonutCard.Controls.Add(this.lblDonutTitle);
            this.panelCategoryDonutCard.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelCategoryDonutCard.Location = new System.Drawing.Point(0, 0);
            this.panelCategoryDonutCard.Name = "panelCategoryDonutCard";
            this.panelCategoryDonutCard.Padding = new System.Windows.Forms.Padding(12, 10, 12, 10);
            this.panelCategoryDonutCard.Size = new System.Drawing.Size(420, 232);
            this.panelCategoryDonutCard.TabIndex = 0;

            // lblDonutTitle
            this.lblDonutTitle.AutoSize = true;
            this.lblDonutTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblDonutTitle.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.lblDonutTitle.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.lblDonutTitle.Location = new System.Drawing.Point(12, 10);
            this.lblDonutTitle.Name = "lblDonutTitle";
            this.lblDonutTitle.Size = new System.Drawing.Size(324, 19);
            this.lblDonutTitle.TabIndex = 0;
            this.lblDonutTitle.Text = "TỈ TRỌNG DOANH THU THEO NGÀNH HÀNG";

            // picCategoryDonut
            this.picCategoryDonut.BackColor = System.Drawing.Color.White;
            this.picCategoryDonut.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picCategoryDonut.Location = new System.Drawing.Point(12, 29);
            this.picCategoryDonut.Name = "picCategoryDonut";
            this.picCategoryDonut.Size = new System.Drawing.Size(394, 191);
            this.picCategoryDonut.TabIndex = 1;
            this.picCategoryDonut.TabStop = false;
            this.picCategoryDonut.Paint += new System.Windows.Forms.PaintEventHandler(this.picCategoryDonut_Paint);
            this.picCategoryDonut.Resize += new System.EventHandler(this.picChart_Resize);

            // panelRightSpacer
            this.panelRightSpacer.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelRightSpacer.Location = new System.Drawing.Point(0, 232);
            this.panelRightSpacer.Name = "panelRightSpacer";
            this.panelRightSpacer.Size = new System.Drawing.Size(420, 10);
            this.panelRightSpacer.TabIndex = 1;

            // panelTopProductsCard
            this.panelTopProductsCard.BackColor = System.Drawing.Color.White;
            this.panelTopProductsCard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelTopProductsCard.Controls.Add(this.dgvTopProducts);
            this.panelTopProductsCard.Controls.Add(this.panelTopProductsHeader);
            this.panelTopProductsCard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTopProductsCard.Location = new System.Drawing.Point(0, 242);
            this.panelTopProductsCard.Name = "panelTopProductsCard";
            this.panelTopProductsCard.Padding = new System.Windows.Forms.Padding(10, 8, 10, 10);
            this.panelTopProductsCard.Size = new System.Drawing.Size(420, 340);
            this.panelTopProductsCard.TabIndex = 2;

            // panelTopProductsHeader
            this.panelTopProductsHeader.Controls.Add(this.btnGridAction3);
            this.panelTopProductsHeader.Controls.Add(this.btnGridAction2);
            this.panelTopProductsHeader.Controls.Add(this.btnGridAction1);
            this.panelTopProductsHeader.Controls.Add(this.lblTopProductsTitle);
            this.panelTopProductsHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTopProductsHeader.Location = new System.Drawing.Point(10, 8);
            this.panelTopProductsHeader.Name = "panelTopProductsHeader";
            this.panelTopProductsHeader.Size = new System.Drawing.Size(398, 32);
            this.panelTopProductsHeader.TabIndex = 0;

            // lblTopProductsTitle
            this.lblTopProductsTitle.AutoSize = true;
            this.lblTopProductsTitle.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.lblTopProductsTitle.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.lblTopProductsTitle.Location = new System.Drawing.Point(0, 4);
            this.lblTopProductsTitle.Name = "lblTopProductsTitle";
            this.lblTopProductsTitle.Size = new System.Drawing.Size(235, 19);
            this.lblTopProductsTitle.TabIndex = 0;
            this.lblTopProductsTitle.Text = "TOP SẢN PHẨM BÁN CHẠY NHẤT";

            // btnGridAction1
            this.btnGridAction1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGridAction1.BackColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.btnGridAction1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGridAction1.FlatAppearance.BorderSize = 0;
            this.btnGridAction1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGridAction1.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.btnGridAction1.ForeColor = System.Drawing.Color.White;
            this.btnGridAction1.Location = new System.Drawing.Point(306, 2);
            this.btnGridAction1.Name = "btnGridAction1";
            this.btnGridAction1.Size = new System.Drawing.Size(28, 25);
            this.btnGridAction1.TabIndex = 1;
            this.btnGridAction1.Text = "🖨";
            this.btnGridAction1.UseVisualStyleBackColor = false;
            this.btnGridAction1.Click += new System.EventHandler(this.btnExportReport_Click);

            // btnGridAction2
            this.btnGridAction2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGridAction2.BackColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.btnGridAction2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGridAction2.FlatAppearance.BorderSize = 0;
            this.btnGridAction2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGridAction2.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.btnGridAction2.ForeColor = System.Drawing.Color.White;
            this.btnGridAction2.Location = new System.Drawing.Point(338, 2);
            this.btnGridAction2.Name = "btnGridAction2";
            this.btnGridAction2.Size = new System.Drawing.Size(28, 25);
            this.btnGridAction2.TabIndex = 2;
            this.btnGridAction2.Text = "☰";
            this.btnGridAction2.UseVisualStyleBackColor = false;
            this.btnGridAction2.Click += new System.EventHandler(this.btnRefreshReport_Click);

            // btnGridAction3
            this.btnGridAction3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGridAction3.BackColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.btnGridAction3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGridAction3.FlatAppearance.BorderSize = 0;
            this.btnGridAction3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGridAction3.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.btnGridAction3.ForeColor = System.Drawing.Color.White;
            this.btnGridAction3.Location = new System.Drawing.Point(370, 2);
            this.btnGridAction3.Name = "btnGridAction3";
            this.btnGridAction3.Size = new System.Drawing.Size(28, 25);
            this.btnGridAction3.TabIndex = 3;
            this.btnGridAction3.Text = "🗑";
            this.btnGridAction3.UseVisualStyleBackColor = false;
            this.btnGridAction3.Click += new System.EventHandler(this.btnResetFilter_Click);

            // dgvTopProducts
            this.dgvTopProducts.AllowUserToAddRows = false;
            this.dgvTopProducts.AllowUserToDeleteRows = false;
            this.dgvTopProducts.AllowUserToResizeRows = false;
            this.dgvTopProducts.BackgroundColor = System.Drawing.Color.White;
            this.dgvTopProducts.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dgvTopProducts.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvTopProducts.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvTopProducts.ColumnHeadersHeight = 30;
            this.dgvTopProducts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTopProducts.EnableHeadersVisualStyles = false;
            this.dgvTopProducts.GridColor = System.Drawing.Color.FromArgb(226, 232, 240);
            this.dgvTopProducts.Location = new System.Drawing.Point(10, 40);
            this.dgvTopProducts.MultiSelect = false;
            this.dgvTopProducts.Name = "dgvTopProducts";
            this.dgvTopProducts.ReadOnly = true;
            this.dgvTopProducts.RowHeadersVisible = false;
            this.dgvTopProducts.RowTemplate.Height = 26;
            this.dgvTopProducts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTopProducts.Size = new System.Drawing.Size(398, 288);
            this.dgvTopProducts.TabIndex = 1;

            // FormQuickReport
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            this.ClientSize = new System.Drawing.Size(1050, 640);
            this.Controls.Add(this.panelMainBody);
            this.Controls.Add(this.panelTopBanner);
            this.Name = "FormQuickReport";
            this.Padding = new System.Windows.Forms.Padding(12, 6, 12, 8);
            this.Text = "BÁO CÁO & THỐNG KÊ DOANH THU";
            this.Load += new System.EventHandler(this.FormQuickReport_Load);

            this.panelTopBanner.ResumeLayout(false);
            this.panelTopBanner.PerformLayout();
            this.panelMainBody.ResumeLayout(false);
            this.panelLeftCol.ResumeLayout(false);
            this.panelRightCol.ResumeLayout(false);
            this.panelFilterCard.ResumeLayout(false);
            this.panelFilterCard.PerformLayout();
            this.panelHourlyChartCard.ResumeLayout(false);
            this.panelHourlyChartCard.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picHourlyChart)).EndInit();
            this.tlpBottomKpis.ResumeLayout(false);
            this.pnlKpiMonthlyRev.ResumeLayout(false);
            this.pnlKpiMonthlyRev.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picKpi1Icon)).EndInit();
            this.pnlKpiProfit.ResumeLayout(false);
            this.pnlKpiProfit.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picKpi2Icon)).EndInit();
            this.pnlKpiAvgBill.ResumeLayout(false);
            this.pnlKpiAvgBill.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picKpi3Icon)).EndInit();
            this.panelCategoryDonutCard.ResumeLayout(false);
            this.panelCategoryDonutCard.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCategoryDonut)).EndInit();
            this.panelTopProductsCard.ResumeLayout(false);
            this.panelTopProductsHeader.ResumeLayout(false);
            this.panelTopProductsHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTopProducts)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel panelTopBanner;
        private System.Windows.Forms.Label lblBannerTitle;
        private System.Windows.Forms.Button btnTopPrint;
        private System.Windows.Forms.Button btnTopExport;
        private System.Windows.Forms.Button btnTopReset;
        private System.Windows.Forms.Panel panelMainBody;
        private System.Windows.Forms.Panel panelLeftCol;
        private System.Windows.Forms.Panel panelRightCol;
        private System.Windows.Forms.Panel panelFilterCard;
        private System.Windows.Forms.Label lblFilterCardTitle;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.Label lblQuickRange;
        private System.Windows.Forms.ComboBox cboQuickRange;
        private System.Windows.Forms.Panel panelLeftSpacer1;
        private System.Windows.Forms.Panel panelHourlyChartCard;
        private System.Windows.Forms.Label lblHourlyTitle;
        private System.Windows.Forms.PictureBox picHourlyChart;
        private System.Windows.Forms.Panel panelLeftSpacer2;
        private System.Windows.Forms.TableLayoutPanel tlpBottomKpis;
        private System.Windows.Forms.Panel pnlKpiMonthlyRev;
        private System.Windows.Forms.Label lblKpi1Title;
        private System.Windows.Forms.Label lblKpi1Value;
        private System.Windows.Forms.Label lblKpi1Unit;
        private System.Windows.Forms.PictureBox picKpi1Icon;
        private System.Windows.Forms.Panel pnlKpiProfit;
        private System.Windows.Forms.Label lblKpi2Title;
        private System.Windows.Forms.Label lblKpi2Value;
        private System.Windows.Forms.Label lblKpi2Unit;
        private System.Windows.Forms.PictureBox picKpi2Icon;
        private System.Windows.Forms.Panel pnlKpiAvgBill;
        private System.Windows.Forms.Label lblKpi3Title;
        private System.Windows.Forms.Label lblKpi3Value;
        private System.Windows.Forms.Label lblKpi3Unit;
        private System.Windows.Forms.PictureBox picKpi3Icon;
        private System.Windows.Forms.Panel panelCategoryDonutCard;
        private System.Windows.Forms.Label lblDonutTitle;
        private System.Windows.Forms.PictureBox picCategoryDonut;
        private System.Windows.Forms.Panel panelRightSpacer;
        private System.Windows.Forms.Panel panelTopProductsCard;
        private System.Windows.Forms.Panel panelTopProductsHeader;
        private System.Windows.Forms.Label lblTopProductsTitle;
        private System.Windows.Forms.Button btnGridAction1;
        private System.Windows.Forms.Button btnGridAction2;
        private System.Windows.Forms.Button btnGridAction3;
        private System.Windows.Forms.DataGridView dgvTopProducts;
    }
}

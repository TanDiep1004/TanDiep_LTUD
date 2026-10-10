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
            this.panelFilter = new System.Windows.Forms.Panel();
            this.lblDate = new System.Windows.Forms.Label();
            this.dtpReportDate = new System.Windows.Forms.DateTimePicker();
            this.btnRunReport = new System.Windows.Forms.Button();
            this.panelCards = new System.Windows.Forms.TableLayoutPanel();
            this.pnlCardOrders = new System.Windows.Forms.Panel();
            this.lblCardOrdersTitle = new System.Windows.Forms.Label();
            this.lblTotalOrders = new System.Windows.Forms.Label();
            this.pnlCardRevenue = new System.Windows.Forms.Panel();
            this.lblCardRevenueTitle = new System.Windows.Forms.Label();
            this.lblTotalRevenue = new System.Windows.Forms.Label();
            this.pnlCardBestSeller = new System.Windows.Forms.Panel();
            this.lblCardBestSellerTitle = new System.Windows.Forms.Label();
            this.lblBestSeller = new System.Windows.Forms.Label();
            this.grpDetail = new System.Windows.Forms.GroupBox();
            this.dgvReportDetail = new System.Windows.Forms.DataGridView();
            this.panelFilter.SuspendLayout();
            this.panelCards.SuspendLayout();
            this.pnlCardOrders.SuspendLayout();
            this.pnlCardRevenue.SuspendLayout();
            this.pnlCardBestSeller.SuspendLayout();
            this.grpDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReportDetail)).BeginInit();
            this.SuspendLayout();

            // panelFilter
            this.panelFilter.BackColor = System.Drawing.Color.White;
            this.panelFilter.Controls.Add(this.btnRunReport);
            this.panelFilter.Controls.Add(this.dtpReportDate);
            this.panelFilter.Controls.Add(this.lblDate);
            this.panelFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelFilter.Location = new System.Drawing.Point(12, 12);
            this.panelFilter.Name = "panelFilter";
            this.panelFilter.Padding = new System.Windows.Forms.Padding(10);
            this.panelFilter.Size = new System.Drawing.Size(1016, 60);
            this.panelFilter.TabIndex = 0;

            // lblDate
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblDate.Location = new System.Drawing.Point(15, 19);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(126, 19);
            this.lblDate.TabIndex = 0;
            this.lblDate.Text = "Chọn ngày ca bán:";

            // dtpReportDate
            this.dtpReportDate.CustomFormat = "dd/MM/yyyy";
            this.dtpReportDate.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpReportDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpReportDate.Location = new System.Drawing.Point(150, 16);
            this.dtpReportDate.Name = "dtpReportDate";
            this.dtpReportDate.Size = new System.Drawing.Size(160, 25);
            this.dtpReportDate.TabIndex = 1;

            // btnRunReport
            this.btnRunReport.BackColor = System.Drawing.Color.FromArgb(41, 100, 180);
            this.btnRunReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRunReport.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnRunReport.ForeColor = System.Drawing.Color.White;
            this.btnRunReport.Location = new System.Drawing.Point(330, 12);
            this.btnRunReport.Name = "btnRunReport";
            this.btnRunReport.Size = new System.Drawing.Size(180, 34);
            this.btnRunReport.TabIndex = 2;
            this.btnRunReport.Text = "📊 Xem Báo Cáo Ca";
            this.btnRunReport.UseVisualStyleBackColor = false;
            this.btnRunReport.Click += new System.EventHandler(this.btnRunReport_Click);

            // panelCards
            this.panelCards.ColumnCount = 3;
            this.panelCards.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.panelCards.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.panelCards.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.34F));
            this.panelCards.Controls.Add(this.pnlCardOrders, 0, 0);
            this.panelCards.Controls.Add(this.pnlCardRevenue, 1, 0);
            this.panelCards.Controls.Add(this.pnlCardBestSeller, 2, 0);
            this.panelCards.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelCards.Location = new System.Drawing.Point(12, 72);
            this.panelCards.Name = "panelCards";
            this.panelCards.RowCount = 1;
            this.panelCards.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelCards.Size = new System.Drawing.Size(1016, 130);
            this.panelCards.TabIndex = 1;

            // pnlCardOrders
            this.pnlCardOrders.BackColor = System.Drawing.Color.FromArgb(23, 162, 184);
            this.pnlCardOrders.Controls.Add(this.lblTotalOrders);
            this.pnlCardOrders.Controls.Add(this.lblCardOrdersTitle);
            this.pnlCardOrders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCardOrders.Location = new System.Drawing.Point(3, 10);
            this.pnlCardOrders.Margin = new System.Windows.Forms.Padding(3, 10, 8, 10);
            this.pnlCardOrders.Name = "pnlCardOrders";
            this.pnlCardOrders.Padding = new System.Windows.Forms.Padding(10);
            this.pnlCardOrders.Size = new System.Drawing.Size(327, 110);
            this.pnlCardOrders.TabIndex = 0;

            // lblCardOrdersTitle
            this.lblCardOrdersTitle.AutoSize = true;
            this.lblCardOrdersTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblCardOrdersTitle.ForeColor = System.Drawing.Color.White;
            this.lblCardOrdersTitle.Location = new System.Drawing.Point(10, 10);
            this.lblCardOrdersTitle.Name = "lblCardOrdersTitle";
            this.lblCardOrdersTitle.Size = new System.Drawing.Size(161, 20);
            this.lblCardOrdersTitle.TabIndex = 0;
            this.lblCardOrdersTitle.Text = "🧾 TỔNG SỐ HÓA ĐƠN";

            // lblTotalOrders
            this.lblTotalOrders.Font = new System.Drawing.Font("Segoe UI", 26F, System.Drawing.FontStyle.Bold);
            this.lblTotalOrders.ForeColor = System.Drawing.Color.White;
            this.lblTotalOrders.Location = new System.Drawing.Point(10, 40);
            this.lblTotalOrders.Name = "lblTotalOrders";
            this.lblTotalOrders.Size = new System.Drawing.Size(307, 55);
            this.lblTotalOrders.TabIndex = 1;
            this.lblTotalOrders.Text = "0";
            this.lblTotalOrders.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            // pnlCardRevenue
            this.pnlCardRevenue.BackColor = System.Drawing.Color.FromArgb(40, 167, 69);
            this.pnlCardRevenue.Controls.Add(this.lblTotalRevenue);
            this.pnlCardRevenue.Controls.Add(this.lblCardRevenueTitle);
            this.pnlCardRevenue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCardRevenue.Location = new System.Drawing.Point(342, 10);
            this.pnlCardRevenue.Margin = new System.Windows.Forms.Padding(4, 10, 4, 10);
            this.pnlCardRevenue.Name = "pnlCardRevenue";
            this.pnlCardRevenue.Padding = new System.Windows.Forms.Padding(10);
            this.pnlCardRevenue.Size = new System.Drawing.Size(330, 110);
            this.pnlCardRevenue.TabIndex = 1;

            // lblCardRevenueTitle
            this.lblCardRevenueTitle.AutoSize = true;
            this.lblCardRevenueTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblCardRevenueTitle.ForeColor = System.Drawing.Color.White;
            this.lblCardRevenueTitle.Location = new System.Drawing.Point(10, 10);
            this.lblCardRevenueTitle.Name = "lblCardRevenueTitle";
            this.lblCardRevenueTitle.Size = new System.Drawing.Size(183, 20);
            this.lblCardRevenueTitle.TabIndex = 0;
            this.lblCardRevenueTitle.Text = "💰 TỔNG DOANH THU CA";

            // lblTotalRevenue
            this.lblTotalRevenue.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblTotalRevenue.ForeColor = System.Drawing.Color.White;
            this.lblTotalRevenue.Location = new System.Drawing.Point(10, 40);
            this.lblTotalRevenue.Name = "lblTotalRevenue";
            this.lblTotalRevenue.Size = new System.Drawing.Size(310, 55);
            this.lblTotalRevenue.TabIndex = 1;
            this.lblTotalRevenue.Text = "0 đ";
            this.lblTotalRevenue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            // pnlCardBestSeller
            this.pnlCardBestSeller.BackColor = System.Drawing.Color.FromArgb(255, 133, 27);
            this.pnlCardBestSeller.Controls.Add(this.lblBestSeller);
            this.pnlCardBestSeller.Controls.Add(this.lblCardBestSellerTitle);
            this.pnlCardBestSeller.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCardBestSeller.Location = new System.Drawing.Point(684, 10);
            this.pnlCardBestSeller.Margin = new System.Windows.Forms.Padding(8, 10, 3, 10);
            this.pnlCardBestSeller.Name = "pnlCardBestSeller";
            this.pnlCardBestSeller.Padding = new System.Windows.Forms.Padding(10);
            this.pnlCardBestSeller.Size = new System.Drawing.Size(329, 110);
            this.pnlCardBestSeller.TabIndex = 2;

            // lblCardBestSellerTitle
            this.lblCardBestSellerTitle.AutoSize = true;
            this.lblCardBestSellerTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblCardBestSellerTitle.ForeColor = System.Drawing.Color.White;
            this.lblCardBestSellerTitle.Location = new System.Drawing.Point(10, 10);
            this.lblCardBestSellerTitle.Name = "lblCardBestSellerTitle";
            this.lblCardBestSellerTitle.Size = new System.Drawing.Size(199, 20);
            this.lblCardBestSellerTitle.TabIndex = 0;
            this.lblCardBestSellerTitle.Text = "🔥 MẶT HÀNG BÁN CHẠY";

            // lblBestSeller
            this.lblBestSeller.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblBestSeller.ForeColor = System.Drawing.Color.White;
            this.lblBestSeller.Location = new System.Drawing.Point(10, 40);
            this.lblBestSeller.Name = "lblBestSeller";
            this.lblBestSeller.Size = new System.Drawing.Size(309, 55);
            this.lblBestSeller.TabIndex = 1;
            this.lblBestSeller.Text = "Chưa có giao dịch";
            this.lblBestSeller.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            // grpDetail
            this.grpDetail.BackColor = System.Drawing.Color.White;
            this.grpDetail.Controls.Add(this.dgvReportDetail);
            this.grpDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpDetail.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.grpDetail.Location = new System.Drawing.Point(12, 202);
            this.grpDetail.Name = "grpDetail";
            this.grpDetail.Padding = new System.Windows.Forms.Padding(10);
            this.grpDetail.Size = new System.Drawing.Size(1016, 426);
            this.grpDetail.TabIndex = 2;
            this.grpDetail.TabStop = false;
            this.grpDetail.Text = "Chi Tiết Giao Dịch Bán Lẻ Trong Ngày";

            // dgvReportDetail
            this.dgvReportDetail.AllowUserToAddRows = false;
            this.dgvReportDetail.AllowUserToDeleteRows = false;
            this.dgvReportDetail.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvReportDetail.BackgroundColor = System.Drawing.Color.White;
            this.dgvReportDetail.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvReportDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReportDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvReportDetail.Location = new System.Drawing.Point(10, 28);
            this.dgvReportDetail.Name = "dgvReportDetail";
            this.dgvReportDetail.ReadOnly = true;
            this.dgvReportDetail.RowHeadersVisible = false;
            this.dgvReportDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvReportDetail.Size = new System.Drawing.Size(996, 388);
            this.dgvReportDetail.TabIndex = 0;

            // FormQuickReport
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(244, 245, 247);
            this.ClientSize = new System.Drawing.Size(1040, 640);
            this.Controls.Add(this.grpDetail);
            this.Controls.Add(this.panelCards);
            this.Controls.Add(this.panelFilter);
            this.Name = "FormQuickReport";
            this.Padding = new System.Windows.Forms.Padding(12);
            this.Text = "Báo Cáo Doanh Thu Nhanh";
            this.Load += new System.EventHandler(this.FormQuickReport_Load);
            this.panelFilter.ResumeLayout(false);
            this.panelFilter.PerformLayout();
            this.panelCards.ResumeLayout(false);
            this.pnlCardOrders.ResumeLayout(false);
            this.pnlCardOrders.PerformLayout();
            this.pnlCardRevenue.ResumeLayout(false);
            this.pnlCardRevenue.PerformLayout();
            this.pnlCardBestSeller.ResumeLayout(false);
            this.pnlCardBestSeller.PerformLayout();
            this.grpDetail.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReportDetail)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel panelFilter;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.DateTimePicker dtpReportDate;
        private System.Windows.Forms.Button btnRunReport;
        private System.Windows.Forms.TableLayoutPanel panelCards;
        private System.Windows.Forms.Panel pnlCardOrders;
        private System.Windows.Forms.Label lblCardOrdersTitle;
        private System.Windows.Forms.Label lblTotalOrders;
        private System.Windows.Forms.Panel pnlCardRevenue;
        private System.Windows.Forms.Label lblCardRevenueTitle;
        private System.Windows.Forms.Label lblTotalRevenue;
        private System.Windows.Forms.Panel pnlCardBestSeller;
        private System.Windows.Forms.Label lblCardBestSellerTitle;
        private System.Windows.Forms.Label lblBestSeller;
        private System.Windows.Forms.GroupBox grpDetail;
        private System.Windows.Forms.DataGridView dgvReportDetail;
    }
}

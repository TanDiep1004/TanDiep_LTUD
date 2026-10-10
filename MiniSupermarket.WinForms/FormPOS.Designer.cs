namespace MiniSupermarket.WinForms
{
    partial class FormPOS
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
            this.panelLeft = new System.Windows.Forms.Panel();
            this.dgvCart = new System.Windows.Forms.DataGridView();
            this.panelBarcode = new System.Windows.Forms.Panel();
            this.lblBarcodeTitle = new System.Windows.Forms.Label();
            this.txtBarcode = new System.Windows.Forms.TextBox();
            this.btnClearCart = new System.Windows.Forms.Button();
            this.panelRight = new System.Windows.Forms.Panel();
            this.grpPayment = new System.Windows.Forms.GroupBox();
            this.btnCheckout = new System.Windows.Forms.Button();
            this.lblChange = new System.Windows.Forms.Label();
            this.lblChangeTitle = new System.Windows.Forms.Label();
            this.txtCashReceived = new System.Windows.Forms.TextBox();
            this.lblCashTitle = new System.Windows.Forms.Label();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.lblTotalTitle = new System.Windows.Forms.Label();
            this.grpCustomer = new System.Windows.Forms.GroupBox();
            this.lblCustomerName = new System.Windows.Forms.Label();
            this.btnFindCustomer = new System.Windows.Forms.Button();
            this.txtCustomerPhone = new System.Windows.Forms.TextBox();
            this.lblPhoneTitle = new System.Windows.Forms.Label();
            this.panelLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCart)).BeginInit();
            this.panelBarcode.SuspendLayout();
            this.panelRight.SuspendLayout();
            this.grpPayment.SuspendLayout();
            this.grpCustomer.SuspendLayout();
            this.SuspendLayout();

            // panelLeft
            this.panelLeft.Controls.Add(this.dgvCart);
            this.panelLeft.Controls.Add(this.panelBarcode);
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelLeft.Location = new System.Drawing.Point(0, 0);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Padding = new System.Windows.Forms.Padding(12);
            this.panelLeft.Size = new System.Drawing.Size(660, 640);
            this.panelLeft.TabIndex = 0;

            // panelBarcode
            this.panelBarcode.Controls.Add(this.btnClearCart);
            this.panelBarcode.Controls.Add(this.txtBarcode);
            this.panelBarcode.Controls.Add(this.lblBarcodeTitle);
            this.panelBarcode.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelBarcode.Location = new System.Drawing.Point(12, 12);
            this.panelBarcode.Name = "panelBarcode";
            this.panelBarcode.Size = new System.Drawing.Size(636, 60);
            this.panelBarcode.TabIndex = 0;

            // lblBarcodeTitle
            this.lblBarcodeTitle.AutoSize = true;
            this.lblBarcodeTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblBarcodeTitle.Location = new System.Drawing.Point(4, 6);
            this.lblBarcodeTitle.Name = "lblBarcodeTitle";
            this.lblBarcodeTitle.Size = new System.Drawing.Size(250, 19);
            this.lblBarcodeTitle.TabIndex = 0;
            this.lblBarcodeTitle.Text = "Quét mã vạch (Barcode) / Nhấn Enter:";

            // txtBarcode
            this.txtBarcode.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtBarcode.Location = new System.Drawing.Point(8, 26);
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.PlaceholderText = "Quét hoặc nhập mã vạch rồi nhấn Enter...";
            this.txtBarcode.Size = new System.Drawing.Size(460, 29);
            this.txtBarcode.TabIndex = 1;
            this.txtBarcode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBarcode_KeyDown);

            // btnClearCart
            this.btnClearCart.BackColor = System.Drawing.Color.FromArgb(220, 53, 69);
            this.btnClearCart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearCart.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnClearCart.ForeColor = System.Drawing.Color.White;
            this.btnClearCart.Location = new System.Drawing.Point(480, 24);
            this.btnClearCart.Name = "btnClearCart";
            this.btnClearCart.Size = new System.Drawing.Size(140, 32);
            this.btnClearCart.TabIndex = 2;
            this.btnClearCart.Text = "🗑 Hủy giỏ hàng";
            this.btnClearCart.UseVisualStyleBackColor = false;
            this.btnClearCart.Click += new System.EventHandler(this.btnClearCart_Click);

            // dgvCart
            this.dgvCart.AllowUserToAddRows = false;
            this.dgvCart.AllowUserToDeleteRows = false;
            this.dgvCart.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCart.BackgroundColor = System.Drawing.Color.White;
            this.dgvCart.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvCart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCart.Location = new System.Drawing.Point(12, 72);
            this.dgvCart.Name = "dgvCart";
            this.dgvCart.ReadOnly = true;
            this.dgvCart.RowHeadersVisible = false;
            this.dgvCart.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCart.Size = new System.Drawing.Size(636, 556);
            this.dgvCart.TabIndex = 1;

            // panelRight
            this.panelRight.BackColor = System.Drawing.Color.White;
            this.panelRight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelRight.Controls.Add(this.grpPayment);
            this.panelRight.Controls.Add(this.grpCustomer);
            this.panelRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelRight.Location = new System.Drawing.Point(660, 0);
            this.panelRight.Name = "panelRight";
            this.panelRight.Padding = new System.Windows.Forms.Padding(12);
            this.panelRight.Size = new System.Drawing.Size(380, 640);
            this.panelRight.TabIndex = 1;

            // grpCustomer
            this.grpCustomer.Controls.Add(this.lblCustomerName);
            this.grpCustomer.Controls.Add(this.btnFindCustomer);
            this.grpCustomer.Controls.Add(this.txtCustomerPhone);
            this.grpCustomer.Controls.Add(this.lblPhoneTitle);
            this.grpCustomer.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.grpCustomer.Location = new System.Drawing.Point(12, 12);
            this.grpCustomer.Name = "grpCustomer";
            this.grpCustomer.Size = new System.Drawing.Size(354, 130);
            this.grpCustomer.TabIndex = 0;
            this.grpCustomer.TabStop = false;
            this.grpCustomer.Text = "Khách Hàng Thành Viên";

            // lblPhoneTitle
            this.lblPhoneTitle.AutoSize = true;
            this.lblPhoneTitle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPhoneTitle.Location = new System.Drawing.Point(12, 28);
            this.lblPhoneTitle.Name = "lblPhoneTitle";
            this.lblPhoneTitle.Size = new System.Drawing.Size(79, 15);
            this.lblPhoneTitle.TabIndex = 0;
            this.lblPhoneTitle.Text = "Số điện thoại:";

            // txtCustomerPhone
            this.txtCustomerPhone.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtCustomerPhone.Location = new System.Drawing.Point(14, 48);
            this.txtCustomerPhone.Name = "txtCustomerPhone";
            this.txtCustomerPhone.PlaceholderText = "Nhập SĐT khách hàng...";
            this.txtCustomerPhone.Size = new System.Drawing.Size(220, 25);
            this.txtCustomerPhone.TabIndex = 1;

            // btnFindCustomer
            this.btnFindCustomer.BackColor = System.Drawing.Color.FromArgb(41, 100, 180);
            this.btnFindCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFindCustomer.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnFindCustomer.ForeColor = System.Drawing.Color.White;
            this.btnFindCustomer.Location = new System.Drawing.Point(242, 47);
            this.btnFindCustomer.Name = "btnFindCustomer";
            this.btnFindCustomer.Size = new System.Drawing.Size(98, 28);
            this.btnFindCustomer.TabIndex = 2;
            this.btnFindCustomer.Text = "🔍 Tra cứu";
            this.btnFindCustomer.UseVisualStyleBackColor = false;
            this.btnFindCustomer.Click += new System.EventHandler(this.btnFindCustomer_Click);

            // lblCustomerName
            this.lblCustomerName.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Italic);
            this.lblCustomerName.ForeColor = System.Drawing.Color.FromArgb(40, 167, 69);
            this.lblCustomerName.Location = new System.Drawing.Point(14, 85);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.Size = new System.Drawing.Size(326, 36);
            this.lblCustomerName.TabIndex = 3;
            this.lblCustomerName.Text = "Khách hàng: Khách vãng lai";

            // grpPayment
            this.grpPayment.Controls.Add(this.btnCheckout);
            this.grpPayment.Controls.Add(this.lblChange);
            this.grpPayment.Controls.Add(this.lblChangeTitle);
            this.grpPayment.Controls.Add(this.txtCashReceived);
            this.grpPayment.Controls.Add(this.lblCashTitle);
            this.grpPayment.Controls.Add(this.lblTotalAmount);
            this.grpPayment.Controls.Add(this.lblTotalTitle);
            this.grpPayment.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.grpPayment.Location = new System.Drawing.Point(12, 150);
            this.grpPayment.Name = "grpPayment";
            this.grpPayment.Size = new System.Drawing.Size(354, 460);
            this.grpPayment.TabIndex = 1;
            this.grpPayment.TabStop = false;
            this.grpPayment.Text = "Thanh Toán Đơn Hàng";

            // lblTotalTitle
            this.lblTotalTitle.AutoSize = true;
            this.lblTotalTitle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblTotalTitle.Location = new System.Drawing.Point(12, 35);
            this.lblTotalTitle.Name = "lblTotalTitle";
            this.lblTotalTitle.Size = new System.Drawing.Size(123, 19);
            this.lblTotalTitle.TabIndex = 0;
            this.lblTotalTitle.Text = "Tổng tiền cần trả:";

            // lblTotalAmount
            this.lblTotalAmount.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblTotalAmount.ForeColor = System.Drawing.Color.FromArgb(220, 53, 69);
            this.lblTotalAmount.Location = new System.Drawing.Point(12, 60);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(330, 48);
            this.lblTotalAmount.TabIndex = 1;
            this.lblTotalAmount.Text = "0 đ";
            this.lblTotalAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            // lblCashTitle
            this.lblCashTitle.AutoSize = true;
            this.lblCashTitle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblCashTitle.Location = new System.Drawing.Point(12, 125);
            this.lblCashTitle.Name = "lblCashTitle";
            this.lblCashTitle.Size = new System.Drawing.Size(107, 19);
            this.lblCashTitle.TabIndex = 2;
            this.lblCashTitle.Text = "Tiền khách đưa:";

            // txtCashReceived
            this.txtCashReceived.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.txtCashReceived.Location = new System.Drawing.Point(14, 150);
            this.txtCashReceived.Name = "txtCashReceived";
            this.txtCashReceived.Size = new System.Drawing.Size(326, 32);
            this.txtCashReceived.TabIndex = 3;
            this.txtCashReceived.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCashReceived.TextChanged += new System.EventHandler(this.txtCashReceived_TextChanged);

            // lblChangeTitle
            this.lblChangeTitle.AutoSize = true;
            this.lblChangeTitle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblChangeTitle.Location = new System.Drawing.Point(12, 205);
            this.lblChangeTitle.Name = "lblChangeTitle";
            this.lblChangeTitle.Size = new System.Drawing.Size(117, 19);
            this.lblChangeTitle.TabIndex = 4;
            this.lblChangeTitle.Text = "Tiền thừa trả khách:";

            // lblChange
            this.lblChange.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblChange.ForeColor = System.Drawing.Color.FromArgb(40, 167, 69);
            this.lblChange.Location = new System.Drawing.Point(12, 230);
            this.lblChange.Name = "lblChange";
            this.lblChange.Size = new System.Drawing.Size(330, 40);
            this.lblChange.TabIndex = 5;
            this.lblChange.Text = "0 đ";
            this.lblChange.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            // btnCheckout
            this.btnCheckout.BackColor = System.Drawing.Color.FromArgb(40, 167, 69);
            this.btnCheckout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCheckout.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.btnCheckout.ForeColor = System.Drawing.Color.White;
            this.btnCheckout.Location = new System.Drawing.Point(14, 330);
            this.btnCheckout.Name = "btnCheckout";
            this.btnCheckout.Size = new System.Drawing.Size(326, 65);
            this.btnCheckout.TabIndex = 6;
            this.btnCheckout.Text = "💳 THANH TOÁN (F9)";
            this.btnCheckout.UseVisualStyleBackColor = false;
            this.btnCheckout.Click += new System.EventHandler(this.btnCheckout_Click);

            // FormPOS
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1040, 640);
            this.Controls.Add(this.panelLeft);
            this.Controls.Add(this.panelRight);
            this.KeyPreview = true;
            this.Name = "FormPOS";
            this.Text = "Quầy Thu Ngân Bán Hàng (POS) — Cửa hàng Cô Ba Sài Gòn";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormPOS_KeyDown);
            this.panelLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCart)).EndInit();
            this.panelBarcode.ResumeLayout(false);
            this.panelBarcode.PerformLayout();
            this.panelRight.ResumeLayout(false);
            this.grpPayment.ResumeLayout(false);
            this.grpPayment.PerformLayout();
            this.grpCustomer.ResumeLayout(false);
            this.grpCustomer.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Panel panelBarcode;
        private System.Windows.Forms.Label lblBarcodeTitle;
        private System.Windows.Forms.TextBox txtBarcode;
        private System.Windows.Forms.Button btnClearCart;
        private System.Windows.Forms.DataGridView dgvCart;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.GroupBox grpCustomer;
        private System.Windows.Forms.Label lblPhoneTitle;
        private System.Windows.Forms.TextBox txtCustomerPhone;
        private System.Windows.Forms.Button btnFindCustomer;
        private System.Windows.Forms.Label lblCustomerName;
        private System.Windows.Forms.GroupBox grpPayment;
        private System.Windows.Forms.Label lblTotalTitle;
        private System.Windows.Forms.Label lblTotalAmount;
        private System.Windows.Forms.Label lblCashTitle;
        private System.Windows.Forms.TextBox txtCashReceived;
        private System.Windows.Forms.Label lblChangeTitle;
        private System.Windows.Forms.Label lblChange;
        private System.Windows.Forms.Button btnCheckout;
    }
}

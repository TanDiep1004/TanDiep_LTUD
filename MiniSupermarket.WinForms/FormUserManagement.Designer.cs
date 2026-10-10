namespace MiniSupermarket.WinForms
{
    partial class FormUserManagement
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
            this.panelLeft = new System.Windows.Forms.Panel();
            this.dgvUsers = new System.Windows.Forms.DataGridView();
            this.panelRight = new System.Windows.Forms.Panel();
            this.grpUserDetail = new System.Windows.Forms.GroupBox();
            this.btnToggleLock = new System.Windows.Forms.Button();
            this.btnResetPassword = new System.Windows.Forms.Button();
            this.btnAddUser = new System.Windows.Forms.Button();
            this.cboRole = new System.Windows.Forms.ComboBox();
            this.lblRole = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.lblFullName = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.lblUsername = new System.Windows.Forms.Label();
            this.panelLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).BeginInit();
            this.panelRight.SuspendLayout();
            this.grpUserDetail.SuspendLayout();
            this.SuspendLayout();

            // panelLeft
            this.panelLeft.Controls.Add(this.dgvUsers);
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelLeft.Location = new System.Drawing.Point(0, 0);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Padding = new System.Windows.Forms.Padding(12);
            this.panelLeft.Size = new System.Drawing.Size(680, 640);
            this.panelLeft.TabIndex = 0;

            // dgvUsers
            this.dgvUsers.AllowUserToAddRows = false;
            this.dgvUsers.AllowUserToDeleteRows = false;
            this.dgvUsers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvUsers.BackgroundColor = System.Drawing.Color.White;
            this.dgvUsers.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvUsers.Location = new System.Drawing.Point(12, 12);
            this.dgvUsers.Name = "dgvUsers";
            this.dgvUsers.ReadOnly = true;
            this.dgvUsers.RowHeadersVisible = false;
            this.dgvUsers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUsers.Size = new System.Drawing.Size(656, 616);
            this.dgvUsers.TabIndex = 0;
            this.dgvUsers.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUsers_CellClick);

            // panelRight
            this.panelRight.BackColor = System.Drawing.Color.White;
            this.panelRight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelRight.Controls.Add(this.grpUserDetail);
            this.panelRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelRight.Location = new System.Drawing.Point(680, 0);
            this.panelRight.Name = "panelRight";
            this.panelRight.Padding = new System.Windows.Forms.Padding(12);
            this.panelRight.Size = new System.Drawing.Size(360, 640);
            this.panelRight.TabIndex = 1;

            // grpUserDetail
            this.grpUserDetail.Controls.Add(this.btnToggleLock);
            this.grpUserDetail.Controls.Add(this.btnResetPassword);
            this.grpUserDetail.Controls.Add(this.btnAddUser);
            this.grpUserDetail.Controls.Add(this.cboRole);
            this.grpUserDetail.Controls.Add(this.lblRole);
            this.grpUserDetail.Controls.Add(this.txtPassword);
            this.grpUserDetail.Controls.Add(this.lblPassword);
            this.grpUserDetail.Controls.Add(this.txtFullName);
            this.grpUserDetail.Controls.Add(this.lblFullName);
            this.grpUserDetail.Controls.Add(this.txtUsername);
            this.grpUserDetail.Controls.Add(this.lblUsername);
            this.grpUserDetail.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.grpUserDetail.Location = new System.Drawing.Point(12, 12);
            this.grpUserDetail.Name = "grpUserDetail";
            this.grpUserDetail.Padding = new System.Windows.Forms.Padding(12);
            this.grpUserDetail.Size = new System.Drawing.Size(334, 500);
            this.grpUserDetail.TabIndex = 0;
            this.grpUserDetail.TabStop = false;
            this.grpUserDetail.Text = "Thông Tin Tài Khoản";

            // lblUsername
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblUsername.Location = new System.Drawing.Point(12, 35);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(98, 17);
            this.lblUsername.TabIndex = 0;
            this.lblUsername.Text = "Tên đăng nhập:";

            // txtUsername
            this.txtUsername.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtUsername.Location = new System.Drawing.Point(15, 58);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(304, 25);
            this.txtUsername.TabIndex = 1;

            // lblFullName
            this.lblFullName.AutoSize = true;
            this.lblFullName.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblFullName.Location = new System.Drawing.Point(12, 95);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new System.Drawing.Size(117, 17);
            this.lblFullName.TabIndex = 2;
            this.lblFullName.Text = "Họ và tên nhân sự:";

            // txtFullName
            this.txtFullName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtFullName.Location = new System.Drawing.Point(15, 118);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Size = new System.Drawing.Size(304, 25);
            this.txtFullName.TabIndex = 3;

            // lblPassword
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblPassword.Location = new System.Drawing.Point(12, 155);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(65, 17);
            this.lblPassword.TabIndex = 4;
            this.lblPassword.Text = "Mật khẩu:";

            // txtPassword
            this.txtPassword.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtPassword.Location = new System.Drawing.Point(15, 178);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '●';
            this.txtPassword.Size = new System.Drawing.Size(304, 25);
            this.txtPassword.TabIndex = 5;

            // lblRole
            this.lblRole.AutoSize = true;
            this.lblRole.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblRole.Location = new System.Drawing.Point(12, 215);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(107, 17);
            this.lblRole.TabIndex = 6;
            this.lblRole.Text = "Vai trò phụ trách:";

            // cboRole
            this.cboRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRole.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboRole.FormattingEnabled = true;
            this.cboRole.Location = new System.Drawing.Point(15, 238);
            this.cboRole.Name = "cboRole";
            this.cboRole.Size = new System.Drawing.Size(304, 25);
            this.cboRole.TabIndex = 7;

            // btnAddUser
            this.btnAddUser.BackColor = System.Drawing.Color.FromArgb(40, 167, 69);
            this.btnAddUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddUser.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnAddUser.ForeColor = System.Drawing.Color.White;
            this.btnAddUser.Location = new System.Drawing.Point(15, 290);
            this.btnAddUser.Name = "btnAddUser";
            this.btnAddUser.Size = new System.Drawing.Size(304, 40);
            this.btnAddUser.TabIndex = 8;
            this.btnAddUser.Text = "➕ Thêm Mới Tài Khoản";
            this.btnAddUser.UseVisualStyleBackColor = false;
            this.btnAddUser.Click += new System.EventHandler(this.btnAddUser_Click);

            // btnResetPassword
            this.btnResetPassword.BackColor = System.Drawing.Color.FromArgb(23, 162, 184);
            this.btnResetPassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResetPassword.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnResetPassword.ForeColor = System.Drawing.Color.White;
            this.btnResetPassword.Location = new System.Drawing.Point(15, 340);
            this.btnResetPassword.Name = "btnResetPassword";
            this.btnResetPassword.Size = new System.Drawing.Size(304, 40);
            this.btnResetPassword.TabIndex = 9;
            this.btnResetPassword.Text = "🔑 Đặt Lại Mật Khẩu (123456)";
            this.btnResetPassword.UseVisualStyleBackColor = false;
            this.btnResetPassword.Click += new System.EventHandler(this.btnResetPassword_Click);

            // btnToggleLock
            this.btnToggleLock.BackColor = System.Drawing.Color.FromArgb(255, 193, 7);
            this.btnToggleLock.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnToggleLock.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnToggleLock.ForeColor = System.Drawing.Color.Black;
            this.btnToggleLock.Location = new System.Drawing.Point(15, 390);
            this.btnToggleLock.Name = "btnToggleLock";
            this.btnToggleLock.Size = new System.Drawing.Size(304, 40);
            this.btnToggleLock.TabIndex = 10;
            this.btnToggleLock.Text = "🔒 Khóa / Mở Khóa Tài Khoản";
            this.btnToggleLock.UseVisualStyleBackColor = false;
            this.btnToggleLock.Click += new System.EventHandler(this.btnToggleLock_Click);

            // FormUserManagement
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1040, 640);
            this.Controls.Add(this.panelLeft);
            this.Controls.Add(this.panelRight);
            this.Name = "FormUserManagement";
            this.Text = "Quản Trị Tài Khoản & Phân Quyền";
            this.Load += new System.EventHandler(this.FormUserManagement_Load);
            this.panelLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).EndInit();
            this.panelRight.ResumeLayout(false);
            this.grpUserDetail.ResumeLayout(false);
            this.grpUserDetail.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.DataGridView dgvUsers;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.GroupBox grpUserDetail;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.ComboBox cboRole;
        private System.Windows.Forms.Button btnAddUser;
        private System.Windows.Forms.Button btnResetPassword;
        private System.Windows.Forms.Button btnToggleLock;
    }
}

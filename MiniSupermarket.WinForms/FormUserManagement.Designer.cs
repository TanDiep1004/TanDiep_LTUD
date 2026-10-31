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
            this.components = new System.ComponentModel.Container();
            this.panelTopBanner = new System.Windows.Forms.Panel();
            this.lblPageTitle = new System.Windows.Forms.Label();

            this.panelUsersCard = new System.Windows.Forms.Panel();
            this.panelUsersCardHeader = new System.Windows.Forms.Panel();
            this.lblUsersCardTitle = new System.Windows.Forms.Label();
            this.btnAddUser = new System.Windows.Forms.Button();
            this.grpPanel = new System.Windows.Forms.GroupBox();
            this.dgvUsers = new System.Windows.Forms.DataGridView();

            this.panelSpacer1 = new System.Windows.Forms.Panel();

            this.panelSelectedInfoCard = new System.Windows.Forms.Panel();
            this.lblSelectedHeader = new System.Windows.Forms.Label();
            this.lblSelectedUserDetails = new System.Windows.Forms.Label();

            this.panelSpacer2 = new System.Windows.Forms.Panel();

            this.panelOtherSettingsCard = new System.Windows.Forms.Panel();
            this.lblOtherSettingsTitle = new System.Windows.Forms.Label();
            this.btnStoreProfile = new System.Windows.Forms.Button();
            this.btnPosConfig = new System.Windows.Forms.Button();
            this.btnHistoryLog = new System.Windows.Forms.Button();
            this.btnSaveChanges = new System.Windows.Forms.Button();

            this.cmsUserActions = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuViewDetail = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEditUser = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuResetPassword = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDisableUser = new System.Windows.Forms.ToolStripMenuItem();

            this.panelTopBanner.SuspendLayout();
            this.panelUsersCard.SuspendLayout();
            this.panelUsersCardHeader.SuspendLayout();
            this.grpPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).BeginInit();
            this.panelSelectedInfoCard.SuspendLayout();
            this.panelOtherSettingsCard.SuspendLayout();
            this.cmsUserActions.SuspendLayout();
            this.SuspendLayout();

            // panelTopBanner
            this.panelTopBanner.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            this.panelTopBanner.Controls.Add(this.lblPageTitle);
            this.panelTopBanner.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTopBanner.Location = new System.Drawing.Point(16, 8);
            this.panelTopBanner.Name = "panelTopBanner";
            this.panelTopBanner.Size = new System.Drawing.Size(1018, 40);
            this.panelTopBanner.TabIndex = 0;

            // lblPageTitle
            this.lblPageTitle.AutoSize = true;
            this.lblPageTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblPageTitle.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.lblPageTitle.Location = new System.Drawing.Point(0, 6);
            this.lblPageTitle.Name = "lblPageTitle";
            this.lblPageTitle.Size = new System.Drawing.Size(365, 25);
            this.lblPageTitle.TabIndex = 0;
            this.lblPageTitle.Text = "PHÂN QUYỀN VÀ CÀI ĐẶT ĐƠN GIẢN";

            // panelUsersCard
            this.panelUsersCard.BackColor = System.Drawing.Color.White;
            this.panelUsersCard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelUsersCard.Controls.Add(this.grpPanel);
            this.panelUsersCard.Controls.Add(this.panelUsersCardHeader);
            this.panelUsersCard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelUsersCard.Location = new System.Drawing.Point(16, 48);
            this.panelUsersCard.Name = "panelUsersCard";
            this.panelUsersCard.Padding = new System.Windows.Forms.Padding(16, 10, 16, 14);
            this.panelUsersCard.Size = new System.Drawing.Size(1018, 312);
            this.panelUsersCard.TabIndex = 1;

            // panelUsersCardHeader
            this.panelUsersCardHeader.Controls.Add(this.btnAddUser);
            this.panelUsersCardHeader.Controls.Add(this.lblUsersCardTitle);
            this.panelUsersCardHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelUsersCardHeader.Location = new System.Drawing.Point(16, 10);
            this.panelUsersCardHeader.Name = "panelUsersCardHeader";
            this.panelUsersCardHeader.Size = new System.Drawing.Size(984, 44);
            this.panelUsersCardHeader.TabIndex = 0;

            // lblUsersCardTitle
            this.lblUsersCardTitle.AutoSize = true;
            this.lblUsersCardTitle.Font = new System.Drawing.Font("Segoe UI", 11.5F, System.Drawing.FontStyle.Bold);
            this.lblUsersCardTitle.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.lblUsersCardTitle.Location = new System.Drawing.Point(0, 10);
            this.lblUsersCardTitle.Name = "lblUsersCardTitle";
            this.lblUsersCardTitle.Size = new System.Drawing.Size(262, 21);
            this.lblUsersCardTitle.TabIndex = 0;
            this.lblUsersCardTitle.Text = "QUẢN LÝ TÀI KHOẢN NGƯỜI DÙNG";

            // btnAddUser
            this.btnAddUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddUser.BackColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.btnAddUser.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddUser.FlatAppearance.BorderSize = 0;
            this.btnAddUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddUser.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnAddUser.ForeColor = System.Drawing.Color.White;
            this.btnAddUser.Location = new System.Drawing.Point(794, 2);
            this.btnAddUser.Name = "btnAddUser";
            this.btnAddUser.Size = new System.Drawing.Size(190, 38);
            this.btnAddUser.TabIndex = 1;
            this.btnAddUser.Text = "THÊM TÀI KHOẢN (F2)  👤+";
            this.btnAddUser.UseVisualStyleBackColor = false;
            this.btnAddUser.Click += new System.EventHandler(this.btnAddUser_Click);

            // grpPanel
            this.grpPanel.Controls.Add(this.dgvUsers);
            this.grpPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpPanel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.grpPanel.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.grpPanel.Location = new System.Drawing.Point(16, 54);
            this.grpPanel.Name = "grpPanel";
            this.grpPanel.Padding = new System.Windows.Forms.Padding(8, 6, 8, 8);
            this.grpPanel.Size = new System.Drawing.Size(984, 242);
            this.grpPanel.TabIndex = 1;
            this.grpPanel.TabStop = false;
            this.grpPanel.Text = "Panel";

            // dgvUsers
            this.dgvUsers.AllowUserToAddRows = false;
            this.dgvUsers.AllowUserToDeleteRows = false;
            this.dgvUsers.AllowUserToResizeRows = false;
            this.dgvUsers.BackgroundColor = System.Drawing.Color.White;
            this.dgvUsers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dgvUsers.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Single;
            this.dgvUsers.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvUsers.ColumnHeadersHeight = 32;
            this.dgvUsers.ContextMenuStrip = this.cmsUserActions;
            this.dgvUsers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvUsers.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvUsers.EnableHeadersVisualStyles = false;
            this.dgvUsers.GridColor = System.Drawing.Color.FromArgb(226, 232, 240);
            this.dgvUsers.Location = new System.Drawing.Point(8, 22);
            this.dgvUsers.MultiSelect = false;
            this.dgvUsers.Name = "dgvUsers";
            this.dgvUsers.RowHeadersWidth = 34;
            this.dgvUsers.RowTemplate.Height = 30;
            this.dgvUsers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUsers.Size = new System.Drawing.Size(968, 212);
            this.dgvUsers.TabIndex = 0;
            this.dgvUsers.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUsers_CellClick);
            this.dgvUsers.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvUsers_CellMouseDown);
            this.dgvUsers.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvUsers_CurrentCellDirtyStateChanged);
            this.dgvUsers.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUsers_CellValueChanged);
            this.dgvUsers.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvUsers_DataError);

            // panelSpacer1
            this.panelSpacer1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelSpacer1.Location = new System.Drawing.Point(16, 360);
            this.panelSpacer1.Name = "panelSpacer1";
            this.panelSpacer1.Size = new System.Drawing.Size(1018, 12);
            this.panelSpacer1.TabIndex = 2;

            // panelSelectedInfoCard
            this.panelSelectedInfoCard.BackColor = System.Drawing.Color.White;
            this.panelSelectedInfoCard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelSelectedInfoCard.Controls.Add(this.lblSelectedUserDetails);
            this.panelSelectedInfoCard.Controls.Add(this.lblSelectedHeader);
            this.panelSelectedInfoCard.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelSelectedInfoCard.Location = new System.Drawing.Point(16, 372);
            this.panelSelectedInfoCard.Name = "panelSelectedInfoCard";
            this.panelSelectedInfoCard.Padding = new System.Windows.Forms.Padding(16, 10, 16, 10);
            this.panelSelectedInfoCard.Size = new System.Drawing.Size(1018, 86);
            this.panelSelectedInfoCard.TabIndex = 3;

            // lblSelectedHeader
            this.lblSelectedHeader.AutoSize = true;
            this.lblSelectedHeader.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.lblSelectedHeader.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.lblSelectedHeader.Location = new System.Drawing.Point(14, 10);
            this.lblSelectedHeader.Name = "lblSelectedHeader";
            this.lblSelectedHeader.Size = new System.Drawing.Size(275, 19);
            this.lblSelectedHeader.TabIndex = 0;
            this.lblSelectedHeader.Text = "THÔNG TIN TÀI KHOẢN ĐANG CHỌN (1)";

            // lblSelectedUserDetails
            this.lblSelectedUserDetails.AutoSize = true;
            this.lblSelectedUserDetails.Font = new System.Drawing.Font("Segoe UI", 15.5F, System.Drawing.FontStyle.Bold);
            this.lblSelectedUserDetails.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.lblSelectedUserDetails.Location = new System.Drawing.Point(12, 36);
            this.lblSelectedUserDetails.Name = "lblSelectedUserDetails";
            this.lblSelectedUserDetails.Size = new System.Drawing.Size(348, 30);
            this.lblSelectedUserDetails.TabIndex = 1;
            this.lblSelectedUserDetails.Text = "User details: nguyenana | Admin";

            // panelSpacer2
            this.panelSpacer2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelSpacer2.Location = new System.Drawing.Point(16, 458);
            this.panelSpacer2.Name = "panelSpacer2";
            this.panelSpacer2.Size = new System.Drawing.Size(1018, 12);
            this.panelSpacer2.TabIndex = 4;

            // panelOtherSettingsCard
            this.panelOtherSettingsCard.BackColor = System.Drawing.Color.White;
            this.panelOtherSettingsCard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelOtherSettingsCard.Controls.Add(this.btnSaveChanges);
            this.panelOtherSettingsCard.Controls.Add(this.btnHistoryLog);
            this.panelOtherSettingsCard.Controls.Add(this.btnPosConfig);
            this.panelOtherSettingsCard.Controls.Add(this.btnStoreProfile);
            this.panelOtherSettingsCard.Controls.Add(this.lblOtherSettingsTitle);
            this.panelOtherSettingsCard.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelOtherSettingsCard.Location = new System.Drawing.Point(16, 470);
            this.panelOtherSettingsCard.Name = "panelOtherSettingsCard";
            this.panelOtherSettingsCard.Padding = new System.Windows.Forms.Padding(16, 10, 16, 12);
            this.panelOtherSettingsCard.Size = new System.Drawing.Size(1018, 156);
            this.panelOtherSettingsCard.TabIndex = 5;

            // lblOtherSettingsTitle
            this.lblOtherSettingsTitle.AutoSize = true;
            this.lblOtherSettingsTitle.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.lblOtherSettingsTitle.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.lblOtherSettingsTitle.Location = new System.Drawing.Point(14, 12);
            this.lblOtherSettingsTitle.Name = "lblOtherSettingsTitle";
            this.lblOtherSettingsTitle.Size = new System.Drawing.Size(162, 19);
            this.lblOtherSettingsTitle.TabIndex = 0;
            this.lblOtherSettingsTitle.Text = "CÁC CÀI ĐẶT KHÁCH";

            // btnStoreProfile
            this.btnStoreProfile.BackColor = System.Drawing.Color.FromArgb(229, 231, 235);
            this.btnStoreProfile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStoreProfile.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(209, 213, 219);
            this.btnStoreProfile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStoreProfile.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnStoreProfile.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.btnStoreProfile.Location = new System.Drawing.Point(16, 42);
            this.btnStoreProfile.Name = "btnStoreProfile";
            this.btnStoreProfile.Padding = new System.Windows.Forms.Padding(0, 8, 0, 6);
            this.btnStoreProfile.Size = new System.Drawing.Size(128, 96);
            this.btnStoreProfile.TabIndex = 1;
            this.btnStoreProfile.Text = "Hồ sơ cửa hàng";
            this.btnStoreProfile.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnStoreProfile.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnStoreProfile.UseVisualStyleBackColor = false;
            this.btnStoreProfile.Click += new System.EventHandler(this.btnStoreProfile_Click);

            // btnPosConfig
            this.btnPosConfig.BackColor = System.Drawing.Color.FromArgb(229, 231, 235);
            this.btnPosConfig.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPosConfig.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(209, 213, 219);
            this.btnPosConfig.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPosConfig.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnPosConfig.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.btnPosConfig.Location = new System.Drawing.Point(156, 42);
            this.btnPosConfig.Name = "btnPosConfig";
            this.btnPosConfig.Padding = new System.Windows.Forms.Padding(0, 8, 0, 6);
            this.btnPosConfig.Size = new System.Drawing.Size(128, 96);
            this.btnPosConfig.TabIndex = 2;
            this.btnPosConfig.Text = "Cấu hình POS";
            this.btnPosConfig.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnPosConfig.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnPosConfig.UseVisualStyleBackColor = false;
            this.btnPosConfig.Click += new System.EventHandler(this.btnPosConfig_Click);

            // btnHistoryLog
            this.btnHistoryLog.BackColor = System.Drawing.Color.FromArgb(229, 231, 235);
            this.btnHistoryLog.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHistoryLog.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(209, 213, 219);
            this.btnHistoryLog.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHistoryLog.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnHistoryLog.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.btnHistoryLog.Location = new System.Drawing.Point(296, 42);
            this.btnHistoryLog.Name = "btnHistoryLog";
            this.btnHistoryLog.Padding = new System.Windows.Forms.Padding(0, 8, 0, 6);
            this.btnHistoryLog.Size = new System.Drawing.Size(128, 96);
            this.btnHistoryLog.TabIndex = 3;
            this.btnHistoryLog.Text = "Lịch sử";
            this.btnHistoryLog.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnHistoryLog.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnHistoryLog.UseVisualStyleBackColor = false;
            this.btnHistoryLog.Click += new System.EventHandler(this.btnHistoryLog_Click);

            // btnSaveChanges
            this.btnSaveChanges.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveChanges.BackColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.btnSaveChanges.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSaveChanges.FlatAppearance.BorderSize = 0;
            this.btnSaveChanges.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveChanges.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.btnSaveChanges.ForeColor = System.Drawing.Color.White;
            this.btnSaveChanges.Location = new System.Drawing.Point(804, 88);
            this.btnSaveChanges.Name = "btnSaveChanges";
            this.btnSaveChanges.Size = new System.Drawing.Size(196, 48);
            this.btnSaveChanges.TabIndex = 4;
            this.btnSaveChanges.Text = "LƯU THAY ĐỔI";
            this.btnSaveChanges.UseVisualStyleBackColor = false;
            this.btnSaveChanges.Click += new System.EventHandler(this.btnSaveChanges_Click);

            // cmsUserActions
            this.cmsUserActions.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmsUserActions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.mnuViewDetail,
                this.mnuEditUser,
                this.mnuResetPassword,
                this.mnuDisableUser
            });
            this.cmsUserActions.Name = "cmsUserActions";
            this.cmsUserActions.Size = new System.Drawing.Size(175, 92);

            // mnuViewDetail
            this.mnuViewDetail.Name = "mnuViewDetail";
            this.mnuViewDetail.Size = new System.Drawing.Size(174, 22);
            this.mnuViewDetail.Text = "Xem chi tiết";
            this.mnuViewDetail.Click += new System.EventHandler(this.mnuViewDetail_Click);

            // mnuEditUser
            this.mnuEditUser.Name = "mnuEditUser";
            this.mnuEditUser.Size = new System.Drawing.Size(174, 22);
            this.mnuEditUser.Text = "Sửa người dùng";
            this.mnuEditUser.Click += new System.EventHandler(this.mnuEditUser_Click);

            // mnuResetPassword
            this.mnuResetPassword.Name = "mnuResetPassword";
            this.mnuResetPassword.Size = new System.Drawing.Size(174, 22);
            this.mnuResetPassword.Text = "Reset mật khẩu";
            this.mnuResetPassword.Click += new System.EventHandler(this.mnuResetPassword_Click);

            // mnuDisableUser
            this.mnuDisableUser.Name = "mnuDisableUser";
            this.mnuDisableUser.Size = new System.Drawing.Size(174, 22);
            this.mnuDisableUser.Text = "Vô hiệu hóa";
            this.mnuDisableUser.Click += new System.EventHandler(this.mnuDisableUser_Click);

            // FormUserManagement
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            this.ClientSize = new System.Drawing.Size(1050, 640);
            this.Controls.Add(this.panelUsersCard);
            this.Controls.Add(this.panelSpacer1);
            this.Controls.Add(this.panelSelectedInfoCard);
            this.Controls.Add(this.panelSpacer2);
            this.Controls.Add(this.panelOtherSettingsCard);
            this.Controls.Add(this.panelTopBanner);
            this.KeyPreview = true;
            this.Name = "FormUserManagement";
            this.Padding = new System.Windows.Forms.Padding(16, 8, 16, 14);
            this.Text = "PHÂN QUYỀN VÀ CÀI ĐẶT ĐƠN GIẢN";
            this.Load += new System.EventHandler(this.FormUserManagement_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormUserManagement_KeyDown);

            this.panelTopBanner.ResumeLayout(false);
            this.panelTopBanner.PerformLayout();
            this.panelUsersCard.ResumeLayout(false);
            this.panelUsersCardHeader.ResumeLayout(false);
            this.panelUsersCardHeader.PerformLayout();
            this.grpPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).EndInit();
            this.panelSelectedInfoCard.ResumeLayout(false);
            this.panelSelectedInfoCard.PerformLayout();
            this.panelOtherSettingsCard.ResumeLayout(false);
            this.panelOtherSettingsCard.PerformLayout();
            this.cmsUserActions.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel panelTopBanner;
        private System.Windows.Forms.Label lblPageTitle;
        private System.Windows.Forms.Panel panelUsersCard;
        private System.Windows.Forms.Panel panelUsersCardHeader;
        private System.Windows.Forms.Label lblUsersCardTitle;
        private System.Windows.Forms.Button btnAddUser;
        private System.Windows.Forms.GroupBox grpPanel;
        private System.Windows.Forms.DataGridView dgvUsers;
        private System.Windows.Forms.Panel panelSpacer1;
        private System.Windows.Forms.Panel panelSelectedInfoCard;
        private System.Windows.Forms.Label lblSelectedHeader;
        private System.Windows.Forms.Label lblSelectedUserDetails;
        private System.Windows.Forms.Panel panelSpacer2;
        private System.Windows.Forms.Panel panelOtherSettingsCard;
        private System.Windows.Forms.Label lblOtherSettingsTitle;
        private System.Windows.Forms.Button btnStoreProfile;
        private System.Windows.Forms.Button btnPosConfig;
        private System.Windows.Forms.Button btnHistoryLog;
        private System.Windows.Forms.Button btnSaveChanges;
        private System.Windows.Forms.ContextMenuStrip cmsUserActions;
        private System.Windows.Forms.ToolStripMenuItem mnuViewDetail;
        private System.Windows.Forms.ToolStripMenuItem mnuEditUser;
        private System.Windows.Forms.ToolStripMenuItem mnuResetPassword;
        private System.Windows.Forms.ToolStripMenuItem mnuDisableUser;
    }
}

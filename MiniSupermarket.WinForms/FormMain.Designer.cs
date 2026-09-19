namespace MiniSupermarket.WinForms
{
    partial class FormMain
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
            this.btnManageCategories = new System.Windows.Forms.Button();
            this.btnManageRoles = new System.Windows.Forms.Button();
            this.SuspendLayout();
            
            // btnManageCategories
            this.btnManageCategories.Location = new System.Drawing.Point(50, 50);
            this.btnManageCategories.Name = "btnManageCategories";
            this.btnManageCategories.Size = new System.Drawing.Size(200, 50);
            this.btnManageCategories.TabIndex = 0;
            this.btnManageCategories.Text = "Quản lý Nhóm hàng";
            this.btnManageCategories.UseVisualStyleBackColor = true;
            this.btnManageCategories.Click += new System.EventHandler(this.btnManageCategories_Click);
            
            // btnManageRoles
            this.btnManageRoles.Location = new System.Drawing.Point(50, 120);
            this.btnManageRoles.Name = "btnManageRoles";
            this.btnManageRoles.Size = new System.Drawing.Size(200, 50);
            this.btnManageRoles.TabIndex = 1;
            this.btnManageRoles.Text = "Quản lý Chức vụ";
            this.btnManageRoles.UseVisualStyleBackColor = true;
            this.btnManageRoles.Click += new System.EventHandler(this.btnManageRoles_Click);
            
            // FormMain
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 220);
            this.Controls.Add(this.btnManageRoles);
            this.Controls.Add(this.btnManageCategories);
            this.Name = "FormMain";
            this.Text = "Menu Chính";
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Button btnManageCategories;
        private System.Windows.Forms.Button btnManageRoles;
    }
}

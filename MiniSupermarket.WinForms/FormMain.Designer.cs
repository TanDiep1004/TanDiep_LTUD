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
            this.btnManageCustomers = new System.Windows.Forms.Button();
            this.btnManageProducts = new System.Windows.Forms.Button();
            this.SuspendLayout();
            
            // btnManageCategories
            this.btnManageCategories.Location = new System.Drawing.Point(50, 25);
            this.btnManageCategories.Name = "btnManageCategories";
            this.btnManageCategories.Size = new System.Drawing.Size(220, 48);
            this.btnManageCategories.TabIndex = 0;
            this.btnManageCategories.Text = "Quản lý Nhóm hàng";
            this.btnManageCategories.UseVisualStyleBackColor = true;
            this.btnManageCategories.Click += new System.EventHandler(this.btnManageCategories_Click);
            
            // btnManageRoles
            this.btnManageRoles.Location = new System.Drawing.Point(50, 85);
            this.btnManageRoles.Name = "btnManageRoles";
            this.btnManageRoles.Size = new System.Drawing.Size(220, 48);
            this.btnManageRoles.TabIndex = 1;
            this.btnManageRoles.Text = "Quản lý Chức vụ";
            this.btnManageRoles.UseVisualStyleBackColor = true;
            this.btnManageRoles.Click += new System.EventHandler(this.btnManageRoles_Click);

            // btnManageCustomers
            this.btnManageCustomers.Location = new System.Drawing.Point(50, 145);
            this.btnManageCustomers.Name = "btnManageCustomers";
            this.btnManageCustomers.Size = new System.Drawing.Size(220, 48);
            this.btnManageCustomers.TabIndex = 2;
            this.btnManageCustomers.Text = "Quản lý Khách hàng";
            this.btnManageCustomers.UseVisualStyleBackColor = true;
            this.btnManageCustomers.Click += new System.EventHandler(this.btnManageCustomers_Click);

            // btnManageProducts
            this.btnManageProducts.Location = new System.Drawing.Point(50, 205);
            this.btnManageProducts.Name = "btnManageProducts";
            this.btnManageProducts.Size = new System.Drawing.Size(220, 48);
            this.btnManageProducts.TabIndex = 3;
            this.btnManageProducts.Text = "Quản lý Sản phẩm";
            this.btnManageProducts.UseVisualStyleBackColor = true;
            this.btnManageProducts.Click += new System.EventHandler(this.btnManageProducts_Click);
            
            // FormMain
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(320, 280);
            this.Controls.Add(this.btnManageProducts);
            this.Controls.Add(this.btnManageCustomers);
            this.Controls.Add(this.btnManageRoles);
            this.Controls.Add(this.btnManageCategories);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu Chính";
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Button btnManageCategories;
        private System.Windows.Forms.Button btnManageRoles;
        private System.Windows.Forms.Button btnManageCustomers;
        private System.Windows.Forms.Button btnManageProducts;
    }
}

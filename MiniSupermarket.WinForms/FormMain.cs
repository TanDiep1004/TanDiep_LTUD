using System;
using System.Windows.Forms;

namespace MiniSupermarket.WinForms
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void btnManageCategories_Click(object sender, EventArgs e)
        {
            var form = new FormCategoryManagement();
            form.Show();
        }

        private void btnManageRoles_Click(object sender, EventArgs e)
        {
            var form = new FormRoleManagement();
            form.Show();
        }
    }
}

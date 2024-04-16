using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TailorManagement1
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }        

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void billToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BillForm bill = Application.OpenForms.OfType<BillForm>().FirstOrDefault();
            if(bill == null)
            {
                bill = new BillForm();
                bill.MdiParent = this;
            }
            if (!bill.Visible)
            {
                bill.Show();
            }
            else
            {
                bill.BringToFront(); // Bring the form to the front if it's already visible
            }
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            CommonUtilities.ExitApplication();
        }

        private void shirtConfigurationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShirtConfigurationForm shirtConfigurationForm = Application.OpenForms.OfType<ShirtConfigurationForm>().FirstOrDefault();
            if (shirtConfigurationForm == null)
            {
                shirtConfigurationForm = new ShirtConfigurationForm();
                shirtConfigurationForm.MdiParent = this;
            }
            if (!shirtConfigurationForm.Visible)
            {
                shirtConfigurationForm.Show();
            }
            else
            {
                shirtConfigurationForm.BringToFront(); // Bring the form to the front if it's already visible
            }

        }

        private void pantConfigurationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PantConfigurationForm pantConfigurationForm = Application.OpenForms.OfType<PantConfigurationForm>().FirstOrDefault();
            if (pantConfigurationForm == null)
            {
                pantConfigurationForm = new PantConfigurationForm();
                pantConfigurationForm.MdiParent = this;
            }
            if (!pantConfigurationForm.Visible)
            {
                pantConfigurationForm.Show();
            }
            else
            {
                pantConfigurationForm.BringToFront(); // Bring the form to the front if it's already visible
            }

        }

        private void dashboardToolStripMenuItem_Click(object sender, EventArgs e)
        {

            DashboardForm dashboardForm = Application.OpenForms.OfType<DashboardForm>().FirstOrDefault();
            if (dashboardForm == null)
            {
                dashboardForm = new DashboardForm();
                dashboardForm.MdiParent = this;
            }
            if (!dashboardForm.Visible)
            {
                dashboardForm.Show();
            }
            else
            {
                dashboardForm.BringToFront(); // Bring the form to the front if it's already visible
            }
        }
    }
}

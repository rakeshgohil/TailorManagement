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
        private int childFormNumber = 0;

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
    }
}

using System;
using System.Windows.Forms;
using TailorManagement1.Utilities;

namespace TailorManagement1
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            CommonUtilities.ExitApplication();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string userId = txtUserId.Text;
            string password = txtPassword.Text;

            if (CommonUtilities.isValidUser(userId, password))
            {
                this.Hide();
                CommonUtilities.OpenMainForm();
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            LanguageUtilities.ChangeLanguage(this, ConfigUtilities.companyLanguageCode);
        }

    }
}

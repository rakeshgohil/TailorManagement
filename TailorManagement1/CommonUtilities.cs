using System.Windows.Forms;

namespace TailorManagement1
{
    public class CommonUtilities
    {
        public static void ExitApplication()
        {
            Application.Exit();
        }

        public static bool isValidUser(string userId, string password)
        {
            return true;
            //add code for validating user from database
        }

        public static void OpenMainForm()
        {
            MainForm mainForm = new MainForm();
            mainForm.Show();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TailorManagement1.Utilities
{
    public static class FormUtilities
    {
        public static void GetAllLabelsAndButtons(Control control)
        {
            foreach (Control subControl in control.Controls)
            {
                if (subControl is Label)
                {
                    Label lbl = (Label)subControl;
                    Console.WriteLine($"{lbl.Name.ToLower()}\t{lbl.Text}");
                }
                else if (subControl is Button)
                {
                    Button btn = (Button)subControl;
                    Console.WriteLine($"{btn.Name.ToLower()}\t{btn.Text}");
                }
                else if (subControl is Panel)
                {
                    GetAllLabelsAndButtons(subControl);
                }
            }
        }

    }
}

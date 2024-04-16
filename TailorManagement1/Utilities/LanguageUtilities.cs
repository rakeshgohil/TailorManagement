using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TailorManagement1.Utilities
{
    public static class LanguageUtilities
    {
        public static void ChangeLanguage(Control control, string languageCode = null)
        {
            CultureInfo cultureInfo = CultureInfo.InvariantCulture;
            if (languageCode != null && !string.IsNullOrWhiteSpace(languageCode)) 
            {
                cultureInfo = new CultureInfo(languageCode);
            }
            Thread.CurrentThread.CurrentCulture = cultureInfo;
            Thread.CurrentThread.CurrentUICulture = cultureInfo;

            ResourceManager resourceManager = new ResourceManager("TailorManagement1.Resources", Assembly.GetExecutingAssembly());

            foreach (Control c in control.Controls)
            {
                if (c is Label || c is Button)
                {
                    string localizedText = resourceManager.GetString(c.Name.ToLower(), cultureInfo);
                    if (localizedText != null)
                    {
                        c.Text = localizedText;
                    }
                }
                else if (c is Panel)
                {
                    ChangeLanguage(c, languageCode);
                }
            }
        }
    }
}

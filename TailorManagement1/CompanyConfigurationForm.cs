using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TailorManagement1.Utilities;
using TailorManagementModels;
using static System.Net.Mime.MediaTypeNames;

namespace TailorManagement1
{
    public partial class CompanyConfigurationForm : Form
    {
        private Dictionary<string, string> companyConfigurations;
        public CompanyConfigurationForm()
        {
            InitializeComponent();
            companyConfigurations = new Dictionary<string, string>();
        }

        private void LoadLanguages()
        {
            var languageSection = ConfigurationManager.GetSection("languages") as NameValueCollection;

            if (languageSection != null)
            {
                foreach (string key in languageSection.AllKeys)
                {
                    string name = languageSection[key];
                    cmbDefaultLanguage.Items.Add(key+"_"+name);
                }
            }
        }
        private void CompanyConfiguration_Load(object sender, EventArgs e)
        {
            LanguageUtilities.ChangeLanguage(this, ConfigUtilities.companyLanguageCode);
            LoadLanguages();
            LoadAllCompanyConfigurations();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveCompanyConfigurations();
        }

        private async void SaveCompanyConfigurations()
        {
            companyConfigurations.Clear();
            companyConfigurations.Add(ConfigUtilities.BILLFOOTER1, txtBillFooter1.Text);
            companyConfigurations.Add(ConfigUtilities.BILLFOOTER2, txtBillFooter2.Text);
            companyConfigurations.Add(ConfigUtilities.BILLHEADER1, txtBillHeader1.Text);
            companyConfigurations.Add(ConfigUtilities.BILLHEADER2, txtBillHeader2.Text);
            companyConfigurations.Add(ConfigUtilities.BILLHEADER3, txtBillHeader3.Text);
            companyConfigurations.Add(ConfigUtilities.COMPANYADDRESS1, txtCompanyAddress.Text);
            companyConfigurations.Add(ConfigUtilities.COMPANYADDRESS2, txtCompanyAddress2.Text);
            companyConfigurations.Add(ConfigUtilities.COMPANYLOGO1, txtCompanyLogo1.Text);
            companyConfigurations.Add(ConfigUtilities.COMPANYLOGO2, txtCompanyLogo2.Text);
            companyConfigurations.Add(ConfigUtilities.COMPANYMOBILE, txtCompanyMobile.Text);
            companyConfigurations.Add(ConfigUtilities.COMPANYNAME, txtCompanyName.Text);
            companyConfigurations.Add(ConfigUtilities.DEFAULTLANGUAGE, cmbDefaultLanguage.Text);
            companyConfigurations.Add(ConfigUtilities.DELIVERYDAYS, txtDeliveryDays.Text);
            companyConfigurations.Add(ConfigUtilities.OWNERNAME, txtOwnerName.Text);
            companyConfigurations.Add(ConfigUtilities.PANTPRICE, txtPantPrice.Text);
            companyConfigurations.Add(ConfigUtilities.PANTQTY, txtPantQty.Text);
            companyConfigurations.Add(ConfigUtilities.PAYMENTDAYS, txtPaymentDues.Text);
            companyConfigurations.Add(ConfigUtilities.SHIRTPRICE, txtShirtPrice.Text);
            companyConfigurations.Add(ConfigUtilities.SHIRTQTY, txtShirtQty.Text);
            companyConfigurations.Add(ConfigUtilities.TRIALDAYS, txtTrialDays.Text);

            companyConfigurations.Add(ConfigUtilities.PANTLAMBAI, cmbPantLambai.Text);
            companyConfigurations.Add(ConfigUtilities.PANTKAMAR, cmbPantKamar.Text);
            companyConfigurations.Add(ConfigUtilities.PANTSEAT, cmbPantSeat.Text);
            companyConfigurations.Add(ConfigUtilities.PANTJANGH, cmbPantJangh.Text);
            companyConfigurations.Add(ConfigUtilities.PANTGOTHAN, cmbPantGothan.Text);
            companyConfigurations.Add(ConfigUtilities.PANTJOLO, cmbPantJolo.Text);
            companyConfigurations.Add(ConfigUtilities.PANTMOLI, cmbPantMoli.Text);

            companyConfigurations.Add(ConfigUtilities.SHIRTLAMBAI, cmbShirtLambai.Text);
            companyConfigurations.Add(ConfigUtilities.SHIRTCHATI, cmbShirtChati.Text);
            companyConfigurations.Add(ConfigUtilities.SHIRTSOLDER, cmbShirtSolder.Text);
            companyConfigurations.Add(ConfigUtilities.SHIRTBYE, cmbShirtBye.Text);
            companyConfigurations.Add(ConfigUtilities.SHIRTFRONT, cmbShirtFront.Text);
            companyConfigurations.Add(ConfigUtilities.SHIRTKOLOR, cmbShirtKolor.Text);
            companyConfigurations.Add(ConfigUtilities.SHIRTCUFF, cmbShirtCuff.Text);

            foreach (var companyConfiguration in companyConfigurations)
            {
                TailorManagementModels.CompanyConfiguration configuration = new TailorManagementModels.CompanyConfiguration()
                {
                    ConfigKey = companyConfiguration.Key,
                    ConfigValue = companyConfiguration.Value
                };
                await ApiClient.GetApiClient().PostAsync(configuration, "api/companyconfigurations");
            }
            ConfigUtilities.FillConfigurations();
            Thread.Sleep(1000);
            MessageBox.Show("Data saved successfully.");
            LoadAllCompanyConfigurations();
        }

        private async void LoadAllCompanyConfigurations()
        {
            cmbDefaultLanguage.Text = await ConfigUtilities.GetConfigurationValue(ConfigUtilities.DEFAULTLANGUAGE, "en-US_English");
            txtBillFooter1.Text = await ConfigUtilities.GetConfigurationValue(ConfigUtilities.BILLFOOTER1);
            txtBillFooter2.Text = await ConfigUtilities.GetConfigurationValue(ConfigUtilities.BILLFOOTER2);
            txtBillHeader1.Text = await ConfigUtilities.GetConfigurationValue(ConfigUtilities.BILLHEADER1);
            txtBillHeader2.Text = await ConfigUtilities.GetConfigurationValue(ConfigUtilities.BILLHEADER2);
            txtBillHeader3.Text = await ConfigUtilities.GetConfigurationValue(ConfigUtilities.BILLHEADER3);
            txtCompanyAddress.Text = await ConfigUtilities.GetConfigurationValue(ConfigUtilities.COMPANYADDRESS1);
            txtCompanyAddress2.Text = await ConfigUtilities.GetConfigurationValue(ConfigUtilities.COMPANYADDRESS2);
            txtCompanyLogo1.Text = await ConfigUtilities.GetConfigurationValue(ConfigUtilities.COMPANYLOGO1);
            txtCompanyLogo2.Text = await ConfigUtilities.GetConfigurationValue(ConfigUtilities.COMPANYLOGO2);
            txtCompanyMobile.Text = await ConfigUtilities.GetConfigurationValue(ConfigUtilities.COMPANYMOBILE);
            txtCompanyName.Text = await ConfigUtilities.GetConfigurationValue(ConfigUtilities.COMPANYNAME);
            txtDeliveryDays.Text = await ConfigUtilities.GetConfigurationValue(ConfigUtilities.DELIVERYDAYS, "15");
            txtOwnerName.Text = await ConfigUtilities.GetConfigurationValue(ConfigUtilities.OWNERNAME);
            txtPantPrice.Text = await ConfigUtilities.GetConfigurationValue(ConfigUtilities.PANTPRICE, "0.00");
            txtPantQty.Text = await ConfigUtilities.GetConfigurationValue(ConfigUtilities.PANTQTY, "1");
            txtPaymentDues.Text = await ConfigUtilities.GetConfigurationValue(ConfigUtilities.PAYMENTDAYS, "30");
            txtShirtPrice.Text = await ConfigUtilities.GetConfigurationValue(ConfigUtilities.SHIRTPRICE, "0.00");
            txtShirtQty.Text = await ConfigUtilities.GetConfigurationValue(ConfigUtilities.SHIRTQTY, "1");
            txtTrialDays.Text = await ConfigUtilities.GetConfigurationValue(ConfigUtilities.TRIALDAYS, "14");

            string configValue = await ConfigUtilities.GetConfigurationValue(ConfigUtilities.PANTLAMBAI, "1");
            cmbPantLambai.SelectedIndex = Convert.ToInt32(configValue)-1;
            configValue = await ConfigUtilities.GetConfigurationValue(ConfigUtilities.PANTGOTHAN, "1");
            cmbPantGothan.SelectedIndex = Convert.ToInt32(configValue)-1;
            configValue = await ConfigUtilities.GetConfigurationValue(ConfigUtilities.PANTJANGH, "1");
            cmbPantJangh.SelectedIndex = Convert.ToInt32(configValue) - 1;
            configValue = await ConfigUtilities.GetConfigurationValue(ConfigUtilities.PANTJOLO, "1");
            cmbPantJolo.SelectedIndex = Convert.ToInt32(configValue) - 1;
            configValue = await ConfigUtilities.GetConfigurationValue(ConfigUtilities.PANTSEAT, "1");
            cmbPantSeat.SelectedIndex = Convert.ToInt32(configValue) - 1;
            configValue = await ConfigUtilities.GetConfigurationValue(ConfigUtilities.PANTKAMAR, "1");
            cmbPantKamar.SelectedIndex = Convert.ToInt32(configValue) - 1;
            configValue = await ConfigUtilities.GetConfigurationValue(ConfigUtilities.PANTMOLI, "1");
            cmbPantMoli.SelectedIndex = Convert.ToInt32(configValue) - 1;

            configValue = await ConfigUtilities.GetConfigurationValue(ConfigUtilities.SHIRTLAMBAI, "1");
            cmbShirtLambai.SelectedIndex = Convert.ToInt32(configValue) - 1;
            configValue = await ConfigUtilities.GetConfigurationValue(ConfigUtilities.SHIRTCHATI, "1");
            cmbShirtChati.SelectedIndex = Convert.ToInt32(configValue) - 1;
            configValue = await ConfigUtilities.GetConfigurationValue(ConfigUtilities.SHIRTBYE, "1");
            cmbShirtBye.SelectedIndex = Convert.ToInt32(configValue) - 1;
            configValue = await ConfigUtilities.GetConfigurationValue(ConfigUtilities.SHIRTCUFF, "1");
            cmbShirtCuff.SelectedIndex = Convert.ToInt32(configValue) - 1;
            configValue = await ConfigUtilities.GetConfigurationValue(ConfigUtilities.SHIRTFRONT, "1");
            cmbShirtFront.SelectedIndex = Convert.ToInt32(configValue) - 1;
            configValue = await ConfigUtilities.GetConfigurationValue(ConfigUtilities.SHIRTKOLOR, "1");
            cmbShirtKolor.SelectedIndex = Convert.ToInt32(configValue) - 1;
            configValue = await ConfigUtilities.GetConfigurationValue(ConfigUtilities.SHIRTSOLDER, "1");
            cmbShirtSolder.SelectedIndex = Convert.ToInt32(configValue) - 1;
        }

        private void txtDeliveryDays_Leave(object sender, EventArgs e)
        {
            FormUtilities.NumericControlLeave(sender, e, true);
        }

        private void txtDeliveryDays_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormUtilities.NumericControlKeyPress(sender, e, true);
        }

        private void txtShirtPrice_Leave(object sender, EventArgs e)
        {
            FormUtilities.NumericControlLeave(sender, e);
        }

        private void txtShirtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormUtilities.NumericControlKeyPress(sender, e);
        }

        private void txtPantQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormUtilities.NumericControlKeyPress(sender, e, true);
        }

        private void txtPantQty_Leave(object sender, EventArgs e)
        {
            FormUtilities.NumericControlLeave(sender, e, true);
        }

        private void txtPantPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormUtilities.NumericControlKeyPress(sender, e);
        }

        private void txtPantPrice_Leave(object sender, EventArgs e)
        {
            FormUtilities.NumericControlLeave(sender, e);
        }

        private void txtShirtQty_Leave(object sender, EventArgs e)
        {
            FormUtilities.NumericControlLeave(sender, e, true);
        }

        private void txtShirtQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormUtilities.NumericControlKeyPress(sender, e, true);
        }

        private void txtTrialDays_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormUtilities.NumericControlKeyPress(sender, e, true);
        }

        private void txtTrialDays_Leave(object sender, EventArgs e)
        {
            FormUtilities.NumericControlLeave(sender, e, true);
        }
    }
}

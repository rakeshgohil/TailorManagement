using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TailorManagement1.Utilities;
using TailorManagementModels;

namespace TailorManagement1
{
    public partial class CompanyConfiguration : Form
    {
        private const string COMPANYNAME = "CompanyName";
        private const string COMPANYMOBILE = "CompanyMobile";
        private const string COMPANYADDRESS = "CompanyAddress";
        private const string SHIRTQTY = "ShirtQty";
        private const string PANTQTY = "PantQty";
        private const string SHIRTPRICE = "ShirtPrice";
        private const string PANTPRICE = "PantPrice";
        private const string DELIVERYDAYS = "DeliveryDays";
        private const string DEFAULTLANGUAGE = "DefaultLanguage";
        private Dictionary<string, string> companyConfigurations;
        public CompanyConfiguration()
        {
            InitializeComponent();
            companyConfigurations = new Dictionary<string, string>();
        }

        private void CompanyConfiguration_Load(object sender, EventArgs e)
        {
            LanguageUtilities.ChangeLanguage(this);
            LoadAllCompanyConfigurations();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveCompanyConfigurations();
        }

        private async void SaveCompanyConfigurations()
        {
            companyConfigurations.Clear();
            companyConfigurations.Add(COMPANYADDRESS, "");
            companyConfigurations.Add(COMPANYMOBILE, "");
            companyConfigurations.Add(COMPANYNAME, "");
            companyConfigurations.Add(SHIRTQTY, "");
            companyConfigurations.Add(SHIRTPRICE, "");
            companyConfigurations.Add(PANTQTY, "");
            companyConfigurations.Add(PANTPRICE, "");
            companyConfigurations.Add(DEFAULTLANGUAGE, "");
            companyConfigurations.Add(DELIVERYDAYS, "");
        }

        private async void LoadAllCompanyConfigurations()
        {
            txtCompanyAddress.Text = await ConfigUtilities.GetConfigurationValue(COMPANYADDRESS, "");
            txtCompanyMobile.Text = await ConfigUtilities.GetConfigurationValue(COMPANYMOBILE, "");
            txtCompanyName.Text = await ConfigUtilities.GetConfigurationValue(COMPANYNAME, "");
            txtDeliveryDays.Text = await ConfigUtilities.GetConfigurationValue(DELIVERYDAYS, "");
            txtPantQty.Text = await ConfigUtilities.GetConfigurationValue(PANTQTY, "");
            txtShirtQty.Text = await ConfigUtilities.GetConfigurationValue(SHIRTQTY, "");
            mskPantPrice.Text = await ConfigUtilities.GetConfigurationValue(PANTPRICE, "");
            mskShirtPrice.Text = await ConfigUtilities.GetConfigurationValue(SHIRTPRICE, "");
            cmbDefaultLanguage.Text = await ConfigUtilities.GetConfigurationValue(DEFAULTLANGUAGE, "");

        }

    }
}

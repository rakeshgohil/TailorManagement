
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TailorManagement1.Utilities
{
    public static class ConfigUtilities
    {
        public const string BILLFOOTER1 = "BillFooter1";
        public const string BILLFOOTER2 = "BillFooter2";
        public const string BILLHEADER1 = "BillHeader1";
        public const string BILLHEADER2 = "BillHeader2";
        public const string BILLHEADER3 = "BillHeader3";
        public const string COMPANYADDRESS1 = "CompanyAddress1";
        public const string COMPANYADDRESS2 = "CompanyAddress2";
        public const string COMPANYLOGO1 = "CompanyLogo1";
        public const string COMPANYLOGO2 = "CompanyLogo2";
        public const string COMPANYMOBILE = "CompanyMobile";
        public const string COMPANYNAME = "CompanyName";
        public const string DEFAULTLANGUAGE = "DefaultLanguage";
        public const string DELIVERYDAYS = "DeliveryDays";
        public const string OWNERNAME = "OwnerName";
        public const string PANTPRICE = "PantPrice";
        public const string PANTQTY = "PantQty";
        public const string PAYMENTDAYS = "PaymentDays";
        public const string SHIRTPRICE = "ShirtPrice";
        public const string SHIRTQTY = "ShirtQty";
        public const string TRIALDAYS = "TrialDays";

        public const string PANTLAMBAI = "PantLambai";
        public const string PANTKAMAR = "PantKamar";
        public const string PANTSEAT = "PantSeat";
        public const string PANTJANGH = "PantJangh";
        public const string PANTGOTHAN = "PantGothan";
        public const string PANTJOLO = "PantJolo";
        public const string PANTMOLI = "PantMoli";

        public const string SHIRTLAMBAI = "ShirtLambai";
        public const string SHIRTCHATI = "ShirtChati";
        public const string SHIRTSOLDER = "ShirtSolder";
        public const string SHIRTBYE = "ShirtBye";
        public const string SHIRTFRONT = "ShirtFront";
        public const string SHIRTKOLOR = "ShirtKolor";
        public const string SHIRTCUFF = "ShirtCuff";

        public static string companyLanguageCode = "en-US";
        private static Dictionary<string, string> configurations;

        public static async void FillConfigurations()
        {
            configurations = new Dictionary<string, string>();
            var companyconfigurations = await ApiClient.GetApiClient().GetAsync<List<TailorManagementModels.CompanyConfiguration>>("api/CompanyConfigurations");
            configurations = companyconfigurations.ToDictionary(x => x.ConfigKey.ToLower(), x => x.ConfigValue);

            string configLanguage = await GetConfigurationValue(ConfigUtilities.DEFAULTLANGUAGE, "en-US_English");
            string[] parts = configLanguage.Split('_');
            companyLanguageCode = parts[0];
        }

        public static async Task<string> GetConfigurationValue(string configkey, string defaultValue = "")
        {
            if(configurations == null || configurations.Count == 0)
            {
                configurations = new Dictionary<string, string>();
                var companyconfigurations = await ApiClient.GetApiClient().GetAsync<List<TailorManagementModels.CompanyConfiguration>>("api/CompanyConfigurations");
                configurations = companyconfigurations.ToDictionary(x => x.ConfigKey.ToLower(), x => x.ConfigValue);
            }
            if (configkey != null && !string.IsNullOrWhiteSpace(configkey) && configurations.ContainsKey(configkey.ToLower()))
            {
                return configurations[configkey.ToLower()];
            }
            return defaultValue;
        }
    }
}


using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TailorManagement1.Utilities
{
    public static class ConfigUtilities
    {
        private static Dictionary<string, string> configurations;
        public static async Task<string> GetConfigurationValue(string configkey, string defaultValue)
        {
            if(configurations == null || configurations.Count == 0)
            {
                configurations = new Dictionary<string, string>();
                var companyconfigurations = await ApiClient.GetApiClient().GetAsync<List<TailorManagementModels.CompanyConfiguration>>("api/CompanyConfigurations");
                configurations = companyconfigurations.ToDictionary(x => x.ConfigKey.ToLower(), x => x.ConfigValue);
            }
            if (configkey != null && !string.IsNullOrWhiteSpace(configkey) && configurations.ContainsKey(configkey.ToLower()))
            {
                return configurations[configkey];
            }
            return defaultValue;
        }
    }
}

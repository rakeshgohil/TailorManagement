using System.Text;

namespace TailorManagementModels
{
    public class PantConfiguration
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public string LocalDescription { get; set; }
        public bool isValid(out StringBuilder error)
        {
            error = new StringBuilder();
            if (string.IsNullOrWhiteSpace(Description))
            {
                error.AppendLine("Description cannot be blank.");
            }

            if (string.IsNullOrWhiteSpace(LocalDescription))
            {
                error.AppendLine("Local Description cannot be blank.");
            }

            if (string.IsNullOrWhiteSpace(error.ToString()))
            {
                return false;
            }
            return true;
        }

    }
}

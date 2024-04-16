using System.Text;

namespace TailorManagementModels
{
    public class Customer
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Mobile { get; set; }
        public bool isValid(out StringBuilder error)
        {
            error = new StringBuilder();
                        
            if (string.IsNullOrWhiteSpace(Mobile))
            {
                error.AppendLine("Mobile cannot be blank.");
            }

            if (string.IsNullOrWhiteSpace(Name))
            {
                error.AppendLine("Name cannot be blank.");
            }
            
            if (!string.IsNullOrWhiteSpace(error.ToString()))
            {
                return false;
            }
            return true;
        }
    }
}

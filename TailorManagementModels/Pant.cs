using System.Text;

namespace TailorManagementModels
{
    public class Pant
    {
        public int Id { get; set; }

        public Customer Customer { get; set; }

        public string Length1 { get; set; }

        public string Length2 { get; set; }

        public string Length3 { get; set; }

        public string Length4 { get; set; }

        public string Length5 { get; set; }

        public string Kamar1 { get; set; }

        public string Kamar2 { get; set; }

        public string Kamar3 { get; set; }

       public string Kamar4 { get; set; }

        public string Kamar5 { get; set; }

        public string Seat1 { get; set; }

        public string Seat2 { get; set; }

        public string Seat3 { get; set; }

        public string Seat4 { get; set; }

        public string Seat5 { get; set; }

        public string Jangh1 { get; set; }

        public string Jangh2 { get; set; }

        public string Jangh3 { get; set; }

        public string Jangh4 { get; set; }

        public string Jangh5 { get; set; }

        public string Gothan1 { get; set; }

        public string Gothan2 { get; set; }

        public string Gothan3 { get; set; }

        public string Gothan4 { get; set; }

        public string Gothan5 { get; set; }

        public string Jolo1 { get; set; }

        public string Jolo2 { get; set; }

        public string Jolo3 { get; set; }

        public string Jolo4 { get; set; }

        public string Jolo5 { get; set; }

        public string Moli1 { get; set; }

        public string Moli2 { get; set; }

        public string Moli3 { get; set; }

        public string Moli4 { get; set; }

        public string Moli5 { get; set; }

        public string Notes { get; set; }
        public bool isValid(out StringBuilder error)
        {
            error = new StringBuilder();
            if (string.IsNullOrWhiteSpace(Length1))
            {
                error.AppendLine("Pant Length cannot be blank.");
            }

            if (string.IsNullOrWhiteSpace(Kamar1))
            {
                error.AppendLine("Pant Kamar cannot be blank.");
            }

            if (string.IsNullOrWhiteSpace(Seat1))
            {
                error.AppendLine("Pant Seat cannot be blank.");
            }

            if (string.IsNullOrWhiteSpace(Jangh1))
            {
                error.AppendLine("Pant Jangh cannot be blank.");
            }

            if (string.IsNullOrWhiteSpace(Gothan1))
            {
                error.AppendLine("Pant Gothan cannot be blank.");
            }

            if (string.IsNullOrWhiteSpace(Jolo1))
            {
                error.AppendLine("Pant Jolo cannot be blank.");
            }

            if (string.IsNullOrWhiteSpace(Moli1))
            {
                error.AppendLine("Pant Moli cannot be blank.");
            }

            if (!string.IsNullOrWhiteSpace(error.ToString()))
            {
                return false;
            }
            return true;
        }

    }
}
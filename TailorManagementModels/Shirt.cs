using System.Text;

namespace TailorManagementModels
{

    public class Shirt
    {
        public int Id { get; set; }
        public Customer Customer { get; set; }
        public string Length1 { get; set; }
        public string Length2 { get; set; }
        public string Length3 { get; set; }
        public string Length4 { get; set; }
        public string Length5 { get; set; }


        public string Chati1 { get; set; }


        public string Chati2 { get; set; }


        public string Chati3 { get; set; }


        public string Chati4 { get; set; }


        public string Chati5 { get; set; }


        public string Solder1 { get; set; }


        public string Solder2 { get; set; }


        public string Solder3 { get; set; }


        public string Solder4 { get; set; }


        public string Solder5 { get; set; }


        public string Bye1 { get; set; }


        public string Bye2 { get; set; }


        public string Bye3 { get; set; }


        public string Bye4 { get; set; }


        public string Bye5 { get; set; }


        public string Front1 { get; set; }


        public string Front2 { get; set; }


        public string Front3 { get; set; }


        public string Front4 { get; set; }


        public string Front5 { get; set; }


        public string Kolor1 { get; set; }


        public string Kolor2 { get; set; }


        public string Kolor3 { get; set; }


        public string Kolor4 { get; set; }


        public string Kolor5 { get; set; }


        public string Cuff1 { get; set; }


        public string Cuff2 { get; set; }


        public string Cuff3 { get; set; }


        public string Cuff4 { get; set; }


        public string Cuff5 { get; set; }

        public string Notes { get; set; }

        public bool isValid(out StringBuilder error)
        {
            error = new StringBuilder();
            if (string.IsNullOrWhiteSpace(Length1))
            {
                error.AppendLine("Shirt Length cannot be blank.");
            }

            if (string.IsNullOrWhiteSpace(Chati1))
            {
                error.AppendLine("Shirt Chati cannot be blank.");
            }

            if (string.IsNullOrWhiteSpace(Solder1))
            {
                error.AppendLine("Shirt Solder cannot be blank.");
            }

            if (string.IsNullOrWhiteSpace(Bye1))
            {
                error.AppendLine("Shirt Bye cannot be blank.");
            }

            if (string.IsNullOrWhiteSpace(Front1))
            {
                error.AppendLine("Shirt Front cannot be blank.");
            }

            if (string.IsNullOrWhiteSpace(Kolor1))
            {
                error.AppendLine("Shirt Kolor cannot be blank.");
            }

            if (string.IsNullOrWhiteSpace(Cuff1))
            {
                error.AppendLine("Shirt Cuff cannot be blank.");
            }

            if (!string.IsNullOrWhiteSpace(error.ToString()))
            {
                return false;
            }
            return true;
        }
    }
}
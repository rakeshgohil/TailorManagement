using System.ComponentModel.DataAnnotations;

namespace TailorManagementModels
{

    public class Shirt
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(10)]
        public string Length { get; set; }

        [MaxLength(10)]
        public string Chest { get; set; }
    }

}

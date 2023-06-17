using System.ComponentModel.DataAnnotations;
using Municipality.Enums;

namespace Municipality.Entities
{
    public class User
    {
        [Key]
        public string Pin { get; set; }
        public string Password { get; set; }
        public string Fullname { get; set; }
        public int VillageId { get; set; }
        public UserType Type { get; set; }
        public int? AgriculturalLandId { get; set; }
    }
}

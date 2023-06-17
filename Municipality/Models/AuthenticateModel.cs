using System.ComponentModel.DataAnnotations;

namespace Municipality.Models
{
    public class AuthenticateModel
    {
        [Required]
        public string Pin { get; set; }

        [Required]
        public string Password { get; set; }
    }
}

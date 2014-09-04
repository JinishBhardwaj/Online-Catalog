
using System.ComponentModel.DataAnnotations;
namespace OnlineCatalog.Api.Models
{
    public class SignupModel
    {
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please provide your password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please provide your firstname")]
        public string Firstname { get; set; }

        [Required(ErrorMessage = "Please provide your lastname")]
        public string Lastname { get; set; }

        [Required(ErrorMessage = "Please provide your address")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Please provide your city")]
        public string City { get; set; }

        [Required(ErrorMessage = "Please provide your pincode")]
        public string Pincode { get; set; }

        [Required(ErrorMessage = "Please provide your province")]
        public int ProvinceId { get; set; }
    }
}
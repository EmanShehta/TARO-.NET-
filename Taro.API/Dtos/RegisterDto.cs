using System.ComponentModel.DataAnnotations;

namespace Taro.API.Dtos
{
    public class RegisterDto
    {
        [Required]
        public string firstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Phone]
        public string PhoneNumber { get; set; }

        [Required]
        [MinLength(8)]
        public string Password { get; set; }
        [Required]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
        [Required]
        public string RoleName { get; set; }
    }
}

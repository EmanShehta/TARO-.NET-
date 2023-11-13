using System.ComponentModel.DataAnnotations;

namespace Taro.API.Dtos
{
    public class loginDto
    {
        [EmailAddress]
        public string Email { get; set; }
        public string Password { get; set; }
    }
}

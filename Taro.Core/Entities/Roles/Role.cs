using Microsoft.AspNetCore.Identity;

namespace Taro.Core.Entities.Roles
{
    public class Role :  IdentityRole
    {
        public DateTime? CreatedAt { get; set; }
        public string CreatedBy { get; set; }
    }
}

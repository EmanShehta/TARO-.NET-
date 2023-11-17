using Microsoft.AspNetCore.Identity;

    public class AppUser : IdentityUser
    {
        public string firstName { get; set; }

        public string lastName { get; set; }

        public Address address { get; set; }
        public string RoleName { get; set; }

    }

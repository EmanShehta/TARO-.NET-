
    public class Address
    {
        public int AddressId { get; set; } 
        public string Street { get; set; } 
        public string City { get; set; }  
        public string Country { get; set; }

        public string AppUserId { get; set; }

        public AppUser User { get; set; }

    }


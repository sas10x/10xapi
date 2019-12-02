using System.Collections.Generic;

namespace Domain
{
    public class Address
    {
        public long AddressId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
        public long Phone { get; set; }
        public virtual Province Province { get; set; }
        public virtual City City { get; set; }
        public virtual AppUser User { get; set; }
        public string Street { get; set; }
        public string Barangay { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
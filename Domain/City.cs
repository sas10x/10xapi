using System.Collections.Generic;

namespace Domain
{
    public class City
    {
        public long CityId { get; set; }
        public string PsgcCode { get; set; }
        public string CityDesc { get; set; }
        public virtual Region Region { get; set; }
        public virtual Province Province { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }
    }
}
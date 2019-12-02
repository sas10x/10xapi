using System.Collections.Generic;

namespace Domain
{
    public class Province
    {
        public long ProvinceId { get; set; }
        public string PsgcCode { get; set; }
        public string ProvDesc { get; set; }
        public virtual Region Region { get; set; }
        public virtual ICollection<City> Citys { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }
    }
}
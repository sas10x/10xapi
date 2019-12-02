using System.Collections.Generic;

namespace Domain
{
    public class Region
    {
        public long RegionId { get; set; }
        public string PsgcCode { get; set; }
        public string RegDesc { get; set; }
        public virtual ICollection<City> Citys { get; set; }
        public virtual ICollection<Province> Provinces { get; set; }
    }
}
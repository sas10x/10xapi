using System;
using System.Collections.Generic;

namespace Domain
{
    public class Order
    {
        public Guid OrderId { get; set; }
        public DateTime Date{ get; set; }
        public decimal Amount { get; set; }
        public virtual Address Address { get; set; }
        public virtual AppUser User { get; set; }
        public virtual ICollection<Cart> Carts { get; set; }
    }
}
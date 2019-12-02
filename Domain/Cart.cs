namespace Domain
{
    public class Cart
    {
        public long CartId { get; set; }
        public long Quantity { get; set; }
        public double Price { get; set; }
        public double Total { get; set; }
        public virtual Product Product { get; set; }
        public virtual Order Order { get; set; }
    }
}
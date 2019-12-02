namespace Domain
{
    public class Product
    {
        public long ProductId { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public double BasePrice { get; set; }
        public double Price { get; set; }
        public virtual Discount Discount { get; set; }
        public virtual VarGrade VarGrade { get; set; }
        public virtual VarDiameter VarDiameter { get; set; }
        public virtual VarLength VarLength { get; set; }
    }
}
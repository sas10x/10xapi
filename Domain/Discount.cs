using System;

namespace Domain
{
    public class Discount
    {
        public long DiscountId { get; set; }
        public DateTime Date { get; set; }
        public decimal Pursinto { get; set; }
        public virtual VarGrade VarGrade { get; set; }

    }
}
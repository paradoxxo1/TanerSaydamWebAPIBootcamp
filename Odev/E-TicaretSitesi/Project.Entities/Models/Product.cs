namespace Project.Entities.Models
{
    public  class Product : BaseEntity
    {
        public string ProductName { get; set; }
        public Decimal UnitPrice { get; set; }
        public int? CategoryId { get; set; }

        public virtual Category Category { get; set; }
        public virtual List<OrderDetail> OrderDetails { get; set; }

    }
}

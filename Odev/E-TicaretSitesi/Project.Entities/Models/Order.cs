namespace Project.Entities.Models
{
    public class Order : BaseEntity
    {
        public string ShippingAdress { get; set; }
        public int? AppUserId { get; set; }

        public virtual AppUser AppUser { get; set; }
        public virtual List<OrderDetail> OrderDetails { get; set; }
    }
}

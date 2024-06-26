﻿namespace Project.Entities.Models
{
    public class OrderDetail : BaseEntity
    {
        public int ProductId { get; set; }
        public int OrderId { get; set; }
        public int Quantity { get; set; }

        public virtual Product Product { get; set; }
        public virtual Order Order { get; set; }    
    }
}

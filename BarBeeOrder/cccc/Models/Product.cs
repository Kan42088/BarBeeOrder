using System;
using System.Collections.Generic;

#nullable disable

namespace cccc.Models
{
    public partial class Product
    {
        public Product()
        {
            AttributePrices = new HashSet<AttributePrice>();
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ShortDescription { get; set; }
        public int? CategoryId { get; set; }
        public string Description { get; set; }
        public int? Price { get; set; }
        public int? Discount { get; set; }
        public string Video { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string Tittle { get; set; }

        public virtual Category Category { get; set; }
        public virtual ICollection<AttributePrice> AttributePrices { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}

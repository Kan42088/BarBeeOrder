using System;
using System.Collections.Generic;

#nullable disable

namespace BarBeeOrder.Models
{
    public partial class Category
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }

        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? ParrentId { get; set; }
        public int? Levels { get; set; }
        public string Ordering { get; set; }
        public bool Published { get; set; }
        public string Title { get; set; }
        public string Cover { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace BarBeeOrder.Models
{
    public partial class Category
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }

        
        [Required(ErrorMessage = "Vui lòng không để trống!")]
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? ParrentId { get; set; }
        public int? Levels { get; set; }
        public int? Ordering { get; set; }
        public bool Published { get; set; }
        public string Title { get; set; }
        public string Cover { get; set; }
        public string Thumb { get; set; }
        public bool IsDeleted { get; set; }
        public int? Type { get; set; }
        public string Alias { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}

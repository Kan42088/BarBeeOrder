﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace BarBeeOrder.Models
{
    public partial class Product
    {
        public Product()
        {
            AttributePrices = new HashSet<AttributePrice>();
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int ProductId { get; set; }
        [Required(ErrorMessage = "Tên sản phẩm không được trống!")]
        [StringLength(100)]
        public string ProductName { get; set; }
        public string ShortDescription { get; set; }
        public int? CategoryId { get; set; }
        public string Description { get; set; }
        [Required(ErrorMessage = "Giá bán không được trống!")]
        [Range(0, 100000000, ErrorMessage = "Giá phải là số tự nhiên lớn hơn 0!")]
        public int? Price { get; set; }
        public int? Discount { get; set; }
        public string Video { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string Tittle { get; set; }
        public string Thumb { get; set; }
        public bool BestSellers { get; set; }
        public bool Active { get; set; }
        public bool HomeFlag { get; set; }

        public virtual Category Category { get; set; }
        public virtual ICollection<AttributePrice> AttributePrices { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}

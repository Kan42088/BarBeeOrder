using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace BarBeeOrder.Models
{
    public partial class Page
    {
        public int PageId { get; set; }
        [Required(ErrorMessage = "Tên sản phẩm không được trống!")]
        [StringLength(100)]
        public string PageName { get; set; }
        public string PageContent { get; set; }
        public bool Published { get; set; }
        public string Tittle { get; set; }

        [Range(0, 100, ErrorMessage = "Thứ tự phải là số tự nhiên!")]
        [RegularExpression(@"^[0-9]{1,15}$",ErrorMessage = "Thứ tự chỉ được nhập là số tự nhiên")]
        public int? Ordering { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}

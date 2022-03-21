using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace BarBeeOrder.Models
{
    public partial class Page
    {
        public int PageId { get; set; }
        [Required(ErrorMessage = "Vui lòng không để trống!")]
        public string PageName { get; set; }
        public string PageContent { get; set; }
        public bool Published { get; set; }
        [Required(ErrorMessage = "Vui lòng không để trống!")]
        public string Tittle { get; set; }
        public int? Ordering { get; set; }
        public DateTime? CreatedDate { get; set; }
        public bool IsHeader { get; set; }
        public string Thumb { get; set; }
        public string Alias { get; set; }
    }
}

using System;
using System.Collections.Generic;

#nullable disable

namespace BarBeeOrder.Models
{
    public partial class Page
    {
        public int PageId { get; set; }
        public string PageName { get; set; }
        public string PageContent { get; set; }
        public bool? Published { get; set; }
        public string Tittle { get; set; }
        public int? Ordering { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}

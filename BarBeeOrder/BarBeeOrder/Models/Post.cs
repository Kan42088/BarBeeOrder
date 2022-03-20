using System;
using System.Collections.Generic;

#nullable disable

namespace BarBeeOrder.Models
{
    public partial class Post
    {
        public int PostId { get; set; }
        public string Tittle { get; set; }
        public string ShortContent { get; set; }
        public string PostContent { get; set; }
        public string Thumb { get; set; }
        public bool Published { get; set; }
        public bool IsHot { get; set; }
        public bool IsNewfeed { get; set; }
        public bool IsDelete { get; set; }
        public string Author { get; set; }
        public int? CustomerId { get; set; }
        public int? CategoryId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string Alias { get; set; }
        public int? Views { get; set; }

        public virtual Customer Customer { get; set; }
    }
}

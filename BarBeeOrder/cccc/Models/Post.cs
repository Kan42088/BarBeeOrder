using System;
using System.Collections.Generic;

#nullable disable

namespace cccc.Models
{
    public partial class Post
    {
        public int PostId { get; set; }
        public string Tittle { get; set; }
        public string ShortContent { get; set; }
        public string PostContent { get; set; }
        public bool Published { get; set; }
        public string CreatedDate { get; set; }
        public int? Author { get; set; }
        public int? AccountId { get; set; }
        public int? CategoryId { get; set; }
        public bool? IsHot { get; set; }

        public virtual Account Account { get; set; }
    }
}

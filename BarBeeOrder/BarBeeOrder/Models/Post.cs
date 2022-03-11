using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace BarBeeOrder.Models
{
    public partial class Post
    {
        public int PostId { get; set; }
        [Required(ErrorMessage = "Tiêu đề không được trống!")]
        [StringLength(100)]
        public string Tittle { get; set; }
        public string ShortContent { get; set; }
        public string PostContent { get; set; }
        public bool Published { get; set; }
        public string CreatedDate { get; set; }
        public int? Author { get; set; }
        [Required(ErrorMessage = "Không được trống!")]
        public int? AccountId { get; set; }
        public int? CategoryId { get; set; }
        public bool? IsHot { get; set; }

        public virtual Account Account { get; set; }
    }
}

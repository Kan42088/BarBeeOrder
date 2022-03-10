using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace BarBeeOrder.Models
{
    public partial class Account
    {
        public Account()
        {
            Posts = new HashSet<Post>();
        }

        public int AccountId { get; set; }
        [Required(ErrorMessage = "Email không được trống!")]
        [StringLength(100)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Mật khẩu không được trống!")]
        [StringLength(100)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Số điện thoại không được trống!")]
        [StringLength(100)]
        public string Phone { get; set; }
        public bool Status { get; set; }
        [Required(ErrorMessage = "Tên không được trống!")]
        [StringLength(100)]
        public string Fullname { get; set; }
        public int? RollId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? LastLogin { get; set; }

        public virtual Role Roll { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
    }
}

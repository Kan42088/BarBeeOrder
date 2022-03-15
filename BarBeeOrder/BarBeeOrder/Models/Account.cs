using System;
using System.Collections.Generic;

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
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public bool Status { get; set; }
        public string Fullname { get; set; }
        public int? RollId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? LastLogin { get; set; }

        public virtual Role Roll { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
    }
}

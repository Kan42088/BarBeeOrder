using System;
using System.Collections.Generic;

#nullable disable

namespace BarBeeOrder.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Orders = new HashSet<Order>();
        }

        public int CustomerId { get; set; }
        public string Fullname { get; set; }
        public DateTime? Birtday { get; set; }
        public string Avatar { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public bool Status { get; set; }
        public DateTime? LastLogin { get; set; }
        public DateTime? CreatedDate { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}

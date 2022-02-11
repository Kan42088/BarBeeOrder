using System;
using System.Collections.Generic;

#nullable disable

namespace BarBeeOrder.Models
{
    public partial class PaymentId
    {
        public PaymentId()
        {
            Orders = new HashSet<Order>();
        }

        public int PaymentId1 { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}

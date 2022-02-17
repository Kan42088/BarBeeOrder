using System;
using System.Collections.Generic;

#nullable disable

namespace cccc.Models
{
    public partial class ShippingUnit
    {
        public ShippingUnit()
        {
            Orders = new HashSet<Order>();
        }

        public int Suid { get; set; }
        public string Name { get; set; }
        public byte[] Phone { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}

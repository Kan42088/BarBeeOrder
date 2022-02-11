using System;
using System.Collections.Generic;

#nullable disable

namespace BarBeeOrder.Models
{
    public partial class TransactionStatus
    {
        public TransactionStatus()
        {
            Orders = new HashSet<Order>();
        }

        public int TransactionStatusId { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}

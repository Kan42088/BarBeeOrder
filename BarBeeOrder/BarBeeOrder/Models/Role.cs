using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace BarBeeOrder.Models
{
    public partial class Role
    {
        public Role()
        {
            Customers = new HashSet<Customer>();
        }

        public int RoleId { get; set; }
        [Required(ErrorMessage = "Vui lòng không để trống!")]
        public string RoleName { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Customer> Customers { get; set; }
    }
}

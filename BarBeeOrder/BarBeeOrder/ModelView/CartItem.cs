using BarBeeOrder.Models;
using System.ComponentModel.DataAnnotations;

namespace BarBeeOrder.ModelView
{
    public class CartItem
    {
        
        public Product product { get; set; }
        public int amount { get; set; }
        public double TotalMoney => amount * product.Price;
    }
}

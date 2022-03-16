using BarBeeOrder.Models;
using System.Collections.Generic;

namespace BarBeeOrder.ModelView
{
    public class HomeProduct
    {
        public Category category { get; set; }
        public List<Product> products { get; set; }
    }
}

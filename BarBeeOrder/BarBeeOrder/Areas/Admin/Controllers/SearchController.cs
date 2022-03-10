using BarBeeOrder.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace BarBeeOrder.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SearchController : Controller
    {
        private readonly BarBeeOrderContext _context;
        
        public SearchController(BarBeeOrderContext context)
        {
            _context = context;
        }

        //Get: /Search/FindProduct
        [HttpGet]
        public IActionResult FindProduct(string keyword)
        {
            List<Product> lsProducts = new List<Product>();
            if (string.IsNullOrEmpty(keyword)|| keyword.Length<1)
            {
                lsProducts = _context.Products.AsNoTracking().Include(c => c.Category).Include(ap => ap.AttributePrices).OrderByDescending(x => x.ProductId).ToList();
                return PartialView("ListProductSearchPartial", lsProducts);
            }
            
            lsProducts = _context.Products.AsNoTracking().Include(a=> a.Category).Where(x=> x.ProductName.Contains(keyword)).Take(5).ToList();
            if (lsProducts==null)
            {
                return PartialView("ListProductSearchPartial", null);
            }
            else
            {
                return PartialView("ListProductSearchPartial", lsProducts);
            }

        }
    }
}

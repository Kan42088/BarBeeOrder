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

        //Get: /Search/FindPage
        [HttpGet]
        public IActionResult FindPage(string keyword)
        {
            List<Page> lsPages = new List<Page>();
            if (string.IsNullOrEmpty(keyword) || keyword.Length < 1)
            {
                lsPages = _context.Pages.AsNoTracking().OrderByDescending(x => x.PageId).ToList();
                return PartialView("ListPageSearchPartial", lsPages);
            }

            lsPages = _context.Pages.AsNoTracking().Where(x => x.PageName.Contains(keyword)).ToList();
            if (lsPages == null)
            {
                return PartialView("ListPageSearchPartial", null);
            }
            else
            {
                return PartialView("ListPageSearchPartial", lsPages);
            }

        }
    }
}

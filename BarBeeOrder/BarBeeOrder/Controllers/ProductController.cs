using BarBeeOrder.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace BarBeeOrder.Controllers
{
    public class ProductController : Controller
    {

        private readonly BarBeeOrderContext _context;

        public ProductController(BarBeeOrderContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Page> pages = new List<Page>();
            pages = _context.Pages.AsNoTracking().Where(p => p.IsHeader == true && p.Published == true).OrderBy(x => x.Ordering).ToList();
            ViewData["MenuPages"] = pages;
            return View();
        }
        public IActionResult Details(int id)
        {
            List<Page> pages = new List<Page>();
            pages = _context.Pages.AsNoTracking().Where(p => p.IsHeader == true && p.Published == true).OrderBy(x => x.Ordering).ToList();
            ViewData["MenuPages"] = pages;
            var product = _context.Products.Include(x=>x.Category).FirstOrDefault(x=>x.ProductId == id);
            if (product == null)
            {
                return RedirectToAction("Index");
            }
            return View(product);
        }
    }
}

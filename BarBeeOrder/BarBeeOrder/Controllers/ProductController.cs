using BarBeeOrder.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            return View();
        }
        public IActionResult Details(int id)
        {
            var product = _context.Products.Include(x=>x.Category).FirstOrDefault(x=>x.ProductId == id);
            if (product == null)
            {
                return RedirectToAction("Index");
            }
            return View(product);
        }
    }
}

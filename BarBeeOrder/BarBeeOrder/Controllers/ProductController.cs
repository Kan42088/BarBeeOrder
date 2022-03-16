using BarBeeOrder.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PagedList.Core;
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

        [Route("cua-hang.html", Name = "Product")]
        public IActionResult Index(int? page)
        {
            List<Page> pages = new List<Page>();
            pages = _context.Pages.AsNoTracking().Where(p => p.IsHeader == true && p.Published == true).OrderBy(x => x.Ordering).ToList();
            ViewData["MenuPages"] = pages;
            try
            {
                var pageNumber = page ?? 1;
                var pageSize = 6; //Show 6 rows every time

                

                List<Product> lsProducts = new List<Product>();
                lsProducts = _context.Products.AsNoTracking().Where(x => x.Active == true && x.IsDelete == false).Include(p => p.Category).OrderByDescending(x => x.ProductId).ToList();
                PagedList<Product> models = new PagedList<Product>(lsProducts.AsQueryable(), pageNumber, pageSize);
                ViewBag.CurrentPage = pageNumber;

                return View(models);
            }
            catch
            {
                return RedirectToAction("Index", "Home");
            }
            
        }
        [Route("/{Alias}-{id}.html", Name = "ListProduct")]
        public IActionResult List(int id, int page=1)
        {
            List<Page> pages = new List<Page>();
            pages = _context.Pages.AsNoTracking().Where(p => p.IsHeader == true && p.Published == true).OrderBy(x => x.Ordering).ToList();
            ViewData["MenuPages"] = pages;
            try
            {
                var pageSize = 6; //Show 6 rows every time
                List<Product> lsProducts = new List<Product>();
                lsProducts = _context.Products.AsNoTracking().Where(x =>x.CategoryId==id && x.Active == true && x.IsDelete == false).Include(p => p.Category).OrderByDescending(x => x.CreatedDate).ToList();
                PagedList<Product> models = new PagedList<Product>(lsProducts.AsQueryable(), page, pageSize);
                ViewBag.CurrentPage = page;
                ViewBag.CurrentCat = _context.Categories.Find(id);
                return View(models);
            }
            catch
            {
                return RedirectToAction("Index", "Home");
            }
            
        }
        [Route("/{Alias}-{id}.html", Name = "ProductDetails")]
        public IActionResult Details(int id)
        {
            List<Page> pages = new List<Page>();
            pages = _context.Pages.AsNoTracking().Where(p => p.IsHeader == true && p.Published == true).OrderBy(x => x.Ordering).ToList();
            ViewData["MenuPages"] = pages;
            try
            {
                var product = _context.Products.Include(x => x.Category).FirstOrDefault(x => x.ProductId == id);
                if (product == null)
                {
                    return RedirectToAction("Index");
                }
                return View(product);
            }
            catch
            {
                return RedirectToAction("Index", "Home");
            }
            
            
        }
    }
}

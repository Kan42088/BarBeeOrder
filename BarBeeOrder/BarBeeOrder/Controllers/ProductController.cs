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
        public IActionResult Index(int? page,string? keyword)
        {
            List<Page> pages = new List<Page>();
            pages = _context.Pages.AsNoTracking().Where(p => p.IsHeader == true && p.Published == true).OrderBy(x => x.Ordering).ToList();
            ViewData["MenuPages"] = pages;
            List<Category> categories = new List<Category>();
            categories = _context.Categories.AsNoTracking().Where(c => c.IsDeleted == false && c.Published == true).OrderBy(x => x.Ordering).ToList();
            ViewData["MenuCategories"] = categories;

            try
            {
                var pageNumber = page ?? 1;
                var pageSize = 9; //Show 6 rows every time

                List<Product> lsProducts = new List<Product>();
                
                if (string.IsNullOrEmpty(keyword)){
                    lsProducts = _context.Products.AsNoTracking().Where(x => x.Active == true && x.IsDelete == false).Include(p => p.Category).OrderByDescending(x => x.ProductId).ToList();
                }
                else
                {
                    lsProducts = _context.Products.AsNoTracking().Where(x => x.Active == true && x.IsDelete == false && x.ProductName.Contains(keyword)).Include(p => p.Category).OrderByDescending(x => x.ProductId).ToList();
                }
                PagedList<Product> models = new PagedList<Product>(lsProducts.AsQueryable(), pageNumber, pageSize);
                
                ViewBag.CurrentPage = pageNumber;
                var lsBestSells = _context.Products.AsNoTracking().Where(x => x.BestSellers==true && x.IsDelete == false && x.Active == true).Take(4).ToList().OrderBy(x => x.CreatedDate).ToList();
                ViewBag.BestSells = lsBestSells;
                ViewBag.Keyword = keyword;
                return View(models);
            }
            catch
            {
                return RedirectToAction("Index", "Home");
            }

        }
        [Route("/cua-hang-{Alias}", Name = "ListProduct")]
        public IActionResult List(string alias, int page = 1)
        {
            List<Page> pages = new List<Page>();
            pages = _context.Pages.AsNoTracking().Where(p => p.IsHeader == true && p.Published == true).OrderBy(x => x.Ordering).ToList();
            ViewData["MenuPages"] = pages;
            List<Category> categories = new List<Category>();
            categories = _context.Categories.AsNoTracking().Where(c => c.IsDeleted == false && c.Published == true).OrderBy(x => x.Ordering).ToList();
            ViewData["MenuCategories"] = categories;

            try
            {
                var pageSize = 9; //Show 6 rows every time
                var danhmuc = _context.Categories.AsNoTracking().SingleOrDefault(x => x.Alias == alias);
                List<Product> lsProducts = new List<Product>();
                lsProducts = _context.Products.AsNoTracking().Where(x => x.CategoryId == danhmuc.CategoryId && x.Active == true && x.IsDelete == false).Include(p => p.Category).OrderByDescending(x => x.CreatedDate).ToList();
                PagedList<Product> models = new PagedList<Product>(lsProducts.AsQueryable(), page, pageSize);
                var lsBestSells = _context.Products.AsNoTracking().Where(x => x.BestSellers == true && x.IsDelete == false && x.Active == true).Take(4).ToList().OrderBy(x => x.CreatedDate).ToList();
                ViewBag.BestSells = lsBestSells;
                ViewBag.CurrentPage = page;
                ViewBag.CurrentCat = danhmuc;
                return View(models);
            }
            catch
            {
                return RedirectToAction("Index", "Home");
            }

        }


        [Route("/cua-hang/{Alias}-{id}.html", Name = "ProductDetails")]
        public IActionResult Details(int id)
        {
            List<Page> pages = new List<Page>();
            pages = _context.Pages.AsNoTracking().Where(p => p.IsHeader == true && p.Published == true).OrderBy(x => x.Ordering).ToList();
            ViewData["MenuPages"] = pages;
            List<Category> categories = new List<Category>();
            categories = _context.Categories.AsNoTracking().Where(c => c.IsDeleted == false && c.Published == true).OrderBy(x => x.Ordering).ToList();
            ViewData["MenuCategories"] = categories;

            try
            {
                var product = _context.Products.Include(x => x.Category).FirstOrDefault(x => x.ProductId == id);
                if (product == null)
                {
                    return RedirectToAction("Index");
                }

                var lsProducts = _context.Products.AsNoTracking().Where(x => x.CategoryId == product.CategoryId && x.ProductId != id && x.IsDelete == false && x.Active == true).Take(4).ToList().OrderBy(x=>x.CreatedDate).ToList();
                ViewBag.SanPham = lsProducts;

                return View(product);
            }
            catch
            {
                return RedirectToAction("Index", "Home");
            }


        }
    }
}

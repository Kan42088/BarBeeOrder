using BarBeeOrder.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BarBeeOrder.ModelView;

namespace BarBeeOrder.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly BarBeeOrderContext _context;
        public HomeController(ILogger<HomeController> logger, BarBeeOrderContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            try
            {
                List<Page> pages = new List<Page>();
                pages = _context.Pages.AsNoTracking().Where(p => p.IsHeader == true && p.Published == true).OrderBy(x => x.Ordering).ToList();
                ViewData["MenuPages"] = pages;
                List<Category> categories = new List<Category>();
                categories = _context.Categories.AsNoTracking().Where(c => c.IsDeleted == false && c.Published == true && c.Type==1).OrderBy(x => x.Ordering).ToList();
                ViewData["MenuCategories"] = categories;

                List<Post> newsfeeds = new List<Post>();
                newsfeeds = _context.Posts.AsNoTracking().Where(x => x.Published == true && x.IsDelete == false && x.IsNewfeed == true).Include(p => p.Customer).OrderByDescending(x => x.PostId).Take(3).ToList();
                ViewBag.NewsFeeds = newsfeeds;

                HomeVM model = new HomeVM();

                List<HomeProduct> homeProducts = new List<HomeProduct>();
                var lsProducts = _context.Products.AsNoTracking().Where(x => x.IsDelete == false && x.HomeFlag == true && x.Active == true).OrderBy(x => x.CreatedDate).ToList();
                var lsCategories = _context.Categories.AsNoTracking().Where(x => x.IsDeleted == false && x.Published == true && x.Type == 1).OrderBy(x => x.Ordering).Take(4).ToList();

                foreach (var item in lsCategories)
                {
                    HomeProduct homeProduct = new HomeProduct();
                    homeProduct.category = item;
                    homeProduct.products = lsProducts.Where(x => x.CategoryId == item.CategoryId).Take(8).ToList();
                    homeProducts.Add(homeProduct);
                }
                model.Products = homeProducts;
                ViewBag.AllProducts = lsProducts.Take(8).ToList();
                return View(model);
            }
            catch(Exception e)
            {
                return RedirectToAction("Error", "Home");
            }
            
        }
        public IActionResult Contact()
        {
            try
            {
                List<Page> pages = new List<Page>();
                pages = _context.Pages.AsNoTracking().Where(p => p.IsHeader == true && p.Published == true).OrderBy(x => x.Ordering).ToList();
                ViewData["MenuPages"] = pages;
                List<Category> categories = new List<Category>();
                categories = _context.Categories.AsNoTracking().Where(c => c.IsDeleted == false && c.Published == true).OrderBy(x => x.Ordering).ToList();
                ViewData["MenuCategories"] = categories;
                return View();
            }
            catch
            {
                return RedirectToAction("Error", "Error");
            }
            
        }
        public IActionResult About()
        {
            List<Page> pages = new List<Page>();
            pages = _context.Pages.AsNoTracking().Where(p => p.IsHeader == true && p.Published == true).OrderBy(x => x.Ordering).ToList();
            ViewData["MenuPages"] = pages;
            List<Category> categories = new List<Category>();
            categories = _context.Categories.AsNoTracking().Where(c => c.IsDeleted == false && c.Published == true).OrderBy(x => x.Ordering).ToList();
            ViewData["MenuCategories"] = categories;
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

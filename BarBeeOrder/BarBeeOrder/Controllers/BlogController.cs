using AspNetCoreHero.ToastNotification.Abstractions;
using BarBeeOrder.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PagedList.Core;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BarBeeOrder.Controllers
{
    public class BlogController : Controller
    {
        private readonly BarBeeOrderContext _context;

        public BlogController(BarBeeOrderContext context)
        {
            _context = context;
        }

        // GET: BlogController/Index
        [Route("tin-tuc.html", Name ="Blog")]
        public async Task<IActionResult> Index(int? page)
        {
            var pageNumber = page ?? 1;
            var pageSize = 6; //Show 5 rows every time

            List<Page> pages = new List<Page>();
            pages = _context.Pages.AsNoTracking().Where(p => p.IsHeader == true && p.Published == true).OrderBy(x => x.Ordering).ToList();
            ViewData["MenuPages"] = pages;
            List<Category> categories = new List<Category>();
            categories = _context.Categories.AsNoTracking().Where(c => c.IsDeleted == false && c.Published == true && c.Type == 1).OrderBy(x => x.Ordering).ToList();
            ViewData["MenuCategories"] = categories;

            List<Post> lsPosts = new List<Post>();
            lsPosts = _context.Posts.AsNoTracking().Where(x => x.Published == true && x.IsDelete ==false).Include(p => p.Customer).OrderByDescending(x => x.PostId).ToList();
            PagedList<Post> models = new PagedList<Post>(lsPosts.AsQueryable(), pageNumber, pageSize);
            
            ViewBag.CurrentPage = pageNumber;

            List<Post> newsfeeds = new List<Post>();
            newsfeeds = _context.Posts.AsNoTracking().Where(x => x.Published == true && x.IsDelete==false && x.IsHot==true).Include(p => p.Customer).OrderByDescending(x => x.PostId).Take(3).ToList();
            ViewBag.NewsFeeds = newsfeeds;
            return View(models);
        }

        // GET: BlogController/Details/5
        [Route("/tin-tuc/{Alias}-{id}.html", Name = "BlogDetails")] 
        public async Task<IActionResult> Details(int? id)
        {
            List<Page> pages = new List<Page>();
            pages = _context.Pages.AsNoTracking().Where(p => p.IsHeader == true && p.Published == true).OrderBy(x => x.Ordering).ToList();
            ViewData["MenuPages"] = pages;
            List<Category> categories = new List<Category>();
            categories = _context.Categories.AsNoTracking().Where(c => c.IsDeleted == false && c.Published == true).OrderBy(x => x.Ordering).ToList();
            ViewData["MenuCategories"] = categories;

            if (id == null)
            {
                return NotFound();
            }

            var post = await _context.Posts.AsNoTracking().SingleOrDefaultAsync(x=> x.PostId== id);
            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }
    }
}

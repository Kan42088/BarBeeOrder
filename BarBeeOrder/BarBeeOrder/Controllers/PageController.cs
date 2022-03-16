using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BarBeeOrder.Models;

namespace BarBeeOrder.Controllers
{
    public class PageController : Controller
    {
        private readonly BarBeeOrderContext _context;

        public PageController(BarBeeOrderContext context)
        {
            _context = context;
        }

        // GET: Page/Details/5
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

            var page = await _context.Pages
                .FirstOrDefaultAsync(m => m.PageId == id && m.Published==true);
            if (page == null)
            {
                return NotFound();
            }

            return View(page);
        }

        private bool PageExists(int id)
        {
            return _context.Pages.Any(e => e.PageId == id);
        }
    }
}

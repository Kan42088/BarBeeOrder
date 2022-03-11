using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BarBeeOrder.Models;
using PagedList.Core;
using AspNetCoreHero.ToastNotification.Abstractions;

namespace BarBeeOrder.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminPostsController : Controller
    {
        private readonly BarBeeOrderContext _context;
        public INotyfService _notyfService { get; }
        public AdminPostsController(BarBeeOrderContext context, INotyfService notyfService)
        {
            _context = context;
            _notyfService = notyfService;
        }

        public IActionResult Filter(int Published, int page = 1)
        {
            
            var url = $"/Admin/AdminPosts";
            if (Published != -1)
            {
                url = $"/Admin/AdminPosts?Published={Published}&page={page}";
            }

            
            return Json(new { published = "success", redirectUrl = url });
        }
        // GET: Admin/AdminPosts
        public async Task<IActionResult> Index(int? page,int Published=-1)
        {
            var pageNumber = page ?? 1;
            var pageSize = 5; //Show 5 rows every time

            List<SelectListItem> listStatus = new List<SelectListItem>();
            listStatus.Add(new SelectListItem() { Text = "Hoạt động", Value = "1", Selected = Published == 1? true : false });
            listStatus.Add(new SelectListItem() { Text = "Không hoạt động", Value = "0", Selected = Published == 0 ? true : false });
            ViewData["TrangThai"] = listStatus;

            List<Post> lsPosts = new List<Post>();
            if (Published == 1)
            {
                lsPosts = _context.Posts.AsNoTracking().Where(x => x.Published == true).Include(p => p.Account).OrderByDescending(x => x.PostId).ToList();
            }
            else if (Published == 0)
            {
                lsPosts = _context.Posts.AsNoTracking().Where(x => x.Published == false).Include(p => p.Account).OrderByDescending(x => x.PostId).ToList();
            }
            else
            {
                lsPosts = _context.Posts.AsNoTracking().Include(p => p.Account).OrderByDescending(x => x.PostId).ToList();
            }

            PagedList<Post> models = new PagedList<Post>(lsPosts.AsQueryable(), pageNumber, pageSize);
            ViewBag.CurrentStatus = Published;
            ViewBag.CurrentPage = pageNumber;
            return View(models);
        }

        // GET: Admin/AdminPosts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = await _context.Posts
                .Include(p => p.Account)
                .FirstOrDefaultAsync(m => m.PostId == id);
            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }

        // GET: Admin/AdminPosts/Create
        public IActionResult Create()
        {
            ViewData["AccountId"] = new SelectList(_context.Accounts, "AccountId", "AccountId");
            return View();
        }

        // POST: Admin/AdminPosts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PostId,Tittle,ShortContent,PostContent,Published,CreatedDate,Author,AccountId,CategoryId,IsHot")] Post post)
        {
            if (ModelState.IsValid)
            {
                _context.Add(post);
                await _context.SaveChangesAsync();
                _notyfService.Success("Tạo mới thành công!");
                return RedirectToAction(nameof(Index));
            }
            ViewData["AccountId"] = new SelectList(_context.Accounts, "AccountId", "AccountId", post.AccountId);
            return View(post);
        }

        // GET: Admin/AdminPosts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = await _context.Posts.FindAsync(id);
            if (post == null)
            {
                return NotFound();
            }
            ViewData["AccountId"] = new SelectList(_context.Accounts, "AccountId", "AccountId", post.AccountId);
            return View(post);
        }

        // POST: Admin/AdminPosts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PostId,Tittle,ShortContent,PostContent,Published,CreatedDate,Author,AccountId,CategoryId,IsHot")] Post post)
        {
            if (id != post.PostId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(post);
                    _notyfService.Success("Chỉnh sửa thành công!");
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PostExists(post.PostId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["AccountId"] = new SelectList(_context.Accounts, "AccountId", "AccountId", post.AccountId);
            return View(post);
        }

        // GET: Admin/AdminPosts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = await _context.Posts
                .Include(p => p.Account)
                .FirstOrDefaultAsync(m => m.PostId == id);
            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }

        // POST: Admin/AdminPosts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var post = await _context.Posts.FindAsync(id);
            _context.Posts.Remove(post);
            await _context.SaveChangesAsync();
            _notyfService.Warning("Xóa thành công!");
            return RedirectToAction(nameof(Index));
        }

        private bool PostExists(int id)
        {
            return _context.Posts.Any(e => e.PostId == id);
        }
    }
}

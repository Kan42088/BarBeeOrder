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
using BarBeeOrder.Helper;
using System.IO;
using Microsoft.AspNetCore.Http;

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
            var taikhoanID = HttpContext.Session.GetString("CustomerId");
            //Ctrl + K +U
            //for (int i = 0; i < 15; i++)
            //{
            //    Post post = new Post();
            //    post.CreatedDate = DateTime.Now;
            //    post.ModifiedDate = DateTime.Now;
            //    post.Alias = Utilities.SEOUrl("title " + i);
            //    post.CustomerId = Convert.ToInt32(taikhoanID);
            //    post.Published = true;
            //    post.PostContent = "noi dung bai viet" + i;
            //    post.ShortContent = "noi dung ngan" + i;
            //    post.Thumb = "default.jpg";
            //    post.Tittle = "title " + i;
            //    post.IsNewfeed = true;
            //    _context.Add(post);
            //    await _context.SaveChangesAsync();
            //}

            
            if (taikhoanID != null)
            {
                var khachhang = _context.Customers.AsNoTracking().SingleOrDefault(x => x.CustomerId == Convert.ToInt32(taikhoanID));
                if (khachhang != null)
                {
                    if (khachhang.RoleId == 2)
                    {
                        return RedirectToAction("Index", "Home", new { area = "" });
                    }
                    try
                    {
                        ViewData["Account"] = khachhang;
                        var pageNumber = page ?? 1;
                        var pageSize = 5; //Show 5 rows every time

                        List<SelectListItem> listStatus = new List<SelectListItem>();
                        listStatus.Add(new SelectListItem() { Text = "Hoạt động", Value = "1", Selected = Published == 1 ? true : false });
                        listStatus.Add(new SelectListItem() { Text = "Không hoạt động", Value = "0", Selected = Published == 0 ? true : false });
                        ViewData["TrangThai"] = listStatus;

                        List<Post> lsPosts = new List<Post>();
                        if (Published == 1)
                        {
                            lsPosts = _context.Posts.AsNoTracking().Where(x => x.Published == true && x.IsDelete == false).Include(p => p.Customer).OrderByDescending(x => x.PostId).ToList();
                        }
                        else if (Published == 0)
                        {
                            lsPosts = _context.Posts.AsNoTracking().Where(x => x.Published == false && x.IsDelete == false).Include(p => p.Customer).OrderByDescending(x => x.PostId).ToList();
                        }
                        else
                        {
                            lsPosts = _context.Posts.AsNoTracking().Where(x => x.IsDelete == false).Include(p => p.Customer).OrderByDescending(x => x.PostId).ToList();
                        }

                        PagedList<Post> models = new PagedList<Post>(lsPosts.AsQueryable(), pageNumber, pageSize);
                        ViewBag.CurrentStatus = Published;
                        ViewBag.CurrentPage = pageNumber;
                        return View(models);
                    }
                    catch
                    {
                        return RedirectToAction("Error", "Error", new { area = "" });
                    }
                   

                }
                return RedirectToAction("Index", "Home", new { area = "" });
            }
            else
            {
                return RedirectToAction("Index", "Home", new { area = "" });
            }
            
        }

        // GET: Admin/AdminPosts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var taikhoanID = HttpContext.Session.GetString("CustomerId");
            if (taikhoanID != null)
            {
                var khachhang = _context.Customers.AsNoTracking().SingleOrDefault(x => x.CustomerId == Convert.ToInt32(taikhoanID));
                if (khachhang != null)
                {
                    if (khachhang.RoleId == 2)
                    {
                        return RedirectToAction("Index", "Home", new { area = "" });
                    }
                    try
                    {
                        ViewData["Account"] = khachhang;
                        if (id == null)
                        {
                            return NotFound();
                        }

                        var post = await _context.Posts
                            .Include(p => p.Customer)
                            .FirstOrDefaultAsync(m => m.PostId == id);
                        if (post == null)
                        {
                            return NotFound();
                        }

                        return View(post);
                    }
                    catch
                    {
                        return RedirectToAction("Error", "Error", new { area = "" });
                    }
                   

                }
                return RedirectToAction("Index", "Home", new { area = "" });
            }
            else
            {
                return RedirectToAction("Index", "Home", new { area = "" });
            }


            
        }

        // GET: Admin/AdminPosts/Create
        public IActionResult Create()
        {
            var taikhoanID = HttpContext.Session.GetString("CustomerId");
            if (taikhoanID != null)
            {
                var khachhang = _context.Customers.AsNoTracking().SingleOrDefault(x => x.CustomerId == Convert.ToInt32(taikhoanID));
                if (khachhang != null)
                {
                    if (khachhang.RoleId == 2)
                    {
                        return RedirectToAction("Index", "Home", new { area = "" });
                    }
                    try
                    {
                        ViewData["Account"] = khachhang;
                        ViewData["AccountId"] = new SelectList(_context.Customers, "AccountId", "AccountId");
                        return View();
                    }
                    catch
                    {
                        return RedirectToAction("Error", "Error", new { area = "" });
                    }
                    

                }
                return RedirectToAction("Index", "Home", new { area = "" });
            }
            else
            {
                return RedirectToAction("Index", "Home", new { area = "" });
            }

           
        }

        // POST: Admin/AdminPosts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PostId,Tittle,ShortContent,PostContent,Published,CreatedDate,Author,AccountId,CategoryId,IsHot,Thumb,IsDelete,IsNewfeed")] Post post, Microsoft.AspNetCore.Http.IFormFile fThumb)
        {
            var taikhoanID = HttpContext.Session.GetString("CustomerId");
            if (taikhoanID != null)
            {
                var khachhang = _context.Customers.AsNoTracking().SingleOrDefault(x => x.CustomerId == Convert.ToInt32(taikhoanID));
                if (khachhang != null)
                {
                    if (khachhang.RoleId == 2)
                    {
                        return RedirectToAction("Index", "Home", new { area = "" });
                    }
                    try
                    {
                        ViewData["Account"] = khachhang;
                        if (ModelState.IsValid)
                        {
                            post.CustomerId = Convert.ToInt32(taikhoanID);
                            post.CreatedDate = DateTime.Now;
                            post.IsDelete = false;
                            post.Alias = Utilities.SEOUrl(post.Tittle);
                            if (fThumb != null)
                            {
                                string extension = Path.GetExtension(fThumb.FileName);
                                string image = Utilities.SEOUrl(post.Tittle) + extension;
                                post.Thumb = await Utilities.UploadFile(fThumb, @"posts", image.ToLower());
                            }
                            if (string.IsNullOrEmpty(post.Thumb))
                            {
                                post.Thumb = "default.jpg";
                            }
                            _context.Add(post);
                            await _context.SaveChangesAsync();
                            _notyfService.Success("Tạo mới thành công!");
                            return RedirectToAction(nameof(Index));
                        }
                        ViewData["AccountId"] = new SelectList(_context.Customers, "AccountId", "AccountId", post.CustomerId);
                        return View(post);
                    }
                    catch
                    {
                        return RedirectToAction("Error", "Error", new { area = "" });
                    }
                    


                }
                return RedirectToAction("Index", "Home", new { area = "" });
            }
            else
            {
                return RedirectToAction("Index", "Home", new { area = "" });
            }

            
        }

        // GET: Admin/AdminPosts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var taikhoanID = HttpContext.Session.GetString("CustomerId");
            if (taikhoanID != null)
            {
                var khachhang = _context.Customers.AsNoTracking().SingleOrDefault(x => x.CustomerId == Convert.ToInt32(taikhoanID));
                if (khachhang != null)
                {
                    if (khachhang.RoleId == 2)
                    {
                        return RedirectToAction("Index", "Home", new { area = "" });
                    }
                    try
                    {
                        ViewData["Account"] = khachhang;
                        if (id == null)
                        {
                            return NotFound();
                        }

                        var post = await _context.Posts.FindAsync(id);
                        if (post == null)
                        {
                            return NotFound();
                        }
                        ViewData["AccountId"] = new SelectList(_context.Customers, "AccountId", "AccountId", post.CustomerId);
                        return View(post);
                    }
                    catch
                    {
                        return RedirectToAction("Error", "Error", new { area = "" });
                    }
                    

                }
                return RedirectToAction("Index", "Home", new { area = "" });
            }
            else
            {
                return RedirectToAction("Index", "Home", new { area = "" });
            }


            
        }

        // POST: Admin/AdminPosts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PostId,Tittle,ShortContent,PostContent,Published,CreatedDate,Author,AccountId,CategoryId,IsHot,Thumb,IsDelete,IsNewfeed")] Post post, Microsoft.AspNetCore.Http.IFormFile fThumb)
        {
            var taikhoanID = HttpContext.Session.GetString("CustomerId");
            if (taikhoanID != null)
            {
                var khachhang = _context.Customers.AsNoTracking().SingleOrDefault(x => x.CustomerId == Convert.ToInt32(taikhoanID));
                if (khachhang != null)
                {
                    if (khachhang.RoleId == 2)
                    {
                        return RedirectToAction("Index", "Home", new { area = "" });
                    }
                    try
                    {
                        ViewData["Account"] = khachhang;
                        if (id != post.PostId)
                        {
                            return NotFound();
                        }

                        if (ModelState.IsValid)
                        {
                            if (fThumb != null)
                            {
                                string extension = Path.GetExtension(fThumb.FileName);
                                string image = Utilities.SEOUrl(post.Tittle) + extension;
                                post.Thumb = await Utilities.UploadFile(fThumb, @"posts", image.ToLower());
                            }
                            if (string.IsNullOrEmpty(post.Thumb))
                            {
                                post.Thumb = "default.jpg";
                            }
                            post.CustomerId = Convert.ToInt32(taikhoanID);
                            post.Alias = Utilities.SEOUrl(post.Tittle);
                            try
                            {
                                _context.Update(post);
                                await _context.SaveChangesAsync();
                                _notyfService.Success("Chỉnh sửa thành công!");
                            }
                            catch (DbUpdateConcurrencyException)
                            {
                                if (!PostExists(post.PostId))
                                {
                                    return RedirectToAction("Error", "Error", new { area = "" });
                                }
                                else
                                {
                                    return RedirectToAction("Error", "Error", new { area = "" });
                                }
                            }
                            return RedirectToAction(nameof(Index));
                        }
                        ViewData["AccountId"] = new SelectList(_context.Customers, "AccountId", "AccountId", post.CustomerId);
                        return View(post);
                    }
                    catch
                    {
                        return RedirectToAction("Error", "Error", new { area = "" });
                    }
                    

                }
                return RedirectToAction("Index", "Home", new { area = "" });
            }
            else
            {
                return RedirectToAction("Index", "Home", new { area = "" });
            }


            
        }

        // GET: Admin/AdminPosts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var taikhoanID = HttpContext.Session.GetString("CustomerId");
            if (taikhoanID != null)
            {
                var khachhang = _context.Customers.AsNoTracking().SingleOrDefault(x => x.CustomerId == Convert.ToInt32(taikhoanID));
                if (khachhang != null)
                {
                    if (khachhang.RoleId == 2)
                    {
                        return RedirectToAction("Index", "Home", new { area = "" });
                    }
                    try
                    {
                        ViewData["Account"] = khachhang;
                        if (id == null)
                        {
                            return NotFound();
                        }

                        var post = await _context.Posts
                            .Include(p => p.Customer)
                            .FirstOrDefaultAsync(m => m.PostId == id);
                        if (post == null)
                        {
                            return NotFound();
                        }

                        return View(post);
                    }
                    catch
                    {
                        return RedirectToAction("Error", "Error", new { area = "" });
                    }
                   

                }
                return RedirectToAction("Index", "Home", new { area = "" });
            }
            else
            {
                return RedirectToAction("Index", "Home", new { area = "" });
            }

            
        }

        // POST: Admin/AdminPosts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var taikhoanID = HttpContext.Session.GetString("CustomerId");
            if (taikhoanID != null)
            {
                var khachhang = _context.Customers.AsNoTracking().SingleOrDefault(x => x.CustomerId == Convert.ToInt32(taikhoanID));
                if (khachhang != null)
                {
                    if (khachhang.RoleId == 2)
                    {
                        return RedirectToAction("Index", "Home", new { area = "" });
                    }
                    try
                    {
                        ViewData["Account"] = khachhang;
                        var post = await _context.Posts.FindAsync(id);
                        post.IsDelete = true;
                        _context.Posts.Update(post);
                        await _context.SaveChangesAsync();
                        _notyfService.Warning("Xóa thành công!");
                        return RedirectToAction(nameof(Index));

                    }
                    catch
                    {
                        return RedirectToAction("Error", "Error", new { area = "" });
                    }
                    

                }
                return RedirectToAction("Index", "Home", new { area = "" });
            }
            else
            {
                return RedirectToAction("Index", "Home", new { area = "" });
            }

            
        }

        private bool PostExists(int id)
        {
            return _context.Posts.Any(e => e.PostId == id);
        }
    }
}

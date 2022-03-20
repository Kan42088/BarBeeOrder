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
using System.IO;
using BarBeeOrder.Helper;
using Microsoft.AspNetCore.Http;

namespace BarBeeOrder.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminCategoriesController : Controller
    {
        private readonly BarBeeOrderContext _context;
        public INotyfService _notyfService { get; }
        public AdminCategoriesController(BarBeeOrderContext context, INotyfService notyfService)
        {
            _context = context;
            _notyfService = notyfService;
        }

        // GET: Admin/AdminCategories
        public async Task<IActionResult> Index(int? page)
        {
            //var taikhoanID = HttpContext.Session.GetString("CustomerId");
            //if (taikhoanID != null)
            //{
            //    var khachhang = _context.Customers.AsNoTracking().SingleOrDefault(x => x.CustomerId == Convert.ToInt32(taikhoanID));
            //    if (khachhang != null)
            //    {
            //        if (khachhang.RoleId == 2)
            //        {
            //            return RedirectToAction("Index", "Home", new { area = "" });
            //        }



            //    }
            //    return RedirectToAction("Index", "Home", new { area = "" });
            //}
            //else
            //{
            //    return RedirectToAction("Index", "Home", new { area = "" });
            //}
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
                        var pageNumber = page ?? 1;
                        var pageSize = 5; //Show 10 rows every time

                        List<SelectListItem> listStatus = new List<SelectListItem>();
                        listStatus.Add(new SelectListItem() { Text = "Hoạt động", Value = "1" });
                        listStatus.Add(new SelectListItem() { Text = "Không hoạt động", Value = "0" });
                        ViewData["TrangThai"] = listStatus;

                        List<Category> lsCategories = new List<Category>();
                        lsCategories = _context.Categories.AsNoTracking().Where(x => x.IsDeleted == false && x.Type == 1).OrderByDescending(x => x.CategoryId).ToList();
                        PagedList<Category> models = new PagedList<Category>(lsCategories.AsQueryable(), pageNumber, pageSize);
                        ViewBag.CurrentPage = pageNumber;
                        ViewData["Account"] = khachhang;
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

        // GET: Admin/AdminCategories/Details/5
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
                        if (id == null)
                        {
                            return NotFound();
                        }

                        var category = await _context.Categories
                            .FirstOrDefaultAsync(m => m.CategoryId == id);
                        if (category == null)
                        {
                            return NotFound();
                        }
                        ViewData["Account"] = khachhang;
                        return View(category);
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

        // GET: Admin/AdminCategories/Create
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
            //////////
            
        }

        // POST: Admin/AdminCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CategoryId,Name,Description,ParrentId,Levels,Ordering,Published,Title,Cover,Type,IsDeleted,Thumb")] Category category, Microsoft.AspNetCore.Http.IFormFile fThumb)
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
                            category.Type = 1;
                            if (fThumb != null)
                            {
                                string extension = Path.GetExtension(fThumb.FileName);
                                string image = Utilities.SEOUrl(category.Name) + extension;
                                category.Thumb = await Utilities.UploadFile(fThumb, @"categories", image.ToLower());
                            }
                            if (string.IsNullOrEmpty(category.Thumb))
                            {
                                category.Thumb = "default.jpg";
                            }
                            _context.Add(category);
                            await _context.SaveChangesAsync();
                            _notyfService.Success("Tạo mới thành công!");
                            return RedirectToAction(nameof(Index));
                        }
                        return View(category);
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
            //////////
            
        }

        // GET: Admin/AdminCategories/Edit/5
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

                        var category = await _context.Categories.FindAsync(id);
                        if (category == null)
                        {
                            return NotFound();
                        }
                        return View(category);
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
            //////////
            
        }

        // POST: Admin/AdminCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CategoryId,Name,Description,ParrentId,Levels,Ordering,Published,Title,Cover,Type,IsDeleted,Thumb")] Category category, Microsoft.AspNetCore.Http.IFormFile fThumb)
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
                        if (id != category.CategoryId)
                        {
                            return NotFound();
                        }

                        if (ModelState.IsValid)
                        {
                            try
                            {
                                if (fThumb != null)
                                {
                                    string extension = Path.GetExtension(fThumb.FileName);
                                    string image = Utilities.SEOUrl(category.Name) + extension;
                                    category.Thumb = await Utilities.UploadFile(fThumb, @"categories", image.ToLower());
                                }
                                if (string.IsNullOrEmpty(category.Thumb))
                                {
                                    category.Thumb = "default.jpg";
                                }
                                _context.Update(category);
                                _notyfService.Success("Chỉnh sửa thành công!");
                                await _context.SaveChangesAsync();
                            }
                            catch (DbUpdateConcurrencyException)
                            {
                                if (!CategoryExists(category.CategoryId))
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
                        return View(category);
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
            //////////
            
        }

        // GET: Admin/AdminCategories/Delete/5
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

                        var category = await _context.Categories
                            .FirstOrDefaultAsync(m => m.CategoryId == id);
                        if (category == null)
                        {
                            return NotFound();
                        }

                        return View(category);

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
            //////////
            
        }

        // POST: Admin/AdminCategories/Delete/5
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
                        var category = await _context.Categories.FindAsync(id);
                        category.IsDeleted = true;
                        _context.Categories.Remove(category);
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
            //////////
            
        }

        private bool CategoryExists(int id)
        {
            return _context.Categories.Any(e => e.CategoryId == id);
        }
    }
}

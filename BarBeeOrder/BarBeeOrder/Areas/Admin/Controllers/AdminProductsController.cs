using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BarBeeOrder.Models;
using PagedList.Core;
using BarBeeOrder.Helper;
using System.IO;
using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Http;

namespace BarBeeOrder.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminProductsController : Controller
    {
        private readonly BarBeeOrderContext _context;
        public INotyfService _notyfService { get; }
        public AdminProductsController(BarBeeOrderContext context, INotyfService notyfService)
        {
            _context = context;
            _notyfService = notyfService;
        }


        // GET:  Admin/AdminProducts/Filter
        public IActionResult Filter(int CatID = 0, int page = 1)
        {

            var url = $"/Admin/AdminProducts?CatID={CatID}&page={page}";
            if (CatID == 0)
            {
                url = $"/Admin/AdminProducts";
            }
            else
            {
                if (true)
                {
                }
            }

            return Json(new { status = "success", redirectUrl = url });
        }

        // GET: Admin/AdminProducts
        public async Task<IActionResult> Index(int? page, int CatID = 0)
        {
            //for (int i = 0; i < 10; i++)
            //{
            //    Product product = new Product();
            //    product.ProductName = "Quả " + i;
            //    product.Alias = Utilities.SEOUrl("Quả " + i);
            //    product.Thumb = "default.jpg";
            //    product.Price = i * 10000;
            //    product.IsDelete = false;
            //    product.Active = true;
            //    product.HomeFlag = true;
            //    product.BestSellers = true;
            //    product.CategoryId = 1;
            //    product.CreatedDate = DateTime.Now;
            //    _context.Add(product);
            //    Product product2 = new Product();
            //    product2.ProductName = "Gạo" + i;
            //    product2.Alias = Utilities.SEOUrl("Gạo" + i);
            //    product2.Thumb = "default.jpg";
            //    product2.Price = i * 10000;
            //    product2.IsDelete = false;
            //    product2.Active = true;
            //    product2.HomeFlag = true;
            //    product2.BestSellers = true;
            //    product2.CategoryId = 2;
            //    product2.CreatedDate = DateTime.Now;
            //    _context.Add(product2);
            //    await _context.SaveChangesAsync();
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
                        ViewData["Account"] = khachhang;
                        var pageNumber = page ?? 1;
                        var pageSize = 5; //Show 5 rows every time

                        List<Product> lsProducts = new List<Product>();
                        if (CatID != 0)
                        {
                            lsProducts = _context.Products.AsNoTracking().Where(x => x.CategoryId == CatID && x.IsDelete == false).Include(c => c.Category).Include(ap => ap.AttributePrices).OrderByDescending(x => x.ProductId).ToList();
                        }
                        else
                        {
                            lsProducts = _context.Products.AsNoTracking().Where(x => x.IsDelete == false).Include(c => c.Category).Include(ap => ap.AttributePrices).OrderByDescending(x => x.ProductId).ToList();
                        }

                        PagedList<Product> models = new PagedList<Product>(lsProducts.AsQueryable(), pageNumber, pageSize);
                        ViewBag.CurrentCateID = CatID;
                        ViewBag.CurrentPage = pageNumber;
                        ViewData["DanhMuc"] = new SelectList(_context.Categories.Where(x => x.IsDeleted == false && x.Type == 1), "CategoryId", "Name", CatID);

                        //var models = lsProducts.AsQueryable().ToPagedList(pageNumber, pageSize);

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

        // GET: Admin/AdminProducts/Details/5
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

                        var product = await _context.Products
                            .Include(p => p.Category)
                            .FirstOrDefaultAsync(m => m.ProductId == id);
                        if (product == null)
                        {
                            return NotFound();
                        }

                        return View(product);
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

        // GET: Admin/AdminProducts/Create
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
                        ViewData["DanhMuc"] = new SelectList(_context.Categories.AsNoTracking().Where(x=> x.IsDeleted==false), "CategoryId", "Name");
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

        // POST: Admin/AdminProducts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductId,ProductName,ShortDescription,CategoryId,Description,Price,Discount,Video,CreatedDate,ModifiedDate,Tittle,BestSellers,Active,HomeFlag")] Product product, Microsoft.AspNetCore.Http.IFormFile fThumb)
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
                            product.ProductName = Utilities.ToTitleCase(product.ProductName);
                            product.Alias = Utilities.SEOUrl(product.ProductName);
                            if (fThumb != null)
                            {
                                string extension = Path.GetExtension(fThumb.FileName);
                                string image = Utilities.SEOUrl(product.ProductName) + extension;
                                product.Thumb = await Utilities.UploadFile(fThumb, @"products", image.ToLower());
                            }
                            if (string.IsNullOrEmpty(product.Thumb))
                            {
                                product.Thumb = "default.jpg";
                            }
                            product.ModifiedDate = DateTime.Now;
                            product.CreatedDate = DateTime.Now;

                            _context.Add(product);
                            await _context.SaveChangesAsync();
                            _notyfService.Success("Tạo mới thành công!");
                            return RedirectToAction(nameof(Index));
                        }
                        ViewData["DanhMuc"] = new SelectList(_context.Categories.Where(x=> x.IsDeleted == false && x.Type==1), "CategoryId", "Name", product.CategoryId);
                        return View(product);
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

        // GET: Admin/AdminProducts/Edit/5
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

                        var product = await _context.Products.FindAsync(id);
                        if (product == null)
                        {
                            return NotFound();
                        }
                        ViewData["DanhMuc"] = new SelectList(_context.Categories.AsNoTracking().Where(x => x.IsDeleted == false), "CategoryId", "Name", product.CategoryId);
                        return View(product);
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

        // POST: Admin/AdminProducts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductId,ProductName,ShortDescription,CategoryId,Description,Price,Discount,Video,CreatedDate,ModifiedDate,Tittle,BestSellers,Active,HomeFlag")] Product product, Microsoft.AspNetCore.Http.IFormFile fThumb)
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
                        if (id != product.ProductId)
                        {
                            return NotFound();
                        }

                        if (ModelState.IsValid)
                        {
                            try
                            {
                                product.ProductName = Utilities.ToTitleCase(product.ProductName);
                                product.Alias = Utilities.SEOUrl(product.ProductName);
                                if (fThumb != null)
                                {
                                    string extension = Path.GetExtension(fThumb.FileName);
                                    string image = Utilities.SEOUrl(product.ProductName) + extension;
                                    product.Thumb = await Utilities.UploadFile(fThumb, @"products", image.ToLower());
                                }
                                if (string.IsNullOrEmpty(product.Thumb))
                                {
                                    product.Thumb = "default.png";
                                }
                                product.ModifiedDate = DateTime.Now;

                                _context.Update(product);
                                _notyfService.Success("Chỉnh sửa thành công!");
                                await _context.SaveChangesAsync();
                            }
                            catch (DbUpdateConcurrencyException)
                            {
                                if (!ProductExists(product.ProductId))
                                {
                                    _notyfService.Error("Chỉnh sửa thất bại!");
                                    return NotFound();
                                }
                                else
                                {
                                    throw;
                                }
                            }
                            return RedirectToAction(nameof(Index));
                        }
                        ViewData["DanhMuc"] = new SelectList(_context.Categories, "CategoryId", "Name", product.CategoryId);
                        return View(product);
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

        // GET: Admin/AdminProducts/Delete/5
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

                        var product = await _context.Products
                            .Include(p => p.Category)
                            .FirstOrDefaultAsync(m => m.ProductId == id);
                        if (product == null)
                        {
                            return NotFound();
                        }

                        return View(product);
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

        // POST: Admin/AdminProducts/Delete/5
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
                        var product = await _context.Products.FindAsync(id);
                        product.IsDelete = true;
                        _context.Products.Update(product);
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

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.ProductId == id);
        }
    }
}

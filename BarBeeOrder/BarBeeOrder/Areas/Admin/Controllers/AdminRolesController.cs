using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BarBeeOrder.Models;
using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace BarBeeOrder.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminRolesController : Controller
    {
        private readonly BarBeeOrderContext _context;
        public INotyfService _notyfService { get;}
        public AdminRolesController(BarBeeOrderContext context, INotyfService notyfService)
        {
            _context = context;
            _notyfService = notyfService;
        }

        // GET: Admin/AdminRoles
        public async Task<IActionResult> Index()
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
                        return View(await _context.Roles.ToListAsync());
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

        // GET: Admin/AdminRoles/Details/5
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

                        var role = await _context.Roles
                            .FirstOrDefaultAsync(m => m.RoleId == id);
                        if (role == null)
                        {
                            return NotFound();
                        }

                        return View(role);
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

        // GET: Admin/AdminRoles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/AdminRoles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RoleId,RoleName,Description")] Role role)
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
                            _context.Add(role);
                            await _context.SaveChangesAsync();
                            _notyfService.Success("Tạo mới thành công!");
                            return RedirectToAction(nameof(Index));
                        }
                        return View(role);
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

        // GET: Admin/AdminRoles/Edit/5
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

                        var role = await _context.Roles.FindAsync(id);
                        if (role == null)
                        {
                            return NotFound();
                        }
                        return View(role);
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

        // POST: Admin/AdminRoles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RoleId,RoleName,Description")] Role role)
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
                        if (id != role.RoleId)
                        {
                            return NotFound();
                        }

                        if (ModelState.IsValid)
                        {
                            try
                            {
                                _context.Update(role);
                                _notyfService.Success("Chỉnh sửa thành công!");
                                await _context.SaveChangesAsync();
                            }
                            catch (DbUpdateConcurrencyException)
                            {
                                if (!RoleExists(role.RoleId))
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
                        return View(role);
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

        // GET: Admin/AdminRoles/Delete/5
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

                        var role = await _context.Roles
                            .FirstOrDefaultAsync(m => m.RoleId == id);
                        if (role == null)
                        {
                            return NotFound();
                        }

                        return View(role);
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

        // POST: Admin/AdminRoles/Delete/5
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
                        var role = await _context.Roles.FindAsync(id);
                        _context.Roles.Remove(role);
                        await _context.SaveChangesAsync();
                        _notyfService.Warning("Xoá thành công!");
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

        private bool RoleExists(int id)
        {
            return _context.Roles.Any(e => e.RoleId == id);
        }
    }
}

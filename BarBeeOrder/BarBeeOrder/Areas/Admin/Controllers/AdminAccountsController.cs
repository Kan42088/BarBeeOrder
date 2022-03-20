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
using BarBeeOrder.Extension;
using Microsoft.AspNetCore.Http;

namespace BarBeeOrder.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminAccountsController : Controller
    {
        private readonly BarBeeOrderContext _context;
        public INotyfService _notyfService { get; }
        public AdminAccountsController(BarBeeOrderContext context, INotyfService notyfService)
        {
            _context = context;
            _notyfService = notyfService;
        }

        // GET: Admin/AdminAccounts
        public async Task<IActionResult> Index(int? page, int RolesID = 0)
        {
            var taikhoanID = HttpContext.Session.GetString("CustomerId");
            if (taikhoanID != null)
            {
                var khachhang = _context.Customers.AsNoTracking().SingleOrDefault(x => x.CustomerId == Convert.ToInt32(taikhoanID));
                if (khachhang != null)
                {
                    if (khachhang.RoleId == 2)
                    {
                        return RedirectToAction("Index", "Home", new {area = ""});
                    }
                    try
                    {
                        ViewData["QuyenTruyCap"] = new SelectList(_context.Roles, "RoleId", "RoleName");

                        List<SelectListItem> listStatus = new List<SelectListItem>();
                        listStatus.Add(new SelectListItem() { Text = "Hoạt động", Value = "1" });
                        listStatus.Add(new SelectListItem() { Text = "Không hoạt động", Value = "0" });
                        ViewData["TrangThai"] = listStatus;

                        var pageNumber = page ?? 1;
                        var pageSize = 5; //Show 5 rows every time

                        List<Customer> lsAccounts = new List<Customer>();
                        if (RolesID != 0)
                        {
                            lsAccounts = _context.Customers.AsNoTracking()
                                .Where(x => x.RoleId == RolesID && x.IsDeteted == false)
                                .Include(c => c.Role)
                                .OrderByDescending(x => x.CustomerId)
                                .ToList();
                        }
                        else
                        {
                            lsAccounts = _context.Customers.AsNoTracking().Where(x => x.IsDeteted == false).Include(c => c.Role).OrderByDescending(x => x.CustomerId).ToList();
                        }

                        PagedList<Customer> models = new PagedList<Customer>(lsAccounts.AsQueryable(), pageNumber, pageSize);
                        ViewBag.CurrentRoleID = RolesID;
                        ViewBag.CurrentPage = pageNumber;

                        //var models = _context.Accounts.Include(a => a.Roll).ToPagedList(pageNumber,pageSize);
                        return View(models);
                    }
                    catch
                    {
                        return RedirectToAction("Error", "Error", new { area = "" });
                    }
                    


                }
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

            
        }

        // GET: Admin/AdminAccounts/Details/5
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

                        var account = await _context.Customers
                            .Include(a => a.Role)
                            .FirstOrDefaultAsync(m => m.CustomerId == id);
                        if (account == null)
                        {
                            return NotFound();
                        }

                        return View(account);
                    }
                    catch
                    {
                        return RedirectToAction("Error", "Error", new { area = "" });
                    }
                    

                }
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
            /////////////

        }

        // GET: Admin/AdminAccounts/Create
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
                        ViewData["RollId"] = new SelectList(_context.Roles, "RoleId", "RoleName");
                        ViewBag.RollId = new SelectList(_context.Roles, "RoleId", "RoleName");
                        return View();
                    }
                    catch
                    {
                        return RedirectToAction("Error", "Error", new { area = "" });
                    }
                   

                }
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
            /////////////
            
        }

        // POST: Admin/AdminAccounts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AccountId,Email,Password,Phone,Status,Fullname,RollId,CreatedDate,LastLogin")] Account account)
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
                        if (ModelState.IsValid)
                        {
                            account.CreatedDate = DateTime.Now;
                            account.IsDelete = false;
                            _context.Add(account);
                            await _context.SaveChangesAsync();
                            _notyfService.Success("Tạo tài khoản thành công!");
                            return RedirectToAction(nameof(Index));
                        }
                        ViewData["RollId"] = new SelectList(_context.Roles, "RoleId", "RoleId", account.RollId);
                        return View(account);
                    }
                    catch
                    {
                        return RedirectToAction("Error", "Error", new { area = "" });
                    }
                    


                }
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
            /////////////
            
        }

        // GET: Admin/AdminAccounts/Edit/5
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
                        if (id == null)
                        {
                            return NotFound();
                        }

                        var account = await _context.Customers.FindAsync(id);
                        if (account == null)
                        {
                            return NotFound();
                        }
                        ViewData["RollId"] = new SelectList(_context.Roles, "RoleId", "RoleId", account.RoleId);
                        return View(account);
                    }
                    catch
                    {
                        return RedirectToAction("Error", "Error", new { area = "" });
                    }
                   


                }
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
            
        }

        // POST: Admin/AdminAccounts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AccountId,Email,Password,Phone,Status,Fullname,RollId,CreatedDate,LastLogin")] Account account)
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
                        if (id != account.AccountId)
                        {
                            return NotFound();
                        }

                        if (ModelState.IsValid)
                        {
                            try
                            {
                                _context.Update(account);
                                _notyfService.Success("Cập nhật thành công!");
                                await _context.SaveChangesAsync();
                            }
                            catch (DbUpdateConcurrencyException)
                            {
                                if (!AccountExists(account.AccountId))
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
                        ViewData["RollId"] = new SelectList(_context.Roles, "RoleId", "RoleId", account.RollId);
                        return View(account);
                    }
                    catch
                    {
                        return RedirectToAction("Error", "Error", new { area = "" });
                    }
                    

                }
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
            /////////////
            
        }

        // GET: Admin/AdminAccounts/Delete/5
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
                        if (id == null)
                        {
                            return NotFound();
                        }

                        var account = await _context.Customers
                            .Include(a => a.Role)
                            .FirstOrDefaultAsync(m => m.CustomerId == id);
                        if (account == null)
                        {
                            return NotFound();
                        }

                        return View(account);
                    }
                    catch
                    {
                        return RedirectToAction("Error", "Error", new { area = "" });
                    }
                    


                }
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
            /////////////
            
        }

        // POST: Admin/AdminAccounts/Delete/5
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
                        var account = await _context.Customers.FindAsync(id);
                        account.IsDeteted = true;
                        _context.Update(account);
                        await _context.SaveChangesAsync();
                        _notyfService.Warning("Đã xóa tài khoản!");
                        return RedirectToAction(nameof(Index));
                    }
                    catch
                    {
                        return RedirectToAction("Error", "Error", new { area = "" });
                    }
                    

                }
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
            /////////////
            
        }

        private bool AccountExists(int id)
        {
            return _context.Customers.Any(e => e.CustomerId == id);
        }
    }
}

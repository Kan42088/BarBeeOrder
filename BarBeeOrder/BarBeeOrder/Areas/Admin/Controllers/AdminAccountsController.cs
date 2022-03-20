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
using BarBeeOrder.Helper;

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
                        List<SelectListItem> listRoles = new List<SelectListItem>();
                        listRoles.Add(new SelectListItem() { Text = "Admin", Value = "1" });
                        listRoles.Add(new SelectListItem() { Text = "Nhân viên", Value = "3" });
                        ViewData["QuyenTruyCap"] = listRoles;

                        List<SelectListItem> listStatus = new List<SelectListItem>();
                        listStatus.Add(new SelectListItem() { Text = "Hoạt động", Value = "1" });
                        listStatus.Add(new SelectListItem() { Text = "Không hoạt động", Value = "0" });
                        ViewData["TrangThai"] = listStatus;

                        var pageNumber = page ?? 1;
                        var pageSize = 5; //Show 5 rows every time

                        List<Customer> lsAccounts = new List<Customer>();
                        if (RolesID != 0 && RolesID!= 2)
                        {
                            lsAccounts = _context.Customers.AsNoTracking()
                                .Where(x => x.RoleId == RolesID && x.IsDeteted == false)
                                .Include(c => c.Role)
                                .OrderByDescending(x => x.CustomerId)
                                .ToList();
                        }
                        else if(RolesID != 2)
                        {
                            lsAccounts = _context.Customers.AsNoTracking().Where(x => x.IsDeteted == false && x.RoleId != 2).Include(c => c.Role).OrderByDescending(x => x.CustomerId).ToList();
                        }
                        else{
                            return RedirectToAction("Error", "Error", new { area = "" });
                        }

                        PagedList<Customer> models = new PagedList<Customer>(lsAccounts.AsQueryable(), pageNumber, pageSize);
                        ViewBag.CurrentRoleID = RolesID;
                        ViewBag.CurrentPage = pageNumber;
                        ViewData["Account"] = khachhang;
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
                        ViewData["Account"] = khachhang;
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
                        ViewData["Account"] = khachhang;
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
        public async Task<IActionResult> Create([Bind("AccountId,Email,Password,Phone,Status,Fullname,RollId,CreatedDate,LastLogin")] Customer account)
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
                            string salt = Utilities.GetRandomKey();
                            account.Password = (account.Password + salt.Trim()).ToMD5();
                            account.CreatedDate = DateTime.Now;
                            account.IsDeteted = false;
                            _context.Add(account);
                            await _context.SaveChangesAsync();
                            _notyfService.Success("Tạo tài khoản thành công!");
                            return RedirectToAction(nameof(Index));
                        }
                        ViewData["Account"] = khachhang;
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
                        ViewData["Account"] = khachhang;
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
        public async Task<IActionResult> Edit(int id, [Bind("AccountId,Email,Password,Phone,Status,Fullname,RollId,CreatedDate,LastLogin")] Customer account)
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
                        if (id != account.CustomerId)
                        {
                            return NotFound();
                        }

                        if (ModelState.IsValid)
                        {
                            try
                            {
                                account.Password = (account.Password.Trim() + account.Salt.Trim()).ToMD5();
                                _context.Update(account);
                                _notyfService.Success("Cập nhật thành công!");
                                await _context.SaveChangesAsync();
                                ViewData["Account"] = khachhang;
                            }
                            catch (DbUpdateConcurrencyException)
                            {
                                if (!AccountExists(account.CustomerId))
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
                        ViewData["Account"] = khachhang;
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
                        ViewData["Account"] = khachhang;
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

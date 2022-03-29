using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BarBeeOrder.Models;

using Microsoft.AspNetCore.Http;
using PagedList.Core;
using BarBeeOrder.Extension;
using AspNetCoreHero.ToastNotification.Abstractions;

namespace BarBeeOrder.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminCustomersController : Controller
    {
        private readonly BarBeeOrderContext _context;
        public INotyfService _notyfService { get; }
        public AdminCustomersController(BarBeeOrderContext context, INotyfService notyfService)
        {
            _context = context;
            _notyfService = notyfService;

        }

        // GET: Admin/AdminCustomers
        public IActionResult Index(int? page)
        {
            //var pageNumber = page == null || page <= 0 ? 1 : page.Value;
            //var pageSize = 20;
            //var listCustomers = _context.Customers.AsNoTracking().OrderByDescending(x => x.CustomerId);
            //PagedList<Customer> models = listCustomers.ToPagedList<Customer>();

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
                        var pageSize = 5; //Show 10 rows every time
                        List<SelectListItem> listStatus = new List<SelectListItem>();
                        listStatus.Add(new SelectListItem() { Text = "Hoạt động", Value = "1" });
                        listStatus.Add(new SelectListItem() { Text = "Không hoạt động", Value = "0" });
                        ViewData["TrangThai"] = listStatus;

                        List<Customer> lsCustomers = new List<Customer>();
                        lsCustomers = _context.Customers.AsNoTracking().Where(x => x.IsDeteted == false && x.RoleId==2).OrderByDescending(x => x.CustomerId).ToList();
                        PagedList<Customer> models = new PagedList<Customer>(lsCustomers.AsQueryable(), pageNumber, pageSize);
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

        // GET: Admin/AdminCustomers/Details/5
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

                        var customer = await _context.Customers.Include(x=> x.Role)
                            .FirstOrDefaultAsync(m => m.CustomerId == id);
                        if (customer == null)
                        {
                            return NotFound();
                        }

                        return View(customer);

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

        // GET: Admin/AdminCustomers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/AdminCustomers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CustomerId,Fullname,Birtday,Avatar,Address,Email,Phone,Password,Status,LastLogin,CreatedDate")] Customer customer)
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
                            _context.Add(customer);
                            await _context.SaveChangesAsync();
                            return RedirectToAction(nameof(Index));
                        }
                        return View(customer);
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

        // GET: Admin/AdminCustomers/Edit/5
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

                        var customer = await _context.Customers.FindAsync(id);
                        if (customer == null)
                        {
                            return NotFound();
                        }
                        return View(customer);
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

        // POST: Admin/AdminCustomers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CustomerId,Fullname,Salt,Address,Email,Phone,Password,Status,LastLogin,CreatedDate")] Customer customer)
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
                        if (id != customer.CustomerId)
                        {
                            return NotFound();
                        }

                        if (ModelState.IsValid)
                        {
                            try
                            {
                                if (string.IsNullOrEmpty(customer.Password))
                                {
                                    var accountcheck = _context.Customers.AsNoTracking().FirstOrDefault(x => x.CustomerId == id);
                                    customer.Password = accountcheck.Password;
                                }
                                else
                                {
                                    customer.Password = (customer.Password.Trim() + customer.Salt.Trim()).ToMD5();
                                }
                                customer.RoleId = 2;
                                _context.Update(customer);
                                await _context.SaveChangesAsync();
                                _notyfService.Success("Cập nhật thành công!");
                                
                            }
                            catch (DbUpdateConcurrencyException)
                            {
                                if (!CustomerExists(customer.CustomerId))
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

        // GET: Admin/AdminCustomers/Delete/5
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

                        var customer = await _context.Customers
                            .FirstOrDefaultAsync(m => m.CustomerId == id);
                        if (customer == null)
                        {
                            return NotFound();
                        }

                        return View(customer);
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

        // POST: Admin/AdminCustomers/Delete/5
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
                        var customer = await _context.Customers.FindAsync(id);
                        _context.Customers.Remove(customer);
                        await _context.SaveChangesAsync();
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

        private bool CustomerExists(int id)
        {
            return _context.Customers.Any(e => e.CustomerId == id);
        }
    }
}

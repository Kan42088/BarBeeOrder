using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BarBeeOrder.Models;
using AspNetCoreHero.ToastNotification.Abstractions;
using PagedList.Core;
using Microsoft.AspNetCore.Http;

namespace BarBeeOrder.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminOrdersController : Controller
    {
        private readonly BarBeeOrderContext _context;

        public INotyfService _notyfService { get; }
        public AdminOrdersController(BarBeeOrderContext context, INotyfService notyfService)
        {
            _context = context;
            _notyfService = notyfService;
        }

        // GET: Admin/AdminOrders
        public async Task<IActionResult> Index(int? page)
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

                    }
                    catch
                    {
                        return RedirectToAction("Error", "Error", new { area = "" });
                    }
                    var pageNumber = page ?? 1;
                    var pageSize = 5; //Show 10 rows every time

                    List<Order> lsOrders = new List<Order>();
                    lsOrders = _context.Orders.AsNoTracking().Where(x => x.Deleted == false).Include(o => o.Customer).Include(o => o.Payment).Include(o => o.Su).Include(o => o.TransactionStatus).OrderByDescending(x => x.OrderDate).ToList();
                    PagedList<Order> models = new PagedList<Order>(lsOrders.AsQueryable(), pageNumber, pageSize);
                    ViewBag.CurrentPage = pageNumber;
                    ViewBag.cStatus = new SelectList(_context.TransactionStatuses, "TransactionStatusId", "Status");
                    return View(models);

                }
                return RedirectToAction("Index", "Home", new { area = "" });
            }
            else
            {
                return RedirectToAction("Index", "Home", new { area = "" });
            }

            
        }

        // GET: Admin/AdminOrders/Details/5
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

                    }
                    catch
                    {
                        return RedirectToAction("Error", "Error", new { area = "" });
                    }
                    if (id == null)
                    {
                        return NotFound();
                    }

                    var order = await _context.Orders
                        .Include(o => o.Customer)
                        .Include(o => o.Payment)
                        .Include(o => o.Su)
                        .Include(o => o.TransactionStatus)
                        .FirstOrDefaultAsync(m => m.OrderId == id);
                    if (order == null)
                    {
                        return NotFound();
                    }

                    var ChitietDonHang = _context.OrderDetails.AsNoTracking().Include(x => x.Product).Where(x => x.OrderId == order.OrderId).OrderBy(x => x.OrderDetailId).ToList();
                    ViewBag.ChitietDonHang = ChitietDonHang;

                    return View(order);

                }
                return RedirectToAction("Index", "Home", new { area = "" });
            }
            else
            {
                return RedirectToAction("Index", "Home", new { area = "" });
            }

            
        }

        // GET: Admin/AdminOrders/Create
        public IActionResult Create()
        {
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "CustomerId");
            ViewData["PaymentId"] = new SelectList(_context.PaymentIds, "PaymentId1", "PaymentId1");
            ViewData["Suid"] = new SelectList(_context.ShippingUnits, "Suid", "Suid");
            ViewData["TransactionStatusId"] = new SelectList(_context.TransactionStatuses, "TransactionStatusId", "TransactionStatusId");
            return View();
        }

        // POST: Admin/AdminOrders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrderId,CustomerId,OrderDate,ShipDate,TransactionStatusId,Deleted,Paid,PaymentDate,TotalMoney,PaymentId,Address,Note,Suid")] Order order)
        {
            if (ModelState.IsValid)
            {
                _context.Add(order);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "CustomerId", order.CustomerId);
            ViewData["PaymentId"] = new SelectList(_context.PaymentIds, "PaymentId1", "PaymentId1", order.PaymentId);
            ViewData["Suid"] = new SelectList(_context.ShippingUnits, "Suid", "Suid", order.Suid);
            ViewData["TransactionStatusId"] = new SelectList(_context.TransactionStatuses, "TransactionStatusId", "TransactionStatusId", order.TransactionStatusId);
            return View(order);
        }

        // POST: Admin/AdminOrders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangeStatus(int id, int cStatus)
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

                    }
                    catch
                    {
                        return RedirectToAction("Error", "Error", new { area = "" });
                    }
                    var order = _context.Orders.FirstOrDefault(o => o.OrderId == id);
                    if (id == null)
                    {
                        _notyfService.Error("Thay đổi trạng thái thất bại!");
                        return RedirectToAction("Index", "AdminOrders");
                    }
                    if (ModelState.IsValid)
                    {
                        try
                        {
                            order.TransactionStatusId = cStatus;
                            //1:cho lay
                            //2:cho xac nhan
                            //3:dang giao
                            //4:giao thanh cong
                            //5:da huy
                            //6:tra hang
                            if (cStatus == 4)
                            {
                                order.ShipDate = DateTime.Now;
                                order.PaymentDate = DateTime.Now;
                            }

                            _context.Update(order);
                            await _context.SaveChangesAsync();
                            _notyfService.Success("Thay đổi trạng thái thành công!");
                        }
                        catch (DbUpdateConcurrencyException)
                        {
                            if (!OrderExists(order.OrderId))
                            {
                                _notyfService.Error("Không tìm thấy đơn hàng!");
                                return RedirectToAction("Index", "AdminOrders");
                            }
                            else
                            {

                            }
                        }
                        return RedirectToAction(nameof(Index));
                    }

                    return RedirectToAction("Index", "AdminOrders");


                }
                return RedirectToAction("Index", "Home", new { area = "" });
            }
            else
            {
                return RedirectToAction("Index", "Home", new { area = "" });
            }

            
        }

        // GET: Admin/AdminOrders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Orders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            //ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "CustomerId", order.CustomerId);
            //ViewData["PaymentId"] = new SelectList(_context.PaymentIds, "PaymentId1", "PaymentId1", order.PaymentId);
            //ViewData["Suid"] = new SelectList(_context.ShippingUnits, "Suid", "Suid", order.Suid);
            ViewData["TransactionStatusId"] = new SelectList(_context.TransactionStatuses, "TransactionStatusId", "TransactionStatusId", order.TransactionStatusId);
            return View(order);
        }
        // POST: Admin/AdminOrders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OrderId,CustomerId,OrderDate,ShipDate,TransactionStatusId,Deleted,Paid,PaymentDate,TotalMoney,PaymentId,Address,Note,Suid")] Order order)
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

                    }
                    catch
                    {
                        return RedirectToAction("Error", "Error", new { area = "" });
                    }
                    if (id != order.OrderId)
                    {
                        return RedirectToAction("Index", "AdminOrders");
                    }

                    if (ModelState.IsValid)
                    {
                        try
                        {
                            _context.Update(order);
                            await _context.SaveChangesAsync();
                        }
                        catch (DbUpdateConcurrencyException)
                        {
                            if (!OrderExists(order.OrderId))
                            {
                                return RedirectToAction("Index", "AdminOrders");
                            }
                            else
                            {
                                throw;
                            }
                        }
                        return RedirectToAction(nameof(Index));
                    }
                    ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "CustomerId", order.CustomerId);
                    ViewData["PaymentId"] = new SelectList(_context.PaymentIds, "PaymentId1", "PaymentId1", order.PaymentId);
                    ViewData["Suid"] = new SelectList(_context.ShippingUnits, "Suid", "Suid", order.Suid);
                    ViewData["TransactionStatusId"] = new SelectList(_context.TransactionStatuses, "TransactionStatusId", "TransactionStatusId", order.TransactionStatusId);
                    return View(order);

                }
                return RedirectToAction("Index", "Home", new { area = "" });
            }
            else
            {
                return RedirectToAction("Index", "Home", new { area = "" });
            }

           
        }

        // GET: Admin/AdminOrders/Delete/5
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

                    }
                    catch
                    {
                        return RedirectToAction("Error", "Error", new { area = "" });
                    }
                    if (id == null)
                    {
                        _notyfService.Error("Không tìm thấy đơn hàng!");
                        return RedirectToAction("Index", "AdminOrders");
                    }

                    var order = await _context.Orders
                        .Include(o => o.Customer)
                        .Include(o => o.Payment)
                        .Include(o => o.Su)
                        .Include(o => o.TransactionStatus)
                        .FirstOrDefaultAsync(m => m.OrderId == id);
                    if (order == null)
                    {
                        _notyfService.Error("Không tìm thấy đơn hàng!");
                        return RedirectToAction("Index", "AdminOrders");
                    }

                    return View(order);

                }
                return RedirectToAction("Index", "Home", new { area = "" });
            }
            else
            {
                return RedirectToAction("Index", "Home", new { area = "" });
            }


            
        }

        // POST: Admin/AdminOrders/Delete/5
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
                        var order = await _context.Orders.FindAsync(id);
                        order.Deleted = true;
                        _context.Orders.Update(order);
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

        private bool OrderExists(int id)
        {
            return _context.Orders.Any(e => e.OrderId == id);
        }
    }
}

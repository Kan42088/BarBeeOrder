using AspNetCoreHero.ToastNotification.Abstractions;
using BarBeeOrder.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BarBeeOrder.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly BarBeeOrderContext _context;
        public INotyfService _notyfService { get; }
        public HomeController(BarBeeOrderContext context, INotyfService notyfService)
        {
            _context = context;
            _notyfService = notyfService;
        }
        public IActionResult Index()
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
                        var today = DateTime.Now;
                        List<Order> monthOrders = new List<Order>();
                        monthOrders = _context.Orders.AsNoTracking().Where(x => x.OrderDate.Value.Month == today.Month).ToList();
                        ViewBag.MonthOrders = monthOrders;
                        List<Order> yearOrders = new List<Order>();
                        yearOrders = _context.Orders.AsNoTracking().Where(x => x.OrderDate.Value.Year == today.Year).ToList();
                        ViewBag.YearOrders = yearOrders;

                        List<Order> model = new List<Order>();
                        model = _context.Orders.AsNoTracking().Where(p=> p.Deleted==false).OrderBy(o=> o.OrderDate).Take(5).Include(o=> o.Customer).Include(t=> t.TransactionStatus).ToList();
                        return View(model);
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
    }
}

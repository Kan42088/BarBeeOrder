using AspNetCoreHero.ToastNotification.Abstractions;
using BarBeeOrder.Extension;
using BarBeeOrder.Helper;
using BarBeeOrder.Models;
using BarBeeOrder.ModelView;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BarBeeOrder.Controllers
{
    public class CheckoutController : Controller
    {
        private readonly BarBeeOrderContext _context;
        public INotyfService _notyfService { get; }

        public CheckoutController(BarBeeOrderContext context, INotyfService notyfService)
        {
            _context = context;
            _notyfService = notyfService;
        }

        [HttpGet]
        [Route("thanh-toan.html", Name = "Checkout")]
        public IActionResult Index(string? returnUrl)
        {
            var cart = HttpContext.Session.Get<List<CartItem>>("GioHang");
            var taikhoanID = HttpContext.Session.GetString("CustomerId");
            BuyVM model = new BuyVM();
            if (taikhoanID != null)
            {
                var khachhang = _context.Customers.AsNoTracking().SingleOrDefault(x => x.CustomerId == Convert.ToInt32(taikhoanID));
                model.CustomerId = khachhang.CustomerId;
                model.FullName = khachhang.Fullname;
                model.Email = khachhang.Email;
                model.Phone = khachhang.Phone;
                model.Address = khachhang.Address;
            }
            ViewBag.GioHang = cart;
            return View(model);
        }

        [HttpPost]
        [Route("thanh-toan.html", Name = "Checkout")]
        public IActionResult Index(BuyVM buy)
        {
            var cart = HttpContext.Session.Get<List<CartItem>>("GioHang");
            var taikhoanID = HttpContext.Session.GetString("CustomerId");
            BuyVM model = new BuyVM();
            if (taikhoanID != null)
            {
                var khachhang = _context.Customers.AsNoTracking().SingleOrDefault(x => x.CustomerId == Convert.ToInt32(taikhoanID));
                model.CustomerId = khachhang.CustomerId;
                model.FullName = khachhang.Fullname;
                model.Email = khachhang.Email;
                model.Phone = khachhang.Phone;
                model.Address = khachhang.Address;

                khachhang.Address = buy.Address;
                _context.Update(khachhang);
                _context.SaveChanges();
            }
            try
            {
                if (ModelState.IsValid)
                {
                    Order donhang = new Order();
                    donhang.CustomerId = model.CustomerId;
                    donhang.Address = model.Address;
                    donhang.OrderDate = DateTime.Now;
                    donhang.TransactionStatusId = 1;
                    donhang.Deleted = false;
                    donhang.Paid = false;
                    donhang.Note= Utilities.StripHTML(model.Note);
                    donhang.TotalMoney = Convert.ToInt32(cart.Sum(x => x.TotalMoney));
                    _context.Add(donhang);
                    _context.SaveChanges();


                    foreach (var item in cart)
                    {
                        OrderDetail orderDetail = new OrderDetail();
                        orderDetail.OrderId = donhang.OrderId;
                        orderDetail.ProductId = item.product.ProductId;
                        orderDetail.Quantity = item.amount;
                        orderDetail.TotalMoney = Convert.ToInt32(item.TotalMoney);
                        orderDetail.Price = item.product.Price;
                        orderDetail.CreateDate = DateTime.Now;
                        _context.Add(orderDetail);
                    }
                    _context.SaveChanges();
                    HttpContext.Session.Remove("GioHang");
                    _notyfService.Success("Đặt đơn hàng thành công!");
                    return RedirectToAction("Success");
                }
            }
            catch
            {
                ViewBag.GioHang = cart;
                return View();
            }
            ViewBag.GioHang = cart;
            return View();
        }

        [HttpGet]
        [Route("dat-hang-thanh-cong.html", Name = "Success")]
        public IActionResult Success()
        {
            try
            {
                var taikhoanID = HttpContext.Session.GetString("CustomerId");
                if (string.IsNullOrEmpty(taikhoanID))
                {
                    return RedirectToAction("Login","Accounts", new { returnUrl = "/dat-hang-thanh-cong.html" });
                }
                var khachhang = _context.Customers.AsNoTracking().SingleOrDefault(x => x.CustomerId == Convert.ToInt32(taikhoanID));
                var donhang = _context.Orders.Where(x=> x.CustomerId== Convert.ToInt32(taikhoanID)).Include(x=> x.Customer).OrderBy(x=>x.OrderDate).Last();
                return View(donhang);
            }
            catch
            {
                return View();
            }
            
        }
    }
}

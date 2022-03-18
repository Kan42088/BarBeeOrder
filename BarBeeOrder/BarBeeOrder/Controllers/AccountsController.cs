﻿using BarBeeOrder.Helper;
using BarBeeOrder.Models;
using BarBeeOrder.ModelView;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authentication;
using BarBeeOrder.Extension;
using AspNetCoreHero.ToastNotification.Abstractions;

namespace BarBeeOrder.Controllers
{
    [Authorize]
    public class AccountsController : Controller
    {
        private readonly BarBeeOrderContext _context;
        public INotyfService _notyfService { get; }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult ValidatePhone(string phone)
        {
            try
            {
                var khachhang = _context.Customers.AsNoTracking().SingleOrDefault(x => x.Phone.ToLower() == phone.ToLower());
                if (khachhang != null)
                {
                    return Json(data: "Số điện thoại :" + phone + " đã được đăng kí!");
                }
                return Json(data: true);
            }
            catch
            {
                return Json(data: true);
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult ValidateEmail(string email)
        {
            try
            {
                var khachhang = _context.Customers.AsNoTracking().SingleOrDefault(x => x.Email.ToLower() == email.ToLower());
                if (khachhang != null)
                {
                    return Json(data: "Email :" + email + " đã được đăng kí!");
                }
                return Json(data: true);
            }
            catch
            {
                return Json(data: true);
            }
        }

        public AccountsController(BarBeeOrderContext context, INotyfService notyfService)
        {
            _context = context;
            _notyfService = notyfService;
        }

        [Route("tai-khoan-cua-toi.html", Name = "Dashboard")]
        public IActionResult Dashboard()
        {
            var taikhoanID = HttpContext.Session.GetString("CustomerId");
            if (taikhoanID != null)
            {
                var khachhang = _context.Customers.AsNoTracking().SingleOrDefault(x=> x.CustomerId==Convert.ToInt32(taikhoanID));
                if (khachhang!=null)
                {
                    var lsOrder = _context.Orders.AsNoTracking().Where(x=> x.CustomerId ==khachhang.CustomerId).Include(x=> x.TransactionStatus).OrderBy(x => x.OrderDate).ToList();
                    ViewBag.lsOrder = lsOrder;
                    return View(khachhang);
                }
            }
            return RedirectToAction("Login", "Accounts");
        }


        [HttpGet]
        [AllowAnonymous]
        [Route("dang-ky.html", Name = "DangKy")]
        public async Task<IActionResult> Dangkitaikhoan()
        {
            return View();
        }

        [HttpPost]
        [Route("dang-ky.html", Name = "DangKy")]
        [AllowAnonymous]
        public async Task<IActionResult> Dangkitaikhoan(RegisterVM taikhoan)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string salt = Utilities.GetRandomKey();
                    Customer khachhang = new Customer
                    {
                        Fullname = taikhoan.FullName,
                        Phone = taikhoan.Phone,
                        Email = taikhoan.Email,
                        Password = (taikhoan.Password+salt.Trim()).ToMD5(),
                        Status = true,
                        Salt = salt,
                        CreatedDate = DateTime.Now
                    };
                    try
                    {
                        _context.Add(khachhang);
                        await _context.SaveChangesAsync();
                        HttpContext.Session.SetString("CustomerId", khachhang.CustomerId.ToString());
                        var taikhoanID = HttpContext.Session.GetString("CustomerId");
                        var claims = new List<Claim>
                        {
                            new Claim(ClaimTypes.Name,khachhang.Fullname),
                            new Claim("CustomerId",khachhang.CustomerId.ToString())
                        };
                        ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "login");
                        ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                        await HttpContext.SignInAsync(claimsPrincipal);
                        return RedirectToAction("Dashboard", "Accounts");

                    }
                    catch
                    {
                        return RedirectToAction("DangKyTaiKhoan", "Accounts");
                    }
                }
                else
                {
                    return View(taikhoan);
                }
            }
            catch
            {
                return View(taikhoan);
            }


        }


        [HttpGet]
        [AllowAnonymous]
        [Route("dang-nhap.html", Name = "DangNhap")]
        public async Task<IActionResult> Login(string returnUrl = null)
        {
            var taikhoanID = HttpContext.Session.GetString("CustomerId");
            if (taikhoanID != null)
            {
                return RedirectToAction("Dashboard", "Accounts");
            }
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("dang-nhap.html",Name ="DangNhap")]
        public async Task<IActionResult> Login(LoginViewModel customer,string returnUrl = null)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bool isEmail = Utilities.IsValidEmail(customer.UserName);
                    if (!isEmail)
                    {
                        return View(customer);
                    }
                    var khachhang = _context.Customers.AsNoTracking().SingleOrDefault(x => x.Email.Trim() == customer.UserName);
                    if (khachhang == null)
                    {
                        return RedirectToAction("Dangkitaikhoan", "Accounts");
                    }
                    string pass = (customer.Password + khachhang.Salt.Trim()).ToMD5();
                    if (khachhang.Password != pass)
                    {
                        _notyfService.Warning("Sai thông tin đăng nhập!");
                        return View(customer);
                    }
                    if (khachhang.Status == false)
                    {
                        return RedirectToAction("ThongBao", "Accounts");
                    }

                    HttpContext.Session.SetString("CustomerId", khachhang.CustomerId.ToString());
                    var taikhoanID = HttpContext.Session.GetString("CustomerId");
                    var claims = new List<Claim>
                        {
                            new Claim(ClaimTypes.Name,khachhang.Fullname),
                            new Claim("CustomerId",khachhang.CustomerId.ToString())
                        };
                    ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "login");
                    ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                    await HttpContext.SignInAsync(claimsPrincipal);
                    _notyfService.Success("Đăng nhập thành công!");
                    return RedirectToAction("Dashboard", "Accounts");
                }
            }
            catch
            {
                return RedirectToAction("Dangkitaikhoan", "Accounts");
            }
            
            return View(customer);
        }
        [HttpGet]
        [Route("dang-xuat.html",Name ="DangXuat")]
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync();
            HttpContext.Session.Remove("CustomerId");
            return RedirectToAction("Index", "Home");
        }

    }
}
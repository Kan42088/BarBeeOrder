using BarBeeOrder.Helper;
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
using EmailService;

namespace BarBeeOrder.Controllers
{
    [Authorize]
    public class AccountsController : Controller
    {
        private readonly BarBeeOrderContext _context;
        public INotyfService _notyfService { get; }
        private readonly IEmailSender _emailSender;
        public AccountsController(BarBeeOrderContext context, INotyfService notyfService, IEmailSender emailSender)
        {
            _context = context;
            _notyfService = notyfService;
            _emailSender = emailSender;
        }
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

        

        [Route("tai-khoan-cua-toi.html", Name = "Dashboard")]
        public IActionResult Dashboard()
        {
            List<Page> pages = new List<Page>();
            pages = _context.Pages.AsNoTracking().Where(p => p.IsHeader == true && p.Published == true).OrderBy(x => x.Ordering).ToList();
            ViewData["MenuPages"] = pages;
            List<Category> categories = new List<Category>();
            categories = _context.Categories.AsNoTracking().Where(c => c.IsDeleted == false && c.Published == true && c.Type == 1).OrderBy(x => x.Ordering).ToList();
            ViewData["MenuCategories"] = categories;

            var taikhoanID = HttpContext.Session.GetString("CustomerId");
            if (taikhoanID != null)
            {
                var khachhang = _context.Customers.AsNoTracking().SingleOrDefault(x => x.CustomerId == Convert.ToInt32(taikhoanID));
                if (khachhang != null)
                {
                    var lsOrder = _context.Orders.AsNoTracking().Where(x => x.CustomerId == khachhang.CustomerId).Include(x => x.TransactionStatus).OrderBy(x => x.OrderDate).ToList();
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
            List<Category> categories = new List<Category>();
            categories = _context.Categories.AsNoTracking().Where(c => c.IsDeleted == false && c.Published == true && c.Type == 1).OrderBy(x => x.Ordering).ToList();
            ViewData["MenuCategories"] = categories;
            List<Page> pages = new List<Page>();
            pages = _context.Pages.AsNoTracking().Where(p => p.IsHeader == true && p.Published == true).OrderBy(x => x.Ordering).ToList();
            ViewData["MenuPages"] = pages;
            return View();
        }

        [HttpPost]
        [Route("dang-ky.html", Name = "DangKy")]
        [AllowAnonymous]
        public async Task<IActionResult> Dangkitaikhoan(RegisterVM taikhoan)
        {
            List<Page> pages = new List<Page>();
            pages = _context.Pages.AsNoTracking().Where(p => p.IsHeader == true && p.Published == true).OrderBy(x => x.Ordering).ToList();
            ViewData["MenuPages"] = pages;
            List<Category> categories = new List<Category>();
            categories = _context.Categories.AsNoTracking().Where(c => c.IsDeleted == false && c.Published == true && c.Type == 1).OrderBy(x => x.Ordering).ToList();
            ViewData["MenuCategories"] = categories;
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
                        Password = (taikhoan.Password + salt.Trim()).ToMD5(),
                        Status = true,
                        Salt = salt,
                        RoleId = 2,
                        Address = "Hà Nội, Việt Nam",
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
            List<Page> pages = new List<Page>();
            pages = _context.Pages.AsNoTracking().Where(p => p.IsHeader == true && p.Published == true).OrderBy(x => x.Ordering).ToList();
            ViewData["MenuPages"] = pages;
            List<Category> categories = new List<Category>();
            categories = _context.Categories.AsNoTracking().Where(c => c.IsDeleted == false && c.Published == true && c.Type == 1).OrderBy(x => x.Ordering).ToList();
            ViewData["MenuCategories"] = categories;

            var taikhoanID = HttpContext.Session.GetString("CustomerId");
            
            if (taikhoanID != null)
            {
                return RedirectToAction("Dashboard", "Accounts");
            }
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("dang-nhap.html", Name = "DangNhap")]
        public async Task<IActionResult> Login(LoginViewModel customer, string returnUrl = null)
        {
            List<Page> pages = new List<Page>();
            pages = _context.Pages.AsNoTracking().Where(p => p.IsHeader == true && p.Published == true).OrderBy(x => x.Ordering).ToList();
            ViewData["MenuPages"] = pages;
            List<Category> categories = new List<Category>();
            categories = _context.Categories.AsNoTracking().Where(c => c.IsDeleted == false && c.Published == true && c.Type == 1).OrderBy(x => x.Ordering).ToList();
            ViewData["MenuCategories"] = categories;

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
                        _notyfService.Warning("Rất tiếc, tài khoản của bạn đã bị khóa!");
                        return View(customer);
                    }
                    if (khachhang.RoleId==2)
                    {
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
                        khachhang.LastLogin = DateTime.Now;
                        _context.Update(khachhang);
                        _context.SaveChanges();
                        if (!string.IsNullOrEmpty(returnUrl))
                        {
                            return Redirect(returnUrl);
                        }
                        
                        return RedirectToAction("Dashboard", "Accounts");
                    }
                    else
                    {
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
                        khachhang.LastLogin = DateTime.Now;
                        _context.Update(khachhang);
                        _context.SaveChanges();
                        if (!string.IsNullOrEmpty(returnUrl))
                        {
                            return Redirect(returnUrl);
                        }
                        return RedirectToAction("Index", "Home",new{area ="Admin" });
                    }
                    
                    
                }
            }
            catch
            {
                return RedirectToAction("Dangkitaikhoan", "Accounts");
            }

            return View(customer);
        }
        [HttpGet]
        [Route("dang-xuat.html", Name = "DangXuat")]
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync();
            HttpContext.Session.Remove("CustomerId");
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult ChangePassword()
        {
            return PartialView("ChangePassword");
        }

        [HttpPost]
        public IActionResult ChangePassword(ChangePasswordVM model)
        {
            try
            {

                var taikhoanID = HttpContext.Session.GetString("CustomerId");
                if (taikhoanID == null)
                {
                    return RedirectToAction("Login", "Accounts");
                }
                if (ModelState.IsValid)
                {
                    var taikhoan = _context.Customers.Find(Convert.ToInt32(taikhoanID));
                    if (taikhoan == null)
                    {
                        return RedirectToAction("Login", "Accounts");
                    }
                    var pass = (model.PasswordNow.Trim() + taikhoan.Salt.Trim()).ToMD5();
                    if (pass == taikhoan.Password)
                    {
                        string passNew = (model.Password.Trim() + taikhoan.Salt.Trim()).ToMD5();
                        taikhoan.Password = passNew;
                        _context.Update(taikhoan);
                        _context.SaveChanges();
                        _notyfService.Success("Đổi mật khẩu thành công!");
                        return RedirectToAction("Dashboard", "Accounts");
                    }
                }
            }
            catch
            {
                _notyfService.Error("Đổi mật khẩu không thành công!");
                return RedirectToAction("Dashboard", "Accounts");
            }
            _notyfService.Error("Đổi mật khẩu không thành công!");
            return RedirectToAction("Dashboard", "Accounts");
        }


        [HttpGet]
        [AllowAnonymous]
        public IActionResult ForgotPassword()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordModel forgotPasswordModel)
        {
            if (!ModelState.IsValid)
                return View(forgotPasswordModel);

            var user = await _context.Customers.AsNoTracking().FirstOrDefaultAsync(x=> x.Email == forgotPasswordModel.Email);
            if (user == null)
                return RedirectToAction(nameof(Login));
            var randomPass = Utilities.GetRandomKey(8);
            string passNew = (randomPass + user.Salt.Trim()).ToMD5();
            user.Password = passNew;
            _context.Update(user);
            _context.SaveChanges();
            _notyfService.Success("Đổi mật khẩu thành công, Kiểm tra lại email của bạn!");
            string content = "Mật khẩu của bản đã được đặt lại thành:\n"+randomPass+"\nVui lòng đăng nhập lại và thay đổi mật khẩu!\nBarBeeOrder.";
            var message = new Message(new string[] { user.Email }, "Mật khẩu đã được đặt lại!", content);
            
            
            _emailSender.SendEmail(message);

            return RedirectToAction(nameof(Login));
        }

       
    }
}

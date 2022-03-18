using AspNetCoreHero.ToastNotification.Abstractions;
using BarBeeOrder.Extension;
using BarBeeOrder.Models;
using BarBeeOrder.ModelView;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using System.Linq;

namespace BarBeeOrder.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly BarBeeOrderContext _context;
        public INotyfService _notyfService { get; }

        public ShoppingCartController(BarBeeOrderContext context, INotyfService notyfService)
        {
            _context = context;
            _notyfService = notyfService;
        }
        public List<CartItem> GioHang
        {
            get
            {
                var gh = HttpContext.Session.Get<List<CartItem>>("GioHang");
                if (gh == default(List<CartItem>))
                {
                    gh = new List<CartItem>();

                }
                return gh;
            }
        }

        [HttpPost]
        [Route("api/cart/update")]
        public IActionResult UpdateCart(int productID, int? amount)
        {
            var cart = HttpContext.Session.Get<List<CartItem>>("GioHang");
            try
            {
                if (cart != null)
                {
                    CartItem item = cart.SingleOrDefault(p => p.product.ProductId == productID);
                    if (item != null && amount.HasValue)
                    {
                        item.amount = amount.Value;
                    }

                    HttpContext.Session.Set<List<CartItem>>("GioHang", cart);
                }
                return Json(new { success = true });
            }
            catch
            {
                return Json(new { success = false });
            }
        }


        [HttpPost]
        [Route("api/cart/add")]
        public IActionResult AddToCart(int productID, int? amount)
        {
            List<CartItem> giohang = GioHang;
            try
            {
                CartItem item = giohang.SingleOrDefault(p => p.product.ProductId == productID);
                if (item != null)
                {
                    item.amount = item.amount + amount.Value;
                    HttpContext.Session.Set<List<CartItem>>("GioHang", giohang);
                }
                else
                {
                    Product hh = _context.Products.SingleOrDefault(p => p.ProductId == productID);
                    item = new CartItem
                    {
                        amount = amount.HasValue ? amount.Value : 1,
                        product = hh
                    };
                    giohang.Add(item);
                }

                HttpContext.Session.Set<List<CartItem>>("GioHang", giohang);
                _notyfService.Success("Đã thêm sản phẩm vào giỏ hàng!");
                return Json(new { success = true });
            }
            catch
            {
                return Json(new { success = false });
            }
            return Json(new { success = false });
        }

        [HttpPost]
        [Route("api/cart/remove")]
        public IActionResult Remove(int productID)
        {
            try
            {
                List<CartItem> giohang = GioHang;
                CartItem item = giohang.SingleOrDefault(p => p.product.ProductId == productID);
                if (item != null)
                {
                    giohang.Remove(item);
                }
                HttpContext.Session.Set<List<CartItem>>("GioHang", giohang);
                return Json(new { success = true });
            }
            catch
            {
                return Json(new { success = false });
            }
            
        }
        [Route("cart.html",Name ="Cart")]
        public IActionResult Index()
        {
            //List<int> lsProductIDs = new List<int>();

            //foreach (var item in lsGiohang)
            //{
            //    lsProductIDs.Add(item.product.ProductId);
            //}
            //List<Product> lsPrducts = _context.Products.OrderByDescending(x=> x.ProductId)
            //    .Where(x=> x.BestSellers== true &&!lsProductIDs.Contains(x.ProductId))
            //    .Take(6).ToList();
            //ViewBag.lsSanPham = lsPrducts;

            var lsGiohang = GioHang;
            return View(GioHang);
        }
    }
}

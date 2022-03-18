using BarBeeOrder.Extension;
using BarBeeOrder.ModelView;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BarBeeOrder.Controllers.Components
{
    public class NumberCartViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var cart = HttpContext.Session.Get<List<CartItem>>("GioHang");
            //int soluongsanpham = 0;
            //if (cart!=null)
            //{
            //    soluongsanpham = cart.Count;
            //}
            return View(cart);
        }
    }
}

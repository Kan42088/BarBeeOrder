using BarBeeOrder.Extension;
using BarBeeOrder.ModelView;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BarBeeOrder.Controllers.Components
{
    public class HeaderCartViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var cart = HttpContext.Session.Get<List<CartItem>>("GioHang");
            return View(cart);
        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace BarBeeOrder.Controllers
{
    public class AjaxContentController : Controller
    {
        public IActionResult HeaderCart()
        {
            return ViewComponent("HeaderCart");
        }
        public IActionResult HeaderFavorites()
        {
            return ViewComponent("NumberCart");
        }
    }
}

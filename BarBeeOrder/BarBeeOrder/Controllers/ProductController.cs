using Microsoft.AspNetCore.Mvc;

namespace BarBeeOrder.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

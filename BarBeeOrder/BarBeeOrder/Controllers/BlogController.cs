using Microsoft.AspNetCore.Mvc;

namespace BarBeeOrder.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

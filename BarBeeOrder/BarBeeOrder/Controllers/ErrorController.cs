using Microsoft.AspNetCore.Mvc;

namespace BarBeeOrder.Controllers
{
    public class ErrorController : Controller
    {

        public IActionResult Error()
        {
            return View();
        }
    }
}

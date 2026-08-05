using Microsoft.AspNetCore.Mvc;

namespace Project.Analytics.Dashboard.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

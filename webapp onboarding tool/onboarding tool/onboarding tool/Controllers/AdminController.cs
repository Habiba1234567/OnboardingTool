using Microsoft.AspNetCore.Mvc;

namespace onboarding_tool.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

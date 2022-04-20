using Microsoft.AspNetCore.Mvc;

namespace AdminTemplate.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

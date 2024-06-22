using Microsoft.AspNetCore.Mvc;

namespace AdminPortal.Controllers
{//musi to byc dopracowane
    public class BaseController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace eco.S.H.O.P.Areas.Admin.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

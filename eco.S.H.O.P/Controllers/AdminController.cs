using BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace eco.S.H.O.P.Controllers
{
    public class AdminController : Controller
    {
        private readonly UserService _userService;
        private readonly ProductService _productService;

        public AdminController(UserService userService, ProductService productService)
        {
            _userService = userService;
            _productService = productService;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}

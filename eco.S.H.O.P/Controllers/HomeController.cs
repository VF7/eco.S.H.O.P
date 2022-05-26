using BLL.Services;
using eco.S.H.O.P.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace eco.S.H.O.P.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ProductService _productService;

        public HomeController(ILogger<HomeController> logger, ProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        public async Task <IActionResult> Index()
        {
            return View(await _productService.FindByConditionAsync(
                x=>x.Price>1));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
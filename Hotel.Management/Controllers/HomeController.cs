using Hotel.Management.Models;
using Hotel.Management.Services.ApartamentService;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Hotel.Management.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IApartamentAppService _apartamentService;

        public HomeController(ILogger<HomeController> logger, IApartamentAppService apartamentService)
        {
            _logger = logger;
            _apartamentService = apartamentService;
        }

        public async Task<IActionResult> Index()
        {
            var apartaments = await _apartamentService.GetAllApratamentsAsync();
            return View(apartaments);
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
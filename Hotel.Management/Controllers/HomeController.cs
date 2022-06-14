using Hotel.Management.Models;
using Hotel.Management.Services.ApartamentService;
using Hotel.Management.Services.ApartamentService.Dto;
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
        public IActionResult Create()
        {
            var model = new CreateOrUpdateApratamentInput();

            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateOrUpdateApratamentInput model)
        {

            await _apartamentService.CreateApartamentAsync(model);
            return RedirectToAction("Index");

        }
        public async Task <IActionResult> Edit(int id)
        {
            var model = await _apartamentService.GetApratamentToEditAsync(id);
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(CreateOrUpdateApratamentInput model)
        {

            await _apartamentService.UpdateApartamentAsync(model);
            return RedirectToAction("Index");

        }
        public async Task<IActionResult> Delete(int id)
        {
            var model = await _apartamentService.GetApratamentToEditAsync(id);
            ViewBag.Id = id;
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(CreateOrUpdateApratamentInput input)
        {

            await _apartamentService.DeleteApartamentAsync(input.Id);
            return RedirectToAction("Index");

        }
    }
}
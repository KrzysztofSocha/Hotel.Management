using Hotel.Management.Services.ApartamentBookingService;
using Hotel.Management.Services.ApartamentBookingService.Dto;
using Hotel.Management.Services.ApartamentService;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.Management.Controllers
{
    public class BookController : Controller
    {
        private readonly IApartamentAppService _apartamentService;
        private readonly IBookingAppService _bookingService;
        public BookController(IApartamentAppService apartamentService, IBookingAppService bookingService)
        {
            _apartamentService=apartamentService;
            _bookingService=bookingService;
        }
        public async Task< IActionResult> Index()
        {
            var models = await _apartamentService.GetFreeApratamentsAsync();
            return View(models);
        }
        public IActionResult Create()
        {
            var model = new CreateBooking();
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int id, CreateBooking input)
        {
            input.ApratamentId=id;
            await _bookingService.CreateBooking(input);
            return RedirectToAction("Index");
        }
    }
}

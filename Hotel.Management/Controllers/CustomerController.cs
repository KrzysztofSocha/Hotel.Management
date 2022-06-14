using Hotel.Management.Services.ClientService;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.Management.Controllers
{
    public class CustomerController : Controller
    {
        private readonly IClientAppService _clientAppService;
        public CustomerController(IClientAppService clientAppService)
        {
            _clientAppService=clientAppService;
        }
        public async Task <IActionResult> Index()
        {
            var clients = await _clientAppService.GetClientsAsync();
            return View(clients);
        }
        public IActionResult Create()
        {
            return View();
        }
    }
}

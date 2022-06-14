using Hotel.Management.Services.ClientService;
using Hotel.Management.Services.ClientService.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.Management.Controllers
{
    public class CustomerController : Controller
    {
        private readonly IClientAppService _clientService;
        public CustomerController(IClientAppService clientService)
        {
            _clientService=clientService;
        }
        public async Task <IActionResult> Index()
        {
            var clients = await _clientService.GetClientsAsync();
            return View(clients);
        }
        
        public IActionResult Create()
        {
            var model = new CreateOrUpdateClient();
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateOrUpdateClient model)
        {

            await _clientService.CreateClientAsync(model);
            return RedirectToAction("Index");

        }
        public async Task<IActionResult> Search(string SearchString)
        {
            var clients = await _clientService.SearchClientAsync(SearchString);
            return View(clients);
        }
        public async Task<IActionResult> Edit(int id)
        {
            var model = await _clientService.GetClientToEditAsync(id);
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,CreateOrUpdateClient model)
        {

            await _clientService.UpdateClientAsync(model, id);
            return RedirectToAction("Index");

        }
    }
}

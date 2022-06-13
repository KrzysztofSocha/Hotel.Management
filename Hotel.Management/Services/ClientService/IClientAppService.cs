using Hotel.Management.Entities;
using Hotel.Management.Services.ClientService.Dto;

namespace Hotel.Management.Services.ClientService
{
    public interface IClientAppService
    {
        Task <List<GetClientOutput>> GetClientsAsync ();
        Task<GetClientOutput> GetClientAsync (string email);
        Task CreateClientAsync(CreateOrUpdateClient input);
        Task UpdateClientAsync(CreateOrUpdateClient input, int id);

    }
}

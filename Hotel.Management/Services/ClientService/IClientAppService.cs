using Hotel.Management.Entities;
using Hotel.Management.Services.ClientService.Dto;

namespace Hotel.Management.Services.ClientService
{
    public interface IClientAppService
    {
        Task <List<GetClientOutput>> GetClientsAsync ();
        Task<List<GetClientOutput>> SearchClientAsync (string emailOrName);
        Task CreateClientAsync(CreateOrUpdateClient input);
        Task UpdateClientAsync(CreateOrUpdateClient input, int id);
        Task<CreateOrUpdateClient> GetClientToEditAsync(int id);
    }
}

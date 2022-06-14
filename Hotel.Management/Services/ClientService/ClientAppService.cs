using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Hotel.Management.Entities;
using Hotel.Management.Services.ClientService.Dto;

namespace Hotel.Management.Services.ClientService
{
    public class ClientAppService:IClientAppService
    {
        private readonly HotelContext _context;
        private readonly IMapper _mapper;
        public ClientAppService(HotelContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task CreateClientAsync(CreateOrUpdateClient input)
        {
            var isExist= _context.CLients.Any(x=>x.Email==input.Email);
            if (!isExist)
            {
                var client = _mapper.Map<Client>(input);
                await _context.CLients.AddAsync(client);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Client o podanym mailu widnieje w bazie danych");
            }
            
        }

        public async Task<List<GetClientOutput>> GetClientsAsync()
        {
            var clients = await _context.CLients.Include(x=>x.Address).ToListAsync();
            return _mapper.Map<List<GetClientOutput>>(clients);
        }

        public async Task<CreateOrUpdateClient> GetClientToEditAsync(int id)
        {
            var clients = await _context.CLients.Include(x => x.Address).FirstOrDefaultAsync(x=>x.Index==id);
            return _mapper.Map<CreateOrUpdateClient>(clients);
        }

        public async Task<List<GetClientOutput>> SearchClientAsync(string searchString)
        {
            var client = await _context.CLients.Include(x => x.Address).Where(x => x.Email.Contains(searchString)|| x.FullName.Contains(searchString)).ToListAsync();
            if (client.Count != 0)
            {
                return _mapper.Map<List<GetClientOutput>>(client);
            }
            return new List<GetClientOutput>();
        }

        public async  Task UpdateClientAsync(CreateOrUpdateClient input, int id)
        {
            var client = await _context.CLients.Include(x=>x.Address).FirstOrDefaultAsync(x => x.Index == id);
            if(client != null)
            {
                var updatedClient = _mapper.Map<Client>(input);
                updatedClient.Index = client.Index;
                updatedClient.AddressId=client.AddressId;
                _context.Entry(client).CurrentValues.SetValues(updatedClient);

                await _context.SaveChangesAsync();
            }
        }
    }
}

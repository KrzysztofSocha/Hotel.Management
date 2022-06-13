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
            var clients = await _context.CLients.ToListAsync();
            return _mapper.Map<List<GetClientOutput>>(clients);
        }

        public async Task<GetClientOutput> GetClientAsync(string email)
        {
           var client = await _context.CLients.FirstOrDefaultAsync(x=>x.Email==email);
            if (client != null)
            {
                return _mapper.Map<GetClientOutput>(client);
            }
            return null;
        }

        public async  Task UpdateClientAsync(CreateOrUpdateClient input, int id)
        {
            var client = await _context.CLients.FirstOrDefaultAsync(x => x.Index == id);
            if(client != null)
            {
                client = _mapper.Map<Client>(input);
                await _context.SaveChangesAsync();
            }
        }
    }
}

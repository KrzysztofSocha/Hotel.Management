using AutoMapper;
using Hotel.Management.Entities;
using Hotel.Management.Services.ApartamentService.Dto;
using Microsoft.EntityFrameworkCore;

namespace Hotel.Management.Services.ApartamentService
{
    public class ApartamentAppService:IApartamentAppService
    {
        private readonly HotelContext _context;
        private IMapper _mapper;
        public ApartamentAppService(HotelContext context,
            IMapper mapper)
        {
            _context=context;
            _mapper=mapper; 
        }

        public async Task CreateApartamentAsync(CreateOrUpdateApratamentInput input)
        {
            try
            {
                var apartament = new Apartament();
                 apartament = _mapper.Map<Apartament>(input);
                await _context.Apartaments.AddAsync(apartament);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw new Exception($"Błąd podczas zapisywania informacji o pokoju {ex.Message}");
            }
        }

        public async Task DeleteApartamentAsync(int id)
        {
            var apartamentToDelete = await _context.Apartaments.FirstOrDefaultAsync(x => x.Id == id);
            if (apartamentToDelete != null)
            {
                apartamentToDelete.IsDeleted = true;
                apartamentToDelete.DeletionTime = DateTime.Now;
                await _context.SaveChangesAsync();
            }                
            else
                throw new Exception("Nie istnieje apartament o podanym id");
           
        }
        
        public async Task<List<GetAllApratamentsOutput>> GetAllApratamentsAsync()
        {
            await CheckFreeApartaments();
            var apartaments = await _context.Apartaments
                .Include(x=>x.Status)
                .Where(x=>x.IsDeleted ==false)
                .ToListAsync();
            return _mapper.Map<List<GetAllApratamentsOutput>>(apartaments);
        }

       
       
        public async Task<List<GetFreeApratamentOutput>> GetFreeApratamentsAsync()
        {
           await CheckFreeApartaments();
           var freeApartaments = await _context.Apartaments.Where(x=>x.StatusId==1 && x.IsDeleted== false).ToListAsync();
            
            return _mapper.Map<List<GetFreeApratamentOutput>>(freeApartaments);
        }

        public async Task UpdateApartamentAsync(CreateOrUpdateApratamentInput input, int id)
        {
            var apartamentToUpdate = await _context.Apartaments.FirstOrDefaultAsync(x=>x.Id==id);
            apartamentToUpdate = _mapper.Map<Apartament>(input);
            await _context.SaveChangesAsync();

        }
        private async Task CheckFreeApartaments()
        {
            var apartaments = await _context.Apartaments.Include(x => x.Booking).Where(x=>x.IsDeleted==false).ToListAsync();
           
            foreach (var apartament in apartaments)
            {
                if (apartament.Booking != null)
                {
                    if (apartament.Booking.EndDate < DateTime.Now)
                    {
                        var history = _mapper.Map<BookingHistory>(apartament);
                        apartament.StatusId = 1;
                        apartament.Booking = null;
                        await _context.BookingHistories.AddAsync(history);
                        await _context.SaveChangesAsync();                        
                    }

                }
            }
        }
    }
}

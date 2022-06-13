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
                var apartament = _mapper.Map<Apartament>(input);
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
            var apartamentToDelete = _context.Apartaments.FirstOrDefault(x => x.Id == id);
            if (apartamentToDelete != null)
            {
                _context.Apartaments.Remove(apartamentToDelete);
                await _context.SaveChangesAsync();
            }                
            else
                throw new Exception("Nie istnieje apartament o podanym id");
           
        }
        //TODO podczas pobierania sprawdzać datę końca wynajmu
        public async Task<List<GetAllApratamentsOutput>> GetAllApratamentsAsync()
        {
            var apartaments = await _context.Apartaments.Include(x=>x.Status).ToListAsync();
            return _mapper.Map<List<GetAllApratamentsOutput>>(apartaments);
        }

        public async Task<GetApartamentBookingInformation> GetBookingInformationAsync(int id)
        {
            var apratament = await _context.Apartaments.Include(x=>x.Booking).FirstOrDefaultAsync(x => x.Id == id);
            if (apratament != null && apratament.Booking != null)
                return _mapper.Map<GetApartamentBookingInformation>(apratament.Booking);
            else
                throw new Exception("Błąd podczas pobierania informacji o rezerwacji");
        }
        //TODO podczas pobierania sprawdzać datę końca wynajmu
        public async Task<List<GetFreeApratamentOutput>> GetFreeApratamentsAsync()
        {
           var apartaments = await _context.Apartaments.Include(x=>x.Booking).ToListAsync();
            var freeApartaments = new List<Apartament>();
            foreach(var apartament in apartaments)
            {
                if(apartament.Booking != null)
                {
                    if(apartament.Booking.EndDate < DateTime.Now)
                    {
                        var history = _mapper.Map<BookingHistory>(apartament);
                        apartament.StatusId = 0;
                        apartament.Booking = null;
                        await _context.BookingHistories.AddAsync(history);
                        await _context.SaveChangesAsync();
                        freeApartaments.Add(apartament);
                    }

                }
            }
            freeApartaments.AddRange(apartaments.Where(x => x.StatusId == 0));
            return _mapper.Map<List<GetFreeApratamentOutput>>(freeApartaments);
        }

        public async Task UpdateApartamentAsync(CreateOrUpdateApratamentInput input, int id)
        {
            var apartamentToUpdate = await _context.Apartaments.FirstOrDefaultAsync(x=>x.Id==id);
            apartamentToUpdate = _mapper.Map<Apartament>(input);
            await _context.SaveChangesAsync();

        }
    }
}

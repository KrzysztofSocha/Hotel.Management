using AutoMapper;
using Hotel.Management.Entities;
using Hotel.Management.Services.ApartamentBookingService.Dto;
using Microsoft.EntityFrameworkCore;

namespace Hotel.Management.Services.ApartamentBookingService
{
    public class BookingAppService:IBookingAppService
    {
        private readonly HotelContext _context;
        private readonly IMapper _mapper;
        public BookingAppService(HotelContext hotelContext,
            IMapper mapper)
        {
            _context= hotelContext;
            _mapper=mapper;
        }

        public async Task CloseBooking(string apartamentNumber)
        {
            var aparatament = await _context.Apartaments.Include(x => x.Booking).FirstOrDefaultAsync(x => x.Number == apartamentNumber);
            if (aparatament != null && aparatament.Booking != null)
            {
                aparatament.StatusId = 1;
                aparatament.Booking.EndDate = DateTime.Now;
                var history = _mapper.Map<BookingHistory>(aparatament);
                aparatament.Booking = null;
                await _context.BookingHistories.AddAsync(history);
                await _context.SaveChangesAsync();
            }
                
        }

        public async Task CreateBooking(CreateOrUpdateBooking input)
        {
            var apartament = await _context.Apartaments
                .Include(x=>x.Booking)
                .FirstOrDefaultAsync(x => x.Id == input.ApratamentId && x.IsDeleted==false);
            if (apartament == null)
                throw new Exception("Nie istnieje appartament o podanym Id");
            if (apartament.Booking == null)
            {
                if (input.StartDate < input.EndDate)
                {
                    apartament.StatusId = 2;
                    apartament.Booking = _mapper.Map<BookingApartament>(input);
                    var bookingDays = input.EndDate.Subtract(input.StartDate).Days;
                    apartament.Booking.Cost = bookingDays * apartament.PriceForDay;
                    await _context.SaveChangesAsync();
                }
                else
                {
                    throw new Exception("Błędne daty zameldowania");
                }

            }
            else
                throw new Exception("Podany apartament jest zarezerwowany");
        }

        public async Task<GetApartamentBookingInfo> GetBookingInformationAsync(int apartamentId)
        {
            var apratament = await _context.Apartaments.Include(x => x.Booking).FirstOrDefaultAsync(x => x.Id == apartamentId);
            if (apratament != null && apratament.Booking != null)
                return _mapper.Map<GetApartamentBookingInfo>(apratament.Booking);
            else
                throw new Exception("Błąd podczas pobierania informacji o rezerwacji");
        }

        public async Task UpdateBooking(CreateOrUpdateBooking input)
        {
            var apartament = await _context.Apartaments
                .Include(x => x.Booking)
                .FirstOrDefaultAsync(x => x.Id == input.ApratamentId && x.IsDeleted == false);
            if (apartament == null)
                throw new Exception("Nie istnieje appartament o podanym Id");
            if (apartament.Booking != null)
            {
                if (input.StartDate < input.EndDate)
                {
                    apartament.Booking = _mapper.Map<BookingApartament>(input);
                    var bookingDays = input.EndDate.Subtract(input.StartDate).Days;
                    apartament.Booking.Cost = bookingDays * apartament.PriceForDay;
                    await _context.SaveChangesAsync();
                }
                else
                {
                    throw new Exception("Błędne daty zameldowania");
                }

            }
        }
    }
}

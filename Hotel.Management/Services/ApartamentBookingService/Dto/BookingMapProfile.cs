using AutoMapper;
using Hotel.Management.Entities;

namespace Hotel.Management.Services.ApartamentBookingService.Dto
{
    public class BookingMapProfile:Profile
    {
        public BookingMapProfile()
        {
            CreateMap<BookingApartament, GetApartamentBookingInfo>()
               .ForMember(dest => dest.DateBoking,
               opt => opt.MapFrom(src => src.StartDate.ToString("dd.MM.yyyy") + "-" + src.EndDate.ToString("dd.MM.yyyy")));
            CreateMap<CreateBooking, BookingApartament>();
            CreateMap<UpdateBooking, BookingApartament>();
            CreateMap<BookingApartament, UpdateBooking>();
        }
    }
}

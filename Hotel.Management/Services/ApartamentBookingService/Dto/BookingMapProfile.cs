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
               opt => opt.MapFrom(src => src.StartDate.ToString("dd.MM.yyyy") + "-" + src.EndDate.ToString("dd.MM.yyyy")))
               .ForMember(dest=>dest.ClientName, opt=>opt.MapFrom(src=>src.Client.FullName))
               .ForMember(dest=>dest.Email, opt=>opt.MapFrom(src=>src.Client.Email))
               .ForMember(dest=>dest.Phone, opt=>opt.MapFrom(src=>src.Client.Phone));
            CreateMap<CreateBooking, BookingApartament>();
            CreateMap<UpdateBooking, BookingApartament>();
            CreateMap<BookingApartament, UpdateBooking>();
            CreateMap<BookingHistory, GetBookingHistory>()
                .ForMember(dest => dest.ClientName, opt => opt.MapFrom(src => src.Client.FullName))
               .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Client.Email))
               .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.Client.Phone))
               .ForMember(dest => dest.DateBoking, opt => opt.MapFrom(src => src.AccommodationTime));
               
        }
    }
}

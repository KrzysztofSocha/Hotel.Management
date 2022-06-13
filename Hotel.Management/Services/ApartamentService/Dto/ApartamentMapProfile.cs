﻿using AutoMapper;
using Hotel.Management.Entities;

namespace Hotel.Management.Services.ApartamentService.Dto
{
    public class ApartamentMapProfile:Profile
    {
        public ApartamentMapProfile()
        {
            CreateMap<CreateOrUpdateApratamentInput, Apartament>();
            CreateMap<Apartament, CreateOrUpdateApratamentInput>();
            CreateMap<Apartament,GetAllApratamentsOutput>()
                .ForMember(dest=>dest.Status, opt=>opt.MapFrom(src=>src.Status.Name));
            CreateMap<Apartament,GetFreeApratamentOutput>();
            CreateMap<BookingApartament, GetApartamentBookingInformation>()
                .ForMember(dest => dest.DateBoking,
                opt => opt.MapFrom(src => src.StartDate.ToString("dd.MM.yyyy") + "-" + src.StartDate.ToString("dd.MM.yyyy")));
            CreateMap<Apartament, BookingHistory>()
                .ForMember(dest => dest.AccommodationTime,
                opt => opt.MapFrom(src => src.Booking.StartDate.ToString("dd.MM.yyyy") + "-" + src.Booking.StartDate.ToString("dd.MM.yyyy")))
                .ForMember(dest => dest.ApartamentNumber, opt => opt.MapFrom(src => src.Number))
                .ForMember(dest => dest.ClientIndex, opt => opt.MapFrom(src => src.Booking.ClientId))
                .ForMember(dest => dest.Cost, opt => opt.MapFrom(src => src.Booking.Cost));
                
                
        }
    }
}
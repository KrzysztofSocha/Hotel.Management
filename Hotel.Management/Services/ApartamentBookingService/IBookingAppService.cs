using Hotel.Management.Services.ApartamentBookingService.Dto;

namespace Hotel.Management.Services.ApartamentBookingService
{
    public interface IBookingAppService
    {
        Task<GetApartamentBookingInfo> GetBookingInformationAsync(int apartamentId);
        Task CreateBooking(CreateOrUpdateBooking input);
        Task UpdateBooking(CreateOrUpdateBooking input);
        Task CloseBooking(string apartamentNumber);
    }
}

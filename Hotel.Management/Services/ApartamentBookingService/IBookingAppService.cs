using Hotel.Management.Services.ApartamentBookingService.Dto;

namespace Hotel.Management.Services.ApartamentBookingService
{
    public interface IBookingAppService
    {
        Task<GetApartamentBookingInfo> GetBookingInformationAsync(int apartamentId);
        Task<UpdateBooking> GetBookingToEditAsync(int apartamentId);

        Task CreateBooking(CreateBooking input);
        Task UpdateBookingAsync(UpdateBooking input);
        Task CloseBooking(int apartamentId);
        Task<List<GetBookingHistory>> GetBookingHistory();
    }
}

namespace Hotel.Management.Services.ApartamentBookingService.Dto
{
    public class CreateBooking
    {
        public int ApratamentId { get; set; }
        public int ClientId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}

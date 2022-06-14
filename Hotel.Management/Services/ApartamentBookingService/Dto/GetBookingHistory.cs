namespace Hotel.Management.Services.ApartamentBookingService.Dto
{
    public class GetBookingHistory
    {
        public string ApartamentNumber { get; set; }
        public string ClientName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public string DateBoking { get; set; }
        public double Cost { get; set; }
    }
}

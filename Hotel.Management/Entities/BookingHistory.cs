namespace Hotel.Management.Entities
{
    public class BookingHistory
    {
        public int Id { get; set; }
        public int ClientIndex { get; set; }
       
        public Client Client { get; set; }
        public string AccommodationTime { get; set; }
        public string ApartamentNumber { get; set; }
    }
}

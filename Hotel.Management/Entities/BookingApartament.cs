namespace Hotel.Management.Entities
{
    public class BookingApartament
    {
        public int Id { get; set; }
        
        public int ClientId { get; set; }
        public Client Client { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Apartament Apartament { get; set; }

    }
}

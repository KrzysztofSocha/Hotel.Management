namespace Hotel.Management.Entities
{
    public class Apartament
    {
        public int Id { get; set; }
        public string Number  { get; set; }
        public string Description { get; set; }
        public int PeopleCount { get; set; }
        public int Floor { get; set; }
        public double PriceForDay { get; set; }
        public int StatusId { get; set; }
        public BookingStatus Status { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletionTime { get; set; }
        public int? BookingId { get; set; }
        public BookingApartament? Booking { get; set; }
        public Apartament()
        {
            IsDeleted = false;            
        }
       
    }
}

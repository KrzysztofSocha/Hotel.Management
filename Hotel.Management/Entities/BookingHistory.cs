using System.ComponentModel.DataAnnotations;

namespace Hotel.Management.Entities
{
    public class BookingHistory
    {
        public int Id { get; set; }
        [Required]
        public int ClientIndex { get; set; }       
        public Client Client { get; set; }
        [Required]
        public string AccommodationTime { get; set; }
        [Required]
        public double Cost { get; set; }
        [Required]
        public string ApartamentNumber { get; set; }
        
    }
}

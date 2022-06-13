using System.ComponentModel.DataAnnotations;

namespace Hotel.Management.Entities
{
    public class Client
    {
        public int Index { get; set; }
        [Required]
        public string FullName  { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [Phone]
        public string Phone { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        public int AddressId { get; set; }
        public ClientAddress Address { get; set; }
    }
}

namespace Hotel.Management.Entities
{
    public class Client
    {
        public int Index { get; set; }
        public string FullName  { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int AddressId { get; set; }
        public ClientAddress Address { get; set; }
    }
}

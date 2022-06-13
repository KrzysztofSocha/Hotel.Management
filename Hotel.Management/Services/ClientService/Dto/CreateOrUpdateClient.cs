namespace Hotel.Management.Services.ClientService.Dto
{
    public class CreateOrUpdateClient
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime DateOfBirth { get; set; }
        public AddressDto Address { get; set; }
    }
}

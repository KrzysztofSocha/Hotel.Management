namespace Hotel.Management.Entities
{
    public class ClientAddress
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string AddressLine { get; set; }
        public Client Client { get; set; }
    }
}

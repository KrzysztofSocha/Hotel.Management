namespace Hotel.Management.Services.ApartamentService.Dto
{
    public class GetAllApratamentsOutput
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public string Description { get; set; }
        public int PeopleCount { get; set; }
        public int Floor { get; set; }
        public double PriceForDay { get; set; }       
        public string Status { get; set; }
    }
}

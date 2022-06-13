using Hotel.Management.Services.ApartamentService.Dto;

namespace Hotel.Management.Services.ApartamentService
{
    public interface IApartamentAppService
    {
        Task<List<GetAllApratamentsOutput>> GetAllApratamentsAsync();
        Task<List<GetFreeApratamentOutput>> GetFreeApratamentsAsync();
       
        Task CreateApartamentAsync(CreateOrUpdateApratamentInput input); 
        Task UpdateApartamentAsync(CreateOrUpdateApratamentInput input, int id);        
        Task DeleteApartamentAsync(int id);
        //Task ChangeAparatamentBooking();
    }
}

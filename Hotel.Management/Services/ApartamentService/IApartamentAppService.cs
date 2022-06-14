using Hotel.Management.Services.ApartamentService.Dto;

namespace Hotel.Management.Services.ApartamentService
{
    public interface IApartamentAppService
    {
        Task<List<GetAllApratamentsOutput>> GetAllApratamentsAsync();
        Task<List<GetFreeApratamentOutput>> GetFreeApratamentsAsync();
        Task<CreateOrUpdateApratamentInput> GetApratamentToEditAsync(int id);
        Task CreateApartamentAsync(CreateOrUpdateApratamentInput input); 
        Task UpdateApartamentAsync(CreateOrUpdateApratamentInput input);        
        Task DeleteApartamentAsync(int id);
       
    }
}

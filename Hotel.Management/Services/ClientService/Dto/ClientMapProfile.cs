using AutoMapper;
using Hotel.Management.Entities;

namespace Hotel.Management.Services.ClientService.Dto
{
    public class ClientMapProfile:Profile
    {
        public ClientMapProfile()
        {
            CreateMap<CreateOrUpdateClient, Client>();
            CreateMap<AddressDto, ClientAddress>();
            CreateMap< ClientAddress, AddressDto>();
            CreateMap< Client, GetClientOutput>();
            CreateMap< Client, CreateOrUpdateClient>();
        }
    }
}

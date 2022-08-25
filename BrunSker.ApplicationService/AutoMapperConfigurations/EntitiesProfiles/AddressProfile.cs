using AutoMapper;
using BrunSker.ApplicationService.Requests.Address;
using BrunSker.Domain.Entities;

namespace BrunSker.ApplicationService.AutoMapperConfigurations.EntitiesProfiles
{
    public class AddressProfile : Profile
    {
        public AddressProfile()
        {
            CreateMap<Address, AddressUpdateRequest>()
                .ReverseMap();
        }
    }
}

using AutoMapper;
using BrunSker.ApplicationService.Requests.Lease;
using BrunSker.Domain.Entities;

namespace BrunSker.ApplicationService.AutoMapperConfigurations.EntitiesProfiles
{
    public class LeaseProfile : Profile
    {
        public LeaseProfile()
        {
            CreateMap<Lease, LeaseUpdateRequest>()
                .ForMember(lu => lu.AddressUpdateRequest, map => map.MapFrom(l => l.Address))
                .ReverseMap();
        }
    }
}

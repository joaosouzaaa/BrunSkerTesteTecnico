using AutoMapper;
using BrunSker.ApplicationService.Response.Endereco;
using BrunSker.Domain.Entities;

namespace BrunSker.ApplicationService.AutoMapperConfigurations.EntitiesProfiles
{
    public class EnderecoProfile : Profile
    {
        public EnderecoProfile()
        {
            CreateMap<Endereco, EnderecoResponse>()
                .ReverseMap();
        }
    }
}

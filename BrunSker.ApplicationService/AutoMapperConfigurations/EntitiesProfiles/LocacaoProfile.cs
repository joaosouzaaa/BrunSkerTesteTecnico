using AutoMapper;
using BrunSker.ApplicationService.Response.Locacao;
using BrunSker.Domain.Entities;

namespace BrunSker.ApplicationService.AutoMapperConfigurations.EntitiesProfiles
{
    public class LocacaoProfile : Profile
    {
        public LocacaoProfile()
        {
            CreateMap<Locacao, LocacaoResponse>()
                .ForMember(lr => lr.EnderecoResponse, map => map.MapFrom(l => l.Endereco))
                .ReverseMap();
        }
    }
}

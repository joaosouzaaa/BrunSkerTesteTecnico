using BrunSker.ApplicationService.AutoMapperConfigurations;
using BrunSker.ApplicationService.Response.Endereco;
using BrunSker.Domain.Entities;
using ExpectedObjects;
using System.Net;
using TestBuilders;

namespace UnitTests.AutoMapperTests
{
    public class EnderecoAutoMapperTests
    {
        public EnderecoAutoMapperTests()
        {
            AutoMapperConfig.Inicialize();
        }

        [Fact]
        public void Endereco_To_EnderecoResponse()
        {
            var endereco = EnderecoBuilder.NewObject().DomainBuild();
            endereco.MapTo<Endereco, EnderecoResponse>().ToExpectedObject().ShouldMatch(endereco);
        }
    }
}

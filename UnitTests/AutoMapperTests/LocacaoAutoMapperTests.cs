using BrunSker.ApplicationService.AutoMapperConfigurations;
using BrunSker.ApplicationService.Response.Locacao;
using BrunSker.Domain.Entities;
using ExpectedObjects;
using TestBuilders;

namespace UnitTests.AutoMapperTests
{
    public class LocacaoAutoMapperTests
    {
        public LocacaoAutoMapperTests()
        {
            AutoMapperConfig.Inicialize();
        }

        [Fact]
        public void Locacao_To_LocacaoResponse()
        {
            var locacao = LocacaoBuilder.NewObject().DomainBuild();
            var locacaoResponse = locacao.MapTo<Locacao, LocacaoResponse>();

            Assert.Equal(locacao.Id, locacaoResponse.Id);
            Assert.Equal(locacao.Preco, locacaoResponse.Preco);
            Assert.Equal(locacao.EstaLocado, locacaoResponse.EstaLocado);
        }
    }
}

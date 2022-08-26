using BrunSker.ApplicationService.Response.Locacao;
using IntegrationTests.Fixture;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using System.Net;
using System.Reflection;
using TestBuilders;

namespace IntegrationTests
{
    public class LocacaoIntegrationTests : HttpClientFixture
    {
        [Fact]
        public async Task AddAsync_ReturnsSuccess()
        {
            var postResult = await CreateDomainPost();

            Assert.Equal(postResult, HttpStatusCode.OK);
        }

        [Fact]
        public async Task AddAsync_ReturnsFails()
        {
            var locacaoSaveRequest = LocacaoBuilder.NewObject().WithPreco(-2).SaveRequestBuild();

            var postResult = await CreatePostAsync("api/Locacao/adicionar_locacao", locacaoSaveRequest);

            Assert.Equal(postResult, HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task UpdateAsync_ReturnsSuccess()
        {
            var postResult = await CreateDomainPost();
            var locacaoUpdateRequest = LocacaoBuilder.NewObject().WithId(1).UpdateRequestBuild();

            var putResult = await CreatePutAsync("api/Locacao/atualizar_locacao", locacaoUpdateRequest);

            Assert.Equal(postResult, HttpStatusCode.OK);
            Assert.Equal(putResult, HttpStatusCode.OK);
        }

        [Fact]
        public async Task UpdateAsync_ReturnsFails()
        {
            var locacaoUpdateRequest = LocacaoBuilder.NewObject().WithId(1).UpdateRequestBuild();

            var putResult = await CreatePutAsync("api/Locacao/atualizar_locacao", locacaoUpdateRequest);

            Assert.Equal(putResult, HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task DeleteAsync_ReturnsSuccess()
        {
            var postResult = await CreateDomainPost();
            
            var deleteResult = await CreateDeleteAsync("api/Locacao/excluir_locacao?id=1");

            Assert.Equal(postResult, HttpStatusCode.OK);
            Assert.Equal(deleteResult, HttpStatusCode.OK);
        }

        [Fact]
        public async Task DeleteAsync_ReturnsFails()
        {
            var deleteResult = await CreateDeleteAsync("api/Locacao/excluir_locacao?id=1");

            Assert.Equal(deleteResult, HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task GetLocacaoByIdAsync_ReturnsEntity()
        {
            var postResult = await CreateDomainPost();

            var getResult = await CreateGetAsync<LocacaoResponse>("api/Locacao/achar_locacao?id=1");

            Assert.Equal(postResult, HttpStatusCode.OK);
            Assert.NotNull(getResult);
        }

        [Fact]
        public async Task GetAllLocacoesAsync_ReturnsList()
        {
            var postFirstResult = await CreateDomainPost();
            var postSecondResult = await CreateDomainPost();

            var getAllResult = await CreateGetAllAsync<LocacaoResponse>("api/Locacao/achar_todas_locacoes");

            Assert.Equal(postFirstResult, HttpStatusCode.OK);
            Assert.Equal(postSecondResult, HttpStatusCode.OK);
            Assert.Equal(getAllResult.Count, 2);
        }

        [Fact]
        public async Task GetAllLocacoesAsync_ReturnsEmptyList()
        {
            var getAllResult = await CreateGetAllAsync<LocacaoResponse>("api/Locacao/achar_todas_locacoes");

            Assert.Empty(getAllResult);
        }

        private async Task<HttpStatusCode> CreateDomainPost()
        {
            var locacaoSaveRequest = LocacaoBuilder.NewObject().SaveRequestBuild();

            return await CreatePostAsync("api/Locacao/adicionar_locacao", locacaoSaveRequest);
        }
    }
}

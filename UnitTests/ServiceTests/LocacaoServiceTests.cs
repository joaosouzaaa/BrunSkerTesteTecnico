using Bogus.DataSets;
using BrunSker.ApplicationService.AutoMapperConfigurations;
using BrunSker.ApplicationService.Interfaces;
using BrunSker.ApplicationService.Services;
using BrunSker.Business.Interfaces.Repositories;
using BrunSker.Business.Settings.NotificationSettings;
using BrunSker.Domain.Entities;
using Moq;
using TestBuilders;

namespace UnitTests.ServiceTests
{
    public class LocacaoServiceTests
    {
        Mock<ILocacaoRepository> _repository;
        Mock<IEnderecoService> _enderecoService;
        NotificationHandler _notification;
        LocacaoService _service;

        public LocacaoServiceTests()
        {
            _repository = new Mock<ILocacaoRepository>();
            _enderecoService = new Mock<IEnderecoService>();
            _notification = new NotificationHandler();
            _service = new LocacaoService(_repository.Object, _enderecoService.Object, _notification);

            AutoMapperConfig.Inicialize();
        }

        [Fact]
        public async Task AddAsync_ReturnsTrue()
        {
            var locacaoSaveRequest = LocacaoBuilder.NewObject().SaveRequestBuild();
            var endereco = EnderecoBuilder.NewObject().DomainBuild();
            _enderecoService.Setup(es => es.GetAddressByCep(locacaoSaveRequest.Cep)).ReturnsAsync(endereco);
            _repository.Setup(r => r.AddAsync(It.IsAny<Locacao>())).ReturnsAsync(true);

            var serviceResult = await _service.AddAsync(locacaoSaveRequest);

            _enderecoService.Verify(es => es.GetAddressByCep(locacaoSaveRequest.Cep), Times.Once());
            _repository.Verify(r => r.AddAsync(It.IsAny<Locacao>()), Times.Once());
            Assert.True(serviceResult);
        }

        [Fact]
        public async Task AddAsync_PriceLessThan0_ReturnsFalse()
        {
            var invalidPrice = -20.2m;
            var locacaoSaveRequest = LocacaoBuilder.NewObject().WithPreco(invalidPrice).SaveRequestBuild();

            var serviceResult = await _service.AddAsync(locacaoSaveRequest);

            _enderecoService.Verify(es => es.GetAddressByCep(locacaoSaveRequest.Cep), Times.Never());
            _repository.Verify(r => r.AddAsync(It.IsAny<Locacao>()), Times.Never());
            Assert.False(serviceResult);
        }

        [Fact]
        public async Task AddAsync_CepBiggerThan8chars_ReturnsFalse()
        {
            var invalidCep = "121212122122222";
            var locacaoSaveRequest = LocacaoBuilder.NewObject().WithCep(invalidCep).SaveRequestBuild();

            var serviceResult = await _service.AddAsync(locacaoSaveRequest);

            _enderecoService.Verify(es => es.GetAddressByCep(locacaoSaveRequest.Cep), Times.Never());
            _repository.Verify(r => r.AddAsync(It.IsAny<Locacao>()), Times.Never());
            Assert.False(serviceResult);
        }

        [Fact]
        public async Task AddAsync_AdressDoesNotExist_ReturnsFalse()
        {
            var locacaoSaveRequest = LocacaoBuilder.NewObject().SaveRequestBuild();
            _enderecoService.Setup(es => es.GetAddressByCep(locacaoSaveRequest.Cep));

            var serviceResult = await _service.AddAsync(locacaoSaveRequest);

            _enderecoService.Verify(es => es.GetAddressByCep(locacaoSaveRequest.Cep), Times.Once());
            _repository.Verify(r => r.AddAsync(It.IsAny<Locacao>()), Times.Never());
            Assert.False(serviceResult);
        }

        [Fact]
        public async Task UpdateAsync_DoesNotUpdateAddress_ReturnsTrue()
        {
            var endereco = EnderecoBuilder.NewObject().WithCep("29705-042").DomainBuild();
            var locacaoUpdateRequest = LocacaoBuilder.NewObject().WithCep("29705042").UpdateRequestBuild();
            var locacao = LocacaoBuilder.NewObject().WithEndereco(endereco).DomainBuild();
            _repository.Setup(r => r.GetLocacaoByIdAsync(locacaoUpdateRequest.Id)).ReturnsAsync(locacao);
            _repository.Setup(r => r.UpdateAsync(It.IsAny<Locacao>())).ReturnsAsync(true);

            var serviceResult = await _service.UpdateAsync(locacaoUpdateRequest);

            _repository.Verify(r => r.GetLocacaoByIdAsync(locacaoUpdateRequest.Id), Times.Once());
            _repository.Verify(r => r.UpdateAsync(It.IsAny<Locacao>()), Times.Once());
            _enderecoService.Verify(es => es.GetAddressByCep(It.IsAny<string>()), Times.Never());
            Assert.True(serviceResult);
        }

        [Fact]
        public async Task UpdateAsync_UpdateAddress_ReturnsTrue()
        {
            var locacaoUpdateRequest = LocacaoBuilder.NewObject().WithCep("29705042").UpdateRequestBuild();
            var locacao = LocacaoBuilder.NewObject().DomainBuild();
            var endereco = EnderecoBuilder.NewObject().DomainBuild();
            _repository.Setup(r => r.GetLocacaoByIdAsync(locacaoUpdateRequest.Id)).ReturnsAsync(locacao);
            _enderecoService.Setup(es => es.GetAddressByCep(It.IsAny<string>())).ReturnsAsync(endereco);
            _repository.Setup(r => r.UpdateAsync(It.IsAny<Locacao>())).ReturnsAsync(true);

            var serviceResult = await _service.UpdateAsync(locacaoUpdateRequest);

            _repository.Verify(r => r.GetLocacaoByIdAsync(locacaoUpdateRequest.Id), Times.Once());
            _repository.Verify(r => r.UpdateAsync(It.IsAny<Locacao>()), Times.Once());
            _enderecoService.Verify(es => es.GetAddressByCep(It.IsAny<string>()), Times.Once());
            Assert.True(serviceResult);
        }

        [Fact]
        public async Task UpdateAsync_LocacaoDoesNotExist_ReturnsFalse()
        {
            var locacaoUpdateRequest = LocacaoBuilder.NewObject().WithCep("29705042").UpdateRequestBuild();
            _repository.Setup(r => r.GetLocacaoByIdAsync(locacaoUpdateRequest.Id));
            
            var serviceResult = await _service.UpdateAsync(locacaoUpdateRequest);

            _repository.Verify(r => r.GetLocacaoByIdAsync(locacaoUpdateRequest.Id), Times.Once());
            _repository.Verify(r => r.UpdateAsync(It.IsAny<Locacao>()), Times.Never());
            _enderecoService.Verify(es => es.GetAddressByCep(It.IsAny<string>()), Times.Never());
            Assert.False(serviceResult);
        }

        [Fact]
        public async Task UpdateAsync_CepLengthBiggerthan8chars_ReturnsFalse()
        {
            var locacaoUpdateRequest = LocacaoBuilder.NewObject().WithCep("121212154542").UpdateRequestBuild();
            var locacao = LocacaoBuilder.NewObject().DomainBuild();
            _repository.Setup(r => r.GetLocacaoByIdAsync(locacaoUpdateRequest.Id)).ReturnsAsync(locacao);

            var serviceResult = await _service.UpdateAsync(locacaoUpdateRequest);

            _repository.Verify(r => r.GetLocacaoByIdAsync(locacaoUpdateRequest.Id), Times.Once());
            _repository.Verify(r => r.UpdateAsync(It.IsAny<Locacao>()), Times.Never());
            _enderecoService.Verify(es => es.GetAddressByCep(It.IsAny<string>()), Times.Never());
            Assert.False(serviceResult);
        }

        [Fact]
        public async Task UpdateAsync_AdressDoesNotExist_ReturnsFalse()
        {
            var locacaoUpdateRequest = LocacaoBuilder.NewObject().WithCep("29705042").UpdateRequestBuild();
            var locacao = LocacaoBuilder.NewObject().DomainBuild();
            _repository.Setup(r => r.GetLocacaoByIdAsync(locacaoUpdateRequest.Id)).ReturnsAsync(locacao);
            _enderecoService.Setup(es => es.GetAddressByCep(It.IsAny<string>()));

            var serviceResult = await _service.UpdateAsync(locacaoUpdateRequest);

            _repository.Verify(r => r.GetLocacaoByIdAsync(locacaoUpdateRequest.Id), Times.Once());
            _repository.Verify(r => r.UpdateAsync(It.IsAny<Locacao>()), Times.Never());
            _enderecoService.Verify(es => es.GetAddressByCep(It.IsAny<string>()), Times.Once());
            Assert.False(serviceResult);
        }

        [Fact]
        public async Task DeleteAsync_ReturnsTrue()
        {
            var id = 1;
            _repository.Setup(r => r.HaveObjectInDb(l => l.Id == id)).ReturnsAsync(true);
            _repository.Setup(r => r.DeleteAsync(id)).ReturnsAsync(true);

            var serviceResult = await _service.DeleteAsync(id);

            _repository.Verify(r => r.HaveObjectInDb(l => l.Id == id), Times.Once());
            _repository.Verify(r => r.DeleteAsync(id), Times.Once());
            Assert.True(serviceResult);
        }

        [Fact]
        public async Task DeleteAsync_EntityDoesNotExist_ReturnsFalse()
        {
            var id = 1;
            _repository.Setup(r => r.HaveObjectInDb(l => l.Id == id)).ReturnsAsync(false);

            var serviceResult = await _service.DeleteAsync(id);

            _repository.Verify(r => r.HaveObjectInDb(l => l.Id == id), Times.Once());
            _repository.Verify(r => r.DeleteAsync(id), Times.Never());
            Assert.False(serviceResult);
        }

        [Fact]
        public async Task GetLocacaoByIdAsync_ReturnsEntity()
        {
            var id = 1;
            var locacao = LocacaoBuilder.NewObject().DomainBuild();
            _repository.Setup(r => r.GetLocacaoByIdAsync(id)).ReturnsAsync(locacao);

            var serviceResult = await _service.GetLocacaoByIdAsync(id);

            _repository.Verify(r => r.GetLocacaoByIdAsync(id), Times.Once());
            Assert.NotNull(serviceResult);
        }

        [Fact]
        public async Task GetLocacaoByIdAsync_ReturnsNull()
        {
            var id = 1;
            _repository.Setup(r => r.GetLocacaoByIdAsync(id));

            var serviceResult = await _service.GetLocacaoByIdAsync(id);

            _repository.Verify(r => r.GetLocacaoByIdAsync(id), Times.Once());
            Assert.Null(serviceResult);
        }

        [Fact]
        public async Task GetAllLocacoesAsync_ReturnsEntities()
        {
            var locacaoList = new List<Locacao>()
            {
                LocacaoBuilder.NewObject().DomainBuild(),
                LocacaoBuilder.NewObject().DomainBuild()
            };
            _repository.Setup(r => r.GetAllLocacoesAsync()).ReturnsAsync(locacaoList);

            var serviceResult = await _service.GetAllLocacoesAsync();

            _repository.Verify(r => r.GetAllLocacoesAsync(), Times.Once());
            Assert.Equal(serviceResult.Count, locacaoList.Count);
        }

        [Fact]
        public async Task GetAllLocacoesAsync_ReturnsEmptyList()
        {
            _repository.Setup(r => r.GetAllLocacoesAsync());

            var serviceResult = await _service.GetAllLocacoesAsync();

            _repository.Verify(r => r.GetAllLocacoesAsync(), Times.Once());
            Assert.Empty(serviceResult);
        }
    }
}

using BrunSker.Api.Controllers;
using BrunSker.ApplicationService.Interfaces;
using BrunSker.ApplicationService.Requests.Lease;
using BrunSker.ApplicationService.Response.Locacao;
using BrunSker.Domain.Entities;
using Moq;
using TestBuilders;

namespace UnitTests.ControllerTests
{
    public class LocacaoControllerTests
    {
        Mock<ILocacaoService> _service;
        LocacaoController _controller;

        public LocacaoControllerTests()
        {
            _service = new Mock<ILocacaoService>();
            _controller = new LocacaoController(_service.Object); 
        }

        [Fact]
        public async Task AddAsync_ReturnsTrue()
        {
            var locacaoSaveRequest = LocacaoBuilder.NewObject().SaveRequestBuild();
            _service.Setup(s => s.AddAsync(locacaoSaveRequest)).ReturnsAsync(true);

            var controllerResult = await _controller.AddAsync(locacaoSaveRequest);

            _service.Verify(s => s.AddAsync(locacaoSaveRequest), Times.Once());
            Assert.True(controllerResult);
        }

        [Fact]
        public async Task AddAsync_ReturnsFalse()
        {
            var locacaoSaveRequest = LocacaoBuilder.NewObject().SaveRequestBuild();
            _service.Setup(s => s.AddAsync(locacaoSaveRequest)).ReturnsAsync(false);

            var controllerResult = await _controller.AddAsync(locacaoSaveRequest);

            _service.Verify(s => s.AddAsync(locacaoSaveRequest), Times.Once());
            Assert.False(controllerResult);
        }

        [Fact]
        public async Task UpdateAsync_ReturnsTrue()
        {
            var locacaoUpdateRequest = LocacaoBuilder.NewObject().UpdateRequestBuild();
            _service.Setup(s => s.UpdateAsync(locacaoUpdateRequest)).ReturnsAsync(true);

            var controllerResult = await _controller.UpdateAsync(locacaoUpdateRequest);

            _service.Verify(s => s.UpdateAsync(locacaoUpdateRequest), Times.Once());
            Assert.True(controllerResult);
        }

        [Fact]
        public async Task UpdateAsync_ReturnsFalse()
        {
            var locacaoUpdateRequest = LocacaoBuilder.NewObject().UpdateRequestBuild();
            _service.Setup(s => s.UpdateAsync(locacaoUpdateRequest)).ReturnsAsync(false);

            var controllerResult = await _controller.UpdateAsync(locacaoUpdateRequest);

            _service.Verify(s => s.UpdateAsync(locacaoUpdateRequest), Times.Once());
            Assert.False(controllerResult);
        }

        [Fact]
        public async Task DeleteAsync_ReturnsTrue()
        {
            var id = 1;
            _service.Setup(s => s.DeleteAsync(id)).ReturnsAsync(true);

            var controllerResult = await _controller.DeleteAsync(id);

            _service.Verify(s => s.DeleteAsync(id), Times.Once());
            Assert.True(controllerResult);
        }

        [Fact]
        public async Task DeleteAsync_ReturnsFalse()
        {
            var id = 1;
            _service.Setup(s => s.DeleteAsync(id)).ReturnsAsync(false);

            var controllerResult = await _controller.DeleteAsync(id);

            _service.Verify(s => s.DeleteAsync(id), Times.Once());
            Assert.False(controllerResult);
        }

        [Fact]
        public async Task GetLocacaoById_ReturnsEntity()
        {
            var id = 1;
            var locacaoResponse = LocacaoBuilder.NewObject().ResponseBuild();
            _service.Setup(s => s.GetLocacaoByIdAsync(id)).ReturnsAsync(locacaoResponse);

            var controllerResult = await _controller.GetLocacaoByIdAsync(id);

            _service.Verify(s => s.GetLocacaoByIdAsync(id), Times.Once());
            Assert.Equal(locacaoResponse, controllerResult);
        }

        [Fact]
        public async Task GetLocacaoById_ReturnsNull()
        {
            var id = 1;
            _service.Setup(s => s.GetLocacaoByIdAsync(id));

            var controllerResult = await _controller.GetLocacaoByIdAsync(id);

            _service.Verify(s => s.GetLocacaoByIdAsync(id), Times.Once());
            Assert.Null(controllerResult);
        }

        [Fact]
        public async Task GetAllLocacoesAsync_ReturnsList()
        {
            var locacaoResponseList = new List<LocacaoResponse>()
            {
                LocacaoBuilder.NewObject().ResponseBuild(),
                LocacaoBuilder.NewObject().ResponseBuild()
            };
            _service.Setup(s => s.GetAllLocacoesAsync()).ReturnsAsync(locacaoResponseList);

            var controllerResult = await _controller.GetAllLocacoesAsync();

            _service.Verify(s => s.GetAllLocacoesAsync(), Times.Once());
            Assert.Equal(controllerResult, locacaoResponseList);
        }

        [Fact]
        public async Task GetAllLocacoesAsync_ReturnsNull()
        {
            _service.Setup(s => s.GetAllLocacoesAsync());

            var controllerResult = await _controller.GetAllLocacoesAsync();

            _service.Verify(s => s.GetAllLocacoesAsync(), Times.Once());
            Assert.Null(controllerResult);
        }
    }
}

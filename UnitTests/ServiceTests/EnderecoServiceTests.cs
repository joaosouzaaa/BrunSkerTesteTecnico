using BrunSker.ApplicationService.Services;
using BrunSker.Business.Settings.NotificationSettings;

namespace UnitTests.ServiceTests
{
    public class EnderecoServiceTests
    {
        NotificationHandler _notification;
        EnderecoService _service;

        public EnderecoServiceTests()
        {
            _notification = new NotificationHandler();
            _service = new EnderecoService(_notification);
        }

        [Fact]
        public async Task GetAddressByCep_ReturnsAddress()
        {
            var validCep = "29705042";

            var serviceResult = await _service.GetAddressByCep(validCep);

            Assert.NotNull(serviceResult);
        }

        [Fact]
        public async Task GetAddressByCep_CepDoesNotExist_ReturnsNull()
        {
            var invalidCep = "12345678";

            var serviceResult = await _service.GetAddressByCep(invalidCep);

            Assert.Null(serviceResult);
        }
    }
}

using BrunSker.Business.Extensions;

namespace UnitTests.ExtensionsTests
{
    public class FormatExtensionTests
    {
        [Fact]
        public void FormatStringWithNumbers_ReturnsOnlyNumber()
        {
            var cep = "11702-490";
            var newCep = cep.CleanCaracters();

            Assert.Equal(newCep, "11702490");
        }
    }
}

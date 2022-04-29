using Shoppinho.Sdk.Utils.Extensions;
using Xunit;

namespace Shoppinho.Sdk.Utils.Testes.Extensions
{
    public class StringExtensionsTests
    {
        [Theory]
        [InlineData("43.746.421/0001-79", "43746421000179")]
        [InlineData("20.167.609/0001-67", "20167609000167")]
        [InlineData("14.071.491/0001-76", "14071491000176")]
        [InlineData("94.456.541/0001-72", "94456541000172")]
        [InlineData("35.887.343/0001-02", "35887343000102")]
        [InlineData("458.598.630-80", "45859863080")]
        [InlineData("071.596.950-11", "07159695011")]
        [InlineData("906.485.600-15", "90648560015")]
        [InlineData("390.761.120-96", "39076112096")]
        [InlineData("+39076112096", "39076112096")]
        public void DeveraExtrairSomenteNumeros(string numeroComPontos, string valorEsperado)
        {
            Assert.Equal(valorEsperado, numeroComPontos.SomenteNumeros());
        }
    }
}
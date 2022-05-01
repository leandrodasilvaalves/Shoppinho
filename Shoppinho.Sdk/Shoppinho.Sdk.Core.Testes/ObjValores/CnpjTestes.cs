using Bogus;
using Bogus.Extensions.Brazil;
using Shoppinho.Sdk.Core.ObjValores;
using Xunit;

namespace Shoppinho.Sdk.Core.Testes.ObjValores
{
    public class CnpjTestes
    {
        private readonly Faker _faker = new Faker("pt_BR");

        [Fact]        
        public void DeveraSerSucessoQuandoInformarUmCnpjValido()
        {
            var cnpj = new Cnpj(_faker.Company.Cnpj());
            Assert.True(cnpj.Validar());
            Assert.True(cnpj.Notificaoes.Count == 0);
        }        

        [Fact]
        public void DeveraFalharquandoInformarCnpjInvalido()
        {
            var numero = _faker.Company.Cnpj(false);            
            int criarDigitoFake(int index) => int.Parse(numero[index].ToString()) + 1;

            numero = $"{numero.Substring(0, 11)}{criarDigitoFake(12)}{criarDigitoFake(13)}";

            var cnpj = new Cnpj(numero);
            Assert.False(cnpj.Validar());
            Assert.True(cnpj.Notificaoes.Count > 0);
        }


        [Theory]
        [InlineData("1675875300010")]
        [InlineData("167587530001091")]
        [InlineData("16.758.753/0001-094")]
        [InlineData("123")]

        public void DeveraFalharQuandoTamanhoDiferenteDeQuatorze(string numero)
        {
            var cnpj = new Cnpj(numero);
            Assert.False(cnpj.Validar());
            Assert.True(cnpj.Notificaoes.Count > 0);
        }

        [Theory]
        [InlineData("00.000.000/0000-00")]
        [InlineData("11.111.111/1111-11")]
        [InlineData("22.222.222/2222-22")]
        [InlineData("33.333.333/3333-33")]
        [InlineData("44.444.444/4444-44")]
        [InlineData("55.555.555/5555-55")]
        [InlineData("66.666.666/6666-66")]
        [InlineData("77.777.777/7777-77")]
        [InlineData("88.888.888/8888-88")]
        [InlineData("99.999.999/9999-99")]
        public void DeveraFalharQuandoInformarTodosDigitosIguais(string numero)
        {
            var cnpj = new Cnpj(numero);
            Assert.False(cnpj.Validar());
            Assert.True(cnpj.Notificaoes.Count > 0);
        }

        [Theory]
        [InlineData("43746421000179", "43.746.421/0001-79")]
        [InlineData("20167609000167", "20.167.609/0001-67")]
        [InlineData("14071491000176", "14.071.491/0001-76")]
        [InlineData("94456541000172", "94.456.541/0001-72")]
        [InlineData("35887343000102", "35.887.343/0001-02")]
        [InlineData("01002003000100", "01.002.003/0001-00")]
        public void DeveraRetornarNumeroFormatado(string numeroSemFormatacao, string valorEsperado)
        {
            var cnpj = new Cnpj(numeroSemFormatacao);            
            Assert.Equal(valorEsperado, cnpj.NumeroFormatado);
            Assert.True(cnpj.Notificaoes.Count == 0);
        }
    }
}
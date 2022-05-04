using Shoppinho.Sdk.Core.ObjValores;
using Xunit;

namespace Shoppinho.Sdk.Core.Testes.ObjValores
{
    public class TelefoneTestes
    {
        [Theory]
        [InlineData("61", "991077157", "55")]
        [InlineData("(61)", "9.9107-7157", "+55")]
        public void DeveraSerVerdadeiroQuandoInformarUmTelefoneValido(string ddd, string numero, string codigoPais)
        {
            var telefone = new Telefone(ddd, numero, codigoPais);

            telefone.Validar();

            Assert.True(telefone.EhValido);
            Assert.True(telefone.Erros.Count == 0);
        }

        [Theory]
        [InlineData("6")]
        [InlineData("611")]
        [InlineData("")]
        public void DeveraSerFalsoQuandoInformarDDDInvalido(string ddd)
        {
            var telefone = new Telefone(ddd, "991077157");

            telefone.Validar();
            
            Assert.False(telefone.EhValido);
            Assert.True(telefone.Erros.Count > 0);
        }

        [Theory]
        [InlineData("9")]
        [InlineData("91077157")]
        [InlineData("9910771572")]
        public void DeveraSerFalsoQuandoInformarNumeroInvalido(string numero)
        {
            var telefone = new Telefone("61", numero);

            telefone.Validar();
            
            Assert.False(telefone.EhValido);
            Assert.True(telefone.Erros.Count > 0);
        }

        [Theory]
        [InlineData("")]
        [InlineData("5")]
        [InlineData("555")]
        public void DeveraSerFalsoQuandoInformarCodigoPaisInvalido(string codigoPais)
        {
            var telefone = new Telefone("61", "991077157", codigoPais);

            telefone.Validar();
            
            Assert.False(telefone.EhValido);
            Assert.True(telefone.Erros.Count > 0);            
        }

        [Theory]
        [InlineData("+55 (61) 9.9107-7157")]
        [InlineData("(61) 9.9107-7157")]
        [InlineData("55 61 991077157")]
        [InlineData("61 991077157")]
        [InlineData("5561991077157")]
        [InlineData("61991077157")]
        public void DeveraServerVerdadeiroQuandoInformarUmTelefoneValidoNoTryParse(string numero)
        {
            Assert.True(Telefone.TryParse(numero, out var telefone));
        }
    }
}
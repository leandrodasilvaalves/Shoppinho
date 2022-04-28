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
            Assert.True(telefone.Validar());
            Assert.True(telefone.Notificaoes.Count == 0);
        }

        [Theory]
        [InlineData("6")]
        [InlineData("611")]
        [InlineData("")]
        public void DeveraSerFalsoQuandoInformarDDDInvalido(string ddd)
        {
            var telefone = new Telefone(ddd, "991077157");
            Assert.False(telefone.Validar());
            Assert.True(telefone.Notificaoes.Count > 0);
        }

        [Theory]
        [InlineData("9")]
        [InlineData("91077157")]
        [InlineData("9910771572")]
        public void DeveraSerFalsoQuandoInformarNumeroInvalido(string numero)
        {
            var telefone = new Telefone("61", numero);
            Assert.False(telefone.Validar());
            Assert.True(telefone.Notificaoes.Count > 0);
        }

        [Theory]
        [InlineData("")]
        [InlineData("5")]
        [InlineData("555")]
        public void DeveraSerFalsoQuandoInformarCodigoPaisInvalido(string codigoPais)
        {
            var telefone = new Telefone("61", "991077157", codigoPais);
            Assert.False(telefone.Validar());
            Assert.True(telefone.Notificaoes.Count > 0);            
        }
    }
}
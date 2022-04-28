using Shoppinho.Sdk.Core.ObjValores;
using Xunit;

namespace Shoppinho.Sdk.Core.Testes.ObjValores
{
    public class CidadeTestes
    {
        [Fact]
        public void DeveraSerVerdadeiroQuandoInformarCidadeEstadoValidos()
        {
            var cidade = new Cidade("Santa Helena de Goiás", "GO");
            Assert.True(cidade.Validar());
            Assert.True(cidade.Notificaoes.Count == 0);
        }

        [Theory]
        [InlineData("")]
        [InlineData("A")]
        public void DeveraSerFalsoQuandoInformarCidadeInvalida(string nomeCidade)
        {
            var cidade = new Cidade(nomeCidade, "DF");
            Assert.False(cidade.Validar());
            Assert.True(cidade.Notificaoes.Count > 0);
        }

        [Theory]
        [InlineData("Distrito Federal")]
        [InlineData("DF1")]
        [InlineData("D")]
        [InlineData("")]
        public void DeveraSerFalsoQuandoInformarEstadoInvalido(string estado)
        {
            var cidade = new Cidade("Brasília", estado);
            Assert.False(cidade.Validar());
            Assert.True(cidade.Notificaoes.Count > 0);
        }

        [Theory]
        [InlineData("", "Distrito Federal")]
        [InlineData("", "DF1")]
        [InlineData("A", "D")]
        [InlineData("", "")]
        public void DeveraSerFalsoQuandoInformarCidadeEstadoInvalidos(string nomeCidade, string estado)
        {
            var cidade = new Cidade("Brasília", estado);
            Assert.False(cidade.Validar());
            Assert.True(cidade.Notificaoes.Count > 0);
        }
    }
}
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
            cidade.Validar();
            
            Assert.True(cidade.EhValido);
            Assert.True(cidade.Erros.Count == 0);
        }

        [Theory]
        [InlineData("")]
        [InlineData("A")]
        public void DeveraSerFalsoQuandoInformarCidadeInvalida(string nomeCidade)
        {
            var cidade = new Cidade(nomeCidade, "DF");
            cidade.Validar();

            Assert.False(cidade.EhValido);
            Assert.True(cidade.Erros.Count > 0);
        }

        [Theory]
        [InlineData("Distrito Federal")]
        [InlineData("DF1")]
        [InlineData("D")]
        [InlineData("")]
        public void DeveraSerFalsoQuandoInformarEstadoInvalido(string estado)
        {
            var cidade = new Cidade("Brasília", estado);
            cidade.Validar();

            Assert.False(cidade.EhValido);
            Assert.True(cidade.Erros.Count > 0);
        }

        [Theory]
        [InlineData("", "Distrito Federal")]
        [InlineData("", "DF1")]
        [InlineData("A", "D")]
        [InlineData("", "")]
        public void DeveraSerFalsoQuandoInformarCidadeEstadoInvalidos(string nomeCidade, string estado)
        {
            var cidade = new Cidade("Brasília", estado);
            cidade.Validar();

            Assert.False(cidade.EhValido);
            Assert.True(cidade.Erros.Count > 0);
        }
    }
}
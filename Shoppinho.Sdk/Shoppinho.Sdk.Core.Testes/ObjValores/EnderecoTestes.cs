using Shoppinho.Sdk.Core.ObjValores;
using Xunit;

namespace Shoppinho.Sdk.Core.Testes.ObjValores
{
    public class EnderecoTestes
    {

        [Theory]   
        [InlineData(Endereco.MinLength)]     
        [InlineData(Endereco.MaxLength)]     
        public void DeveraSerVerdadeiroQuandoInformarEnderecoValidoLogradouroComTamanhoMaximo(int quantidadeCaracteres)
        {
            var endereco = new Endereco(
                new string('a', quantidadeCaracteres),
                "Qd 05",
                "18",
                new Cidade("Santa Helena de Goiás", "GO"),
                "75.920-000"
            );
            Assert.True(endereco.Validar());
            Assert.True(endereco.Notificaoes.Count == 0);
        }

        [Theory]
        [InlineData("")]
        [InlineData("Ra")]
        public void DeveraSerFalsoQuandoInformarLogradouroInvalido(string logradouro)
        {
            var endereco = new Endereco(
                logradouro,
                "Qd 05",
                "18",
                new Cidade("Santa Helena de Goiás", "GO"),
                "75.920-000"
            );
            Assert.False(endereco.Validar());
            Assert.True(endereco.Notificaoes.Count > 0);
        }

        [Fact]
        public void DeveraSerFalsoQuandoInformarLogradouroComMaisDeCemCaracteres()
        {
            var logradouro = new string('a', Endereco.MaxLength + 1);
            var endereco = new Endereco(
                logradouro,
                "Qd 05",
                "18",
                new Cidade("Santa Helena de Goiás", "GO"),
                "75.920-000"
            );
            Assert.False(endereco.Validar());
            Assert.True(endereco.Notificaoes.Count > 0);
        }

        [Theory]
        [InlineData("Abcd.75")]
        [InlineData("72.835.9563")]
        [InlineData("")]
        [InlineData("abcasdwe")]
        [InlineData("!@#$%&()")]
        public void DeveraSerFalsoQuandoInformarCepInvalido(string cep)
        {
            var endereco = new Endereco(
                "Rua Rubi",
                "Qd 05",
                "18",
                new Cidade("Santa Helena de Goiás", "GO"),
                cep
            );
            Assert.False(endereco.Validar());
            Assert.True(endereco.Notificaoes.Count > 0);
        }
    }
}
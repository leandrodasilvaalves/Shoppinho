using Shoppinho.Sdk.Core.ObjValores;
using Xunit;

namespace Shoppinho.Sdk.Core.Testes.ObjValores
{
    public class EmailTestes
    {

        [Theory]
        [InlineData("email@email.com")]
        [InlineData("contato@gmail.com")]
        [InlineData("contato@hotmail.com")]
        [InlineData("contato@outlook.com")]
        [InlineData("contato@outlook.com.br")]
        [InlineData("contato@empresa.com.br")]
        [InlineData("contato@empresa.com")]
        [InlineData("contato@live.com")]
        [InlineData("contato@yahoo.com")]
        [InlineData("contato@yahoo.com.br")]
        [InlineData("contato_comercial@empresa.com.br")]
        [InlineData("contato.comercial@empresa.com.br")]
        [InlineData("contato1@empresa.com.br")]
        public void DeveraSerVerdadeiroQuandoInformarUmEnderecoDeEmailValido(string enderecoEmail)
        {
            var email = new Email(enderecoEmail);
            email.Validar();

            Assert.True(email.EhValido);
            Assert.True(email.Erros.Count == 0);
        }

        [Theory]
        [InlineData("emailemail.com")]        
        [InlineData("contato@hotmailcom")]
        [InlineData("contato@hotmail..com")]
        [InlineData("contatooutlook.com")]
        [InlineData("contato@outlook_com_br")]
        [InlineData("contato@empresa-com+br")]
        [InlineData("@empresa.com")]
        [InlineData("contato@")]        
        public void DeveraSerFalsoQuandoInformarUmEnderecoDeEmailInvalido(string enderecoEmail)
        {
            var email = new Email(enderecoEmail);
            email.Validar();
            
            Assert.False(email.EhValido);
            Assert.True(email.Erros.Count > 0);
        }
    }
}
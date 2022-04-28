using Shoppinho.Sdk.Core.Entidades;
using Shoppinho.Sdk.Core.ObjValores;

namespace Shoppinho.Lojas.Api.Dominio.Entidades
{
    public class Loja : Entidade
    {
        protected Loja(){} //EF
        public Loja(string nomeFantasia, string razaoSocial, Cnpj cnpj, List<Email> emails)
        {
            NomeFantasia = nomeFantasia;
            RazaoSocial = razaoSocial;
            CNPJ = cnpj;
            Emails = emails;
        }

        public string NomeFantasia { get; private set; }
        public string RazaoSocial { get; private set; }
        public Cnpj CNPJ { get; private set; }        
        public string InscricaoEstadual { get; set; }
        public List<Endereco> Enderecos { get; set; } //TODO: trasformar para IReadOnlyCollection
        public List<Telefone> Telefones { get; set; }  //TODO: trasformar para IReadOnlyCollection
        public List<Email> Emails { get; private set; }  //TODO: trasformar para IReadOnlyCollection

        public void IncluirEmail(string enderecoEmail, bool principal = false)
        {
            var email = new Email(enderecoEmail, principal);
            //if(email.Validar())
                Emails.Add(email);
        }
    }
}

//TODO: criar um objeto de valor para InscricaoEstadual no sdk
//https://sistemas1.sefaz.ma.gov.br/portalsefaz/pdf?codigo=1524#:~:text=na%20Inscri%C3%A7%C3%A3o%20Estadual-,Formato%3A%20num%C3%A9rico%20Tamanho%3A%209%20d%C3%ADgitos%2C%20sendo%3A,calculado%20atrav%C3%A9s%20do%20m%C3%B3dulo%2011.        
using System.Collections.ObjectModel;
using Shoppinho.Sdk.Core.Entidades;
using Shoppinho.Sdk.Core.ObjValores;

namespace Shoppinho.Lojas.Api.Dominio.Entidades
{
    public class Loja : Entidade
    {

        private readonly IList<Email> _emails;
        private readonly IList<Telefone> _telefones;
        private readonly IList<Endereco> _enderecos;

        protected Loja() { } //EF
        public Loja(string nomeFantasia, string razaoSocial, Cnpj cnpj)
        {
            NomeFantasia = nomeFantasia;
            RazaoSocial = razaoSocial;
            CNPJ = cnpj;
            _emails = new List<Email>();
            _telefones = new List<Telefone>();
            _enderecos = new List<Endereco>();
        }

        public string NomeFantasia { get; private set; }
        public string RazaoSocial { get; private set; }
        public Cnpj CNPJ { get; private set; }
        public string InscricaoEstadual { get; set; }
        public IReadOnlyCollection<Endereco> Enderecos => new ReadOnlyCollection<Endereco>(_enderecos);
        public IReadOnlyCollection<Telefone> Telefones => new ReadOnlyCollection<Telefone>(_telefones);
        public IReadOnlyCollection<Email> Emails => new ReadOnlyCollection<Email>(_emails);

        public void IncluirEmail(string enderecoEmail, bool principal = false)
        {
            var email = new Email(enderecoEmail, principal);
            if (email.Validar())
            {
                _emails.Add(email);
            }
        }

        public void RemoverEmailEmail(string enderecoEmail)
        {
            _emails.Remove(new Email(enderecoEmail));
        }

        //TODO: refatorar
        //Criar metodo desacoplado com interface
        //Incluir Notificacoes do objvalor na entidade
        public void IncluirTelefone(Telefone telefone)
        {
            if (telefone.Validar())
            {
                _telefones.Add(telefone);
            }
        }

        public void RemoverTelefone(Telefone telefone)
        {
                _telefones.Remove(telefone);
        }


        //TODO: add endereco/ remover endereco

    }
}

//TODO: criar um objeto de valor para InscricaoEstadual no sdk
//https://sistemas1.sefaz.ma.gov.br/portalsefaz/pdf?codigo=1524#:~:text=na%20Inscri%C3%A7%C3%A3o%20Estadual-,Formato%3A%20num%C3%A9rico%20Tamanho%3A%209%20d%C3%ADgitos%2C%20sendo%3A,calculado%20atrav%C3%A9s%20do%20m%C3%B3dulo%2011.        
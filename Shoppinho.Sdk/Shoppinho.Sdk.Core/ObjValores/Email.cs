using System.Text.RegularExpressions;
using Shoppinho.Sdk.Core.ObjValores.Base;

namespace Shoppinho.Sdk.Core.ObjValores
{
    public class Email : ObjValorBase
    {
        public Email(string endereco, bool principal = false, Guid id = default)
        {
            Endereco = endereco;
            Principal = principal;
            Id = id != default ? id : Guid.NewGuid();
        }

        public Guid Id { get; private set; }
        public string Endereco { get; private set; }
        public bool Principal { get; private set; }

        public override bool Validar()
        {
            var regExpEmail = new Regex(@"^[a-zA-Z]+(([\'\,\.\- ][a-zA-Z ])?[a-zA-Z]*)*\s+<(\w[-._\w]*\w@\w[-._\w]*\w\.\w{2,3})>$|^(\w[-._\w]*\w@\w[-._\w]*\w\.\w{2,3})$");
            return regExpEmail.Match(Endereco).Success;
        }

        public static implicit operator Email(string enderecoEmail)
        {
            if (TryParse(enderecoEmail, out var email))
            {
                return email;
            }
            throw new InvalidOperationException("O e-mail informado é inválido");
        }

        public static bool TryParse(string enderecoEmail, out Email email)
        {
            email = new Email(enderecoEmail);
            return email.Validar();
        }
    }
}
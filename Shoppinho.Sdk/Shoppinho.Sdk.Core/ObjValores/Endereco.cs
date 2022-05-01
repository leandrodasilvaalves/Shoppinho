using System.Text.RegularExpressions;
using Shoppinho.Sdk.Core.Notificacoes;
using Shoppinho.Sdk.Core.ObjValores.Base;
using Shoppinho.Sdk.Utils.Extensions;

namespace Shoppinho.Sdk.Core.ObjValores
{
    public class Endereco : ObjValorBase
    {
        public const int MinLength = 5;
        public const int MaxLength = 100;
        protected Endereco() { }

        public Endereco(
            string logradouro,
            string complemento,
            string numero,
            Cidade cidade,
            string cep,
            bool principal = default)
        {
            Logradouro = logradouro;
            Complemento = complemento;
            Numero = numero;
            Cidade = cidade;
            Id = Guid.NewGuid();
            Principal = principal;
            Cep = cep.SomenteNumeros();
        }

        public Guid Id { get; private set; }
        public string Logradouro { get; private set; }
        public string Complemento { get; private set; }
        public string Numero { get; private set; }
        public Cidade Cidade { get; private set; }
        public string Cep { get; private set; }
        public bool Principal { get; private set; }

        public override bool Validar()
        {
            return Cidade.Validar() &&
                   ValidarLogradouro() &&
                   ValidarCep();
        }

        private bool ValidarLogradouro()
        {
            if (Logradouro?.Length >= MinLength && Logradouro?.Length <= MaxLength)
            {
                return true;
            }
            IncluirNotificacao(new Erro("ENDERECO_LOGRADOURO_INVALIDO", $"O logradouro deve ter entre {MinLength} e {MaxLength} caracteres"));
            return false;
        }

        public bool ValidarCep()
        {
            var regex = new Regex(@"^\d{8}$");
            if (regex.Match(Cep).Success)
            {
                return true;
            }
            IncluirNotificacao(new Erro("ENDERECO_CEP_INVALIDO", "O cep informado é inválido"));
            return false;
        }
    }
}
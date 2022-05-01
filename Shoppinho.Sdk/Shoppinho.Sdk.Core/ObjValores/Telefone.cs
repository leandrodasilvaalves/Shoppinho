using System.Text.RegularExpressions;
using Shoppinho.Sdk.Core.Notificacoes;
using Shoppinho.Sdk.Core.ObjValores.Base;
using Shoppinho.Sdk.Utils.Extensions;

namespace Shoppinho.Sdk.Core.ObjValores
{
    public class Telefone : ObjValorBase
    {
        protected Telefone() { }
        public Telefone(string ddd, string numero, string codigoPais = "55", bool whatsapp = false, bool principal = false)
        {
            DDD = ddd.SomenteNumeros();
            Numero = numero.SomenteNumeros();
            CodigoPais = codigoPais;
            Whatsapp = whatsapp;
            Principal = principal;
        }

        public string CodigoPais { get; private set; }
        public string DDD { get; private set; }
        public string Numero { get; private set; }
        public bool Whatsapp { get; private set; }
        public bool Principal { get; private set; }

        public override bool Validar()
        {
            return
                ValidarDDD() &&
                ValidarNumero() &&
                ValidarCodigoPais();
        }

        private bool ValidarDDD()
        {
            var regex = new Regex(@"^\d{2}$");
            if (regex.Match(DDD).Success)
            {
                return true;
            }
            IncluirNotificacao(new Erro("TELEFONE_DDD_INVALIDO","O DDD informado é inválido"));
            return false;
        }

        private bool ValidarNumero()
        {
            var regex = new Regex(@"^\d{9}$");
            if (regex.Match(Numero).Success)
            {
                return true;
            }
            IncluirNotificacao(new Erro("TELEFON_NUMERO_INVALIDO","O número deve conter 9 dígitos"));
            return false;
        }

        public bool ValidarCodigoPais()
        {
            var regex = new Regex(@"^\+?\d{2}$");
            if (regex.Match(CodigoPais).Success)
            {
                return true;
            }
            IncluirNotificacao(new Erro("TELEFONE_CODIGO_PAIS_INVALIDO","O código do país informado é inválido"));
            return false;
        }

        public static bool TryParse(string numeroTelefone, out Telefone telefone)
        {
            numeroTelefone = numeroTelefone.SomenteNumeros();
            int CODIGO_PAIS_DDD_NUMERO = 13;
            int DDD_NUMERO = 11;
            telefone = new Telefone();
            if (numeroTelefone.Length == CODIGO_PAIS_DDD_NUMERO)
            {
                telefone = new Telefone(
                    codigoPais: numeroTelefone.Substring(0, 2),
                    ddd: numeroTelefone.Substring(2, 2),
                    numero: numeroTelefone.Substring(4)
                );
            }
            else if (numeroTelefone.Length == DDD_NUMERO)
            {
                telefone = new Telefone(
                    ddd: numeroTelefone.Substring(0, 2),
                    numero: numeroTelefone.Substring(2)
                );
            }
            return telefone.Validar();
        }

        public static Telefone Parse(string numeroTelefone)
        {
            if (TryParse(numeroTelefone, out var telefone))
            {
                return telefone;
            }
            throw new InvalidOperationException("O telefone informado é inválido");
        }

        public static implicit operator Telefone(string numero)
        {
           return Telefone.Parse(numero);
        }
    }
}
using System.Text.RegularExpressions;
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

        public string CodigoPais { get; set; }
        public string DDD { get; private set; }
        public string Numero { get; private set; }
        public bool Whatsapp { get; private set; }
        public bool Principal { get; private set; }

        public override bool Validar()
        {
            return 
                ValidarDDD()&&
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
            IncluirNotificacao("O DDD informado é inválido");
            return false;
        }

        private bool ValidarNumero() 
        {
            var regex = new Regex(@"^\d{9}$");
            if (regex.Match(Numero).Success)
            {
                return true;
            }
            IncluirNotificacao("O número deve conter 9 dígitos");
            return false;
        }

        public bool ValidarCodigoPais()
        {
            var regex = new Regex(@"^\+?\d{2}$");
            if (regex.Match(CodigoPais).Success)
            {
                return true;
            }
            IncluirNotificacao("O código do país informado é inválido");
            return false;
        }
    }
}
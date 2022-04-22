using System.Text.RegularExpressions;

namespace Shoppinho.Sdk.Core.ObjValores.ObjValores.Base
{
    public abstract class CpfCnpjBase
    { 
        protected CpfCnpjBase(string numero)
        {
            var documento =  GetType().Name.ToUpper();
            Numero = numero  ?? throw new ArgumentNullException($"Número do {documento} não foi informado");
        }

         protected abstract int TamanhoMaximo { get; }

        public string Numero { get; private set; }

        public string SomenteNumeros
        {
            get
            {
                var regex = new Regex(@"[^\d+]");
                return regex.Replace(Numero, string.Empty);
            }
        }

        public abstract bool Validar();

        protected abstract bool VerificarPrimeiroDigito();

        protected abstract bool VerificarSegundoDigito();

        protected bool TodosDigitosIguais()
        {
            var igual = true;
            for (var i = 1; i < TamanhoMaximo && igual; i++)
                if (SomenteNumeros[i] != SomenteNumeros[0])
                    igual = false;

            return igual;
        }

        protected bool VerificarDigito(int indice, int[] multiplicadores)
        {
            var DigitoVerificadorModulo11 = 11;
            var soma = 0;
            for (var i = 0; i < multiplicadores.Length; i++)
                soma += multiplicadores[i] * ObterDigitoPorIndice(i);

            var resto = soma % DigitoVerificadorModulo11;
            if (resto == 1 || resto == 0)
            {
                if (ObterDigitoPorIndice(indice) == 0)
                    return true;
            }
            else if (ObterDigitoPorIndice(indice) == (DigitoVerificadorModulo11 - resto))
                return true;

            return false;
        }

        protected bool ValidarTamanho() => SomenteNumeros?.Length == TamanhoMaximo;

        private int ObterDigitoPorIndice(int indice) => int.Parse(SomenteNumeros[indice].ToString());
    }
}
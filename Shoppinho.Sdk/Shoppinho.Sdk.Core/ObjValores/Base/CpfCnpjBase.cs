using Shoppinho.Sdk.Utils.Extensions;

namespace Shoppinho.Sdk.Core.ObjValores.ObjValores.Base
{
    public abstract class CpfCnpjBase
    {
        private readonly int _tamanhoMaximo;
        private readonly string _formatoDocumento;
        protected CpfCnpjBase(string numero, int tamanhoMaximo, string formatoDocumento)
        {
            var documento = GetType().Name.ToUpper();
            Numero = numero.SomenteNumeros() ?? throw new ArgumentNullException($"Número do {documento} não foi informado");
            _formatoDocumento = formatoDocumento ?? throw new ArgumentNullException(nameof(formatoDocumento));
            _tamanhoMaximo = tamanhoMaximo;
        }

        public string Numero { get; private set; }

        public string NumeroFormatado
        {
            get
            {   
                return Convert.ToInt64(Numero).ToString(_formatoDocumento);
            }
        }

        public abstract bool Validar();

        protected abstract bool VerificarPrimeiroDigito();

        protected abstract bool VerificarSegundoDigito();

        protected bool TodosDigitosIguais()
        {
            var igual = true;
            for (var i = 1; i < _tamanhoMaximo && igual; i++)
                if (Numero[i] != Numero[0])
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

        protected bool ValidarTamanho() => Numero?.Length == _tamanhoMaximo;

        private int ObterDigitoPorIndice(int indice) => int.Parse(Numero[indice].ToString());
    }
}
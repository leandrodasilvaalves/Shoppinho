using Shoppinho.Sdk.Core.Bases;
using Shoppinho.Sdk.Core.Notificacoes;
using Shoppinho.Sdk.Utils.Extensions;

namespace Shoppinho.Sdk.Core.ObjValores.ObjValores
{
    public abstract class Documento : Validador
    {
        private readonly int _tamanhoMaximo;
        private readonly string _formatoDocumento;
        private readonly string _nomeDocumento;
        protected Documento(string numero, int tamanhoMaximo, string formatoDocumento)
        {
            _nomeDocumento = GetType().Name.ToUpper();
            Numero = numero.SomenteNumeros() ?? throw new ArgumentNullException($"Número do {_nomeDocumento} não foi informado");
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

        protected abstract void VerificarPrimeiroDigito();

        protected abstract void VerificarSegundoDigito();

        protected void TodosDigitosIguais()
        {
            //TODO: melhorar essa lógica de modo que fique mais semâtico
            //tá um pouco estranho ter que negar a variável "todosIguais"
            var todosIguais = true;
            for (var i = 1; i < _tamanhoMaximo && todosIguais; i++)
                if (Numero[i] != Numero[0])
                    todosIguais = false;
            
            Regra(!todosIguais,
                new Erro($"{_nomeDocumento}_DIGITOS_IGUAIS", "Todos os dígitos informados são iguais"));
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

        protected void ValidarTamanho()
        {
            var tamanhoValido = Numero?.Length == _tamanhoMaximo;            
            Regra(tamanhoValido,
                new Erro($"{_nomeDocumento}_TAMANHO_INVALIDO", "A quantidade de caracteres é inválida."));
        }

        private int ObterDigitoPorIndice(int indice) => int.Parse(Numero[indice].ToString());
    }
}
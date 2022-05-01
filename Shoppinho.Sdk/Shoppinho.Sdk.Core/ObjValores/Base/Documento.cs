using Shoppinho.Sdk.Core.Notificacoes;
using Shoppinho.Sdk.Core.ObjValores.Base;
using Shoppinho.Sdk.Utils.Extensions;

namespace Shoppinho.Sdk.Core.ObjValores.ObjValores.Base
{
    public abstract class Documento : ObjValorBase
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

        protected abstract bool VerificarPrimeiroDigito();

        protected abstract bool VerificarSegundoDigito();

        protected bool TodosDigitosIguais()
        {
            var todosIguais = true;
            for (var i = 1; i < _tamanhoMaximo && todosIguais; i++)
                if (Numero[i] != Numero[0])
                    todosIguais = false;

            if (todosIguais)
            {
                IncluirNotificacao(new Erro($"{_nomeDocumento}_DIGITOS_IGUAIS", "Todos os dígitos informados são iguais"));
            }
            return todosIguais;
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

            IncluirNotificacao(new Erro($"{_nomeDocumento}_DIGITO_VERIFICADOR_INVALIDO", 
                $"O documento {_nomeDocumento} deve ter {_tamanhoMaximo} caracteres."));
            return false;
        }

        protected bool ValidarTamanho()
        {
            var tamanhoValido = Numero?.Length == _tamanhoMaximo;
            if (!tamanhoValido)
            {
                IncluirNotificacao(new Erro($"{_nomeDocumento}_TAMANHO_INVALIDO", "A quantidade de caracteres é inválida."));
            }
            return tamanhoValido;
        }

        private int ObterDigitoPorIndice(int indice) => int.Parse(Numero[indice].ToString());
    }
}
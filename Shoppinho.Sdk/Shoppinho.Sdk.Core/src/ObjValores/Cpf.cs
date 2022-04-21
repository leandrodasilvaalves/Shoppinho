using System.Text.RegularExpressions;

namespace Shoppinho.Sdk.Core.ObjValores
{
    public struct Cpf
    {
        public const int TamanhoMaximo = 11;
        public const string SquencialInvalido = "12345678909";

        public Cpf(string numero)
        {
            Numero = numero ?? throw new ArgumentNullException("Número do cpf");
        }

        public string Numero { get; private set; }

        public string SomenteNumeros
        {
            get
            {
                var regex = new Regex(@"[^\d+]");
                return regex.Replace(Numero, string.Empty);
            }
        }

        public int[] Numeros
        {
            get
            {
                var numeros = new int[TamanhoMaximo];
                for (var i = 0; i < TamanhoMaximo; i++)
                    numeros[i] = int.Parse(SomenteNumeros[i].ToString());

                return numeros;
            }
        }

        //https://dicasdeprogramacao.com.br/algoritmo-para-validar-cpf/
        //https://www.macoratti.net/alg_cpf.htm
        public bool Validar()
        {
            if (!ValidarTamanho())
                return false;

            if (TodosDigitosIguais() || SomenteNumeros == SquencialInvalido)
                return false;

            if (!VerificarPrimeiroDigito() || !VerificarSegundoDigito())
                return false;

            return true;
        }

        private bool ValidarTamanho() => SomenteNumeros?.Length == TamanhoMaximo;

        private bool VerificarPrimeiroDigito() => VerificarDigito(10, 9);

        private bool VerificarSegundoDigito() => VerificarDigito(TamanhoMaximo, 10);

        private bool VerificarDigito(int multiplicador, int indice)
        {
            var soma = 0;
            for (var i = 0; i < indice; i++)
                soma += (multiplicador - i) * Numeros[i];

            var resto = soma % TamanhoMaximo;

            if (resto == 1 || resto == 0)
            {
                if (Numeros[indice] != 0)
                    return false;   
            }
            else if (Numeros[indice] != TamanhoMaximo - resto)
                return false;

            return true;
        }

        private bool TodosDigitosIguais()
        {
            var igual = true;
            for (var i = 1; i < TamanhoMaximo && igual; i++)
                if (SomenteNumeros[i] != SomenteNumeros[0])
                    igual = false;

            return igual;
        }

        public static implicit operator Cpf(string numero)
        {
            if (Cpf.TryParse(numero, out var cpf))
                return cpf;

            throw new InvalidOperationException("O número de cpf informado é inválido");
        }

        public static bool TryParse(string numero, out Cpf cpf)
        {
            cpf = new Cpf(numero);
            return cpf.Validar();
        }
    }
}
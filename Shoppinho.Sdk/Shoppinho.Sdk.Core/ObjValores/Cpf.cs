using Shoppinho.Sdk.Core.Notificacoes;
using Shoppinho.Sdk.Core.ObjValores.ObjValores;

namespace Shoppinho.Sdk.Core.ObjValores
{
    public sealed class Cpf : Documento
    {
        private const string SquencialInvalido = "12345678909";
        public const int TamanhoMaximo = 11;

        protected Cpf() : base(default, default, default) { } //EF

        public Cpf(string numero)
            : base(numero, TamanhoMaximo, @"000\.000\.000\-00") { }

        //https://www.macoratti.net/alg_cpf.htm
        public override void Validar()
        {
            ValidarTamanho();
            var validouTamanho = EhValido;
            if (validouTamanho)
            {
                TodosDigitosIguais();
                NaoEhSequencialInvalido();
                VerificarPrimeiroDigito();
                VerificarSegundoDigito();
            }
        }

        private void NaoEhSequencialInvalido()
        {
            Regra(Numero != SquencialInvalido,
                new Erro("CPF_INVALIDO", "O número do cpf informado é inválido"));
        }

        protected override void VerificarPrimeiroDigito()
        {
            var multiplicadores = new int[] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            Regra(VerificarDigito(9, multiplicadores),
                new Erro("CPF_PRIMEIRO_DIGITO_VERIFICADOR_INVALIDO", "O primeiro dígito verificador é inválido"));
        }

        protected override void VerificarSegundoDigito()
        {
            var multiplicadores = new int[] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            Regra(VerificarDigito(10, multiplicadores),
                new Erro("CPF_SEGUNDO_DIGITO_VERIFICADOR_INVALIDO", "O segundo dígito verificador é inválido"));
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
            cpf.Validar();
            return cpf.EhValido;
        }
    }
}
using Shoppinho.Sdk.Core.Notificacoes;
using Shoppinho.Sdk.Core.ObjValores.ObjValores;
namespace Shoppinho.Sdk.Core.ObjValores
{
    public sealed class Cnpj : Documento
    {
        public const int TamanhoMaximo = 14;

        protected Cnpj() : base(default, default, default) { } //EF
        public Cnpj(string numero)
            : base(numero, TamanhoMaximo, @"00\.000\.000\/0000\-00") { }

        //https://www.macoratti.net/alg_cnpj.htm
        public override void Validar()
        {
            ValidarTamanho();
            if (EhValido)
            {
                TodosDigitosIguais();
                VerificarPrimeiroDigito();
                VerificarSegundoDigito();
            }
        }

        protected override void VerificarPrimeiroDigito()
        {
            var multiplicadores = new int[] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            Regra(
                VerificarDigito(12, multiplicadores),
                new Erro("CNPJ_PRIMEIRO_DIGITO_VERIFICADOR_INVALIDO", "O primeiro digito verificador é inválido"));
        }

        protected override void VerificarSegundoDigito()
        {
            var multiplicadores = new int[] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            Regra(
                VerificarDigito(13, multiplicadores),
                new Erro("CNPJ_SEGUNDO_DIGITO_VERIFICADOR_INVALIDO", "O segundo digito verificador é inválido"));
        }

        public static implicit operator Cnpj(string numero)
        {
            if (TryParse(numero, out var cnpj))
                return cnpj;

            throw new InvalidOperationException("O número de CNPJ informado é inválido");
        }

        public static bool TryParse(string numero, out Cnpj cnpj)
        {
            cnpj = new Cnpj(numero);
            cnpj.Validar();
            return cnpj.EhValido;
        }
    }
}
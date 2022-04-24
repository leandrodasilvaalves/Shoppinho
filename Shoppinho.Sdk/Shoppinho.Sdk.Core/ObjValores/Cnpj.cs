using Shoppinho.Sdk.Core.ObjValores.ObjValores.Base;

namespace Shoppinho.Sdk.Core.ObjValores
{
    public sealed class Cnpj : CpfCnpjBase
    {
        public const int TamanhoMaximo = 14;

        protected Cnpj() : base(default, default, default) { } //EF
        public Cnpj(string numero) 
            : base(numero, TamanhoMaximo, @"00\.000\.000\/0000\-00") { }

        //https://www.macoratti.net/alg_cnpj.htm
        public override bool Validar()
        {
            if (ValidarTamanho() &&
                !TodosDigitosIguais() &&
                VerificarPrimeiroDigito() &&
                VerificarSegundoDigito())
                return true;

            return false;
        }

        protected override bool VerificarPrimeiroDigito()
        {
            var multiplicadores = new int[] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            return VerificarDigito(12, multiplicadores);
        }

        protected override bool VerificarSegundoDigito()
        {
            var multiplicadores = new int[] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            return VerificarDigito(13, multiplicadores);
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
            return cnpj.Validar();
        }
    }
}
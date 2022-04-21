namespace Shoppinho.Sdk.Core.ObjValores
{
    public struct Cnpj
    {
        public Cnpj(string numero)
        {
            Numero = numero;
        }
        public string Numero { get; private set; }
    }
}
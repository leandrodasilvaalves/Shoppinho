namespace Shoppinho.Sdk.Core.ObjValores
{
    public struct Cpf
    {
        public Cpf(string numero)
        {
            Numero = numero;
        }
        public string Numero { get; private set; }
    }
}
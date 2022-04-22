namespace Shoppinho.Sdk.Core.ObjValores
{
    public struct Endereco
    {
        public Endereco(
            string logradouro,
            string complemento,
            string numero,
            Cidade cidade) : this()
        {
            Logradouro = logradouro;
            Complemento = complemento;
            Numero = numero;
            Cidade = cidade;
        }

        public string Logradouro { get; private set; }
        public string Complemento { get; private set; }
        public string Numero { get; private set; }
        public Cidade Cidade { get; private set; }
        public string? Cep { get; private set; }
    }
}
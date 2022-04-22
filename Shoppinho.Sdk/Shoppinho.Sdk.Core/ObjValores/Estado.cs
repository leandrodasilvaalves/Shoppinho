namespace Shoppinho.Sdk.Core.ObjValores
{
    public struct Estado
    {
        public Estado(string nome) : this()
        {
            Nome = nome;
        }

        public Estado(string nome, string sigla): this(nome)
        {
            Sigla = sigla;
        }

        public string Nome { get; private set; }
        public string? Sigla { get; private set; }
    }
}
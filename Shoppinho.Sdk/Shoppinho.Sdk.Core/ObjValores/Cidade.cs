namespace Shoppinho.Sdk.Core.ObjValores
{
    public struct Cidade
    {   public Cidade(string nome, Estado estado)
        {
            Nome = nome;
            Estado = estado;
        }

        public string Nome { get; private set; }
        public Estado Estado { get; private set; }
    }
}
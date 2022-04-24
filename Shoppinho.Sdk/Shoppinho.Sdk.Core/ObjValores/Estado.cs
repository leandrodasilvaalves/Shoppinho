namespace Shoppinho.Sdk.Core.ObjValores
{
    public class Estado
    {
        protected Estado(){} //EF
        public Estado(string nome, string sigla)
        {
            Sigla = sigla;
            Nome = nome;
        }

        public string Nome { get; private set; }
        public string Sigla { get; private set; }
    }
}
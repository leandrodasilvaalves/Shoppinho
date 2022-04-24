namespace Shoppinho.Sdk.Core.ObjValores
{
    public class Cidade
    {   
        protected Cidade(){}//EF
        public Cidade(string nome, string estado)
        {
            Nome = nome;
            Estado = estado;
        }

        public string Nome { get; private set; }
        public string Estado { get; private set; }
    }
}
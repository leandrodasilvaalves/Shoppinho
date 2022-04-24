namespace Shoppinho.Sdk.Core.ObjValores
{
    public class Endereco
    {
        protected Endereco(){}
        
        public Endereco(
            string logradouro,
            string complemento,
            string numero,
            Cidade cidade,
            bool principal)
        {
            Logradouro = logradouro;
            Complemento = complemento;
            Numero = numero;
            Cidade = cidade;
            Id = Guid.NewGuid();
            Principal = principal;
        }

        public Guid Id { get; private set; }
        public string Logradouro { get; private set; }
        public string Complemento { get; private set; }
        public string Numero { get; private set; }
        public Cidade Cidade { get; private set; }
        public string Cep { get; private set; }
        public bool Principal { get; private set; }
    }
}
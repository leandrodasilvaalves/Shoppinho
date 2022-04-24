namespace Shoppinho.Sdk.Core.ObjValores
{
    public class Email
    {
        public Email(string endereco, bool principal)
        {
            Endereco = endereco;
            Principal = principal;
        }

        public string Endereco { get; private set; }
        public bool Principal { get; private set; }
    }
}
namespace Shoppinho.Sdk.Core.ObjValores
{
    public class Telefone
    {
        protected Telefone(){}

        public Telefone(int ddd, string numero, bool whatsapp = false, string codigoPais = "+55", bool principal = false)
        {
            DDD = ddd;
            Numero = numero;
            Whatsapp = whatsapp;
            CodigoPais = codigoPais;
            Principal = principal;
        }

        public string CodigoPais { get; set; }
        public int DDD { get; private set; }
        public string Numero { get; private set; }
        public bool Whatsapp { get; private set; }
        public bool Principal { get; private set; }        
    }
}
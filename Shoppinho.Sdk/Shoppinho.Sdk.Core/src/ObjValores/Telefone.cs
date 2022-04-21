namespace Shoppinho.Sdk.Core.ObjValores
{
    public struct Telefone
    {
        public Telefone(int ddd, string numero, bool whatsapp = false)
        {
            DDD = ddd;
            Numero = numero;
            Whatsapp = whatsapp;
        }

        public int DDD { get; private set; }
        public string Numero { get; private set; }
        public bool Whatsapp { get; private set; }        
    }
}
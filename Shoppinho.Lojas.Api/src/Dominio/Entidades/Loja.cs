namespace src.Dominio.Entidades
{
    public class Loja
    {
        public Guid Id { get; set; }
        public string NomeFantasia { get; set; }
        public string RazaoSocial { get; private set; }
        public string CNPJ { get; set; }        
        public string InscricaoEstadual { get; set; }
        public List<string> Enderecos { get; set; }
        public List<string> Telefones { get; set; }
    }
}
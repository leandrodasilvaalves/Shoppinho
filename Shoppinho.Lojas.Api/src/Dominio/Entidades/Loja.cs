using Shoppinho.Sdk.Core.ObjValores;

namespace src.Dominio.Entidades
{
    public class Loja
    {
        public Guid Id { get; set; }
        public string NomeFantasia { get; set; }
        public string RazaoSocial { get; private set; }
        public Cnpj CNPJ { get; set; }        
        public string InscricaoEstadual { get; set; }
        public List<Endereco> Enderecos { get; set; }
        public List<Telefone> Telefones { get; set; }
    }
}
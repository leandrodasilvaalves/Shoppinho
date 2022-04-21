using Shoppinho.Sdk.Core.Entidades;
using Shoppinho.Sdk.Core.ObjValores;

namespace src.Dominio.Entidades
{
    public class Loja : Entidade
    {
        public Loja(string nomeFantasia, string razaoSocial, Cnpj cNPJ)
        {
            NomeFantasia = nomeFantasia;
            RazaoSocial = razaoSocial;
            CNPJ = cNPJ;
        }

        public string NomeFantasia { get; private set; }
        public string RazaoSocial { get; private set; }
        public Cnpj CNPJ { get; private set; }        
        public string? InscricaoEstadual { get; set; }
        public List<Endereco>? Enderecos { get; set; }
        public List<Telefone>? Telefones { get; set; }
    }
}
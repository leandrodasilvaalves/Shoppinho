using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shoppinho.Sdk.Core.ObjValores;

namespace Shoppinho.Lojas.Api.Infra.Mapeamentos
{
    public class TelefoneMap : IEntityTypeConfiguration<Telefone>
    {
        public void Configure(EntityTypeBuilder<Telefone> builder)
        {
            builder.HasKey(e => new { e.CodigoPais, e.DDD, e.Numero});
            builder.ToTable("Telefones");
        }
    }
}
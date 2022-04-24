using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shoppinho.Sdk.Core.ObjValores;

namespace Shoppinho.Lojas.Api.Infra.Mapeamentos
{
    public class EnderecoMap : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.HasKey(e => e.Id);

            builder.OwnsOne(e => e.Cidade, tf =>
            {
                tf.Property(e => e.Nome)
                    .HasColumnName("Cidade")                
                    .HasColumnType("varchar(80)");

                tf.Property(e => e.Estado)
                    .HasColumnName("Estado")
                    .HasColumnType("varchar(2)");
            });

            builder.ToTable("Enderecos");
        }
    }
}
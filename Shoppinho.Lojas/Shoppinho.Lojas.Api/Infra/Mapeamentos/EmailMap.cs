using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shoppinho.Sdk.Core.ObjValores;

namespace Shoppinho.Lojas.Api.Infra.Mapeamentos
{
    public class EmailMap : IEntityTypeConfiguration<Email>
    {
        public void Configure(EntityTypeBuilder<Email> builder)
        {
            builder.HasKey(e => e.Endereco);
            
            builder.Property(e => e.Endereco)
                .HasColumnName("Email")
                .HasColumnType("varchar(100)")
                .IsRequired();
            
            builder.ToTable("Emails");
        }
    }
}
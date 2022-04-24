using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shoppinho.Lojas.Api.Dominio.Entidades;
using Shoppinho.Sdk.Core.ObjValores;

namespace Shoppinho.Lojas.Api.Infra.Mapeamentos
{
    public class LojaMap : IEntityTypeConfiguration<Loja>
    {
        public void Configure(EntityTypeBuilder<Loja> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.NomeFantasia)
                .HasColumnType("varchar(120)")
                .IsRequired();

            builder.Property(e => e.RazaoSocial)
                .HasColumnType("varchar(120)")
                .IsRequired();

            builder.OwnsOne(e => e.CNPJ, tf =>
            {
                tf.Property(e => e.Numero)
                    .IsRequired()                    
                    .HasColumnName("CNPJ")
                    .HasColumnType($"varchar({Cnpj.TamanhoMaximo})");
            });

            builder.Property(e => e.InscricaoEstadual)
                .HasColumnType("varchar(9)");

            builder
                .HasMany(e => e.Enderecos)
                .WithOne();

            builder
                .HasMany(e => e.Telefones)
                .WithOne();

            builder.ToTable("Lojas");
        }
    }
}
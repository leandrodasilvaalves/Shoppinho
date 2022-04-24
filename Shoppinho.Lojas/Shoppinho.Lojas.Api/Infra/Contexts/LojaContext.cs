using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using Shoppinho.Lojas.Api.Dominio.Entidades;
using Shoppinho.Sdk.Core.Eventos;

namespace Shoppinho.Lojas.Api.Infra.Contexts
{
    public class LojaContext : DbContext
    {
        public LojaContext(DbContextOptions<LojaContext> options)
            : base(options) { }

        public DbSet<Loja> Lojas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<ValidationResult>();
            modelBuilder.Ignore<Evento>();

            foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(
                e => e.GetProperties().Where(p => p.ClrType == typeof(string))))
                property.SetColumnType("varchar(100)");


            modelBuilder.ApplyConfigurationsFromAssembly(typeof(LojaContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
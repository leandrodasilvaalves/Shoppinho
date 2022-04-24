using Microsoft.EntityFrameworkCore;
using Shoppinho.Lojas.Api.Dominio.Entidades;
using Shoppinho.Lojas.Api.Dominio.Interfaces;
using Shoppinho.Lojas.Api.Infra.Contexts;

namespace Shoppinho.Lojas.Api.Infra.Repositorios
{
    public class LojaRepositorio : ILojaRepositorio
    {
        private readonly LojaContext _db;

        public LojaRepositorio(LojaContext db) 
            => _db = db ?? throw new ArgumentNullException(nameof(db));

        public async Task<Loja> ObterPorId(Guid id) 
            => await _db.Lojas.FindAsync(id);

        public async Task<IEnumerable<Loja>> ObterTodos() 
            => await _db.Lojas.ToListAsync();

        public Task Incluir(Loja entidade)
        {
            _db.Lojas.Add(entidade);
            return _db.SaveChangesAsync();
        }

        public Task Atualizar(Loja entidade)
        {
            _db.Update(entidade);
            return _db.SaveChangesAsync();
        }

        public Task Excluir(Loja entidade)
        {
            _db.Remove(entidade);
            return _db.SaveChangesAsync();
        }

        public void Dispose() => _db.Dispose();
    }
}
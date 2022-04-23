using Shoppinho.Lojas.Api.Dominio.Entidades;
using Shoppinho.Lojas.Api.Dominio.Interfaces;

namespace Shoppinho.Lojas.Api.Infra
{
    public class LojaRepositorio : ILojaRepositorio
    {
        public Task Atualizar(Loja entidade)
        {
            throw new NotImplementedException();
        }

        public Task Excluir(Loja entidade)
        {
            throw new NotImplementedException();
        }

        public Task Incluir(Loja entidade)
        {
            throw new NotImplementedException();
        }

        public Task<Loja> ObterPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Loja>> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

    }
}
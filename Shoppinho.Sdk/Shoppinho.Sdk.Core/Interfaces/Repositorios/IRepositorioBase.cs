using Shoppinho.Sdk.Core.Entidades;

namespace Shoppinho.Sdk.Core.Interfaces.Repositorios
{
    public interface IRepositorioBase<T>: IDisposable where T : Entidade
    {
        Task<T> ObterPorId(Guid id);        
        Task<IEnumerable<T>> ObterTodos();
        Task Incluir(T entidade);
        Task Atualizar(T entidade);
        Task Excluir(T entidade);
    }
}
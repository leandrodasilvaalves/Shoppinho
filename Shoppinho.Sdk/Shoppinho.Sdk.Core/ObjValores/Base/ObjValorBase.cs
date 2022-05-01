using System.Collections.ObjectModel;
using Shoppinho.Sdk.Core.Notificacoes;

namespace Shoppinho.Sdk.Core.ObjValores.Base
{
    public abstract class ObjValorBase
    {
        private readonly IList<Notificacao> _notificacoes;
        public ObjValorBase()
        {
            _notificacoes = new List<Notificacao>();
        }

        public IReadOnlyCollection<Notificacao> Notificaoes
            => new ReadOnlyCollection<Notificacao>(_notificacoes);

        public void IncluirNotificacao(Notificacao notificacao)
        {
            _notificacoes.Add(notificacao);
        }

        public void LimparNotificacoes()
             => _notificacoes.Clear();

        public void RemoverNotificacao(Notificacao notificacao)
            => _notificacoes.Remove(notificacao);

        public abstract bool Validar();
    }
}
using System.Collections.ObjectModel;
using Shoppinho.Sdk.Core.Notificacoes;

namespace Shoppinho.Sdk.Core.Bases
{
    public abstract class Notificavel
    {
        private readonly IList<Notificacao> _notificacoes;

        public Notificavel()
        {
            _notificacoes = new List<Notificacao>();
        }

        public int Erros => _notificacoes.OfType<Erro>().Count();
        public int Alertas => _notificacoes.OfType<Erro>().Count();
        public int Informacoes => _notificacoes.OfType<Erro>().Count();

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
    }
}
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

        public IReadOnlyCollection<Erro> Erros =>
            new ReadOnlyCollection<Erro>(_notificacoes.OfType<Erro>().ToList());
        public IReadOnlyCollection<Alerta> Alertas =>
            new ReadOnlyCollection<Alerta>(_notificacoes.OfType<Alerta>().ToList());
        public IReadOnlyCollection<Informacao> Informcoes =>
            new ReadOnlyCollection<Informacao>(_notificacoes.OfType<Informacao>().ToList());

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
using System.Collections.ObjectModel;

namespace Shoppinho.Sdk.Core.ObjValores.Base
{
    public abstract class ObjValorBase
    {
        private readonly IList<string> _notificacoes;
        public ObjValorBase()
        {
            _notificacoes = new List<string>();
        }

        public IReadOnlyCollection<string> Notificaoes 
            => new ReadOnlyCollection<string>(_notificacoes);

        public void IncluirNotificacao(string notificacao)
        {
            if (!string.IsNullOrEmpty(notificacao))
                _notificacoes.Add(notificacao);
        }

        public void LimparNotificacoes()
             => _notificacoes.Clear();

        public void RemoverNotificacao(string notificacao) 
            => _notificacoes.Remove(notificacao);

        public abstract bool Validar();
    }
}
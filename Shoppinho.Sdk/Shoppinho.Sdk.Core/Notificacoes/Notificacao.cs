using System;

namespace Shoppinho.Sdk.Core.Notificacoes
{
    public abstract class Notificacao
    {
        protected Notificacao(string codigo, string mensagem)
        {
            Codigo = codigo;
            Mensagem = mensagem;
            DataHora = DateTimeOffset.UtcNow;
        }

        public string Codigo { get; private set; }
        public string Mensagem { get; private set; }
        public DateTimeOffset DataHora { get; private set; }
    }
}
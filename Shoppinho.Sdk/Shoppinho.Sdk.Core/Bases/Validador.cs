using System.Linq.Expressions;
using Shoppinho.Sdk.Core.Notificacoes;

namespace Shoppinho.Sdk.Core.Bases
{
    public abstract class Validador : Notificavel
    {
        public bool EhValido => Erros == 0;

        public abstract bool Validar();

        public void Regra(Expression<Func<bool>> expressao, Erro notificacao)
        {
            var valido = expressao.Compile().Invoke();
            if (valido is false)
            {
                IncluirNotificacao(notificacao);
            }
        }
    }
}
using Shoppinho.Sdk.Core.Notificacoes;

namespace Shoppinho.Sdk.Core.Bases
{
    public abstract class Validador : Notificavel
    {
        public bool EhValido => !Erros.Any();        

        public abstract void Validar();

        public void Regra(bool condicao, Erro erro)
        {
            if (condicao is false)
            {
                IncluirNotificacao(erro);
            }
        }
    }
}
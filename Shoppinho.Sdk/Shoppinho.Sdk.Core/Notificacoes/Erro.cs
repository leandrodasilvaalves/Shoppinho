namespace Shoppinho.Sdk.Core.Notificacoes
{
    public class Erro : Notificacao
    {
        public Erro(string codigo, string mensagem)
            : base(codigo, mensagem) { }
    }
}
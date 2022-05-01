using Shoppinho.Sdk.Core.Bases;
using Shoppinho.Sdk.Core.Notificacoes;

namespace Shoppinho.Sdk.Core.ObjValores
{
    public class Cidade : Validador
    {
        public const int MinLength = 5;
        public const int MaxLength = 100;

        protected Cidade() { }//EF
        public Cidade(string nome, string estado)
        {
            Nome = nome;
            Estado = estado;
        }

        public string Nome { get; private set; }
        public string Estado { get; private set; }

        public override bool Validar() => ValidarNomeCidade() && ValidarEstado();

        private bool ValidarEstado()
        {
            var estados = new string[] {
                "AC", "AL", "AP", "AM", "BA", "CE",
                "DF", "ES", "GO", "MA", "MT", "MS",
                "MG", "PA", "PB", "PR", "PE", "PI",
                "RJ", "RN", "RS", "RO", "RR", "SC",
                "SP", "SE", "TO",
            };
            if (estados.Contains(Estado.ToUpper()))
            {
                return true;
            }
            IncluirNotificacao(new Erro("CIDADE_ESTADO_INVALIDO", "O estado informado é inválido"));
            return false;
        }

        private bool ValidarNomeCidade()
        {
            if (Nome?.Length >= MinLength && Nome?.Length <= MaxLength)
            {
                return true;
            }
            IncluirNotificacao(new Erro("CIDADE_NOME_INVALIDO", 
                $"O nome da cidade deve ter entre {MinLength} e {MaxLength} caracteres"));
            return false;
        }
    }
}


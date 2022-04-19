using System.Collections.ObjectModel;
using src.Eventos;

namespace src.Entidades
{
    public abstract class Entidade
    {
        private readonly IList<Evento> _eventos = new List<Evento>();

        protected Entidade()
        {
            Id = Guid.NewGuid();
        }

        public Guid  Id { get; private set; }
        public DateTimeOffset DataCadastro { get; private set; }
        public DateTimeOffset UltimaAtualizacao { get; private set; }
        public bool Ativo { get; private set; }

        public IReadOnlyCollection<Evento> Eventos => new ReadOnlyCollection<Evento>(_eventos);
        public void IncluirEvento(Evento @evento)
        {
            _eventos.Add(@evento);
        }

        public void LimparEventos()
        { 
            _eventos.Clear();           
        }

        public void RemoverEvento(Evento @evento)
        {
            _eventos.Remove(@evento);
        }

        public override bool Equals(object? obj)
        {
            var objComparar = obj as Entidade;

            if(ReferenceEquals(this, objComparar)) return true;
            if(ReferenceEquals(null, objComparar)) return false;

            return Id.Equals(objComparar);
        }

        public override int GetHashCode()
        {
            return (GetType().GetHashCode() ^ 93) + Id.GetHashCode();
        }
    }
}
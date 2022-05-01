using System.Collections.ObjectModel;
using Shoppinho.Sdk.Core.Bases;
using Shoppinho.Sdk.Core.Eventos;

namespace Shoppinho.Sdk.Core.Entidades
{
    //TODO: avalidar como tornar a Endidade filho de validador
    public abstract class Entidade : Comparavel<Entidade>
    {
        private readonly IList<Evento> _eventos = new List<Evento>();

        protected Entidade()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; private set; }
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

        public override bool Igual(Entidade obj) => Id.Equals(obj);
        public override int GerarHashCode() => Id.GetHashCode();
    }
}
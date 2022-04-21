namespace Shoppinho.Sdk.Core.Eventos
{
    public abstract class Evento
    {
        protected Evento()
        {
            DataHora = DateTimeOffset.UtcNow;
            IdAgregado = Guid.NewGuid();
        }

        public Guid IdAgregado { get; set; }
        public DateTimeOffset DataHora { get; private set; }
        public string? TipoEvento { get; set; }
    }
}
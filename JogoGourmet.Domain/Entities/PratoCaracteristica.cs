namespace JogoGourmet.Domain.Entities
{
    public class PratoCaracteristica : BaseEntity
    {
        public PratoCaracteristica(Guid? pratoId, Guid? caracteristicaId)
        {
            PratoId = pratoId;
            CaracteristicaId = caracteristicaId;
        }

        public Guid? PratoId { get; set; }
        public Guid? CaracteristicaId { get; set; }
    }
}

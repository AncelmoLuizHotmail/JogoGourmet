namespace JogoGourmet.App.Models
{
    public class PratoCaracteristica : BaseMosel
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

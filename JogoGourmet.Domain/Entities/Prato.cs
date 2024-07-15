namespace JogoGourmet.Domain.Entities
{
    public class Prato : BaseEntity
    {
        public Prato(string descricao)
        {
            Descricao = descricao;
        }

        public string Descricao { get; set; } = null!;

        public List<PratoCaracteristica> Caracteristicas = new List<PratoCaracteristica>();

        public Caracteristica Caracteristica { get; set; }
    }
}

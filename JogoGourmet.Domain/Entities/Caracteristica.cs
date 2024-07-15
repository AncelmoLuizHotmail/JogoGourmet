namespace JogoGourmet.Domain.Entities
{
    public class Caracteristica : BaseEntity
    {
        public Caracteristica(string descricao)
        {
            Descricao = descricao;
        }

        public string Descricao { get; set; } = null!;

        public List<PratoCaracteristica> Pratos = new List<PratoCaracteristica>();
    }
}

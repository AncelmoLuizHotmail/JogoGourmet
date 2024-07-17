namespace JogoGourmet.App.Models
{
    public class Prato : BaseMosel
    {
        public Prato(string descricao, string caracteristica = null)
        {
            Descricao = descricao;
            Caracteristica = new Caracteristica(caracteristica);
        }

        public string Descricao { get; set; } = null!;

        public List<PratoCaracteristica> Caracteristicas = new List<PratoCaracteristica>();

        public Caracteristica Caracteristica { get; set; }
    }
}

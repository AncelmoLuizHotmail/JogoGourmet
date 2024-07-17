namespace JogoGourmet.App.Models
{
    public class Caracteristica : BaseMosel
    {
        public Caracteristica(string descricao)
        {
            Descricao = descricao;
        }

        public string Descricao { get; set; } = null!;

        public List<PratoCaracteristica> Pratos = new List<PratoCaracteristica>();


    }
}

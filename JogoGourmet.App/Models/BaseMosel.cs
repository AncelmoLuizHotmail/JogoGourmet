namespace JogoGourmet.App.Models
{
    public abstract class BaseMosel
    {
        public Guid Id { get; set; } = Guid.NewGuid();
    }
}

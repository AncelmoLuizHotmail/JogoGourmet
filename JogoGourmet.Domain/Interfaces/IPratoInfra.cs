using JogoGourmet.Domain.Entities;

namespace JogoGourmet.Domain.Interfaces
{
    public interface IPratoInfra
    {
        Prato AdicionarPrato(string prato);
        Prato AdicionarCaracteristica(Prato prato, string caracteristica);
        List<Prato> CarregarPratos();
        Prato ObterPrato(List<Prato> pratos, string descricao);
    }
}

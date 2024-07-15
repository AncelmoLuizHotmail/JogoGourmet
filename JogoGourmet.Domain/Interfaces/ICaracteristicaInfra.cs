using JogoGourmet.Domain.Entities;

namespace JogoGourmet.Domain.Interfaces
{
    public interface ICaracteristicaInfra
    {
        Caracteristica AdicionarCaracteristica(string caracteristica);
        Prato EspecificarPrato(Prato prato, string caracteristica);
    }
}

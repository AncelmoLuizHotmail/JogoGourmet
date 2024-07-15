using JogoGourmet.Domain.Entities;
using JogoGourmet.Domain.Interfaces;

namespace JogoGourmet.Domain.Infra
{
    public class CaracteristicaInfra : ICaracteristicaInfra
    {
        public Caracteristica AdicionarCaracteristica(string caracteristica) => new Caracteristica(caracteristica);
        public Prato EspecificarPrato(Prato prato, string caracteristica)
        {
            var c = new Caracteristica(caracteristica);
            prato.Caracteristicas.Add(new PratoCaracteristica(prato.Id, c.Id));

            return prato;
        }
    }
}

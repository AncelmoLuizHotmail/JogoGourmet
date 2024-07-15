using JogoGourmet.Domain.Entities;
using JogoGourmet.Domain.Interfaces;

namespace JogoGourmet.Domain.Infra
{
    public class PratoInfra : IPratoInfra
    {
        public List<Prato> CarregarPratos()
        {
            var pratosIniciais = new List<Prato>();

            var lazanha = new Prato("Lazanha");
            var caracLazanha = new Caracteristica("Massa");
            lazanha.Caracteristicas.Add(new PratoCaracteristica(lazanha.Id, caracLazanha.Id));
            caracLazanha.Pratos.Add(new PratoCaracteristica(lazanha.Id, caracLazanha.Id));
            lazanha.Caracteristica = caracLazanha;

            var bolo = new Prato("Bolo de Chocolate");
            var caracBolo = new Caracteristica("Sobremesa");
            bolo.Caracteristicas.Add(new PratoCaracteristica(bolo.Id, caracBolo.Id));
            caracBolo.Pratos.Add(new PratoCaracteristica(bolo.Id, caracBolo.Id));
            bolo.Caracteristica = caracBolo;

            pratosIniciais.Add(lazanha);
            pratosIniciais.Add(bolo);

            return pratosIniciais;
        }

        public Prato AdicionarPrato(string prato) => new Prato(prato);

        public Prato AdicionarCaracteristica(Prato prato, string caracteristica)
        {
            var c = new Caracteristica(caracteristica);
            prato.Caracteristicas.Add(new PratoCaracteristica(prato.Id, c.Id));
            prato.Caracteristica = c;

            return prato;
        }

        public Prato ObterPrato(List<Prato> pratos, string descricao)
        {
            var prato = pratos.FirstOrDefault(x => x.Descricao == descricao);

            return prato;
        }
    }
}

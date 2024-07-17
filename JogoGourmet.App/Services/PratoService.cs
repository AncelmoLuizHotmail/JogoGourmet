using JogoGourmet.App.Models;

namespace JogoGourmet.App.Services
{
    public static class PratoService
    {
        public static List<Prato> CarregarPratos()
        {
            var pratosIniciais = new List<Prato>();

            var lazanha = new Prato("Lazanha","MASSA");
            var caracLazanha = new Caracteristica("MASSA");
            lazanha.Caracteristicas.Add(new PratoCaracteristica(lazanha.Id, caracLazanha.Id));
            caracLazanha.Pratos.Add(new PratoCaracteristica(lazanha.Id, caracLazanha.Id));
            lazanha.Caracteristica = caracLazanha;

            var bolo = new Prato("Bolo de Chocolate", "");

            pratosIniciais.Add(lazanha);
            pratosIniciais.Add(bolo);

            return pratosIniciais;
        }
        public static Prato AdicionarPrato(string prato) => new Prato(prato);
        public static Prato AdicionarCaracteristica(Prato prato, Caracteristica caracteristica)
        {
            prato.Caracteristicas.Add(new PratoCaracteristica(prato.Id, caracteristica.Id));
            prato.Caracteristica = caracteristica;

            return prato;
        }

        public static List<Prato> ObterPratosPorCaracteristica(List<Prato> pratos, string caracteristica)
        {
            var resp = pratos.Where(x => x.Caracteristica.Descricao == caracteristica).ToList();

            return resp;
        }
    }
}

using JogoGourmet.App.Models;

namespace JogoGourmet.App.Services
{
    public static class CaracteristicaService
    {
        public static Caracteristica AdicionarCaracteristica(List<Caracteristica> lista, string caracteristica)
        {
            var c = lista.FirstOrDefault(x => x.Descricao == caracteristica);
           
            if (c == null)
             return new Caracteristica(caracteristica.ToUpper());

            return c;
        } 
        public static Prato EspecificarPrato(Prato prato, string caracteristica)
        {
            var c = new Caracteristica(caracteristica);
            prato.Caracteristicas.Add(new PratoCaracteristica(prato.Id, c.Id));

            return prato;
        }

        public static List<Caracteristica> CarregarCaracteristicas() => new List<Caracteristica> { new Caracteristica("MASSA") };

        public static string Obter(List<Caracteristica> caracteristicas) => caracteristicas.Last().Descricao;

        public static Caracteristica Obter(List<Caracteristica> caracteristicas, string caracteristica) => caracteristicas.FirstOrDefault(x => x.Descricao == caracteristica);
      
    }
}

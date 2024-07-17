using JogoGourmet.App.Models;
using JogoGourmet.App.Services;

namespace JogoGourmet.App.Applications
{
    public static class QuestoesApp
    {
        public static List<Prato> Pratos = new List<Prato>();
        public static List<Caracteristica> Caracteristicas = new List<Caracteristica>();
        public static void CargaInicial()
        {
            Pratos = PratoService.CarregarPratos();
            Caracteristicas = CaracteristicaService.CarregarCaracteristicas();
        }

        public static void PerguntarCaracteristica()
        {
            QuestoesApp.AfirmarCaracteristica(Pratos, CaracteristicaService.Obter(Caracteristicas));
        }

        public static void SolicitacaoInicial()
        {
            Console.Clear();
            Console.WriteLine("Pense em um prato que gosta");
            AcoesApp.Ok();
        }

        public static void AcertoPrato()
        {
            Console.WriteLine("Acertei de novo!");
            Console.ReadKey();
            SolicitacaoInicial();
        }

        public static void AfirmarCaracteristica(List<Prato> Pratos, string caracteristica)
        {
            foreach (var item in Caracteristicas)
                PerguntarCaracteristica(item.Descricao);

            AfirmacaoPrato(Pratos, Pratos.Last().Descricao);
        }

        public static void PerguntarCaracteristica(string caracteristica)
        {
            Console.WriteLine($"O prato que você pensou é {caracteristica}?");
            var valor = AcoesApp.OpcaoResposta();

            if (valor)
            {
                var pratos = PratoService.ObterPratosPorCaracteristica(Pratos, caracteristica);

                AfirmacaoPrato(pratos);
            }
        }

        public static void AfirmacaoPrato(List<Prato> pratos, string prato = null)
        {
            Prato acheiPrato;
            if (!string.IsNullOrEmpty(prato))
            {
                Console.WriteLine($"O prato que você pensou é {prato}?");

                if (AcoesApp.OpcaoResposta())
                    AcertoPrato();
            }
            else
            {
                foreach (var item in pratos)
                {
                    acheiPrato = Pratos.FirstOrDefault(x => x.Descricao == item.Descricao);

                    Console.WriteLine($"O prato que você pensou é {acheiPrato.Descricao}?");

                    if (AcoesApp.OpcaoResposta())
                        AcertoPrato();
                }
            }


            Console.WriteLine("Qual é o prato que você pensou?");
            var novoPrato = PratoService.AdicionarPrato(Console.ReadLine());
            Console.WriteLine($"{novoPrato.Descricao} é ________ mas {Pratos.Last().Descricao} não");
            Pratos.Add(novoPrato);
            var novaCaracteristica = CaracteristicaService.AdicionarCaracteristica(Caracteristicas, Console.ReadLine());

            var tem = Caracteristicas.FirstOrDefault(x => x.Descricao == novaCaracteristica.Descricao.ToUpper());
            if (tem is null)
                Caracteristicas.Add(novaCaracteristica);

            PratoService.AdicionarCaracteristica(novoPrato, novaCaracteristica);

            Console.Clear();
        }
    }
}

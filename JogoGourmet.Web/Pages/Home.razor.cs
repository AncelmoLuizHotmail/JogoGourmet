using JogoGourmet.Domain.Entities;
using JogoGourmet.Domain.Interfaces;
using Microsoft.AspNetCore.Components;

namespace JogoGourmet.Web.Pages
{
    public partial class Home
    {
        [Inject]
        private IPratoInfra PratoInfra { get; set; } = null!;

        [Parameter]
        public string Caracteristica { get; set; } = string.Empty;
        [Parameter]
        public string NovaCaracteristica { get; set; } = string.Empty;

        [Parameter]
        public string Prato { get; set; } = string.Empty;

        [Parameter]
        public string NovoPrato { get; set; } = string.Empty;

        private static List<Prato> _pratos = new List<Prato>();

        private string _nomePrato { get; set; } = string.Empty;
        private string _nomeCaracteristica { get; set; } = string.Empty;
        private bool PanelStart { get; set; } = true;
        private bool PanelStep01 { get; set; } = true;
        private bool PanelStep02 { get; set; } = true;
        private bool PanelStep04 { get; set; } = true;
        private bool PanelSuccess { get; set; } = true;
        private bool PanelAddPrato { get; set; } = true;
        private bool PanelAddCaracteristica { get; set; } = true;

        protected override async Task OnInitializedAsync()
        {
            PanelStart = false;
            _pratos = PratoInfra.CarregarPratos();
        }

        private void ShowStart()
        {
            LimparDados();
            PanelStart = true;
            PanelStep01 = false;
            PanelSuccess = true;
        }
        private void ShowStep01()
        {
            PerguntaInicial();
            PanelStep01 = true;
            PanelStep02 = false;
            PanelAddPrato = true;
        }
        private void ShowStep02()
        {
            PanelStep02 = true;
            PanelStep04 = false;
        }
        private void ShowStep03(bool opcao)
        {
            if (opcao)
            {
                var prato = BuscarPrato(Caracteristica);
                AfirmacaoDoPrato(prato.Caracteristica.Id);
                PanelStep02 = true;
                PanelStep04 = false;
            }
            else
            {
                var prato = BuscarPrato("Sobremesa");
                AfirmacaoDoPrato(prato.Caracteristica.Id);
                PanelStep02 = true;
                PanelStep04 = false;
            }
        }
        private void ShowStep04(bool opcao)
        {
            if (opcao)
            {
                PanelSuccess = false;
                PanelStep04 = true;
            }
            else
            {
                LimparDados();
                PanelAddPrato = false;
                PanelStep04 = true;
            }
        }

        private void ShowAdicionarPrato()
        {
            NovoPrato = AdicionarPrato();
            Prato = BuscarDescricaoPrato(1);

            PanelAddPrato = true;
            PanelAddCaracteristica = false;
        }

        private void ShowAdicionarCaracteristica()
        {
            AdicionarCaracteristica(NovoPrato);

            PanelAddCaracteristica = true;
            PanelStep01 = false;
        }

        private void PerguntaInicial()
        {
            if (_pratos.Count == 2)
                Caracteristica = _pratos[0].Caracteristica.Descricao;
            else
            {
                int index = _pratos.Count - 1;
                Caracteristica = _pratos[index].Caracteristica.Descricao;
            }
        }

        private void AfirmacaoDoPrato(Guid id)
        {
            var prato = _pratos.FirstOrDefault(c => c.Caracteristicas.Any(x => x.CaracteristicaId == id));
            Prato = prato?.Descricao ?? "Erro!";
        }

        private string BuscarDescricaoPrato(int index)
        {
            return _pratos[index].Descricao;
        }
        private Prato BuscarPrato(string descricao)
        {
            var prato = _pratos.FirstOrDefault(c => c.Caracteristica.Descricao == descricao);
           
            return prato;
        }

        private string AdicionarPrato()
        {
            var novoPrato = PratoInfra.AdicionarPrato(_nomePrato);
            _pratos.Add(novoPrato);

            return novoPrato.Descricao;
        }

        private void AdicionarCaracteristica(string desc)
        {
            var prato = PratoInfra.ObterPrato(_pratos, desc);
            var pratosAtulizados = PratoInfra.AdicionarCaracteristica(prato, _nomeCaracteristica);
        }

        private void LimparDados()
        {
            Prato = string.Empty;
            NovoPrato = string.Empty;
            Caracteristica = string.Empty;
            NovaCaracteristica = string.Empty;
            _nomePrato = string.Empty;
            _nomeCaracteristica = string.Empty;
        }
    }
}

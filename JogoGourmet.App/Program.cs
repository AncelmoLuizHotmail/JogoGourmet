// See https://aka.ms/new-console-template for more information
using JogoGourmet.App.Applications;

bool valor;

InteracaoApp.CargaInicial();

Console.WriteLine("Jogo Gourmet");
Console.WriteLine();

do
{
    Console.Clear();

    QuestoesApp.SolicitacaoInicial();
    InteracaoApp.PerguntarCaracteristica();

    Console.WriteLine("Vamos jogar de novo?");

    valor = AcoesApp.OpcaoResposta();
} while (valor);



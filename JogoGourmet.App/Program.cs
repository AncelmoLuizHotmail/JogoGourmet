// See https://aka.ms/new-console-template for more information
using JogoGourmet.App.Applications;

bool valor;

InteracaoApp.CargaInicial();

Console.WriteLine("Jogo Gourmet");
Console.WriteLine();

do
{
	try
	{
        Console.Clear();

        QuestoesApp.PerguntarCaracteristica();

        Console.WriteLine("Vamos jogar de novo?");

        valor = AcoesApp.OpcaoResposta();
    }
	catch (Exception)
	{
        QuestoesApp.PerguntarCaracteristica();
        valor = true;
    }
} while (valor);



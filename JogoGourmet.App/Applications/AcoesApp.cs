namespace JogoGourmet.App.Applications
{
    public static class AcoesApp
    {
        public static void Ok()
        {
            Console.WriteLine();
            Console.Write("Pressione qualquer tecla para continuar...");
            Console.ReadKey();
            Console.Clear();
        }
       
        public static void Cancelar()
        {
            Console.WriteLine("Cancelar");
            Console.ReadKey();
            Console.Clear();
        }
        public static bool OpcaoResposta()
        {
            Console.WriteLine("(S) SIM  (N) NÃO");
            var resp = Convert.ToChar(Console.ReadLine().ToUpper());
            Console.Clear();

            return resp == 'S' ? true : false;
        }
    }
}

namespace carteira_de_clientes;

static class Program
{
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();
        Application.Run(new TelaLogin());
    }    
}
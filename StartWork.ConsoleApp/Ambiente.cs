namespace StartWork.ConsoleApp;

public class Ambiente
{
    private readonly Config _config;

    public Ambiente(Config config)
    {
        _config = config;
    }
    public void IniciarTrabalho()
    {
        Logger.Escrever("\nIniciando ferramentas de trabalho... 🚀");

        // No modo trabalho, abre as comunicações normais
        Processos.AbrirPorProtocolo("ms-outlook://");
        Processos.AbrirPorProtocolo("msteams://");

        // Abre os links de trabalho no Edge           
        string urls = string.Join(" ", _config.LinksTrabalho);

        Navegador.AbrirEdgeComAbas(urls);

        // Dispara o clique do login do Salesforce após 5 segundos
        if (Navegador.EsperarJanelaEdge(15))
        {
            Thread.Sleep(3000); // apenas para carregar a página
            Salesforce.PressionarBotaoLogin();
        }
    }

    public void IniciarEstudo()
    {
        Logger.Escrever("\nIniciando ambiente de estudo... 📚");

        // No modo estudo, NÃO abre Outlook e NÃO abre o Teams.
        // Abre apenas o Edge com as abas do OneNote (ou outros sites de estudo que você queira)
        string urls = string.Join(" ", _config.LinksEstudo);

        Navegador.AbrirEdgeComAbas(urls);
    }
}
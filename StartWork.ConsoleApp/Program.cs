namespace StartWork.ConsoleApp;

class Program
{
    static void Main(string[] args)
    {
        TimeOnly horaAgora = TimeOnly.FromDateTime(DateTime.Now);

        Config config = Config.Carregar();
        Ambiente ambiente = new(config);
        TimeOnly inicioTrabalho = TimeOnly.Parse(config.InicioTrabalho);
        TimeOnly fimTrabalho = TimeOnly.Parse(config.FimTrabalho);

        Processos.EncerrarProcessosAtivos();    

        if (horaAgora >= inicioTrabalho && horaAgora <= fimTrabalho)
        {
            ambiente.IniciarTrabalho();
        }
        else
        {
            ambiente.IniciarEstudo();
        }
    }

}
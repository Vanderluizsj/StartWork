using System.Diagnostics;

namespace StartWork.ConsoleApp;
public static class Processos
{
    public static void EncerrarProcessosAtivos()
    {
        Logger.Escrever("Limpando ambiente anterior... 🧹");

            // Lista com os nomes dos processos executáveis no Windows
            // Nota: O Novo Outlook roda sob o nome "olk", o Teams moderno como "ms-teams" ou "Teams"
            List<string> processosParaFechar =
            [
                "olk",
                "ms-teams",
                "Teams"
            ];

            foreach (string nomeProcesso in processosParaFechar)
            {
                try
                {
                    // Busca todos os processos ativos com esse nome
                    Process[] processos = Process.GetProcessesByName(nomeProcesso);

                    foreach (Process p in processos)
                    {
                        if (!p.CloseMainWindow())
                        {
                            p.Kill();
                        }
                        else
                        {
                            p.WaitForExit(5000);

                            if (!p.HasExited)
                                p.Kill();
                        }
                    }

                    if (processos.Length > 0)
                    {
                        Logger.Escrever($"[Limpeza] {nomeProcesso} encerrado com sucesso.");
                    }
                }
                catch (Exception ex)
                {
                    // Ignora erros caso o processo já estivesse fechado ou sem permissão
                    Logger.Escrever($"[Erro] Não foi possível fechar {nomeProcesso}: {ex.Message}");
                }
            }

            // Um pequeno delay para o Windows processar os fechamentos antes de abrir os novos
            Thread.Sleep(1500);
    }

    public static void AbrirPorProtocolo(string protocolo)
    {
        try
            {
                Process.Start(new ProcessStartInfo { FileName = protocolo, UseShellExecute = true });
            }
            catch (Exception ex) { Logger.Escrever($"[Erro] Erro ao abrir protocolo: {ex.Message}"); }
    }
}
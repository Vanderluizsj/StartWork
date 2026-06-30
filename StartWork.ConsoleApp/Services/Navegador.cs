using System.Diagnostics;

namespace StartWork.ConsoleApp;

public static class Navegador
{
    public static void AbrirEdgeComAbas(string urls)
    {
        try
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = "msedge.exe",
                Arguments = urls,
                UseShellExecute = true
            });
            Logger.Escrever("[Sucesso] Edge iniciado.");
        }
        catch (Exception ex)
        {
            Logger.Escrever($"[Erro] Falha ao abrir Edge. Motivo: {ex.Message}");
        }
    }

    public static bool EsperarJanelaEdge(int timeoutSegundos)
    {
        Stopwatch sw = Stopwatch.StartNew();

        while (sw.Elapsed.TotalSeconds < timeoutSegundos)
        {
            foreach (Process processo in Process.GetProcessesByName("msedge"))
            {
                if (processo.MainWindowHandle != IntPtr.Zero)
                    return true;
            }

            Thread.Sleep(500);
        }

        return false;
    }
}

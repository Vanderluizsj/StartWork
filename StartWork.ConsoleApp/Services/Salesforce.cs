using System.Diagnostics;

namespace StartWork.ConsoleApp;

public static class Salesforce
{
    public static void PressionarBotaoLogin()
    {
        try
        {
            Logger.Escrever("Efetuando login automático no Salesforce... 🔑");

            // Usamos o PowerShell para simular a tecla 'Enter' na janela ativa do Edge.
            // Como o Edge foca no botão de login ou no formulário ao carregar com senha salva,
            // mandar um comando de 'Enter' dispara o <input type="submit" id="Login"> na hora!
            string scriptPowerShell = "$wshell = New-Object -ComObject wscript.shell; " +
                                      "$wshell.AppActivate('Edge'); " +
                                      "Sleep 1; " +
                                      "$wshell.SendKeys('{ENTER}')";

            ProcessStartInfo psi = new ProcessStartInfo
            {
                FileName = "powershell",
                Arguments = $"-Command \"{scriptPowerShell}\"",
                WindowStyle = ProcessWindowStyle.Hidden, // Roda invisível para não atrapalhar
                CreateNoWindow = true
            };

            Process.Start(psi);
        }
        catch (Exception ex)
        {
            Logger.Escrever($"[Erro] Erro ao simular clique de login: {ex.Message}");
        }
    }
}
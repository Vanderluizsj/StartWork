using System;

namespace StartWork.ConsoleApp
{
    public static class Logger
    {
        private static readonly string pastaLogs = "Logs";
        private static readonly string caminhoLog = Path.Combine(pastaLogs, "StartWork.txt");

        static Logger()
        {
            Directory.CreateDirectory(pastaLogs);

            // Se existir um log de outro dia, remove
            if (File.Exists(caminhoLog))
            {
                DateTime ultimaAlteracao = File.GetLastWriteTime(caminhoLog);

                if (ultimaAlteracao.Date != DateTime.Today)
                {
                    File.Delete(caminhoLog);
                }
            }

            // Se o arquivo não existir, cria com cabeçalho
            if (!File.Exists(caminhoLog))
            {
                CriarNovoArquivo();
            }
        }

        private static void CriarNovoArquivo()
        {
            using StreamWriter writer = new(caminhoLog, false);

            writer.WriteLine("=========================================================");
            writer.WriteLine("                    START WORK");
            writer.WriteLine($"Data: {DateTime.Now:dd/MM/yyyy}");
            writer.WriteLine("=========================================================");
            writer.WriteLine();
        }

        public static void Escrever(string mensagem)
        {
            string linha = $"[{DateTime.Now:HH:mm:ss}] {mensagem}";

            File.AppendAllText(caminhoLog, linha + Environment.NewLine);

            Console.WriteLine(linha);
        }
    }
}
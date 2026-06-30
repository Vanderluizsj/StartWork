using System.Text.Json;

namespace StartWork.ConsoleApp
{
    public class Config
    {
        public string InicioTrabalho { get; set; } = "";
        public string FimTrabalho { get; set; } = "";

        public List<string> LinksTrabalho { get; set; } = new();
        public List<string> LinksEstudo { get; set; } = new();

        public static Config Carregar()
        {
            string json = File.ReadAllText("config.json");

            return JsonSerializer.Deserialize<Config>(json)!;
        }
    }
}
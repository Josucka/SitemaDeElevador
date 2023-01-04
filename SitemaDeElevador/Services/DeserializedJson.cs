using Newtonsoft.Json;
using System.Text.Json;

namespace SitemaDeElevador.Services
{
    public class DeserializedJson
    {
        public Predios DeserializeJson(string filePath)
        {
            // Verifica se o arquivo JSON existe
            if (!File.Exists(filePath))
            {
                Console.WriteLine("O arquivo arquivo.json não foi encontrado!");
                return new Predios { Predio = new Predio[0] };
            }

            // Lê o conteúdo do arquivo JSON
            string jsonString = File.ReadAllText(filePath);

            // Deserializa o JSON em uma instância da classe Predios
            return JsonConvert.DeserializeObject<Predios>(jsonString);
        }
    }
}

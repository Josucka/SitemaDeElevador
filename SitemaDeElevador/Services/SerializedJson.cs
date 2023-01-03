using Newtonsoft.Json;

namespace SitemaDeElevador.Services
{
    public class SerializedJson
    {
        public static T Ler<T>(string caminhoArquivo)
        {
            // Verifica se o caminho do arquivo é válido
            if (!File.Exists(caminhoArquivo))
            {
                throw new FileNotFoundException("O arquivo especificado não foi encontrado.");
            }

            // Lê o conteúdo do arquivo
            string conteudo = File.ReadAllText(caminhoArquivo);

            // Deserializa o JSON para o tipo especificado
            return JsonConvert.DeserializeObject<T>(conteudo);
        }
    }
}

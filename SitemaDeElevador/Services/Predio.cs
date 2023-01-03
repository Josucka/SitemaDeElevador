using Newtonsoft.Json;

namespace SitemaDeElevador.Services
{
    public class Predio
    {
        [JsonProperty("andar")]
        public int Andar { get; set; }

        [JsonProperty("elevador")]
        public string Elevador { get; set; }

        [JsonProperty("turno")]
        public string Turno { get; set; }
    }
}
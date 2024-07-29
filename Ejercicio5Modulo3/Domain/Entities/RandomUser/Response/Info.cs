using System.Text.Json.Serialization;

namespace Ejercicio5Modulo3.Domain.Entities.RandomUser.Response
{
    public class Info
    {

        [JsonPropertyName("seed")]
        public string Seed { get; set; }

        //era int
        [JsonPropertyName("results")]
        public string Results { get; set; }

        //era int
        [JsonPropertyName("page")]
        public string Page { get; set; }

        [JsonPropertyName("version")]
        public string Version { get; set; }

    }
}

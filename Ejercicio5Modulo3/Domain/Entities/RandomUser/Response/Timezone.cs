using System.Text.Json.Serialization;

namespace Ejercicio5Modulo3.Domain.Entities.RandomUser.Response
{
    public class Timezone
    {

        [JsonPropertyName("offset")]
        public string Offset { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }
    }
}

using System.Text.Json.Serialization;

namespace Ejercicio5Modulo3.Domain.Entities.RandomUser.Response
{
    public class Coordinates
    {

        [JsonPropertyName("latitude")]
        public string Latitude { get; set; }

        [JsonPropertyName("longitude")]
        public string Longitude { get; set; }
    }
}

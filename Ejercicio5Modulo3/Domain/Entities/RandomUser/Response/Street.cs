using System.Text.Json.Serialization;

namespace Ejercicio5Modulo3.Domain.Entities.RandomUser.Response
{
    public class Street
    {

        [JsonPropertyName("number")]
        public int Number { get; set; }


        [JsonPropertyName("name")]
        public string Name { get; set; }

    }
}

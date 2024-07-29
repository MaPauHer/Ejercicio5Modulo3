using System.Text.Json.Serialization;

namespace Ejercicio5Modulo3.Domain.Entities.RandomUser.Request
{
    public class GetRandomUserRequest
    {

        [JsonPropertyName("results")]
        public int Results { get; set; }

    }
}

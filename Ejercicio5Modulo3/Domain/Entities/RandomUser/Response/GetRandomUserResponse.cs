using System.Text.Json.Serialization;

namespace Ejercicio5Modulo3.Domain.Entities.RandomUser.Response
{
    public class GetRandomUserResponse
    {

        [JsonPropertyName("results")]
        public List<Result> Results { get; set; }


        //[JsonPropertyName("info")]
        //public Info Info { get; set; }

    }
}

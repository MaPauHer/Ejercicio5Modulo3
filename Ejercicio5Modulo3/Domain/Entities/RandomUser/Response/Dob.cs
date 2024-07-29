using System.Text.Json.Serialization;

namespace Ejercicio5Modulo3.Domain.Entities.RandomUser.Response
{
    public class Dob
    {

        //[JsonPropertyName("date")]
        //public string Date { get; set; }


        [JsonPropertyName("age")]
        public int Age { get; set; }
    }
}

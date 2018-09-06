using Newtonsoft.Json;

namespace Domain.Entities
{
    public class Movie
    {
        public string Id { get; set; }

        [JsonProperty("Titulo")]
        public string Title { get; set; }

        [JsonProperty("Ano")]
        public int ReleaseYear { get; set; }

        [JsonProperty("Nota")]
        public double Score { get; set; }
    }
}

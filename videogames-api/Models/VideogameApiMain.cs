using System.Text.Json.Serialization;

namespace videogames_api.Models {
    public class VideogameApiMain {
        [JsonInclude]
        [JsonPropertyName("results")]
        public List<VideogameResult> Results { get; set; }
    }
}

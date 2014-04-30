using Newtonsoft.Json;

namespace Moves.Net.Model
{
    [JsonObject]
    public class Place
    {   
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("location")]
        public Location Location { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("foursquareId")]
        public string FoursquareId { get; set; }

        [JsonProperty("foursquareCategoryIds")]
        public string[] FoursquareCategoryIds { get; set; }
    }
}

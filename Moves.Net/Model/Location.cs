using Newtonsoft.Json;

namespace Moves.Net.Model
{
    [JsonObject]
	public class Location
    {
        [JsonProperty("lat")]
        public double Latitude { get; set; }

        [JsonProperty("lon")]
        public double Longitude { get; set; }
    }
}

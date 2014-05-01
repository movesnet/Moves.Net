using Newtonsoft.Json;

namespace Moves.Net.Model
{
    [JsonObject]
	public class Segment
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("startTime")]
        public string StartTime { get; set; }

        [JsonProperty("endTime")]
        public string EndTime { get; set; }

        [JsonProperty("place")]
        public Place Place { get; set; }

        [JsonProperty("activities")]
        public Activity[] Activities { get; set; }

        [JsonProperty("lastUpdate")]
        public string LastUpdate { get; set; }        
    }
}

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Moves.Net.Model.Places
{
    [JsonObject]
    public class Segment
    {
        [JsonProperty("type")]
        public string type { get; set; }

        [JsonProperty("startTime")]
        public string startTime { get; set; }

        [JsonProperty("endTime")]
        public string endTime { get; set; }

        [JsonProperty("place")]
        public Place place { get; set; }

        [JsonProperty("lastUpdate")]
        public string lastUpdate { get; set; }        
    }
}

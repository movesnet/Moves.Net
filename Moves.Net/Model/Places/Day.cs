using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Moves.Net.Model.Places
{    
    [JsonObject]
    public class Day
    {
        [JsonProperty("date")]
        public string date { get; set; }

        [JsonProperty("segments")]
        public List<Segment> segments { get; set; }

        [JsonProperty("lastUpdate")]
        public string lastUpdate { get; set; }
    }
}

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Moves.Net.Model.Places
{
    [JsonObject]
    public class Place
    {   
        [JsonProperty("id")]
        public string id { get; set; }

        [JsonProperty("type")]
        public string type { get; set; }

        [JsonProperty("location")]
        public Location location { get; set; }

        [JsonProperty("name")]
        public string name { get; set; }

        [JsonProperty("foursquareId")]
        public string foursquareId { get; set; }

        [JsonProperty("foursquareCategoryIds")]
        public List<string> foursquareCategoryIds { get; set; }
    }
}

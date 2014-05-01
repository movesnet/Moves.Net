﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Moves.Net.Model
{
    [JsonObject]
    public class ActivityList
    {
        [JsonProperty("activity")]
        public string Activity { get; set; }

        [JsonProperty("geo")]
        public bool Geo { get; set; }

        [JsonProperty("place")]
        public bool Place { get; set; }

        [JsonProperty("color")]
        public string Color { get; set; }

        [JsonProperty("units")]
        public string Units { get; set; }
    }
}




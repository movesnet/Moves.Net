using Newtonsoft.Json;
using System;

namespace Moves.Net.Model
{
	[JsonObject]
	public class Trackpoint : Location
	{
        [JsonProperty("time")]
        public string Time { get; set; }
	}
}

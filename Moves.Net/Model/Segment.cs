using Newtonsoft.Json;
using System;

namespace Moves.Net.Model
{
	[JsonObject]
	public class Segment
	{
		[JsonProperty("type")]
		public string Type { get; set; }

		[JsonProperty("startTime")]
		public DateTime StartTime { get; set; }

		[JsonProperty("endTime")]
		public DateTime EndTime { get; set; }

		[JsonProperty("place")]
		public Place Place { get; set; }

		[JsonProperty("activities")]
		public Activity[] Activities { get; set; }

		[JsonProperty("lastUpdate")]
		public string LastUpdate { get; set; }
	}
}
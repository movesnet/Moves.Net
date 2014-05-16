using Newtonsoft.Json;
using System;

namespace Moves.Net.Model
{
	[JsonObject]
	public class Day
	{
		[JsonProperty("date")]
		public DateTime Date { get; set; }

		[JsonProperty("segments")]
		public Segment[] Segments { get; set; }

		[JsonProperty("summary")]
		public Summary[] Summaries { get; set; }

		[JsonProperty("lastUpdate")]
		public DateTime LastUpdate { get; set; }
	}
}
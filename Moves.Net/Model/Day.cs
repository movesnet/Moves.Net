using Newtonsoft.Json;

namespace Moves.Net.Model
{
	[JsonObject]
	public class Day
	{
		[JsonProperty("date")]
		public string Date { get; set; }

		[JsonProperty("segments")]
		public Segment[] Segments { get; set; }

		[JsonProperty("summary")]
		public Summary[] Summaries { get; set; }

		[JsonProperty("lastUpdate")]
		public string LastUpdate { get; set; }
	}
}
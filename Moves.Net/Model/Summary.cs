using Newtonsoft.Json;

namespace Moves.Net.Model
{
	[JsonObject]
	public class Summary
	{
		[JsonProperty("activity")]
		public string Activity { get; set; }

		[JsonProperty("group")]
		public string Group { get; set; }

		[JsonProperty("duration")]
		public long Duration { get; set; }

		[JsonProperty("distance")]
		public long Distance { get; set; }

		[JsonProperty("steps")]
		public long Steps { get; set; }

		[JsonProperty("calories")]
		public long Calories { get; set; }
	}
}
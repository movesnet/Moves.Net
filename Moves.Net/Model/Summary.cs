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
		public double Duration { get; set; }

		[JsonProperty("distance")]
		public double Distance { get; set; }

		[JsonProperty("steps")]
		public double Steps { get; set; }

		[JsonProperty("calories")]
		public double Calories { get; set; }
	}
}
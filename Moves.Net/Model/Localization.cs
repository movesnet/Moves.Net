using Newtonsoft.Json;

namespace Moves.Net.Model
{
	[JsonObject]
	public class Localization
	{
		[JsonProperty("language")]
		public string Language { get; set; }

		[JsonProperty("locale")]
		public string Locale { get; set; }

		[JsonProperty("firstWeekDay")]
		public int FirstWeekDay { get; set; }

		[JsonProperty("metric")]
		public bool Metric { get; set; }
	}
}
using Newtonsoft.Json;

namespace Moves.Net.Model
{
	[JsonObject]
	public class Profile
	{
		[JsonProperty("firstDate")]
		public string FirstDate { get; set; }

		[JsonProperty("currentTimeZone")]
		public TimeZone CurrentTimeZone { get; set; }

		[JsonProperty("localization")]
		public Localization Localization { get; set; }

		[JsonProperty("caloriesAvailable")]
		public bool CaloriesAvailable { get; set; }

		[JsonProperty("platform")]
		public string Platform { get; set; }
	}
}
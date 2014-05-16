using Newtonsoft.Json;

namespace Moves.Net.Model
{
	[JsonObject]
	public class User
	{
		[JsonProperty("userId")]
		public string UserId { get; set; }

		[JsonProperty("profile")]
		public Profile Profile { get; set; }
	}
}
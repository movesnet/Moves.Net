using Newtonsoft.Json;

namespace Moves.Net.Model
{
	[JsonObject]
	public class Error
	{
		[JsonProperty("error")]
		public string Code { get; set; }
	}
}
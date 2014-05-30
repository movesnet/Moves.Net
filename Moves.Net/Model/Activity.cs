using Newtonsoft.Json;
using System;

namespace Moves.Net.Model
{
	[JsonObject]
	public class Activity
	{
		[JsonProperty("activity")]
		public string ActivityType { get; set; }

		[JsonProperty("group")]
		public string Group { get; set; }

		[JsonProperty("manual")]
		public bool Manual { get; set; }

		[JsonProperty("startTime")]
		public DateTime StartTime { get; set; }

		[JsonProperty("endTime")]
		public DateTime EndTime { get; set; }

		[JsonProperty("duration")]
		public long Duration { get; set; }

		[JsonProperty("distance")]
		public long Distance { get; set; }

		[JsonProperty("steps")]
		public long Steps { get; set; }

		[JsonProperty("calories")]
		public long Calories { get; set; }

		[JsonProperty("trackPoints")]
		public Trackpoint[] TrackPoints { get; set; }
	}
}
﻿using Newtonsoft.Json;
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
		public double Duration { get; set; }

		[JsonProperty("distance")]
		public double Distance { get; set; }

		[JsonProperty("steps")]
		public double Steps { get; set; }

		[JsonProperty("calories")]
		public double Calories { get; set; }

		[JsonProperty("trackPoints")]
		public Trackpoint[] TrackPoints { get; set; }
	}
}
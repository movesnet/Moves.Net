﻿using Newtonsoft.Json;
using System;

namespace Moves.Net.Model
{
	[JsonObject]
	public class TimeZone
	{
		[JsonProperty("id")]
		public string Id { get; set; }

		[JsonProperty("offset")]
		public int Offset { get; set; }
	}
}

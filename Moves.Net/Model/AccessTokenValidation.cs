﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Moves.Net.Model
{
	[JsonObject]
	public class AccessTokenValidation
	{
		[JsonProperty("client_id")]
		public string ClientId { get; set; }

		[JsonProperty("scope")]
		public string Scope { get; set; }

		[JsonProperty("expires_in")]
		public string ExpiresIn { get; set; }

		[JsonProperty("user_id")]
		public string UserId { get; set; }
	}
}

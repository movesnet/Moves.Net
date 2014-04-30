using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Moves.Net.Model
{
	[JsonObject]
	public class ErrorResource
	{
		[JsonProperty("error")]
		public string Code { get; set; }
	}
}

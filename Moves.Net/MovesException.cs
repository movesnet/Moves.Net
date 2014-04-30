using Moves.Net.Model;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Moves.Net
{
	[Serializable]
	public class MovesException : Exception
	{
		public static MovesException FromErrorResponse(IRestResponse response) {
			var error = JsonConvert.DeserializeObject<ErrorResource>(response.Content);

			return new MovesException(error.Code);
		}

		public MovesException() { }
		public MovesException(string message) : base(message) { }
		public MovesException(string message, Exception inner) : base(message, inner) { }
		protected MovesException(
		  System.Runtime.Serialization.SerializationInfo info,
		  System.Runtime.Serialization.StreamingContext context)
			: base(info, context) { }
	}
}

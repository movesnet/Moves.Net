using Moves.Net.Model;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Net;

namespace Moves.Net
{
	[Serializable]
	public class MovesException : Exception
	{
		public HttpStatusCode StatusCode { get; private set; }

		public MovesException()
		{
		}

		public MovesException(string message)
			: base(message)
		{
		}

		public MovesException(string message, HttpStatusCode statusCode)
			: base(message)
		{
			this.StatusCode = statusCode;
		}

		public MovesException(string message, Exception inner)
			: base(message, inner)
		{
		}

		protected MovesException(
		  System.Runtime.Serialization.SerializationInfo info,
		  System.Runtime.Serialization.StreamingContext context)
			: base(info, context) { }

		public static MovesException FromErrorResponse(IRestResponse response)
		{
			var error = JsonConvert.DeserializeObject<Error>(response.Content);
			return new MovesException(error.Code, response.StatusCode);
		}
	}
}
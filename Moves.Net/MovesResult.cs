using Moves.Net.Model;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace Moves.Net
{
	public class MovesResult<T>
	{
		private static T DeserializeContent<T>(IRestResponse response)
		{
			return DeserializeContent<T>(response.Content);
		}
		private static T DeserializeContent<T>(string content)
		{
			return JsonConvert.DeserializeObject<T>(content);
		}

		public MovesResult(IRestResponse response)
		{
			ETag = response.Headers.Where(x => x.Name == "ETag").Select(x => x.Value.ToString()).FirstOrDefault();
			Status = response.StatusCode;
			
			if ((int)response.StatusCode >= 400)
			{
				throw MovesException.FromErrorResponse(response);
			}
			else if (response.StatusCode != HttpStatusCode.NotModified)
			{
				Data = DeserializeContent<T>(response);
			}
		}

		public string ETag { get; set; }

		public HttpStatusCode Status { get; set; }

		public T Data { get; set; }
	}
}

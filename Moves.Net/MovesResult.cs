using Newtonsoft.Json;
using RestSharp;
using System.Linq;
using System.Net;

namespace Moves.Net
{
	public class MovesResult<TResult>
	{
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
				Data = JsonConvert.DeserializeObject<TResult>(response.Content);
			}
		}

		public string ETag { get; set; }

		public HttpStatusCode Status { get; set; }

		public TResult Data { get; set; }
	}
}
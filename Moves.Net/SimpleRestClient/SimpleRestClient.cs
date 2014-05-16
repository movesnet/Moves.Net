using RestSharp;
using RestSharp.Contrib;
using RestSharp.Deserializers;
using System.Linq;

namespace Moves.Net
{
	public class SimpleRestClient : ISimpleRestClient
	{
		public string BaseUrl { get; set; }

		public Credentials Credentials { get; set; }

		public SimpleRestClient(string baseUrl, Credentials credentials)
		{
			this.BaseUrl = baseUrl;
			this.Credentials = credentials;
		}

		public IRestResponse Get(IRestRequest request)
		{
			return Get(BaseUrl, request);
		}

		public IRestResponse Get(string baseUrl, IRestRequest request)
		{
			request.Method = Method.GET;

			return ExecuteRequest(baseUrl, request);
		}

		public IRestResponse Post(IRestRequest request)
		{
			return Post(BaseUrl, request);
		}

		public IRestResponse Post(string baseUrl, IRestRequest request)
		{
			request.Method = Method.POST;

			return ExecuteRequest(baseUrl, request);
		}

		public IRestResponse ExecuteRequest(string baseUrl, IRestRequest request)
		{
			var deserializer = new JsonDeserializer();
			var client = new RestClient(baseUrl);
			client.AddHandler("application/json", deserializer);
			client.AddHandler("text/json", deserializer);

			if (!string.IsNullOrEmpty(this.Credentials.AccessToken))
			{
				request.AddHeader("Authorization", string.Format("Bearer {0}", this.Credentials.AccessToken));
			}

			return client.Execute(request);
		}

		public string CreateResourceUrl(string format, params object[] args)
		{
			return string.Format(format, args.Select(x => x != null ? HttpUtility.UrlEncode(x.ToString()) : string.Empty).ToArray());
		}

		public IRestRequest CreateRequest(string format, params object[] args)
		{
			var resource = CreateResourceUrl(format, args);

			return new RestRequest(resource)
			{
				RequestFormat = DataFormat.Json,
				JsonSerializer = new RestSharp.Serializers.JsonSerializer()
			};
		}
	}
}
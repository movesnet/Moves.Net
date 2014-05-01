using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestSharp;
using RestSharp.Contrib;
using RestSharp.Deserializers;

namespace Moves.Net
{
	public abstract class RestClientBase
	{
		protected Credentials Credentials { get; private set; }        
        
		public string BaseUrl { get; private set; }
		        
		public RestClientBase(string baseUrl, Credentials credentials)
		{
			this.BaseUrl = baseUrl;
			this.Credentials = credentials;
		}
		protected string CreateResourceUrl(string format, params object[] args)
		{
			return string.Format(format, args.Select(x => x != null ? HttpUtility.UrlEncode(x.ToString()) : string.Empty).ToArray());
		}

		protected IRestRequest CreateRequest(string format, params object[] args)
		{
			var resource = CreateResourceUrl(format, args);

			return new RestRequest(resource)
			{
				RequestFormat = DataFormat.Json,
				JsonSerializer = new RestSharp.Serializers.JsonSerializer()
			};
		}

		protected IRestResponse Get(IRestRequest request)
		{
			return Get(BaseUrl, request);
		}

		protected IRestResponse Get(string baseUrl, IRestRequest request)
		{
			request.Method = Method.GET;

			return ExecuteRequest(baseUrl, request);
		}

		protected IRestResponse Post(IRestRequest request)
		{
			return Post(BaseUrl, request);
		}

		protected IRestResponse Post(string baseUrl, IRestRequest request)
		{
			request.Method = Method.POST;

			return ExecuteRequest(baseUrl, request);
		}

		protected static IRestResponse ExecuteRequest(string baseUrl, IRestRequest request)
		{
			var deserializer = new JsonDeserializer();
			var client = new RestClient(baseUrl);
			client.AddHandler("application/json", deserializer);
			client.AddHandler("text/json", deserializer);

			return client.Execute(request);
		}
	}
}

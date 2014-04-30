using Moves.Net.Model.Authentication;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Contrib;
using RestSharp.Deserializers;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Moves.Net.Endpoints
{  
    public abstract class EndpointBase
    {
        public Credentials Credentials { get; private set; }
        public static string MovesAuthenticationBaseUrl = "https://api.moves-app.com/oauth/v1/";
        public static string MovesApiBaseUrl = "https://api.moves-app.com/api/1.1/";

        public EndpointBase(Credentials credentials)
        {
            this.Credentials = credentials;
        }

        protected string CreateResourceUrl(string format, params object[] args)
        {
            return string.Format(format, args.Select(x => x != null ? HttpUtility.UrlEncode(x.ToString()) : string.Empty).ToArray());
        }

        protected RestRequest CreateRequest(string format, params object[] args)
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
            return Get(MovesApiBaseUrl, request);
        }

        protected IRestResponse Get(string baseUrl, IRestRequest request)
        {
            request.Method = Method.GET;

            return ExecuteRequest(baseUrl, request);
        }

        protected IRestResponse Post(IRestRequest request) {
            return Post(MovesApiBaseUrl, request);
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

        protected T DeserializeContent<T>(IRestResponse response)
        {
            return DeserializeContent<T>(response.Content);
        }
        protected T DeserializeContent<T>(string content)
        {
            return JsonConvert.DeserializeObject<T>(content);
        }      
    }
}

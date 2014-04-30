using Moves.Net.Model;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Contrib;
using RestSharp.Deserializers;
using RestSharp.Serializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Moves.Net
{
    public class MovesService
	{
		private static string MovesBaseUrl = "https://api.moves-app.com/oauth/v1/";
		
		#region RestSharp Helpers

		private RestRequest CreateRequest(string format, params object[] args)
		{
			var resource = string.Format(format, args.Select(x => x != null ? HttpUtility.UrlEncode(x.ToString()) : string.Empty).ToArray());

			return new RestRequest(resource)
			{
				RequestFormat = DataFormat.Json,
				JsonSerializer = new RestSharp.Serializers.JsonSerializer()
			};
		}

		private IRestResponse Get(IRestRequest request)
		{
			request.Method = Method.GET;

			return ExecuteRequest(request);
		}

		private IRestResponse Post(IRestRequest request)
		{
			request.Method = Method.POST;

			return ExecuteRequest(request);
		}

		private static IRestResponse ExecuteRequest(IRestRequest request)
		{
			var deserializer = new JsonDeserializer();
			var client = new RestClient(MovesBaseUrl);
			client.AddHandler("application/json", deserializer);
			client.AddHandler("text/json", deserializer);

			return client.Execute(request);
		}

		private T DeserializeContent<T>(IRestResponse response)
		{
			return JsonConvert.DeserializeObject<T>(response.Content);
		}

		#endregion		
		
		public MovesService(string clientId, string clientSecret)
		{
			ClientId = clientId;
			ClientSecret = clientSecret;
		}

		public string ClientId { get; private set; }
		public string ClientSecret { get; private set; }

		public AccessTokenData ReceiveAccessToken(string authorizationToken, string redirectUri)
		{
			var request = CreateRequest(
				"access_token?grant_type=authorization_code&code={0}&client_id={1}&client_secret={2}&redirect_uri=" + redirectUri,
				authorizationToken,
				ClientId,
				ClientSecret				
			);

			var response = Post(request);

			if (response.StatusCode == HttpStatusCode.BadRequest)
			{
				throw MovesException.FromErrorResponse(response);
			}

			return DeserializeContent<AccessTokenData>(response);
		}

		public AccessTokenData RefreshAccessToken(string refreshToken)
		{
			var request = CreateRequest(
				"access_token?grant_type=refresh_token&refresh_token={0}&client_id={1}&client_secret={2}",
				refreshToken,
				ClientId,
				ClientSecret
			);

			var response = Post(request);

			if (response.StatusCode == HttpStatusCode.NotFound)
			{
				throw MovesException.FromErrorResponse(response);
			}

			return DeserializeContent<AccessTokenData>(response);
		}

		public AccessTokenValidation ValidateAccessToken(string accessToken)
		{
			var request = CreateRequest(
				"tokeninfo?access_token={0}",
				accessToken
			);

			var response = Get(request);

			if (response.StatusCode == HttpStatusCode.NotFound)
			{
				throw MovesException.FromErrorResponse(response);
			}

			return DeserializeContent<AccessTokenValidation>(response);
		}
	}
}

using Moves.Net.Endpoints;
using Moves.Net.Model;

namespace Moves.Net
{
	/// <summary>
	/// Provides a moves client for accessing moves data
	/// </summary>
	public class MovesClient : EndpointBase
	{
		#region Variables

		private string AuthenticationBaseUrl { get; set; }

		#endregion Variables

		#region Constructors

		/// <summary>
		/// Create a new MovesClient
		/// </summary>
		/// <param name="clientId">The provided Moves client ID</param>
		/// <param name="clientSecret">The provided Moves client secret</param>
		/// <param name="accessToken">Provide the received accesstoken</param>
		public MovesClient(string clientId, string clientSecret, string accessToken = null)
			: this(new SimpleRestClient(
						baseUrl: "https://api.moves-app.com/api/1.1/",
						credentials: new Credentials { ClientId = clientId, ClientSecret = clientSecret, AccessToken = accessToken })) { }

		protected MovesClient(ISimpleRestClient restClient)
			: base(restClient)
		{
			AuthenticationBaseUrl = "https://api.moves-app.com/oauth/v1/";

			Places = new PlaceEndpoint(RestClient);
			Profile = new ProfileEndpoint(RestClient);
			Storyline = new StorylineEndpoint(RestClient);
			Summary = new SummaryEndpoint(RestClient);
			Activity = new ActivityEndpoint(RestClient);
		}

		#endregion Constructors

		#region Endpoints

		public PlaceEndpoint Places { get; private set; }

		public StorylineEndpoint Storyline { get; private set; }

		public SummaryEndpoint Summary { get; private set; }

		public ProfileEndpoint Profile { get; private set; }

		public ActivityEndpoint Activity { get; private set; }

		#endregion Endpoints

		#region Authentication

		/// <summary>
		/// Returns a new instance of the service. The given
		/// <paramref name="accessToken"/> is used in each request made by this
		/// instance.
		/// </summary>
		/// <param name="accessToken">The access token to use</param>
		/// <returns>A new <see cref="MovesClient"/> instance</returns>
		public MovesClient Authorized(string accessToken)
		{
			return new MovesClient(RestClient.Credentials.ClientId, RestClient.Credentials.ClientSecret, accessToken);
		}

		/// <summary>
		/// Get a authorization url for authenticating through Moves
		/// </summary>
		/// <param name="scopes"></param>
		/// <param name="redirectUri"></param>
		/// <returns></returns>
		public string GetAuthorizationUrl(string[] scopes, string redirectUri)
		{
			return string.Format("{0}authorize?response_type=code&client_id={1}&scope={2}&redirect_uri={3}",
				AuthenticationBaseUrl,
				RestClient.Credentials.ClientId,
				string.Join(" ", scopes),
				redirectUri
			);
		}

		/// <summary>
		/// Retrieve a access token
		/// </summary>
		/// <param name="authorizationToken"></param>
		/// <param name="redirectUri"></param>
		/// <returns></returns>
		public MovesResult<AccessTokenData> ReceiveAccessToken(string authorizationToken, string redirectUri)
		{
			var request = RestClient.CreateRequest(
				"access_token?grant_type=authorization_code&code={0}&client_id={1}&client_secret={2}&redirect_uri={3}",
				authorizationToken,
				RestClient.Credentials.ClientId,
				RestClient.Credentials.ClientSecret,
				redirectUri
			);

			var response = RestClient.Post(AuthenticationBaseUrl, request);

			return new MovesResult<AccessTokenData>(response);
		}

		/// <summary>
		/// Refresh the access token giving the refresh token
		/// </summary>
		/// <param name="refreshToken"></param>
		/// <returns></returns>
		public MovesResult<AccessTokenData> RefreshAccessToken(string refreshToken)
		{
			var request = RestClient.CreateRequest(
				"access_token?grant_type=refresh_token&refresh_token={0}&client_id={1}&client_secret={2}",
				refreshToken,
				RestClient.Credentials.ClientId,
				RestClient.Credentials.ClientSecret
			);

			var response = RestClient.Post(AuthenticationBaseUrl, request);

			return new MovesResult<AccessTokenData>(response);
		}

		/// <summary>
		/// Validate the access token
		/// </summary>
		/// <param name="accessToken"></param>
		/// <returns></returns>
		public MovesResult<AccessTokenValidation> ValidateAccessToken(string accessToken)
		{
			var request = RestClient.CreateRequest(
				"tokeninfo?access_token={0}",
				accessToken
			);

			var response = RestClient.Get(AuthenticationBaseUrl, request);

			return new MovesResult<AccessTokenValidation>(response);
		}

		#endregion Authentication
	}
}
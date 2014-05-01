using Moves.Net.Endpoints;
using Moves.Net.Model;

namespace Moves.Net
{
	public class MovesService : RestClientBase
	{
		private string AuthenticationBaseUrl { get; set; }		
		
		public MovesService(string clientId, string clientSecret, string accessToken = null) : base(
			"https://api.moves-app.com/api/1.1/", 
			new Credentials { ClientId = clientId, ClientSecret = clientSecret, AccessToken = accessToken } )
		{ 
			AuthenticationBaseUrl = "https://api.moves-app.com/oauth/v1/";

			Places = new PlaceEndpoint(BaseUrl, Credentials);
			Profile = new ProfileEndpoint(BaseUrl, Credentials);
			Storyline = new StorylineEndpoint(BaseUrl, Credentials);
			Summary = new SummaryEndpoint(BaseUrl, Credentials);
			Activity = new ActivityEndpoint(BaseUrl, Credentials);           
		}
        
        public PlaceEndpoint Places { get; private set; }
        public StorylineEndpoint Storyline { get; private set; }
        public SummaryEndpoint Summary { get; private set; }
		public ProfileEndpoint Profile { get; private set; }
        public ActivityEndpoint Activity { get; private set; }

		/// <summary>
		/// Returns a new instance of the service. The given 
		/// <paramref name="accessToken"/> is used in each request made by this
		/// instance.
		/// </summary>
		/// <param name="accessToken">The access token to use</param>
		/// <returns>A new <see cref="MovesService"/> instance</returns>
		public MovesService Authorized(string accessToken)
		{
			return new MovesService(Credentials.ClientId, Credentials.ClientSecret, accessToken);
		}

		public string GetAuthorizationUrl(string[] scopes)
		{
			return string.Format("{0}authorize?response_type=code&client_id={1}&scope={2}",
				AuthenticationBaseUrl,
				this.Credentials.ClientId,
				string.Join(" ", scopes)
			);
		}

		public MovesResult<AccessTokenData> ReceiveAccessToken(string authorizationToken, string redirectUri)
		{
			var request = this.CreateRequest(
				"access_token?grant_type=authorization_code&code={0}&client_id={1}&client_secret={2}&redirect_uri=" + redirectUri,
				authorizationToken,
				this.Credentials.ClientId,
				this.Credentials.ClientSecret
			);

			var response = this.Post(AuthenticationBaseUrl, request);

			return new MovesResult<AccessTokenData>(response);
		}

		public MovesResult<AccessTokenData> RefreshAccessToken(string refreshToken)
		{
			var request = this.CreateRequest(
				"access_token?grant_type=refresh_token&refresh_token={0}&client_id={1}&client_secret={2}",
				refreshToken,
				this.Credentials.ClientId,
				this.Credentials.ClientSecret
			);

			var response = this.Post(AuthenticationBaseUrl, request);

			return new MovesResult<AccessTokenData>(response);
		}

		public MovesResult<AccessTokenValidation> ValidateAccessToken(string accessToken)
		{
			var request = this.CreateRequest(
				"tokeninfo?access_token={0}",
				accessToken
			);

			var response = this.Get(AuthenticationBaseUrl, request);

			return new MovesResult<AccessTokenValidation>(response);
		}
	}
}
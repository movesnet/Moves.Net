using Moves.Net.Endpoints;
using Moves.Net.Model;

namespace Moves.Net
{
    /// <summary>
    /// Provides a moves client for accessing moves data
    /// </summary>
	public class MovesClient : RestClientBase
    {
        #region Variables 
        
        private string AuthenticationBaseUrl { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Create a new MovesClient
        /// </summary>
        /// <param name="clientId">The provided Moves client ID</param>
        /// <param name="clientSecret">The provided Moves client secret</param>
        /// <param name="accessToken">Provide the received accesstoken</param>
		public MovesClient(string clientId, string clientSecret, string accessToken = null) : base("https://api.moves-app.com/api/1.1/", new Credentials { ClientId = clientId, ClientSecret = clientSecret, AccessToken = accessToken } )
		{ 
			AuthenticationBaseUrl = "https://api.moves-app.com/oauth/v1/";

            //Initialize the endpoints
			Places = new PlaceEndpoint(BaseUrl, Credentials);
			Profile = new ProfileEndpoint(BaseUrl, Credentials);
			Storyline = new StorylineEndpoint(BaseUrl, Credentials);
			Summary = new SummaryEndpoint(BaseUrl, Credentials);
			Activity = new ActivityEndpoint(BaseUrl, Credentials);           
		}

        #endregion

        #region Endpoints

        public PlaceEndpoint Places { get; private set; }
        public StorylineEndpoint Storyline { get; private set; }
        public SummaryEndpoint Summary { get; private set; }
		public ProfileEndpoint Profile { get; private set; }
        public ActivityEndpoint Activity { get; private set; }

        #endregion

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
			return new MovesClient(Credentials.ClientId, Credentials.ClientSecret, accessToken);
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
				this.Credentials.ClientId,
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
			var request = this.CreateRequest(
				"access_token?grant_type=authorization_code&code={0}&client_id={1}&client_secret={2}&redirect_uri={3}",
				authorizationToken,
				this.Credentials.ClientId,
				this.Credentials.ClientSecret,
                redirectUri
			);

			var response = this.Post(AuthenticationBaseUrl, request);

			return new MovesResult<AccessTokenData>(response);
		}

        /// <summary>
        /// Refresh the access token giving the refresh token
        /// </summary>
        /// <param name="refreshToken"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Validate the access token
        /// </summary>
        /// <param name="accessToken"></param>
        /// <returns></returns>
		public MovesResult<AccessTokenValidation> ValidateAccessToken(string accessToken)
		{
			var request = this.CreateRequest(
				"tokeninfo?access_token={0}",
				accessToken
			);

			var response = this.Get(AuthenticationBaseUrl, request);

			return new MovesResult<AccessTokenValidation>(response);
        }

        #endregion
    }
}
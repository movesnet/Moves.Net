using Moves.Net.Endpoints;

namespace Moves.Net
{
    public class MovesService
	{
        public Credentials Credentials { get; set; }

		public MovesService(string clientId, string clientSecret, string accessToken = null)
		{
			this.Credentials = new Credentials
            {
                ClientId = clientId,
                ClientSecret = clientSecret,
                AccessToken = accessToken
            };

			Authentication = new AuthenticationEndpoint(this.Credentials);
			Places = new PlaceEndpoint(this.Credentials);
			Profile = new ProfileEndpoint(this.Credentials);
            Storyline = new StorylineEndpoint(this.Credentials);
            Summary = new SummaryEndpoint(this.Credentials);
            Activity = new ActivityEndpoint(this.Credentials);           
		}
        
        public AuthenticationEndpoint Authentication { get; private set; }
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
	}
}

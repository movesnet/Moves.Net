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
			Places = new PlacesEndpoint(this.Credentials);
			Profile = new ProfileEndpoint(this.Credentials);
		}
        
        public AuthenticationEndpoint Authentication { get; private set; }
        public PlacesEndpoint Places { get; private set; }
		public ProfileEndpoint Profile { get; private set; }

		public MovesService Authorize(string accessToken)
		{
			this.Credentials.AccessToken = accessToken;
			return this;
		}
	}
}

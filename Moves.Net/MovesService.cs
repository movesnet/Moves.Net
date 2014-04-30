using Moves.Net.Endpoints;
using Moves.Net.Model.Authentication;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Contrib;
using RestSharp.Deserializers;
using System.Linq;
using System.Net;

namespace Moves.Net
{
    public class MovesService
	{
        private Credentials _credentials;
		public MovesService(string clientId, string clientSecret, string accessToken)
		{
            _credentials = new Credentials
            {
                ClientId = clientId,
                ClientSecret = clientSecret,
                AccessToken = accessToken
            };

            Authentication = new AuthenticationEndpoint(_credentials);
            Places = new PlacesEndpoint(_credentials);
		}
        
        public AuthenticationEndpoint Authentication { get; private set; }
        public PlacesEndpoint Places { get; private set; }
	}
}

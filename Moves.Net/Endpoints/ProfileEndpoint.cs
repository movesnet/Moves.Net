using Moves.Net.Model;

namespace Moves.Net.Endpoints
{
	public class ProfileEndpoint : EndpointBase
	{
		public ProfileEndpoint(ISimpleRestClient restClient)
			: base(restClient) { }

		public MovesResult<User> GetUser(string etag = null)
		{
			var request = RestClient.CreateRequest("user/profile");

			var response = RestClient.Get(request);

			return new MovesResult<User>(response);
		}
	}
}
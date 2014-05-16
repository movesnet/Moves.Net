using Moves.Net.Model;
using System.Collections.Generic;

namespace Moves.Net.Endpoints
{
	public class ActivityEndpoint : DailyEndpointBase
	{
		public ActivityEndpoint(ISimpleRestClient restClient)
			: base(restClient, "activities") { }

		public MovesResult<IEnumerable<ActivityList>> GetSupported(string etag = null)
		{
			var request = RestClient.CreateRequest("activities");

			var response = RestClient.Get(request);

			return new MovesResult<IEnumerable<ActivityList>>(response);
		}
	}
}
using System.Collections.Generic;
using System.Net;
using Moves.Net.Model;

namespace Moves.Net.Endpoints
{
    public class ActivityEndpoint : DailyEndpointBase
    {
        public ActivityEndpoint(string baseUrl, Credentials credentials)
			: base(baseUrl, credentials, "activities") { }

        public MovesResult<IEnumerable<ActivityList>> GetSupported(string etag = null)
        {
            var request = CreateRequest("activities");

            var response = Get(request);

            return new MovesResult<IEnumerable<ActivityList>>(response);
        }
    }
}

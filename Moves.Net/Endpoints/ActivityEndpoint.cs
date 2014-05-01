using System.Collections.Generic;
using System.Net;
using Moves.Net.Model;

namespace Moves.Net.Endpoints
{
    public class ActivityEndpoint : DailyEndpointBase
    {
        public ActivityEndpoint(Credentials credentials) : base("activities", credentials) { }

        public MovesResult<IEnumerable<ActivityList>> GetSupported(string etag = null)
        {
            var request = CreateRequest(
                "activities?access_token={0}",
                this.Credentials.AccessToken
            );

            var response = Get(request);

            return new MovesResult<IEnumerable<ActivityList>>(response);
        }
    }
}

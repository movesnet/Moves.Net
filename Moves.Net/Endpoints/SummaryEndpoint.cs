using System.Collections.Generic;
using System.Net;
using Moves.Net.Model;

namespace Moves.Net.Endpoints
{
    public class SummaryEndpoint : DailyEndpointBase
    {
		public SummaryEndpoint(string baseUrl, Credentials credentials)
			: base(baseUrl, credentials, "summary") { }
    }
}

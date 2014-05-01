using System.Collections.Generic;
using System.Net;
using Moves.Net.Model;

namespace Moves.Net.Endpoints
{
    public class SummaryEndpoint : DailyEndpointBase
    {
        public SummaryEndpoint(Credentials credentials) : base("summary", credentials) { }
    }
}

using System.Collections.Generic;
using System.Net;
using Moves.Net.Model;

namespace Moves.Net.Endpoints
{
    public class PlaceEndpoint : DailyEndpointBase
    {
        public PlaceEndpoint(Credentials credentials) : base("places", credentials) { }
    }
}

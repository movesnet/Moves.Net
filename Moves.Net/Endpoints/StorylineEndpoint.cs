using System.Collections.Generic;
using System.Net;
using Moves.Net.Model;
using System;
using System.Text;
using Moves.Net.Helper;

namespace Moves.Net.Endpoints
{
	public class StorylineEndpoint : DailyEndpointBase
	{        
        public StorylineEndpoint(Credentials credentials) : base("storyline", credentials) { }		
	}
}

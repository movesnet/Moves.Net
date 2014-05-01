using System.Linq;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Contrib;
using RestSharp.Deserializers;

namespace Moves.Net.Endpoints
{
	public abstract class EndpointBase : RestClientBase
    {
		public EndpointBase(string baseUrl, Credentials credentials)
			: base(baseUrl, credentials) { }
    }
}

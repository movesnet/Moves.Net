using Moves.Net.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Moves.Net.Endpoints
{
	public class ProfileEndpoint : EndpointBase
	{
		public ProfileEndpoint(string baseUrl, Credentials credentials)
			:base(baseUrl, credentials) { }

		public MovesResult<User> GetUser(string etag = null)
		{
			var request = CreateRequest(
				"user/profile?access_token={0}",
				Credentials.AccessToken
			);

			var response = Get(request);

			return new MovesResult<User>(response);
		}
	}
}

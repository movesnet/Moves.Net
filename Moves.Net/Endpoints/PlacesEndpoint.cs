using System.Collections.Generic;
using System.Net;
using Moves.Net.Model;

namespace Moves.Net.Endpoints
{
	public class PlacesEndpoint : EndpointBase
	{
		public PlacesEndpoint(Credentials credentials)
			: base(credentials) { }

		private MovesResult<IEnumerable<Day>> GetDaily(string dailyString, string etag = null)
		{
			var request = CreateRequest(
				"user/places/daily/{1}?access_token={0}",
				this.Credentials.AccessToken,
				dailyString
			);

			var response = Get(request);

			return new MovesResult<IEnumerable<Day>>(response);
		}

		public MovesResult<IEnumerable<Day>> GetByDay(int year, int month, int day, string etag = null)
		{
			return GetDaily(string.Format("{0}-{1}-{2}", year, month.ToString("D2"), day.ToString("D2")), etag);
		}

		public MovesResult<IEnumerable<Day>> GetByMonth(int year, int month, string etag = null)
		{
			return GetDaily(string.Format("{0}-{1}", year, month.ToString("D2")), etag);
		}

		public MovesResult<IEnumerable<Day>> GetByWeek(int year, int weekNr, string etag = null)
		{
			return GetDaily(string.Format("{0}-W{1}", year, weekNr.ToString("D2")), etag);
		}
	}
}

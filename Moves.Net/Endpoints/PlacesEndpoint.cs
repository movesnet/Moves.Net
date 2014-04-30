using System.Collections.Generic;
using System.Net;
using Moves.Net.Model;

namespace Moves.Net.Endpoints
{
	public class PlacesEndpoint : EndpointBase
	{
		public PlacesEndpoint(Credentials credentials)
			: base(credentials) { }

		private IEnumerable<Day> GetDaily(string dailyString)
		{
			var request = CreateRequest(
				"user/places/daily/{1}?access_token={0}",
				this.Credentials.AccessToken,
				dailyString
			);

			var response = Get(request);

			if (response.StatusCode == HttpStatusCode.BadRequest)
			{
				throw MovesException.FromErrorResponse(response);
			}

			return DeserializeContent<Day[]>(response);
		}

		public IEnumerable<Day> GetByDay(int year, int month, int day)
		{
			return GetDaily(string.Format("{0}-{1}-{2}", year, month.ToString("D2"), day.ToString("D2")));
		}

		public IEnumerable<Day> GetByMonth(int year, int month)
		{
			return GetDaily(string.Format("{0}-{1}", year, month.ToString("D2")));
		}

		public IEnumerable<Day> GetByWeek(int year, int weekNr)
		{
			return GetDaily(string.Format("{0}-W{1}", year, weekNr.ToString("D2")));
		}
	}
}

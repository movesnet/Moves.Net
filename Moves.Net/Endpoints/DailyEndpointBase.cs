using Moves.Net.Helper;
using Moves.Net.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Moves.Net.Endpoints
{
	public abstract class DailyEndpointBase : EndpointBase
	{
		protected string ApiName { get; private set; }

		public DailyEndpointBase(ISimpleRestClient restClient, string apiName)
			: base(restClient)
		{
			this.ApiName = apiName;
		}

		/// <summary>
		/// Get daily result for a requested day, week, month or period.
		/// </summary>
		/// <param name="dailyString">The string of the daily request (day, week, month)</param>
		/// <param name="to">From range in one query between from and to date is 31 days</param>
		/// <param name="trackPoints">Should the tracking points be included in the result.</param>
		/// <param name="updatedSince">Return only days which data has been updated since given timestamp in ISO 8601</param>
		/// <param name="pastDays">How many past days to return, including today (in users current time zone)</param>
		/// <param name="timeZone">Use the given time zone ID for the date period and timestamps, overriding the users current time zone</param>
		/// <param name="etag">The ETag response-header field provides the current value of the entity tag for the requested variant</param>
		/// <returns>A daily result.</returns>
		private MovesResult<IEnumerable<Day>> GetDaily
		(
			string dailyString = null,
			DateTime? from = null,
			DateTime? to = null,
			bool? trackPoints = true,
			DateTime? updatedSince = null,
			int? pastDays = null,
			int? timeZone = null,
			string etag = null
		)
		{
			var isRange = from.HasValue &&
						  to.HasValue &&
						  string.IsNullOrEmpty(dailyString);

			var url = new StringBuilder();
			url.AppendFormat("user/{0}/daily", this.ApiName);

			if (isRange)
			{
				url.AddParameter("from", from.Value.ToUniversalTime().ToString("o"));
				url.AddParameter("to", to.Value.ToUniversalTime().ToString("o"));
			}
			if (!string.IsNullOrEmpty(dailyString))
			{
				url.Append("/");
				url.Append(dailyString);
			}
			if (trackPoints.HasValue)
			{
				url.AddParameter("trackPoints", trackPoints.Value.ToString().ToLower());
			}
			if (updatedSince.HasValue)
			{
				url.AddParameter("updatedSince", updatedSince.Value.ToUniversalTime().ToString("o"));
			}
			if (pastDays.HasValue)
			{
				url.AddParameter("pastDays", pastDays.Value.ToString());
			}
			if (timeZone.HasValue)
			{
				url.AddParameter("timeZone", timeZone.Value.ToString());
			}

			var response = RestClient.Get(url.ToString());

			return new MovesResult<IEnumerable<Day>>(response);
		}

		/// <summary>
		/// Get daily result for a period.
		/// </summary>
		/// <param name="from">From range in one query between from and to date is 31 days</param>
		/// <param name="to">From range in one query between from and to date is 31 days</param>
		/// <param name="trackPoints">Should the tracking points be included in the result.</param>
		/// <param name="updatedSince">Return only days which data has been updated since given timestamp in ISO 8601</param>
		/// <param name="pastDays">How many past days to return, including today (in users current time zone)</param>
		/// <param name="timeZone">Use the given time zone ID for the date period and timestamps, overriding the users current time zone</param>
		/// <param name="etag">The ETag response-header field provides the current value of the entity tag for the requested variant</param>
		/// <returns>A daily result.</returns>
		private MovesResult<IEnumerable<Day>> GetPeriod
		(
			DateTime from,
			DateTime to,
			bool trackPoints = true,
			DateTime? updatedSince = null,
			int? pastDays = null,
			int? timeZone = null,
			string etag = null
		)
		{
			return GetDaily
			(
				from: from,
				to: to,
				trackPoints: trackPoints,
				updatedSince: updatedSince,
				pastDays: pastDays,
				timeZone: timeZone,
				etag: etag
			);
		}

		/// <summary>
		/// Get daily result for a requested day
		/// </summary>
		/// <param name="year">The year of the requested day</param>
		/// <param name="month">The month of the requested day</param>
		/// <param name="day">The day of the requested day</param>
		/// <param name="trackPoints">Should the tracking points be included in the result.</param>
		/// <param name="updatedSince">Return only days which data has been updated since given timestamp in ISO 8601</param>
		/// <param name="pastDays">How many past days to return, including today (in users current time zone)</param>
		/// <param name="timeZone">Use the given time zone ID for the date period and timestamps, overriding the users current time zone</param>
		/// <param name="etag">The ETag response-header field provides the current value of the entity tag for the requested variant</param>
		/// <returns>A daily result.</returns>
		public MovesResult<IEnumerable<Day>> GetByDay
		(
			int year,
			int month,
			int day,
			bool trackPoints = true,
			DateTime? updatedSince = null,
			int? pastDays = null,
			int? timeZone = null,
			string etag = null
		)
		{
			return GetDaily
			(
				dailyString: string.Format("{0}-{1}-{2}", year, month.ToString("D2"), day.ToString("D2")),
				trackPoints: trackPoints,
				updatedSince: updatedSince,
				pastDays: pastDays,
				timeZone: timeZone,
				etag: etag
			);
		}

		/// <summary>
		/// Get daily result for a requested month
		/// </summary>
		/// <param name="year">The year of the requested day</param>
		/// <param name="month">The month of the requested day</param>
		/// <param name="trackPoints">Should the tracking points be included in the result.</param>
		/// <param name="updatedSince">Return only days which data has been updated since given timestamp in ISO 8601</param>
		/// <param name="pastDays">How many past days to return, including today (in users current time zone)</param>
		/// <param name="timeZone">Use the given time zone ID for the date period and timestamps, overriding the users current time zone</param>
		/// <param name="etag">The ETag response-header field provides the current value of the entity tag for the requested variant</param>
		/// <returns>A daily result.</returns>
		public MovesResult<IEnumerable<Day>> GetByMonth
		(
			int year,
			int month,
			DateTime?
			updatedSince = null,
			int? pastDays = null,
			int? timeZone = null,
			string etag = null
		)
		{
			return GetDaily
			(
				dailyString: string.Format("{0}-{1}", year, month.ToString("D2")),
				trackPoints: null,
				updatedSince: updatedSince,
				pastDays: pastDays,
				timeZone: timeZone,
				etag: etag
			);
		}

		/// <summary>
		/// Get daily result for a requested week
		/// </summary>
		/// <param name="year">The year of the requested week</param>
		/// <param name="weekNr">The requested week, Uses ISO8601 week-numbering.</param>
		/// <param name="trackPoints">Should the tracking points be included in the result.</param>
		/// <param name="updatedSince">Return only days which data has been updated since given timestamp in ISO 8601</param>
		/// <param name="pastDays">How many past days to return, including today (in users current time zone)</param>
		/// <param name="timeZone">Use the given time zone ID for the date period and timestamps, overriding the users current time zone</param>
		/// <param name="etag">The ETag response-header field provides the current value of the entity tag for the requested variant</param>
		/// <returns>A daily result.</returns>
		public MovesResult<IEnumerable<Day>> GetByWeek
		(
			int year,
			int weekNr,
			bool trackPoints = true,
			DateTime? updatedSince = null,
			int? pastDays = null,
			int? timeZone = null,
			string etag = null
		)
		{
			return GetDaily
			(
				dailyString: string.Format("{0}-W{1}", year, weekNr.ToString("D2")),
				trackPoints: trackPoints,
				updatedSince: updatedSince,
				pastDays: pastDays,
				timeZone: timeZone,
				etag: etag
			);
		}
	}
}
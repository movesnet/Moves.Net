using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using RestSharp;
using System;
using System.Globalization;
using System.Linq;
using System.Net;

namespace Moves.Net
{
	public class MovesResult<TResult>
	{
		private class MovesDateConverter : DateTimeConverterBase
		{
			public override object ReadJson(JsonReader reader, System.Type objectType, object existingValue, JsonSerializer serializer)
			{
				var value = reader.Value.ToString();

				if (value.Length == 8)
				{
					return DateTime.ParseExact(value, "yyyyMMdd", CultureInfo.InvariantCulture);
				}
				else
				{
					if (value.Contains('+'))
					{
						return DateTime.ParseExact(value, "yyyyMMddTHHmmssK", CultureInfo.InvariantCulture);
					}
					else
					{
						return DateTime.ParseExact(value, "yyyyMMddTHHmmssZ", CultureInfo.InvariantCulture);
					}
				}
			}

			public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
			{
				writer.WriteValue(((DateTime)value).ToString("yyyyMMdd"));
			}
		}

		public MovesResult(IRestResponse response)
		{
			ETag = response.Headers.Where(x => x.Name == "ETag").Select(x => x.Value.ToString()).FirstOrDefault();
			Status = response.StatusCode;

			if ((int)response.StatusCode >= 400)
			{
				throw MovesException.FromErrorResponse(response);
			}
			else if (response.StatusCode != HttpStatusCode.NotModified)
			{
				Data = JsonConvert.DeserializeObject<TResult>(
					response.Content,
					new MovesDateConverter()
				);
			}
		}

		public string ETag { get; set; }

		public HttpStatusCode Status { get; set; }

		public TResult Data { get; set; }
	}
}
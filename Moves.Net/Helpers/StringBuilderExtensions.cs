using RestSharp.Contrib;
using System.Text;

namespace Moves.Net.Helper
{
	public static class StringExtensions
	{
		public static StringBuilder AppendValue(this StringBuilder url, string value)
		{
			return url.Append(HttpUtility.UrlPathEncode(value));
		}

		public static StringBuilder AddParameter(this StringBuilder url, string name, string value)
		{
			return url.Append(HttpUtility.UrlPathEncode(HttpUtility.UrlPathEncode(string.Format("{0}{1}={2}", url.ToString().Contains("?") ? "&" : "?", name, value))));
		}
	}
}
using RestSharp;

namespace Moves.Net
{
	public interface ISimpleRestClient
	{
		Credentials Credentials { get; set; }

		IRestRequest CreateRequest(string format, params object[] args);

		string CreateResourceUrl(string format, params object[] args);

		IRestResponse ExecuteRequest(string baseUrl, IRestRequest request);

		IRestResponse Get(IRestRequest request);

		IRestResponse Get(string baseUrl, IRestRequest request);

		IRestResponse Post(IRestRequest request);

		IRestResponse Post(string baseUrl, IRestRequest request);
	}
}
namespace Moves.Net.Endpoints
{
	public abstract class EndpointBase
	{
		public EndpointBase(ISimpleRestClient restClient)
		{
			RestClient = restClient;
		}

		protected ISimpleRestClient RestClient
		{
			get;
			set;
		}
	}
}
namespace Moves.Net.Endpoints
{
	public class SummaryEndpoint : DailyEndpointBase
	{
		public SummaryEndpoint(ISimpleRestClient restClient)
			: base(restClient, "summary") { }
	}
}
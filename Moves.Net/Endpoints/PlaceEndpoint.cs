namespace Moves.Net.Endpoints
{
	public class PlaceEndpoint : DailyEndpointBase
	{
		public PlaceEndpoint(ISimpleRestClient restClient)
			: base(restClient, "places") { }
	}
}
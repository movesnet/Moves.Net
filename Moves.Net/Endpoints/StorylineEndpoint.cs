namespace Moves.Net.Endpoints
{
	public class StorylineEndpoint : DailyEndpointBase
	{
		public StorylineEndpoint(ISimpleRestClient restClient)
			: base(restClient, "storyline") { }
	}
}
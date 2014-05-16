using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moves.Net.UnitTests
{
	public class TestableMovesClient : MovesClient
	{
		public TestableMovesClient(ISimpleRestClient restClient)
			: base(restClient) { }
	}
}

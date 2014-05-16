using Moq;
using Moves.Net.UnitTests.Properties;
using NUnit.Framework;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Moves.Net.UnitTests
{
	[TestFixture]
    public class MovesClientTests
    {
		public MovesClient CreateMovesClient(ISimpleRestClient restClient)
		{
			return new TestableMovesClient(restClient);
		}

		[Test]
		public void Test()
		{
			 var restClient = new Mock<ISimpleRestClient>();

			 restClient
				 .Setup<IRestResponse>(rest => rest.Get(It.IsAny<string>())).Returns(
					 Mock.Of<IRestResponse>(resp =>
						 resp.StatusCode == HttpStatusCode.OK &&
						 resp.Content == Testdata.SummariesResult &&
						 resp.Headers == new List<Parameter>()
					 )
				 );

			 var client = CreateMovesClient(restClient.Object);

			 var result = client.Summary.GetByDay(2000, 1, 1);

			 Assert.NotNull(result);
			
		}
    }
}

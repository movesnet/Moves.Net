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
		#region Nested Type: TestableMovesClient

		public class TestableMovesClient : MovesClient
		{
			public TestableMovesClient(ISimpleRestClient restClient)
				: base(restClient) { }
		}

		#endregion

		private MovesClient CreateMovesClient(ISimpleRestClient restClient)
		{
			return new TestableMovesClient(restClient);
		}

		private ISimpleRestClient CreateRestClientMock(HttpStatusCode responseCode, string responseContent)
		{
			var restClient = new Mock<ISimpleRestClient>();

			var response = Mock.Of<IRestResponse>(resp =>
				resp.StatusCode == responseCode &&
				resp.Content == responseContent &&
				resp.Headers == new List<Parameter>()
			);
			restClient.Setup<IRestResponse>(rest => rest.Get(It.IsAny<IRestRequest>())).Returns(response);
			restClient.Setup<IRestResponse>(rest => rest.Get(It.IsAny<string>(), It.IsAny<IRestRequest>())).Returns(response);
			restClient.Setup<IRestResponse>(rest => rest.Post(It.IsAny<IRestRequest>())).Returns(response);
			restClient.Setup<IRestResponse>(rest => rest.Post(It.IsAny<string>(), It.IsAny<IRestRequest>())).Returns(response);
			restClient.Setup<IRestResponse>(rest => rest.ExecuteRequest(It.IsAny<string>(), It.IsAny<IRestRequest>())).Returns(response);

			return restClient.Object;
		}

		[Test]
		public void FirstTest()
		{
			var client = CreateMovesClient(
				CreateRestClientMock(
					responseCode: HttpStatusCode.OK,
					responseContent: Testdata.SummariesResult
				)
			);

			var result = client.Summary.GetByDay(2000, 1, 1);

			Assert.AreEqual(new DateTime(2013, 3, 15), result.Data.First().Date);			
		}
    }
}

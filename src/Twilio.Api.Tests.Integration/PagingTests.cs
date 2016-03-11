using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Moq;
using RestSharp;

using Twilio.Api;
using Twilio.Model;
using System.Threading;

namespace Twilio.Api.Tests.Integration
{
    public class Foo : TwilioBase
    {
        public string Bar { get; set; }
    }

    public class FooResult : TwilioListBase
    {
        public List<Foo> Foos { get; set; }
    }

    public class NextGenFooResult : NextGenListBase
    {
        public List<Foo> Foos { get; set; }
    }

    [TestFixture]
    public class PagingTests
    {
        private Mock<TwilioRestClient> mockClient;
//        private Mock<NextGenClient> mockNextGenClient;
		private ManualResetEvent manualResetEvent = null;

        [SetUp]
        public void Setup()
        {
            mockClient = new Mock<TwilioRestClient>(Credentials.AccountSid, Credentials.AuthToken);
            mockClient.CallBase = true;

//            mockNextGenClient = new Mock<NextGenClient>(Credentials.AccountSid, Credentials.AuthToken, Credentials.AccountSid, "v1", "https://taskrouter.twilio.com");
//            mockNextGenClient.CallBase = true;
        }

        [Test]
        public void ShouldGetNextPage()
        {
            IRestRequest savedRequest = null;

            FooResult firstPage = new FooResult();
            firstPage.NextPageUri = new Uri("/Foos?PageToken=abc123", UriKind.Relative);

            mockClient.Setup(trc => trc.Execute<FooResult>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => savedRequest = request)
                .Returns(new FooResult());
            var client = mockClient.Object;

            var response = client.GetNextPage<FooResult>(firstPage);

            mockClient.Verify(trc => trc.Execute<FooResult>(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("/Foos?PageToken=abc123", savedRequest.Resource);
            Assert.AreEqual(Method.GET, savedRequest.Method);

            Assert.IsNotNull(response);
        }

        [Test]
        public void ShouldGetPreviousPage()
        {
            IRestRequest savedRequest = null;

            FooResult firstPage = new FooResult();
            firstPage.PreviousPageUri = new Uri("/Foos?PageToken=abc123", UriKind.Relative);

            mockClient.Setup(trc => trc.Execute<FooResult>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => savedRequest = request)
                .Returns(new FooResult());
            var client = mockClient.Object;

            var response = client.GetPreviousPage<FooResult>(firstPage);

            mockClient.Verify(trc => trc.Execute<FooResult>(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("/Foos?PageToken=abc123", savedRequest.Resource);
            Assert.AreEqual(Method.GET, savedRequest.Method);

            Assert.IsNotNull(response);
        }

		/*
        [Test]
        public void ShouldGetNextGenNextPage()
        {
            IRestRequest savedRequest = null;

            NextGenFooResult firstPage = new NextGenFooResult();
            firstPage.Meta = new ListMeta();
            firstPage.Meta.NextPageUrl = new Uri("https://taskrouter.twilio.com/v1/Foos?PageToken=abc123", UriKind.Absolute);

            mockNextGenClient.Setup(trc => trc.Execute<NextGenFooResult>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => savedRequest = request)
                .Returns(new NextGenFooResult());
            var client = mockNextGenClient.Object;

            var response = client.GetNextPage<NextGenFooResult>(firstPage);
            
            mockNextGenClient.Verify(trc => trc.Execute<NextGenFooResult>(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("/Foos?PageToken=abc123", savedRequest.Resource);
            Assert.AreEqual(Method.GET, savedRequest.Method);

            Assert.IsNotNull(response);
        }

        [Test]
        public void ShouldGetNextGenPreviousPage()
        {
            IRestRequest savedRequest = null;

            NextGenFooResult firstPage = new NextGenFooResult();
            firstPage.Meta = new ListMeta();
            firstPage.Meta.PreviousPageUrl = new Uri("https://taskrouter.twilio.com/v1/Foos?PageToken=abc123", UriKind.Absolute);

            mockNextGenClient.Setup(trc => trc.Execute<NextGenFooResult>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => savedRequest = request)
                .Returns(new NextGenFooResult());
            var client = mockNextGenClient.Object;

            var response = client.GetPreviousPage<NextGenFooResult>(firstPage);

            mockNextGenClient.Verify(trc => trc.Execute<NextGenFooResult>(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("/Foos?PageToken=abc123", savedRequest.Resource);
            Assert.AreEqual(Method.GET, savedRequest.Method);

            Assert.IsNotNull(response);
        }
		*/

        [Test]
        public void ShouldGetNextPageAsync()
        {
            IRestRequest savedRequest = null;

            FooResult firstPage = new FooResult();
            firstPage.NextPageUri = new Uri("/Foos?PageToken=abc123", UriKind.Relative);

			mockClient.Setup(trc => trc.ExecuteAsync<FooResult>(It.IsAny<IRestRequest>(), It.IsAny<Action<FooResult>>()))
				.Callback<IRestRequest, Action<FooResult>> ((request, action) => savedRequest = request);
            var client = mockClient.Object;
            manualResetEvent = new ManualResetEvent(false);

			client.GetNextPage<FooResult>(firstPage, page => {
				manualResetEvent.Set();
			});

            manualResetEvent.WaitOne(1);

			mockClient.Verify(trc => trc.ExecuteAsync<FooResult>(It.IsAny<IRestRequest>(), It.IsAny<Action<FooResult>>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("/Foos?PageToken=abc123", savedRequest.Resource);
            Assert.AreEqual(Method.GET, savedRequest.Method);
        }

        [Test]
        public void ShouldGetPreviousPageAsync()
        {
            IRestRequest savedRequest = null;

            FooResult firstPage = new FooResult();
            firstPage.PreviousPageUri = new Uri("/Foos?PageToken=abc123", UriKind.Relative);

			mockClient.Setup(trc => trc.ExecuteAsync<FooResult>(It.IsAny<IRestRequest>(), It.IsAny<Action<FooResult>>()))
				.Callback<IRestRequest, Action<FooResult>> ((request, action) => savedRequest = request);
            var client = mockClient.Object;
            manualResetEvent = new ManualResetEvent(false);

			client.GetPreviousPage<FooResult>(firstPage, page => {
				manualResetEvent.Set();
			});

            manualResetEvent.WaitOne(1);

			mockClient.Verify(trc => trc.ExecuteAsync<FooResult>(It.IsAny<IRestRequest>(), It.IsAny<Action<FooResult>>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("/Foos?PageToken=abc123", savedRequest.Resource);
            Assert.AreEqual(Method.GET, savedRequest.Method);
        }

		/*
        [Test]
        public void ShouldGetNextGenNextPageAsync()
        {
            IRestRequest savedRequest = null;

            NextGenFooResult firstPage = new NextGenFooResult();
            firstPage.Meta = new ListMeta();
            firstPage.Meta.NextPageUrl = new Uri("https://taskrouter.twilio.com/v1/Foos?PageToken=abc123", UriKind.Absolute);

			mockNextGenClient.Setup(trc => trc.ExecuteAsync<NextGenFooResult>(It.IsAny<IRestRequest>(), It.IsAny<Action<NextGenFooResult>>()))
				.Callback<IRestRequest, Action<NextGenFooResult>> ((request, action) => savedRequest = request);
            var client = mockNextGenClient.Object;
            manualResetEvent = new ManualResetEvent(false);

			client.GetNextPage<NextGenFooResult>(firstPage, page => {
				manualResetEvent.Set();
			});

            manualResetEvent.WaitOne(1);
            
			mockNextGenClient.Verify(trc => trc.ExecuteAsync<NextGenFooResult>(It.IsAny<IRestRequest>(), It.IsAny<Action<NextGenFooResult>>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("/Foos?PageToken=abc123", savedRequest.Resource);
            Assert.AreEqual(Method.GET, savedRequest.Method);
        }

        [Test]
        public void ShouldGetNextGenPreviousPageAsync()
        {
            IRestRequest savedRequest = null;

            NextGenFooResult firstPage = new NextGenFooResult();
            firstPage.Meta = new ListMeta();
            firstPage.Meta.PreviousPageUrl = new Uri("https://taskrouter.twilio.com/v1/Foos?PageToken=abc123", UriKind.Absolute);

			mockNextGenClient.Setup(trc => trc.ExecuteAsync<NextGenFooResult>(It.IsAny<IRestRequest>(), It.IsAny<Action<NextGenFooResult>>()))
				.Callback<IRestRequest, Action<NextGenFooResult>> ((request, action) => savedRequest = request);
            var client = mockNextGenClient.Object;
            manualResetEvent = new ManualResetEvent(false);

			client.GetPreviousPage<NextGenFooResult>(firstPage, page => {
				manualResetEvent.Set();
			});

            manualResetEvent.WaitOne(1);

			mockNextGenClient.Verify(trc => trc.ExecuteAsync<NextGenFooResult>(It.IsAny<IRestRequest>(), It.IsAny<Action<NextGenFooResult>>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("/Foos?PageToken=abc123", savedRequest.Resource);
            Assert.AreEqual(Method.GET, savedRequest.Method);
        }
        */
    }
}

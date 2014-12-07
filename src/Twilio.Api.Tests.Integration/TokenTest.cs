using System;
using NUnit.Framework;
using System.Threading;
using Moq;
using RestSharp;

namespace Twilio.Api.Tests.Integration
{
	[TestFixture]
	public class TokenTest
	{

		ManualResetEvent manualResetEvent = null;

		private Mock<TwilioRestClient> mockClient;

		[SetUp]
		public void Setup()
		{
			mockClient = new Mock<TwilioRestClient> (Credentials.AccountSid, Credentials.AuthToken);
			mockClient.CallBase = true;
		}

		[Test]
		public void ShouldCreateToken()
		{
			IRestRequest savedRequest = null;
			mockClient.Setup(trc => trc.Execute<Token>(It.IsAny<IRestRequest>()))
				.Callback<IRestRequest>((request) => savedRequest = request)
				.Returns(new Token());
			var client = mockClient.Object;

			client.CreateToken();

			mockClient.Verify (trc => trc.Execute<Token> (It.IsAny<IRestRequest> ()), Times.Once);
			Assert.IsNotNull (savedRequest);
			Assert.AreEqual("Accounts/{AccountSid}/Tokens.json", savedRequest.Resource);
			Assert.AreEqual(Method.POST, savedRequest.Method);
			Assert.AreEqual(0, savedRequest.Parameters.Count);
		}

		[Test]
		public void ShouldCreateTokenWithTtl()
		{
			IRestRequest savedRequest = null;
			mockClient.Setup(trc => trc.Execute<Token>(It.IsAny<IRestRequest>()))
				.Callback<IRestRequest>((request) => savedRequest = request)
				.Returns(new Token());
			var client = mockClient.Object;
			var ttl = 100;

			client.CreateToken(ttl);

			mockClient.Verify (trc => trc.Execute<Token> (It.IsAny<IRestRequest> ()), Times.Once);
			Assert.IsNotNull (savedRequest);
			Assert.AreEqual("Accounts/{AccountSid}/Tokens.json", savedRequest.Resource);
			Assert.AreEqual(Method.POST, savedRequest.Method);
			Assert.AreEqual(1, savedRequest.Parameters.Count);

			var ttlParam = savedRequest.Parameters.Find(x => x.Name == "Ttl");
			Assert.IsNotNull(ttlParam);
			Assert.AreEqual(100, ttlParam.Value);
		}

		[Test]
		public void ShouldCreateTokenAsynchronously()
		{
			IRestRequest savedRequest = null;
			mockClient.Setup (trc => trc.ExecuteAsync<Token> (It.IsAny<IRestRequest>(), It.IsAny<Action<Token>>()))
				.Callback<IRestRequest, Action<Token>> ((request, action) => savedRequest = request);

			var client = mockClient.Object;
			manualResetEvent = new ManualResetEvent(false);

			client.CreateToken(token => { manualResetEvent.Set(); });
			manualResetEvent.WaitOne(1);

			mockClient.Verify (trc => trc.ExecuteAsync<Token> (It.IsAny<IRestRequest> (), It.IsAny<Action<Token>>()), Times.Once);
			Assert.IsNotNull(savedRequest);
			Assert.AreEqual("Accounts/{AccountSid}/Tokens.json", savedRequest.Resource);
			Assert.AreEqual(Method.POST, savedRequest.Method);
			Assert.AreEqual(0, savedRequest.Parameters.Count);
		}
	}
}


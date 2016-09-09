using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using Twilio;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Rest;
using Twilio.Rest.Api.V2010.Account;

namespace Twilio.Tests.Rest.Api.V2010.Account {

    [TestFixture]
    public class TokenTest : TwilioTest {
        [SetUp]
        public void SetUp() {
        }
    
        [Test]
        public void TestCreateRequest() {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            Request request = new Request(Twilio.Http.HttpMethod.POST,
                                          Domains.API,
                                          "/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Tokens.json");
            twilioRestClient.Request(request)
                            .Returns(new Response(System.Net.HttpStatusCode.InternalServerError,
                                                  "null"));
            
            try {
                TokenResource.Create("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").Execute(twilioRestClient);
                Assert.Fail("Expected TwilioException to be thrown for 500");
            } catch (AggregateException ae) {
                ae.Handle((e) =>
                {
                    if (e.GetType() != typeof(ApiException)) {
                        throw e;
                    }
            
                    return true;
                });
            } catch (ApiException) {
            }
            twilioRestClient.Received().Request(request);
        }
    
        [Test]
        public void TestCreateResponse() {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            twilioRestClient.Request(Arg.Any<Request>())
                            .Returns(new Response(System.Net.HttpStatusCode.Created,
                                                  "{\"account_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"date_created\": \"Fri, 24 Jul 2015 18:43:58 +0000\",\"date_updated\": \"Fri, 24 Jul 2015 18:43:58 +0000\",\"ice_servers\": [{\"url\": \"stun:global.stun:3478?transport=udp\"},{\"credential\": \"5SR2x8mZK1lTFJW3NVgLGw6UM9C0dja4jI/Hdw3xr+w=\",\"url\": \"turn:global.turn:3478?transport=udp\",\"username\": \"cda92e5006c7810494639fc466ecc80182cef8183fdf400f84c4126f3b59d0bb\"}],\"password\": \"5SR2x8mZK1lTFJW3NVgLGw6UM9C0dja4jI/Hdw3xr+w=\",\"ttl\": \"86400\",\"username\": \"cda92e5006c7810494639fc466ecc80182cef8183fdf400f84c4126f3b59d0bb\"}"));
            
            var response = TokenResource.Create("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").Execute(twilioRestClient);
            Assert.NotNull(response);
        }
    }
}
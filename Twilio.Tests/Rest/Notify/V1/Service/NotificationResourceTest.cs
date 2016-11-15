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
using Twilio.Rest.Notify.V1.Service;

namespace Twilio.Tests.Rest.Notify.V1.Service 
{

    [TestFixture]
    public class NotificationTest : TwilioTest 
    {
        [SetUp]
        public void SetUp()
        {
        }
    
        [Test]
        public void TestCreateRequest()
        {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            var request = new Request(HttpMethod.POST,
                                      Domains.Notify,
                                      "/v1/Services/ISaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Notifications");
            twilioRestClient.GetAccountSid().Returns("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
            twilioRestClient.Request(request)
                            .Returns(new Response(System.Net.HttpStatusCode.InternalServerError,
                                                  "null"));
            
            try
            {
                NotificationResource.Creator("ISaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").Create(twilioRestClient);
                Assert.Fail("Expected TwilioException to be thrown for 500");
            }
            catch (AggregateException ae)
            {
                ae.Handle((e) =>
                {
                    if (e.GetType() != typeof(ApiException))
                    {
                        throw e;
                    }
            
                    return true;
                });
            }
            catch (ApiException)
            {
            }
            twilioRestClient.Received().Request(request);
        }
    
        [Test]
        public void TestCreateResponse()
        {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            twilioRestClient.GetAccountSid().Returns("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
            twilioRestClient.Request(Arg.Any<Request>())
                            .Returns(new Response(System.Net.HttpStatusCode.Created,
                                                  "{\"sid\": \"NOb8021351170b4e1286adaac3fdd6d082\",\"account_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"service_sid\": \"IS699b53e02da45a1ba9d13b7d7d2766af\",\"date_created\": \"2016-03-24T23:42:28Z\",\"identities\": [\"jing\"],\"tags\": [],\"priority\": \"high\",\"ttl\": 2419200,\"title\": \"test\",\"body\": \"body\",\"sound\": null,\"action\": null,\"data\": null,\"apn\": null,\"gcm\": null,\"sms\": null,\"facebook_messenger\": null}"));
            
            var response = NotificationResource.Creator("ISaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").Create(twilioRestClient);
            Assert.NotNull(response);
        }
    }
}
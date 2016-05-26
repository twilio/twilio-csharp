using NSubstitute;
using NUnit.Framework;
using System;
using Twilio;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Resources.Notifications.V1.Service;

namespace Twilio.Tests.Notifications.V1.Service {

    [TestFixture]
    public class NotificationTest : TwilioTest {
        [SetUp]
        public void SetUp() {
        }
    
        [Test]
        public void TestCreateRequest() {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            Request request = new Request(System.Net.Http.HttpMethod.Post,
                                          Domains.NOTIFICATIONS,
                                          "/v1/Services/ISaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Notifications");
            
            
            twilioRestClient.Request(request)
                            .Returns(System.Threading.Tasks.Task.FromResult(
                                new Response(System.Net.HttpStatusCode.InternalServerError,
                                             "null")));
            
            try {
                var task = NotificationResource.Create("ISaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").ExecuteAsync(twilioRestClient);
            task.Wait();
                Assert.Fail("Expected TwilioException to be thrown for 500");
            } catch (AggregateException ae) {
                ae.Handle((e) =>
                {
                    if (e.GetType() != typeof(ApiException)) {
                        throw e;
                        return false;
                    }
            
                    return true;
                });
            }
            twilioRestClient.Received().Request(request);
        }
    
        [Test]
        public void TestCreateResponse() {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            twilioRestClient.Request(Arg.Any<Request>())
                            .Returns(System.Threading.Tasks.Task.FromResult(
                                new Response(System.Net.HttpStatusCode.Created,
                                             "{\"sid\": \"NOb8021351170b4e1286adaac3fdd6d082\",\"account_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"service_sid\": \"IS699b53e02da45a1ba9d13b7d7d2766af\",\"date_created\": \"2016-03-24T23:42:28Z\",\"identities\": [\"jing\"],\"tags\": [],\"priority\": \"high\",\"ttl\": 2419200,\"title\": \"test\",\"body\": \"body\",\"sound\": null,\"action\": null,\"data\": null,\"apn\": null,\"gcm\": null}")));
            
            var task = NotificationResource.Create("ISaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").ExecuteAsync(twilioRestClient);
            task.Wait();
        }
    }
}
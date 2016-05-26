using NSubstitute;
using NUnit.Framework;
using System;
using Twilio;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Resources.Monitor.V1;

namespace Twilio.Tests.Monitor.V1 {

    [TestFixture]
    public class EventTest : TwilioTest {
        [SetUp]
        public void SetUp() {
        }
    
        [Test]
        public void TestFetchRequest() {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            Request request = new Request(System.Net.Http.HttpMethod.Get,
                                          Domains.MONITOR,
                                          "/v1/Events/AEaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
            
            
            twilioRestClient.Request(request)
                            .Returns(new Response(System.Net.HttpStatusCode.InternalServerError,
                                                  "null"));
            
            try {
                EventResource.Fetch("AEaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").Execute(twilioRestClient);
                Assert.Fail("Expected TwilioException to be thrown for 500");
            } catch (AggregateException ae) {
                ae.Handle((e) =>
                {
                    if (e.GetType() != typeof(ApiException)) {
                        throw e;
                    }
            
                    return true;
                });
            } catch (ApiException e) {
            }
            twilioRestClient.Received().Request(request);
        }
    
        [Test]
        public void TestFetchResponse() {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            twilioRestClient.Request(Arg.Any<Request>())
                            .Returns(new Response(System.Net.HttpStatusCode.OK,
                                                  "{\"account_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"actor_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"actor_type\": \"account\",\"description\": null,\"event_data\": {\"friendly_name\": {\"previous\": \"SubAccount Created at 2014-10-03 09:48 am\",\"updated\": \"Mr. Friendly\"}},\"event_date\": \"2014-10-03T16:48:25Z\",\"event_type\": \"account.updated\",\"links\": {\"actor\": \"https://api.twilio.com/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"resource\": \"https://api.twilio.com/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\"},\"resource_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"resource_type\": \"account\",\"sid\": \"AEaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"source\": \"api\",\"source_ip_address\": \"10.86.6.250\",\"url\": \"https://monitor.twilio.com/v1/Events/AEaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\"}"));
            
            var response = EventResource.Fetch("AEaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").Execute(twilioRestClient);
            Assert.NotNull(response);
        }
    
        [Test]
        public void TestReadRequest() {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            Request request = new Request(System.Net.Http.HttpMethod.Get,
                                          Domains.MONITOR,
                                          "/v1/Events");
            
            request.AddQueryParam("PageSize", "50");
            twilioRestClient.Request(request)
                            .Returns(new Response(System.Net.HttpStatusCode.InternalServerError,
                                                  "null"));
            
            try {
                EventResource.Read().Execute(twilioRestClient);
                Assert.Fail("Expected TwilioException to be thrown for 500");
            } catch (AggregateException ae) {
                ae.Handle((e) =>
                {
                    if (e.GetType() != typeof(ApiException)) {
                        throw e;
                    }
            
                    return true;
                });
            } catch (ApiException e) {
            }
            twilioRestClient.Received().Request(request);
        }
    
        [Test]
        public void TestReadFullResponse() {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            twilioRestClient.Request(Arg.Any<Request>())
                            .Returns(new Response(System.Net.HttpStatusCode.OK,
                                                  "{\"events\": [{\"account_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"actor_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"actor_type\": \"account\",\"description\": null,\"event_data\": {\"friendly_name\": {\"previous\": \"SubAccount Created at 2014-10-03 09:48 am\",\"updated\": \"Mr. Friendly\"}},\"event_date\": \"2014-10-03T16:48:25Z\",\"event_type\": \"account.updated\",\"links\": {\"actor\": \"https://api.twilio.com/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"resource\": \"https://api.twilio.com/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\"},\"resource_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"resource_type\": \"account\",\"sid\": \"AEaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"source\": \"api\",\"source_ip_address\": \"10.86.6.250\",\"url\": \"https://monitor.twilio.com/v1/Events/AEaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\"}],\"meta\": {\"first_page_url\": \"https://monitor.twilio.com/v1/Events?PageSize=50&Page=0\",\"key\": \"events\",\"next_page_url\": null,\"page\": 0,\"page_size\": 50,\"previous_page_url\": null,\"url\": \"https://monitor.twilio.com/v1/Events?PageSize=50&Page=0\"}}"));
            
            var response = EventResource.Read().Execute(twilioRestClient);
            Assert.NotNull(response);
        }
    
        [Test]
        public void TestReadEmptyResponse() {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            twilioRestClient.Request(Arg.Any<Request>())
                            .Returns(new Response(System.Net.HttpStatusCode.OK,
                                                  "{\"events\": [],\"meta\": {\"first_page_url\": \"https://monitor.twilio.com/v1/Events?PageSize=50&Page=0\",\"key\": \"events\",\"next_page_url\": null,\"page\": 0,\"page_size\": 50,\"previous_page_url\": null,\"url\": \"https://monitor.twilio.com/v1/Events?PageSize=50&Page=0\"}}"));
            
            var response = EventResource.Read().Execute(twilioRestClient);
            Assert.NotNull(response);
        }
    }
}
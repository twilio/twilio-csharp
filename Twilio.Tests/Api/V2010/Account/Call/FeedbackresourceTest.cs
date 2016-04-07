using NUnit.Framework;
using NUnit.Mocks;
using System;
using Twilio;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Tests.Api.V2010.Account.Call {

    [TestFixture]
    public class FeedbackTest : TwilioTest {
        private DynamicMock twilioRestClient;
    
        [SetUp]
        public void SetUp() {
            TwilioClient.init("AC123", "AUTH TOKEN");
            twilioRestClient = new DynamicMock(typeof(ITwilioRestClient));
        }
    
        [TestCase]
        public void TestCreateRequest() {
            ITwilioRestClient client = (ITwilioRestClient) twilioRestClient;
            Request request = new Request(System.Net.Http.HttpMethod.Post,
                                          Domains.API,
                                          "/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Calls/CAaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Feedback.json");
            request.AddPostParam("QualityScore", Serialize(1));
            
            twilioRestClient.ExpectAndReturn("Request", new Response(System.Net.HttpStatusCode.OK, null), request);
            client.Request(request);
        }
    
        [TestCase]
        public void TestFetchRequest() {
            ITwilioRestClient client = (ITwilioRestClient) twilioRestClient;
            Request request = new Request(System.Net.Http.HttpMethod.Get,
                                          Domains.API,
                                          "/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Calls/CAaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Feedback.json");
            
            
            twilioRestClient.ExpectAndReturn("Request", new Response(System.Net.HttpStatusCode.OK, null), request);
            client.Request(request);
        }
    
        [TestCase]
        public void TestUpdateRequest() {
            ITwilioRestClient client = (ITwilioRestClient) twilioRestClient;
            Request request = new Request(System.Net.Http.HttpMethod.Post,
                                          Domains.API,
                                          "/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Calls/CAaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Feedback.json");
            request.AddPostParam("QualityScore", Serialize(1));
            
            twilioRestClient.ExpectAndReturn("Request", new Response(System.Net.HttpStatusCode.OK, null), request);
            client.Request(request);
        }
    }
}
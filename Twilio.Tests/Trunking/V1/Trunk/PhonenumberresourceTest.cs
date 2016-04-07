using NUnit.Framework;
using NUnit.Mocks;
using System;
using Twilio;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Tests.Trunking.V1.Trunk {

    [TestFixture]
    public class PhoneNumberTest : TwilioTest {
        private DynamicMock twilioRestClient;
    
        [SetUp]
        public void SetUp() {
            TwilioClient.init("AC123", "AUTH TOKEN");
            twilioRestClient = new DynamicMock(typeof(ITwilioRestClient));
        }
    
        [TestCase]
        public void TestFetchRequest() {
            ITwilioRestClient client = (ITwilioRestClient) twilioRestClient;
            Request request = new Request(System.Net.Http.HttpMethod.Get,
                                          Domains.TRUNKING,
                                          "/v1/Trunks/TRaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/PhoneNumbers/PNaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
            
            
            twilioRestClient.ExpectAndReturn("Request", new Response(System.Net.HttpStatusCode.OK, null), request);
            client.Request(request);
        }
    
        [TestCase]
        public void TestDeleteRequest() {
            ITwilioRestClient client = (ITwilioRestClient) twilioRestClient;
            Request request = new Request(System.Net.Http.HttpMethod.Delete,
                                          Domains.TRUNKING,
                                          "/v1/Trunks/TRaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/PhoneNumbers/PNaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
            
            
            twilioRestClient.ExpectAndReturn("Request", new Response(System.Net.HttpStatusCode.OK, null), request);
            client.Request(request);
        }
    
        [TestCase]
        public void TestCreateRequest() {
            ITwilioRestClient client = (ITwilioRestClient) twilioRestClient;
            Request request = new Request(System.Net.Http.HttpMethod.Post,
                                          Domains.TRUNKING,
                                          "/v1/Trunks/TRaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/PhoneNumbers");
            request.AddPostParam("PhoneNumberSid", Serialize("PNaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa"));
            
            twilioRestClient.ExpectAndReturn("Request", new Response(System.Net.HttpStatusCode.OK, null), request);
            client.Request(request);
        }
    
        [TestCase]
        public void TestReadRequest() {
            ITwilioRestClient client = (ITwilioRestClient) twilioRestClient;
            Request request = new Request(System.Net.Http.HttpMethod.Get,
                                          Domains.TRUNKING,
                                          "/v1/Trunks/TRaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/PhoneNumbers");
            
            request.AddQueryParam("PageSize", "50");
            twilioRestClient.ExpectAndReturn("Request", new Response(System.Net.HttpStatusCode.OK, null), request);
            client.Request(request);
        }
    }
}
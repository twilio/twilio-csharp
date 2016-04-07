using NUnit.Framework;
using NUnit.Mocks;
using System;
using Twilio;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Tests.Api.V2010.Account {

    [TestFixture]
    public class AddressTest : TwilioTest {
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
                                                      "/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Addresses.json");
                        request.AddPostParam("CustomerName", Serialize("customerName"));
            request.AddPostParam("Street", Serialize("street"));
            request.AddPostParam("City", Serialize("city"));
            request.AddPostParam("Region", Serialize("region"));
            request.AddPostParam("PostalCode", Serialize("postalCode"));
            request.AddPostParam("IsoCountry", Serialize("US"));
                        
                        twilioRestClient.ExpectAndReturn("Request", new Response(System.Net.HttpStatusCode.OK, null), request);
                        client.Request(request);
        }
    
        [TestCase]
        public void TestDeleteRequest() {
            ITwilioRestClient client = (ITwilioRestClient) twilioRestClient;
            Request request = new Request(System.Net.Http.HttpMethod.Delete,
                                          Domains.API,
                                          "/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Addresses/ADaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa.json");
            
            
            twilioRestClient.ExpectAndReturn("Request", new Response(System.Net.HttpStatusCode.OK, null), request);
            client.Request(request);
        }
    
        [TestCase]
        public void TestFetchRequest() {
            ITwilioRestClient client = (ITwilioRestClient) twilioRestClient;
            Request request = new Request(System.Net.Http.HttpMethod.Get,
                                          Domains.API,
                                          "/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Addresses/ADaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa.json");
            
            
            twilioRestClient.ExpectAndReturn("Request", new Response(System.Net.HttpStatusCode.OK, null), request);
            client.Request(request);
        }
    
        [TestCase]
        public void TestUpdateRequest() {
            ITwilioRestClient client = (ITwilioRestClient) twilioRestClient;
            Request request = new Request(System.Net.Http.HttpMethod.Post,
                                          Domains.API,
                                          "/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Addresses/ADaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa.json");
            
            
            twilioRestClient.ExpectAndReturn("Request", new Response(System.Net.HttpStatusCode.OK, null), request);
            client.Request(request);
        }
    
        [TestCase]
        public void TestReadRequest() {
            ITwilioRestClient client = (ITwilioRestClient) twilioRestClient;
            Request request = new Request(System.Net.Http.HttpMethod.Get,
                                          Domains.API,
                                          "/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Addresses.json");
            
            request.AddQueryParam("PageSize", "50");
            twilioRestClient.ExpectAndReturn("Request", new Response(System.Net.HttpStatusCode.OK, null), request);
            client.Request(request);
        }
    }
}
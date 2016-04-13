using NSubstitute;
using NUnit.Framework;
using System;
using Twilio;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Resources.Lookups.V1;

namespace Twilio.Tests.Lookups.V1 {

    [TestFixture]
    public class PhoneNumberTest : TwilioTest {
        [SetUp]
        public void SetUp() {
        }
    
        [TestCase]
        public void TestFetchRequest() {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            Request request = new Request(System.Net.Http.HttpMethod.Get,
                                          Domains.LOOKUPS,
                                          "/v1/PhoneNumbers/+987654321");
            
            
            twilioRestClient.Request(request)
                            .Returns(new Response(System.Net.HttpStatusCode.OK, null));
            
            try {
                PhoneNumberResource.Fetch(new Twilio.Types.PhoneNumber("+987654321")).ExecuteAsync(twilioRestClient);
                Assert.Fail("Expected TwilioException to be thrown for 500");
            } catch (TwilioException e) {}
            twilioRestClient.Received().Request(request);
        }
    
        [Test]
        public void TestFetchResponse() {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            twilioRestClient.Request(Arg.Any<Request>())
                            .Returns(new Response(System.Net.HttpStatusCode.OK,
                                     "{\"carrier\": {\"error_code\": null,\"mobile_country_code\": \"310\",\"mobile_network_code\": \"456\",\"name\": \"verizon\",\"type\": \"mobile\"},\"country_code\": \"US\",\"national_format\": \"(510) 867-5309\",\"phone_number\": \"+15108675309\",\"url\": \"https://lookups.twilio.com/v1/PhoneNumbers/phone_number\"}"));
            
            Assert.NotNull(PhoneNumberResource.Fetch(new Twilio.Types.PhoneNumber("+987654321"))"
                  .ExecuteAsync(twilioRestClient));
        }
    }
}
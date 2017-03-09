using NSubstitute;
using NSubstitute.ExceptionExtensions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Rest.Lookups.V1;

namespace Twilio.Tests.Rest.Lookups.V1 
{

    [TestFixture]
    public class PhoneNumberTest : TwilioTest 
    {
        [Test]
        public void TestFetchRequest()
        {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            var request = new Request(
                HttpMethod.Get,
                Twilio.Rest.Domain.Lookups,
                "/v1/PhoneNumbers/+987654321",
                ""
            );
            twilioRestClient.Request(request).Throws(new ApiException("Server Error, no content"));

            try
            {
                PhoneNumberResource.Fetch(new Twilio.Types.PhoneNumber("+987654321"), client: twilioRestClient);
                Assert.Fail("Expected TwilioException to be thrown for 500");
            }
            catch (ApiException) {}
            twilioRestClient.Received().Request(request);
        }

        [Test]
        public void TestFetchResponse()
        {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            twilioRestClient.AccountSid.Returns("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
            twilioRestClient.Request(Arg.Any<Request>())
                            .Returns(new Response(
                                         System.Net.HttpStatusCode.OK,
                                         "{\"caller_name\": {\"caller_name\": \"Delicious Cheese Cake\",\"caller_type\": \"CONSUMER\",\"error_code\": null},\"carrier\": {\"error_code\": null,\"mobile_country_code\": \"310\",\"mobile_network_code\": \"456\",\"name\": \"verizon\",\"type\": \"mobile\"},\"country_code\": \"US\",\"national_format\": \"(510) 867-5309\",\"phone_number\": \"+15108675309\",\"add_ons\": {\"status\": \"successful\",\"message\": null,\"code\": null,\"results\": {}},\"url\": \"https://lookups.twilio.com/v1/PhoneNumbers/phone_number\"}"
                                     ));

            var response = PhoneNumberResource.Fetch(new Twilio.Types.PhoneNumber("+987654321"), client: twilioRestClient);
            Assert.NotNull(response);
        }
    }

}
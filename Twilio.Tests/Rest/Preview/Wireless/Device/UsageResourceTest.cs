using NSubstitute;
using NSubstitute.ExceptionExtensions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Rest.Preview.Wireless.Device;

namespace Twilio.Tests.Rest.Preview.Wireless.Device 
{

    [TestFixture]
    public class UsageTest : TwilioTest 
    {
        [Test]
        public void TestFetchRequest()
        {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            var request = new Request(
                HttpMethod.Get,
                Twilio.Rest.Domain.Preview,
                "/wireless/Devices/DEaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Usage",
                ""
            );
            twilioRestClient.Request(request).Throws(new ApiException("Server Error, no content"));
            
            try
            {
                UsageResource.Fetch("DEaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", client: twilioRestClient);
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
                                         "{\"account_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"commands_costs\": {},\"commands_usage\": {},\"data_costs\": {},\"data_usage\": {},\"device_alias\": \"device_alias\",\"device_sid\": \"DEaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"period\": {},\"url\": \"https://preview.twilio.com/wireless/Devices/DEaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Usage\"}"
                                     ));
            
            var response = UsageResource.Fetch("DEaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", client: twilioRestClient);
            Assert.NotNull(response);
        }
    }

}
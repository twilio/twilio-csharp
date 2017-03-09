using NSubstitute;
using NSubstitute.ExceptionExtensions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Rest.Monitor.V1;

namespace Twilio.Tests.Rest.Monitor.V1 
{

    [TestFixture]
    public class AlertTest : TwilioTest 
    {
        [Test]
        public void TestFetchRequest()
        {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            var request = new Request(
                HttpMethod.Get,
                Twilio.Rest.Domain.Monitor,
                "/v1/Alerts/NOaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa",
                ""
            );
            twilioRestClient.Request(request).Throws(new ApiException("Server Error, no content"));

            try
            {
                AlertResource.Fetch("NOaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", client: twilioRestClient);
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
                                         "{\"account_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"alert_text\": \"alert_text\",\"api_version\": \"2010-04-01\",\"date_created\": \"2015-07-30T20:00:00Z\",\"date_generated\": \"2015-07-30T20:00:00Z\",\"date_updated\": \"2015-07-30T20:00:00Z\",\"error_code\": \"error_code\",\"log_level\": \"log_level\",\"more_info\": \"more_info\",\"request_method\": \"GET\",\"request_url\": \"http://www.example.com\",\"request_variables\": \"request_variables\",\"resource_sid\": \"aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"response_body\": \"response_body\",\"response_headers\": \"response_headers\",\"sid\": \"NOaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"url\": \"http://www.example.com\"}"
                                     ));

            var response = AlertResource.Fetch("NOaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", client: twilioRestClient);
            Assert.NotNull(response);
        }

        [Test]
        public void TestDeleteRequest()
        {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            var request = new Request(
                HttpMethod.Delete,
                Twilio.Rest.Domain.Monitor,
                "/v1/Alerts/NOaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa",
                ""
            );
            twilioRestClient.Request(request).Throws(new ApiException("Server Error, no content"));

            try
            {
                AlertResource.Delete("NOaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", client: twilioRestClient);
                Assert.Fail("Expected TwilioException to be thrown for 500");
            }
            catch (ApiException) {}
            twilioRestClient.Received().Request(request);
        }

        [Test]
        public void TestDeleteResponse()
        {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            twilioRestClient.AccountSid.Returns("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
            twilioRestClient.Request(Arg.Any<Request>())
                            .Returns(new Response(
                                         System.Net.HttpStatusCode.NoContent,
                                         "null"
                                     ));

            var response = AlertResource.Delete("NOaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", client: twilioRestClient);
            Assert.NotNull(response);
        }

        [Test]
        public void TestReadRequest()
        {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            var request = new Request(
                HttpMethod.Get,
                Twilio.Rest.Domain.Monitor,
                "/v1/Alerts",
                ""
            );
            twilioRestClient.Request(request).Throws(new ApiException("Server Error, no content"));

            try
            {
                AlertResource.Read(client: twilioRestClient);
                Assert.Fail("Expected TwilioException to be thrown for 500");
            }
            catch (ApiException) {}
            twilioRestClient.Received().Request(request);
        }

        [Test]
        public void TestReadEmptyResponse()
        {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            twilioRestClient.AccountSid.Returns("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
            twilioRestClient.Request(Arg.Any<Request>())
                            .Returns(new Response(
                                         System.Net.HttpStatusCode.OK,
                                         "{\"alerts\": [],\"meta\": {\"first_page_url\": \"https://monitor.twilio.com/v1/Alerts?Page=0&PageSize=50\",\"key\": \"alerts\",\"next_page_url\": null,\"page\": 0,\"page_size\": 0,\"previous_page_url\": null,\"url\": \"https://monitor.twilio.com/v1/Alerts\"}}"
                                     ));

            var response = AlertResource.Read(client: twilioRestClient);
            Assert.NotNull(response);
        }

        [Test]
        public void TestReadFullResponse()
        {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            twilioRestClient.AccountSid.Returns("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
            twilioRestClient.Request(Arg.Any<Request>())
                            .Returns(new Response(
                                         System.Net.HttpStatusCode.OK,
                                         "{\"alerts\": [{\"account_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"alert_text\": \"alert_text\",\"api_version\": \"2010-04-01\",\"date_created\": \"2015-07-30T20:00:00Z\",\"date_generated\": \"2015-07-30T20:00:00Z\",\"date_updated\": \"2015-07-30T20:00:00Z\",\"error_code\": \"error_code\",\"log_level\": \"log_level\",\"more_info\": \"more_info\",\"request_method\": \"GET\",\"request_url\": \"http://www.example.com\",\"resource_sid\": \"aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"sid\": \"NOaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"url\": \"http://www.example.com\"}],\"meta\": {\"first_page_url\": \"https://monitor.twilio.com/v1/Alerts?Page=0&PageSize=50\",\"key\": \"alerts\",\"next_page_url\": null,\"page\": 0,\"page_size\": 1,\"previous_page_url\": null,\"url\": \"https://monitor.twilio.com/v1/Alerts\"}}"
                                     ));

            var response = AlertResource.Read(client: twilioRestClient);
            Assert.NotNull(response);
        }
    }

}
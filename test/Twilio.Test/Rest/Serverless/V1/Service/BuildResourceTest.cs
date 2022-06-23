/// This code was generated by
/// \ / _    _  _|   _  _
///  | (_)\/(_)(_|\/| |(/_  v1.0.0
///       /       /

using NSubstitute;
using NSubstitute.ExceptionExtensions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Rest.Serverless.V1.Service;

namespace Twilio.Tests.Rest.Serverless.V1.Service
{

    [TestFixture]
    public class BuildTest : TwilioTest
    {
        [Test]
        public void TestReadRequest()
        {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            var request = new Request(
                HttpMethod.Get,
                Twilio.Rest.Domain.Serverless,
                "/v1/Services/ZSXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX/Builds",
                ""
            );
            twilioRestClient.Request(request).Throws(new ApiException("Server Error, no content"));

            try
            {
                BuildResource.Read("ZSXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX", client: twilioRestClient);
                Assert.Fail("Expected TwilioException to be thrown for 500");
            }
            catch (ApiException) {}
            twilioRestClient.Received().Request(request);
        }

        [Test]
        public void TestReadEmptyResponse()
        {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            twilioRestClient.AccountSid.Returns("ACXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");
            twilioRestClient.Request(Arg.Any<Request>())
                            .Returns(new Response(
                                         System.Net.HttpStatusCode.OK,
                                         "{\"builds\": [],\"meta\": {\"first_page_url\": \"https://serverless.twilio.com/v1/Services/ZS00000000000000000000000000000000/Builds?PageSize=50&Page=0\",\"key\": \"builds\",\"next_page_url\": null,\"page\": 0,\"page_size\": 50,\"previous_page_url\": null,\"url\": \"https://serverless.twilio.com/v1/Services/ZS00000000000000000000000000000000/Builds?PageSize=50&Page=0\"}}"
                                     ));

            var response = BuildResource.Read("ZSXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX", client: twilioRestClient);
            Assert.NotNull(response);
        }

        [Test]
        public void TestFetchRequest()
        {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            var request = new Request(
                HttpMethod.Get,
                Twilio.Rest.Domain.Serverless,
                "/v1/Services/ZSXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX/Builds/ZBXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX",
                ""
            );
            twilioRestClient.Request(request).Throws(new ApiException("Server Error, no content"));

            try
            {
                BuildResource.Fetch("ZSXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX", "ZBXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX", client: twilioRestClient);
                Assert.Fail("Expected TwilioException to be thrown for 500");
            }
            catch (ApiException) {}
            twilioRestClient.Received().Request(request);
        }

        [Test]
        public void TestFetchResponse()
        {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            twilioRestClient.AccountSid.Returns("ACXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");
            twilioRestClient.Request(Arg.Any<Request>())
                            .Returns(new Response(
                                         System.Net.HttpStatusCode.OK,
                                         "{\"sid\": \"ZB00000000000000000000000000000000\",\"account_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"service_sid\": \"ZS00000000000000000000000000000000\",\"asset_versions\": [{\"sid\": \"ZN00000000000000000000000000000000\",\"account_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"service_sid\": \"ZS00000000000000000000000000000000\",\"asset_sid\": \"ZH00000000000000000000000000000000\",\"date_created\": \"2018-11-10T20:00:00Z\",\"path\": \"/asset-path\",\"visibility\": \"PUBLIC\"}],\"function_versions\": [{\"sid\": \"ZN00000000000000000000000000000001\",\"account_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"service_sid\": \"ZS00000000000000000000000000000000\",\"function_sid\": \"ZH00000000000000000000000000000001\",\"date_created\": \"2018-11-10T20:00:00Z\",\"path\": \"/function-path\",\"visibility\": \"PUBLIC\"}],\"dependencies\": [{\"name\": \"twilio\",\"version\": \"3.29.2\"},{\"name\": \"@twilio/runtime-handler\",\"version\": \"1.0.1\"}],\"runtime\": \"node14\",\"status\": \"building\",\"date_created\": \"2018-11-10T20:00:00Z\",\"date_updated\": \"2018-11-10T20:00:00Z\",\"url\": \"https://serverless.twilio.com/v1/Services/ZS00000000000000000000000000000000/Builds/ZB00000000000000000000000000000000\",\"links\": {\"build_status\": \"https://serverless.twilio.com/v1/Services/ZS00000000000000000000000000000000/Builds/ZB00000000000000000000000000000000/Status\"}}"
                                     ));

            var response = BuildResource.Fetch("ZSXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX", "ZBXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX", client: twilioRestClient);
            Assert.NotNull(response);
        }

        [Test]
        public void TestDeleteRequest()
        {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            var request = new Request(
                HttpMethod.Delete,
                Twilio.Rest.Domain.Serverless,
                "/v1/Services/ZSXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX/Builds/ZBXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX",
                ""
            );
            twilioRestClient.Request(request).Throws(new ApiException("Server Error, no content"));

            try
            {
                BuildResource.Delete("ZSXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX", "ZBXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX", client: twilioRestClient);
                Assert.Fail("Expected TwilioException to be thrown for 500");
            }
            catch (ApiException) {}
            twilioRestClient.Received().Request(request);
        }

        [Test]
        public void TestDeleteResponse()
        {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            twilioRestClient.AccountSid.Returns("ACXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");
            twilioRestClient.Request(Arg.Any<Request>())
                            .Returns(new Response(
                                         System.Net.HttpStatusCode.NoContent,
                                         "null"
                                     ));

            var response = BuildResource.Delete("ZSXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX", "ZBXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX", client: twilioRestClient);
            Assert.NotNull(response);
        }

        [Test]
        public void TestCreateRequest()
        {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            var request = new Request(
                HttpMethod.Post,
                Twilio.Rest.Domain.Serverless,
                "/v1/Services/ZSXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX/Builds",
                ""
            );
            twilioRestClient.Request(request).Throws(new ApiException("Server Error, no content"));

            try
            {
                BuildResource.Create("ZSXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX", client: twilioRestClient);
                Assert.Fail("Expected TwilioException to be thrown for 500");
            }
            catch (ApiException) {}
            twilioRestClient.Received().Request(request);
        }

        [Test]
        public void TestCreateResponse()
        {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            twilioRestClient.AccountSid.Returns("ACXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");
            twilioRestClient.Request(Arg.Any<Request>())
                            .Returns(new Response(
                                         System.Net.HttpStatusCode.Created,
                                         "{\"sid\": \"ZB00000000000000000000000000000000\",\"account_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"service_sid\": \"ZS00000000000000000000000000000000\",\"asset_versions\": [{\"sid\": \"ZN00000000000000000000000000000000\",\"account_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"service_sid\": \"ZS00000000000000000000000000000000\",\"asset_sid\": \"ZH00000000000000000000000000000000\",\"date_created\": \"2018-11-10T20:00:00Z\",\"path\": \"/asset-path\",\"visibility\": \"PUBLIC\"}],\"function_versions\": [{\"sid\": \"ZN00000000000000000000000000000001\",\"account_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"service_sid\": \"ZS00000000000000000000000000000000\",\"function_sid\": \"ZH00000000000000000000000000000001\",\"date_created\": \"2018-11-10T20:00:00Z\",\"path\": \"/function-path\",\"visibility\": \"PUBLIC\"}],\"dependencies\": [{\"name\": \"twilio\",\"version\": \"3.29.2\"},{\"name\": \"@twilio/runtime-handler\",\"version\": \"1.0.1\"}],\"runtime\": \"node14\",\"status\": \"building\",\"date_created\": \"2018-11-10T20:00:00Z\",\"date_updated\": \"2018-11-10T20:00:00Z\",\"url\": \"https://serverless.twilio.com/v1/Services/ZS00000000000000000000000000000000/Builds/ZB00000000000000000000000000000000\",\"links\": {\"build_status\": \"https://serverless.twilio.com/v1/Services/ZS00000000000000000000000000000000/Builds/ZB00000000000000000000000000000000/Status\"}}"
                                     ));

            var response = BuildResource.Create("ZSXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX", client: twilioRestClient);
            Assert.NotNull(response);
        }
    }

}
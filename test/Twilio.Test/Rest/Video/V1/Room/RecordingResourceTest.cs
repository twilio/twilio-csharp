using NSubstitute;
using NSubstitute.ExceptionExtensions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Rest.Video.V1.Room;

namespace Twilio.Tests.Rest.Video.V1.Room 
{

    [TestFixture]
    public class RecordingTest : TwilioTest 
    {
        [Test]
        public void TestFetchRequest()
        {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            var request = new Request(
                HttpMethod.Get,
                Twilio.Rest.Domain.Video,
                "/v1/Rooms/RMaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Recordings/RTaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa",
                ""
            );
            twilioRestClient.Request(request).Throws(new ApiException("Server Error, no content"));

            try
            {
                RecordingResource.Fetch("RMaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "RTaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", client: twilioRestClient);
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
                                         "{\"account_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"status\": \"processing\",\"date_created\": \"2015-07-30T20:00:00Z\",\"sid\": \"RTaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"source_sid\": \"MTaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"size\": 0,\"type\": \"audio\",\"duration\": 0,\"container_format\": \"mka\",\"codec\": \"OPUS\",\"grouping_sids\": {\"room_sid\": \"RMaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\"},\"room_sid\": \"RMaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"url\": \"https://video.twilio.com/v1/Rooms/RMaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Recordings/RTaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"links\": {\"media\": \"https://video.twilio.com/v1/Rooms/RMaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Recordings/RTaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Media\"}}"
                                     ));

            var response = RecordingResource.Fetch("RMaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "RTaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", client: twilioRestClient);
            Assert.NotNull(response);
        }

        [Test]
        public void TestReadRequest()
        {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            var request = new Request(
                HttpMethod.Get,
                Twilio.Rest.Domain.Video,
                "/v1/Rooms/RMaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Recordings",
                ""
            );
            twilioRestClient.Request(request).Throws(new ApiException("Server Error, no content"));

            try
            {
                RecordingResource.Read("RMaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", client: twilioRestClient);
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
                                         "{\"recordings\": [],\"meta\": {\"page\": 0,\"page_size\": 50,\"first_page_url\": \"https://video.twilio.com/v1/Rooms/RMaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Recordings?PageSize=50&Page=0\",\"previous_page_url\": null,\"url\": \"https://video.twilio.com/v1/Rooms/RMaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Recordings?PageSize=50&Page=0\",\"next_page_url\": null,\"key\": \"recordings\"}}"
                                     ));

            var response = RecordingResource.Read("RMaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", client: twilioRestClient);
            Assert.NotNull(response);
        }

        [Test]
        public void TestReadResultsResponse()
        {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            twilioRestClient.AccountSid.Returns("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
            twilioRestClient.Request(Arg.Any<Request>())
                            .Returns(new Response(
                                         System.Net.HttpStatusCode.OK,
                                         "{\"recordings\": [{\"account_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"status\": \"completed\",\"date_created\": \"2015-07-30T20:00:00Z\",\"sid\": \"RTaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"source_sid\": \"MTaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"size\": 0,\"type\": \"audio\",\"duration\": 0,\"container_format\": \"mka\",\"codec\": \"OPUS\",\"grouping_sids\": {\"room_sid\": \"RMaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\"},\"room_sid\": \"RMaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"url\": \"https://video.twilio.com/v1/Rooms/RMaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Recordings/RTaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"links\": {\"media\": \"https://video.twilio.com/v1/Rooms/RMaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Recordings/RTaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Media\"}}],\"meta\": {\"page\": 0,\"page_size\": 50,\"first_page_url\": \"https://video.twilio.com/v1/Rooms/RMaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Recordings?PageSize=50&Page=0\",\"previous_page_url\": null,\"url\": \"https://video.twilio.com/v1/Rooms/RMaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Recordings?PageSize=50&Page=0\",\"next_page_url\": null,\"key\": \"recordings\"}}"
                                     ));

            var response = RecordingResource.Read("RMaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", client: twilioRestClient);
            Assert.NotNull(response);
        }
    }

}
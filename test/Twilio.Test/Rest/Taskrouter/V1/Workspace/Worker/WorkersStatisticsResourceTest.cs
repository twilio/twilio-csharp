using NSubstitute;
using NSubstitute.ExceptionExtensions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Rest.Taskrouter.V1.Workspace.Worker;

namespace Twilio.Tests.Rest.Taskrouter.V1.Workspace.Worker 
{

    [TestFixture]
    public class WorkersStatisticsTest : TwilioTest 
    {
        [Test]
        public void TestFetchRequest()
        {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            var request = new Request(
                HttpMethod.Get,
                Twilio.Rest.Domain.Taskrouter,
                "/v1/Workspaces/WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Workers/Statistics",
                ""
            );
            twilioRestClient.Request(request).Throws(new ApiException("Server Error, no content"));

            try
            {
                WorkersStatisticsResource.Fetch("WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", client: twilioRestClient);
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
                                         "{\"account_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"url\": \"https://taskrouter.twilio.com/v1/Workspaces/WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Workers/Statistics\",\"cumulative\": {\"activity_durations\": [{\"avg\": 0.0,\"friendly_name\": \"80fa2beb-3a05-11e5-8fc8-98e0d9a1eb73\",\"max\": 0,\"min\": 0,\"sid\": \"WAaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"total\": 0},{\"avg\": 0.0,\"friendly_name\": \"817ca1c5-3a05-11e5-9292-98e0d9a1eb73\",\"max\": 0,\"min\": 0,\"sid\": \"WAaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"total\": 0},{\"avg\": 0.0,\"friendly_name\": \"Busy\",\"max\": 0,\"min\": 0,\"sid\": \"WAaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"total\": 0},{\"avg\": 0.0,\"friendly_name\": \"Idle\",\"max\": 0,\"min\": 0,\"sid\": \"WAaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"total\": 0},{\"avg\": 0.0,\"friendly_name\": \"Offline\",\"max\": 0,\"min\": 0,\"sid\": \"WAaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"total\": 0},{\"avg\": 0.0,\"friendly_name\": \"Reserved\",\"max\": 0,\"min\": 0,\"sid\": \"WAaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"total\": 0}],\"end_time\": \"2015-08-18T16:35:33Z\",\"reservations_accepted\": 0,\"reservations_canceled\": 0,\"reservations_created\": 0,\"reservations_rejected\": 0,\"reservations_rescinded\": 0,\"reservations_timed_out\": 0,\"start_time\": \"2015-08-18T16:20:33Z\",\"tasks_assigned\": 0},\"realtime\": {\"activity_statistics\": [{\"friendly_name\": \"Offline\",\"sid\": \"WAaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"workers\": 1},{\"friendly_name\": \"Idle\",\"sid\": \"WAaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"workers\": 0},{\"friendly_name\": \"80fa2beb-3a05-11e5-8fc8-98e0d9a1eb73\",\"sid\": \"WAaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"workers\": 0},{\"friendly_name\": \"Reserved\",\"sid\": \"WAaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"workers\": 0},{\"friendly_name\": \"Busy\",\"sid\": \"WAaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"workers\": 0},{\"friendly_name\": \"817ca1c5-3a05-11e5-9292-98e0d9a1eb73\",\"sid\": \"WAaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"workers\": 0}],\"total_workers\": 1},\"workspace_sid\": \"WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\"}"
                                     ));

            var response = WorkersStatisticsResource.Fetch("WSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", client: twilioRestClient);
            Assert.NotNull(response);
        }
    }

}
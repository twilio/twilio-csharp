using NSubstitute;
using NSubstitute.ExceptionExtensions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Rest.Api.V2010.Account.Call;

namespace Twilio.Tests.Rest.Api.V2010.Account.Call 
{

    [TestFixture]
    public class FeedbackSummaryTest : TwilioTest 
    {
        [Test]
        public void TestCreateRequest()
        {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            var request = new Request(
                HttpMethod.Post,
                Twilio.Rest.Domain.Api,
                "/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Calls/FeedbackSummary.json",
                ""
            );
            request.AddPostParam("StartDate", Serialize(MarshalConverter.DateTimeFromString("2008-01-02")));
            request.AddPostParam("EndDate", Serialize(MarshalConverter.DateTimeFromString("2008-01-02")));
            twilioRestClient.AccountSid.Returns("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
            twilioRestClient.Request(request).Throws(new ApiException("Server Error, no content"));

            try
            {
                FeedbackSummaryResource.Create(MarshalConverter.DateTimeFromString("2008-01-02"), MarshalConverter.DateTimeFromString("2008-01-02"), client: twilioRestClient);
                Assert.Fail("Expected TwilioException to be thrown for 500");
            }
            catch (ApiException) {}
            twilioRestClient.Received().Request(request);
        }

        [Test]
        public void TestCreateResponse()
        {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            twilioRestClient.AccountSid.Returns("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
            twilioRestClient.Request(Arg.Any<Request>())
                            .Returns(new Response(
                                         System.Net.HttpStatusCode.Created,
                                         "{\"account_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"call_count\": 10200,\"call_feedback_count\": 729,\"end_date\": \"2011-01-01\",\"include_subaccounts\": false,\"issues\": [{\"count\": 45,\"description\": \"imperfect-audio\",\"percentage_of_total_calls\": \"0.04%\"}],\"quality_score_average\": 4.5,\"quality_score_median\": 4,\"quality_score_standard_deviation\": 1,\"sid\": \"FSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"start_date\": \"2011-01-01\",\"status\": \"completed\",\"date_created\": \"Tue, 31 Aug 2010 20:36:28 +0000\",\"date_updated\": \"Tue, 31 Aug 2010 20:36:44 +0000\"}"
                                     ));

            var response = FeedbackSummaryResource.Create(MarshalConverter.DateTimeFromString("2008-01-02"), MarshalConverter.DateTimeFromString("2008-01-02"), client: twilioRestClient);
            Assert.NotNull(response);
        }

        [Test]
        public void TestFetchRequest()
        {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            var request = new Request(
                HttpMethod.Get,
                Twilio.Rest.Domain.Api,
                "/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Calls/FeedbackSummary/FSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa.json",
                ""
            );
            twilioRestClient.AccountSid.Returns("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
            twilioRestClient.Request(request).Throws(new ApiException("Server Error, no content"));

            try
            {
                FeedbackSummaryResource.Fetch("FSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", client: twilioRestClient);
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
                                         "{\"account_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"call_count\": 10200,\"call_feedback_count\": 729,\"end_date\": \"2011-01-01\",\"include_subaccounts\": false,\"issues\": [{\"count\": 45,\"description\": \"imperfect-audio\",\"percentage_of_total_calls\": \"0.04%\"}],\"quality_score_average\": 4.5,\"quality_score_median\": 4,\"quality_score_standard_deviation\": 1,\"sid\": \"FSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"start_date\": \"2011-01-01\",\"status\": \"completed\",\"date_created\": \"Tue, 31 Aug 2010 20:36:28 +0000\",\"date_updated\": \"Tue, 31 Aug 2010 20:36:44 +0000\"}"
                                     ));

            var response = FeedbackSummaryResource.Fetch("FSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", client: twilioRestClient);
            Assert.NotNull(response);
        }

        [Test]
        public void TestDeleteRequest()
        {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            var request = new Request(
                HttpMethod.Delete,
                Twilio.Rest.Domain.Api,
                "/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Calls/FeedbackSummary/FSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa.json",
                ""
            );
            twilioRestClient.AccountSid.Returns("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
            twilioRestClient.Request(request).Throws(new ApiException("Server Error, no content"));

            try
            {
                FeedbackSummaryResource.Delete("FSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", client: twilioRestClient);
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

            var response = FeedbackSummaryResource.Delete("FSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", client: twilioRestClient);
            Assert.NotNull(response);
        }
    }

}
using NSubstitute;
using NUnit.Framework;
using System;
using Twilio;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Resources.Api.V2010.Account.Call;

namespace Twilio.Tests.Api.V2010.Account.Call {

    [TestFixture]
    public class FeedbackSummaryTest : TwilioTest {
        [SetUp]
        public void SetUp() {
        }
    
        [Test]
        public void TestCreateResponse() {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            twilioRestClient.Request(Arg.Any<Request>())
                            .Returns(System.Threading.Tasks.Task.FromResult(
                                new Response(System.Net.HttpStatusCode.Created,
                                             "{\"account_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"call_count\": 10200,\"call_feedback_count\": 729,\"end_date\": \"2011-01-01\",\"include_subaccounts\": false,\"issues\": [{\"count\": 45,\"description\": \"imperfect-audio\",\"percentage_of_total_calls\": \"0.04%\"}],\"quality_score_average\": 4.5,\"quality_score_median\": 4,\"quality_score_standard_deviation\": 1,\"sid\": \"FSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"start_date\": \"2011-01-01\",\"status\": \"completed\",\"date_created\": \"Tue, 31 Aug 2010 20:36:28 +0000\",\"date_updated\": \"Tue, 31 Aug 2010 20:36:44 +0000\"}")));
            
            var task = FeedbackSummaryResource.Create("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", MarshalConverter.LocalDateFromString("2008-01-02"), MarshalConverter.LocalDateFromString("2008-01-02")).ExecuteAsync(twilioRestClient);
            task.Wait();
        }
    
        [Test]
        public void TestFetchResponse() {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            twilioRestClient.Request(Arg.Any<Request>())
                            .Returns(System.Threading.Tasks.Task.FromResult(
                                new Response(System.Net.HttpStatusCode.OK,
                                             "{\"account_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"call_count\": 10200,\"call_feedback_count\": 729,\"end_date\": \"2011-01-01\",\"include_subaccounts\": false,\"issues\": [{\"count\": 45,\"description\": \"imperfect-audio\",\"percentage_of_total_calls\": \"0.04%\"}],\"quality_score_average\": 4.5,\"quality_score_median\": 4,\"quality_score_standard_deviation\": 1,\"sid\": \"FSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"start_date\": \"2011-01-01\",\"status\": \"completed\",\"date_created\": \"Tue, 31 Aug 2010 20:36:28 +0000\",\"date_updated\": \"Tue, 31 Aug 2010 20:36:44 +0000\"}")));
            
            var task = FeedbackSummaryResource.Fetch("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "FSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").ExecuteAsync(twilioRestClient);
            task.Wait();
            Assert.NotNull(task.Result);
        }
    
        [Test]
        public void TestDeleteResponse() {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            twilioRestClient.Request(Arg.Any<Request>())
                            .Returns(System.Threading.Tasks.Task.FromResult(
                                new Response(System.Net.HttpStatusCode.NoContent,
                                             "null")));
            
            var task = FeedbackSummaryResource.Delete("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "FSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").ExecuteAsync(twilioRestClient);
            task.Wait();
        }
    }
}
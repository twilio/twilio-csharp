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
using Twilio.Rest.Api.V2010.Account.Conference;

namespace Twilio.Tests.Rest.Api.V2010.Account.Conference
{

    [TestFixture]
    public class ParticipantTest : TwilioTest
    {
        [Test]
        public void TestFetchRequest()
        {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            var request = new Request(
                HttpMethod.Get,
                Twilio.Rest.Domain.Api,
                "/2010-04-01/Accounts/ACXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX/Conferences/CFXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX/Participants/CAXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX.json",
                ""
            );
            twilioRestClient.AccountSid.Returns("ACXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");
            twilioRestClient.Request(request).Throws(new ApiException("Server Error, no content"));

            try
            {
                ParticipantResource.Fetch("CFXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX", "CAXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX", client: twilioRestClient);
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
                                         "{\"account_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"call_sid\": \"CAaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"label\": null,\"conference_sid\": \"CFaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"date_created\": \"Fri, 18 Feb 2011 21:07:19 +0000\",\"date_updated\": \"Fri, 18 Feb 2011 21:07:19 +0000\",\"end_conference_on_exit\": false,\"muted\": false,\"hold\": false,\"status\": \"complete\",\"start_conference_on_enter\": true,\"coaching\": true,\"call_sid_to_coach\": \"CFbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbb\",\"uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Conferences/CFaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Participants/CAaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa.json\"}"
                                     ));

            var response = ParticipantResource.Fetch("CFXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX", "CAXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX", client: twilioRestClient);
            Assert.NotNull(response);
        }

        [Test]
        public void TestFetchByLabelResponse()
        {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            twilioRestClient.AccountSid.Returns("ACXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");
            twilioRestClient.Request(Arg.Any<Request>())
                            .Returns(new Response(
                                         System.Net.HttpStatusCode.OK,
                                         "{\"account_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"call_sid\": \"CAaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"label\": \"customer\",\"conference_sid\": \"CFaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"date_created\": \"Fri, 18 Feb 2011 21:07:19 +0000\",\"date_updated\": \"Fri, 18 Feb 2011 21:07:19 +0000\",\"end_conference_on_exit\": false,\"muted\": false,\"hold\": false,\"status\": \"complete\",\"start_conference_on_enter\": true,\"coaching\": true,\"call_sid_to_coach\": \"CFbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbb\",\"uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Conferences/CFaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Participants/CAaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa.json\"}"
                                     ));

            var response = ParticipantResource.Fetch("CFXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX", "CAXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX", client: twilioRestClient);
            Assert.NotNull(response);
        }

        [Test]
        public void TestUpdateRequest()
        {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            var request = new Request(
                HttpMethod.Post,
                Twilio.Rest.Domain.Api,
                "/2010-04-01/Accounts/ACXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX/Conferences/CFXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX/Participants/CAXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX.json",
                ""
            );
            twilioRestClient.AccountSid.Returns("ACXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");
            twilioRestClient.Request(request).Throws(new ApiException("Server Error, no content"));

            try
            {
                ParticipantResource.Update("CFXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX", "CAXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX", client: twilioRestClient);
                Assert.Fail("Expected TwilioException to be thrown for 500");
            }
            catch (ApiException) {}
            twilioRestClient.Received().Request(request);
        }

        [Test]
        public void TestMuteParticipantResponse()
        {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            twilioRestClient.AccountSid.Returns("ACXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");
            twilioRestClient.Request(Arg.Any<Request>())
                            .Returns(new Response(
                                         System.Net.HttpStatusCode.OK,
                                         "{\"account_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"call_sid\": \"CAaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"label\": null,\"conference_sid\": \"CFaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"date_created\": \"Fri, 18 Feb 2011 21:07:19 +0000\",\"date_updated\": \"Fri, 18 Feb 2011 21:07:19 +0000\",\"end_conference_on_exit\": false,\"muted\": true,\"hold\": false,\"status\": \"complete\",\"start_conference_on_enter\": true,\"coaching\": false,\"call_sid_to_coach\": null,\"uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Conferences/CFaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Participants/CAaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa.json\"}"
                                     ));

            var response = ParticipantResource.Update("CFXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX", "CAXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX", client: twilioRestClient);
            Assert.NotNull(response);
        }

        [Test]
        public void TestMuteParticipantByLabelResponse()
        {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            twilioRestClient.AccountSid.Returns("ACXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");
            twilioRestClient.Request(Arg.Any<Request>())
                            .Returns(new Response(
                                         System.Net.HttpStatusCode.OK,
                                         "{\"account_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"call_sid\": \"CAaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"label\": \"customer\",\"conference_sid\": \"CFaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"date_created\": \"Fri, 18 Feb 2011 21:07:19 +0000\",\"date_updated\": \"Fri, 18 Feb 2011 21:07:19 +0000\",\"end_conference_on_exit\": false,\"muted\": true,\"hold\": false,\"status\": \"complete\",\"start_conference_on_enter\": true,\"coaching\": false,\"call_sid_to_coach\": null,\"uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Conferences/CFaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Participants/CAaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa.json\"}"
                                     ));

            var response = ParticipantResource.Update("CFXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX", "CAXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX", client: twilioRestClient);
            Assert.NotNull(response);
        }

        [Test]
        public void TestModifyParticipantResponse()
        {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            twilioRestClient.AccountSid.Returns("ACXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");
            twilioRestClient.Request(Arg.Any<Request>())
                            .Returns(new Response(
                                         System.Net.HttpStatusCode.OK,
                                         "{\"account_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"call_sid\": \"CAaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"label\": null,\"conference_sid\": \"CFaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"date_created\": \"Fri, 18 Feb 2011 21:07:19 +0000\",\"date_updated\": \"Fri, 18 Feb 2011 21:07:19 +0000\",\"end_conference_on_exit\": false,\"muted\": false,\"hold\": false,\"status\": \"complete\",\"start_conference_on_enter\": true,\"coaching\": true,\"call_sid_to_coach\": \"CFbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbb\",\"uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Conferences/CFaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Participants/CAaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa.json\"}"
                                     ));

            var response = ParticipantResource.Update("CFXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX", "CAXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX", client: twilioRestClient);
            Assert.NotNull(response);
        }

        [Test]
        public void TestModifyParticipantByLabelResponse()
        {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            twilioRestClient.AccountSid.Returns("ACXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");
            twilioRestClient.Request(Arg.Any<Request>())
                            .Returns(new Response(
                                         System.Net.HttpStatusCode.OK,
                                         "{\"account_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"call_sid\": \"CAaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"label\": \"customer\",\"conference_sid\": \"CFaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"date_created\": \"Fri, 18 Feb 2011 21:07:19 +0000\",\"date_updated\": \"Fri, 18 Feb 2011 21:07:19 +0000\",\"end_conference_on_exit\": false,\"muted\": false,\"hold\": false,\"status\": \"complete\",\"start_conference_on_enter\": true,\"coaching\": true,\"call_sid_to_coach\": \"CFbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbb\",\"uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Conferences/CFaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Participants/CAaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa.json\"}"
                                     ));

            var response = ParticipantResource.Update("CFXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX", "CAXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX", client: twilioRestClient);
            Assert.NotNull(response);
        }

        [Test]
        public void TestCreateRequest()
        {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            var request = new Request(
                HttpMethod.Post,
                Twilio.Rest.Domain.Api,
                "/2010-04-01/Accounts/ACXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX/Conferences/CFXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX/Participants.json",
                ""
            );
            request.AddPostParam("From", Serialize(new Twilio.Types.PhoneNumber("+15017122661")));
            request.AddPostParam("To", Serialize(new Twilio.Types.PhoneNumber("+15558675310")));
            twilioRestClient.AccountSid.Returns("ACXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");
            twilioRestClient.Request(request).Throws(new ApiException("Server Error, no content"));

            try
            {
                ParticipantResource.Create("CFXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX", new Twilio.Types.PhoneNumber("+15017122661"), new Twilio.Types.PhoneNumber("+15558675310"), client: twilioRestClient);
                Assert.Fail("Expected TwilioException to be thrown for 500");
            }
            catch (ApiException) {}
            twilioRestClient.Received().Request(request);
        }

        [Test]
        public void TestCreateWithSidResponse()
        {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            twilioRestClient.AccountSid.Returns("ACXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");
            twilioRestClient.Request(Arg.Any<Request>())
                            .Returns(new Response(
                                         System.Net.HttpStatusCode.Created,
                                         "{\"account_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"call_sid\": \"CAaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"label\": \"customer\",\"conference_sid\": \"CFaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"date_created\": \"Fri, 18 Feb 2011 21:07:19 +0000\",\"date_updated\": \"Fri, 18 Feb 2011 21:07:19 +0000\",\"end_conference_on_exit\": false,\"muted\": false,\"hold\": false,\"status\": \"complete\",\"start_conference_on_enter\": true,\"coaching\": false,\"call_sid_to_coach\": null,\"uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Conferences/CFaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Participants/CAaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa.json\"}"
                                     ));

            var response = ParticipantResource.Create("CFXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX", new Twilio.Types.PhoneNumber("+15017122661"), new Twilio.Types.PhoneNumber("+15558675310"), client: twilioRestClient);
            Assert.NotNull(response);
        }

        [Test]
        public void TestCreateWithFriendlyNameResponse()
        {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            twilioRestClient.AccountSid.Returns("ACXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");
            twilioRestClient.Request(Arg.Any<Request>())
                            .Returns(new Response(
                                         System.Net.HttpStatusCode.Created,
                                         "{\"account_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"call_sid\": \"CAaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"label\": \"customer\",\"conference_sid\": \"CFaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"date_created\": \"Fri, 18 Feb 2011 21:07:19 +0000\",\"date_updated\": \"Fri, 18 Feb 2011 21:07:19 +0000\",\"end_conference_on_exit\": false,\"muted\": false,\"hold\": false,\"status\": \"complete\",\"start_conference_on_enter\": true,\"coaching\": false,\"call_sid_to_coach\": null,\"uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Conferences/CFaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Participants/CAaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa.json\"}"
                                     ));

            var response = ParticipantResource.Create("CFXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX", new Twilio.Types.PhoneNumber("+15017122661"), new Twilio.Types.PhoneNumber("+15558675310"), client: twilioRestClient);
            Assert.NotNull(response);
        }

        [Test]
        public void TestCreateWithSidAsCoachResponse()
        {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            twilioRestClient.AccountSid.Returns("ACXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");
            twilioRestClient.Request(Arg.Any<Request>())
                            .Returns(new Response(
                                         System.Net.HttpStatusCode.Created,
                                         "{\"account_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"call_sid\": \"CAaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"label\": null,\"conference_sid\": \"CFaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"date_created\": \"Fri, 18 Feb 2011 21:07:19 +0000\",\"date_updated\": \"Fri, 18 Feb 2011 21:07:19 +0000\",\"end_conference_on_exit\": false,\"muted\": false,\"hold\": false,\"status\": \"queued\",\"start_conference_on_enter\": true,\"coaching\": false,\"call_sid_to_coach\": null,\"uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Conferences/CFaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Participants/CAaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa.json\"}"
                                     ));

            var response = ParticipantResource.Create("CFXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX", new Twilio.Types.PhoneNumber("+15017122661"), new Twilio.Types.PhoneNumber("+15558675310"), client: twilioRestClient);
            Assert.NotNull(response);
        }

        [Test]
        public void TestCreateWithNonE164NumberResponse()
        {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            twilioRestClient.AccountSid.Returns("ACXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");
            twilioRestClient.Request(Arg.Any<Request>())
                            .Returns(new Response(
                                         System.Net.HttpStatusCode.Created,
                                         "{\"account_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"call_sid\": \"CAaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"label\": null,\"conference_sid\": \"CFaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"date_created\": \"Fri, 18 Feb 2011 21:07:19 +0000\",\"date_updated\": \"Fri, 18 Feb 2011 21:07:19 +0000\",\"end_conference_on_exit\": false,\"muted\": false,\"hold\": false,\"status\": \"complete\",\"start_conference_on_enter\": true,\"coaching\": false,\"call_sid_to_coach\": null,\"uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Conferences/CFaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Participants/CAaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa.json\"}"
                                     ));

            var response = ParticipantResource.Create("CFXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX", new Twilio.Types.PhoneNumber("+15017122661"), new Twilio.Types.PhoneNumber("+15558675310"), client: twilioRestClient);
            Assert.NotNull(response);
        }

        [Test]
        public void TestCreateWithFriendlyNameJitterBufferSizeResponse()
        {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            twilioRestClient.AccountSid.Returns("ACXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");
            twilioRestClient.Request(Arg.Any<Request>())
                            .Returns(new Response(
                                         System.Net.HttpStatusCode.Created,
                                         "{\"account_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"call_sid\": \"CAaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"label\": null,\"conference_sid\": \"CFaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"date_created\": \"Fri, 18 Feb 2011 21:07:19 +0000\",\"date_updated\": \"Fri, 18 Feb 2011 21:07:19 +0000\",\"end_conference_on_exit\": false,\"muted\": false,\"hold\": false,\"status\": \"complete\",\"start_conference_on_enter\": true,\"coaching\": false,\"call_sid_to_coach\": null,\"uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Conferences/CFaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Participants/CAaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa.json\"}"
                                     ));

            var response = ParticipantResource.Create("CFXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX", new Twilio.Types.PhoneNumber("+15017122661"), new Twilio.Types.PhoneNumber("+15558675310"), client: twilioRestClient);
            Assert.NotNull(response);
        }

        [Test]
        public void TestCreateWithFriendlyNameByocResponse()
        {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            twilioRestClient.AccountSid.Returns("ACXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");
            twilioRestClient.Request(Arg.Any<Request>())
                            .Returns(new Response(
                                         System.Net.HttpStatusCode.Created,
                                         "{\"account_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"call_sid\": \"CAaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"label\": null,\"conference_sid\": \"CFaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"date_created\": \"Fri, 18 Feb 2011 21:07:19 +0000\",\"date_updated\": \"Fri, 18 Feb 2011 21:07:19 +0000\",\"end_conference_on_exit\": false,\"muted\": false,\"hold\": false,\"status\": \"complete\",\"start_conference_on_enter\": true,\"coaching\": false,\"call_sid_to_coach\": null,\"uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Conferences/CFaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Participants/CAaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa.json\"}"
                                     ));

            var response = ParticipantResource.Create("CFXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX", new Twilio.Types.PhoneNumber("+15017122661"), new Twilio.Types.PhoneNumber("+15558675310"), client: twilioRestClient);
            Assert.NotNull(response);
        }

        [Test]
        public void TestCreateWithFriendlyNameCallerIdResponse()
        {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            twilioRestClient.AccountSid.Returns("ACXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");
            twilioRestClient.Request(Arg.Any<Request>())
                            .Returns(new Response(
                                         System.Net.HttpStatusCode.Created,
                                         "{\"account_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"call_sid\": \"CAaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"conference_sid\": \"CFaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"date_created\": \"Fri, 18 Feb 2011 21:07:19 +0000\",\"date_updated\": \"Fri, 18 Feb 2011 21:07:19 +0000\",\"end_conference_on_exit\": false,\"muted\": false,\"hold\": false,\"status\": \"complete\",\"start_conference_on_enter\": true,\"coaching\": false,\"call_sid_to_coach\": null,\"label\": null,\"uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Conferences/CFaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Participants/CAaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa.json\"}"
                                     ));

            var response = ParticipantResource.Create("CFXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX", new Twilio.Types.PhoneNumber("+15017122661"), new Twilio.Types.PhoneNumber("+15558675310"), client: twilioRestClient);
            Assert.NotNull(response);
        }

        [Test]
        public void TestCreateWithFriendlyNameReasonResponse()
        {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            twilioRestClient.AccountSid.Returns("ACXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");
            twilioRestClient.Request(Arg.Any<Request>())
                            .Returns(new Response(
                                         System.Net.HttpStatusCode.Created,
                                         "{\"account_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"call_sid\": \"CAaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"label\": null,\"conference_sid\": \"CFaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"date_created\": \"Fri, 18 Feb 2011 21:07:19 +0000\",\"date_updated\": \"Fri, 18 Feb 2011 21:07:19 +0000\",\"end_conference_on_exit\": false,\"muted\": false,\"hold\": false,\"status\": \"complete\",\"start_conference_on_enter\": true,\"coaching\": false,\"call_sid_to_coach\": null,\"uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Conferences/CFaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Participants/CAaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa.json\"}"
                                     ));

            var response = ParticipantResource.Create("CFXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX", new Twilio.Types.PhoneNumber("+15017122661"), new Twilio.Types.PhoneNumber("+15558675310"), client: twilioRestClient);
            Assert.NotNull(response);
        }

        [Test]
        public void TestCreateWithFriendlyNameRecordingTrackResponse()
        {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            twilioRestClient.AccountSid.Returns("ACXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");
            twilioRestClient.Request(Arg.Any<Request>())
                            .Returns(new Response(
                                         System.Net.HttpStatusCode.Created,
                                         "{\"account_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"call_sid\": \"CAaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"label\": null,\"conference_sid\": \"CFaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"date_created\": \"Fri, 18 Feb 2011 21:07:19 +0000\",\"date_updated\": \"Fri, 18 Feb 2011 21:07:19 +0000\",\"end_conference_on_exit\": false,\"muted\": false,\"hold\": false,\"status\": \"complete\",\"start_conference_on_enter\": true,\"coaching\": false,\"call_sid_to_coach\": null,\"uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Conferences/CFaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Participants/CAaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa.json\"}"
                                     ));

            var response = ParticipantResource.Create("CFXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX", new Twilio.Types.PhoneNumber("+15017122661"), new Twilio.Types.PhoneNumber("+15558675310"), client: twilioRestClient);
            Assert.NotNull(response);
        }

        [Test]
        public void TestCreateWithFromToClientResponse()
        {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            twilioRestClient.AccountSid.Returns("ACXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");
            twilioRestClient.Request(Arg.Any<Request>())
                            .Returns(new Response(
                                         System.Net.HttpStatusCode.Created,
                                         "{\"account_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"call_sid\": \"CAaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"label\": \"customer\",\"conference_sid\": \"CFaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"date_created\": \"Fri, 18 Feb 2011 21:07:19 +0000\",\"date_updated\": \"Fri, 18 Feb 2011 21:07:19 +0000\",\"end_conference_on_exit\": false,\"muted\": false,\"hold\": false,\"status\": \"complete\",\"start_conference_on_enter\": true,\"coaching\": false,\"call_sid_to_coach\": null,\"uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Conferences/CFaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Participants/CAaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa.json\"}"
                                     ));

            var response = ParticipantResource.Create("CFXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX", new Twilio.Types.PhoneNumber("+15017122661"), new Twilio.Types.PhoneNumber("+15558675310"), client: twilioRestClient);
            Assert.NotNull(response);
        }

        [Test]
        public void TestCreateWithFromToSipResponse()
        {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            twilioRestClient.AccountSid.Returns("ACXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");
            twilioRestClient.Request(Arg.Any<Request>())
                            .Returns(new Response(
                                         System.Net.HttpStatusCode.Created,
                                         "{\"account_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"call_sid\": \"CAaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"label\": \"customer\",\"conference_sid\": \"CFaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"date_created\": \"Fri, 18 Feb 2011 21:07:19 +0000\",\"date_updated\": \"Fri, 18 Feb 2011 21:07:19 +0000\",\"end_conference_on_exit\": false,\"muted\": false,\"hold\": false,\"status\": \"complete\",\"start_conference_on_enter\": true,\"coaching\": false,\"call_sid_to_coach\": null,\"uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Conferences/CFaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Participants/CAaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa.json\"}"
                                     ));

            var response = ParticipantResource.Create("CFXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX", new Twilio.Types.PhoneNumber("+15017122661"), new Twilio.Types.PhoneNumber("+15558675310"), client: twilioRestClient);
            Assert.NotNull(response);
        }

        [Test]
        public void TestDeleteRequest()
        {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            var request = new Request(
                HttpMethod.Delete,
                Twilio.Rest.Domain.Api,
                "/2010-04-01/Accounts/ACXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX/Conferences/CFXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX/Participants/CAXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX.json",
                ""
            );
            twilioRestClient.AccountSid.Returns("ACXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");
            twilioRestClient.Request(request).Throws(new ApiException("Server Error, no content"));

            try
            {
                ParticipantResource.Delete("CFXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX", "CAXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX", client: twilioRestClient);
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

            var response = ParticipantResource.Delete("CFXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX", "CAXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX", client: twilioRestClient);
            Assert.NotNull(response);
        }

        [Test]
        public void TestDeleteByLabelResponse()
        {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            twilioRestClient.AccountSid.Returns("ACXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");
            twilioRestClient.Request(Arg.Any<Request>())
                            .Returns(new Response(
                                         System.Net.HttpStatusCode.NoContent,
                                         "null"
                                     ));

            var response = ParticipantResource.Delete("CFXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX", "CAXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX", client: twilioRestClient);
            Assert.NotNull(response);
        }

        [Test]
        public void TestReadRequest()
        {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            var request = new Request(
                HttpMethod.Get,
                Twilio.Rest.Domain.Api,
                "/2010-04-01/Accounts/ACXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX/Conferences/CFXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX/Participants.json",
                ""
            );
            twilioRestClient.AccountSid.Returns("ACXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");
            twilioRestClient.Request(request).Throws(new ApiException("Server Error, no content"));

            try
            {
                ParticipantResource.Read("CFXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX", client: twilioRestClient);
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
                                         "{\"participants\": [],\"first_page_uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Conferences/CFaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Participants.json?Hold=True&PageSize=50&Page=0\",\"next_page_uri\": null,\"previous_page_uri\": null,\"uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Conferences/CFaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Participants.json?Hold=True&PageSize=50&Page=0\",\"page\": 0,\"page_size\": 50,\"end\": 0,\"start\": 0}"
                                     ));

            var response = ParticipantResource.Read("CFXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX", client: twilioRestClient);
            Assert.NotNull(response);
        }

        [Test]
        public void TestReadFullResponse()
        {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            twilioRestClient.AccountSid.Returns("ACXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");
            twilioRestClient.Request(Arg.Any<Request>())
                            .Returns(new Response(
                                         System.Net.HttpStatusCode.OK,
                                         "{\"participants\": [{\"account_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"call_sid\": \"CAaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"label\": null,\"conference_sid\": \"CFaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"date_created\": \"Sat, 19 Feb 2011 21:07:19 +0000\",\"date_updated\": \"Sat, 19 Feb 2011 21:07:19 +0000\",\"end_conference_on_exit\": false,\"muted\": true,\"hold\": false,\"status\": \"connected\",\"start_conference_on_enter\": true,\"coaching\": true,\"call_sid_to_coach\": \"CFbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbb\",\"uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Conferences/CFaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Participants/CAaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa.json\"},{\"account_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"call_sid\": \"CAbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbb\",\"label\": null,\"conference_sid\": \"CFaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"date_created\": \"Fri, 18 Feb 2011 21:07:19 +0000\",\"date_updated\": \"Fri, 18 Feb 2011 21:07:19 +0000\",\"end_conference_on_exit\": false,\"muted\": true,\"hold\": false,\"status\": \"connected\",\"start_conference_on_enter\": true,\"coaching\": false,\"call_sid_to_coach\": null,\"uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Conferences/CFaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Participants/CAbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbb.json\"}],\"first_page_uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Conferences/CFaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Participants.json?Muted=true&PageSize=2&Page=0\",\"next_page_uri\": null,\"previous_page_uri\": null,\"uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Conferences/CFaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Participants.json?Muted=true&PageSize=2&Page=0\",\"page\": 0,\"page_size\": 2,\"start\": 0,\"end\": 1}"
                                     ));

            var response = ParticipantResource.Read("CFXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX", client: twilioRestClient);
            Assert.NotNull(response);
        }

        [Test]
        public void TestReadNextResponse()
        {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            twilioRestClient.AccountSid.Returns("ACXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");
            twilioRestClient.Request(Arg.Any<Request>())
                            .Returns(new Response(
                                         System.Net.HttpStatusCode.OK,
                                         "{\"participants\": [{\"account_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"call_sid\": \"CAcccccccccccccccccccccccccccccccc\",\"label\": null,\"conference_sid\": \"CFaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"date_created\": \"Thu, 17 Feb 2011 21:07:19 +0000\",\"date_updated\": \"Thu, 17 Feb 2011 21:07:19 +0000\",\"end_conference_on_exit\": false,\"muted\": true,\"hold\": false,\"status\": \"connected\",\"start_conference_on_enter\": true,\"coaching\": false,\"call_sid_to_coach\": null,\"uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Conferences/CFaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Participants/CAcccccccccccccccccccccccccccccccc.json\"},{\"account_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"call_sid\": \"CAdddddddddddddddddddddddddddddddd\",\"label\": null,\"conference_sid\": \"CFaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"date_created\": \"Wed, 16 Feb 2011 21:07:19 +0000\",\"date_updated\": \"Wed, 16 Feb 2011 21:07:19 +0000\",\"end_conference_on_exit\": false,\"muted\": true,\"hold\": false,\"status\": \"connected\",\"start_conference_on_enter\": true,\"coaching\": false,\"call_sid_to_coach\": null,\"uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Conferences/CFaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Participants/CAdddddddddddddddddddddddddddddddd.json\"}],\"first_page_uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Conferences/CFaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Participants.json?Muted=true&PageSize=2&Page=0\",\"next_page_uri\": null,\"previous_page_uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Conferences/CFaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Participants.json?Muted=true&PageSize=2&Page=0&PageToken=PBCPcccccccccccccccccccccccccccccccc\",\"uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Conferences/CFaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Participants.json?Muted=true&PageSize=2&Page=1&PageToken=PACPbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbb\",\"page\": 1,\"page_size\": 2,\"start\": 2,\"end\": 3}"
                                     ));

            var response = ParticipantResource.Read("CFXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX", client: twilioRestClient);
            Assert.NotNull(response);
        }

        [Test]
        public void TestReadPreviousResponse()
        {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            twilioRestClient.AccountSid.Returns("ACXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");
            twilioRestClient.Request(Arg.Any<Request>())
                            .Returns(new Response(
                                         System.Net.HttpStatusCode.OK,
                                         "{\"participants\": [{\"account_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"call_sid\": \"CAaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"label\": null,\"conference_sid\": \"CFaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"date_created\": \"Sat, 19 Feb 2011 21:07:19 +0000\",\"date_updated\": \"Sat, 19 Feb 2011 21:07:19 +0000\",\"end_conference_on_exit\": false,\"muted\": true,\"hold\": false,\"status\": \"connected\",\"start_conference_on_enter\": true,\"coaching\": true,\"call_sid_to_coach\": \"CFbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbb\",\"uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Conferences/CFaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Participants/CAaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa.json\"},{\"account_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"call_sid\": \"CAbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbb\",\"label\": null,\"conference_sid\": \"CFaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"date_created\": \"Fri, 18 Feb 2011 21:07:19 +0000\",\"date_updated\": \"Fri, 18 Feb 2011 21:07:19 +0000\",\"end_conference_on_exit\": false,\"muted\": true,\"hold\": false,\"status\": \"connected\",\"start_conference_on_enter\": true,\"coaching\": false,\"call_sid_to_coach\": null,\"uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Conferences/CFaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Participants/CAbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbb.json\"}],\"first_page_uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Conferences/CFaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Participants.json?Muted=true&PageSize=2&Page=0\",\"next_page_uri\": null,\"previous_page_uri\": null,\"uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Conferences/CFaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Participants.json?Muted=true&PageSize=2&Page=0&PageToken=PBCPcccccccccccccccccccccccccccccccc\",\"page\": 0,\"page_size\": 2,\"start\": 0,\"end\": 1}"
                                     ));

            var response = ParticipantResource.Read("CFXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX", client: twilioRestClient);
            Assert.NotNull(response);
        }
    }

}
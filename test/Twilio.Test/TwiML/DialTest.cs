/// This code was generated by
/// \ / _    _  _|   _  _
///  | (_)\/(_)(_|\/| |(/_  v1.0.0
///       /       /

using NUnit.Framework;
using System;
using Twilio.Converters;
using Twilio.TwiML.Voice;

namespace Twilio.Tests.TwiML
{

    [TestFixture]
    public class DialTest : TwilioTest
    {
        [Test]
        public void TestEmptyElement()
        {
            var elem = new Dial();

            Assert.AreEqual(
                "<?xml version=\"1.0\" encoding=\"utf-8\"?>" + Environment.NewLine +
                "<Dial></Dial>",
                elem.ToString()
            );
        }

        [Test]
        public void TestElementWithParams()
        {
            var elem = new Dial(
                "number",
                new Uri("https://example.com"),
                Twilio.Http.HttpMethod.Get,
                1,
                true,
                1,
                "caller_id",
                Dial.RecordEnum.DoNotRecord,
                Dial.TrimEnum.TrimSilence,
                new Uri("https://example.com"),
                Twilio.Http.HttpMethod.Get,
                Promoter.ListOfOne(Dial.RecordingEventEnum.InProgress),
                true,
                Dial.RingToneEnum.At,
                Dial.RecordingTrackEnum.Both
            );
            Assert.AreEqual(
                "<?xml version=\"1.0\" encoding=\"utf-8\"?>" + Environment.NewLine +
                "<Dial action=\"https://example.com\" method=\"GET\" timeout=\"1\" hangupOnStar=\"true\" timeLimit=\"1\" callerId=\"caller_id\" record=\"do-not-record\" trim=\"trim-silence\" recordingStatusCallback=\"https://example.com\" recordingStatusCallbackMethod=\"GET\" recordingStatusCallbackEvent=\"in-progress\" answerOnBridge=\"true\" ringTone=\"at\" recordingTrack=\"both\">number</Dial>",
                elem.ToString()
            );
        }

        [Test]
        public void TestElementWithExtraAttributes()
        {
            var elem = new Dial();
            elem.SetOption("newParam1", "value");
            elem.SetOption("newParam2", 1);

            Assert.AreEqual(
                "<?xml version=\"1.0\" encoding=\"utf-8\"?>" + Environment.NewLine +
                "<Dial newParam1=\"value\" newParam2=\"1\"></Dial>",
                elem.ToString()
            );
        }

        [Test]
        public void TestNestElement()
        {
            var elem = new Dial();
            var child = new Client();
            elem.Nest(child).Identity();

            Assert.AreEqual(
                "<?xml version=\"1.0\" encoding=\"utf-8\"?>" + Environment.NewLine +
                "<Dial>" + Environment.NewLine +
                "  <Client>" + Environment.NewLine +
                "    <Identity></Identity>" + Environment.NewLine +
                "  </Client>" + Environment.NewLine +
                "</Dial>",
                elem.ToString()
            );
        }

        [Test]
        public void TestElementWithChildren()
        {
            var elem = new Dial();

            elem.Client(
                "identity",
                new Uri("https://example.com"),
                Twilio.Http.HttpMethod.Get,
                Promoter.ListOfOne(Client.EventEnum.Initiated),
                new Uri("https://example.com"),
                Twilio.Http.HttpMethod.Get
            );

            elem.Conference(
                "name",
                true,
                Conference.BeepEnum.True,
                true,
                true,
                new Uri("https://example.com"),
                Twilio.Http.HttpMethod.Get,
                1,
                Conference.RecordEnum.DoNotRecord,
                Conference.RegionEnum.Us1,
                "CAXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX",
                Conference.TrimEnum.TrimSilence,
                Promoter.ListOfOne(Conference.EventEnum.Start),
                new Uri("https://example.com"),
                Twilio.Http.HttpMethod.Get,
                new Uri("https://example.com"),
                Twilio.Http.HttpMethod.Get,
                Promoter.ListOfOne(Conference.RecordingEventEnum.InProgress),
                new Uri("https://example.com"),
                Conference.JitterBufferSizeEnum.Large,
                "participant_label"
            );

            elem.Number(
                new Twilio.Types.PhoneNumber("+15017122661"),
                "send_digits",
                new Uri("https://example.com"),
                Twilio.Http.HttpMethod.Get,
                Promoter.ListOfOne(Number.EventEnum.Initiated),
                new Uri("https://example.com"),
                Twilio.Http.HttpMethod.Get,
                "BYXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX"
            );

            elem.Queue(
                "name",
                new Uri("https://example.com"),
                Twilio.Http.HttpMethod.Get,
                "reservation_sid",
                "post_work_activity_sid"
            );

            elem.Sim("DEXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");

            elem.Sip(
                new Uri("https://example.com"),
                "username",
                "password",
                new Uri("https://example.com"),
                Twilio.Http.HttpMethod.Get,
                Promoter.ListOfOne(Sip.EventEnum.Initiated),
                new Uri("https://example.com"),
                Twilio.Http.HttpMethod.Get
            );

            Assert.AreEqual(
                "<?xml version=\"1.0\" encoding=\"utf-8\"?>" + Environment.NewLine +
                "<Dial>" + Environment.NewLine +
                "  <Client url=\"https://example.com\" method=\"GET\" statusCallbackEvent=\"initiated\" statusCallback=\"https://example.com\" statusCallbackMethod=\"GET\">identity</Client>" + Environment.NewLine +
                "  <Conference muted=\"true\" beep=\"true\" startConferenceOnEnter=\"true\" endConferenceOnExit=\"true\" waitUrl=\"https://example.com\" waitMethod=\"GET\" maxParticipants=\"1\" record=\"do-not-record\" region=\"us1\" coach=\"CAXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX\" trim=\"trim-silence\" statusCallbackEvent=\"start\" statusCallback=\"https://example.com\" statusCallbackMethod=\"GET\" recordingStatusCallback=\"https://example.com\" recordingStatusCallbackMethod=\"GET\" recordingStatusCallbackEvent=\"in-progress\" eventCallbackUrl=\"https://example.com\" jitterBufferSize=\"large\" participantLabel=\"participant_label\">name</Conference>" + Environment.NewLine +
                "  <Number sendDigits=\"send_digits\" url=\"https://example.com\" method=\"GET\" statusCallbackEvent=\"initiated\" statusCallback=\"https://example.com\" statusCallbackMethod=\"GET\" byoc=\"BYXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX\">+15017122661</Number>" + Environment.NewLine +
                "  <Queue url=\"https://example.com\" method=\"GET\" reservationSid=\"reservation_sid\" postWorkActivitySid=\"post_work_activity_sid\">name</Queue>" + Environment.NewLine +
                "  <Sim>DEXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX</Sim>" + Environment.NewLine +
                "  <Sip username=\"username\" password=\"password\" url=\"https://example.com\" method=\"GET\" statusCallbackEvent=\"initiated\" statusCallback=\"https://example.com\" statusCallbackMethod=\"GET\">https://example.com</Sip>" + Environment.NewLine +
                "</Dial>",
                elem.ToString()
            );
        }

        [Test]
        public void TestElementWithTextNode()
        {
            var elem = new Dial();

            elem.AddText("Here is the content");

            Assert.AreEqual(
                "<?xml version=\"1.0\" encoding=\"utf-8\"?>" + Environment.NewLine +
                "<Dial>Here is the content</Dial>",
                elem.ToString()
            );
        }

        [Test]
        public void TestAllowGenericChildNodes()
        {
            var elem = new Dial();
            elem.AddChild("generic-tag").AddText("Content").SetOption("tag", true);

            Assert.AreEqual(
                "<?xml version=\"1.0\" encoding=\"utf-8\"?>" + Environment.NewLine +
                "<Dial>" + Environment.NewLine +
                "  <generic-tag tag=\"True\">Content</generic-tag>" + Environment.NewLine +
                "</Dial>",
                elem.ToString()
            );
        }

        [Test]
        public void TestAllowGenericChildrenOfChildNodes()
        {
            var elem = new Dial();
            var child = new Client();
            elem.Nest(child).AddChild("generic-tag").SetOption("tag", true).AddText("Content");

            Assert.AreEqual(
                "<?xml version=\"1.0\" encoding=\"utf-8\"?>" + Environment.NewLine +
                "<Dial>" + Environment.NewLine +
                "  <Client>" + Environment.NewLine +
                "    <generic-tag tag=\"True\">Content</generic-tag>" + Environment.NewLine +
                "  </Client>" + Environment.NewLine +
                "</Dial>",
                elem.ToString()
            );
        }

        [Test]
        public void TestMixedContent()
        {
            var elem = new Dial();
            elem.AddText("before")
                .AddChild("Child").AddText("content");
            elem.AddText("after");

            Assert.AreEqual(
                "<?xml version=\"1.0\" encoding=\"utf-8\"?>" + Environment.NewLine +
                "<Dial>before<Child>content</Child>after</Dial>",
                elem.ToString()
            );
        }
    }

}
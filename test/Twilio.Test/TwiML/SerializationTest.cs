using NUnit.Framework;
using System;
using System.IO;
using System.Threading;
using System.Xml.Linq;
using Twilio.Converters;
using Twilio.TwiML;
using Twilio.TwiML.Voice;

namespace Twilio.Tests.TwiML
{
    [TestFixture]
    public class SerializationTest : TwilioTest
    {
        private Twilio.TwiML.TwiML twiml;
        private string twimlOutput;

        public SerializationTest()
        {
            var elem = new VoiceResponse();

            elem.Connect(new Uri("https://example.com"), Twilio.Http.HttpMethod.Get);

            elem.Dial(
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
                Dial.RecordingTrackEnum.Both,
                true,
                new Uri("https://example.com"),
                Twilio.Http.HttpMethod.Get
            );

            elem.Echo();

            elem.Enqueue(
                "name",
                new Uri("https://example.com"),
                1,
                Twilio.Http.HttpMethod.Get,
                new Uri("https://example.com"),
                Twilio.Http.HttpMethod.Get,
                "workflow_sid"
            );

            elem.Gather(
                Promoter.ListOfOne(Gather.InputEnum.Dtmf),
                new Uri("https://example.com"),
                Twilio.Http.HttpMethod.Get,
                1,
                "speech_timeout",
                1,
                true,
                "finish_on_key",
                1,
                new Uri("https://example.com"),
                Twilio.Http.HttpMethod.Get,
                Gather.LanguageEnum.AfZa,
                "hints",
                true,
                true,
                true,
                Gather.SpeechModelEnum.Default,
                true
            );

            elem.Hangup();

            elem.Leave();

            elem.Pause(1);

            elem.Play(new Uri("https://example.com"), 1, "digits");

            elem.Queue(
                "name",
                new Uri("https://example.com"),
                Twilio.Http.HttpMethod.Get,
                "reservation_sid",
                "post_work_activity_sid"
            );

            elem.Record(
                new Uri("https://example.com"),
                Twilio.Http.HttpMethod.Get,
                1,
                "finish_on_key",
                1,
                true,
                Record.TrimEnum.TrimSilence,
                new Uri("https://example.com"),
                Twilio.Http.HttpMethod.Get,
                Promoter.ListOfOne(Record.RecordingEventEnum.InProgress),
                true,
                new Uri("https://example.com")
            );

            elem.Redirect(new Uri("https://example.com"), Twilio.Http.HttpMethod.Get);

            elem.Reject(Reject.ReasonEnum.Rejected);

            elem.Say("message", Say.VoiceEnum.Man, 1, Say.LanguageEnum.Arb);

            elem.Sms(
                "message",
                new Twilio.Types.PhoneNumber("+15558675310"),
                new Twilio.Types.PhoneNumber("+15017122661"),
                new Uri("https://example.com"),
                Twilio.Http.HttpMethod.Get,
                new Uri("https://example.com")
            );

            elem.Pay(
                Pay.InputEnum.Dtmf,
                new Uri("https://example.com"),
                Pay.BankAccountTypeEnum.ConsumerChecking,
                new Uri("https://example.com"),
                Pay.StatusCallbackMethodEnum.Get,
                1,
                1,
                true,
                "postal_code",
                1,
                "payment_connector",
                Pay.PaymentMethodEnum.AchDebit,
                Pay.TokenTypeEnum.OneTime,
                "charge_amount",
                "currency",
                "description",
                Promoter.ListOfOne(Pay.ValidCardTypesEnum.Visa),
                Pay.LanguageEnum.DeDe
            );

            elem.Prompt(
                Prompt.ForEnum.PaymentCardNumber,
                Promoter.ListOfOne(Prompt.ErrorTypeEnum.Timeout),
                Promoter.ListOfOne(Prompt.CardTypeEnum.Visa),
                Promoter.ListOfOne(1),
                true
            );

            elem.Start(new Uri("https://example.com"), Twilio.Http.HttpMethod.Get);

            elem.Stop();

            elem.Refer(new Uri("https://example.com"), Twilio.Http.HttpMethod.Get);

            twiml = elem;

            twimlOutput = "<?xml version=\"1.0\" encoding=\"utf-8\"?>" + Environment.NewLine +
                          "<Response>" + Environment.NewLine +
                          "  <Connect action=\"https://example.com\" method=\"GET\" />" + Environment.NewLine +
                          "  <Dial action=\"https://example.com\" method=\"GET\" timeout=\"1\" hangupOnStar=\"true\" timeLimit=\"1\" callerId=\"caller_id\" record=\"do-not-record\" trim=\"trim-silence\" recordingStatusCallback=\"https://example.com\" recordingStatusCallbackMethod=\"GET\" recordingStatusCallbackEvent=\"in-progress\" answerOnBridge=\"true\" ringTone=\"at\" recordingTrack=\"both\" sequential=\"true\" referUrl=\"https://example.com\" referMethod=\"GET\">number</Dial>" +
                          Environment.NewLine +
                          "  <Echo />" + Environment.NewLine +
                          "  <Enqueue action=\"https://example.com\" maxQueueSize=\"1\" method=\"GET\" waitUrl=\"https://example.com\" waitUrlMethod=\"GET\" workflowSid=\"workflow_sid\">name</Enqueue>" +
                          Environment.NewLine +
                          "  <Gather input=\"dtmf\" action=\"https://example.com\" method=\"GET\" timeout=\"1\" speechTimeout=\"speech_timeout\" maxSpeechTime=\"1\" profanityFilter=\"true\" finishOnKey=\"finish_on_key\" numDigits=\"1\" partialResultCallback=\"https://example.com\" partialResultCallbackMethod=\"GET\" language=\"af-ZA\" hints=\"hints\" bargeIn=\"true\" debug=\"true\" actionOnEmptyResult=\"true\" speechModel=\"default\" enhanced=\"true\" />" +
                          Environment.NewLine +
                          "  <Hangup />" + Environment.NewLine +
                          "  <Leave />" + Environment.NewLine +
                          "  <Pause length=\"1\" />" + Environment.NewLine +
                          "  <Play loop=\"1\" digits=\"digits\">https://example.com</Play>" + Environment.NewLine +
                          "  <Queue url=\"https://example.com\" method=\"GET\" reservationSid=\"reservation_sid\" postWorkActivitySid=\"post_work_activity_sid\">name</Queue>" +
                          Environment.NewLine +
                          "  <Record action=\"https://example.com\" method=\"GET\" timeout=\"1\" finishOnKey=\"finish_on_key\" maxLength=\"1\" playBeep=\"true\" trim=\"trim-silence\" recordingStatusCallback=\"https://example.com\" recordingStatusCallbackMethod=\"GET\" recordingStatusCallbackEvent=\"in-progress\" transcribe=\"true\" transcribeCallback=\"https://example.com\" />" +
                          Environment.NewLine +
                          "  <Redirect method=\"GET\">https://example.com</Redirect>" + Environment.NewLine +
                          "  <Reject reason=\"rejected\" />" + Environment.NewLine +
                          "  <Say voice=\"man\" loop=\"1\" language=\"arb\">message</Say>" + Environment.NewLine +
                          "  <Sms to=\"+15558675310\" from=\"+15017122661\" action=\"https://example.com\" method=\"GET\" statusCallback=\"https://example.com\">message</Sms>" +
                          Environment.NewLine +
                          "  <Pay input=\"dtmf\" action=\"https://example.com\" bankAccountType=\"consumer-checking\" statusCallback=\"https://example.com\" statusCallbackMethod=\"GET\" timeout=\"1\" maxAttempts=\"1\" securityCode=\"true\" postalCode=\"postal_code\" minPostalCodeLength=\"1\" paymentConnector=\"payment_connector\" paymentMethod=\"ach-debit\" tokenType=\"one-time\" chargeAmount=\"charge_amount\" currency=\"currency\" description=\"description\" validCardTypes=\"visa\" language=\"de-DE\" />" +
                          Environment.NewLine +
                          "  <Prompt for=\"payment-card-number\" errorType=\"timeout\" cardType=\"visa\" attempt=\"1\" requireMatchingInputs=\"true\" />" +
                          Environment.NewLine +
                          "  <Start action=\"https://example.com\" method=\"GET\" />" + Environment.NewLine +
                          "  <Stop />" + Environment.NewLine +
                          "  <Refer action=\"https://example.com\" method=\"GET\" />" + Environment.NewLine +
                          "</Response>";
        }

        [Test]
        public void TestSaveStream()
        {
            string output;
            using (var memoryStream = new MemoryStream())
            {
                twiml.Save(memoryStream);
                memoryStream.Seek(0, SeekOrigin.Begin);
                using (var reader = new StreamReader(memoryStream))
                {
                    output = reader.ReadToEnd();
                }
            }

            Assert.AreEqual(twimlOutput, output);
        }

        [Test]
        public void TestSaveTextWriter()
        {
            string output;
            using (var writer = new Utf8StringWriter())
            {
                twiml.Save(writer);
                output = writer.ToString();
            }

            Assert.AreEqual(twimlOutput, output);
        }

#if !NET35
        [Test]
        public async System.Threading.Tasks.Task TestSaveAsyncStream()
        {
            string output;
            using (var memoryStream = new MemoryStream())
            {
                await twiml.SaveAsync(memoryStream, CancellationToken.None);
                memoryStream.Seek(0, SeekOrigin.Begin);
                using (var reader = new StreamReader(memoryStream))
                {
                    output = await reader.ReadToEndAsync();
                }
            }
            
            Assert.AreEqual(twimlOutput, output);
        }
        
        [Test]
        public async System.Threading.Tasks.Task TestSaveAsyncTextWriter()
        {
            string output;
            using (var writer = new Utf8StringWriter())
            {
                await twiml.SaveAsync(writer, CancellationToken.None);
                output = writer.ToString();
            }
            
            Assert.AreEqual(twimlOutput, output);
        }
#endif
    }
}
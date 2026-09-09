using System.Net;
using Newtonsoft.Json.Linq;
using NSubstitute;
using NUnit.Framework;
using Twilio.Clients;
using Twilio.Http;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Rest.Memory.V1;
using Twilio.Rest.Messaging.V2;

namespace Twilio.Tests.Rest
{
    /// <summary>
    /// Forward compatibility of response models: the API can add fields, stop sending
    /// fields, or add new enum values underneath a pinned SDK version without breaking
    /// deserialization of the fields the SDK already knows about.
    ///
    /// Covers three shapes of generated response model:
    ///  - a flat (non-nested) response: MessageResource
    ///  - a deeply nested response: ChannelsSenderResource
    ///  - an operation-specific response with nested lists of objects: RecallCreateResource
    /// </summary>
    [TestFixture]
    public class ResponseForwardCompatibilityTest
    {
        private ITwilioRestClient _twilioRestClient;

        [SetUp]
        public void Init()
        {
            _twilioRestClient = Substitute.For<ITwilioRestClient>();
            _twilioRestClient.AccountSid.Returns("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
        }

        private void Mock(JToken payload, HttpStatusCode statusCode = HttpStatusCode.OK)
        {
            _twilioRestClient.Request(Arg.Any<Request>())
                .Returns(new Response(statusCode, payload.ToString()));
        }

        // ---------------------------------------------------------------
        // Flat response model: MessageResource
        // ---------------------------------------------------------------

        private static JObject BaseMessagePayload() => JObject.Parse(@"
        {
            ""account_sid"": ""ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa"",
            ""body"": ""Hello owl"",
            ""direction"": ""outbound-api"",
            ""error_code"": 30007,
            ""from"": ""+14155552345"",
            ""price"": ""-0.00750"",
            ""price_unit"": ""USD"",
            ""sid"": ""SMaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa"",
            ""status"": ""sent"",
            ""subresource_uris"": {
                ""media"": ""/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Messages/SMaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Media.json""
            },
            ""to"": ""+14155552345""
        }");

        [Test]
        public void TestFlatResponse_UnknownFieldIsIgnored()
        {
            var payload = BaseMessagePayload();
            payload["delivery_channel"] = "rcs";
            payload["engagement"] = JObject.Parse(@"{ ""clicks"": 3, ""links"": [{ ""url"": ""https://twilio.com"" }] }");

            Mock(payload);
            var message = MessageResource.Fetch("SMaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", client: _twilioRestClient);

            Assert.AreEqual("SMaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", message.Sid);
            Assert.AreEqual("Hello owl", message.Body);
            Assert.AreEqual(MessageResource.StatusEnum.Sent, message.Status);
        }

        [Test]
        public void TestFlatResponse_RemovedFieldDeserializesToNull()
        {
            var payload = BaseMessagePayload();
            payload.Remove("body");
            payload.Remove("status");
            payload.Remove("subresource_uris");

            Mock(payload);
            var message = MessageResource.Fetch("SMaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", client: _twilioRestClient);

            Assert.IsNull(message.Body);
            Assert.IsNull(message.Status);
            Assert.IsNull(message.SubresourceUris);
            Assert.AreEqual("SMaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", message.Sid);
        }

        [Test]
        public void TestFlatResponse_UnknownEnumValueIsPreserved()
        {
            var payload = BaseMessagePayload();
            payload["status"] = "eagerly_delivered";

            Mock(payload);
            var message = MessageResource.Fetch("SMaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", client: _twilioRestClient);

            Assert.AreEqual("eagerly_delivered", message.Status.ToString());
            Assert.AreNotEqual(MessageResource.StatusEnum.Delivered, message.Status);
        }

        [Test]
        public void TestFlatResponse_EmptyBodyDeserializesToEmptyResource()
        {
            Mock(new JObject());
            var message = MessageResource.Fetch("SMaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", client: _twilioRestClient);

            Assert.IsNotNull(message);
            Assert.IsNull(message.Sid);
            Assert.IsNull(message.Status);
        }

        // ---------------------------------------------------------------
        // Nested response model: ChannelsSenderResource
        // ---------------------------------------------------------------

        private static JObject BaseSenderPayload() => JObject.Parse(@"
        {
            ""sid"": ""XEaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa"",
            ""status"": ""ONLINE"",
            ""configuration"": {
                ""waba_id"": ""1234567890"",
                ""verification_method"": ""sms""
            },
            ""profile"": { ""name"": ""Owl Shop"" },
            ""offline_reasons"": [
                { ""code"": ""63024"", ""message"": ""Sender is offline"" }
            ],
            ""compliance"": {
                ""countries"": [
                    {
                        ""country"": ""US"",
                        ""status"": ""ONLINE"",
                        ""carriers"": [ { ""name"": ""AT&T"", ""status"": ""APPROVED"" } ]
                    }
                ]
            }
        }");

        private ChannelsSenderResource FetchSender(JToken payload)
        {
            Mock(payload);
            return ChannelsSenderResource.Fetch("XEaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", client: _twilioRestClient);
        }

        [Test]
        public void TestNestedResponse_UnknownFieldAtNestedLevelIsIgnored()
        {
            var payload = BaseSenderPayload();
            payload["configuration"]["waba_tier"] = "TIER_2";
            payload["compliance"]["countries"][0]["carriers"][0]["launch_date"] = "2025-03-01";

            var sender = FetchSender(payload);

            Assert.AreEqual("1234567890", sender.Configuration.WabaId);
            Assert.AreEqual("AT&T", sender.Compliance.Countries[0].Carriers[0].Name);
        }

        [Test]
        public void TestNestedResponse_RemovedNestedObjectDeserializesToNull()
        {
            var payload = BaseSenderPayload();
            payload.Remove("configuration");
            payload.Remove("compliance");

            var sender = FetchSender(payload);

            Assert.IsNull(sender.Configuration);
            Assert.IsNull(sender.Compliance);
            Assert.AreEqual("Owl Shop", sender.Profile.Name);
        }

        [Test]
        public void TestNestedResponse_RemovedFieldInsideNestedObjectDeserializesToNullButSiblingsSurvive()
        {
            // Different from removing the whole nested object: the object is still present,
            // only one property inside it disappears.
            var payload = BaseSenderPayload();
            ((JObject)payload["configuration"]).Remove("waba_id");
            ((JObject)payload["compliance"]["countries"][0]).Remove("carriers");

            var sender = FetchSender(payload);

            Assert.IsNull(sender.Configuration.WabaId);
            Assert.AreEqual("sms", sender.Configuration.VerificationMethod.ToString());
            Assert.IsNull(sender.Compliance.Countries[0].Carriers);
            Assert.AreEqual("US", sender.Compliance.Countries[0].Country);
        }

        [Test]
        public void TestNestedResponse_NewItemInNestedListIsDeserialized()
        {
            var payload = BaseSenderPayload();
            ((JArray)payload["offline_reasons"]).Add(JObject.Parse(@"
            { ""code"": ""63999"", ""message"": ""Brand new reason"", ""remediation"": ""Contact support"" }"));

            var sender = FetchSender(payload);

            Assert.AreEqual(2, sender.OfflineReasons.Count);
            Assert.AreEqual("Brand new reason", sender.OfflineReasons[1].Message);
        }

        [Test]
        public void TestNestedResponse_UnknownEnumValueAtNestedLevelIsPreserved()
        {
            var payload = BaseSenderPayload();
            payload["compliance"]["countries"][0]["carriers"][0]["status"] = "LAUNCHING";

            var sender = FetchSender(payload);

            Assert.AreEqual("LAUNCHING", sender.Compliance.Countries[0].Carriers[0].Status.ToString());
        }

        // ---------------------------------------------------------------
        // Operation-specific response model with nested lists of objects: RecallCreateResource
        //
        // ProfileCreateResource (id/message only) is too thin to exercise nested add/remove,
        // so this uses RecallCreateResource instead: it carries lists of nested objects
        // (observations, communications) and an object nested two levels deep
        // (communications[].author), plus its own enums (channel, participant type).
        // ---------------------------------------------------------------

        private static JObject BaseRecallPayload() => JObject.Parse(@"
        {
            ""observations"": [
                {
                    ""content"": ""Customer asked about owl feed"",
                    ""occurredAt"": ""2026-01-01T00:00:00Z"",
                    ""source"": ""conversation"",
                    ""id"": ""OB1"",
                    ""score"": 0.9
                }
            ],
            ""communications"": [
                {
                    ""id"": ""CM1"",
                    ""content"": { ""text"": ""Hello, how can I help?"" },
                    ""author"": {
                        ""id"": ""PT1"",
                        ""name"": ""Agent Owl"",
                        ""channel"": ""SMS"",
                        ""type"": ""HUMAN_AGENT""
                    },
                    ""channelId"": ""CH1""
                }
            ],
            ""meta"": { ""queryTime"": 120 },
            ""message"": ""ok""
        }");

        private RecallCreateResource CreateRecallWithResponse(JToken payload)
        {
            Mock(payload, HttpStatusCode.Created);
            var request = new RecallResource.MemoryRetrievalRequest.Builder().WithQuery("owl feed").Build();
            return RecallResource.Create(
                "ST_aaaaaaaaaaaaaaaaaaaaaaaaaa",
                "PR_aaaaaaaaaaaaaaaaaaaaaaaaaa",
                request,
                client: _twilioRestClient);
        }

        [Test]
        public void TestOperationSpecificResponse_UnknownFieldAtParentAndNestedLevelIsIgnored()
        {
            var payload = BaseRecallPayload();
            payload["queryId"] = "QR1"; // unknown field at parent level
            payload["meta"]["cacheHit"] = true; // unknown field inside a nested object
            payload["communications"][0]["author"]["profileId"] = "PR2"; // known nested field, still fine
            payload["communications"][0]["deliveryReceipt"] = JObject.Parse(@"{ ""seenAt"": ""2026-01-01T00:01:00Z"" }"); // unknown nested object inside a list item

            var recall = CreateRecallWithResponse(payload);

            Assert.AreEqual("ok", recall.Message);
            Assert.AreEqual(120, recall.Meta.QueryTime);
            Assert.AreEqual("Agent Owl", recall.Communications[0].Author.Name);
        }

        [Test]
        public void TestOperationSpecificResponse_RemovedFieldAtParentAndNestedLevelDeserializesToNull()
        {
            var payload = BaseRecallPayload();
            payload.Remove("message"); // removed at parent level
            ((JObject)payload["communications"][0]["author"]).Remove("name"); // removed two levels deep

            var recall = CreateRecallWithResponse(payload);

            Assert.IsNull(recall.Message);
            Assert.IsNull(recall.Communications[0].Author.Name);
            // Siblings at the same nested level are unaffected.
            Assert.AreEqual("PT1", recall.Communications[0].Author.Id);
            Assert.AreEqual(RecallResource.ChannelEnum.Sms, recall.Communications[0].Author.Channel);
        }

        [Test]
        public void TestOperationSpecificResponse_UnknownEnumValueInNestedListItemIsPreserved()
        {
            var payload = BaseRecallPayload();
            payload["communications"][0]["author"]["channel"] = "RCS_BUSINESS_MESSAGING";
            payload["communications"][0]["author"]["type"] = "SUPERVISOR";

            var recall = CreateRecallWithResponse(payload);

            Assert.AreEqual("RCS_BUSINESS_MESSAGING", recall.Communications[0].Author.Channel.ToString());
            Assert.AreNotEqual(RecallResource.ChannelEnum.Rcs, recall.Communications[0].Author.Channel);
            Assert.AreEqual("SUPERVISOR", recall.Communications[0].Author.Type.ToString());
        }
    }
}

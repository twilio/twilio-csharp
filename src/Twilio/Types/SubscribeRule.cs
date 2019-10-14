using System.Collections.Generic;
using Newtonsoft.Json;
using Twilio.Converters;

/// <summary>
/// Subscribe Rule - A single Subscribe Rule for a Participant
///
///   For more information see:
///   <a href="https://www.twilio.com/docs/video/api/track-subscriptions#specifying-sr">Specifying Subscribe Rules</a>
/// </summary>
namespace Twilio.Types
{
    public class SubscribeRule
    {
        public sealed class TypeEnum : StringEnum
        {
            private TypeEnum(string value) : base(value) {}

            public TypeEnum() {}
            public static readonly TypeEnum Include = new TypeEnum("include");
            public static readonly TypeEnum Exclude = new TypeEnum("exclude");
        }

        public sealed class KindEnum : StringEnum
        {
            private KindEnum(string value) : base(value) {}

            public KindEnum() {}

            public static readonly KindEnum Audio = new KindEnum("audio");
            public static readonly KindEnum Data = new KindEnum("data");
            public static readonly KindEnum Video = new KindEnum("video");
        }

        public sealed class PriorityEnum : StringEnum
        {
            private PriorityEnum(string value) : base(value) {}

            public PriorityEnum() {}

            public static readonly PriorityEnum Low = new PriorityEnum("low");
            public static readonly PriorityEnum Standard = new PriorityEnum("standard");
            public static readonly PriorityEnum High = new PriorityEnum("high");
        }

        [JsonProperty("type")]
        [JsonConverter(typeof(StringEnumConverter))]
        public TypeEnum Type { get; private set; }

        [JsonProperty("all")]
        public bool? All { get; private set; }

        [JsonProperty("publisher")]
        public string Publisher { get; private set; }

        [JsonProperty("track")]
        public string Track { get; private set; }

        [JsonProperty("kind")]
        [JsonConverter(typeof(StringEnumConverter))]
        public KindEnum Kind { get; private set; }

        [JsonProperty("priority")]
        [JsonConverter(typeof(StringEnumConverter))]
        public PriorityEnum Priority { get; private set; }

        public SubscribeRule (
                [JsonProperty("type")]
                TypeEnum type,
                [JsonProperty("all")]
                bool? all,
                [JsonProperty("publisher")]
                string publisher,
                [JsonProperty("track")]
                string track,
                [JsonProperty("kind")]
                KindEnum kind,
                [JsonProperty("priority")]
                PriorityEnum priority
                )
        {
            Type = type;
            All = all;
            Publisher = publisher;
            Track = track;
            Kind = kind;
            Priority = priority;
        }
    }
}

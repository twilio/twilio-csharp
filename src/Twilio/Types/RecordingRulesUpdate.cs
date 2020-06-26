using System.Collections.Generic;
using Newtonsoft.Json;
using Twilio.Converters;

namespace Twilio.Types
{
    public class RecordingRulesUpdate
    {
        [JsonProperty("rules")]
        public List<RecordingRule> Rules { get; private set; }

        public RecordingRulesUpdate (
            [JsonProperty("rules")]
            List<RecordingRule> rules
        )
        {
            Rules = rules;
        }
    }
}

using System.Collections.Generic;
using Newtonsoft.Json;
using Twilio.Converters;

/// <summary>
/// Recording Rule Update - Used to update the list of Recording Rules
/// </summary>
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

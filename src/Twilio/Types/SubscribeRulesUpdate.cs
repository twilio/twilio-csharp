using System.Collections.Generic;
using Newtonsoft.Json;
using Twilio.Converters;

///
/// Subscribe Rule Update - Used to update the list of Subscribe Rules
///
namespace Twilio.Types
{
    public class SubscribeRulesUpdate
    {
        [JsonProperty("rules")]
        public List<SubscribeRule> Rules { get; private set; }

        public SubscribeRulesUpdate (
            [JsonProperty("rules")]
            List<SubscribeRule> rules
        )
        {
            Rules = rules;
        }
    }
}

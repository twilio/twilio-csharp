using System;
using System.Collections.Generic;
using Twilio.Base;

namespace Twilio.Rest.Api.V2010.Account.Message 
{

    public class CreateFeedbackOptions : IOptions<FeedbackResource> 
    {
        public string AccountSid { get; set; }
        public string MessageSid { get; }
        public FeedbackResource.OutcomeEnum Outcome { get; set; }
    
        /// <summary>
        /// Construct a new CreateFeedbackOptions
        /// </summary>
        ///
        /// <param name="messageSid"> The message_sid </param>
        public CreateFeedbackOptions(string messageSid)
        {
            MessageSid = messageSid;
        }
    
        /// <summary>
        /// Generate the necessary parameters
        /// </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();
            if (Outcome != null)
            {
                p.Add(new KeyValuePair<string, string>("Outcome", Outcome.ToString()));
            }
            
            return p;
        }
    }

}
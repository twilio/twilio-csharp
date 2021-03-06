/// This code was generated by
/// \ / _    _  _|   _  _
///  | (_)\/(_)(_|\/| |(/_  v1.0.0
///       /       /

using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Converters;

namespace Twilio.Rest.Insights.V1.Call
{

    /// <summary>
    /// FetchCallSummaryOptions
    /// </summary>
    public class FetchCallSummaryOptions : IOptions<CallSummaryResource>
    {
        /// <summary>
        /// The call_sid
        /// </summary>
        public string PathCallSid { get; }
        /// <summary>
        /// The processing_state
        /// </summary>
        public CallSummaryResource.ProcessingStateEnum ProcessingState { get; set; }

        /// <summary>
        /// Construct a new FetchCallSummaryOptions
        /// </summary>
        /// <param name="pathCallSid"> The call_sid </param>
        public FetchCallSummaryOptions(string pathCallSid)
        {
            PathCallSid = pathCallSid;
        }

        /// <summary>
        /// Generate the necessary parameters
        /// </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();
            if (ProcessingState != null)
            {
                p.Add(new KeyValuePair<string, string>("ProcessingState", ProcessingState.ToString()));
            }

            return p;
        }
    }

}
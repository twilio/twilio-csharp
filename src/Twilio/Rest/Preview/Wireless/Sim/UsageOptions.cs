using System;
using System.Collections.Generic;
using Twilio.Base;

namespace Twilio.Rest.Preview.Wireless.Sim 
{

    /// <summary>
    /// FetchUsageOptions
    /// </summary>
    public class FetchUsageOptions : IOptions<UsageResource> 
    {
        /// <summary>
        /// The sim_sid
        /// </summary>
        public string PathSimSid { get; }
        /// <summary>
        /// The end
        /// </summary>
        public string End { get; set; }
        /// <summary>
        /// The start
        /// </summary>
        public string Start { get; set; }
    
        /// <summary>
        /// Construct a new FetchUsageOptions
        /// </summary>
        ///
        /// <param name="pathSimSid"> The sim_sid </param>
        public FetchUsageOptions(string pathSimSid)
        {
            PathSimSid = pathSimSid;
        }
    
        /// <summary>
        /// Generate the necessary parameters
        /// </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();
            if (End != null)
            {
                p.Add(new KeyValuePair<string, string>("End", End));
            }
            
            if (Start != null)
            {
                p.Add(new KeyValuePair<string, string>("Start", Start));
            }
            
            return p;
        }
    }

}
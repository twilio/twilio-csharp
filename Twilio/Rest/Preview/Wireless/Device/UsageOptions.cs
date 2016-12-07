using System;
using System.Collections.Generic;
using Twilio.Base;

namespace Twilio.Rest.Preview.Wireless.Device 
{

    public class FetchUsageOptions : IOptions<UsageResource> 
    {
        public string DeviceSid { get; }
        public string End { get; set; }
        public string Start { get; set; }
    
        /// <summary>
        /// Construct a new FetchUsageOptions
        /// </summary>
        ///
        /// <param name="deviceSid"> The device_sid </param>
        public FetchUsageOptions(string deviceSid)
        {
            DeviceSid = deviceSid;
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
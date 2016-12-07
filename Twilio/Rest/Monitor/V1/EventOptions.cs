using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Converters;

namespace Twilio.Rest.Monitor.V1 
{

    public class FetchEventOptions : IOptions<EventResource> 
    {
        public string Sid { get; }
    
        /// <summary>
        /// Construct a new FetchEventOptions
        /// </summary>
        ///
        /// <param name="sid"> The sid </param>
        public FetchEventOptions(string sid)
        {
            Sid = sid;
        }
    
        /// <summary>
        /// Generate the necessary parameters
        /// </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();
            return p;
        }
    }

    public class ReadEventOptions : ReadOptions<EventResource> 
    {
        public string ActorSid { get; set; }
        public string EventType { get; set; }
        public string ResourceSid { get; set; }
        public string SourceIpAddress { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    
        /// <summary>
        /// Generate the necessary parameters
        /// </summary>
        public override List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();
            if (ActorSid != null)
            {
                p.Add(new KeyValuePair<string, string>("ActorSid", ActorSid));
            }
            
            if (EventType != null)
            {
                p.Add(new KeyValuePair<string, string>("EventType", EventType));
            }
            
            if (ResourceSid != null)
            {
                p.Add(new KeyValuePair<string, string>("ResourceSid", ResourceSid));
            }
            
            if (SourceIpAddress != null)
            {
                p.Add(new KeyValuePair<string, string>("SourceIpAddress", SourceIpAddress));
            }
            
            if (StartDate != null)
            {
                p.Add(new KeyValuePair<string, string>("StartDate", StartDate.ToString()));
            }
            
            if (EndDate != null)
            {
                p.Add(new KeyValuePair<string, string>("EndDate", EndDate.ToString()));
            }
            
            if (PageSize != null)
            {
                p.Add(new KeyValuePair<string, string>("PageSize", PageSize.ToString()));
            }
            
            return p;
        }
    }

}
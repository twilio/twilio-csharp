using System;
using System.Collections.Generic;
using Twilio.Base;

namespace Twilio.Rest.Api.V2010.Account 
{

    public class FetchRecordingOptions : IOptions<RecordingResource> 
    {
        public string AccountSid { get; set; }
        public string Sid { get; }
    
        /// <summary>
        /// Construct a new FetchRecordingOptions
        /// </summary>
        ///
        /// <param name="sid"> Fetch by unique recording Sid </param>
        public FetchRecordingOptions(string sid)
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

    public class DeleteRecordingOptions : IOptions<RecordingResource> 
    {
        public string AccountSid { get; set; }
        public string Sid { get; }
    
        /// <summary>
        /// Construct a new DeleteRecordingOptions
        /// </summary>
        ///
        /// <param name="sid"> Delete by unique recording Sid </param>
        public DeleteRecordingOptions(string sid)
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

    public class ReadRecordingOptions : ReadOptions<RecordingResource> 
    {
        public string AccountSid { get; set; }
        public DateTime? DateCreatedBefore { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateCreatedAfter { get; set; }
        public string CallSid { get; set; }
    
        /// <summary>
        /// Generate the necessary parameters
        /// </summary>
        public override List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();
            if (DateCreated != null)
            {
                p.Add(new KeyValuePair<string, string>("DateCreated", DateCreated.Value.ToString("yyyy-MM-ddThh:mm:ssZ")));
            }
            else
            {
                if (DateCreatedBefore != null)
                {
                    p.Add(new KeyValuePair<string, string>("DateCreated<", DateCreatedBefore.Value.ToString("yyyy-MM-ddThh:mm:ssZ")));
                }
            
                if (DateCreatedAfter != null)
                {
                    p.Add(new KeyValuePair<string, string>("DateCreated>", DateCreatedAfter.Value.ToString("yyyy-MM-ddThh:mm:ssZ")));
                }
            }
            
            if (CallSid != null)
            {
                p.Add(new KeyValuePair<string, string>("CallSid", CallSid));
            }
            
            if (PageSize != null)
            {
                p.Add(new KeyValuePair<string, string>("PageSize", PageSize.ToString()));
            }
            
            return p;
        }
    }

}
using System;
using System.Collections.Generic;
using Twilio.Base;

namespace Twilio.Rest.Api.V2010.Account 
{

    public class FetchConferenceOptions : IOptions<ConferenceResource> 
    {
        public string AccountSid { get; set; }
        public string Sid { get; }
    
        /// <summary>
        /// Construct a new FetchConferenceOptions
        /// </summary>
        ///
        /// <param name="sid"> Fetch by unique conference Sid </param>
        public FetchConferenceOptions(string sid)
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

    public class ReadConferenceOptions : ReadOptions<ConferenceResource> 
    {
        public string AccountSid { get; set; }
        public string DateCreated { get; set; }
        public string DateUpdated { get; set; }
        public string FriendlyName { get; set; }
        public ConferenceResource.StatusEnum Status { get; set; }
    
        /// <summary>
        /// Generate the necessary parameters
        /// </summary>
        public override List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();
            if (DateCreated != null)
            {
                p.Add(new KeyValuePair<string, string>("DateCreated", DateCreated));
            }
            
            if (DateUpdated != null)
            {
                p.Add(new KeyValuePair<string, string>("DateUpdated", DateUpdated));
            }
            
            if (FriendlyName != null)
            {
                p.Add(new KeyValuePair<string, string>("FriendlyName", FriendlyName));
            }
            
            if (Status != null)
            {
                p.Add(new KeyValuePair<string, string>("Status", Status.ToString()));
            }
            
            if (PageSize != null)
            {
                p.Add(new KeyValuePair<string, string>("PageSize", PageSize.ToString()));
            }
            
            return p;
        }
    }

    public class UpdateConferenceOptions : IOptions<ConferenceResource> 
    {
        public string AccountSid { get; set; }
        public string Sid { get; }
        public ConferenceResource.UpdateStatusEnum Status { get; set; }
    
        /// <summary>
        /// Construct a new UpdateConferenceOptions
        /// </summary>
        ///
        /// <param name="sid"> The sid </param>
        public UpdateConferenceOptions(string sid)
        {
            Sid = sid;
        }
    
        /// <summary>
        /// Generate the necessary parameters
        /// </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();
            if (Status != null)
            {
                p.Add(new KeyValuePair<string, string>("Status", Status.ToString()));
            }
            
            return p;
        }
    }

}
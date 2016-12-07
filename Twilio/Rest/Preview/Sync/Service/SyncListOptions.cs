using System;
using System.Collections.Generic;
using Twilio.Base;

namespace Twilio.Rest.Preview.Sync.Service 
{

    public class FetchSyncListOptions : IOptions<SyncListResource> 
    {
        public string ServiceSid { get; }
        public string Sid { get; }
    
        /// <summary>
        /// Construct a new FetchSyncListOptions
        /// </summary>
        ///
        /// <param name="serviceSid"> The service_sid </param>
        /// <param name="sid"> The sid </param>
        public FetchSyncListOptions(string serviceSid, string sid)
        {
            ServiceSid = serviceSid;
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

    public class DeleteSyncListOptions : IOptions<SyncListResource> 
    {
        public string ServiceSid { get; }
        public string Sid { get; }
    
        /// <summary>
        /// Construct a new DeleteSyncListOptions
        /// </summary>
        ///
        /// <param name="serviceSid"> The service_sid </param>
        /// <param name="sid"> The sid </param>
        public DeleteSyncListOptions(string serviceSid, string sid)
        {
            ServiceSid = serviceSid;
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

    public class CreateSyncListOptions : IOptions<SyncListResource> 
    {
        public string ServiceSid { get; }
        public string UniqueName { get; set; }
    
        /// <summary>
        /// Construct a new CreateSyncListOptions
        /// </summary>
        ///
        /// <param name="serviceSid"> The service_sid </param>
        public CreateSyncListOptions(string serviceSid)
        {
            ServiceSid = serviceSid;
        }
    
        /// <summary>
        /// Generate the necessary parameters
        /// </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();
            if (UniqueName != null)
            {
                p.Add(new KeyValuePair<string, string>("UniqueName", UniqueName));
            }
            
            return p;
        }
    }

    public class ReadSyncListOptions : ReadOptions<SyncListResource> 
    {
        public string ServiceSid { get; }
    
        /// <summary>
        /// Construct a new ReadSyncListOptions
        /// </summary>
        ///
        /// <param name="serviceSid"> The service_sid </param>
        public ReadSyncListOptions(string serviceSid)
        {
            ServiceSid = serviceSid;
        }
    
        /// <summary>
        /// Generate the necessary parameters
        /// </summary>
        public override List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();
            if (PageSize != null)
            {
                p.Add(new KeyValuePair<string, string>("PageSize", PageSize.ToString()));
            }
            
            return p;
        }
    }

}
using System;
using System.Collections.Generic;
using Twilio.Base;

namespace Twilio.Rest.Preview.Sync.Service 
{

    public class FetchSyncMapOptions : IOptions<SyncMapResource> 
    {
        public string ServiceSid { get; }
        public string Sid { get; }
    
        /// <summary>
        /// Construct a new FetchSyncMapOptions
        /// </summary>
        ///
        /// <param name="serviceSid"> The service_sid </param>
        /// <param name="sid"> The sid </param>
        public FetchSyncMapOptions(string serviceSid, string sid)
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

    public class DeleteSyncMapOptions : IOptions<SyncMapResource> 
    {
        public string ServiceSid { get; }
        public string Sid { get; }
    
        /// <summary>
        /// Construct a new DeleteSyncMapOptions
        /// </summary>
        ///
        /// <param name="serviceSid"> The service_sid </param>
        /// <param name="sid"> The sid </param>
        public DeleteSyncMapOptions(string serviceSid, string sid)
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

    public class CreateSyncMapOptions : IOptions<SyncMapResource> 
    {
        public string ServiceSid { get; }
        public string UniqueName { get; set; }
    
        /// <summary>
        /// Construct a new CreateSyncMapOptions
        /// </summary>
        ///
        /// <param name="serviceSid"> The service_sid </param>
        public CreateSyncMapOptions(string serviceSid)
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

    public class ReadSyncMapOptions : ReadOptions<SyncMapResource> 
    {
        public string ServiceSid { get; }
    
        /// <summary>
        /// Construct a new ReadSyncMapOptions
        /// </summary>
        ///
        /// <param name="serviceSid"> The service_sid </param>
        public ReadSyncMapOptions(string serviceSid)
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
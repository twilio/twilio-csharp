using System;
using System.Collections.Generic;
using Twilio.Base;

namespace Twilio.Rest.Preview.Sync.Service 
{

    public class FetchDocumentOptions : IOptions<DocumentResource> 
    {
        /// <summary>
        /// The service_sid
        /// </summary>
        public string ServiceSid { get; }
        /// <summary>
        /// The sid
        /// </summary>
        public string Sid { get; }
    
        /// <summary>
        /// Construct a new FetchDocumentOptions
        /// </summary>
        ///
        /// <param name="serviceSid"> The service_sid </param>
        /// <param name="sid"> The sid </param>
        public FetchDocumentOptions(string serviceSid, string sid)
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

    public class DeleteDocumentOptions : IOptions<DocumentResource> 
    {
        /// <summary>
        /// The service_sid
        /// </summary>
        public string ServiceSid { get; }
        /// <summary>
        /// The sid
        /// </summary>
        public string Sid { get; }
    
        /// <summary>
        /// Construct a new DeleteDocumentOptions
        /// </summary>
        ///
        /// <param name="serviceSid"> The service_sid </param>
        /// <param name="sid"> The sid </param>
        public DeleteDocumentOptions(string serviceSid, string sid)
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

    public class CreateDocumentOptions : IOptions<DocumentResource> 
    {
        /// <summary>
        /// The service_sid
        /// </summary>
        public string ServiceSid { get; }
        /// <summary>
        /// The unique_name
        /// </summary>
        public string UniqueName { get; set; }
        /// <summary>
        /// The data
        /// </summary>
        public object Data { get; set; }
    
        /// <summary>
        /// Construct a new CreateDocumentOptions
        /// </summary>
        ///
        /// <param name="serviceSid"> The service_sid </param>
        public CreateDocumentOptions(string serviceSid)
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
            
            if (Data != null)
            {
                p.Add(new KeyValuePair<string, string>("Data", Data.ToString()));
            }
            
            return p;
        }
    }

    public class ReadDocumentOptions : ReadOptions<DocumentResource> 
    {
        /// <summary>
        /// The service_sid
        /// </summary>
        public string ServiceSid { get; }
    
        /// <summary>
        /// Construct a new ReadDocumentOptions
        /// </summary>
        ///
        /// <param name="serviceSid"> The service_sid </param>
        public ReadDocumentOptions(string serviceSid)
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

    public class UpdateDocumentOptions : IOptions<DocumentResource> 
    {
        /// <summary>
        /// The service_sid
        /// </summary>
        public string ServiceSid { get; }
        /// <summary>
        /// The sid
        /// </summary>
        public string Sid { get; }
        /// <summary>
        /// The data
        /// </summary>
        public object Data { get; }
    
        /// <summary>
        /// Construct a new UpdateDocumentOptions
        /// </summary>
        ///
        /// <param name="serviceSid"> The service_sid </param>
        /// <param name="sid"> The sid </param>
        /// <param name="data"> The data </param>
        public UpdateDocumentOptions(string serviceSid, string sid, object data)
        {
            ServiceSid = serviceSid;
            Sid = sid;
            Data = data;
        }
    
        /// <summary>
        /// Generate the necessary parameters
        /// </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();
            if (Data != null)
            {
                p.Add(new KeyValuePair<string, string>("Data", Data.ToString()));
            }
            
            return p;
        }
    }

}
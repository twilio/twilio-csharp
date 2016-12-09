using System;
using System.Collections.Generic;
using Twilio.Base;

namespace Twilio.Rest.Api.V2010.Account.Message 
{

    public class DeleteMediaOptions : IOptions<MediaResource> 
    {
        /// <summary>
        /// The account_sid
        /// </summary>
        public string AccountSid { get; set; }
        /// <summary>
        /// The message_sid
        /// </summary>
        public string MessageSid { get; }
        /// <summary>
        /// Delete by unique media Sid
        /// </summary>
        public string Sid { get; }
    
        /// <summary>
        /// Construct a new DeleteMediaOptions
        /// </summary>
        ///
        /// <param name="messageSid"> The message_sid </param>
        /// <param name="sid"> Delete by unique media Sid </param>
        public DeleteMediaOptions(string messageSid, string sid)
        {
            MessageSid = messageSid;
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

    public class FetchMediaOptions : IOptions<MediaResource> 
    {
        /// <summary>
        /// The account_sid
        /// </summary>
        public string AccountSid { get; set; }
        /// <summary>
        /// The message_sid
        /// </summary>
        public string MessageSid { get; }
        /// <summary>
        /// Fetch by unique media Sid
        /// </summary>
        public string Sid { get; }
    
        /// <summary>
        /// Construct a new FetchMediaOptions
        /// </summary>
        ///
        /// <param name="messageSid"> The message_sid </param>
        /// <param name="sid"> Fetch by unique media Sid </param>
        public FetchMediaOptions(string messageSid, string sid)
        {
            MessageSid = messageSid;
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

    public class ReadMediaOptions : ReadOptions<MediaResource> 
    {
        /// <summary>
        /// The account_sid
        /// </summary>
        public string AccountSid { get; set; }
        /// <summary>
        /// The message_sid
        /// </summary>
        public string MessageSid { get; }
        /// <summary>
        /// Filter by date created
        /// </summary>
        public DateTime? DateCreatedBefore { get; set; }
        /// <summary>
        /// Filter by date created
        /// </summary>
        public DateTime? DateCreated { get; set; }
        /// <summary>
        /// Filter by date created
        /// </summary>
        public DateTime? DateCreatedAfter { get; set; }
    
        /// <summary>
        /// Construct a new ReadMediaOptions
        /// </summary>
        ///
        /// <param name="messageSid"> The message_sid </param>
        public ReadMediaOptions(string messageSid)
        {
            MessageSid = messageSid;
        }
    
        /// <summary>
        /// Generate the necessary parameters
        /// </summary>
        public override List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();
            if (DateCreated != null)
            {
                p.Add(new KeyValuePair<string, string>("DateCreated", DateCreated.ToString()));
            }
            else
            {
                if (DateCreatedBefore != null)
                {
                    p.Add(new KeyValuePair<string, string>("DateCreated<", DateCreatedBefore.ToString()));
                }
            
                if (DateCreatedAfter != null)
                {
                    p.Add(new KeyValuePair<string, string>("DateCreated>", DateCreatedAfter.ToString()));
                }
            }
            
            if (PageSize != null)
            {
                p.Add(new KeyValuePair<string, string>("PageSize", PageSize.ToString()));
            }
            
            return p;
        }
    }

}
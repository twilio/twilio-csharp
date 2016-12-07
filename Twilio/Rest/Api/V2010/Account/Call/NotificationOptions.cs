using System;
using System.Collections.Generic;
using Twilio.Base;

namespace Twilio.Rest.Api.V2010.Account.Call 
{

    public class FetchNotificationOptions : IOptions<NotificationResource> 
    {
        public string AccountSid { get; set; }
        public string CallSid { get; }
        public string Sid { get; }
    
        /// <summary>
        /// Construct a new FetchNotificationOptions
        /// </summary>
        ///
        /// <param name="callSid"> The call_sid </param>
        /// <param name="sid"> The sid </param>
        public FetchNotificationOptions(string callSid, string sid)
        {
            CallSid = callSid;
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

    public class DeleteNotificationOptions : IOptions<NotificationResource> 
    {
        public string AccountSid { get; set; }
        public string CallSid { get; }
        public string Sid { get; }
    
        /// <summary>
        /// Construct a new DeleteNotificationOptions
        /// </summary>
        ///
        /// <param name="callSid"> The call_sid </param>
        /// <param name="sid"> The sid </param>
        public DeleteNotificationOptions(string callSid, string sid)
        {
            CallSid = callSid;
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

    public class ReadNotificationOptions : ReadOptions<NotificationResource> 
    {
        public string AccountSid { get; set; }
        public string CallSid { get; }
        public int? Log { get; set; }
        public DateTime? MessageDateBefore { get; set; }
        public DateTime? MessageDate { get; set; }
        public DateTime? MessageDateAfter { get; set; }
    
        /// <summary>
        /// Construct a new ReadNotificationOptions
        /// </summary>
        ///
        /// <param name="callSid"> The call_sid </param>
        public ReadNotificationOptions(string callSid)
        {
            CallSid = callSid;
        }
    
        /// <summary>
        /// Generate the necessary parameters
        /// </summary>
        public override List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();
            if (Log != null)
            {
                p.Add(new KeyValuePair<string, string>("Log", Log.ToString()));
            }
            
            if (MessageDate != null)
            {
                p.Add(new KeyValuePair<string, string>("MessageDate", MessageDate.Value.ToString("yyyy-MM-dd")));
            }
            else
            {
                if (MessageDateBefore != null)
                {
                    p.Add(new KeyValuePair<string, string>("MessageDate<", MessageDateBefore.Value.ToString("yyyy-MM-dd")));
                }
            
                if (MessageDateAfter != null)
                {
                    p.Add(new KeyValuePair<string, string>("MessageDate>", MessageDateAfter.Value.ToString("yyyy-MM-dd")));
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
using System;
using System.Collections.Generic;
using Twilio.Base;

namespace Twilio.Rest.Api.V2010.Account.Call 
{

    public class FetchNotificationOptions : IOptions<NotificationResource> 
    {
        /// <summary>
        /// The account_sid
        /// </summary>
        public string AccountSid { get; set; }
        /// <summary>
        /// The call_sid
        /// </summary>
        public string CallSid { get; }
        /// <summary>
        /// The sid
        /// </summary>
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
        /// <summary>
        /// The account_sid
        /// </summary>
        public string AccountSid { get; set; }
        /// <summary>
        /// The call_sid
        /// </summary>
        public string CallSid { get; }
        /// <summary>
        /// The sid
        /// </summary>
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
        /// <summary>
        /// The account_sid
        /// </summary>
        public string AccountSid { get; set; }
        /// <summary>
        /// The call_sid
        /// </summary>
        public string CallSid { get; }
        /// <summary>
        /// The log
        /// </summary>
        public int? Log { get; set; }
        /// <summary>
        /// The message_date
        /// </summary>
        public DateTime? MessageDateBefore { get; set; }
        /// <summary>
        /// The message_date
        /// </summary>
        public DateTime? MessageDate { get; set; }
        /// <summary>
        /// The message_date
        /// </summary>
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
                p.Add(new KeyValuePair<string, string>("Log", Log.Value.ToString()));
            }
            
            if (MessageDate != null)
            {
                p.Add(new KeyValuePair<string, string>("MessageDate", MessageDate.ToString()));
            }
            else
            {
                if (MessageDateBefore != null)
                {
                    p.Add(new KeyValuePair<string, string>("MessageDate<", MessageDateBefore.ToString()));
                }
            
                if (MessageDateAfter != null)
                {
                    p.Add(new KeyValuePair<string, string>("MessageDate>", MessageDateAfter.ToString()));
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
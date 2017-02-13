using System;
using System.Collections.Generic;
using Twilio.Base;

namespace Twilio.Rest.Api.V2010.Account 
{

    public class FetchNotificationOptions : IOptions<NotificationResource> 
    {
        /// <summary>
        /// The account_sid
        /// </summary>
        public string AccountSid { get; set; }
        /// <summary>
        /// Fetch by unique notification Sid
        /// </summary>
        public string Sid { get; }
    
        /// <summary>
        /// Construct a new FetchNotificationOptions
        /// </summary>
        ///
        /// <param name="sid"> Fetch by unique notification Sid </param>
        public FetchNotificationOptions(string sid)
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

    public class DeleteNotificationOptions : IOptions<NotificationResource> 
    {
        /// <summary>
        /// The account_sid
        /// </summary>
        public string AccountSid { get; set; }
        /// <summary>
        /// Delete by unique notification Sid
        /// </summary>
        public string Sid { get; }
    
        /// <summary>
        /// Construct a new DeleteNotificationOptions
        /// </summary>
        ///
        /// <param name="sid"> Delete by unique notification Sid </param>
        public DeleteNotificationOptions(string sid)
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

    public class ReadNotificationOptions : ReadOptions<NotificationResource> 
    {
        /// <summary>
        /// The account_sid
        /// </summary>
        public string AccountSid { get; set; }
        /// <summary>
        /// Filter by log level
        /// </summary>
        public int? Log { get; set; }
        /// <summary>
        /// Filter by date
        /// </summary>
        public DateTime? MessageDateBefore { get; set; }
        /// <summary>
        /// Filter by date
        /// </summary>
        public DateTime? MessageDate { get; set; }
        /// <summary>
        /// Filter by date
        /// </summary>
        public DateTime? MessageDateAfter { get; set; }
    
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
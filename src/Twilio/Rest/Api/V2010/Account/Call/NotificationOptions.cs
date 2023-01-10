/*
 * This code was generated by
 * ___ _ _ _ _ _    _ ____    ____ ____ _    ____ ____ _  _ ____ ____ ____ ___ __   __
 *  |  | | | | |    | |  | __ |  | |__| | __ | __ |___ |\ | |___ |__/ |__|  | |  | |__/
 *  |  |_|_| | |___ | |__|    |__| |  | |    |__] |___ | \| |___ |  \ |  |  | |__| |  \
 *
 * Twilio - Api
 * This is the public Twilio REST API.
 *
 * NOTE: This class is auto generated by OpenAPI Generator.
 * https://openapi-generator.tech
 * Do not edit the class manually.
 */


using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Converters;




namespace Twilio.Rest.Api.V2010.Account.Call
{
    /// <summary> fetch </summary>
    public class FetchNotificationOptions : IOptions<NotificationResource>
    {
    
        ///<summary> The [Call](https://www.twilio.com/docs/voice/api/call-resource) SID of the Call Notification resource to fetch. </summary> 
        public string PathCallSid { get; }

        ///<summary> The Twilio-provided string that uniquely identifies the Call Notification resource to fetch. </summary> 
        public string PathSid { get; }

        ///<summary> The SID of the [Account](https://www.twilio.com/docs/iam/api/account) that created the Call Notification resource to fetch. </summary> 
        public string PathAccountSid { get; set; }



        /// <summary> Construct a new FetchCallNotificationOptions </summary>
        /// <param name="pathCallSid"> The [Call](https://www.twilio.com/docs/voice/api/call-resource) SID of the Call Notification resource to fetch. </param>
        /// <param name="pathSid"> The Twilio-provided string that uniquely identifies the Call Notification resource to fetch. </param>
        public FetchNotificationOptions(string pathCallSid, string pathSid)
        {
            PathCallSid = pathCallSid;
            PathSid = pathSid;
        }

        
        /// <summary> Generate the necessary parameters </summary>
        public  List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            return p;
        }
        

    }


    /// <summary> read </summary>
    public class ReadNotificationOptions : ReadOptions<NotificationResource>
    {
    
        ///<summary> The [Call](https://www.twilio.com/docs/voice/api/call-resource) SID of the Call Notification resources to read. </summary> 
        public string PathCallSid { get; }

        ///<summary> The SID of the [Account](https://www.twilio.com/docs/iam/api/account) that created the Call Notification resources to read. </summary> 
        public string PathAccountSid { get; set; }

        ///<summary> Only read notifications of the specified log level. Can be:  `0` to read only ERROR notifications or `1` to read only WARNING notifications. By default, all notifications are read. </summary> 
        public int? Log { get; set; }

        ///<summary> Only show notifications for the specified date, formatted as `YYYY-MM-DD`. You can also specify an inequality, such as `<=YYYY-MM-DD` for messages logged at or before midnight on a date, or `>=YYYY-MM-DD` for messages logged at or after midnight on a date. </summary> 
        public DateTime? MessageDate { get; set; }

        ///<summary> Only show notifications for the specified date, formatted as `YYYY-MM-DD`. You can also specify an inequality, such as `<=YYYY-MM-DD` for messages logged at or before midnight on a date, or `>=YYYY-MM-DD` for messages logged at or after midnight on a date. </summary> 
        public DateTime? MessageDateBefore { get; set; }

        ///<summary> Only show notifications for the specified date, formatted as `YYYY-MM-DD`. You can also specify an inequality, such as `<=YYYY-MM-DD` for messages logged at or before midnight on a date, or `>=YYYY-MM-DD` for messages logged at or after midnight on a date. </summary> 
        public DateTime? MessageDateAfter { get; set; }



        /// <summary> Construct a new ListCallNotificationOptions </summary>
        /// <param name="pathCallSid"> The [Call](https://www.twilio.com/docs/voice/api/call-resource) SID of the Call Notification resources to read. </param>
        public ReadNotificationOptions(string pathCallSid)
        {
            PathCallSid = pathCallSid;
        }

        
        /// <summary> Generate the necessary parameters </summary>
        public  override List<KeyValuePair<string, string>> GetParams()
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


using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Converters;
using Twilio.Exceptions;

namespace Twilio.Rest.Preview.Sync 
{

    public class ServiceResource : Resource 
    {
        /// <summary>
        /// fetch
        /// </summary>
        ///
        /// <param name="sid"> The sid </param>
        /// <returns> ServiceFetcher capable of executing the fetch </returns> 
        public static ServiceFetcher Fetcher(string sid)
        {
            return new ServiceFetcher(sid);
        }
    
        /// <summary>
        /// delete
        /// </summary>
        ///
        /// <param name="sid"> The sid </param>
        /// <returns> ServiceDeleter capable of executing the delete </returns> 
        public static ServiceDeleter Deleter(string sid)
        {
            return new ServiceDeleter(sid);
        }
    
        /// <summary>
        /// create
        /// </summary>
        ///
        /// <returns> ServiceCreator capable of executing the create </returns> 
        public static ServiceCreator Creator()
        {
            return new ServiceCreator();
        }
    
        /// <summary>
        /// read
        /// </summary>
        ///
        /// <returns> ServiceReader capable of executing the read </returns> 
        public static ServiceReader Reader()
        {
            return new ServiceReader();
        }
    
        /// <summary>
        /// update
        /// </summary>
        ///
        /// <param name="sid"> The sid </param>
        /// <returns> ServiceUpdater capable of executing the update </returns> 
        public static ServiceUpdater Updater(string sid)
        {
            return new ServiceUpdater(sid);
        }
    
        /// <summary>
        /// Converts a JSON string into a ServiceResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> ServiceResource object represented by the provided JSON </returns> 
        public static ServiceResource FromJson(string json)
        {
            // Convert all checked exceptions to Runtime
            try
            {
                return JsonConvert.DeserializeObject<ServiceResource>(json);
            }
            catch (JsonException e)
            {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("sid")]
        public string Sid { get; set; }
        [JsonProperty("account_sid")]
        public string AccountSid { get; set; }
        [JsonProperty("friendly_name")]
        public string FriendlyName { get; set; }
        [JsonProperty("date_created")]
        public DateTime? DateCreated { get; set; }
        [JsonProperty("date_updated")]
        public DateTime? DateUpdated { get; set; }
        [JsonProperty("url")]
        public Uri Url { get; set; }
        [JsonProperty("webhook_url")]
        public Uri WebhookUrl { get; set; }
        [JsonProperty("reachability_webhooks_enabled")]
        public bool? ReachabilityWebhooksEnabled { get; set; }
        [JsonProperty("links")]
        public Dictionary<string, string> Links { get; set; }
    
        public ServiceResource()
        {
        
        }
    
        private ServiceResource([JsonProperty("sid")]
                                string sid, 
                                [JsonProperty("account_sid")]
                                string accountSid, 
                                [JsonProperty("friendly_name")]
                                string friendlyName, 
                                [JsonProperty("date_created")]
                                string dateCreated, 
                                [JsonProperty("date_updated")]
                                string dateUpdated, 
                                [JsonProperty("url")]
                                Uri url, 
                                [JsonProperty("webhook_url")]
                                Uri webhookUrl, 
                                [JsonProperty("reachability_webhooks_enabled")]
                                bool? reachabilityWebhooksEnabled, 
                                [JsonProperty("links")]
                                Dictionary<string, string> links)
                                {
            Sid = sid;
            AccountSid = accountSid;
            FriendlyName = friendlyName;
            DateCreated = MarshalConverter.DateTimeFromString(dateCreated);
            DateUpdated = MarshalConverter.DateTimeFromString(dateUpdated);
            Url = url;
            WebhookUrl = webhookUrl;
            ReachabilityWebhooksEnabled = reachabilityWebhooksEnabled;
            Links = links;
        }
    }
}
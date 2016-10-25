using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Preview.Sync {

    public class ServiceResource : Resource {
        /// <summary>
        /// fetch
        /// </summary>
        ///
        /// <param name="sid"> The sid </param>
        /// <returns> ServiceFetcher capable of executing the fetch </returns> 
        public static ServiceFetcher Fetcher(string sid) {
            return new ServiceFetcher(sid);
        }
    
        /// <summary>
        /// delete
        /// </summary>
        ///
        /// <param name="sid"> The sid </param>
        /// <returns> ServiceDeleter capable of executing the delete </returns> 
        public static ServiceDeleter Deleter(string sid) {
            return new ServiceDeleter(sid);
        }
    
        /// <summary>
        /// create
        /// </summary>
        ///
        /// <param name="friendlyName"> The friendly_name </param>
        /// <param name="webhookUrl"> The webhook_url </param>
        /// <param name="reachabilityWebhooksEnabled"> The reachability_webhooks_enabled </param>
        /// <returns> ServiceCreator capable of executing the create </returns> 
        public static ServiceCreator Creator(string friendlyName=null, Uri webhookUrl=null, bool? reachabilityWebhooksEnabled=null) {
            return new ServiceCreator(friendlyName:friendlyName, webhookUrl:webhookUrl, reachabilityWebhooksEnabled:reachabilityWebhooksEnabled);
        }
    
        /// <summary>
        /// read
        /// </summary>
        ///
        /// <returns> ServiceReader capable of executing the read </returns> 
        public static ServiceReader Reader() {
            return new ServiceReader();
        }
    
        /// <summary>
        /// update
        /// </summary>
        ///
        /// <param name="sid"> The sid </param>
        /// <param name="webhookUrl"> The webhook_url </param>
        /// <param name="friendlyName"> The friendly_name </param>
        /// <param name="reachabilityWebhooksEnabled"> The reachability_webhooks_enabled </param>
        /// <returns> ServiceUpdater capable of executing the update </returns> 
        public static ServiceUpdater Updater(string sid, Uri webhookUrl=null, string friendlyName=null, bool? reachabilityWebhooksEnabled=null) {
            return new ServiceUpdater(sid, webhookUrl:webhookUrl, friendlyName:friendlyName, reachabilityWebhooksEnabled:reachabilityWebhooksEnabled);
        }
    
        /// <summary>
        /// Converts a JSON string into a ServiceResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> ServiceResource object represented by the provided JSON </returns> 
        public static ServiceResource FromJson(string json) {
            // Convert all checked exceptions to Runtime
            try {
                return JsonConvert.DeserializeObject<ServiceResource>(json);
            } catch (JsonException e) {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("sid")]
        public string sid { get; }
        [JsonProperty("account_sid")]
        public string accountSid { get; }
        [JsonProperty("friendly_name")]
        public string friendlyName { get; }
        [JsonProperty("date_created")]
        public DateTime? dateCreated { get; }
        [JsonProperty("date_updated")]
        public DateTime? dateUpdated { get; }
        [JsonProperty("url")]
        public Uri url { get; }
        [JsonProperty("webhook_url")]
        public Uri webhookUrl { get; }
        [JsonProperty("reachability_webhooks_enabled")]
        public bool? reachabilityWebhooksEnabled { get; }
        [JsonProperty("links")]
        public Dictionary<string, string> links { get; }
    
        public ServiceResource() {
        
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
                                Dictionary<string, string> links) {
            this.sid = sid;
            this.accountSid = accountSid;
            this.friendlyName = friendlyName;
            this.dateCreated = MarshalConverter.DateTimeFromString(dateCreated);
            this.dateUpdated = MarshalConverter.DateTimeFromString(dateUpdated);
            this.url = url;
            this.webhookUrl = webhookUrl;
            this.reachabilityWebhooksEnabled = reachabilityWebhooksEnabled;
            this.links = links;
        }
    }
}
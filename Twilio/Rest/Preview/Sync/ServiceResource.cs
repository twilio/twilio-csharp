using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Preview.Sync {

    public class ServiceResource : SidResource {
        /**
         * fetch
         * 
         * @param sid The sid
         * @return ServiceFetcher capable of executing the fetch
         */
        public static ServiceFetcher Fetch(string sid) {
            return new ServiceFetcher(sid);
        }
    
        /**
         * delete
         * 
         * @param sid The sid
         * @return ServiceDeleter capable of executing the delete
         */
        public static ServiceDeleter Delete(string sid) {
            return new ServiceDeleter(sid);
        }
    
        /**
         * create
         * 
         * @return ServiceCreator capable of executing the create
         */
        public static ServiceCreator Create() {
            return new ServiceCreator();
        }
    
        /**
         * read
         * 
         * @return ServiceReader capable of executing the read
         */
        public static ServiceReader Read() {
            return new ServiceReader();
        }
    
        /**
         * update
         * 
         * @param sid The sid
         * @return ServiceUpdater capable of executing the update
         */
        public static ServiceUpdater Update(string sid) {
            return new ServiceUpdater(sid);
        }
    
        /**
         * Converts a JSON string into a ServiceResource object
         * 
         * @param json Raw JSON string
         * @return ServiceResource object represented by the provided JSON
         */
        public static ServiceResource FromJson(string json) {
            // Convert all checked exceptions to Runtime
            try {
                return JsonConvert.DeserializeObject<ServiceResource>(json);
            } catch (JsonException e) {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("sid")]
        private readonly string sid;
        [JsonProperty("account_sid")]
        private readonly string accountSid;
        [JsonProperty("friendly_name")]
        private readonly string friendlyName;
        [JsonProperty("date_created")]
        private readonly DateTime? dateCreated;
        [JsonProperty("date_updated")]
        private readonly DateTime? dateUpdated;
        [JsonProperty("url")]
        private readonly Uri url;
        [JsonProperty("webhook_url")]
        private readonly Uri webhookUrl;
        [JsonProperty("links")]
        private readonly Dictionary<string, string> links;
    
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
                                [JsonProperty("links")]
                                Dictionary<string, string> links) {
            this.sid = sid;
            this.accountSid = accountSid;
            this.friendlyName = friendlyName;
            this.dateCreated = MarshalConverter.DateTimeFromString(dateCreated);
            this.dateUpdated = MarshalConverter.DateTimeFromString(dateUpdated);
            this.url = url;
            this.webhookUrl = webhookUrl;
            this.links = links;
        }
    
        /**
         * @return The sid
         */
        public override string GetSid() {
            return this.sid;
        }
    
        /**
         * @return The account_sid
         */
        public string GetAccountSid() {
            return this.accountSid;
        }
    
        /**
         * @return The friendly_name
         */
        public string GetFriendlyName() {
            return this.friendlyName;
        }
    
        /**
         * @return The date_created
         */
        public DateTime? GetDateCreated() {
            return this.dateCreated;
        }
    
        /**
         * @return The date_updated
         */
        public DateTime? GetDateUpdated() {
            return this.dateUpdated;
        }
    
        /**
         * @return The url
         */
        public Uri GetUrl() {
            return this.url;
        }
    
        /**
         * @return The webhook_url
         */
        public Uri GetWebhookUrl() {
            return this.webhookUrl;
        }
    
        /**
         * @return The links
         */
        public Dictionary<string, string> GetLinks() {
            return this.links;
        }
    }
}
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Preview.Sync.Service {

    public class SyncMapResource : SidResource {
        /**
         * fetch
         * 
         * @param serviceSid The service_sid
         * @param sid The sid
         * @return SyncMapFetcher capable of executing the fetch
         */
        public static SyncMapFetcher Fetcher(string serviceSid, string sid) {
            return new SyncMapFetcher(serviceSid, sid);
        }
    
        /**
         * delete
         * 
         * @param serviceSid The service_sid
         * @param sid The sid
         * @return SyncMapDeleter capable of executing the delete
         */
        public static SyncMapDeleter Deleter(string serviceSid, string sid) {
            return new SyncMapDeleter(serviceSid, sid);
        }
    
        /**
         * create
         * 
         * @param serviceSid The service_sid
         * @return SyncMapCreator capable of executing the create
         */
        public static SyncMapCreator Creator(string serviceSid) {
            return new SyncMapCreator(serviceSid);
        }
    
        /**
         * read
         * 
         * @param serviceSid The service_sid
         * @return SyncMapReader capable of executing the read
         */
        public static SyncMapReader Reader(string serviceSid) {
            return new SyncMapReader(serviceSid);
        }
    
        /**
         * Converts a JSON string into a SyncMapResource object
         * 
         * @param json Raw JSON string
         * @return SyncMapResource object represented by the provided JSON
         */
        public static SyncMapResource FromJson(string json) {
            // Convert all checked exceptions to Runtime
            try {
                return JsonConvert.DeserializeObject<SyncMapResource>(json);
            } catch (JsonException e) {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("sid")]
        private readonly string sid;
        [JsonProperty("unique_name")]
        private readonly string uniqueName;
        [JsonProperty("account_sid")]
        private readonly string accountSid;
        [JsonProperty("service_sid")]
        private readonly string serviceSid;
        [JsonProperty("url")]
        private readonly Uri url;
        [JsonProperty("links")]
        private readonly Dictionary<string, string> links;
        [JsonProperty("revision")]
        private readonly string revision;
        [JsonProperty("date_created")]
        private readonly DateTime? dateCreated;
        [JsonProperty("date_updated")]
        private readonly DateTime? dateUpdated;
        [JsonProperty("created_by")]
        private readonly string createdBy;
    
        public SyncMapResource() {
        
        }
    
        private SyncMapResource([JsonProperty("sid")]
                                string sid, 
                                [JsonProperty("unique_name")]
                                string uniqueName, 
                                [JsonProperty("account_sid")]
                                string accountSid, 
                                [JsonProperty("service_sid")]
                                string serviceSid, 
                                [JsonProperty("url")]
                                Uri url, 
                                [JsonProperty("links")]
                                Dictionary<string, string> links, 
                                [JsonProperty("revision")]
                                string revision, 
                                [JsonProperty("date_created")]
                                string dateCreated, 
                                [JsonProperty("date_updated")]
                                string dateUpdated, 
                                [JsonProperty("created_by")]
                                string createdBy) {
            this.sid = sid;
            this.uniqueName = uniqueName;
            this.accountSid = accountSid;
            this.serviceSid = serviceSid;
            this.url = url;
            this.links = links;
            this.revision = revision;
            this.dateCreated = MarshalConverter.DateTimeFromString(dateCreated);
            this.dateUpdated = MarshalConverter.DateTimeFromString(dateUpdated);
            this.createdBy = createdBy;
        }
    
        /**
         * @return The sid
         */
        public override string GetSid() {
            return this.sid;
        }
    
        /**
         * @return The unique_name
         */
        public string GetUniqueName() {
            return this.uniqueName;
        }
    
        /**
         * @return The account_sid
         */
        public string GetAccountSid() {
            return this.accountSid;
        }
    
        /**
         * @return The service_sid
         */
        public string GetServiceSid() {
            return this.serviceSid;
        }
    
        /**
         * @return The url
         */
        public Uri GetUrl() {
            return this.url;
        }
    
        /**
         * @return The links
         */
        public Dictionary<string, string> GetLinks() {
            return this.links;
        }
    
        /**
         * @return The revision
         */
        public string GetRevision() {
            return this.revision;
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
         * @return The created_by
         */
        public string GetCreatedBy() {
            return this.createdBy;
        }
    }
}
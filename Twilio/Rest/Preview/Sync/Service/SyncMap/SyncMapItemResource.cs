using Newtonsoft.Json;
using System;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Preview.Sync.Service.SyncMap {

    public class SyncMapItemResource : SidResource {
        public sealed class QueryResultOrder : IStringEnum {
            public const string ASC="asc";
            public const string DESC="desc";
        
            private string value;
            
            public QueryResultOrder() { }
            
            public QueryResultOrder(string value) {
                this.value = value;
            }
            
            public override string ToString() {
                return value;
            }
            
            public static implicit operator QueryResultOrder(string value) {
                return new QueryResultOrder(value);
            }
            
            public static implicit operator string(QueryResultOrder value) {
                return value.ToString();
            }
            
            public void FromString(string value) {
                this.value = value;
            }
        }
    
        public sealed class QueryFromBoundType : IStringEnum {
            public const string INCLUSIVE="inclusive";
            public const string EXCLUSIVE="exclusive";
        
            private string value;
            
            public QueryFromBoundType() { }
            
            public QueryFromBoundType(string value) {
                this.value = value;
            }
            
            public override string ToString() {
                return value;
            }
            
            public static implicit operator QueryFromBoundType(string value) {
                return new QueryFromBoundType(value);
            }
            
            public static implicit operator string(QueryFromBoundType value) {
                return value.ToString();
            }
            
            public void FromString(string value) {
                this.value = value;
            }
        }
    
        /**
         * fetch
         * 
         * @param serviceSid The service_sid
         * @param mapSid The map_sid
         * @param key The key
         * @return SyncMapItemFetcher capable of executing the fetch
         */
        public static SyncMapItemFetcher Fetcher(string serviceSid, string mapSid, string key) {
            return new SyncMapItemFetcher(serviceSid, mapSid, key);
        }
    
        /**
         * delete
         * 
         * @param serviceSid The service_sid
         * @param mapSid The map_sid
         * @param key The key
         * @return SyncMapItemDeleter capable of executing the delete
         */
        public static SyncMapItemDeleter Deleter(string serviceSid, string mapSid, string key) {
            return new SyncMapItemDeleter(serviceSid, mapSid, key);
        }
    
        /**
         * create
         * 
         * @param serviceSid The service_sid
         * @param mapSid The map_sid
         * @param key The key
         * @param data The data
         * @return SyncMapItemCreator capable of executing the create
         */
        public static SyncMapItemCreator Creator(string serviceSid, string mapSid, string key, Object data) {
            return new SyncMapItemCreator(serviceSid, mapSid, key, data);
        }
    
        /**
         * read
         * 
         * @param serviceSid The service_sid
         * @param mapSid The map_sid
         * @return SyncMapItemReader capable of executing the read
         */
        public static SyncMapItemReader Reader(string serviceSid, string mapSid) {
            return new SyncMapItemReader(serviceSid, mapSid);
        }
    
        /**
         * update
         * 
         * @param serviceSid The service_sid
         * @param mapSid The map_sid
         * @param key The key
         * @param data The data
         * @return SyncMapItemUpdater capable of executing the update
         */
        public static SyncMapItemUpdater Updater(string serviceSid, string mapSid, string key, Object data) {
            return new SyncMapItemUpdater(serviceSid, mapSid, key, data);
        }
    
        /**
         * Converts a JSON string into a SyncMapItemResource object
         * 
         * @param json Raw JSON string
         * @return SyncMapItemResource object represented by the provided JSON
         */
        public static SyncMapItemResource FromJson(string json) {
            // Convert all checked exceptions to Runtime
            try {
                return JsonConvert.DeserializeObject<SyncMapItemResource>(json);
            } catch (JsonException e) {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("key")]
        private readonly string key;
        [JsonProperty("account_sid")]
        private readonly string accountSid;
        [JsonProperty("service_sid")]
        private readonly string serviceSid;
        [JsonProperty("map_sid")]
        private readonly string mapSid;
        [JsonProperty("url")]
        private readonly Uri url;
        [JsonProperty("revision")]
        private readonly string revision;
        [JsonProperty("data")]
        private readonly Object data;
        [JsonProperty("date_created")]
        private readonly DateTime? dateCreated;
        [JsonProperty("date_updated")]
        private readonly DateTime? dateUpdated;
        [JsonProperty("created_by")]
        private readonly string createdBy;
    
        public SyncMapItemResource() {
        
        }
    
        private SyncMapItemResource([JsonProperty("key")]
                                    string key, 
                                    [JsonProperty("account_sid")]
                                    string accountSid, 
                                    [JsonProperty("service_sid")]
                                    string serviceSid, 
                                    [JsonProperty("map_sid")]
                                    string mapSid, 
                                    [JsonProperty("url")]
                                    Uri url, 
                                    [JsonProperty("revision")]
                                    string revision, 
                                    [JsonProperty("data")]
                                    Object data, 
                                    [JsonProperty("date_created")]
                                    string dateCreated, 
                                    [JsonProperty("date_updated")]
                                    string dateUpdated, 
                                    [JsonProperty("created_by")]
                                    string createdBy) {
            this.key = key;
            this.accountSid = accountSid;
            this.serviceSid = serviceSid;
            this.mapSid = mapSid;
            this.url = url;
            this.revision = revision;
            this.data = data;
            this.dateCreated = MarshalConverter.DateTimeFromString(dateCreated);
            this.dateUpdated = MarshalConverter.DateTimeFromString(dateUpdated);
            this.createdBy = createdBy;
        }
    
        /**
         * @return The key
         */
        public override string GetSid() {
            return this.GetKey();
        }
    
        /**
         * @return The key
         */
        public string GetKey() {
            return this.key;
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
         * @return The map_sid
         */
        public string GetMapSid() {
            return this.mapSid;
        }
    
        /**
         * @return The url
         */
        public Uri GetUrl() {
            return this.url;
        }
    
        /**
         * @return The revision
         */
        public string GetRevision() {
            return this.revision;
        }
    
        /**
         * @return The data
         */
        public Object GetData() {
            return this.data;
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
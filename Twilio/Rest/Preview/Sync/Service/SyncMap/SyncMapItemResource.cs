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
    
        /// <summary>
        /// fetch
        /// </summary>
        ///
        /// <param name="serviceSid"> The service_sid </param>
        /// <param name="mapSid"> The map_sid </param>
        /// <param name="key"> The key </param>
        /// <returns> SyncMapItemFetcher capable of executing the fetch </returns> 
        public static SyncMapItemFetcher Fetcher(string serviceSid, string mapSid, string key) {
            return new SyncMapItemFetcher(serviceSid, mapSid, key);
        }
    
        /// <summary>
        /// delete
        /// </summary>
        ///
        /// <param name="serviceSid"> The service_sid </param>
        /// <param name="mapSid"> The map_sid </param>
        /// <param name="key"> The key </param>
        /// <returns> SyncMapItemDeleter capable of executing the delete </returns> 
        public static SyncMapItemDeleter Deleter(string serviceSid, string mapSid, string key) {
            return new SyncMapItemDeleter(serviceSid, mapSid, key);
        }
    
        /// <summary>
        /// create
        /// </summary>
        ///
        /// <param name="serviceSid"> The service_sid </param>
        /// <param name="mapSid"> The map_sid </param>
        /// <param name="key"> The key </param>
        /// <param name="data"> The data </param>
        /// <returns> SyncMapItemCreator capable of executing the create </returns> 
        public static SyncMapItemCreator Creator(string serviceSid, string mapSid, string key, Object data) {
            return new SyncMapItemCreator(serviceSid, mapSid, key, data);
        }
    
        /// <summary>
        /// read
        /// </summary>
        ///
        /// <param name="serviceSid"> The service_sid </param>
        /// <param name="mapSid"> The map_sid </param>
        /// <returns> SyncMapItemReader capable of executing the read </returns> 
        public static SyncMapItemReader Reader(string serviceSid, string mapSid) {
            return new SyncMapItemReader(serviceSid, mapSid);
        }
    
        /// <summary>
        /// update
        /// </summary>
        ///
        /// <param name="serviceSid"> The service_sid </param>
        /// <param name="mapSid"> The map_sid </param>
        /// <param name="key"> The key </param>
        /// <param name="data"> The data </param>
        /// <returns> SyncMapItemUpdater capable of executing the update </returns> 
        public static SyncMapItemUpdater Updater(string serviceSid, string mapSid, string key, Object data) {
            return new SyncMapItemUpdater(serviceSid, mapSid, key, data);
        }
    
        /// <summary>
        /// Converts a JSON string into a SyncMapItemResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> SyncMapItemResource object represented by the provided JSON </returns> 
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
    
        /// <returns> The key </returns> 
        public override string GetSid() {
            return this.GetKey();
        }
    
        /// <returns> The key </returns> 
        public string GetKey() {
            return this.key;
        }
    
        /// <returns> The account_sid </returns> 
        public string GetAccountSid() {
            return this.accountSid;
        }
    
        /// <returns> The service_sid </returns> 
        public string GetServiceSid() {
            return this.serviceSid;
        }
    
        /// <returns> The map_sid </returns> 
        public string GetMapSid() {
            return this.mapSid;
        }
    
        /// <returns> The url </returns> 
        public Uri GetUrl() {
            return this.url;
        }
    
        /// <returns> The revision </returns> 
        public string GetRevision() {
            return this.revision;
        }
    
        /// <returns> The data </returns> 
        public Object GetData() {
            return this.data;
        }
    
        /// <returns> The date_created </returns> 
        public DateTime? GetDateCreated() {
            return this.dateCreated;
        }
    
        /// <returns> The date_updated </returns> 
        public DateTime? GetDateUpdated() {
            return this.dateUpdated;
        }
    
        /// <returns> The created_by </returns> 
        public string GetCreatedBy() {
            return this.createdBy;
        }
    }
}
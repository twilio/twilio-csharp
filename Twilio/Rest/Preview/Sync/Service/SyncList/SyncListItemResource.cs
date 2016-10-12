using Newtonsoft.Json;
using System;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Preview.Sync.Service.SyncList {

    public class SyncListItemResource : SidResource {
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
        /// <param name="listSid"> The list_sid </param>
        /// <param name="index"> The index </param>
        /// <returns> SyncListItemFetcher capable of executing the fetch </returns> 
        public static SyncListItemFetcher Fetcher(string serviceSid, string listSid, int? index) {
            return new SyncListItemFetcher(serviceSid, listSid, index);
        }
    
        /// <summary>
        /// delete
        /// </summary>
        ///
        /// <param name="serviceSid"> The service_sid </param>
        /// <param name="listSid"> The list_sid </param>
        /// <param name="index"> The index </param>
        /// <returns> SyncListItemDeleter capable of executing the delete </returns> 
        public static SyncListItemDeleter Deleter(string serviceSid, string listSid, int? index) {
            return new SyncListItemDeleter(serviceSid, listSid, index);
        }
    
        /// <summary>
        /// create
        /// </summary>
        ///
        /// <param name="serviceSid"> The service_sid </param>
        /// <param name="listSid"> The list_sid </param>
        /// <param name="data"> The data </param>
        /// <returns> SyncListItemCreator capable of executing the create </returns> 
        public static SyncListItemCreator Creator(string serviceSid, string listSid, Object data) {
            return new SyncListItemCreator(serviceSid, listSid, data);
        }
    
        /// <summary>
        /// read
        /// </summary>
        ///
        /// <param name="serviceSid"> The service_sid </param>
        /// <param name="listSid"> The list_sid </param>
        /// <returns> SyncListItemReader capable of executing the read </returns> 
        public static SyncListItemReader Reader(string serviceSid, string listSid) {
            return new SyncListItemReader(serviceSid, listSid);
        }
    
        /// <summary>
        /// update
        /// </summary>
        ///
        /// <param name="serviceSid"> The service_sid </param>
        /// <param name="listSid"> The list_sid </param>
        /// <param name="index"> The index </param>
        /// <param name="data"> The data </param>
        /// <returns> SyncListItemUpdater capable of executing the update </returns> 
        public static SyncListItemUpdater Updater(string serviceSid, string listSid, int? index, Object data) {
            return new SyncListItemUpdater(serviceSid, listSid, index, data);
        }
    
        /// <summary>
        /// Converts a JSON string into a SyncListItemResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> SyncListItemResource object represented by the provided JSON </returns> 
        public static SyncListItemResource FromJson(string json) {
            // Convert all checked exceptions to Runtime
            try {
                return JsonConvert.DeserializeObject<SyncListItemResource>(json);
            } catch (JsonException e) {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("index")]
        private readonly int? index;
        [JsonProperty("account_sid")]
        private readonly string accountSid;
        [JsonProperty("service_sid")]
        private readonly string serviceSid;
        [JsonProperty("list_sid")]
        private readonly string listSid;
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
    
        public SyncListItemResource() {
        
        }
    
        private SyncListItemResource([JsonProperty("index")]
                                     int? index, 
                                     [JsonProperty("account_sid")]
                                     string accountSid, 
                                     [JsonProperty("service_sid")]
                                     string serviceSid, 
                                     [JsonProperty("list_sid")]
                                     string listSid, 
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
            this.index = index;
            this.accountSid = accountSid;
            this.serviceSid = serviceSid;
            this.listSid = listSid;
            this.url = url;
            this.revision = revision;
            this.data = data;
            this.dateCreated = MarshalConverter.DateTimeFromString(dateCreated);
            this.dateUpdated = MarshalConverter.DateTimeFromString(dateUpdated);
            this.createdBy = createdBy;
        }
    
        /// <returns> The index </returns> 
        public override string GetSid() {
            return this.GetIndex().ToString();
        }
    
        /// <returns> The index </returns> 
        public int? GetIndex() {
            return this.index;
        }
    
        /// <returns> The account_sid </returns> 
        public string GetAccountSid() {
            return this.accountSid;
        }
    
        /// <returns> The service_sid </returns> 
        public string GetServiceSid() {
            return this.serviceSid;
        }
    
        /// <returns> The list_sid </returns> 
        public string GetListSid() {
            return this.listSid;
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
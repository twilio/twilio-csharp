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
    
        /**
         * fetch
         * 
         * @param serviceSid The service_sid
         * @param listSid The list_sid
         * @param index The index
         * @return SyncListItemFetcher capable of executing the fetch
         */
        public static SyncListItemFetcher Fetch(string serviceSid, string listSid, int? index) {
            return new SyncListItemFetcher(serviceSid, listSid, index);
        }
    
        /**
         * delete
         * 
         * @param serviceSid The service_sid
         * @param listSid The list_sid
         * @param index The index
         * @return SyncListItemDeleter capable of executing the delete
         */
        public static SyncListItemDeleter Delete(string serviceSid, string listSid, int? index) {
            return new SyncListItemDeleter(serviceSid, listSid, index);
        }
    
        /**
         * create
         * 
         * @param serviceSid The service_sid
         * @param listSid The list_sid
         * @param data The data
         * @return SyncListItemCreator capable of executing the create
         */
        public static SyncListItemCreator Create(string serviceSid, string listSid, Object data) {
            return new SyncListItemCreator(serviceSid, listSid, data);
        }
    
        /**
         * read
         * 
         * @param serviceSid The service_sid
         * @param listSid The list_sid
         * @return SyncListItemReader capable of executing the read
         */
        public static SyncListItemReader Read(string serviceSid, string listSid) {
            return new SyncListItemReader(serviceSid, listSid);
        }
    
        /**
         * update
         * 
         * @param serviceSid The service_sid
         * @param listSid The list_sid
         * @param index The index
         * @param data The data
         * @return SyncListItemUpdater capable of executing the update
         */
        public static SyncListItemUpdater Update(string serviceSid, string listSid, int? index, Object data) {
            return new SyncListItemUpdater(serviceSid, listSid, index, data);
        }
    
        /**
         * Converts a JSON string into a SyncListItemResource object
         * 
         * @param json Raw JSON string
         * @return SyncListItemResource object represented by the provided JSON
         */
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
    
        /**
         * @return The index
         */
        public override string GetSid() {
            return this.GetIndex().ToString();
        }
    
        /**
         * @return The index
         */
        public int? GetIndex() {
            return this.index;
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
         * @return The list_sid
         */
        public string GetListSid() {
            return this.listSid;
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
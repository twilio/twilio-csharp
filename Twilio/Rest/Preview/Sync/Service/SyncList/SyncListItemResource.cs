using Newtonsoft.Json;
using System;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Preview.Sync.Service.SyncList {

    public class SyncListItemResource : Resource {
        public sealed class QueryResultOrder : IStringEnum {
            public const string Asc = "asc";
            public const string Desc = "desc";
        
            private string _value;
            
            public QueryResultOrder() { }
            
            public QueryResultOrder(string value) {
                _value = value;
            }
            
            public override string ToString() {
                return _value;
            }
            
            public static implicit operator QueryResultOrder(string value) {
                return new QueryResultOrder(value);
            }
            
            public static implicit operator string(QueryResultOrder value) {
                return value.ToString();
            }
            
            public void FromString(string value) {
                _value = value;
            }
        }
    
        public sealed class QueryFromBoundType : IStringEnum {
            public const string Inclusive = "inclusive";
            public const string Exclusive = "exclusive";
        
            private string _value;
            
            public QueryFromBoundType() { }
            
            public QueryFromBoundType(string value) {
                _value = value;
            }
            
            public override string ToString() {
                return _value;
            }
            
            public static implicit operator QueryFromBoundType(string value) {
                return new QueryFromBoundType(value);
            }
            
            public static implicit operator string(QueryFromBoundType value) {
                return value.ToString();
            }
            
            public void FromString(string value) {
                _value = value;
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
        /// <param name="order"> The order </param>
        /// <param name="from"> The from </param>
        /// <param name="bounds"> The bounds </param>
        /// <returns> SyncListItemReader capable of executing the read </returns> 
        public static SyncListItemReader Reader(string serviceSid, string listSid, SyncListItemResource.QueryResultOrder order=null, string from=null, SyncListItemResource.QueryFromBoundType bounds=null) {
            return new SyncListItemReader(serviceSid, listSid, order:order, from:from, bounds:bounds);
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
        public int? index { get; }
        [JsonProperty("account_sid")]
        public string accountSid { get; }
        [JsonProperty("service_sid")]
        public string serviceSid { get; }
        [JsonProperty("list_sid")]
        public string listSid { get; }
        [JsonProperty("url")]
        public Uri url { get; }
        [JsonProperty("revision")]
        public string revision { get; }
        [JsonProperty("data")]
        public Object data { get; }
        [JsonProperty("date_created")]
        public DateTime? dateCreated { get; }
        [JsonProperty("date_updated")]
        public DateTime? dateUpdated { get; }
        [JsonProperty("created_by")]
        public string createdBy { get; }
    
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
    }
}
using Newtonsoft.Json;
using System;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Preview.Sync.Service.SyncMap 
{

    public class SyncMapItemResource : Resource 
    {
        public sealed class QueryResultOrder : IStringEnum 
        {
            public const string Asc = "asc";
            public const string Desc = "desc";
        
            private string _value;
            
            public QueryResultOrder() {}
            
            public QueryResultOrder(string value)
            {
                _value = value;
            }
            
            public override string ToString()
            {
                return _value;
            }
            
            public static implicit operator QueryResultOrder(string value)
            {
                return new QueryResultOrder(value);
            }
            
            public static implicit operator string(QueryResultOrder value)
            {
                return value.ToString();
            }
            
            public void FromString(string value)
            {
                _value = value;
            }
        }
    
        public sealed class QueryFromBoundType : IStringEnum 
        {
            public const string Inclusive = "inclusive";
            public const string Exclusive = "exclusive";
        
            private string _value;
            
            public QueryFromBoundType() {}
            
            public QueryFromBoundType(string value)
            {
                _value = value;
            }
            
            public override string ToString()
            {
                return _value;
            }
            
            public static implicit operator QueryFromBoundType(string value)
            {
                return new QueryFromBoundType(value);
            }
            
            public static implicit operator string(QueryFromBoundType value)
            {
                return value.ToString();
            }
            
            public void FromString(string value)
            {
                _value = value;
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
        public static SyncMapItemFetcher Fetcher(string serviceSid, string mapSid, string key)
        {
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
        public static SyncMapItemDeleter Deleter(string serviceSid, string mapSid, string key)
        {
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
        public static SyncMapItemCreator Creator(string serviceSid, string mapSid, string key, Object data)
        {
            return new SyncMapItemCreator(serviceSid, mapSid, key, data);
        }
    
        /// <summary>
        /// read
        /// </summary>
        ///
        /// <param name="serviceSid"> The service_sid </param>
        /// <param name="mapSid"> The map_sid </param>
        /// <returns> SyncMapItemReader capable of executing the read </returns> 
        public static SyncMapItemReader Reader(string serviceSid, string mapSid)
        {
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
        public static SyncMapItemUpdater Updater(string serviceSid, string mapSid, string key, Object data)
        {
            return new SyncMapItemUpdater(serviceSid, mapSid, key, data);
        }
    
        /// <summary>
        /// Converts a JSON string into a SyncMapItemResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> SyncMapItemResource object represented by the provided JSON </returns> 
        public static SyncMapItemResource FromJson(string json)
        {
            // Convert all checked exceptions to Runtime
            try
            {
                return JsonConvert.DeserializeObject<SyncMapItemResource>(json);
            }
            catch (JsonException e)
            {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("key")]
        public string key { get; set; }
        [JsonProperty("account_sid")]
        public string accountSid { get; set; }
        [JsonProperty("service_sid")]
        public string serviceSid { get; set; }
        [JsonProperty("map_sid")]
        public string mapSid { get; set; }
        [JsonProperty("url")]
        public Uri url { get; set; }
        [JsonProperty("revision")]
        public string revision { get; set; }
        [JsonProperty("data")]
        public Object data { get; set; }
        [JsonProperty("date_created")]
        public DateTime? dateCreated { get; set; }
        [JsonProperty("date_updated")]
        public DateTime? dateUpdated { get; set; }
        [JsonProperty("created_by")]
        public string createdBy { get; set; }
    
        public SyncMapItemResource()
        {
        
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
                                    string createdBy)
                                    {
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
    }
}
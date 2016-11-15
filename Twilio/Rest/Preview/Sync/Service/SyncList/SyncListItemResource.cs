using Newtonsoft.Json;
using System;
using Twilio.Base;
using Twilio.Converters;
using Twilio.Exceptions;

namespace Twilio.Rest.Preview.Sync.Service.SyncList 
{

    public class SyncListItemResource : Resource 
    {
        public sealed class QueryResultOrderEnum : IStringEnum 
        {
            public const string Asc = "asc";
            public const string Desc = "desc";
        
            private string _value;
            
            public QueryResultOrderEnum() {}
            
            public QueryResultOrderEnum(string value)
            {
                _value = value;
            }
            
            public override string ToString()
            {
                return _value;
            }
            
            public static implicit operator QueryResultOrderEnum(string value)
            {
                return new QueryResultOrderEnum(value);
            }
            
            public static implicit operator string(QueryResultOrderEnum value)
            {
                return value.ToString();
            }
            
            public void FromString(string value)
            {
                _value = value;
            }
        }
    
        public sealed class QueryFromBoundTypeEnum : IStringEnum 
        {
            public const string Inclusive = "inclusive";
            public const string Exclusive = "exclusive";
        
            private string _value;
            
            public QueryFromBoundTypeEnum() {}
            
            public QueryFromBoundTypeEnum(string value)
            {
                _value = value;
            }
            
            public override string ToString()
            {
                return _value;
            }
            
            public static implicit operator QueryFromBoundTypeEnum(string value)
            {
                return new QueryFromBoundTypeEnum(value);
            }
            
            public static implicit operator string(QueryFromBoundTypeEnum value)
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
        /// <param name="listSid"> The list_sid </param>
        /// <param name="index"> The index </param>
        /// <returns> SyncListItemFetcher capable of executing the fetch </returns> 
        public static SyncListItemFetcher Fetcher(string serviceSid, string listSid, int? index)
        {
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
        public static SyncListItemDeleter Deleter(string serviceSid, string listSid, int? index)
        {
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
        public static SyncListItemCreator Creator(string serviceSid, string listSid, Object data)
        {
            return new SyncListItemCreator(serviceSid, listSid, data);
        }
    
        /// <summary>
        /// read
        /// </summary>
        ///
        /// <param name="serviceSid"> The service_sid </param>
        /// <param name="listSid"> The list_sid </param>
        /// <returns> SyncListItemReader capable of executing the read </returns> 
        public static SyncListItemReader Reader(string serviceSid, string listSid)
        {
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
        public static SyncListItemUpdater Updater(string serviceSid, string listSid, int? index, Object data)
        {
            return new SyncListItemUpdater(serviceSid, listSid, index, data);
        }
    
        /// <summary>
        /// Converts a JSON string into a SyncListItemResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> SyncListItemResource object represented by the provided JSON </returns> 
        public static SyncListItemResource FromJson(string json)
        {
            // Convert all checked exceptions to Runtime
            try
            {
                return JsonConvert.DeserializeObject<SyncListItemResource>(json);
            }
            catch (JsonException e)
            {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("index")]
        public int? Index { get; set; }
        [JsonProperty("account_sid")]
        public string AccountSid { get; set; }
        [JsonProperty("service_sid")]
        public string ServiceSid { get; set; }
        [JsonProperty("list_sid")]
        public string ListSid { get; set; }
        [JsonProperty("url")]
        public Uri Url { get; set; }
        [JsonProperty("revision")]
        public string Revision { get; set; }
        [JsonProperty("data")]
        public Object Data { get; set; }
        [JsonProperty("date_created")]
        public DateTime? DateCreated { get; set; }
        [JsonProperty("date_updated")]
        public DateTime? DateUpdated { get; set; }
        [JsonProperty("created_by")]
        public string CreatedBy { get; set; }
    
        public SyncListItemResource()
        {
        
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
                                     string createdBy)
                                     {
            Index = index;
            AccountSid = accountSid;
            ServiceSid = serviceSid;
            ListSid = listSid;
            Url = url;
            Revision = revision;
            Data = data;
            DateCreated = MarshalConverter.DateTimeFromString(dateCreated);
            DateUpdated = MarshalConverter.DateTimeFromString(dateUpdated);
            CreatedBy = createdBy;
        }
    }
}
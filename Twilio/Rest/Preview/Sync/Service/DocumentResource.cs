using Newtonsoft.Json;
using System;
using Twilio.Base;
using Twilio.Converters;
using Twilio.Exceptions;

namespace Twilio.Rest.Preview.Sync.Service 
{

    public class DocumentResource : Resource 
    {
        /// <summary>
        /// fetch
        /// </summary>
        ///
        /// <param name="serviceSid"> The service_sid </param>
        /// <param name="sid"> The sid </param>
        /// <returns> DocumentFetcher capable of executing the fetch </returns> 
        public static DocumentFetcher Fetcher(string serviceSid, string sid)
        {
            return new DocumentFetcher(serviceSid, sid);
        }
    
        /// <summary>
        /// delete
        /// </summary>
        ///
        /// <param name="serviceSid"> The service_sid </param>
        /// <param name="sid"> The sid </param>
        /// <returns> DocumentDeleter capable of executing the delete </returns> 
        public static DocumentDeleter Deleter(string serviceSid, string sid)
        {
            return new DocumentDeleter(serviceSid, sid);
        }
    
        /// <summary>
        /// create
        /// </summary>
        ///
        /// <param name="serviceSid"> The service_sid </param>
        /// <returns> DocumentCreator capable of executing the create </returns> 
        public static DocumentCreator Creator(string serviceSid)
        {
            return new DocumentCreator(serviceSid);
        }
    
        /// <summary>
        /// read
        /// </summary>
        ///
        /// <param name="serviceSid"> The service_sid </param>
        /// <returns> DocumentReader capable of executing the read </returns> 
        public static DocumentReader Reader(string serviceSid)
        {
            return new DocumentReader(serviceSid);
        }
    
        /// <summary>
        /// update
        /// </summary>
        ///
        /// <param name="serviceSid"> The service_sid </param>
        /// <param name="sid"> The sid </param>
        /// <param name="data"> The data </param>
        /// <returns> DocumentUpdater capable of executing the update </returns> 
        public static DocumentUpdater Updater(string serviceSid, string sid, Object data)
        {
            return new DocumentUpdater(serviceSid, sid, data);
        }
    
        /// <summary>
        /// Converts a JSON string into a DocumentResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> DocumentResource object represented by the provided JSON </returns> 
        public static DocumentResource FromJson(string json)
        {
            // Convert all checked exceptions to Runtime
            try
            {
                return JsonConvert.DeserializeObject<DocumentResource>(json);
            }
            catch (JsonException e)
            {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("sid")]
        public string Sid { get; set; }
        [JsonProperty("unique_name")]
        public string UniqueName { get; set; }
        [JsonProperty("account_sid")]
        public string AccountSid { get; set; }
        [JsonProperty("service_sid")]
        public string ServiceSid { get; set; }
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
    
        public DocumentResource()
        {
        
        }
    
        private DocumentResource([JsonProperty("sid")]
                                 string sid, 
                                 [JsonProperty("unique_name")]
                                 string uniqueName, 
                                 [JsonProperty("account_sid")]
                                 string accountSid, 
                                 [JsonProperty("service_sid")]
                                 string serviceSid, 
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
            Sid = sid;
            UniqueName = uniqueName;
            AccountSid = accountSid;
            ServiceSid = serviceSid;
            Url = url;
            Revision = revision;
            Data = data;
            DateCreated = MarshalConverter.DateTimeFromString(dateCreated);
            DateUpdated = MarshalConverter.DateTimeFromString(dateUpdated);
            CreatedBy = createdBy;
        }
    }
}
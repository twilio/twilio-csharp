using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Preview.Sync.Service 
{

    public class SyncListResource : Resource 
    {
        /// <summary>
        /// fetch
        /// </summary>
        ///
        /// <param name="serviceSid"> The service_sid </param>
        /// <param name="sid"> The sid </param>
        /// <returns> SyncListFetcher capable of executing the fetch </returns> 
        public static SyncListFetcher Fetcher(string serviceSid, string sid)
        {
            return new SyncListFetcher(serviceSid, sid);
        }
    
        /// <summary>
        /// delete
        /// </summary>
        ///
        /// <param name="serviceSid"> The service_sid </param>
        /// <param name="sid"> The sid </param>
        /// <returns> SyncListDeleter capable of executing the delete </returns> 
        public static SyncListDeleter Deleter(string serviceSid, string sid)
        {
            return new SyncListDeleter(serviceSid, sid);
        }
    
        /// <summary>
        /// create
        /// </summary>
        ///
        /// <param name="serviceSid"> The service_sid </param>
        /// <returns> SyncListCreator capable of executing the create </returns> 
        public static SyncListCreator Creator(string serviceSid)
        {
            return new SyncListCreator(serviceSid);
        }
    
        /// <summary>
        /// read
        /// </summary>
        ///
        /// <param name="serviceSid"> The service_sid </param>
        /// <returns> SyncListReader capable of executing the read </returns> 
        public static SyncListReader Reader(string serviceSid)
        {
            return new SyncListReader(serviceSid);
        }
    
        /// <summary>
        /// Converts a JSON string into a SyncListResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> SyncListResource object represented by the provided JSON </returns> 
        public static SyncListResource FromJson(string json)
        {
            // Convert all checked exceptions to Runtime
            try
            {
                return JsonConvert.DeserializeObject<SyncListResource>(json);
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
        [JsonProperty("links")]
        public Dictionary<string, string> Links { get; set; }
        [JsonProperty("revision")]
        public string Revision { get; set; }
        [JsonProperty("date_created")]
        public DateTime? DateCreated { get; set; }
        [JsonProperty("date_updated")]
        public DateTime? DateUpdated { get; set; }
        [JsonProperty("created_by")]
        public string CreatedBy { get; set; }
    
        public SyncListResource()
        {
        
        }
    
        private SyncListResource([JsonProperty("sid")]
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
                                 string createdBy)
                                 {
            Sid = sid;
            UniqueName = uniqueName;
            AccountSid = accountSid;
            ServiceSid = serviceSid;
            Url = url;
            Links = links;
            Revision = revision;
            DateCreated = MarshalConverter.DateTimeFromString(dateCreated);
            DateUpdated = MarshalConverter.DateTimeFromString(dateUpdated);
            CreatedBy = createdBy;
        }
    }
}
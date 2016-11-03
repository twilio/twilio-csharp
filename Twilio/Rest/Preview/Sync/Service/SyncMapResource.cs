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

    public class SyncMapResource : Resource 
    {
        /// <summary>
        /// fetch
        /// </summary>
        ///
        /// <param name="serviceSid"> The service_sid </param>
        /// <param name="sid"> The sid </param>
        /// <returns> SyncMapFetcher capable of executing the fetch </returns> 
        public static SyncMapFetcher Fetcher(string serviceSid, string sid)
        {
            return new SyncMapFetcher(serviceSid, sid);
        }
    
        /// <summary>
        /// delete
        /// </summary>
        ///
        /// <param name="serviceSid"> The service_sid </param>
        /// <param name="sid"> The sid </param>
        /// <returns> SyncMapDeleter capable of executing the delete </returns> 
        public static SyncMapDeleter Deleter(string serviceSid, string sid)
        {
            return new SyncMapDeleter(serviceSid, sid);
        }
    
        /// <summary>
        /// create
        /// </summary>
        ///
        /// <param name="serviceSid"> The service_sid </param>
        /// <returns> SyncMapCreator capable of executing the create </returns> 
        public static SyncMapCreator Creator(string serviceSid)
        {
            return new SyncMapCreator(serviceSid);
        }
    
        /// <summary>
        /// read
        /// </summary>
        ///
        /// <param name="serviceSid"> The service_sid </param>
        /// <returns> SyncMapReader capable of executing the read </returns> 
        public static SyncMapReader Reader(string serviceSid)
        {
            return new SyncMapReader(serviceSid);
        }
    
        /// <summary>
        /// Converts a JSON string into a SyncMapResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> SyncMapResource object represented by the provided JSON </returns> 
        public static SyncMapResource FromJson(string json)
        {
            // Convert all checked exceptions to Runtime
            try
            {
                return JsonConvert.DeserializeObject<SyncMapResource>(json);
            }
            catch (JsonException e)
            {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("sid")]
        public string sid { get; set; }
        [JsonProperty("unique_name")]
        public string uniqueName { get; set; }
        [JsonProperty("account_sid")]
        public string accountSid { get; set; }
        [JsonProperty("service_sid")]
        public string serviceSid { get; set; }
        [JsonProperty("url")]
        public Uri url { get; set; }
        [JsonProperty("links")]
        public Dictionary<string, string> links { get; set; }
        [JsonProperty("revision")]
        public string revision { get; set; }
        [JsonProperty("date_created")]
        public DateTime? dateCreated { get; set; }
        [JsonProperty("date_updated")]
        public DateTime? dateUpdated { get; set; }
        [JsonProperty("created_by")]
        public string createdBy { get; set; }
    
        public SyncMapResource()
        {
        
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
                                string createdBy)
                                {
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
    }
}
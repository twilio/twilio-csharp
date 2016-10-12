using Newtonsoft.Json;
using System;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Preview.Sync.Service {

    public class DocumentResource : SidResource {
        /// <summary>
        /// fetch
        /// </summary>
        ///
        /// <param name="serviceSid"> The service_sid </param>
        /// <param name="sid"> The sid </param>
        /// <returns> DocumentFetcher capable of executing the fetch </returns> 
        public static DocumentFetcher Fetcher(string serviceSid, string sid) {
            return new DocumentFetcher(serviceSid, sid);
        }
    
        /// <summary>
        /// delete
        /// </summary>
        ///
        /// <param name="serviceSid"> The service_sid </param>
        /// <param name="sid"> The sid </param>
        /// <returns> DocumentDeleter capable of executing the delete </returns> 
        public static DocumentDeleter Deleter(string serviceSid, string sid) {
            return new DocumentDeleter(serviceSid, sid);
        }
    
        /// <summary>
        /// create
        /// </summary>
        ///
        /// <param name="serviceSid"> The service_sid </param>
        /// <returns> DocumentCreator capable of executing the create </returns> 
        public static DocumentCreator Creator(string serviceSid) {
            return new DocumentCreator(serviceSid);
        }
    
        /// <summary>
        /// read
        /// </summary>
        ///
        /// <param name="serviceSid"> The service_sid </param>
        /// <returns> DocumentReader capable of executing the read </returns> 
        public static DocumentReader Reader(string serviceSid) {
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
        public static DocumentUpdater Updater(string serviceSid, string sid, Object data) {
            return new DocumentUpdater(serviceSid, sid, data);
        }
    
        /// <summary>
        /// Converts a JSON string into a DocumentResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> DocumentResource object represented by the provided JSON </returns> 
        public static DocumentResource FromJson(string json) {
            // Convert all checked exceptions to Runtime
            try {
                return JsonConvert.DeserializeObject<DocumentResource>(json);
            } catch (JsonException e) {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("sid")]
        private readonly string sid;
        [JsonProperty("unique_name")]
        private readonly string uniqueName;
        [JsonProperty("account_sid")]
        private readonly string accountSid;
        [JsonProperty("service_sid")]
        private readonly string serviceSid;
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
    
        public DocumentResource() {
        
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
                                 string createdBy) {
            this.sid = sid;
            this.uniqueName = uniqueName;
            this.accountSid = accountSid;
            this.serviceSid = serviceSid;
            this.url = url;
            this.revision = revision;
            this.data = data;
            this.dateCreated = MarshalConverter.DateTimeFromString(dateCreated);
            this.dateUpdated = MarshalConverter.DateTimeFromString(dateUpdated);
            this.createdBy = createdBy;
        }
    
        /// <returns> The sid </returns> 
        public override string GetSid() {
            return this.sid;
        }
    
        /// <returns> The unique_name </returns> 
        public string GetUniqueName() {
            return this.uniqueName;
        }
    
        /// <returns> The account_sid </returns> 
        public string GetAccountSid() {
            return this.accountSid;
        }
    
        /// <returns> The service_sid </returns> 
        public string GetServiceSid() {
            return this.serviceSid;
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
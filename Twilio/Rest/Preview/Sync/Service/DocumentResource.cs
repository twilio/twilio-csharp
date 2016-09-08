using Newtonsoft.Json;
using System;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Preview.Sync.Service {

    public class DocumentResource : SidResource {
        /**
         * fetch
         * 
         * @param serviceSid The service_sid
         * @param sid The sid
         * @return DocumentFetcher capable of executing the fetch
         */
        public static DocumentFetcher Fetch(string serviceSid, string sid) {
            return new DocumentFetcher(serviceSid, sid);
        }
    
        /**
         * delete
         * 
         * @param serviceSid The service_sid
         * @param sid The sid
         * @return DocumentDeleter capable of executing the delete
         */
        public static DocumentDeleter Delete(string serviceSid, string sid) {
            return new DocumentDeleter(serviceSid, sid);
        }
    
        /**
         * create
         * 
         * @param serviceSid The service_sid
         * @return DocumentCreator capable of executing the create
         */
        public static DocumentCreator Create(string serviceSid) {
            return new DocumentCreator(serviceSid);
        }
    
        /**
         * read
         * 
         * @param serviceSid The service_sid
         * @return DocumentReader capable of executing the read
         */
        public static DocumentReader Read(string serviceSid) {
            return new DocumentReader(serviceSid);
        }
    
        /**
         * update
         * 
         * @param serviceSid The service_sid
         * @param sid The sid
         * @param data The data
         * @return DocumentUpdater capable of executing the update
         */
        public static DocumentUpdater Update(string serviceSid, string sid, Object data) {
            return new DocumentUpdater(serviceSid, sid, data);
        }
    
        /**
         * Converts a JSON string into a DocumentResource object
         * 
         * @param json Raw JSON string
         * @return DocumentResource object represented by the provided JSON
         */
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
    
        /**
         * @return The sid
         */
        public override string GetSid() {
            return this.sid;
        }
    
        /**
         * @return The unique_name
         */
        public string GetUniqueName() {
            return this.uniqueName;
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
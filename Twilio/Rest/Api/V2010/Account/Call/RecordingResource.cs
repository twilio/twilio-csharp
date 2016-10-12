using Newtonsoft.Json;
using System;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Api.V2010.Account.Call {

    public class RecordingResource : SidResource {
        /// <summary>
        /// fetch
        /// </summary>
        ///
        /// <param name="accountSid"> The account_sid </param>
        /// <param name="callSid"> The call_sid </param>
        /// <param name="sid"> The sid </param>
        /// <returns> RecordingFetcher capable of executing the fetch </returns> 
        public static RecordingFetcher Fetcher(string accountSid, string callSid, string sid) {
            return new RecordingFetcher(accountSid, callSid, sid);
        }
    
        /// <summary>
        /// Create a RecordingFetcher to execute fetch.
        /// </summary>
        ///
        /// <param name="callSid"> The call_sid </param>
        /// <param name="sid"> The sid </param>
        /// <returns> RecordingFetcher capable of executing the fetch </returns> 
        public static RecordingFetcher Fetcher(string callSid, 
                                               string sid) {
            return new RecordingFetcher(callSid, sid);
        }
    
        /// <summary>
        /// delete
        /// </summary>
        ///
        /// <param name="accountSid"> The account_sid </param>
        /// <param name="callSid"> The call_sid </param>
        /// <param name="sid"> The sid </param>
        /// <returns> RecordingDeleter capable of executing the delete </returns> 
        public static RecordingDeleter Deleter(string accountSid, string callSid, string sid) {
            return new RecordingDeleter(accountSid, callSid, sid);
        }
    
        /// <summary>
        /// Create a RecordingDeleter to execute delete.
        /// </summary>
        ///
        /// <param name="callSid"> The call_sid </param>
        /// <param name="sid"> The sid </param>
        /// <returns> RecordingDeleter capable of executing the delete </returns> 
        public static RecordingDeleter Deleter(string callSid, 
                                               string sid) {
            return new RecordingDeleter(callSid, sid);
        }
    
        /// <summary>
        /// read
        /// </summary>
        ///
        /// <param name="accountSid"> The account_sid </param>
        /// <param name="callSid"> The call_sid </param>
        /// <returns> RecordingReader capable of executing the read </returns> 
        public static RecordingReader Reader(string accountSid, string callSid) {
            return new RecordingReader(accountSid, callSid);
        }
    
        /// <summary>
        /// Create a RecordingReader to execute read.
        /// </summary>
        ///
        /// <param name="callSid"> The call_sid </param>
        /// <returns> RecordingReader capable of executing the read </returns> 
        public static RecordingReader Reader(string callSid) {
            return new RecordingReader(callSid);
        }
    
        /// <summary>
        /// Converts a JSON string into a RecordingResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> RecordingResource object represented by the provided JSON </returns> 
        public static RecordingResource FromJson(string json) {
            // Convert all checked exceptions to Runtime
            try {
                return JsonConvert.DeserializeObject<RecordingResource>(json);
            } catch (JsonException e) {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("account_sid")]
        private readonly string accountSid;
        [JsonProperty("api_version")]
        private readonly string apiVersion;
        [JsonProperty("call_sid")]
        private readonly string callSid;
        [JsonProperty("date_created")]
        private readonly DateTime? dateCreated;
        [JsonProperty("date_updated")]
        private readonly DateTime? dateUpdated;
        [JsonProperty("duration")]
        private readonly string duration;
        [JsonProperty("sid")]
        private readonly string sid;
        [JsonProperty("uri")]
        private readonly string uri;
    
        public RecordingResource() {
        
        }
    
        private RecordingResource([JsonProperty("account_sid")]
                                  string accountSid, 
                                  [JsonProperty("api_version")]
                                  string apiVersion, 
                                  [JsonProperty("call_sid")]
                                  string callSid, 
                                  [JsonProperty("date_created")]
                                  string dateCreated, 
                                  [JsonProperty("date_updated")]
                                  string dateUpdated, 
                                  [JsonProperty("duration")]
                                  string duration, 
                                  [JsonProperty("sid")]
                                  string sid, 
                                  [JsonProperty("uri")]
                                  string uri) {
            this.accountSid = accountSid;
            this.apiVersion = apiVersion;
            this.callSid = callSid;
            this.dateCreated = MarshalConverter.DateTimeFromString(dateCreated);
            this.dateUpdated = MarshalConverter.DateTimeFromString(dateUpdated);
            this.duration = duration;
            this.sid = sid;
            this.uri = uri;
        }
    
        /// <returns> The account_sid </returns> 
        public string GetAccountSid() {
            return this.accountSid;
        }
    
        /// <returns> The api_version </returns> 
        public string GetApiVersion() {
            return this.apiVersion;
        }
    
        /// <returns> The call_sid </returns> 
        public string GetCallSid() {
            return this.callSid;
        }
    
        /// <returns> The date_created </returns> 
        public DateTime? GetDateCreated() {
            return this.dateCreated;
        }
    
        /// <returns> The date_updated </returns> 
        public DateTime? GetDateUpdated() {
            return this.dateUpdated;
        }
    
        /// <returns> The duration </returns> 
        public string GetDuration() {
            return this.duration;
        }
    
        /// <returns> The sid </returns> 
        public override string GetSid() {
            return this.sid;
        }
    
        /// <returns> The uri </returns> 
        public string GetUri() {
            return this.uri;
        }
    }
}
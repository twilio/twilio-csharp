using Newtonsoft.Json;
using System;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Api.V2010.Account {

    public class ConferenceResource : SidResource {
        public sealed class Status : IStringEnum {
            public const string INIT="init";
            public const string IN_PROGRESS="in-progress";
            public const string COMPLETED="completed";
        
            private string value;
            
            public Status() { }
            
            public Status(string value) {
                this.value = value;
            }
            
            public override string ToString() {
                return value;
            }
            
            public static implicit operator Status(string value) {
                return new Status(value);
            }
            
            public static implicit operator string(Status value) {
                return value.ToString();
            }
            
            public void FromString(string value) {
                this.value = value;
            }
        }
    
        /// <summary>
        /// Fetch an instance of a conference
        /// </summary>
        ///
        /// <param name="accountSid"> The account_sid </param>
        /// <param name="sid"> Fetch by unique conference Sid </param>
        /// <returns> ConferenceFetcher capable of executing the fetch </returns> 
        public static ConferenceFetcher Fetcher(string accountSid, string sid) {
            return new ConferenceFetcher(accountSid, sid);
        }
    
        /// <summary>
        /// Create a ConferenceFetcher to execute fetch.
        /// </summary>
        ///
        /// <param name="sid"> Fetch by unique conference Sid </param>
        /// <returns> ConferenceFetcher capable of executing the fetch </returns> 
        public static ConferenceFetcher Fetcher(string sid) {
            return new ConferenceFetcher(sid);
        }
    
        /// <summary>
        /// Retrieve a list of conferences belonging to the account used to make the request
        /// </summary>
        ///
        /// <param name="accountSid"> The account_sid </param>
        /// <returns> ConferenceReader capable of executing the read </returns> 
        public static ConferenceReader Reader(string accountSid) {
            return new ConferenceReader(accountSid);
        }
    
        /// <summary>
        /// Create a ConferenceReader to execute read.
        /// </summary>
        ///
        /// <returns> ConferenceReader capable of executing the read </returns> 
        public static ConferenceReader Reader() {
            return new ConferenceReader();
        }
    
        /// <summary>
        /// Converts a JSON string into a ConferenceResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> ConferenceResource object represented by the provided JSON </returns> 
        public static ConferenceResource FromJson(string json) {
            // Convert all checked exceptions to Runtime
            try {
                return JsonConvert.DeserializeObject<ConferenceResource>(json);
            } catch (JsonException e) {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("account_sid")]
        private readonly string accountSid;
        [JsonProperty("date_created")]
        private readonly DateTime? dateCreated;
        [JsonProperty("date_updated")]
        private readonly DateTime? dateUpdated;
        [JsonProperty("api_version")]
        private readonly string apiVersion;
        [JsonProperty("friendly_name")]
        private readonly string friendlyName;
        [JsonProperty("sid")]
        private readonly string sid;
        [JsonProperty("status")]
        [JsonConverter(typeof(StringEnumConverter))]
        private readonly ConferenceResource.Status status;
        [JsonProperty("uri")]
        private readonly string uri;
    
        public ConferenceResource() {
        
        }
    
        private ConferenceResource([JsonProperty("account_sid")]
                                   string accountSid, 
                                   [JsonProperty("date_created")]
                                   string dateCreated, 
                                   [JsonProperty("date_updated")]
                                   string dateUpdated, 
                                   [JsonProperty("api_version")]
                                   string apiVersion, 
                                   [JsonProperty("friendly_name")]
                                   string friendlyName, 
                                   [JsonProperty("sid")]
                                   string sid, 
                                   [JsonProperty("status")]
                                   ConferenceResource.Status status, 
                                   [JsonProperty("uri")]
                                   string uri) {
            this.accountSid = accountSid;
            this.dateCreated = MarshalConverter.DateTimeFromString(dateCreated);
            this.dateUpdated = MarshalConverter.DateTimeFromString(dateUpdated);
            this.apiVersion = apiVersion;
            this.friendlyName = friendlyName;
            this.sid = sid;
            this.status = status;
            this.uri = uri;
        }
    
        /// <returns> The unique sid that identifies this account </returns> 
        public string GetAccountSid() {
            return this.accountSid;
        }
    
        /// <returns> The date this resource was created </returns> 
        public DateTime? GetDateCreated() {
            return this.dateCreated;
        }
    
        /// <returns> The date this resource was last updated </returns> 
        public DateTime? GetDateUpdated() {
            return this.dateUpdated;
        }
    
        /// <returns> The api_version </returns> 
        public string GetApiVersion() {
            return this.apiVersion;
        }
    
        /// <returns> A human readable description of this resource </returns> 
        public string GetFriendlyName() {
            return this.friendlyName;
        }
    
        /// <returns> A string that uniquely identifies this conference </returns> 
        public override string GetSid() {
            return this.sid;
        }
    
        /// <returns> The status of the conference </returns> 
        public ConferenceResource.Status GetStatus() {
            return this.status;
        }
    
        /// <returns> The URI for this resource </returns> 
        public string GetUri() {
            return this.uri;
        }
    }
}
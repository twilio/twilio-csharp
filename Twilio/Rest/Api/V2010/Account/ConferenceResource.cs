using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Api.V2010.Account {

    public class ConferenceResource : Resource {
        public sealed class Status : IStringEnum {
            public const string Init = "init";
            public const string InProgress = "in-progress";
            public const string Completed = "completed";
        
            private string _value;
            
            public Status() { }
            
            public Status(string value) {
                _value = value;
            }
            
            public override string ToString() {
                return _value;
            }
            
            public static implicit operator Status(string value) {
                return new Status(value);
            }
            
            public static implicit operator string(Status value) {
                return value.ToString();
            }
            
            public void FromString(string value) {
                _value = value;
            }
        }
    
        /// <summary>
        /// Fetch an instance of a conference
        /// </summary>
        ///
        /// <param name="sid"> Fetch by unique conference Sid </param>
        /// <param name="accountSid"> The account_sid </param>
        /// <returns> ConferenceFetcher capable of executing the fetch </returns> 
        public static ConferenceFetcher Fetcher(string sid, string accountSid=null) {
            return new ConferenceFetcher(sid, accountSid:accountSid);
        }
    
        /// <summary>
        /// Retrieve a list of conferences belonging to the account used to make the request
        /// </summary>
        ///
        /// <param name="accountSid"> The account_sid </param>
        /// <param name="dateCreated"> Filter by date created </param>
        /// <param name="dateUpdated"> Filter by date updated </param>
        /// <param name="friendlyName"> Filter by friendly name </param>
        /// <param name="status"> The status of the conference </param>
        /// <returns> ConferenceReader capable of executing the read </returns> 
        public static ConferenceReader Reader(string accountSid=null, string dateCreated=null, string dateUpdated=null, string friendlyName=null, ConferenceResource.Status status=null) {
            return new ConferenceReader(accountSid:accountSid, dateCreated:dateCreated, dateUpdated:dateUpdated, friendlyName:friendlyName, status:status);
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
        public string accountSid { get; }
        [JsonProperty("date_created")]
        public DateTime? dateCreated { get; }
        [JsonProperty("date_updated")]
        public DateTime? dateUpdated { get; }
        [JsonProperty("api_version")]
        public string apiVersion { get; }
        [JsonProperty("friendly_name")]
        public string friendlyName { get; }
        [JsonProperty("sid")]
        public string sid { get; }
        [JsonProperty("status")]
        [JsonConverter(typeof(StringEnumConverter))]
        public ConferenceResource.Status status { get; }
        [JsonProperty("uri")]
        public string uri { get; }
        [JsonProperty("subresource_uris")]
        public Dictionary<string, string> subresourceUris { get; }
    
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
                                   string uri, 
                                   [JsonProperty("subresource_uris")]
                                   Dictionary<string, string> subresourceUris) {
            this.accountSid = accountSid;
            this.dateCreated = MarshalConverter.DateTimeFromString(dateCreated);
            this.dateUpdated = MarshalConverter.DateTimeFromString(dateUpdated);
            this.apiVersion = apiVersion;
            this.friendlyName = friendlyName;
            this.sid = sid;
            this.status = status;
            this.uri = uri;
            this.subresourceUris = subresourceUris;
        }
    }
}
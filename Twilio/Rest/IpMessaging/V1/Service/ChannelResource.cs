using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.IpMessaging.V1.Service {

    public class ChannelResource : SidResource {
        public sealed class ChannelType : IStringEnum {
            public const string PUBLIC="public";
            public const string PRIVATE="private";
        
            private string value;
            
            public ChannelType() { }
            
            public ChannelType(string value) {
                this.value = value;
            }
            
            public override string ToString() {
                return value;
            }
            
            public static implicit operator ChannelType(string value) {
                return new ChannelType(value);
            }
            
            public static implicit operator string(ChannelType value) {
                return value.ToString();
            }
            
            public void FromString(string value) {
                this.value = value;
            }
        }
    
        /// <summary>
        /// fetch
        /// </summary>
        ///
        /// <param name="serviceSid"> The service_sid </param>
        /// <param name="sid"> The sid </param>
        /// <returns> ChannelFetcher capable of executing the fetch </returns> 
        public static ChannelFetcher Fetcher(string serviceSid, string sid) {
            return new ChannelFetcher(serviceSid, sid);
        }
    
        /// <summary>
        /// delete
        /// </summary>
        ///
        /// <param name="serviceSid"> The service_sid </param>
        /// <param name="sid"> The sid </param>
        /// <returns> ChannelDeleter capable of executing the delete </returns> 
        public static ChannelDeleter Deleter(string serviceSid, string sid) {
            return new ChannelDeleter(serviceSid, sid);
        }
    
        /// <summary>
        /// create
        /// </summary>
        ///
        /// <param name="serviceSid"> The service_sid </param>
        /// <returns> ChannelCreator capable of executing the create </returns> 
        public static ChannelCreator Creator(string serviceSid) {
            return new ChannelCreator(serviceSid);
        }
    
        /// <summary>
        /// read
        /// </summary>
        ///
        /// <param name="serviceSid"> The service_sid </param>
        /// <returns> ChannelReader capable of executing the read </returns> 
        public static ChannelReader Reader(string serviceSid) {
            return new ChannelReader(serviceSid);
        }
    
        /// <summary>
        /// update
        /// </summary>
        ///
        /// <param name="serviceSid"> The service_sid </param>
        /// <param name="sid"> The sid </param>
        /// <returns> ChannelUpdater capable of executing the update </returns> 
        public static ChannelUpdater Updater(string serviceSid, string sid) {
            return new ChannelUpdater(serviceSid, sid);
        }
    
        /// <summary>
        /// Converts a JSON string into a ChannelResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> ChannelResource object represented by the provided JSON </returns> 
        public static ChannelResource FromJson(string json) {
            // Convert all checked exceptions to Runtime
            try {
                return JsonConvert.DeserializeObject<ChannelResource>(json);
            } catch (JsonException e) {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("sid")]
        private readonly string sid;
        [JsonProperty("account_sid")]
        private readonly string accountSid;
        [JsonProperty("service_sid")]
        private readonly string serviceSid;
        [JsonProperty("friendly_name")]
        private readonly string friendlyName;
        [JsonProperty("unique_name")]
        private readonly string uniqueName;
        [JsonProperty("attributes")]
        private readonly string attributes;
        [JsonProperty("type")]
        [JsonConverter(typeof(StringEnumConverter))]
        private readonly ChannelResource.ChannelType type;
        [JsonProperty("date_created")]
        private readonly DateTime? dateCreated;
        [JsonProperty("date_updated")]
        private readonly DateTime? dateUpdated;
        [JsonProperty("created_by")]
        private readonly string createdBy;
        [JsonProperty("url")]
        private readonly Uri url;
        [JsonProperty("links")]
        private readonly Dictionary<string, string> links;
    
        public ChannelResource() {
        
        }
    
        private ChannelResource([JsonProperty("sid")]
                                string sid, 
                                [JsonProperty("account_sid")]
                                string accountSid, 
                                [JsonProperty("service_sid")]
                                string serviceSid, 
                                [JsonProperty("friendly_name")]
                                string friendlyName, 
                                [JsonProperty("unique_name")]
                                string uniqueName, 
                                [JsonProperty("attributes")]
                                string attributes, 
                                [JsonProperty("type")]
                                ChannelResource.ChannelType type, 
                                [JsonProperty("date_created")]
                                string dateCreated, 
                                [JsonProperty("date_updated")]
                                string dateUpdated, 
                                [JsonProperty("created_by")]
                                string createdBy, 
                                [JsonProperty("url")]
                                Uri url, 
                                [JsonProperty("links")]
                                Dictionary<string, string> links) {
            this.sid = sid;
            this.accountSid = accountSid;
            this.serviceSid = serviceSid;
            this.friendlyName = friendlyName;
            this.uniqueName = uniqueName;
            this.attributes = attributes;
            this.type = type;
            this.dateCreated = MarshalConverter.DateTimeFromString(dateCreated);
            this.dateUpdated = MarshalConverter.DateTimeFromString(dateUpdated);
            this.createdBy = createdBy;
            this.url = url;
            this.links = links;
        }
    
        /// <returns> The sid </returns> 
        public override string GetSid() {
            return this.sid;
        }
    
        /// <returns> The account_sid </returns> 
        public string GetAccountSid() {
            return this.accountSid;
        }
    
        /// <returns> The service_sid </returns> 
        public string GetServiceSid() {
            return this.serviceSid;
        }
    
        /// <returns> The friendly_name </returns> 
        public string GetFriendlyName() {
            return this.friendlyName;
        }
    
        /// <returns> The unique_name </returns> 
        public string GetUniqueName() {
            return this.uniqueName;
        }
    
        /// <returns> The attributes </returns> 
        public string GetAttributes() {
            return this.attributes;
        }
    
        /// <returns> The type </returns> 
        public ChannelResource.ChannelType GetChannelType() {
            return this.type;
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
    
        /// <returns> The url </returns> 
        public Uri GetUrl() {
            return this.url;
        }
    
        /// <returns> The links </returns> 
        public Dictionary<string, string> GetLinks() {
            return this.links;
        }
    }
}
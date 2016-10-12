using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Notify.V1.Service {

    public class BindingResource : SidResource {
        public sealed class BindingType : IStringEnum {
            public const string APN="apn";
            public const string GCM="gcm";
            public const string SMS="sms";
            public const string FACEBOOK_MESSENGER="facebook-messenger";
        
            private string value;
            
            public BindingType() { }
            
            public BindingType(string value) {
                this.value = value;
            }
            
            public override string ToString() {
                return value;
            }
            
            public static implicit operator BindingType(string value) {
                return new BindingType(value);
            }
            
            public static implicit operator string(BindingType value) {
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
        /// <returns> BindingFetcher capable of executing the fetch </returns> 
        public static BindingFetcher Fetcher(string serviceSid, string sid) {
            return new BindingFetcher(serviceSid, sid);
        }
    
        /// <summary>
        /// delete
        /// </summary>
        ///
        /// <param name="serviceSid"> The service_sid </param>
        /// <param name="sid"> The sid </param>
        /// <returns> BindingDeleter capable of executing the delete </returns> 
        public static BindingDeleter Deleter(string serviceSid, string sid) {
            return new BindingDeleter(serviceSid, sid);
        }
    
        /// <summary>
        /// create
        /// </summary>
        ///
        /// <param name="serviceSid"> The service_sid </param>
        /// <param name="endpoint"> The endpoint </param>
        /// <param name="identity"> The identity </param>
        /// <param name="bindingType"> The binding_type </param>
        /// <param name="address"> The address </param>
        /// <returns> BindingCreator capable of executing the create </returns> 
        public static BindingCreator Creator(string serviceSid, string endpoint, string identity, BindingResource.BindingType bindingType, string address) {
            return new BindingCreator(serviceSid, endpoint, identity, bindingType, address);
        }
    
        /// <summary>
        /// read
        /// </summary>
        ///
        /// <param name="serviceSid"> The service_sid </param>
        /// <returns> BindingReader capable of executing the read </returns> 
        public static BindingReader Reader(string serviceSid) {
            return new BindingReader(serviceSid);
        }
    
        /// <summary>
        /// Converts a JSON string into a BindingResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> BindingResource object represented by the provided JSON </returns> 
        public static BindingResource FromJson(string json) {
            // Convert all checked exceptions to Runtime
            try {
                return JsonConvert.DeserializeObject<BindingResource>(json);
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
        [JsonProperty("date_created")]
        private readonly DateTime? dateCreated;
        [JsonProperty("date_updated")]
        private readonly DateTime? dateUpdated;
        [JsonProperty("notification_protocol_version")]
        private readonly string notificationProtocolVersion;
        [JsonProperty("endpoint")]
        private readonly string endpoint;
        [JsonProperty("identity")]
        private readonly string identity;
        [JsonProperty("binding_type")]
        private readonly string bindingType;
        [JsonProperty("address")]
        private readonly string address;
        [JsonProperty("tags")]
        private readonly List<string> tags;
        [JsonProperty("url")]
        private readonly Uri url;
    
        public BindingResource() {
        
        }
    
        private BindingResource([JsonProperty("sid")]
                                string sid, 
                                [JsonProperty("account_sid")]
                                string accountSid, 
                                [JsonProperty("service_sid")]
                                string serviceSid, 
                                [JsonProperty("date_created")]
                                string dateCreated, 
                                [JsonProperty("date_updated")]
                                string dateUpdated, 
                                [JsonProperty("notification_protocol_version")]
                                string notificationProtocolVersion, 
                                [JsonProperty("endpoint")]
                                string endpoint, 
                                [JsonProperty("identity")]
                                string identity, 
                                [JsonProperty("binding_type")]
                                string bindingType, 
                                [JsonProperty("address")]
                                string address, 
                                [JsonProperty("tags")]
                                List<string> tags, 
                                [JsonProperty("url")]
                                Uri url) {
            this.sid = sid;
            this.accountSid = accountSid;
            this.serviceSid = serviceSid;
            this.dateCreated = MarshalConverter.DateTimeFromString(dateCreated);
            this.dateUpdated = MarshalConverter.DateTimeFromString(dateUpdated);
            this.notificationProtocolVersion = notificationProtocolVersion;
            this.endpoint = endpoint;
            this.identity = identity;
            this.bindingType = bindingType;
            this.address = address;
            this.tags = tags;
            this.url = url;
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
    
        /// <returns> The date_created </returns> 
        public DateTime? GetDateCreated() {
            return this.dateCreated;
        }
    
        /// <returns> The date_updated </returns> 
        public DateTime? GetDateUpdated() {
            return this.dateUpdated;
        }
    
        /// <returns> The notification_protocol_version </returns> 
        public string GetNotificationProtocolVersion() {
            return this.notificationProtocolVersion;
        }
    
        /// <returns> The endpoint </returns> 
        public string GetEndpoint() {
            return this.endpoint;
        }
    
        /// <returns> The identity </returns> 
        public string GetIdentity() {
            return this.identity;
        }
    
        /// <returns> The binding_type </returns> 
        public string GetBindingType() {
            return this.bindingType;
        }
    
        /// <returns> The address </returns> 
        public string GetAddress() {
            return this.address;
        }
    
        /// <returns> The tags </returns> 
        public List<string> GetTags() {
            return this.tags;
        }
    
        /// <returns> The url </returns> 
        public Uri GetUrl() {
            return this.url;
        }
    }
}
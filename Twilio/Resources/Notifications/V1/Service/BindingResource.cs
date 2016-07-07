using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Creators.Notifications.V1.Service;
using Twilio.Deleters.Notifications.V1.Service;
using Twilio.Exceptions;
using Twilio.Fetchers.Notifications.V1.Service;
using Twilio.Http;
using Twilio.Readers.Notifications.V1.Service;
using Twilio.Resources;

namespace Twilio.Resources.Notifications.V1.Service {

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
    
        /**
         * fetch
         * 
         * @param serviceSid The service_sid
         * @param sid The sid
         * @return BindingFetcher capable of executing the fetch
         */
        public static BindingFetcher Fetch(string serviceSid, string sid) {
            return new BindingFetcher(serviceSid, sid);
        }
    
        /**
         * delete
         * 
         * @param serviceSid The service_sid
         * @param sid The sid
         * @return BindingDeleter capable of executing the delete
         */
        public static BindingDeleter Delete(string serviceSid, string sid) {
            return new BindingDeleter(serviceSid, sid);
        }
    
        /**
         * create
         * 
         * @param serviceSid The service_sid
         * @param endpoint The endpoint
         * @param identity The identity
         * @param bindingType The binding_type
         * @param address The address
         * @return BindingCreator capable of executing the create
         */
        public static BindingCreator Create(string serviceSid, string endpoint, string identity, BindingResource.BindingType bindingType, string address) {
            return new BindingCreator(serviceSid, endpoint, identity, bindingType, address);
        }
    
        /**
         * read
         * 
         * @param serviceSid The service_sid
         * @return BindingReader capable of executing the read
         */
        public static BindingReader Read(string serviceSid) {
            return new BindingReader(serviceSid);
        }
    
        /**
         * Converts a JSON string into a BindingResource object
         * 
         * @param json Raw JSON string
         * @return BindingResource object represented by the provided JSON
         */
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
    
        /**
         * @return The sid
         */
        public override string GetSid() {
            return this.sid;
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
         * @return The notification_protocol_version
         */
        public string GetNotificationProtocolVersion() {
            return this.notificationProtocolVersion;
        }
    
        /**
         * @return The endpoint
         */
        public string GetEndpoint() {
            return this.endpoint;
        }
    
        /**
         * @return The identity
         */
        public string GetIdentity() {
            return this.identity;
        }
    
        /**
         * @return The binding_type
         */
        public string GetBindingType() {
            return this.bindingType;
        }
    
        /**
         * @return The address
         */
        public string GetAddress() {
            return this.address;
        }
    
        /**
         * @return The tags
         */
        public List<string> GetTags() {
            return this.tags;
        }
    
        /**
         * @return The url
         */
        public Uri GetUrl() {
            return this.url;
        }
    }
}
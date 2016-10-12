using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Notify.V1.Service {

    public class NotificationResource : Resource {
        public sealed class Priority : IStringEnum {
            public const string HIGH="high";
            public const string LOW="low";
        
            private string value;
            
            public Priority() { }
            
            public Priority(string value) {
                this.value = value;
            }
            
            public override string ToString() {
                return value;
            }
            
            public static implicit operator Priority(string value) {
                return new Priority(value);
            }
            
            public static implicit operator string(Priority value) {
                return value.ToString();
            }
            
            public void FromString(string value) {
                this.value = value;
            }
        }
    
        /// <summary>
        /// create
        /// </summary>
        ///
        /// <param name="serviceSid"> The service_sid </param>
        /// <returns> NotificationCreator capable of executing the create </returns> 
        public static NotificationCreator Creator(string serviceSid) {
            return new NotificationCreator(serviceSid);
        }
    
        /// <summary>
        /// Converts a JSON string into a NotificationResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> NotificationResource object represented by the provided JSON </returns> 
        public static NotificationResource FromJson(string json) {
            // Convert all checked exceptions to Runtime
            try {
                return JsonConvert.DeserializeObject<NotificationResource>(json);
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
        [JsonProperty("identities")]
        private readonly List<string> identities;
        [JsonProperty("tags")]
        private readonly List<string> tags;
        [JsonProperty("priority")]
        [JsonConverter(typeof(StringEnumConverter))]
        private readonly NotificationResource.Priority priority;
        [JsonProperty("ttl")]
        private readonly int? ttl;
        [JsonProperty("title")]
        private readonly string title;
        [JsonProperty("body")]
        private readonly string body;
        [JsonProperty("sound")]
        private readonly string sound;
        [JsonProperty("action")]
        private readonly string action;
        [JsonProperty("data")]
        private readonly Object data;
        [JsonProperty("apn")]
        private readonly Object apn;
        [JsonProperty("gcm")]
        private readonly Object gcm;
        [JsonProperty("sms")]
        private readonly Object sms;
        [JsonProperty("facebook_messenger")]
        private readonly Object facebookMessenger;
    
        public NotificationResource() {
        
        }
    
        private NotificationResource([JsonProperty("sid")]
                                     string sid, 
                                     [JsonProperty("account_sid")]
                                     string accountSid, 
                                     [JsonProperty("service_sid")]
                                     string serviceSid, 
                                     [JsonProperty("date_created")]
                                     string dateCreated, 
                                     [JsonProperty("identities")]
                                     List<string> identities, 
                                     [JsonProperty("tags")]
                                     List<string> tags, 
                                     [JsonProperty("priority")]
                                     NotificationResource.Priority priority, 
                                     [JsonProperty("ttl")]
                                     int? ttl, 
                                     [JsonProperty("title")]
                                     string title, 
                                     [JsonProperty("body")]
                                     string body, 
                                     [JsonProperty("sound")]
                                     string sound, 
                                     [JsonProperty("action")]
                                     string action, 
                                     [JsonProperty("data")]
                                     Object data, 
                                     [JsonProperty("apn")]
                                     Object apn, 
                                     [JsonProperty("gcm")]
                                     Object gcm, 
                                     [JsonProperty("sms")]
                                     Object sms, 
                                     [JsonProperty("facebook_messenger")]
                                     Object facebookMessenger) {
            this.sid = sid;
            this.accountSid = accountSid;
            this.serviceSid = serviceSid;
            this.dateCreated = MarshalConverter.DateTimeFromString(dateCreated);
            this.identities = identities;
            this.tags = tags;
            this.priority = priority;
            this.ttl = ttl;
            this.title = title;
            this.body = body;
            this.sound = sound;
            this.action = action;
            this.data = data;
            this.apn = apn;
            this.gcm = gcm;
            this.sms = sms;
            this.facebookMessenger = facebookMessenger;
        }
    
        /// <returns> The sid </returns> 
        public string GetSid() {
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
    
        /// <returns> The identities </returns> 
        public List<string> GetIdentities() {
            return this.identities;
        }
    
        /// <returns> The tags </returns> 
        public List<string> GetTags() {
            return this.tags;
        }
    
        /// <returns> The priority </returns> 
        public NotificationResource.Priority GetPriority() {
            return this.priority;
        }
    
        /// <returns> The ttl </returns> 
        public int? GetTtl() {
            return this.ttl;
        }
    
        /// <returns> The title </returns> 
        public string GetTitle() {
            return this.title;
        }
    
        /// <returns> The body </returns> 
        public string GetBody() {
            return this.body;
        }
    
        /// <returns> The sound </returns> 
        public string GetSound() {
            return this.sound;
        }
    
        /// <returns> The action </returns> 
        public string GetAction() {
            return this.action;
        }
    
        /// <returns> The data </returns> 
        public Object GetData() {
            return this.data;
        }
    
        /// <returns> The apn </returns> 
        public Object GetApn() {
            return this.apn;
        }
    
        /// <returns> The gcm </returns> 
        public Object GetGcm() {
            return this.gcm;
        }
    
        /// <returns> The sms </returns> 
        public Object GetSms() {
            return this.sms;
        }
    
        /// <returns> The facebook_messenger </returns> 
        public Object GetFacebookMessenger() {
            return this.facebookMessenger;
        }
    }
}
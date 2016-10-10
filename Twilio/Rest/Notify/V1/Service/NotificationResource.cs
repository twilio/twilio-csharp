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
    
        /**
         * create
         * 
         * @param serviceSid The service_sid
         * @return NotificationCreator capable of executing the create
         */
        public static NotificationCreator Creator(string serviceSid) {
            return new NotificationCreator(serviceSid);
        }
    
        /**
         * Converts a JSON string into a NotificationResource object
         * 
         * @param json Raw JSON string
         * @return NotificationResource object represented by the provided JSON
         */
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
    
        /**
         * @return The sid
         */
        public string GetSid() {
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
         * @return The identities
         */
        public List<string> GetIdentities() {
            return this.identities;
        }
    
        /**
         * @return The tags
         */
        public List<string> GetTags() {
            return this.tags;
        }
    
        /**
         * @return The priority
         */
        public NotificationResource.Priority GetPriority() {
            return this.priority;
        }
    
        /**
         * @return The ttl
         */
        public int? GetTtl() {
            return this.ttl;
        }
    
        /**
         * @return The title
         */
        public string GetTitle() {
            return this.title;
        }
    
        /**
         * @return The body
         */
        public string GetBody() {
            return this.body;
        }
    
        /**
         * @return The sound
         */
        public string GetSound() {
            return this.sound;
        }
    
        /**
         * @return The action
         */
        public string GetAction() {
            return this.action;
        }
    
        /**
         * @return The data
         */
        public Object GetData() {
            return this.data;
        }
    
        /**
         * @return The apn
         */
        public Object GetApn() {
            return this.apn;
        }
    
        /**
         * @return The gcm
         */
        public Object GetGcm() {
            return this.gcm;
        }
    
        /**
         * @return The sms
         */
        public Object GetSms() {
            return this.sms;
        }
    
        /**
         * @return The facebook_messenger
         */
        public Object GetFacebookMessenger() {
            return this.facebookMessenger;
        }
    }
}
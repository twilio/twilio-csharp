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
        public string sid { get; }
        [JsonProperty("account_sid")]
        public string accountSid { get; }
        [JsonProperty("service_sid")]
        public string serviceSid { get; }
        [JsonProperty("date_created")]
        public DateTime? dateCreated { get; }
        [JsonProperty("identities")]
        public List<string> identities { get; }
        [JsonProperty("tags")]
        public List<string> tags { get; }
        [JsonProperty("priority")]
        [JsonConverter(typeof(StringEnumConverter))]
        public NotificationResource.Priority priority { get; }
        [JsonProperty("ttl")]
        public int? ttl { get; }
        [JsonProperty("title")]
        public string title { get; }
        [JsonProperty("body")]
        public string body { get; }
        [JsonProperty("sound")]
        public string sound { get; }
        [JsonProperty("action")]
        public string action { get; }
        [JsonProperty("data")]
        public Object data { get; }
        [JsonProperty("apn")]
        public Object apn { get; }
        [JsonProperty("gcm")]
        public Object gcm { get; }
        [JsonProperty("sms")]
        public Object sms { get; }
        [JsonProperty("facebook_messenger")]
        public Object facebookMessenger { get; }
    
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
    }
}
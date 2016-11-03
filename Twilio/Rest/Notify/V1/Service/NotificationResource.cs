using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Notify.V1.Service 
{

    public class NotificationResource : Resource 
    {
        public sealed class Priority : IStringEnum 
        {
            public const string High = "high";
            public const string Low = "low";
        
            private string _value;
            
            public Priority() {}
            
            public Priority(string value)
            {
                _value = value;
            }
            
            public override string ToString()
            {
                return _value;
            }
            
            public static implicit operator Priority(string value)
            {
                return new Priority(value);
            }
            
            public static implicit operator string(Priority value)
            {
                return value.ToString();
            }
            
            public void FromString(string value)
            {
                _value = value;
            }
        }
    
        /// <summary>
        /// create
        /// </summary>
        ///
        /// <param name="serviceSid"> The service_sid </param>
        /// <returns> NotificationCreator capable of executing the create </returns> 
        public static NotificationCreator Creator(string serviceSid)
        {
            return new NotificationCreator(serviceSid);
        }
    
        /// <summary>
        /// Converts a JSON string into a NotificationResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> NotificationResource object represented by the provided JSON </returns> 
        public static NotificationResource FromJson(string json)
        {
            // Convert all checked exceptions to Runtime
            try
            {
                return JsonConvert.DeserializeObject<NotificationResource>(json);
            }
            catch (JsonException e)
            {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("sid")]
        public string sid { get; set; }
        [JsonProperty("account_sid")]
        public string accountSid { get; set; }
        [JsonProperty("service_sid")]
        public string serviceSid { get; set; }
        [JsonProperty("date_created")]
        public DateTime? dateCreated { get; set; }
        [JsonProperty("identities")]
        public List<string> identities { get; set; }
        [JsonProperty("tags")]
        public List<string> tags { get; set; }
        [JsonProperty("priority")]
        [JsonConverter(typeof(StringEnumConverter))]
        public NotificationResource.Priority priority { get; set; }
        [JsonProperty("ttl")]
        public int? ttl { get; set; }
        [JsonProperty("title")]
        public string title { get; set; }
        [JsonProperty("body")]
        public string body { get; set; }
        [JsonProperty("sound")]
        public string sound { get; set; }
        [JsonProperty("action")]
        public string action { get; set; }
        [JsonProperty("data")]
        public Object data { get; set; }
        [JsonProperty("apn")]
        public Object apn { get; set; }
        [JsonProperty("gcm")]
        public Object gcm { get; set; }
        [JsonProperty("sms")]
        public Object sms { get; set; }
        [JsonProperty("facebook_messenger")]
        public Object facebookMessenger { get; set; }
    
        public NotificationResource()
        {
        
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
                                     Object facebookMessenger)
                                     {
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
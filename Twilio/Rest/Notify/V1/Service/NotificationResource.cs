using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Types;

namespace Twilio.Rest.Notify.V1.Service 
{

    public class NotificationResource : Resource 
    {
        public sealed class PriorityEnum : StringEnum 
        {
            private PriorityEnum(string value) : base(value) {}
            public PriorityEnum() {}
        
            public static readonly PriorityEnum High = new PriorityEnum("high");
            public static readonly PriorityEnum Low = new PriorityEnum("low");
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
        public string Sid { get; set; }
        [JsonProperty("account_sid")]
        public string AccountSid { get; set; }
        [JsonProperty("service_sid")]
        public string ServiceSid { get; set; }
        [JsonProperty("date_created")]
        public DateTime? DateCreated { get; set; }
        [JsonProperty("identities")]
        public List<string> Identities { get; set; }
        [JsonProperty("tags")]
        public List<string> Tags { get; set; }
        [JsonProperty("priority")]
        [JsonConverter(typeof(StringEnumConverter))]
        public NotificationResource.PriorityEnum Priority { get; set; }
        [JsonProperty("ttl")]
        public int? Ttl { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("body")]
        public string Body { get; set; }
        [JsonProperty("sound")]
        public string Sound { get; set; }
        [JsonProperty("action")]
        public string Action { get; set; }
        [JsonProperty("data")]
        public Object Data { get; set; }
        [JsonProperty("apn")]
        public Object Apn { get; set; }
        [JsonProperty("gcm")]
        public Object Gcm { get; set; }
        [JsonProperty("sms")]
        public Object Sms { get; set; }
        [JsonProperty("facebook_messenger")]
        public Object FacebookMessenger { get; set; }
    
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
                                     NotificationResource.PriorityEnum priority, 
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
            Sid = sid;
            AccountSid = accountSid;
            ServiceSid = serviceSid;
            DateCreated = MarshalConverter.DateTimeFromString(dateCreated);
            Identities = identities;
            Tags = tags;
            Priority = priority;
            Ttl = ttl;
            Title = title;
            Body = body;
            Sound = sound;
            Action = action;
            Data = data;
            Apn = apn;
            Gcm = gcm;
            Sms = sms;
            FacebookMessenger = facebookMessenger;
        }
    }
}
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Types;

namespace Twilio.Rest.Notify.V1.Service 
{

    public class BindingResource : Resource 
    {
        public sealed class BindingTypeEnum : StringEnum 
        {
            private BindingTypeEnum(string value) : base(value) {}
            public BindingTypeEnum() {}
        
            public static BindingTypeEnum Apn = new BindingTypeEnum("apn");
            public static BindingTypeEnum Gcm = new BindingTypeEnum("gcm");
            public static BindingTypeEnum Sms = new BindingTypeEnum("sms");
            public static BindingTypeEnum FacebookMessenger = new BindingTypeEnum("facebook-messenger");
        }
    
        /// <summary>
        /// fetch
        /// </summary>
        ///
        /// <param name="serviceSid"> The service_sid </param>
        /// <param name="sid"> The sid </param>
        /// <returns> BindingFetcher capable of executing the fetch </returns> 
        public static BindingFetcher Fetcher(string serviceSid, string sid)
        {
            return new BindingFetcher(serviceSid, sid);
        }
    
        /// <summary>
        /// delete
        /// </summary>
        ///
        /// <param name="serviceSid"> The service_sid </param>
        /// <param name="sid"> The sid </param>
        /// <returns> BindingDeleter capable of executing the delete </returns> 
        public static BindingDeleter Deleter(string serviceSid, string sid)
        {
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
        public static BindingCreator Creator(string serviceSid, string endpoint, string identity, BindingResource.BindingTypeEnum bindingType, string address)
        {
            return new BindingCreator(serviceSid, endpoint, identity, bindingType, address);
        }
    
        /// <summary>
        /// read
        /// </summary>
        ///
        /// <param name="serviceSid"> The service_sid </param>
        /// <returns> BindingReader capable of executing the read </returns> 
        public static BindingReader Reader(string serviceSid)
        {
            return new BindingReader(serviceSid);
        }
    
        /// <summary>
        /// Converts a JSON string into a BindingResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> BindingResource object represented by the provided JSON </returns> 
        public static BindingResource FromJson(string json)
        {
            // Convert all checked exceptions to Runtime
            try
            {
                return JsonConvert.DeserializeObject<BindingResource>(json);
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
        [JsonProperty("credential_sid")]
        public string CredentialSid { get; set; }
        [JsonProperty("date_created")]
        public DateTime? DateCreated { get; set; }
        [JsonProperty("date_updated")]
        public DateTime? DateUpdated { get; set; }
        [JsonProperty("notification_protocol_version")]
        public string NotificationProtocolVersion { get; set; }
        [JsonProperty("endpoint")]
        public string Endpoint { get; set; }
        [JsonProperty("identity")]
        public string Identity { get; set; }
        [JsonProperty("binding_type")]
        public string BindingType { get; set; }
        [JsonProperty("address")]
        public string Address { get; set; }
        [JsonProperty("tags")]
        public List<string> Tags { get; set; }
        [JsonProperty("url")]
        public Uri Url { get; set; }
    
        public BindingResource()
        {
        
        }
    
        private BindingResource([JsonProperty("sid")]
                                string sid, 
                                [JsonProperty("account_sid")]
                                string accountSid, 
                                [JsonProperty("service_sid")]
                                string serviceSid, 
                                [JsonProperty("credential_sid")]
                                string credentialSid, 
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
                                Uri url)
                                {
            Sid = sid;
            AccountSid = accountSid;
            ServiceSid = serviceSid;
            CredentialSid = credentialSid;
            DateCreated = MarshalConverter.DateTimeFromString(dateCreated);
            DateUpdated = MarshalConverter.DateTimeFromString(dateUpdated);
            NotificationProtocolVersion = notificationProtocolVersion;
            Endpoint = endpoint;
            Identity = identity;
            BindingType = bindingType;
            Address = address;
            Tags = tags;
            Url = url;
        }
    }
}
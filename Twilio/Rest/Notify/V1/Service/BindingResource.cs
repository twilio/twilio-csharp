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

    public class BindingResource : Resource 
    {
        public sealed class BindingType : IStringEnum 
        {
            public const string Apn = "apn";
            public const string Gcm = "gcm";
            public const string Sms = "sms";
            public const string FacebookMessenger = "facebook-messenger";
        
            private string _value;
            
            public BindingType() {}
            
            public BindingType(string value)
            {
                _value = value;
            }
            
            public override string ToString()
            {
                return _value;
            }
            
            public static implicit operator BindingType(string value)
            {
                return new BindingType(value);
            }
            
            public static implicit operator string(BindingType value)
            {
                return value.ToString();
            }
            
            public void FromString(string value)
            {
                _value = value;
            }
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
        /// <param name="tag"> The tag </param>
        /// <param name="notificationProtocolVersion"> The notification_protocol_version </param>
        /// <param name="credentialSid"> The credential_sid </param>
        /// <returns> BindingCreator capable of executing the create </returns> 
        public static BindingCreator Creator(string serviceSid, string endpoint, string identity, BindingResource.BindingType bindingType, string address, List<string> tag=null, string notificationProtocolVersion=null, string credentialSid=null)
        {
            return new BindingCreator(serviceSid, endpoint, identity, bindingType, address, tag:tag, notificationProtocolVersion:notificationProtocolVersion, credentialSid:credentialSid);
        }
    
        /// <summary>
        /// read
        /// </summary>
        ///
        /// <param name="serviceSid"> The service_sid </param>
        /// <param name="startDate"> The start_date </param>
        /// <param name="endDate"> The end_date </param>
        /// <param name="identity"> The identity </param>
        /// <param name="tag"> The tag </param>
        /// <returns> BindingReader capable of executing the read </returns> 
        public static BindingReader Reader(string serviceSid, DateTime? startDate=null, DateTime? endDate=null, List<string> identity=null, List<string> tag=null)
        {
            return new BindingReader(serviceSid, startDate:startDate, endDate:endDate, identity:identity, tag:tag);
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
        public string sid { get; }
        [JsonProperty("account_sid")]
        public string accountSid { get; }
        [JsonProperty("service_sid")]
        public string serviceSid { get; }
        [JsonProperty("credential_sid")]
        public string credentialSid { get; }
        [JsonProperty("date_created")]
        public DateTime? dateCreated { get; }
        [JsonProperty("date_updated")]
        public DateTime? dateUpdated { get; }
        [JsonProperty("notification_protocol_version")]
        public string notificationProtocolVersion { get; }
        [JsonProperty("endpoint")]
        public string endpoint { get; }
        [JsonProperty("identity")]
        public string identity { get; }
        [JsonProperty("binding_type")]
        public string bindingType { get; }
        [JsonProperty("address")]
        public string address { get; }
        [JsonProperty("tags")]
        public List<string> tags { get; }
        [JsonProperty("url")]
        public Uri url { get; }
    
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
            this.sid = sid;
            this.accountSid = accountSid;
            this.serviceSid = serviceSid;
            this.credentialSid = credentialSid;
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
    }
}
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.IpMessaging.V1.Service 
{

    public class RoleResource : Resource 
    {
        public sealed class RoleType : IStringEnum 
        {
            public const string Channel = "channel";
            public const string Deployment = "deployment";
        
            private string _value;
            
            public RoleType() {}
            
            public RoleType(string value)
            {
                _value = value;
            }
            
            public override string ToString()
            {
                return _value;
            }
            
            public static implicit operator RoleType(string value)
            {
                return new RoleType(value);
            }
            
            public static implicit operator string(RoleType value)
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
        /// <returns> RoleFetcher capable of executing the fetch </returns> 
        public static RoleFetcher Fetcher(string serviceSid, string sid)
        {
            return new RoleFetcher(serviceSid, sid);
        }
    
        /// <summary>
        /// delete
        /// </summary>
        ///
        /// <param name="serviceSid"> The service_sid </param>
        /// <param name="sid"> The sid </param>
        /// <returns> RoleDeleter capable of executing the delete </returns> 
        public static RoleDeleter Deleter(string serviceSid, string sid)
        {
            return new RoleDeleter(serviceSid, sid);
        }
    
        /// <summary>
        /// create
        /// </summary>
        ///
        /// <param name="serviceSid"> The service_sid </param>
        /// <param name="friendlyName"> The friendly_name </param>
        /// <param name="type"> The type </param>
        /// <param name="permission"> The permission </param>
        /// <returns> RoleCreator capable of executing the create </returns> 
        public static RoleCreator Creator(string serviceSid, string friendlyName, RoleResource.RoleType type, List<string> permission)
        {
            return new RoleCreator(serviceSid, friendlyName, type, permission);
        }
    
        /// <summary>
        /// read
        /// </summary>
        ///
        /// <param name="serviceSid"> The service_sid </param>
        /// <returns> RoleReader capable of executing the read </returns> 
        public static RoleReader Reader(string serviceSid)
        {
            return new RoleReader(serviceSid);
        }
    
        /// <summary>
        /// update
        /// </summary>
        ///
        /// <param name="serviceSid"> The service_sid </param>
        /// <param name="sid"> The sid </param>
        /// <param name="permission"> The permission </param>
        /// <returns> RoleUpdater capable of executing the update </returns> 
        public static RoleUpdater Updater(string serviceSid, string sid, List<string> permission)
        {
            return new RoleUpdater(serviceSid, sid, permission);
        }
    
        /// <summary>
        /// Converts a JSON string into a RoleResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> RoleResource object represented by the provided JSON </returns> 
        public static RoleResource FromJson(string json)
        {
            // Convert all checked exceptions to Runtime
            try
            {
                return JsonConvert.DeserializeObject<RoleResource>(json);
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
        [JsonProperty("friendly_name")]
        public string friendlyName { get; set; }
        [JsonProperty("type")]
        [JsonConverter(typeof(StringEnumConverter))]
        public RoleResource.RoleType type { get; set; }
        [JsonProperty("permissions")]
        public List<string> permissions { get; set; }
        [JsonProperty("date_created")]
        public DateTime? dateCreated { get; set; }
        [JsonProperty("date_updated")]
        public DateTime? dateUpdated { get; set; }
        [JsonProperty("url")]
        public Uri url { get; set; }
    
        public RoleResource()
        {
        
        }
    
        private RoleResource([JsonProperty("sid")]
                             string sid, 
                             [JsonProperty("account_sid")]
                             string accountSid, 
                             [JsonProperty("service_sid")]
                             string serviceSid, 
                             [JsonProperty("friendly_name")]
                             string friendlyName, 
                             [JsonProperty("type")]
                             RoleResource.RoleType type, 
                             [JsonProperty("permissions")]
                             List<string> permissions, 
                             [JsonProperty("date_created")]
                             string dateCreated, 
                             [JsonProperty("date_updated")]
                             string dateUpdated, 
                             [JsonProperty("url")]
                             Uri url)
                             {
            this.sid = sid;
            this.accountSid = accountSid;
            this.serviceSid = serviceSid;
            this.friendlyName = friendlyName;
            this.type = type;
            this.permissions = permissions;
            this.dateCreated = MarshalConverter.DateTimeFromString(dateCreated);
            this.dateUpdated = MarshalConverter.DateTimeFromString(dateUpdated);
            this.url = url;
        }
    }
}
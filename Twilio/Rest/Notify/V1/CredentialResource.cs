using Newtonsoft.Json;
using System;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Notify.V1 
{

    public class CredentialResource : Resource 
    {
        public sealed class CredentialPushService : IStringEnum 
        {
            public const string Gcm = "gcm";
            public const string Apn = "apn";
        
            private string _value;
            
            public CredentialPushService() {}
            
            public CredentialPushService(string value)
            {
                _value = value;
            }
            
            public override string ToString()
            {
                return _value;
            }
            
            public static implicit operator CredentialPushService(string value)
            {
                return new CredentialPushService(value);
            }
            
            public static implicit operator string(CredentialPushService value)
            {
                return value.ToString();
            }
            
            public void FromString(string value)
            {
                _value = value;
            }
        }
    
        /// <summary>
        /// read
        /// </summary>
        ///
        /// <returns> CredentialReader capable of executing the read </returns> 
        public static CredentialReader Reader()
        {
            return new CredentialReader();
        }
    
        /// <summary>
        /// create
        /// </summary>
        ///
        /// <param name="type"> The type </param>
        /// <returns> CredentialCreator capable of executing the create </returns> 
        public static CredentialCreator Creator(CredentialResource.CredentialPushService type)
        {
            return new CredentialCreator(type);
        }
    
        /// <summary>
        /// fetch
        /// </summary>
        ///
        /// <param name="sid"> The sid </param>
        /// <returns> CredentialFetcher capable of executing the fetch </returns> 
        public static CredentialFetcher Fetcher(string sid)
        {
            return new CredentialFetcher(sid);
        }
    
        /// <summary>
        /// update
        /// </summary>
        ///
        /// <param name="sid"> The sid </param>
        /// <returns> CredentialUpdater capable of executing the update </returns> 
        public static CredentialUpdater Updater(string sid)
        {
            return new CredentialUpdater(sid);
        }
    
        /// <summary>
        /// delete
        /// </summary>
        ///
        /// <param name="sid"> The sid </param>
        /// <returns> CredentialDeleter capable of executing the delete </returns> 
        public static CredentialDeleter Deleter(string sid)
        {
            return new CredentialDeleter(sid);
        }
    
        /// <summary>
        /// Converts a JSON string into a CredentialResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> CredentialResource object represented by the provided JSON </returns> 
        public static CredentialResource FromJson(string json)
        {
            // Convert all checked exceptions to Runtime
            try
            {
                return JsonConvert.DeserializeObject<CredentialResource>(json);
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
        [JsonProperty("friendly_name")]
        public string friendlyName { get; set; }
        [JsonProperty("type")]
        [JsonConverter(typeof(StringEnumConverter))]
        public CredentialResource.CredentialPushService type { get; set; }
        [JsonProperty("sandbox")]
        public string sandbox { get; set; }
        [JsonProperty("date_created")]
        public DateTime? dateCreated { get; set; }
        [JsonProperty("date_updated")]
        public DateTime? dateUpdated { get; set; }
        [JsonProperty("url")]
        public Uri url { get; set; }
    
        public CredentialResource()
        {
        
        }
    
        private CredentialResource([JsonProperty("sid")]
                                   string sid, 
                                   [JsonProperty("account_sid")]
                                   string accountSid, 
                                   [JsonProperty("friendly_name")]
                                   string friendlyName, 
                                   [JsonProperty("type")]
                                   CredentialResource.CredentialPushService type, 
                                   [JsonProperty("sandbox")]
                                   string sandbox, 
                                   [JsonProperty("date_created")]
                                   string dateCreated, 
                                   [JsonProperty("date_updated")]
                                   string dateUpdated, 
                                   [JsonProperty("url")]
                                   Uri url)
                                   {
            this.sid = sid;
            this.accountSid = accountSid;
            this.friendlyName = friendlyName;
            this.type = type;
            this.sandbox = sandbox;
            this.dateCreated = MarshalConverter.DateTimeFromString(dateCreated);
            this.dateUpdated = MarshalConverter.DateTimeFromString(dateUpdated);
            this.url = url;
        }
    }
}
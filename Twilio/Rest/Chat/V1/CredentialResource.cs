using Newtonsoft.Json;
using System;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Chat.V1 
{

    public class CredentialResource : Resource 
    {
        public sealed class PushService : IStringEnum 
        {
            public const string Gcm = "gcm";
            public const string Apn = "apn";
        
            private string _value;
            
            public PushService() {}
            
            public PushService(string value)
            {
                _value = value;
            }
            
            public override string ToString()
            {
                return _value;
            }
            
            public static implicit operator PushService(string value)
            {
                return new PushService(value);
            }
            
            public static implicit operator string(PushService value)
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
        /// <param name="friendlyName"> The friendly_name </param>
        /// <param name="certificate"> The certificate </param>
        /// <param name="privateKey"> The private_key </param>
        /// <param name="sandbox"> The sandbox </param>
        /// <param name="apiKey"> The api_key </param>
        /// <returns> CredentialCreator capable of executing the create </returns> 
        public static CredentialCreator Creator(CredentialResource.PushService type, string friendlyName=null, string certificate=null, string privateKey=null, bool? sandbox=null, string apiKey=null)
        {
            return new CredentialCreator(type, friendlyName:friendlyName, certificate:certificate, privateKey:privateKey, sandbox:sandbox, apiKey:apiKey);
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
        /// <param name="friendlyName"> The friendly_name </param>
        /// <param name="certificate"> The certificate </param>
        /// <param name="privateKey"> The private_key </param>
        /// <param name="sandbox"> The sandbox </param>
        /// <param name="apiKey"> The api_key </param>
        /// <returns> CredentialUpdater capable of executing the update </returns> 
        public static CredentialUpdater Updater(string sid, string friendlyName=null, string certificate=null, string privateKey=null, bool? sandbox=null, string apiKey=null)
        {
            return new CredentialUpdater(sid, friendlyName:friendlyName, certificate:certificate, privateKey:privateKey, sandbox:sandbox, apiKey:apiKey);
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
        public string sid { get; }
        [JsonProperty("account_sid")]
        public string accountSid { get; }
        [JsonProperty("friendly_name")]
        public string friendlyName { get; }
        [JsonProperty("type")]
        [JsonConverter(typeof(StringEnumConverter))]
        public CredentialResource.PushService type { get; }
        [JsonProperty("sandbox")]
        public string sandbox { get; }
        [JsonProperty("date_created")]
        public DateTime? dateCreated { get; }
        [JsonProperty("date_updated")]
        public DateTime? dateUpdated { get; }
        [JsonProperty("url")]
        public Uri url { get; }
    
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
                                   CredentialResource.PushService type, 
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
using Newtonsoft.Json;
using System;
using Twilio.Base;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Types;

namespace Twilio.Rest.Chat.V1 
{

    public class CredentialResource : Resource 
    {
        public sealed class PushServiceEnum : StringEnum 
        {
            private PushServiceEnum(string value) : base(value) {}
            public PushServiceEnum() {}
        
            public static PushServiceEnum Gcm = new PushServiceEnum("gcm");
            public static PushServiceEnum Apn = new PushServiceEnum("apn");
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
        public static CredentialCreator Creator(CredentialResource.PushServiceEnum type)
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
        public string Sid { get; set; }
        [JsonProperty("account_sid")]
        public string AccountSid { get; set; }
        [JsonProperty("friendly_name")]
        public string FriendlyName { get; set; }
        [JsonProperty("type")]
        [JsonConverter(typeof(StringEnumConverter))]
        public CredentialResource.PushServiceEnum Type { get; set; }
        [JsonProperty("sandbox")]
        public string Sandbox { get; set; }
        [JsonProperty("date_created")]
        public DateTime? DateCreated { get; set; }
        [JsonProperty("date_updated")]
        public DateTime? DateUpdated { get; set; }
        [JsonProperty("url")]
        public Uri Url { get; set; }
    
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
                                   CredentialResource.PushServiceEnum type, 
                                   [JsonProperty("sandbox")]
                                   string sandbox, 
                                   [JsonProperty("date_created")]
                                   string dateCreated, 
                                   [JsonProperty("date_updated")]
                                   string dateUpdated, 
                                   [JsonProperty("url")]
                                   Uri url)
                                   {
            Sid = sid;
            AccountSid = accountSid;
            FriendlyName = friendlyName;
            Type = type;
            Sandbox = sandbox;
            DateCreated = MarshalConverter.DateTimeFromString(dateCreated);
            DateUpdated = MarshalConverter.DateTimeFromString(dateUpdated);
            Url = url;
        }
    }
}
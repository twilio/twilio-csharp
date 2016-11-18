using Newtonsoft.Json;
using System;
using Twilio.Base;
using Twilio.Converters;
using Twilio.Exceptions;

namespace Twilio.Rest.Accounts.V1.Credential 
{

    public class PublicKeyResource : Resource 
    {
        /// <summary>
        /// read
        /// </summary>
        ///
        /// <returns> PublicKeyReader capable of executing the read </returns> 
        public static PublicKeyReader Reader()
        {
            return new PublicKeyReader();
        }
    
        /// <summary>
        /// create
        /// </summary>
        ///
        /// <param name="publicKey"> The public_key </param>
        /// <returns> PublicKeyCreator capable of executing the create </returns> 
        public static PublicKeyCreator Creator(string publicKey)
        {
            return new PublicKeyCreator(publicKey);
        }
    
        /// <summary>
        /// fetch
        /// </summary>
        ///
        /// <param name="sid"> The sid </param>
        /// <returns> PublicKeyFetcher capable of executing the fetch </returns> 
        public static PublicKeyFetcher Fetcher(string sid)
        {
            return new PublicKeyFetcher(sid);
        }
    
        /// <summary>
        /// update
        /// </summary>
        ///
        /// <param name="sid"> The sid </param>
        /// <returns> PublicKeyUpdater capable of executing the update </returns> 
        public static PublicKeyUpdater Updater(string sid)
        {
            return new PublicKeyUpdater(sid);
        }
    
        /// <summary>
        /// delete
        /// </summary>
        ///
        /// <param name="sid"> The sid </param>
        /// <returns> PublicKeyDeleter capable of executing the delete </returns> 
        public static PublicKeyDeleter Deleter(string sid)
        {
            return new PublicKeyDeleter(sid);
        }
    
        /// <summary>
        /// Converts a JSON string into a PublicKeyResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> PublicKeyResource object represented by the provided JSON </returns> 
        public static PublicKeyResource FromJson(string json)
        {
            // Convert all checked exceptions to Runtime
            try
            {
                return JsonConvert.DeserializeObject<PublicKeyResource>(json);
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
        [JsonProperty("date_created")]
        public DateTime? DateCreated { get; set; }
        [JsonProperty("date_updated")]
        public DateTime? DateUpdated { get; set; }
        [JsonProperty("url")]
        public Uri Url { get; set; }
    
        public PublicKeyResource()
        {
        
        }
    
        private PublicKeyResource([JsonProperty("sid")]
                                  string sid, 
                                  [JsonProperty("account_sid")]
                                  string accountSid, 
                                  [JsonProperty("friendly_name")]
                                  string friendlyName, 
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
            DateCreated = MarshalConverter.DateTimeFromString(dateCreated);
            DateUpdated = MarshalConverter.DateTimeFromString(dateUpdated);
            Url = url;
        }
    }
}
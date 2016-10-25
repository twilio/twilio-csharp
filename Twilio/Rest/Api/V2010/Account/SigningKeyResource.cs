using Newtonsoft.Json;
using System;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Api.V2010.Account 
{

    public class SigningKeyResource : Resource 
    {
        /// <summary>
        /// fetch
        /// </summary>
        ///
        /// <param name="sid"> The sid </param>
        /// <param name="accountSid"> The account_sid </param>
        /// <returns> SigningKeyFetcher capable of executing the fetch </returns> 
        public static SigningKeyFetcher Fetcher(string sid, string accountSid=null)
        {
            return new SigningKeyFetcher(sid, accountSid:accountSid);
        }
    
        /// <summary>
        /// update
        /// </summary>
        ///
        /// <param name="sid"> The sid </param>
        /// <param name="accountSid"> The account_sid </param>
        /// <param name="friendlyName"> The friendly_name </param>
        /// <returns> SigningKeyUpdater capable of executing the update </returns> 
        public static SigningKeyUpdater Updater(string sid, string accountSid=null, string friendlyName=null)
        {
            return new SigningKeyUpdater(sid, accountSid:accountSid, friendlyName:friendlyName);
        }
    
        /// <summary>
        /// delete
        /// </summary>
        ///
        /// <param name="sid"> The sid </param>
        /// <param name="accountSid"> The account_sid </param>
        /// <returns> SigningKeyDeleter capable of executing the delete </returns> 
        public static SigningKeyDeleter Deleter(string sid, string accountSid=null)
        {
            return new SigningKeyDeleter(sid, accountSid:accountSid);
        }
    
        /// <summary>
        /// read
        /// </summary>
        ///
        /// <param name="accountSid"> The account_sid </param>
        /// <returns> SigningKeyReader capable of executing the read </returns> 
        public static SigningKeyReader Reader(string accountSid=null)
        {
            return new SigningKeyReader(accountSid:accountSid);
        }
    
        /// <summary>
        /// Converts a JSON string into a SigningKeyResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> SigningKeyResource object represented by the provided JSON </returns> 
        public static SigningKeyResource FromJson(string json)
        {
            // Convert all checked exceptions to Runtime
            try
            {
                return JsonConvert.DeserializeObject<SigningKeyResource>(json);
            }
            catch (JsonException e)
            {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("sid")]
        public string sid { get; }
        [JsonProperty("friendly_name")]
        public string friendlyName { get; }
        [JsonProperty("date_created")]
        public DateTime? dateCreated { get; }
        [JsonProperty("date_updated")]
        public DateTime? dateUpdated { get; }
    
        public SigningKeyResource()
        {
        
        }
    
        private SigningKeyResource([JsonProperty("sid")]
                                   string sid, 
                                   [JsonProperty("friendly_name")]
                                   string friendlyName, 
                                   [JsonProperty("date_created")]
                                   string dateCreated, 
                                   [JsonProperty("date_updated")]
                                   string dateUpdated)
                                   {
            this.sid = sid;
            this.friendlyName = friendlyName;
            this.dateCreated = MarshalConverter.DateTimeFromString(dateCreated);
            this.dateUpdated = MarshalConverter.DateTimeFromString(dateUpdated);
        }
    }
}
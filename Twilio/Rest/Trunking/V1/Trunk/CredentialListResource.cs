using Newtonsoft.Json;
using System;
using Twilio.Base;
using Twilio.Converters;
using Twilio.Exceptions;

namespace Twilio.Rest.Trunking.V1.Trunk 
{

    public class CredentialListResource : Resource 
    {
        /// <summary>
        /// fetch
        /// </summary>
        ///
        /// <param name="trunkSid"> The trunk_sid </param>
        /// <param name="sid"> The sid </param>
        /// <returns> CredentialListFetcher capable of executing the fetch </returns> 
        public static CredentialListFetcher Fetcher(string trunkSid, string sid)
        {
            return new CredentialListFetcher(trunkSid, sid);
        }
    
        /// <summary>
        /// delete
        /// </summary>
        ///
        /// <param name="trunkSid"> The trunk_sid </param>
        /// <param name="sid"> The sid </param>
        /// <returns> CredentialListDeleter capable of executing the delete </returns> 
        public static CredentialListDeleter Deleter(string trunkSid, string sid)
        {
            return new CredentialListDeleter(trunkSid, sid);
        }
    
        /// <summary>
        /// create
        /// </summary>
        ///
        /// <param name="trunkSid"> The trunk_sid </param>
        /// <param name="credentialListSid"> The credential_list_sid </param>
        /// <returns> CredentialListCreator capable of executing the create </returns> 
        public static CredentialListCreator Creator(string trunkSid, string credentialListSid)
        {
            return new CredentialListCreator(trunkSid, credentialListSid);
        }
    
        /// <summary>
        /// read
        /// </summary>
        ///
        /// <param name="trunkSid"> The trunk_sid </param>
        /// <returns> CredentialListReader capable of executing the read </returns> 
        public static CredentialListReader Reader(string trunkSid)
        {
            return new CredentialListReader(trunkSid);
        }
    
        /// <summary>
        /// Converts a JSON string into a CredentialListResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> CredentialListResource object represented by the provided JSON </returns> 
        public static CredentialListResource FromJson(string json)
        {
            // Convert all checked exceptions to Runtime
            try
            {
                return JsonConvert.DeserializeObject<CredentialListResource>(json);
            }
            catch (JsonException e)
            {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("account_sid")]
        public string AccountSid { get; set; }
        [JsonProperty("sid")]
        public string Sid { get; set; }
        [JsonProperty("trunk_sid")]
        public string TrunkSid { get; set; }
        [JsonProperty("friendly_name")]
        public string FriendlyName { get; set; }
        [JsonProperty("date_created")]
        public DateTime? DateCreated { get; set; }
        [JsonProperty("date_updated")]
        public DateTime? DateUpdated { get; set; }
        [JsonProperty("url")]
        public Uri Url { get; set; }
    
        public CredentialListResource()
        {
        
        }
    
        private CredentialListResource([JsonProperty("account_sid")]
                                       string accountSid, 
                                       [JsonProperty("sid")]
                                       string sid, 
                                       [JsonProperty("trunk_sid")]
                                       string trunkSid, 
                                       [JsonProperty("friendly_name")]
                                       string friendlyName, 
                                       [JsonProperty("date_created")]
                                       string dateCreated, 
                                       [JsonProperty("date_updated")]
                                       string dateUpdated, 
                                       [JsonProperty("url")]
                                       Uri url)
                                       {
            AccountSid = accountSid;
            Sid = sid;
            TrunkSid = trunkSid;
            FriendlyName = friendlyName;
            DateCreated = MarshalConverter.DateTimeFromString(dateCreated);
            DateUpdated = MarshalConverter.DateTimeFromString(dateUpdated);
            Url = url;
        }
    }
}
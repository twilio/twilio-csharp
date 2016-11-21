using Newtonsoft.Json;
using System;
using Twilio.Base;
using Twilio.Converters;
using Twilio.Exceptions;

namespace Twilio.Rest.Trunking.V1.Trunk 
{

    public class IpAccessControlListResource : Resource 
    {
        /// <summary>
        /// fetch
        /// </summary>
        ///
        /// <param name="trunkSid"> The trunk_sid </param>
        /// <param name="sid"> The sid </param>
        /// <returns> IpAccessControlListFetcher capable of executing the fetch </returns> 
        public static IpAccessControlListFetcher Fetcher(string trunkSid, string sid)
        {
            return new IpAccessControlListFetcher(trunkSid, sid);
        }
    
        /// <summary>
        /// delete
        /// </summary>
        ///
        /// <param name="trunkSid"> The trunk_sid </param>
        /// <param name="sid"> The sid </param>
        /// <returns> IpAccessControlListDeleter capable of executing the delete </returns> 
        public static IpAccessControlListDeleter Deleter(string trunkSid, string sid)
        {
            return new IpAccessControlListDeleter(trunkSid, sid);
        }
    
        /// <summary>
        /// create
        /// </summary>
        ///
        /// <param name="trunkSid"> The trunk_sid </param>
        /// <param name="ipAccessControlListSid"> The ip_access_control_list_sid </param>
        /// <returns> IpAccessControlListCreator capable of executing the create </returns> 
        public static IpAccessControlListCreator Creator(string trunkSid, string ipAccessControlListSid)
        {
            return new IpAccessControlListCreator(trunkSid, ipAccessControlListSid);
        }
    
        /// <summary>
        /// read
        /// </summary>
        ///
        /// <param name="trunkSid"> The trunk_sid </param>
        /// <returns> IpAccessControlListReader capable of executing the read </returns> 
        public static IpAccessControlListReader Reader(string trunkSid)
        {
            return new IpAccessControlListReader(trunkSid);
        }
    
        /// <summary>
        /// Converts a JSON string into a IpAccessControlListResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> IpAccessControlListResource object represented by the provided JSON </returns> 
        public static IpAccessControlListResource FromJson(string json)
        {
            // Convert all checked exceptions to Runtime
            try
            {
                return JsonConvert.DeserializeObject<IpAccessControlListResource>(json);
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
    
        public IpAccessControlListResource()
        {
        
        }
    
        private IpAccessControlListResource([JsonProperty("account_sid")]
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
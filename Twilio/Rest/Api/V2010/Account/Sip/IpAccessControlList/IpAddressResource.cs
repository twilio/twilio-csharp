using Newtonsoft.Json;
using System;
using Twilio.Base;
using Twilio.Converters;
using Twilio.Exceptions;

namespace Twilio.Rest.Api.V2010.Account.Sip.IpAccessControlList 
{

    public class IpAddressResource : Resource 
    {
        /// <summary>
        /// read
        /// </summary>
        ///
        /// <param name="ipAccessControlListSid"> The ip_access_control_list_sid </param>
        /// <returns> IpAddressReader capable of executing the read </returns> 
        public static IpAddressReader Reader(string ipAccessControlListSid)
        {
            return new IpAddressReader(ipAccessControlListSid);
        }
    
        /// <summary>
        /// create
        /// </summary>
        ///
        /// <param name="ipAccessControlListSid"> The ip_access_control_list_sid </param>
        /// <param name="friendlyName"> The friendly_name </param>
        /// <param name="ipAddress"> The ip_address </param>
        /// <returns> IpAddressCreator capable of executing the create </returns> 
        public static IpAddressCreator Creator(string ipAccessControlListSid, string friendlyName, string ipAddress)
        {
            return new IpAddressCreator(ipAccessControlListSid, friendlyName, ipAddress);
        }
    
        /// <summary>
        /// fetch
        /// </summary>
        ///
        /// <param name="ipAccessControlListSid"> The ip_access_control_list_sid </param>
        /// <param name="sid"> The sid </param>
        /// <returns> IpAddressFetcher capable of executing the fetch </returns> 
        public static IpAddressFetcher Fetcher(string ipAccessControlListSid, string sid)
        {
            return new IpAddressFetcher(ipAccessControlListSid, sid);
        }
    
        /// <summary>
        /// update
        /// </summary>
        ///
        /// <param name="ipAccessControlListSid"> The ip_access_control_list_sid </param>
        /// <param name="sid"> The sid </param>
        /// <returns> IpAddressUpdater capable of executing the update </returns> 
        public static IpAddressUpdater Updater(string ipAccessControlListSid, string sid)
        {
            return new IpAddressUpdater(ipAccessControlListSid, sid);
        }
    
        /// <summary>
        /// delete
        /// </summary>
        ///
        /// <param name="ipAccessControlListSid"> The ip_access_control_list_sid </param>
        /// <param name="sid"> The sid </param>
        /// <returns> IpAddressDeleter capable of executing the delete </returns> 
        public static IpAddressDeleter Deleter(string ipAccessControlListSid, string sid)
        {
            return new IpAddressDeleter(ipAccessControlListSid, sid);
        }
    
        /// <summary>
        /// Converts a JSON string into a IpAddressResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> IpAddressResource object represented by the provided JSON </returns> 
        public static IpAddressResource FromJson(string json)
        {
            // Convert all checked exceptions to Runtime
            try
            {
                return JsonConvert.DeserializeObject<IpAddressResource>(json);
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
        [JsonProperty("ip_address")]
        public string IpAddress { get; set; }
        [JsonProperty("ip_access_control_list_sid")]
        public string IpAccessControlListSid { get; set; }
        [JsonProperty("date_created")]
        public DateTime? DateCreated { get; set; }
        [JsonProperty("date_updated")]
        public DateTime? DateUpdated { get; set; }
        [JsonProperty("uri")]
        public string Uri { get; set; }
    
        public IpAddressResource()
        {
        
        }
    
        private IpAddressResource([JsonProperty("sid")]
                                  string sid, 
                                  [JsonProperty("account_sid")]
                                  string accountSid, 
                                  [JsonProperty("friendly_name")]
                                  string friendlyName, 
                                  [JsonProperty("ip_address")]
                                  string ipAddress, 
                                  [JsonProperty("ip_access_control_list_sid")]
                                  string ipAccessControlListSid, 
                                  [JsonProperty("date_created")]
                                  string dateCreated, 
                                  [JsonProperty("date_updated")]
                                  string dateUpdated, 
                                  [JsonProperty("uri")]
                                  string uri)
                                  {
            Sid = sid;
            AccountSid = accountSid;
            FriendlyName = friendlyName;
            IpAddress = ipAddress;
            IpAccessControlListSid = ipAccessControlListSid;
            DateCreated = MarshalConverter.DateTimeFromString(dateCreated);
            DateUpdated = MarshalConverter.DateTimeFromString(dateUpdated);
            Uri = uri;
        }
    }
}
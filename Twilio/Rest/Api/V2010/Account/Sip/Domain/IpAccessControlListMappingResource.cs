using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Converters;
using Twilio.Exceptions;

namespace Twilio.Rest.Api.V2010.Account.Sip.Domain 
{

    public class IpAccessControlListMappingResource : Resource 
    {
        /// <summary>
        /// fetch
        /// </summary>
        ///
        /// <param name="domainSid"> The domain_sid </param>
        /// <param name="sid"> The sid </param>
        /// <returns> IpAccessControlListMappingFetcher capable of executing the fetch </returns> 
        public static IpAccessControlListMappingFetcher Fetcher(string domainSid, string sid)
        {
            return new IpAccessControlListMappingFetcher(domainSid, sid);
        }
    
        /// <summary>
        /// create
        /// </summary>
        ///
        /// <param name="domainSid"> The domain_sid </param>
        /// <param name="ipAccessControlListSid"> The ip_access_control_list_sid </param>
        /// <returns> IpAccessControlListMappingCreator capable of executing the create </returns> 
        public static IpAccessControlListMappingCreator Creator(string domainSid, string ipAccessControlListSid)
        {
            return new IpAccessControlListMappingCreator(domainSid, ipAccessControlListSid);
        }
    
        /// <summary>
        /// read
        /// </summary>
        ///
        /// <param name="domainSid"> The domain_sid </param>
        /// <returns> IpAccessControlListMappingReader capable of executing the read </returns> 
        public static IpAccessControlListMappingReader Reader(string domainSid)
        {
            return new IpAccessControlListMappingReader(domainSid);
        }
    
        /// <summary>
        /// delete
        /// </summary>
        ///
        /// <param name="domainSid"> The domain_sid </param>
        /// <param name="sid"> The sid </param>
        /// <returns> IpAccessControlListMappingDeleter capable of executing the delete </returns> 
        public static IpAccessControlListMappingDeleter Deleter(string domainSid, string sid)
        {
            return new IpAccessControlListMappingDeleter(domainSid, sid);
        }
    
        /// <summary>
        /// Converts a JSON string into a IpAccessControlListMappingResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> IpAccessControlListMappingResource object represented by the provided JSON </returns> 
        public static IpAccessControlListMappingResource FromJson(string json)
        {
            // Convert all checked exceptions to Runtime
            try
            {
                return JsonConvert.DeserializeObject<IpAccessControlListMappingResource>(json);
            }
            catch (JsonException e)
            {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("account_sid")]
        public string AccountSid { get; set; }
        [JsonProperty("date_created")]
        public DateTime? DateCreated { get; set; }
        [JsonProperty("date_updated")]
        public DateTime? DateUpdated { get; set; }
        [JsonProperty("friendly_name")]
        public string FriendlyName { get; set; }
        [JsonProperty("sid")]
        public string Sid { get; set; }
        [JsonProperty("uri")]
        public string Uri { get; set; }
        [JsonProperty("subresource_uris")]
        public Dictionary<string, string> SubresourceUris { get; set; }
    
        public IpAccessControlListMappingResource()
        {
        
        }
    
        private IpAccessControlListMappingResource([JsonProperty("account_sid")]
                                                   string accountSid, 
                                                   [JsonProperty("date_created")]
                                                   string dateCreated, 
                                                   [JsonProperty("date_updated")]
                                                   string dateUpdated, 
                                                   [JsonProperty("friendly_name")]
                                                   string friendlyName, 
                                                   [JsonProperty("sid")]
                                                   string sid, 
                                                   [JsonProperty("uri")]
                                                   string uri, 
                                                   [JsonProperty("subresource_uris")]
                                                   Dictionary<string, string> subresourceUris)
                                                   {
            AccountSid = accountSid;
            DateCreated = MarshalConverter.DateTimeFromString(dateCreated);
            DateUpdated = MarshalConverter.DateTimeFromString(dateUpdated);
            FriendlyName = friendlyName;
            Sid = sid;
            Uri = uri;
            SubresourceUris = subresourceUris;
        }
    }
}
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Converters;
using Twilio.Exceptions;

namespace Twilio.Rest.Api.V2010.Account.Sip.Domain 
{

    public class CredentialListMappingResource : Resource 
    {
        /// <summary>
        /// create
        /// </summary>
        ///
        /// <param name="domainSid"> The domain_sid </param>
        /// <param name="credentialListSid"> The credential_list_sid </param>
        /// <returns> CredentialListMappingCreator capable of executing the create </returns> 
        public static CredentialListMappingCreator Creator(string domainSid, string credentialListSid)
        {
            return new CredentialListMappingCreator(domainSid, credentialListSid);
        }
    
        /// <summary>
        /// read
        /// </summary>
        ///
        /// <param name="domainSid"> The domain_sid </param>
        /// <returns> CredentialListMappingReader capable of executing the read </returns> 
        public static CredentialListMappingReader Reader(string domainSid)
        {
            return new CredentialListMappingReader(domainSid);
        }
    
        /// <summary>
        /// fetch
        /// </summary>
        ///
        /// <param name="domainSid"> The domain_sid </param>
        /// <param name="sid"> The sid </param>
        /// <returns> CredentialListMappingFetcher capable of executing the fetch </returns> 
        public static CredentialListMappingFetcher Fetcher(string domainSid, string sid)
        {
            return new CredentialListMappingFetcher(domainSid, sid);
        }
    
        /// <summary>
        /// delete
        /// </summary>
        ///
        /// <param name="domainSid"> The domain_sid </param>
        /// <param name="sid"> The sid </param>
        /// <returns> CredentialListMappingDeleter capable of executing the delete </returns> 
        public static CredentialListMappingDeleter Deleter(string domainSid, string sid)
        {
            return new CredentialListMappingDeleter(domainSid, sid);
        }
    
        /// <summary>
        /// Converts a JSON string into a CredentialListMappingResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> CredentialListMappingResource object represented by the provided JSON </returns> 
        public static CredentialListMappingResource FromJson(string json)
        {
            // Convert all checked exceptions to Runtime
            try
            {
                return JsonConvert.DeserializeObject<CredentialListMappingResource>(json);
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
    
        public CredentialListMappingResource()
        {
        
        }
    
        private CredentialListMappingResource([JsonProperty("account_sid")]
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
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Api.V2010.Account.Sip.Domain {

    public class CredentialListMappingResource : Resource {
        /// <summary>
        /// create
        /// </summary>
        ///
        /// <param name="domainSid"> The domain_sid </param>
        /// <param name="credentialListSid"> The credential_list_sid </param>
        /// <param name="accountSid"> The account_sid </param>
        /// <returns> CredentialListMappingCreator capable of executing the create </returns> 
        public static CredentialListMappingCreator Creator(string domainSid, string credentialListSid, string accountSid=null) {
            return new CredentialListMappingCreator(domainSid, credentialListSid, accountSid:accountSid);
        }
    
        /// <summary>
        /// read
        /// </summary>
        ///
        /// <param name="domainSid"> The domain_sid </param>
        /// <param name="accountSid"> The account_sid </param>
        /// <returns> CredentialListMappingReader capable of executing the read </returns> 
        public static CredentialListMappingReader Reader(string domainSid, string accountSid=null) {
            return new CredentialListMappingReader(domainSid, accountSid:accountSid);
        }
    
        /// <summary>
        /// fetch
        /// </summary>
        ///
        /// <param name="domainSid"> The domain_sid </param>
        /// <param name="sid"> The sid </param>
        /// <param name="accountSid"> The account_sid </param>
        /// <returns> CredentialListMappingFetcher capable of executing the fetch </returns> 
        public static CredentialListMappingFetcher Fetcher(string domainSid, string sid, string accountSid=null) {
            return new CredentialListMappingFetcher(domainSid, sid, accountSid:accountSid);
        }
    
        /// <summary>
        /// delete
        /// </summary>
        ///
        /// <param name="domainSid"> The domain_sid </param>
        /// <param name="sid"> The sid </param>
        /// <param name="accountSid"> The account_sid </param>
        /// <returns> CredentialListMappingDeleter capable of executing the delete </returns> 
        public static CredentialListMappingDeleter Deleter(string domainSid, string sid, string accountSid=null) {
            return new CredentialListMappingDeleter(domainSid, sid, accountSid:accountSid);
        }
    
        /// <summary>
        /// Converts a JSON string into a CredentialListMappingResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> CredentialListMappingResource object represented by the provided JSON </returns> 
        public static CredentialListMappingResource FromJson(string json) {
            // Convert all checked exceptions to Runtime
            try {
                return JsonConvert.DeserializeObject<CredentialListMappingResource>(json);
            } catch (JsonException e) {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("account_sid")]
        public string accountSid { get; }
        [JsonProperty("date_created")]
        public DateTime? dateCreated { get; }
        [JsonProperty("date_updated")]
        public DateTime? dateUpdated { get; }
        [JsonProperty("friendly_name")]
        public string friendlyName { get; }
        [JsonProperty("sid")]
        public string sid { get; }
        [JsonProperty("uri")]
        public string uri { get; }
        [JsonProperty("subresource_uris")]
        public Dictionary<string, string> subresourceUris { get; }
    
        public CredentialListMappingResource() {
        
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
                                              Dictionary<string, string> subresourceUris) {
            this.accountSid = accountSid;
            this.dateCreated = MarshalConverter.DateTimeFromString(dateCreated);
            this.dateUpdated = MarshalConverter.DateTimeFromString(dateUpdated);
            this.friendlyName = friendlyName;
            this.sid = sid;
            this.uri = uri;
            this.subresourceUris = subresourceUris;
        }
    }
}
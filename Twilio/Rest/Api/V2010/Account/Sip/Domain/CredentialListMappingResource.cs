using Newtonsoft.Json;
using System;
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
        /// <param name="accountSid"> The account_sid </param>
        /// <param name="domainSid"> The domain_sid </param>
        /// <param name="credentialListSid"> The credential_list_sid </param>
        /// <returns> CredentialListMappingCreator capable of executing the create </returns> 
        public static CredentialListMappingCreator Creator(string accountSid, string domainSid, string credentialListSid) {
            return new CredentialListMappingCreator(accountSid, domainSid, credentialListSid);
        }
    
        /// <summary>
        /// Create a CredentialListMappingCreator to execute create.
        /// </summary>
        ///
        /// <param name="domainSid"> The domain_sid </param>
        /// <param name="credentialListSid"> The credential_list_sid </param>
        /// <returns> CredentialListMappingCreator capable of executing the create </returns> 
        public static CredentialListMappingCreator Creator(string domainSid, 
                                                           string credentialListSid) {
            return new CredentialListMappingCreator(domainSid, credentialListSid);
        }
    
        /// <summary>
        /// read
        /// </summary>
        ///
        /// <param name="accountSid"> The account_sid </param>
        /// <param name="domainSid"> The domain_sid </param>
        /// <returns> CredentialListMappingReader capable of executing the read </returns> 
        public static CredentialListMappingReader Reader(string accountSid, string domainSid) {
            return new CredentialListMappingReader(accountSid, domainSid);
        }
    
        /// <summary>
        /// Create a CredentialListMappingReader to execute read.
        /// </summary>
        ///
        /// <param name="domainSid"> The domain_sid </param>
        /// <returns> CredentialListMappingReader capable of executing the read </returns> 
        public static CredentialListMappingReader Reader(string domainSid) {
            return new CredentialListMappingReader(domainSid);
        }
    
        /// <summary>
        /// fetch
        /// </summary>
        ///
        /// <param name="accountSid"> The account_sid </param>
        /// <param name="domainSid"> The domain_sid </param>
        /// <param name="sid"> The sid </param>
        /// <returns> CredentialListMappingFetcher capable of executing the fetch </returns> 
        public static CredentialListMappingFetcher Fetcher(string accountSid, string domainSid, string sid) {
            return new CredentialListMappingFetcher(accountSid, domainSid, sid);
        }
    
        /// <summary>
        /// Create a CredentialListMappingFetcher to execute fetch.
        /// </summary>
        ///
        /// <param name="domainSid"> The domain_sid </param>
        /// <param name="sid"> The sid </param>
        /// <returns> CredentialListMappingFetcher capable of executing the fetch </returns> 
        public static CredentialListMappingFetcher Fetcher(string domainSid, 
                                                           string sid) {
            return new CredentialListMappingFetcher(domainSid, sid);
        }
    
        /// <summary>
        /// delete
        /// </summary>
        ///
        /// <param name="accountSid"> The account_sid </param>
        /// <param name="domainSid"> The domain_sid </param>
        /// <param name="sid"> The sid </param>
        /// <returns> CredentialListMappingDeleter capable of executing the delete </returns> 
        public static CredentialListMappingDeleter Deleter(string accountSid, string domainSid, string sid) {
            return new CredentialListMappingDeleter(accountSid, domainSid, sid);
        }
    
        /// <summary>
        /// Create a CredentialListMappingDeleter to execute delete.
        /// </summary>
        ///
        /// <param name="domainSid"> The domain_sid </param>
        /// <param name="sid"> The sid </param>
        /// <returns> CredentialListMappingDeleter capable of executing the delete </returns> 
        public static CredentialListMappingDeleter Deleter(string domainSid, 
                                                           string sid) {
            return new CredentialListMappingDeleter(domainSid, sid);
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
                                              string uri) {
            this.accountSid = accountSid;
            this.dateCreated = MarshalConverter.DateTimeFromString(dateCreated);
            this.dateUpdated = MarshalConverter.DateTimeFromString(dateUpdated);
            this.friendlyName = friendlyName;
            this.sid = sid;
            this.uri = uri;
        }
    }
}
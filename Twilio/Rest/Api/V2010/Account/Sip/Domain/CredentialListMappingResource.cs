using Newtonsoft.Json;
using System;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Api.V2010.Account.Sip.Domain {

    public class CredentialListMappingResource : SidResource {
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
        private readonly string accountSid;
        [JsonProperty("date_created")]
        private readonly DateTime? dateCreated;
        [JsonProperty("date_updated")]
        private readonly DateTime? dateUpdated;
        [JsonProperty("friendly_name")]
        private readonly string friendlyName;
        [JsonProperty("sid")]
        private readonly string sid;
        [JsonProperty("uri")]
        private readonly string uri;
    
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
    
        /// <returns> The account_sid </returns> 
        public string GetAccountSid() {
            return this.accountSid;
        }
    
        /// <returns> The date_created </returns> 
        public DateTime? GetDateCreated() {
            return this.dateCreated;
        }
    
        /// <returns> The date_updated </returns> 
        public DateTime? GetDateUpdated() {
            return this.dateUpdated;
        }
    
        /// <returns> The friendly_name </returns> 
        public string GetFriendlyName() {
            return this.friendlyName;
        }
    
        /// <returns> The sid </returns> 
        public override string GetSid() {
            return this.sid;
        }
    
        /// <returns> The uri </returns> 
        public string GetUri() {
            return this.uri;
        }
    }
}
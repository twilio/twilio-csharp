using Newtonsoft.Json;
using System;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Api.V2010.Account.Sip.Domain {

    public class IpAccessControlListMappingResource : SidResource {
        /// <summary>
        /// fetch
        /// </summary>
        ///
        /// <param name="accountSid"> The account_sid </param>
        /// <param name="domainSid"> The domain_sid </param>
        /// <param name="sid"> The sid </param>
        /// <returns> IpAccessControlListMappingFetcher capable of executing the fetch </returns> 
        public static IpAccessControlListMappingFetcher Fetcher(string accountSid, string domainSid, string sid) {
            return new IpAccessControlListMappingFetcher(accountSid, domainSid, sid);
        }
    
        /// <summary>
        /// Create a IpAccessControlListMappingFetcher to execute fetch.
        /// </summary>
        ///
        /// <param name="domainSid"> The domain_sid </param>
        /// <param name="sid"> The sid </param>
        /// <returns> IpAccessControlListMappingFetcher capable of executing the fetch </returns> 
        public static IpAccessControlListMappingFetcher Fetcher(string domainSid, 
                                                                string sid) {
            return new IpAccessControlListMappingFetcher(domainSid, sid);
        }
    
        /// <summary>
        /// create
        /// </summary>
        ///
        /// <param name="accountSid"> The account_sid </param>
        /// <param name="domainSid"> The domain_sid </param>
        /// <param name="ipAccessControlListSid"> The ip_access_control_list_sid </param>
        /// <returns> IpAccessControlListMappingCreator capable of executing the create </returns> 
        public static IpAccessControlListMappingCreator Creator(string accountSid, string domainSid, string ipAccessControlListSid) {
            return new IpAccessControlListMappingCreator(accountSid, domainSid, ipAccessControlListSid);
        }
    
        /// <summary>
        /// Create a IpAccessControlListMappingCreator to execute create.
        /// </summary>
        ///
        /// <param name="domainSid"> The domain_sid </param>
        /// <param name="ipAccessControlListSid"> The ip_access_control_list_sid </param>
        /// <returns> IpAccessControlListMappingCreator capable of executing the create </returns> 
        public static IpAccessControlListMappingCreator Creator(string domainSid, 
                                                                string ipAccessControlListSid) {
            return new IpAccessControlListMappingCreator(domainSid, ipAccessControlListSid);
        }
    
        /// <summary>
        /// read
        /// </summary>
        ///
        /// <param name="accountSid"> The account_sid </param>
        /// <param name="domainSid"> The domain_sid </param>
        /// <returns> IpAccessControlListMappingReader capable of executing the read </returns> 
        public static IpAccessControlListMappingReader Reader(string accountSid, string domainSid) {
            return new IpAccessControlListMappingReader(accountSid, domainSid);
        }
    
        /// <summary>
        /// Create a IpAccessControlListMappingReader to execute read.
        /// </summary>
        ///
        /// <param name="domainSid"> The domain_sid </param>
        /// <returns> IpAccessControlListMappingReader capable of executing the read </returns> 
        public static IpAccessControlListMappingReader Reader(string domainSid) {
            return new IpAccessControlListMappingReader(domainSid);
        }
    
        /// <summary>
        /// delete
        /// </summary>
        ///
        /// <param name="accountSid"> The account_sid </param>
        /// <param name="domainSid"> The domain_sid </param>
        /// <param name="sid"> The sid </param>
        /// <returns> IpAccessControlListMappingDeleter capable of executing the delete </returns> 
        public static IpAccessControlListMappingDeleter Deleter(string accountSid, string domainSid, string sid) {
            return new IpAccessControlListMappingDeleter(accountSid, domainSid, sid);
        }
    
        /// <summary>
        /// Create a IpAccessControlListMappingDeleter to execute delete.
        /// </summary>
        ///
        /// <param name="domainSid"> The domain_sid </param>
        /// <param name="sid"> The sid </param>
        /// <returns> IpAccessControlListMappingDeleter capable of executing the delete </returns> 
        public static IpAccessControlListMappingDeleter Deleter(string domainSid, 
                                                                string sid) {
            return new IpAccessControlListMappingDeleter(domainSid, sid);
        }
    
        /// <summary>
        /// Converts a JSON string into a IpAccessControlListMappingResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> IpAccessControlListMappingResource object represented by the provided JSON </returns> 
        public static IpAccessControlListMappingResource FromJson(string json) {
            // Convert all checked exceptions to Runtime
            try {
                return JsonConvert.DeserializeObject<IpAccessControlListMappingResource>(json);
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
    
        public IpAccessControlListMappingResource() {
        
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
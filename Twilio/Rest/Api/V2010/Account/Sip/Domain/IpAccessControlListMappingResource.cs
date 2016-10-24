using Newtonsoft.Json;
using System;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Api.V2010.Account.Sip.Domain {

    public class IpAccessControlListMappingResource : Resource {
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
    }
}
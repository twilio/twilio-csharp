using Newtonsoft.Json;
using System;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Creators.Api.V2010.Account.Sip.Domain;
using Twilio.Deleters.Api.V2010.Account.Sip.Domain;
using Twilio.Exceptions;
using Twilio.Fetchers.Api.V2010.Account.Sip.Domain;
using Twilio.Http;
using Twilio.Readers.Api.V2010.Account.Sip.Domain;
using Twilio.Resources;

namespace Twilio.Resources.Api.V2010.Account.Sip.Domain {

    public class IpAccessControlListMappingResource : SidResource {
        /**
         * fetch
         * 
         * @param accountSid The account_sid
         * @param domainSid The domain_sid
         * @param sid The sid
         * @return IpAccessControlListMappingFetcher capable of executing the fetch
         */
        public static IpAccessControlListMappingFetcher Fetch(string accountSid, string domainSid, string sid) {
            return new IpAccessControlListMappingFetcher(accountSid, domainSid, sid);
        }
    
        /**
         * Create a IpAccessControlListMappingFetcher to execute fetch.
         * 
         * @param domainSid The domain_sid
         * @param sid The sid
         * @return IpAccessControlListMappingFetcher capable of executing the fetch
         */
        public static IpAccessControlListMappingFetcher Fetch(string domainSid, 
                                                              string sid) {
            return new IpAccessControlListMappingFetcher(domainSid, sid);
        }
    
        /**
         * create
         * 
         * @param accountSid The account_sid
         * @param domainSid The domain_sid
         * @param ipAccessControlListSid The ip_access_control_list_sid
         * @return IpAccessControlListMappingCreator capable of executing the create
         */
        public static IpAccessControlListMappingCreator Create(string accountSid, string domainSid, string ipAccessControlListSid) {
            return new IpAccessControlListMappingCreator(accountSid, domainSid, ipAccessControlListSid);
        }
    
        /**
         * Create a IpAccessControlListMappingCreator to execute create.
         * 
         * @param domainSid The domain_sid
         * @param ipAccessControlListSid The ip_access_control_list_sid
         * @return IpAccessControlListMappingCreator capable of executing the create
         */
        public static IpAccessControlListMappingCreator Create(string domainSid, 
                                                               string ipAccessControlListSid) {
            return new IpAccessControlListMappingCreator(domainSid, ipAccessControlListSid);
        }
    
        /**
         * read
         * 
         * @param accountSid The account_sid
         * @param domainSid The domain_sid
         * @return IpAccessControlListMappingReader capable of executing the read
         */
        public static IpAccessControlListMappingReader Read(string accountSid, string domainSid) {
            return new IpAccessControlListMappingReader(accountSid, domainSid);
        }
    
        /**
         * Create a IpAccessControlListMappingReader to execute read.
         * 
         * @param domainSid The domain_sid
         * @return IpAccessControlListMappingReader capable of executing the read
         */
        public static IpAccessControlListMappingReader Read(string domainSid) {
            return new IpAccessControlListMappingReader(domainSid);
        }
    
        /**
         * delete
         * 
         * @param accountSid The account_sid
         * @param domainSid The domain_sid
         * @param sid The sid
         * @return IpAccessControlListMappingDeleter capable of executing the delete
         */
        public static IpAccessControlListMappingDeleter Delete(string accountSid, string domainSid, string sid) {
            return new IpAccessControlListMappingDeleter(accountSid, domainSid, sid);
        }
    
        /**
         * Create a IpAccessControlListMappingDeleter to execute delete.
         * 
         * @param domainSid The domain_sid
         * @param sid The sid
         * @return IpAccessControlListMappingDeleter capable of executing the delete
         */
        public static IpAccessControlListMappingDeleter Delete(string domainSid, 
                                                               string sid) {
            return new IpAccessControlListMappingDeleter(domainSid, sid);
        }
    
        /**
         * Converts a JSON string into a IpAccessControlListMappingResource object
         * 
         * @param json Raw JSON string
         * @return IpAccessControlListMappingResource object represented by the
         *         provided JSON
         */
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
    
        /**
         * @return The account_sid
         */
        public string GetAccountSid() {
            return this.accountSid;
        }
    
        /**
         * @return The date_created
         */
        public DateTime? GetDateCreated() {
            return this.dateCreated;
        }
    
        /**
         * @return The date_updated
         */
        public DateTime? GetDateUpdated() {
            return this.dateUpdated;
        }
    
        /**
         * @return The friendly_name
         */
        public string GetFriendlyName() {
            return this.friendlyName;
        }
    
        /**
         * @return The sid
         */
        public override string GetSid() {
            return this.sid;
        }
    
        /**
         * @return The uri
         */
        public string GetUri() {
            return this.uri;
        }
    }
}
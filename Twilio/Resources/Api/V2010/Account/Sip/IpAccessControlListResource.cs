using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Creators.Api.V2010.Account.Sip;
using Twilio.Deleters.Api.V2010.Account.Sip;
using Twilio.Exceptions;
using Twilio.Fetchers.Api.V2010.Account.Sip;
using Twilio.Http;
using Twilio.Readers.Api.V2010.Account.Sip;
using Twilio.Resources;
using Twilio.Updaters.Api.V2010.Account.Sip;

namespace Twilio.Resources.Api.V2010.Account.Sip {

    public class IpAccessControlListResource : SidResource {
        /**
         * Retrieve a list of ip-access-control-lists belonging to the account used to
         * make the request
         * 
         * @param accountSid The account_sid
         * @return IpAccessControlListReader capable of executing the read
         */
        public static IpAccessControlListReader Read(string accountSid) {
            return new IpAccessControlListReader(accountSid);
        }
    
        /**
         * Create a new IpAccessControlList resource
         * 
         * @param accountSid The account_sid
         * @param friendlyName A human readable description of this resource
         * @return IpAccessControlListCreator capable of executing the create
         */
        public static IpAccessControlListCreator Create(string accountSid, string friendlyName) {
            return new IpAccessControlListCreator(accountSid, friendlyName);
        }
    
        /**
         * Fetch a specific instance of an IpAccessControlList
         * 
         * @param accountSid The account_sid
         * @param sid Fetch by unique ip-access-control-list Sid
         * @return IpAccessControlListFetcher capable of executing the fetch
         */
        public static IpAccessControlListFetcher Fetch(string accountSid, string sid) {
            return new IpAccessControlListFetcher(accountSid, sid);
        }
    
        /**
         * Rename an IpAccessControlList
         * 
         * @param accountSid The account_sid
         * @param sid The sid
         * @param friendlyName A human readable description of this resource
         * @return IpAccessControlListUpdater capable of executing the update
         */
        public static IpAccessControlListUpdater Update(string accountSid, string sid, string friendlyName) {
            return new IpAccessControlListUpdater(accountSid, sid, friendlyName);
        }
    
        /**
         * Delete an IpAccessControlList from the requested account
         * 
         * @param accountSid The account_sid
         * @param sid Delete by unique ip-access-control-list Sid
         * @return IpAccessControlListDeleter capable of executing the delete
         */
        public static IpAccessControlListDeleter Delete(string accountSid, string sid) {
            return new IpAccessControlListDeleter(accountSid, sid);
        }
    
        /**
         * Converts a JSON string into a IpAccessControlListResource object
         * 
         * @param json Raw JSON string
         * @return IpAccessControlListResource object represented by the provided JSON
         */
        public static IpAccessControlListResource FromJson(string json) {
            // Convert all checked exceptions to Runtime
            try {
                return JsonConvert.DeserializeObject<IpAccessControlListResource>(json);
            } catch (JsonException e) {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("sid")]
        private readonly string sid;
        [JsonProperty("account_sid")]
        private readonly string accountSid;
        [JsonProperty("friendly_name")]
        private readonly string friendlyName;
        [JsonProperty("date_created")]
        private readonly DateTime? dateCreated;
        [JsonProperty("date_updated")]
        private readonly DateTime? dateUpdated;
        [JsonProperty("subresource_uris")]
        private readonly Dictionary<string, string> subresourceUris;
        [JsonProperty("uri")]
        private readonly string uri;
    
        public IpAccessControlListResource() {
        
        }
    
        private IpAccessControlListResource([JsonProperty("sid")]
                                            string sid, 
                                            [JsonProperty("account_sid")]
                                            string accountSid, 
                                            [JsonProperty("friendly_name")]
                                            string friendlyName, 
                                            [JsonProperty("date_created")]
                                            string dateCreated, 
                                            [JsonProperty("date_updated")]
                                            string dateUpdated, 
                                            [JsonProperty("subresource_uris")]
                                            Dictionary<string, string> subresourceUris, 
                                            [JsonProperty("uri")]
                                            string uri) {
            this.sid = sid;
            this.accountSid = accountSid;
            this.friendlyName = friendlyName;
            this.dateCreated = MarshalConverter.DateTimeFromString(dateCreated);
            this.dateUpdated = MarshalConverter.DateTimeFromString(dateUpdated);
            this.subresourceUris = subresourceUris;
            this.uri = uri;
        }
    
        /**
         * @return A string that uniquely identifies this resource
         */
        public override string GetSid() {
            return this.sid;
        }
    
        /**
         * @return The unique sid that identifies this account
         */
        public string GetAccountSid() {
            return this.accountSid;
        }
    
        /**
         * @return A human readable description of this resource
         */
        public string GetFriendlyName() {
            return this.friendlyName;
        }
    
        /**
         * @return The date this resource was created
         */
        public DateTime? GetDateCreated() {
            return this.dateCreated;
        }
    
        /**
         * @return The date this resource was last updated
         */
        public DateTime? GetDateUpdated() {
            return this.dateUpdated;
        }
    
        /**
         * @return The subresource_uris
         */
        public Dictionary<string, string> GetSubresourceUris() {
            return this.subresourceUris;
        }
    
        /**
         * @return The URI for this resource
         */
        public string GetUri() {
            return this.uri;
        }
    }
}
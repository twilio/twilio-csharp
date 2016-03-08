using Newtonsoft.Json;
using System;
using Twilio.Clients.TwilioRestClient;
using Twilio.Creators.Api.V2010.Account.Sip;
using Twilio.Deleters.Api.V2010.Account.Sip;
using Twilio.Exceptions;
using Twilio.Fetchers.Api.V2010.Account.Sip;
using Twilio.Http;
using Twilio.Readers.Api.V2010.Account.Sip;
using Twilio.Resources;
using Twilio.Updaters.Api.V2010.Account.Sip;
using com.twilio.sdk.converters.MarshalConverter;
using org.joda.time.DateTime;

namespace Twilio.Resources.Api.V2010.Account.Sip {

    public class IpAccessControlList : SidResource {
        /**
         * Retrieve a list of ip-access-control-lists belonging to the account used to
         * make the request
         * 
         * @param accountSid The account_sid
         * @return IpAccessControlListReader capable of executing the read
         */
        public static IpAccessControlListReader read(String accountSid) {
            return new IpAccessControlListReader(accountSid);
        }
    
        /**
         * Create a new IpAccessControlList resource
         * 
         * @param accountSid The account_sid
         * @param friendlyName A human readable description of this resource
         * @return IpAccessControlListCreator capable of executing the create
         */
        public static IpAccessControlListCreator create(String accountSid, String friendlyName) {
            return new IpAccessControlListCreator(accountSid, friendlyName);
        }
    
        /**
         * Fetch a specific instance of an IpAccessControlList
         * 
         * @param accountSid The account_sid
         * @param sid Fetch by unique ip-access-control-list Sid
         * @return IpAccessControlListFetcher capable of executing the fetch
         */
        public static IpAccessControlListFetcher fetch(String accountSid, String sid) {
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
        public static IpAccessControlListUpdater update(String accountSid, String sid, String friendlyName) {
            return new IpAccessControlListUpdater(accountSid, sid, friendlyName);
        }
    
        /**
         * Delete an IpAccessControlList from the requested account
         * 
         * @param accountSid The account_sid
         * @param sid Delete by unique ip-access-control-list Sid
         * @return IpAccessControlListDeleter capable of executing the delete
         */
        public static IpAccessControlListDeleter delete(String accountSid, String sid) {
            return new IpAccessControlListDeleter(accountSid, sid);
        }
    
        /**
         * Converts a JSON string into a IpAccessControlList object
         * 
         * @param json Raw JSON string
         * @return IpAccessControlList object represented by the provided JSON
         */
        public static IpAccessControlList fromJson(string json) {
            // Convert all checked exceptions to Runtime
            try {
                return JsonConvert.DeserializeObject<IpAccessControlList>(json);
            } catch (JsonException e) {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("sid")]
        private readonly String sid;
        [JsonProperty("account_sid")]
        private readonly String accountSid;
        [JsonProperty("friendly_name")]
        private readonly String friendlyName;
        [JsonProperty("date_created")]
        private readonly DateTime dateCreated;
        [JsonProperty("date_updated")]
        private readonly DateTime dateUpdated;
        [JsonProperty("subresource_uris")]
        private readonly Map<String, String> subresourceUris;
        [JsonProperty("uri")]
        private readonly String uri;
    
        private IpAccessControlList([JsonProperty("sid")]
                                    String sid, 
                                    [JsonProperty("account_sid")]
                                    String accountSid, 
                                    [JsonProperty("friendly_name")]
                                    String friendlyName, 
                                    [JsonProperty("date_created")]
                                    String dateCreated, 
                                    [JsonProperty("date_updated")]
                                    String dateUpdated, 
                                    [JsonProperty("subresource_uris")]
                                    Map<String, String> subresourceUris, 
                                    [JsonProperty("uri")]
                                    String uri) {
            this.sid = sid;
            this.accountSid = accountSid;
            this.friendlyName = friendlyName;
            this.dateCreated = MarshalConverter.dateTimeFromString(dateCreated);
            this.dateUpdated = MarshalConverter.dateTimeFromString(dateUpdated);
            this.subresourceUris = subresourceUris;
            this.uri = uri;
        }
    
        /**
         * @return A string that uniquely identifies this resource
         */
        public String GetSid() {
            return this.sid;
        }
    
        /**
         * @return The unique sid that identifies this account
         */
        public String GetAccountSid() {
            return this.accountSid;
        }
    
        /**
         * @return A human readable description of this resource
         */
        public String GetFriendlyName() {
            return this.friendlyName;
        }
    
        /**
         * @return The date this resource was created
         */
        public DateTime GetDateCreated() {
            return this.dateCreated;
        }
    
        /**
         * @return The date this resource was last updated
         */
        public DateTime GetDateUpdated() {
            return this.dateUpdated;
        }
    
        /**
         * @return The subresource_uris
         */
        public Map<String, String> GetSubresourceUris() {
            return this.subresourceUris;
        }
    
        /**
         * @return The URI for this resource
         */
        public String GetUri() {
            return this.uri;
        }
    }
}
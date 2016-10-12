using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Api.V2010.Account.Sip {

    public class IpAccessControlListResource : SidResource {
        /// <summary>
        /// Retrieve a list of ip-access-control-lists belonging to the account used to make the request
        /// </summary>
        ///
        /// <param name="accountSid"> The account_sid </param>
        /// <returns> IpAccessControlListReader capable of executing the read </returns> 
        public static IpAccessControlListReader Reader(string accountSid) {
            return new IpAccessControlListReader(accountSid);
        }
    
        /// <summary>
        /// Create a IpAccessControlListReader to execute read.
        /// </summary>
        ///
        /// <returns> IpAccessControlListReader capable of executing the read </returns> 
        public static IpAccessControlListReader Reader() {
            return new IpAccessControlListReader();
        }
    
        /// <summary>
        /// Create a new IpAccessControlList resource
        /// </summary>
        ///
        /// <param name="accountSid"> The account_sid </param>
        /// <param name="friendlyName"> A human readable description of this resource </param>
        /// <returns> IpAccessControlListCreator capable of executing the create </returns> 
        public static IpAccessControlListCreator Creator(string accountSid, string friendlyName) {
            return new IpAccessControlListCreator(accountSid, friendlyName);
        }
    
        /// <summary>
        /// Create a IpAccessControlListCreator to execute create.
        /// </summary>
        ///
        /// <param name="friendlyName"> A human readable description of this resource </param>
        /// <returns> IpAccessControlListCreator capable of executing the create </returns> 
        public static IpAccessControlListCreator Creator(string friendlyName) {
            return new IpAccessControlListCreator(friendlyName);
        }
    
        /// <summary>
        /// Fetch a specific instance of an IpAccessControlList
        /// </summary>
        ///
        /// <param name="accountSid"> The account_sid </param>
        /// <param name="sid"> Fetch by unique ip-access-control-list Sid </param>
        /// <returns> IpAccessControlListFetcher capable of executing the fetch </returns> 
        public static IpAccessControlListFetcher Fetcher(string accountSid, string sid) {
            return new IpAccessControlListFetcher(accountSid, sid);
        }
    
        /// <summary>
        /// Create a IpAccessControlListFetcher to execute fetch.
        /// </summary>
        ///
        /// <param name="sid"> Fetch by unique ip-access-control-list Sid </param>
        /// <returns> IpAccessControlListFetcher capable of executing the fetch </returns> 
        public static IpAccessControlListFetcher Fetcher(string sid) {
            return new IpAccessControlListFetcher(sid);
        }
    
        /// <summary>
        /// Rename an IpAccessControlList
        /// </summary>
        ///
        /// <param name="accountSid"> The account_sid </param>
        /// <param name="sid"> The sid </param>
        /// <param name="friendlyName"> A human readable description of this resource </param>
        /// <returns> IpAccessControlListUpdater capable of executing the update </returns> 
        public static IpAccessControlListUpdater Updater(string accountSid, string sid, string friendlyName) {
            return new IpAccessControlListUpdater(accountSid, sid, friendlyName);
        }
    
        /// <summary>
        /// Create a IpAccessControlListUpdater to execute update.
        /// </summary>
        ///
        /// <param name="sid"> The sid </param>
        /// <param name="friendlyName"> A human readable description of this resource </param>
        /// <returns> IpAccessControlListUpdater capable of executing the update </returns> 
        public static IpAccessControlListUpdater Updater(string sid, 
                                                         string friendlyName) {
            return new IpAccessControlListUpdater(sid, friendlyName);
        }
    
        /// <summary>
        /// Delete an IpAccessControlList from the requested account
        /// </summary>
        ///
        /// <param name="accountSid"> The account_sid </param>
        /// <param name="sid"> Delete by unique ip-access-control-list Sid </param>
        /// <returns> IpAccessControlListDeleter capable of executing the delete </returns> 
        public static IpAccessControlListDeleter Deleter(string accountSid, string sid) {
            return new IpAccessControlListDeleter(accountSid, sid);
        }
    
        /// <summary>
        /// Create a IpAccessControlListDeleter to execute delete.
        /// </summary>
        ///
        /// <param name="sid"> Delete by unique ip-access-control-list Sid </param>
        /// <returns> IpAccessControlListDeleter capable of executing the delete </returns> 
        public static IpAccessControlListDeleter Deleter(string sid) {
            return new IpAccessControlListDeleter(sid);
        }
    
        /// <summary>
        /// Converts a JSON string into a IpAccessControlListResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> IpAccessControlListResource object represented by the provided JSON </returns> 
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
    
        /// <returns> A string that uniquely identifies this resource </returns> 
        public override string GetSid() {
            return this.sid;
        }
    
        /// <returns> The unique sid that identifies this account </returns> 
        public string GetAccountSid() {
            return this.accountSid;
        }
    
        /// <returns> A human readable description of this resource </returns> 
        public string GetFriendlyName() {
            return this.friendlyName;
        }
    
        /// <returns> The date this resource was created </returns> 
        public DateTime? GetDateCreated() {
            return this.dateCreated;
        }
    
        /// <returns> The date this resource was last updated </returns> 
        public DateTime? GetDateUpdated() {
            return this.dateUpdated;
        }
    
        /// <returns> The subresource_uris </returns> 
        public Dictionary<string, string> GetSubresourceUris() {
            return this.subresourceUris;
        }
    
        /// <returns> The URI for this resource </returns> 
        public string GetUri() {
            return this.uri;
        }
    }
}
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Api.V2010.Account.Sip {

    public class IpAccessControlListResource : Resource {
        /// <summary>
        /// Retrieve a list of ip-access-control-lists belonging to the account used to make the request
        /// </summary>
        ///
        /// <param name="accountSid"> The account_sid </param>
        /// <returns> IpAccessControlListReader capable of executing the read </returns> 
        public static IpAccessControlListReader Reader(string accountSid=null) {
            return new IpAccessControlListReader(accountSid:accountSid);
        }
    
        /// <summary>
        /// Create a new IpAccessControlList resource
        /// </summary>
        ///
        /// <param name="friendlyName"> A human readable description of this resource </param>
        /// <param name="accountSid"> The account_sid </param>
        /// <returns> IpAccessControlListCreator capable of executing the create </returns> 
        public static IpAccessControlListCreator Creator(string friendlyName, string accountSid=null) {
            return new IpAccessControlListCreator(friendlyName, accountSid:accountSid);
        }
    
        /// <summary>
        /// Fetch a specific instance of an IpAccessControlList
        /// </summary>
        ///
        /// <param name="sid"> Fetch by unique ip-access-control-list Sid </param>
        /// <param name="accountSid"> The account_sid </param>
        /// <returns> IpAccessControlListFetcher capable of executing the fetch </returns> 
        public static IpAccessControlListFetcher Fetcher(string sid, string accountSid=null) {
            return new IpAccessControlListFetcher(sid, accountSid:accountSid);
        }
    
        /// <summary>
        /// Rename an IpAccessControlList
        /// </summary>
        ///
        /// <param name="sid"> The sid </param>
        /// <param name="friendlyName"> A human readable description of this resource </param>
        /// <param name="accountSid"> The account_sid </param>
        /// <returns> IpAccessControlListUpdater capable of executing the update </returns> 
        public static IpAccessControlListUpdater Updater(string sid, string friendlyName, string accountSid=null) {
            return new IpAccessControlListUpdater(sid, friendlyName, accountSid:accountSid);
        }
    
        /// <summary>
        /// Delete an IpAccessControlList from the requested account
        /// </summary>
        ///
        /// <param name="sid"> Delete by unique ip-access-control-list Sid </param>
        /// <param name="accountSid"> The account_sid </param>
        /// <returns> IpAccessControlListDeleter capable of executing the delete </returns> 
        public static IpAccessControlListDeleter Deleter(string sid, string accountSid=null) {
            return new IpAccessControlListDeleter(sid, accountSid:accountSid);
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
        public string sid { get; }
        [JsonProperty("account_sid")]
        public string accountSid { get; }
        [JsonProperty("friendly_name")]
        public string friendlyName { get; }
        [JsonProperty("date_created")]
        public DateTime? dateCreated { get; }
        [JsonProperty("date_updated")]
        public DateTime? dateUpdated { get; }
        [JsonProperty("subresource_uris")]
        public Dictionary<string, string> subresourceUris { get; }
        [JsonProperty("uri")]
        public string uri { get; }
    
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
    }
}
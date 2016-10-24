using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Api.V2010.Account.Sip {

    public class CredentialListResource : Resource {
        /// <summary>
        /// Retrieve a list of Credentials belonging to the account used to make the request
        /// </summary>
        ///
        /// <param name="accountSid"> The account_sid </param>
        /// <returns> CredentialListReader capable of executing the read </returns> 
        public static CredentialListReader Reader(string accountSid) {
            return new CredentialListReader(accountSid);
        }
    
        /// <summary>
        /// Create a CredentialListReader to execute read.
        /// </summary>
        ///
        /// <returns> CredentialListReader capable of executing the read </returns> 
        public static CredentialListReader Reader() {
            return new CredentialListReader();
        }
    
        /// <summary>
        /// Add a Credential to the list
        /// </summary>
        ///
        /// <param name="accountSid"> The account_sid </param>
        /// <param name="friendlyName"> The friendly_name </param>
        /// <returns> CredentialListCreator capable of executing the create </returns> 
        public static CredentialListCreator Creator(string accountSid, string friendlyName) {
            return new CredentialListCreator(accountSid, friendlyName);
        }
    
        /// <summary>
        /// Create a CredentialListCreator to execute create.
        /// </summary>
        ///
        /// <param name="friendlyName"> The friendly_name </param>
        /// <returns> CredentialListCreator capable of executing the create </returns> 
        public static CredentialListCreator Creator(string friendlyName) {
            return new CredentialListCreator(friendlyName);
        }
    
        /// <summary>
        /// Retrieve a specific Credential in a list
        /// </summary>
        ///
        /// <param name="accountSid"> The account_sid </param>
        /// <param name="sid"> Fetch by unique credential Sid </param>
        /// <returns> CredentialListFetcher capable of executing the fetch </returns> 
        public static CredentialListFetcher Fetcher(string accountSid, string sid) {
            return new CredentialListFetcher(accountSid, sid);
        }
    
        /// <summary>
        /// Create a CredentialListFetcher to execute fetch.
        /// </summary>
        ///
        /// <param name="sid"> Fetch by unique credential Sid </param>
        /// <returns> CredentialListFetcher capable of executing the fetch </returns> 
        public static CredentialListFetcher Fetcher(string sid) {
            return new CredentialListFetcher(sid);
        }
    
        /// <summary>
        /// Change the password of a Credential record
        /// </summary>
        ///
        /// <param name="accountSid"> The account_sid </param>
        /// <param name="sid"> The sid </param>
        /// <param name="friendlyName"> The friendly_name </param>
        /// <returns> CredentialListUpdater capable of executing the update </returns> 
        public static CredentialListUpdater Updater(string accountSid, string sid, string friendlyName) {
            return new CredentialListUpdater(accountSid, sid, friendlyName);
        }
    
        /// <summary>
        /// Create a CredentialListUpdater to execute update.
        /// </summary>
        ///
        /// <param name="sid"> The sid </param>
        /// <param name="friendlyName"> The friendly_name </param>
        /// <returns> CredentialListUpdater capable of executing the update </returns> 
        public static CredentialListUpdater Updater(string sid, 
                                                    string friendlyName) {
            return new CredentialListUpdater(sid, friendlyName);
        }
    
        /// <summary>
        /// Remove a credential from a CredentialList
        /// </summary>
        ///
        /// <param name="accountSid"> The account_sid </param>
        /// <param name="sid"> Delete by unique credential Sid </param>
        /// <returns> CredentialListDeleter capable of executing the delete </returns> 
        public static CredentialListDeleter Deleter(string accountSid, string sid) {
            return new CredentialListDeleter(accountSid, sid);
        }
    
        /// <summary>
        /// Create a CredentialListDeleter to execute delete.
        /// </summary>
        ///
        /// <param name="sid"> Delete by unique credential Sid </param>
        /// <returns> CredentialListDeleter capable of executing the delete </returns> 
        public static CredentialListDeleter Deleter(string sid) {
            return new CredentialListDeleter(sid);
        }
    
        /// <summary>
        /// Converts a JSON string into a CredentialListResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> CredentialListResource object represented by the provided JSON </returns> 
        public static CredentialListResource FromJson(string json) {
            // Convert all checked exceptions to Runtime
            try {
                return JsonConvert.DeserializeObject<CredentialListResource>(json);
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
        [JsonProperty("subresource_uris")]
        public Dictionary<string, string> subresourceUris { get; }
        [JsonProperty("uri")]
        public string uri { get; }
    
        public CredentialListResource() {
        
        }
    
        private CredentialListResource([JsonProperty("account_sid")]
                                       string accountSid, 
                                       [JsonProperty("date_created")]
                                       string dateCreated, 
                                       [JsonProperty("date_updated")]
                                       string dateUpdated, 
                                       [JsonProperty("friendly_name")]
                                       string friendlyName, 
                                       [JsonProperty("sid")]
                                       string sid, 
                                       [JsonProperty("subresource_uris")]
                                       Dictionary<string, string> subresourceUris, 
                                       [JsonProperty("uri")]
                                       string uri) {
            this.accountSid = accountSid;
            this.dateCreated = MarshalConverter.DateTimeFromString(dateCreated);
            this.dateUpdated = MarshalConverter.DateTimeFromString(dateUpdated);
            this.friendlyName = friendlyName;
            this.sid = sid;
            this.subresourceUris = subresourceUris;
            this.uri = uri;
        }
    }
}
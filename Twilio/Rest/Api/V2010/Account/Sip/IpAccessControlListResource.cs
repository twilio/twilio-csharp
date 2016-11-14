using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Api.V2010.Account.Sip 
{

    public class IpAccessControlListResource : Resource 
    {
        /// <summary>
        /// Retrieve a list of ip-access-control-lists belonging to the account used to make the request
        /// </summary>
        ///
        /// <returns> IpAccessControlListReader capable of executing the read </returns> 
        public static IpAccessControlListReader Reader()
        {
            return new IpAccessControlListReader();
        }
    
        /// <summary>
        /// Create a new IpAccessControlList resource
        /// </summary>
        ///
        /// <param name="friendlyName"> A human readable description of this resource </param>
        /// <returns> IpAccessControlListCreator capable of executing the create </returns> 
        public static IpAccessControlListCreator Creator(string friendlyName)
        {
            return new IpAccessControlListCreator(friendlyName);
        }
    
        /// <summary>
        /// Fetch a specific instance of an IpAccessControlList
        /// </summary>
        ///
        /// <param name="sid"> Fetch by unique ip-access-control-list Sid </param>
        /// <returns> IpAccessControlListFetcher capable of executing the fetch </returns> 
        public static IpAccessControlListFetcher Fetcher(string sid)
        {
            return new IpAccessControlListFetcher(sid);
        }
    
        /// <summary>
        /// Rename an IpAccessControlList
        /// </summary>
        ///
        /// <param name="sid"> The sid </param>
        /// <param name="friendlyName"> A human readable description of this resource </param>
        /// <returns> IpAccessControlListUpdater capable of executing the update </returns> 
        public static IpAccessControlListUpdater Updater(string sid, string friendlyName)
        {
            return new IpAccessControlListUpdater(sid, friendlyName);
        }
    
        /// <summary>
        /// Delete an IpAccessControlList from the requested account
        /// </summary>
        ///
        /// <param name="sid"> Delete by unique ip-access-control-list Sid </param>
        /// <returns> IpAccessControlListDeleter capable of executing the delete </returns> 
        public static IpAccessControlListDeleter Deleter(string sid)
        {
            return new IpAccessControlListDeleter(sid);
        }
    
        /// <summary>
        /// Converts a JSON string into a IpAccessControlListResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> IpAccessControlListResource object represented by the provided JSON </returns> 
        public static IpAccessControlListResource FromJson(string json)
        {
            // Convert all checked exceptions to Runtime
            try
            {
                return JsonConvert.DeserializeObject<IpAccessControlListResource>(json);
            }
            catch (JsonException e)
            {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("sid")]
        public string Sid { get; set; }
        [JsonProperty("account_sid")]
        public string AccountSid { get; set; }
        [JsonProperty("friendly_name")]
        public string FriendlyName { get; set; }
        [JsonProperty("date_created")]
        public DateTime? DateCreated { get; set; }
        [JsonProperty("date_updated")]
        public DateTime? DateUpdated { get; set; }
        [JsonProperty("subresource_uris")]
        public Dictionary<string, string> SubresourceUris { get; set; }
        [JsonProperty("uri")]
        public string Uri { get; set; }
    
        public IpAccessControlListResource()
        {
        
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
                                            string uri)
                                            {
            Sid = sid;
            AccountSid = accountSid;
            FriendlyName = friendlyName;
            DateCreated = MarshalConverter.DateTimeFromString(dateCreated);
            DateUpdated = MarshalConverter.DateTimeFromString(dateUpdated);
            SubresourceUris = subresourceUris;
            Uri = uri;
        }
    }
}
using Newtonsoft.Json;
using System;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Chat.V1.Service 
{

    public class UserResource : Resource 
    {
        /// <summary>
        /// fetch
        /// </summary>
        ///
        /// <param name="serviceSid"> The service_sid </param>
        /// <param name="sid"> The sid </param>
        /// <returns> UserFetcher capable of executing the fetch </returns> 
        public static UserFetcher Fetcher(string serviceSid, string sid)
        {
            return new UserFetcher(serviceSid, sid);
        }
    
        /// <summary>
        /// delete
        /// </summary>
        ///
        /// <param name="serviceSid"> The service_sid </param>
        /// <param name="sid"> The sid </param>
        /// <returns> UserDeleter capable of executing the delete </returns> 
        public static UserDeleter Deleter(string serviceSid, string sid)
        {
            return new UserDeleter(serviceSid, sid);
        }
    
        /// <summary>
        /// create
        /// </summary>
        ///
        /// <param name="serviceSid"> The service_sid </param>
        /// <param name="identity"> The identity </param>
        /// <returns> UserCreator capable of executing the create </returns> 
        public static UserCreator Creator(string serviceSid, string identity)
        {
            return new UserCreator(serviceSid, identity);
        }
    
        /// <summary>
        /// read
        /// </summary>
        ///
        /// <param name="serviceSid"> The service_sid </param>
        /// <returns> UserReader capable of executing the read </returns> 
        public static UserReader Reader(string serviceSid)
        {
            return new UserReader(serviceSid);
        }
    
        /// <summary>
        /// update
        /// </summary>
        ///
        /// <param name="serviceSid"> The service_sid </param>
        /// <param name="sid"> The sid </param>
        /// <returns> UserUpdater capable of executing the update </returns> 
        public static UserUpdater Updater(string serviceSid, string sid)
        {
            return new UserUpdater(serviceSid, sid);
        }
    
        /// <summary>
        /// Converts a JSON string into a UserResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> UserResource object represented by the provided JSON </returns> 
        public static UserResource FromJson(string json)
        {
            // Convert all checked exceptions to Runtime
            try
            {
                return JsonConvert.DeserializeObject<UserResource>(json);
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
        [JsonProperty("service_sid")]
        public string ServiceSid { get; set; }
        [JsonProperty("role_sid")]
        public string RoleSid { get; set; }
        [JsonProperty("attributes")]
        public string Attributes { get; set; }
        [JsonProperty("friendly_name")]
        public string FriendlyName { get; set; }
        [JsonProperty("identity")]
        public string Identity { get; set; }
        [JsonProperty("date_created")]
        public DateTime? DateCreated { get; set; }
        [JsonProperty("date_updated")]
        public DateTime? DateUpdated { get; set; }
        [JsonProperty("url")]
        public Uri Url { get; set; }
    
        public UserResource()
        {
        
        }
    
        private UserResource([JsonProperty("sid")]
                             string sid, 
                             [JsonProperty("account_sid")]
                             string accountSid, 
                             [JsonProperty("service_sid")]
                             string serviceSid, 
                             [JsonProperty("role_sid")]
                             string roleSid, 
                             [JsonProperty("attributes")]
                             string attributes, 
                             [JsonProperty("friendly_name")]
                             string friendlyName, 
                             [JsonProperty("identity")]
                             string identity, 
                             [JsonProperty("date_created")]
                             string dateCreated, 
                             [JsonProperty("date_updated")]
                             string dateUpdated, 
                             [JsonProperty("url")]
                             Uri url)
                             {
            Sid = sid;
            AccountSid = accountSid;
            ServiceSid = serviceSid;
            RoleSid = roleSid;
            Attributes = attributes;
            FriendlyName = friendlyName;
            Identity = identity;
            DateCreated = MarshalConverter.DateTimeFromString(dateCreated);
            DateUpdated = MarshalConverter.DateTimeFromString(dateUpdated);
            Url = url;
        }
    }
}
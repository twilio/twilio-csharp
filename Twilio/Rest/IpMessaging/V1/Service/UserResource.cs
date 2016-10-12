using Newtonsoft.Json;
using System;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.IpMessaging.V1.Service {

    public class UserResource : SidResource {
        /// <summary>
        /// fetch
        /// </summary>
        ///
        /// <param name="serviceSid"> The service_sid </param>
        /// <param name="sid"> The sid </param>
        /// <returns> UserFetcher capable of executing the fetch </returns> 
        public static UserFetcher Fetcher(string serviceSid, string sid) {
            return new UserFetcher(serviceSid, sid);
        }
    
        /// <summary>
        /// delete
        /// </summary>
        ///
        /// <param name="serviceSid"> The service_sid </param>
        /// <param name="sid"> The sid </param>
        /// <returns> UserDeleter capable of executing the delete </returns> 
        public static UserDeleter Deleter(string serviceSid, string sid) {
            return new UserDeleter(serviceSid, sid);
        }
    
        /// <summary>
        /// create
        /// </summary>
        ///
        /// <param name="serviceSid"> The service_sid </param>
        /// <param name="identity"> The identity </param>
        /// <returns> UserCreator capable of executing the create </returns> 
        public static UserCreator Creator(string serviceSid, string identity) {
            return new UserCreator(serviceSid, identity);
        }
    
        /// <summary>
        /// read
        /// </summary>
        ///
        /// <param name="serviceSid"> The service_sid </param>
        /// <returns> UserReader capable of executing the read </returns> 
        public static UserReader Reader(string serviceSid) {
            return new UserReader(serviceSid);
        }
    
        /// <summary>
        /// update
        /// </summary>
        ///
        /// <param name="serviceSid"> The service_sid </param>
        /// <param name="sid"> The sid </param>
        /// <returns> UserUpdater capable of executing the update </returns> 
        public static UserUpdater Updater(string serviceSid, string sid) {
            return new UserUpdater(serviceSid, sid);
        }
    
        /// <summary>
        /// Converts a JSON string into a UserResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> UserResource object represented by the provided JSON </returns> 
        public static UserResource FromJson(string json) {
            // Convert all checked exceptions to Runtime
            try {
                return JsonConvert.DeserializeObject<UserResource>(json);
            } catch (JsonException e) {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("sid")]
        private readonly string sid;
        [JsonProperty("account_sid")]
        private readonly string accountSid;
        [JsonProperty("service_sid")]
        private readonly string serviceSid;
        [JsonProperty("role_sid")]
        private readonly string roleSid;
        [JsonProperty("identity")]
        private readonly string identity;
        [JsonProperty("date_created")]
        private readonly DateTime? dateCreated;
        [JsonProperty("date_updated")]
        private readonly DateTime? dateUpdated;
        [JsonProperty("url")]
        private readonly Uri url;
    
        public UserResource() {
        
        }
    
        private UserResource([JsonProperty("sid")]
                             string sid, 
                             [JsonProperty("account_sid")]
                             string accountSid, 
                             [JsonProperty("service_sid")]
                             string serviceSid, 
                             [JsonProperty("role_sid")]
                             string roleSid, 
                             [JsonProperty("identity")]
                             string identity, 
                             [JsonProperty("date_created")]
                             string dateCreated, 
                             [JsonProperty("date_updated")]
                             string dateUpdated, 
                             [JsonProperty("url")]
                             Uri url) {
            this.sid = sid;
            this.accountSid = accountSid;
            this.serviceSid = serviceSid;
            this.roleSid = roleSid;
            this.identity = identity;
            this.dateCreated = MarshalConverter.DateTimeFromString(dateCreated);
            this.dateUpdated = MarshalConverter.DateTimeFromString(dateUpdated);
            this.url = url;
        }
    
        /// <returns> The sid </returns> 
        public override string GetSid() {
            return this.sid;
        }
    
        /// <returns> The account_sid </returns> 
        public string GetAccountSid() {
            return this.accountSid;
        }
    
        /// <returns> The service_sid </returns> 
        public string GetServiceSid() {
            return this.serviceSid;
        }
    
        /// <returns> The role_sid </returns> 
        public string GetRoleSid() {
            return this.roleSid;
        }
    
        /// <returns> The identity </returns> 
        public string GetIdentity() {
            return this.identity;
        }
    
        /// <returns> The date_created </returns> 
        public DateTime? GetDateCreated() {
            return this.dateCreated;
        }
    
        /// <returns> The date_updated </returns> 
        public DateTime? GetDateUpdated() {
            return this.dateUpdated;
        }
    
        /// <returns> The url </returns> 
        public Uri GetUrl() {
            return this.url;
        }
    }
}
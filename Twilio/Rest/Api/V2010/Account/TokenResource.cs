using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Types;

namespace Twilio.Rest.Api.V2010.Account 
{

    public class TokenResource : Resource 
    {
        /// <summary>
        /// Create a new token
        /// </summary>
        ///
        /// <returns> TokenCreator capable of executing the create </returns> 
        public static TokenCreator Creator()
        {
            return new TokenCreator();
        }
    
        /// <summary>
        /// Converts a JSON string into a TokenResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> TokenResource object represented by the provided JSON </returns> 
        public static TokenResource FromJson(string json)
        {
            // Convert all checked exceptions to Runtime
            try
            {
                return JsonConvert.DeserializeObject<TokenResource>(json);
            }
            catch (JsonException e)
            {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("account_sid")]
        public string AccountSid { get; set; }
        [JsonProperty("date_created")]
        public DateTime? DateCreated { get; set; }
        [JsonProperty("date_updated")]
        public DateTime? DateUpdated { get; set; }
        [JsonProperty("ice_servers")]
        public List<IceServer> IceServers { get; set; }
        [JsonProperty("password")]
        public string Password { get; set; }
        [JsonProperty("ttl")]
        public string Ttl { get; set; }
        [JsonProperty("username")]
        public string Username { get; set; }
    
        public TokenResource()
        {
        
        }
    
        private TokenResource([JsonProperty("account_sid")]
                              string accountSid, 
                              [JsonProperty("date_created")]
                              string dateCreated, 
                              [JsonProperty("date_updated")]
                              string dateUpdated, 
                              [JsonProperty("ice_servers")]
                              List<IceServer> iceServers, 
                              [JsonProperty("password")]
                              string password, 
                              [JsonProperty("ttl")]
                              string ttl, 
                              [JsonProperty("username")]
                              string username)
                              {
            AccountSid = accountSid;
            DateCreated = MarshalConverter.DateTimeFromString(dateCreated);
            DateUpdated = MarshalConverter.DateTimeFromString(dateUpdated);
            IceServers = iceServers;
            Password = password;
            Ttl = ttl;
            Username = username;
        }
    }
}
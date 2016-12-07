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
        private static Request BuildCreateRequest(CreateTokenOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Post,
                Rest.Domain.Api,
                "/2010-04-01/Accounts/" + (options.AccountSid ?? client.AccountSid) + "/Tokens.json",
                client.Region,
                postParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// Create a new token
        /// </summary>
        public static TokenResource Create(CreateTokenOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildCreateRequest(options, client));
            return FromJson(response.Content);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<TokenResource> CreateAsync(CreateTokenOptions options, ITwilioRestClient client)
        {
            var response = await System.Threading.Tasks.Task.FromResult(Create(options, client));
            return response;
        }
        #endif
    
        /// <summary>
        /// Create a new token
        /// </summary>
        public static TokenResource Create(string accountSid = null, int? ttl = null, ITwilioRestClient client = null)
        {
            var options = new CreateTokenOptions{AccountSid = accountSid, Ttl = ttl};
            return Create(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<TokenResource> CreateAsync(string accountSid = null, int? ttl = null, ITwilioRestClient client = null)
        {
            var options = new CreateTokenOptions{AccountSid = accountSid, Ttl = ttl};
            var response = await System.Threading.Tasks.Task.FromResult(Create(options, client));
            return response;
        }
        #endif
    
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
        public string AccountSid { get; private set; }
        [JsonProperty("date_created")]
        public DateTime? DateCreated { get; private set; }
        [JsonProperty("date_updated")]
        public DateTime? DateUpdated { get; private set; }
        [JsonProperty("ice_servers")]
        public List<IceServer> IceServers { get; private set; }
        [JsonProperty("password")]
        public string Password { get; private set; }
        [JsonProperty("ttl")]
        public string Ttl { get; private set; }
        [JsonProperty("username")]
        public string Username { get; private set; }
    
        private TokenResource()
        {
        
        }
    }

}
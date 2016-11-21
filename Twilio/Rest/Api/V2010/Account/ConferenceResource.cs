using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Types;

namespace Twilio.Rest.Api.V2010.Account 
{

    public class ConferenceResource : Resource 
    {
        public sealed class StatusEnum : StringEnum 
        {
            private StatusEnum(string value) : base(value) {}
            public StatusEnum() {}
        
            public static readonly StatusEnum Init = new StatusEnum("init");
            public static readonly StatusEnum InProgress = new StatusEnum("in-progress");
            public static readonly StatusEnum Completed = new StatusEnum("completed");
        }
    
        /// <summary>
        /// Fetch an instance of a conference
        /// </summary>
        ///
        /// <param name="sid"> Fetch by unique conference Sid </param>
        /// <returns> ConferenceFetcher capable of executing the fetch </returns> 
        public static ConferenceFetcher Fetcher(string sid)
        {
            return new ConferenceFetcher(sid);
        }
    
        /// <summary>
        /// Retrieve a list of conferences belonging to the account used to make the request
        /// </summary>
        ///
        /// <returns> ConferenceReader capable of executing the read </returns> 
        public static ConferenceReader Reader()
        {
            return new ConferenceReader();
        }
    
        /// <summary>
        /// Converts a JSON string into a ConferenceResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> ConferenceResource object represented by the provided JSON </returns> 
        public static ConferenceResource FromJson(string json)
        {
            // Convert all checked exceptions to Runtime
            try
            {
                return JsonConvert.DeserializeObject<ConferenceResource>(json);
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
        [JsonProperty("api_version")]
        public string ApiVersion { get; set; }
        [JsonProperty("friendly_name")]
        public string FriendlyName { get; set; }
        [JsonProperty("sid")]
        public string Sid { get; set; }
        [JsonProperty("status")]
        [JsonConverter(typeof(StringEnumConverter))]
        public ConferenceResource.StatusEnum Status { get; set; }
        [JsonProperty("uri")]
        public string Uri { get; set; }
        [JsonProperty("subresource_uris")]
        public Dictionary<string, string> SubresourceUris { get; set; }
    
        public ConferenceResource()
        {
        
        }
    
        private ConferenceResource([JsonProperty("account_sid")]
                                   string accountSid, 
                                   [JsonProperty("date_created")]
                                   string dateCreated, 
                                   [JsonProperty("date_updated")]
                                   string dateUpdated, 
                                   [JsonProperty("api_version")]
                                   string apiVersion, 
                                   [JsonProperty("friendly_name")]
                                   string friendlyName, 
                                   [JsonProperty("sid")]
                                   string sid, 
                                   [JsonProperty("status")]
                                   ConferenceResource.StatusEnum status, 
                                   [JsonProperty("uri")]
                                   string uri, 
                                   [JsonProperty("subresource_uris")]
                                   Dictionary<string, string> subresourceUris)
                                   {
            AccountSid = accountSid;
            DateCreated = MarshalConverter.DateTimeFromString(dateCreated);
            DateUpdated = MarshalConverter.DateTimeFromString(dateUpdated);
            ApiVersion = apiVersion;
            FriendlyName = friendlyName;
            Sid = sid;
            Status = status;
            Uri = uri;
            SubresourceUris = subresourceUris;
        }
    }
}
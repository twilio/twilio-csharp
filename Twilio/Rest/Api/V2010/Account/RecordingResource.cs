using Newtonsoft.Json;
using System;
using Twilio.Base;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Types;

namespace Twilio.Rest.Api.V2010.Account 
{

    public class RecordingResource : Resource 
    {
        public sealed class SourceEnum : StringEnum 
        {
            private SourceEnum(string value) : base(value) {}
            public SourceEnum() {}
        
            public static readonly SourceEnum Dialverb = new SourceEnum("DialVerb");
            public static readonly SourceEnum Conference = new SourceEnum("Conference");
            public static readonly SourceEnum Outboundapi = new SourceEnum("OutboundAPI");
            public static readonly SourceEnum Trunking = new SourceEnum("Trunking");
            public static readonly SourceEnum Recordverb = new SourceEnum("RecordVerb");
        }
    
        public sealed class StatusEnum : StringEnum 
        {
            private StatusEnum(string value) : base(value) {}
            public StatusEnum() {}
        
            public static readonly StatusEnum Processing = new StatusEnum("processing");
            public static readonly StatusEnum Completed = new StatusEnum("completed");
        }
    
        /// <summary>
        /// Fetch an instance of a recording
        /// </summary>
        ///
        /// <param name="sid"> Fetch by unique recording Sid </param>
        /// <returns> RecordingFetcher capable of executing the fetch </returns> 
        public static RecordingFetcher Fetcher(string sid)
        {
            return new RecordingFetcher(sid);
        }
    
        /// <summary>
        /// Delete a recording from your account
        /// </summary>
        ///
        /// <param name="sid"> Delete by unique recording Sid </param>
        /// <returns> RecordingDeleter capable of executing the delete </returns> 
        public static RecordingDeleter Deleter(string sid)
        {
            return new RecordingDeleter(sid);
        }
    
        /// <summary>
        /// Retrieve a list of recordings belonging to the account used to make the request
        /// </summary>
        ///
        /// <returns> RecordingReader capable of executing the read </returns> 
        public static RecordingReader Reader()
        {
            return new RecordingReader();
        }
    
        /// <summary>
        /// Converts a JSON string into a RecordingResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> RecordingResource object represented by the provided JSON </returns> 
        public static RecordingResource FromJson(string json)
        {
            // Convert all checked exceptions to Runtime
            try
            {
                return JsonConvert.DeserializeObject<RecordingResource>(json);
            }
            catch (JsonException e)
            {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("account_sid")]
        public string AccountSid { get; set; }
        [JsonProperty("api_version")]
        public string ApiVersion { get; set; }
        [JsonProperty("call_sid")]
        public string CallSid { get; set; }
        [JsonProperty("date_created")]
        public DateTime? DateCreated { get; set; }
        [JsonProperty("date_updated")]
        public DateTime? DateUpdated { get; set; }
        [JsonProperty("duration")]
        public string Duration { get; set; }
        [JsonProperty("sid")]
        public string Sid { get; set; }
        [JsonProperty("price")]
        public string Price { get; set; }
        [JsonProperty("price_unit")]
        public string PriceUnit { get; set; }
        [JsonProperty("status")]
        [JsonConverter(typeof(StringEnumConverter))]
        public RecordingResource.StatusEnum Status { get; set; }
        [JsonProperty("channels")]
        public int? Channels { get; set; }
        [JsonProperty("source")]
        [JsonConverter(typeof(StringEnumConverter))]
        public RecordingResource.SourceEnum Source { get; set; }
        [JsonProperty("uri")]
        public string Uri { get; set; }
    
        public RecordingResource()
        {
        
        }
    
        private RecordingResource([JsonProperty("account_sid")]
                                  string accountSid, 
                                  [JsonProperty("api_version")]
                                  string apiVersion, 
                                  [JsonProperty("call_sid")]
                                  string callSid, 
                                  [JsonProperty("date_created")]
                                  string dateCreated, 
                                  [JsonProperty("date_updated")]
                                  string dateUpdated, 
                                  [JsonProperty("duration")]
                                  string duration, 
                                  [JsonProperty("sid")]
                                  string sid, 
                                  [JsonProperty("price")]
                                  string price, 
                                  [JsonProperty("price_unit")]
                                  string priceUnit, 
                                  [JsonProperty("status")]
                                  RecordingResource.StatusEnum status, 
                                  [JsonProperty("channels")]
                                  int? channels, 
                                  [JsonProperty("source")]
                                  RecordingResource.SourceEnum source, 
                                  [JsonProperty("uri")]
                                  string uri)
                                  {
            AccountSid = accountSid;
            ApiVersion = apiVersion;
            CallSid = callSid;
            DateCreated = MarshalConverter.DateTimeFromString(dateCreated);
            DateUpdated = MarshalConverter.DateTimeFromString(dateUpdated);
            Duration = duration;
            Sid = sid;
            Price = price;
            PriceUnit = priceUnit;
            Status = status;
            Channels = channels;
            Source = source;
            Uri = uri;
        }
    }
}
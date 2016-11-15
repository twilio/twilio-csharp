using Newtonsoft.Json;
using System;
using Twilio.Base;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Types;

namespace Twilio.Rest.Api.V2010.Account 
{

    public class TranscriptionResource : Resource 
    {
        public sealed class StatusEnum : StringEnum 
        {
            private StatusEnum(string value) : base(value) {}
            public StatusEnum() {}
        
            public static readonly StatusEnum InProgress = new StatusEnum("in-progress");
            public static readonly StatusEnum Completed = new StatusEnum("completed");
            public static readonly StatusEnum Failed = new StatusEnum("failed");
        }
    
        /// <summary>
        /// Fetch and instance of a Transcription
        /// </summary>
        ///
        /// <param name="sid"> Fetch by unique transcription Sid </param>
        /// <returns> TranscriptionFetcher capable of executing the fetch </returns> 
        public static TranscriptionFetcher Fetcher(string sid)
        {
            return new TranscriptionFetcher(sid);
        }
    
        /// <summary>
        /// Delete a transcription from the account used to make the request
        /// </summary>
        ///
        /// <param name="sid"> Delete by unique transcription Sid </param>
        /// <returns> TranscriptionDeleter capable of executing the delete </returns> 
        public static TranscriptionDeleter Deleter(string sid)
        {
            return new TranscriptionDeleter(sid);
        }
    
        /// <summary>
        /// Retrieve a list of transcriptions belonging to the account used to make the request
        /// </summary>
        ///
        /// <returns> TranscriptionReader capable of executing the read </returns> 
        public static TranscriptionReader Reader()
        {
            return new TranscriptionReader();
        }
    
        /// <summary>
        /// Converts a JSON string into a TranscriptionResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> TranscriptionResource object represented by the provided JSON </returns> 
        public static TranscriptionResource FromJson(string json)
        {
            // Convert all checked exceptions to Runtime
            try
            {
                return JsonConvert.DeserializeObject<TranscriptionResource>(json);
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
        [JsonProperty("date_created")]
        public DateTime? DateCreated { get; set; }
        [JsonProperty("date_updated")]
        public DateTime? DateUpdated { get; set; }
        [JsonProperty("duration")]
        public string Duration { get; set; }
        [JsonProperty("price")]
        public decimal? Price { get; set; }
        [JsonProperty("price_unit")]
        public string PriceUnit { get; set; }
        [JsonProperty("recording_sid")]
        public string RecordingSid { get; set; }
        [JsonProperty("sid")]
        public string Sid { get; set; }
        [JsonProperty("status")]
        [JsonConverter(typeof(StringEnumConverter))]
        public TranscriptionResource.StatusEnum Status { get; set; }
        [JsonProperty("transcription_text")]
        public string TranscriptionText { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("uri")]
        public string Uri { get; set; }
    
        public TranscriptionResource()
        {
        
        }
    
        private TranscriptionResource([JsonProperty("account_sid")]
                                      string accountSid, 
                                      [JsonProperty("api_version")]
                                      string apiVersion, 
                                      [JsonProperty("date_created")]
                                      string dateCreated, 
                                      [JsonProperty("date_updated")]
                                      string dateUpdated, 
                                      [JsonProperty("duration")]
                                      string duration, 
                                      [JsonProperty("price")]
                                      decimal? price, 
                                      [JsonProperty("price_unit")]
                                      string priceUnit, 
                                      [JsonProperty("recording_sid")]
                                      string recordingSid, 
                                      [JsonProperty("sid")]
                                      string sid, 
                                      [JsonProperty("status")]
                                      TranscriptionResource.StatusEnum status, 
                                      [JsonProperty("transcription_text")]
                                      string transcriptionText, 
                                      [JsonProperty("type")]
                                      string type, 
                                      [JsonProperty("uri")]
                                      string uri)
                                      {
            AccountSid = accountSid;
            ApiVersion = apiVersion;
            DateCreated = MarshalConverter.DateTimeFromString(dateCreated);
            DateUpdated = MarshalConverter.DateTimeFromString(dateUpdated);
            Duration = duration;
            Price = price;
            PriceUnit = priceUnit;
            RecordingSid = recordingSid;
            Sid = sid;
            Status = status;
            TranscriptionText = transcriptionText;
            Type = type;
            Uri = uri;
        }
    }
}
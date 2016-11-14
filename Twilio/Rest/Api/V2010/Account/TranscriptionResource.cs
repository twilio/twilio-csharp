using Newtonsoft.Json;
using System;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Api.V2010.Account 
{

    public class TranscriptionResource : Resource 
    {
        public sealed class TranscriptionStatus : IStringEnum 
        {
            public const string InProgress = "in-progress";
            public const string Completed = "completed";
            public const string Failed = "failed";
        
            private string _value;
            
            public TranscriptionStatus() {}
            
            public TranscriptionStatus(string value)
            {
                _value = value;
            }
            
            public override string ToString()
            {
                return _value;
            }
            
            public static implicit operator TranscriptionStatus(string value)
            {
                return new TranscriptionStatus(value);
            }
            
            public static implicit operator string(TranscriptionStatus value)
            {
                return value.ToString();
            }
            
            public void FromString(string value)
            {
                _value = value;
            }
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
        public string accountSid { get; set; }
        [JsonProperty("api_version")]
        public string apiVersion { get; set; }
        [JsonProperty("date_created")]
        public DateTime? dateCreated { get; set; }
        [JsonProperty("date_updated")]
        public DateTime? dateUpdated { get; set; }
        [JsonProperty("duration")]
        public string duration { get; set; }
        [JsonProperty("price")]
        public decimal? price { get; set; }
        [JsonProperty("price_unit")]
        public string priceUnit { get; set; }
        [JsonProperty("recording_sid")]
        public string recordingSid { get; set; }
        [JsonProperty("sid")]
        public string sid { get; set; }
        [JsonProperty("status")]
        [JsonConverter(typeof(StringEnumConverter))]
        public TranscriptionResource.TranscriptionStatus status { get; set; }
        [JsonProperty("transcription_text")]
        public string transcriptionText { get; set; }
        [JsonProperty("type")]
        public string type { get; set; }
        [JsonProperty("uri")]
        public string uri { get; set; }
    
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
                                      TranscriptionResource.TranscriptionStatus status, 
                                      [JsonProperty("transcription_text")]
                                      string transcriptionText, 
                                      [JsonProperty("type")]
                                      string type, 
                                      [JsonProperty("uri")]
                                      string uri)
                                      {
            this.accountSid = accountSid;
            this.apiVersion = apiVersion;
            this.dateCreated = MarshalConverter.DateTimeFromString(dateCreated);
            this.dateUpdated = MarshalConverter.DateTimeFromString(dateUpdated);
            this.duration = duration;
            this.price = price;
            this.priceUnit = priceUnit;
            this.recordingSid = recordingSid;
            this.sid = sid;
            this.status = status;
            this.transcriptionText = transcriptionText;
            this.type = type;
            this.uri = uri;
        }
    }
}
using Newtonsoft.Json;
using System;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Api.V2010.Account.Call 
{

    public class RecordingResource : Resource 
    {
        /// <summary>
        /// fetch
        /// </summary>
        ///
        /// <param name="callSid"> The call_sid </param>
        /// <param name="sid"> The sid </param>
        /// <returns> RecordingFetcher capable of executing the fetch </returns> 
        public static RecordingFetcher Fetcher(string callSid, string sid)
        {
            return new RecordingFetcher(callSid, sid);
        }
    
        /// <summary>
        /// delete
        /// </summary>
        ///
        /// <param name="callSid"> The call_sid </param>
        /// <param name="sid"> The sid </param>
        /// <returns> RecordingDeleter capable of executing the delete </returns> 
        public static RecordingDeleter Deleter(string callSid, string sid)
        {
            return new RecordingDeleter(callSid, sid);
        }
    
        /// <summary>
        /// read
        /// </summary>
        ///
        /// <param name="callSid"> The call_sid </param>
        /// <returns> RecordingReader capable of executing the read </returns> 
        public static RecordingReader Reader(string callSid)
        {
            return new RecordingReader(callSid);
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
        public decimal? Price { get; set; }
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
                                  decimal? price, 
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
            Uri = uri;
        }
    }
}
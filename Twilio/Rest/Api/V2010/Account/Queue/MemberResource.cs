using Newtonsoft.Json;
using System;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Api.V2010.Account.Queue 
{

    public class MemberResource : Resource 
    {
        /// <summary>
        /// Fetch a specific members of the queue
        /// </summary>
        ///
        /// <param name="queueSid"> The Queue in which to find the members </param>
        /// <param name="callSid"> The call_sid </param>
        /// <returns> MemberFetcher capable of executing the fetch </returns> 
        public static MemberFetcher Fetcher(string queueSid, string callSid)
        {
            return new MemberFetcher(queueSid, callSid);
        }
    
        /// <summary>
        /// Dequeue a member from a queue and have the member's call begin executing the TwiML document at that URL
        /// </summary>
        ///
        /// <param name="queueSid"> The Queue in which to find the members </param>
        /// <param name="callSid"> The call_sid </param>
        /// <param name="url"> The url </param>
        /// <param name="method"> The method </param>
        /// <returns> MemberUpdater capable of executing the update </returns> 
        public static MemberUpdater Updater(string queueSid, string callSid, Uri url, Twilio.Http.HttpMethod method)
        {
            return new MemberUpdater(queueSid, callSid, url, method);
        }
    
        /// <summary>
        /// Retrieve a list of members in the queue
        /// </summary>
        ///
        /// <param name="queueSid"> The Queue in which to find members </param>
        /// <returns> MemberReader capable of executing the read </returns> 
        public static MemberReader Reader(string queueSid)
        {
            return new MemberReader(queueSid);
        }
    
        /// <summary>
        /// Converts a JSON string into a MemberResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> MemberResource object represented by the provided JSON </returns> 
        public static MemberResource FromJson(string json)
        {
            // Convert all checked exceptions to Runtime
            try
            {
                return JsonConvert.DeserializeObject<MemberResource>(json);
            }
            catch (JsonException e)
            {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("call_sid")]
        public string callSid { get; set; }
        [JsonProperty("date_enqueued")]
        public DateTime? dateEnqueued { get; set; }
        [JsonProperty("position")]
        public int? position { get; set; }
        [JsonProperty("uri")]
        public string uri { get; set; }
        [JsonProperty("wait_time")]
        public int? waitTime { get; set; }
    
        public MemberResource()
        {
        
        }
    
        private MemberResource([JsonProperty("call_sid")]
                               string callSid, 
                               [JsonProperty("date_enqueued")]
                               string dateEnqueued, 
                               [JsonProperty("position")]
                               int? position, 
                               [JsonProperty("uri")]
                               string uri, 
                               [JsonProperty("wait_time")]
                               int? waitTime)
                               {
            this.callSid = callSid;
            this.dateEnqueued = MarshalConverter.DateTimeFromString(dateEnqueued);
            this.position = position;
            this.uri = uri;
            this.waitTime = waitTime;
        }
    }
}
using Newtonsoft.Json;
using System;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Api.V2010.Account.Queue {

    public class MemberResource : SidResource {
        /// <summary>
        /// Fetch a specific members of the queue
        /// </summary>
        ///
        /// <param name="accountSid"> The account_sid </param>
        /// <param name="queueSid"> The Queue in which to find the members </param>
        /// <param name="callSid"> The call_sid </param>
        /// <returns> MemberFetcher capable of executing the fetch </returns> 
        public static MemberFetcher Fetcher(string accountSid, string queueSid, string callSid) {
            return new MemberFetcher(accountSid, queueSid, callSid);
        }
    
        /// <summary>
        /// Create a MemberFetcher to execute fetch.
        /// </summary>
        ///
        /// <param name="queueSid"> The Queue in which to find the members </param>
        /// <param name="callSid"> The call_sid </param>
        /// <returns> MemberFetcher capable of executing the fetch </returns> 
        public static MemberFetcher Fetcher(string queueSid, 
                                            string callSid) {
            return new MemberFetcher(queueSid, callSid);
        }
    
        /// <summary>
        /// Dequeue a member from a queue and have the member's call begin executing the TwiML document at that URL
        /// </summary>
        ///
        /// <param name="accountSid"> The account_sid </param>
        /// <param name="queueSid"> The Queue in which to find the members </param>
        /// <param name="callSid"> The call_sid </param>
        /// <param name="url"> The url </param>
        /// <param name="method"> The method </param>
        /// <returns> MemberUpdater capable of executing the update </returns> 
        public static MemberUpdater Updater(string accountSid, string queueSid, string callSid, Uri url, Twilio.Http.HttpMethod method) {
            return new MemberUpdater(accountSid, queueSid, callSid, url, method);
        }
    
        /// <summary>
        /// Create a MemberUpdater to execute update.
        /// </summary>
        ///
        /// <param name="queueSid"> The Queue in which to find the members </param>
        /// <param name="callSid"> The call_sid </param>
        /// <param name="url"> The url </param>
        /// <param name="method"> The method </param>
        /// <returns> MemberUpdater capable of executing the update </returns> 
        public static MemberUpdater Updater(string queueSid, 
                                            string callSid, 
                                            Uri url, 
                                            Twilio.Http.HttpMethod method) {
            return new MemberUpdater(queueSid, callSid, url, method);
        }
    
        /// <summary>
        /// Retrieve a list of members in the queue
        /// </summary>
        ///
        /// <param name="accountSid"> The account_sid </param>
        /// <param name="queueSid"> The Queue in which to find members </param>
        /// <returns> MemberReader capable of executing the read </returns> 
        public static MemberReader Reader(string accountSid, string queueSid) {
            return new MemberReader(accountSid, queueSid);
        }
    
        /// <summary>
        /// Create a MemberReader to execute read.
        /// </summary>
        ///
        /// <param name="queueSid"> The Queue in which to find members </param>
        /// <returns> MemberReader capable of executing the read </returns> 
        public static MemberReader Reader(string queueSid) {
            return new MemberReader(queueSid);
        }
    
        /// <summary>
        /// Converts a JSON string into a MemberResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> MemberResource object represented by the provided JSON </returns> 
        public static MemberResource FromJson(string json) {
            // Convert all checked exceptions to Runtime
            try {
                return JsonConvert.DeserializeObject<MemberResource>(json);
            } catch (JsonException e) {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("call_sid")]
        private readonly string callSid;
        [JsonProperty("date_enqueued")]
        private readonly DateTime? dateEnqueued;
        [JsonProperty("position")]
        private readonly int? position;
        [JsonProperty("uri")]
        private readonly string uri;
        [JsonProperty("wait_time")]
        private readonly int? waitTime;
    
        public MemberResource() {
        
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
                               int? waitTime) {
            this.callSid = callSid;
            this.dateEnqueued = MarshalConverter.DateTimeFromString(dateEnqueued);
            this.position = position;
            this.uri = uri;
            this.waitTime = waitTime;
        }
    
        /// <returns> Unique string that identifies this resource </returns> 
        public override string GetSid() {
            return this.GetCallSid();
        }
    
        /// <returns> Unique string that identifies this resource </returns> 
        public string GetCallSid() {
            return this.callSid;
        }
    
        /// <returns> The date the member was enqueued </returns> 
        public DateTime? GetDateEnqueued() {
            return this.dateEnqueued;
        }
    
        /// <returns> This member's current position in the queue. </returns> 
        public int? GetPosition() {
            return this.position;
        }
    
        /// <returns> The uri </returns> 
        public string GetUri() {
            return this.uri;
        }
    
        /// <returns> The number of seconds the member has been in the queue. </returns> 
        public int? GetWaitTime() {
            return this.waitTime;
        }
    }
}
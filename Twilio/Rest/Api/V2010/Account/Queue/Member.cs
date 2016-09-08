using Newtonsoft.Json;
using System;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Fetchers.Api.V2010.Account.Queue;
using Twilio.Http;
using Twilio.Readers.Api.V2010.Account.Queue;
using Twilio.Updaters.Api.V2010.Account.Queue;

namespace Twilio.Rest.Api.V2010.Account.Queue {

    public class Member : SidResource {
        /**
         * Fetch a specific members of the queue
         * 
         * @param accountSid The account_sid
         * @param queueSid The Queue in which to find the members
         * @param callSid The call_sid
         * @return MemberFetcher capable of executing the fetch
         */
        public static MemberFetcher Fetch(string accountSid, string queueSid, string callSid) {
            return new MemberFetcher(accountSid, queueSid, callSid);
        }
    
        /**
         * Create a MemberFetcher to execute fetch.
         * 
         * @param queueSid The Queue in which to find the members
         * @param callSid The call_sid
         * @return MemberFetcher capable of executing the fetch
         */
        public static MemberFetcher Fetch(string queueSid, 
                                          string callSid) {
            return new MemberFetcher(queueSid, callSid);
        }
    
        /**
         * Dequeue a member from a queue and have the member's call begin executing the
         * TwiML document at that URL
         * 
         * @param accountSid The account_sid
         * @param queueSid The Queue in which to find the members
         * @param callSid The call_sid
         * @param url The url
         * @param method The method
         * @return MemberUpdater capable of executing the update
         */
        public static MemberUpdater Update(string accountSid, string queueSid, string callSid, Uri url, Twilio.Http.HttpMethod method) {
            return new MemberUpdater(accountSid, queueSid, callSid, url, method);
        }
    
        /**
         * Create a MemberUpdater to execute update.
         * 
         * @param queueSid The Queue in which to find the members
         * @param callSid The call_sid
         * @param url The url
         * @param method The method
         * @return MemberUpdater capable of executing the update
         */
        public static MemberUpdater Update(string queueSid, 
                                           string callSid, 
                                           Uri url, 
                                           Twilio.Http.HttpMethod method) {
            return new MemberUpdater(queueSid, callSid, url, method);
        }
    
        /**
         * Retrieve a list of members in the queue
         * 
         * @param accountSid The account_sid
         * @param queueSid The Queue in which to find members
         * @return MemberReader capable of executing the read
         */
        public static MemberReader Read(string accountSid, string queueSid) {
            return new MemberReader(accountSid, queueSid);
        }
    
        /**
         * Create a MemberReader to execute read.
         * 
         * @param queueSid The Queue in which to find members
         * @return MemberReader capable of executing the read
         */
        public static MemberReader Read(string queueSid) {
            return new MemberReader(queueSid);
        }
    
        /**
         * Converts a JSON string into a Member object
         * 
         * @param json Raw JSON string
         * @return Member object represented by the provided JSON
         */
        public static Member FromJson(string json) {
            // Convert all checked exceptions to Runtime
            try {
                return JsonConvert.DeserializeObject<Member>(json);
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
    
        public Member() {
        
        }
    
        private Member([JsonProperty("call_sid")]
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
    
        /**
         * @return Unique string that identifies this resource
         */
        public override string GetSid() {
            return this.GetCallSid();
        }
    
        /**
         * @return Unique string that identifies this resource
         */
        public string GetCallSid() {
            return this.callSid;
        }
    
        /**
         * @return The date the member was enqueued
         */
        public DateTime? GetDateEnqueued() {
            return this.dateEnqueued;
        }
    
        /**
         * @return This member's current position in the queue.
         */
        public int? GetPosition() {
            return this.position;
        }
    
        /**
         * @return The uri
         */
        public string GetUri() {
            return this.uri;
        }
    
        /**
         * @return The number of seconds the member has been in the queue.
         */
        public int? GetWaitTime() {
            return this.waitTime;
        }
    }
}
using Newtonsoft.Json;
using System;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Api.V2010.Account {

    public class QueueResource : SidResource {
        /// <summary>
        /// Fetch an instance of a queue identified by the QueueSid
        /// </summary>
        ///
        /// <param name="accountSid"> The account_sid </param>
        /// <param name="sid"> Fetch by unique queue Sid </param>
        /// <returns> QueueFetcher capable of executing the fetch </returns> 
        public static QueueFetcher Fetcher(string accountSid, string sid) {
            return new QueueFetcher(accountSid, sid);
        }
    
        /// <summary>
        /// Create a QueueFetcher to execute fetch.
        /// </summary>
        ///
        /// <param name="sid"> Fetch by unique queue Sid </param>
        /// <returns> QueueFetcher capable of executing the fetch </returns> 
        public static QueueFetcher Fetcher(string sid) {
            return new QueueFetcher(sid);
        }
    
        /// <summary>
        /// Update the queue with the new parameters
        /// </summary>
        ///
        /// <param name="accountSid"> The account_sid </param>
        /// <param name="sid"> The sid </param>
        /// <returns> QueueUpdater capable of executing the update </returns> 
        public static QueueUpdater Updater(string accountSid, string sid) {
            return new QueueUpdater(accountSid, sid);
        }
    
        /// <summary>
        /// Create a QueueUpdater to execute update.
        /// </summary>
        ///
        /// <param name="sid"> The sid </param>
        /// <returns> QueueUpdater capable of executing the update </returns> 
        public static QueueUpdater Updater(string sid) {
            return new QueueUpdater(sid);
        }
    
        /// <summary>
        /// Remove an empty queue
        /// </summary>
        ///
        /// <param name="accountSid"> The account_sid </param>
        /// <param name="sid"> Delete by unique queue Sid </param>
        /// <returns> QueueDeleter capable of executing the delete </returns> 
        public static QueueDeleter Deleter(string accountSid, string sid) {
            return new QueueDeleter(accountSid, sid);
        }
    
        /// <summary>
        /// Create a QueueDeleter to execute delete.
        /// </summary>
        ///
        /// <param name="sid"> Delete by unique queue Sid </param>
        /// <returns> QueueDeleter capable of executing the delete </returns> 
        public static QueueDeleter Deleter(string sid) {
            return new QueueDeleter(sid);
        }
    
        /// <summary>
        /// Retrieve a list of queues belonging to the account used to make the request
        /// </summary>
        ///
        /// <param name="accountSid"> The account_sid </param>
        /// <returns> QueueReader capable of executing the read </returns> 
        public static QueueReader Reader(string accountSid) {
            return new QueueReader(accountSid);
        }
    
        /// <summary>
        /// Create a QueueReader to execute read.
        /// </summary>
        ///
        /// <returns> QueueReader capable of executing the read </returns> 
        public static QueueReader Reader() {
            return new QueueReader();
        }
    
        /// <summary>
        /// Create a queue
        /// </summary>
        ///
        /// <param name="accountSid"> The account_sid </param>
        /// <returns> QueueCreator capable of executing the create </returns> 
        public static QueueCreator Creator(string accountSid) {
            return new QueueCreator(accountSid);
        }
    
        /// <summary>
        /// Create a QueueCreator to execute create.
        /// </summary>
        ///
        /// <returns> QueueCreator capable of executing the create </returns> 
        public static QueueCreator Creator() {
            return new QueueCreator();
        }
    
        /// <summary>
        /// Converts a JSON string into a QueueResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> QueueResource object represented by the provided JSON </returns> 
        public static QueueResource FromJson(string json) {
            // Convert all checked exceptions to Runtime
            try {
                return JsonConvert.DeserializeObject<QueueResource>(json);
            } catch (JsonException e) {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("account_sid")]
        private readonly string accountSid;
        [JsonProperty("average_wait_time")]
        private readonly int? averageWaitTime;
        [JsonProperty("current_size")]
        private readonly int? currentSize;
        [JsonProperty("date_created")]
        private readonly DateTime? dateCreated;
        [JsonProperty("date_updated")]
        private readonly DateTime? dateUpdated;
        [JsonProperty("friendly_name")]
        private readonly string friendlyName;
        [JsonProperty("max_size")]
        private readonly int? maxSize;
        [JsonProperty("sid")]
        private readonly string sid;
        [JsonProperty("uri")]
        private readonly string uri;
    
        public QueueResource() {
        
        }
    
        private QueueResource([JsonProperty("account_sid")]
                              string accountSid, 
                              [JsonProperty("average_wait_time")]
                              int? averageWaitTime, 
                              [JsonProperty("current_size")]
                              int? currentSize, 
                              [JsonProperty("date_created")]
                              string dateCreated, 
                              [JsonProperty("date_updated")]
                              string dateUpdated, 
                              [JsonProperty("friendly_name")]
                              string friendlyName, 
                              [JsonProperty("max_size")]
                              int? maxSize, 
                              [JsonProperty("sid")]
                              string sid, 
                              [JsonProperty("uri")]
                              string uri) {
            this.accountSid = accountSid;
            this.averageWaitTime = averageWaitTime;
            this.currentSize = currentSize;
            this.dateCreated = MarshalConverter.DateTimeFromString(dateCreated);
            this.dateUpdated = MarshalConverter.DateTimeFromString(dateUpdated);
            this.friendlyName = friendlyName;
            this.maxSize = maxSize;
            this.sid = sid;
            this.uri = uri;
        }
    
        /// <returns> The account_sid </returns> 
        public string GetAccountSid() {
            return this.accountSid;
        }
    
        /// <returns> Average wait time of members in the queue </returns> 
        public int? GetAverageWaitTime() {
            return this.averageWaitTime;
        }
    
        /// <returns> The count of calls currently in the queue. </returns> 
        public int? GetCurrentSize() {
            return this.currentSize;
        }
    
        /// <returns> The date_created </returns> 
        public DateTime? GetDateCreated() {
            return this.dateCreated;
        }
    
        /// <returns> The date_updated </returns> 
        public DateTime? GetDateUpdated() {
            return this.dateUpdated;
        }
    
        /// <returns> A user-provided string that identifies this queue. </returns> 
        public string GetFriendlyName() {
            return this.friendlyName;
        }
    
        /// <returns> The max number of calls allowed in the queue </returns> 
        public int? GetMaxSize() {
            return this.maxSize;
        }
    
        /// <returns> A string that uniquely identifies this queue </returns> 
        public override string GetSid() {
            return this.sid;
        }
    
        /// <returns> The uri </returns> 
        public string GetUri() {
            return this.uri;
        }
    }
}
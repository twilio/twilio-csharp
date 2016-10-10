using Newtonsoft.Json;
using System;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Api.V2010.Account {

    public class QueueResource : SidResource {
        /**
         * Fetch an instance of a queue identified by the QueueSid
         * 
         * @param accountSid The account_sid
         * @param sid Fetch by unique queue Sid
         * @return QueueFetcher capable of executing the fetch
         */
        public static QueueFetcher Fetcher(string accountSid, string sid) {
            return new QueueFetcher(accountSid, sid);
        }
    
        /**
         * Create a QueueFetcher to execute fetch.
         * 
         * @param sid Fetch by unique queue Sid
         * @return QueueFetcher capable of executing the fetch
         */
        public static QueueFetcher Fetcher(string sid) {
            return new QueueFetcher(sid);
        }
    
        /**
         * Update the queue with the new parameters
         * 
         * @param accountSid The account_sid
         * @param sid The sid
         * @return QueueUpdater capable of executing the update
         */
        public static QueueUpdater Updater(string accountSid, string sid) {
            return new QueueUpdater(accountSid, sid);
        }
    
        /**
         * Create a QueueUpdater to execute update.
         * 
         * @param sid The sid
         * @return QueueUpdater capable of executing the update
         */
        public static QueueUpdater Updater(string sid) {
            return new QueueUpdater(sid);
        }
    
        /**
         * Remove an empty queue
         * 
         * @param accountSid The account_sid
         * @param sid Delete by unique queue Sid
         * @return QueueDeleter capable of executing the delete
         */
        public static QueueDeleter Deleter(string accountSid, string sid) {
            return new QueueDeleter(accountSid, sid);
        }
    
        /**
         * Create a QueueDeleter to execute delete.
         * 
         * @param sid Delete by unique queue Sid
         * @return QueueDeleter capable of executing the delete
         */
        public static QueueDeleter Deleter(string sid) {
            return new QueueDeleter(sid);
        }
    
        /**
         * Retrieve a list of queues belonging to the account used to make the request
         * 
         * @param accountSid The account_sid
         * @return QueueReader capable of executing the read
         */
        public static QueueReader Reader(string accountSid) {
            return new QueueReader(accountSid);
        }
    
        /**
         * Create a QueueReader to execute read.
         * 
         * @return QueueReader capable of executing the read
         */
        public static QueueReader Reader() {
            return new QueueReader();
        }
    
        /**
         * Create a queue
         * 
         * @param accountSid The account_sid
         * @return QueueCreator capable of executing the create
         */
        public static QueueCreator Creator(string accountSid) {
            return new QueueCreator(accountSid);
        }
    
        /**
         * Create a QueueCreator to execute create.
         * 
         * @return QueueCreator capable of executing the create
         */
        public static QueueCreator Creator() {
            return new QueueCreator();
        }
    
        /**
         * Converts a JSON string into a QueueResource object
         * 
         * @param json Raw JSON string
         * @return QueueResource object represented by the provided JSON
         */
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
    
        /**
         * @return The account_sid
         */
        public string GetAccountSid() {
            return this.accountSid;
        }
    
        /**
         * @return Average wait time of members in the queue
         */
        public int? GetAverageWaitTime() {
            return this.averageWaitTime;
        }
    
        /**
         * @return The count of calls currently in the queue.
         */
        public int? GetCurrentSize() {
            return this.currentSize;
        }
    
        /**
         * @return The date_created
         */
        public DateTime? GetDateCreated() {
            return this.dateCreated;
        }
    
        /**
         * @return The date_updated
         */
        public DateTime? GetDateUpdated() {
            return this.dateUpdated;
        }
    
        /**
         * @return A user-provided string that identifies this queue.
         */
        public string GetFriendlyName() {
            return this.friendlyName;
        }
    
        /**
         * @return The max number of calls allowed in the queue
         */
        public int? GetMaxSize() {
            return this.maxSize;
        }
    
        /**
         * @return A string that uniquely identifies this queue
         */
        public override string GetSid() {
            return this.sid;
        }
    
        /**
         * @return The uri
         */
        public string GetUri() {
            return this.uri;
        }
    }
}
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Creators.Api.V2010.Account;
using Twilio.Deleters.Api.V2010.Account;
using Twilio.Exceptions;
using Twilio.Fetchers.Api.V2010.Account;
using Twilio.Http;
using Twilio.Readers.Api.V2010.Account;
using Twilio.Resources;
using Twilio.Updaters.Api.V2010.Account;

namespace Twilio.Resources.Api.V2010.Account {

    public class QueueResource : SidResource {
        /**
         * Fetch an instance of a queue identified by the QueueSid
         * 
         * @param accountSid The account_sid
         * @param sid Fetch by unique queue Sid
         * @return QueueFetcher capable of executing the fetch
         */
        public static QueueFetcher Fetch(string accountSid, string sid) {
            return new QueueFetcher(accountSid, sid);
        }
    
        /**
         * Update the queue with the new parameters
         * 
         * @param accountSid The account_sid
         * @param sid The sid
         * @return QueueUpdater capable of executing the update
         */
        public static QueueUpdater Update(string accountSid, string sid) {
            return new QueueUpdater(accountSid, sid);
        }
    
        /**
         * Remove an empty queue
         * 
         * @param accountSid The account_sid
         * @param sid Delete by unique queue Sid
         * @return QueueDeleter capable of executing the delete
         */
        public static QueueDeleter Delete(string accountSid, string sid) {
            return new QueueDeleter(accountSid, sid);
        }
    
        /**
         * Retrieve a list of queues belonging to the account used to make the request
         * 
         * @param accountSid The account_sid
         * @return QueueReader capable of executing the read
         */
        public static QueueReader Read(string accountSid) {
            return new QueueReader(accountSid);
        }
    
        /**
         * Create a queue
         * 
         * @param accountSid The account_sid
         * @return QueueCreator capable of executing the create
         */
        public static QueueCreator Create(string accountSid) {
            return new QueueCreator(accountSid);
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
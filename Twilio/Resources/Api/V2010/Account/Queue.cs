using Newtonsoft.Json;
using System;
using Twilio.Clients.TwilioRestClient;
using Twilio.Creators.Api.V2010.Account;
using Twilio.Deleters.Api.V2010.Account;
using Twilio.Exceptions;
using Twilio.Fetchers.Api.V2010.Account;
using Twilio.Http;
using Twilio.Readers.Api.V2010.Account;
using Twilio.Resources;
using Twilio.Updaters.Api.V2010.Account;
using com.twilio.sdk.converters.MarshalConverter;
using org.joda.time.DateTime;

namespace Twilio.Resources.Api.V2010.Account {

    public class Queue : SidResource {
        /**
         * Fetch an instance of a queue identified by the QueueSid
         * 
         * @param accountSid The account_sid
         * @param sid Fetch by unique queue Sid
         * @return QueueFetcher capable of executing the fetch
         */
        public static QueueFetcher fetch(String accountSid, String sid) {
            return new QueueFetcher(accountSid, sid);
        }
    
        /**
         * Update the queue with the new parameters
         * 
         * @param accountSid The account_sid
         * @param sid The sid
         * @return QueueUpdater capable of executing the update
         */
        public static QueueUpdater update(String accountSid, String sid) {
            return new QueueUpdater(accountSid, sid);
        }
    
        /**
         * Remove an empty queue
         * 
         * @param accountSid The account_sid
         * @param sid Delete by unique queue Sid
         * @return QueueDeleter capable of executing the delete
         */
        public static QueueDeleter delete(String accountSid, String sid) {
            return new QueueDeleter(accountSid, sid);
        }
    
        /**
         * Retrieve a list of queues belonging to the account used to make the request
         * 
         * @param accountSid The account_sid
         * @return QueueReader capable of executing the read
         */
        public static QueueReader read(String accountSid) {
            return new QueueReader(accountSid);
        }
    
        /**
         * Create a queue
         * 
         * @param accountSid The account_sid
         * @return QueueCreator capable of executing the create
         */
        public static QueueCreator create(String accountSid) {
            return new QueueCreator(accountSid);
        }
    
        /**
         * Converts a JSON string into a Queue object
         * 
         * @param json Raw JSON string
         * @return Queue object represented by the provided JSON
         */
        public static Queue fromJson(string json) {
            // Convert all checked exceptions to Runtime
            try {
                return JsonConvert.DeserializeObject<Queue>(json);
            } catch (JsonException e) {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("account_sid")]
        private readonly String accountSid;
        [JsonProperty("average_wait_time")]
        private readonly Integer averageWaitTime;
        [JsonProperty("current_size")]
        private readonly Integer currentSize;
        [JsonProperty("date_created")]
        private readonly DateTime dateCreated;
        [JsonProperty("date_updated")]
        private readonly DateTime dateUpdated;
        [JsonProperty("friendly_name")]
        private readonly String friendlyName;
        [JsonProperty("max_size")]
        private readonly Integer maxSize;
        [JsonProperty("sid")]
        private readonly String sid;
        [JsonProperty("uri")]
        private readonly String uri;
    
        private Queue([JsonProperty("account_sid")]
                      String accountSid, 
                      [JsonProperty("average_wait_time")]
                      Integer averageWaitTime, 
                      [JsonProperty("current_size")]
                      Integer currentSize, 
                      [JsonProperty("date_created")]
                      String dateCreated, 
                      [JsonProperty("date_updated")]
                      String dateUpdated, 
                      [JsonProperty("friendly_name")]
                      String friendlyName, 
                      [JsonProperty("max_size")]
                      Integer maxSize, 
                      [JsonProperty("sid")]
                      String sid, 
                      [JsonProperty("uri")]
                      String uri) {
            this.accountSid = accountSid;
            this.averageWaitTime = averageWaitTime;
            this.currentSize = currentSize;
            this.dateCreated = MarshalConverter.dateTimeFromString(dateCreated);
            this.dateUpdated = MarshalConverter.dateTimeFromString(dateUpdated);
            this.friendlyName = friendlyName;
            this.maxSize = maxSize;
            this.sid = sid;
            this.uri = uri;
        }
    
        /**
         * @return The account_sid
         */
        public String GetAccountSid() {
            return this.accountSid;
        }
    
        /**
         * @return Average wait time of members in the queue
         */
        public Integer GetAverageWaitTime() {
            return this.averageWaitTime;
        }
    
        /**
         * @return The count of calls currently in the queue.
         */
        public Integer GetCurrentSize() {
            return this.currentSize;
        }
    
        /**
         * @return The date_created
         */
        public DateTime GetDateCreated() {
            return this.dateCreated;
        }
    
        /**
         * @return The date_updated
         */
        public DateTime GetDateUpdated() {
            return this.dateUpdated;
        }
    
        /**
         * @return A user-provided string that identifies this queue.
         */
        public String GetFriendlyName() {
            return this.friendlyName;
        }
    
        /**
         * @return The max number of calls allowed in the queue
         */
        public Integer GetMaxSize() {
            return this.maxSize;
        }
    
        /**
         * @return A string that uniquely identifies this queue
         */
        public String GetSid() {
            return this.sid;
        }
    
        /**
         * @return The uri
         */
        public String GetUri() {
            return this.uri;
        }
    }
}
using Newtonsoft.Json;
using System;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Api.V2010.Account {

    public class NotificationResource : SidResource {
        /**
         * Fetch a notification belonging to the account used to make the request
         * 
         * @param accountSid The account_sid
         * @param sid Fetch by unique notification Sid
         * @return NotificationFetcher capable of executing the fetch
         */
        public static NotificationFetcher Fetcher(string accountSid, string sid) {
            return new NotificationFetcher(accountSid, sid);
        }
    
        /**
         * Create a NotificationFetcher to execute fetch.
         * 
         * @param sid Fetch by unique notification Sid
         * @return NotificationFetcher capable of executing the fetch
         */
        public static NotificationFetcher Fetcher(string sid) {
            return new NotificationFetcher(sid);
        }
    
        /**
         * Delete a notification identified by the NotificationSid from an accounts log
         * 
         * @param accountSid The account_sid
         * @param sid Delete by unique notification Sid
         * @return NotificationDeleter capable of executing the delete
         */
        public static NotificationDeleter Deleter(string accountSid, string sid) {
            return new NotificationDeleter(accountSid, sid);
        }
    
        /**
         * Create a NotificationDeleter to execute delete.
         * 
         * @param sid Delete by unique notification Sid
         * @return NotificationDeleter capable of executing the delete
         */
        public static NotificationDeleter Deleter(string sid) {
            return new NotificationDeleter(sid);
        }
    
        /**
         * Retrieve a list of notifications belonging to the account used to make the
         * request
         * 
         * @param accountSid The account_sid
         * @return NotificationReader capable of executing the read
         */
        public static NotificationReader Reader(string accountSid) {
            return new NotificationReader(accountSid);
        }
    
        /**
         * Create a NotificationReader to execute read.
         * 
         * @return NotificationReader capable of executing the read
         */
        public static NotificationReader Reader() {
            return new NotificationReader();
        }
    
        /**
         * Converts a JSON string into a NotificationResource object
         * 
         * @param json Raw JSON string
         * @return NotificationResource object represented by the provided JSON
         */
        public static NotificationResource FromJson(string json) {
            // Convert all checked exceptions to Runtime
            try {
                return JsonConvert.DeserializeObject<NotificationResource>(json);
            } catch (JsonException e) {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("account_sid")]
        private readonly string accountSid;
        [JsonProperty("api_version")]
        private readonly string apiVersion;
        [JsonProperty("call_sid")]
        private readonly string callSid;
        [JsonProperty("date_created")]
        private readonly DateTime? dateCreated;
        [JsonProperty("date_updated")]
        private readonly DateTime? dateUpdated;
        [JsonProperty("error_code")]
        private readonly string errorCode;
        [JsonProperty("log")]
        private readonly string log;
        [JsonProperty("message_date")]
        private readonly DateTime? messageDate;
        [JsonProperty("message_text")]
        private readonly string messageText;
        [JsonProperty("more_info")]
        private readonly Uri moreInfo;
        [JsonProperty("request_method")]
        [JsonConverter(typeof(HttpMethodConverter))]
        private readonly Twilio.Http.HttpMethod requestMethod;
        [JsonProperty("request_url")]
        private readonly Uri requestUrl;
        [JsonProperty("request_variables")]
        private readonly string requestVariables;
        [JsonProperty("response_body")]
        private readonly string responseBody;
        [JsonProperty("response_headers")]
        private readonly string responseHeaders;
        [JsonProperty("sid")]
        private readonly string sid;
        [JsonProperty("uri")]
        private readonly string uri;
    
        public NotificationResource() {
        
        }
    
        private NotificationResource([JsonProperty("account_sid")]
                                     string accountSid, 
                                     [JsonProperty("api_version")]
                                     string apiVersion, 
                                     [JsonProperty("call_sid")]
                                     string callSid, 
                                     [JsonProperty("date_created")]
                                     string dateCreated, 
                                     [JsonProperty("date_updated")]
                                     string dateUpdated, 
                                     [JsonProperty("error_code")]
                                     string errorCode, 
                                     [JsonProperty("log")]
                                     string log, 
                                     [JsonProperty("message_date")]
                                     string messageDate, 
                                     [JsonProperty("message_text")]
                                     string messageText, 
                                     [JsonProperty("more_info")]
                                     Uri moreInfo, 
                                     [JsonProperty("request_method")]
                                     Twilio.Http.HttpMethod requestMethod, 
                                     [JsonProperty("request_url")]
                                     Uri requestUrl, 
                                     [JsonProperty("request_variables")]
                                     string requestVariables, 
                                     [JsonProperty("response_body")]
                                     string responseBody, 
                                     [JsonProperty("response_headers")]
                                     string responseHeaders, 
                                     [JsonProperty("sid")]
                                     string sid, 
                                     [JsonProperty("uri")]
                                     string uri) {
            this.accountSid = accountSid;
            this.apiVersion = apiVersion;
            this.callSid = callSid;
            this.dateCreated = MarshalConverter.DateTimeFromString(dateCreated);
            this.dateUpdated = MarshalConverter.DateTimeFromString(dateUpdated);
            this.errorCode = errorCode;
            this.log = log;
            this.messageDate = MarshalConverter.DateTimeFromString(messageDate);
            this.messageText = messageText;
            this.moreInfo = moreInfo;
            this.requestMethod = requestMethod;
            this.requestUrl = requestUrl;
            this.requestVariables = requestVariables;
            this.responseBody = responseBody;
            this.responseHeaders = responseHeaders;
            this.sid = sid;
            this.uri = uri;
        }
    
        /**
         * @return The unique sid that identifies this account
         */
        public string GetAccountSid() {
            return this.accountSid;
        }
    
        /**
         * @return The version of the Twilio API in use
         */
        public string GetApiVersion() {
            return this.apiVersion;
        }
    
        /**
         * @return The string that uniquely identifies the call
         */
        public string GetCallSid() {
            return this.callSid;
        }
    
        /**
         * @return The date this resource was created
         */
        public DateTime? GetDateCreated() {
            return this.dateCreated;
        }
    
        /**
         * @return The date this resource was last updated
         */
        public DateTime? GetDateUpdated() {
            return this.dateUpdated;
        }
    
        /**
         * @return A unique error code corresponding to the notification
         */
        public string GetErrorCode() {
            return this.errorCode;
        }
    
        /**
         * @return An integer log level
         */
        public string GetLog() {
            return this.log;
        }
    
        /**
         * @return The date the notification was generated
         */
        public DateTime? GetMessageDate() {
            return this.messageDate;
        }
    
        /**
         * @return The text of the notification.
         */
        public string GetMessageText() {
            return this.messageText;
        }
    
        /**
         * @return A URL for more information about the error code
         */
        public Uri GetMoreInfo() {
            return this.moreInfo;
        }
    
        /**
         * @return HTTP method used with the request url
         */
        public Twilio.Http.HttpMethod GetRequestMethod() {
            return this.requestMethod;
        }
    
        /**
         * @return URL of the resource that generated the notification
         */
        public Uri GetRequestUrl() {
            return this.requestUrl;
        }
    
        /**
         * @return Twilio-generated HTTP variables sent to the server
         */
        public string GetRequestVariables() {
            return this.requestVariables;
        }
    
        /**
         * @return The HTTP body returned by your server.
         */
        public string GetResponseBody() {
            return this.responseBody;
        }
    
        /**
         * @return The HTTP headers returned by your server.
         */
        public string GetResponseHeaders() {
            return this.responseHeaders;
        }
    
        /**
         * @return A string that uniquely identifies this notification
         */
        public override string GetSid() {
            return this.sid;
        }
    
        /**
         * @return The URI for this resource
         */
        public string GetUri() {
            return this.uri;
        }
    }
}
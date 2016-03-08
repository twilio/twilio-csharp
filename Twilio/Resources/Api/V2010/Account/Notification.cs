using Newtonsoft.Json;
using System;
using Twilio.Clients.TwilioRestClient;
using Twilio.Deleters.Api.V2010.Account;
using Twilio.Exceptions;
using Twilio.Fetchers.Api.V2010.Account;
using Twilio.Http;
using Twilio.Readers.Api.V2010.Account;
using Twilio.Resources;
using com.twilio.sdk.converters.MarshalConverter;
using com.twilio.sdk.http.HttpMethod;
using java.net.URI;
using org.joda.time.DateTime;

namespace Twilio.Resources.Api.V2010.Account {

    public class Notification : SidResource {
        /**
         * Fetch a notification belonging to the account used to make the request
         * 
         * @param accountSid The account_sid
         * @param sid Fetch by unique notification Sid
         * @return NotificationFetcher capable of executing the fetch
         */
        public static NotificationFetcher fetch(String accountSid, String sid) {
            return new NotificationFetcher(accountSid, sid);
        }
    
        /**
         * Delete a notification identified by the NotificationSid from an accounts log
         * 
         * @param accountSid The account_sid
         * @param sid Delete by unique notification Sid
         * @return NotificationDeleter capable of executing the delete
         */
        public static NotificationDeleter delete(String accountSid, String sid) {
            return new NotificationDeleter(accountSid, sid);
        }
    
        /**
         * Retrieve a list of notifications belonging to the account used to make the
         * request
         * 
         * @param accountSid The account_sid
         * @return NotificationReader capable of executing the read
         */
        public static NotificationReader read(String accountSid) {
            return new NotificationReader(accountSid);
        }
    
        /**
         * Converts a JSON string into a Notification object
         * 
         * @param json Raw JSON string
         * @return Notification object represented by the provided JSON
         */
        public static Notification fromJson(string json) {
            // Convert all checked exceptions to Runtime
            try {
                return JsonConvert.DeserializeObject<Notification>(json);
            } catch (JsonException e) {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("account_sid")]
        private readonly String accountSid;
        [JsonProperty("api_version")]
        private readonly String apiVersion;
        [JsonProperty("call_sid")]
        private readonly String callSid;
        [JsonProperty("date_created")]
        private readonly DateTime dateCreated;
        [JsonProperty("date_updated")]
        private readonly DateTime dateUpdated;
        [JsonProperty("error_code")]
        private readonly String errorCode;
        [JsonProperty("log")]
        private readonly String log;
        [JsonProperty("message_date")]
        private readonly DateTime messageDate;
        [JsonProperty("message_text")]
        private readonly String messageText;
        [JsonProperty("more_info")]
        private readonly URI moreInfo;
        [JsonProperty("request_method")]
        private readonly HttpMethod requestMethod;
        [JsonProperty("request_url")]
        private readonly URI requestUrl;
        [JsonProperty("request_variables")]
        private readonly String requestVariables;
        [JsonProperty("response_body")]
        private readonly String responseBody;
        [JsonProperty("response_headers")]
        private readonly String responseHeaders;
        [JsonProperty("sid")]
        private readonly String sid;
        [JsonProperty("uri")]
        private readonly String uri;
    
        private Notification([JsonProperty("account_sid")]
                             String accountSid, 
                             [JsonProperty("api_version")]
                             String apiVersion, 
                             [JsonProperty("call_sid")]
                             String callSid, 
                             [JsonProperty("date_created")]
                             String dateCreated, 
                             [JsonProperty("date_updated")]
                             String dateUpdated, 
                             [JsonProperty("error_code")]
                             String errorCode, 
                             [JsonProperty("log")]
                             String log, 
                             [JsonProperty("message_date")]
                             String messageDate, 
                             [JsonProperty("message_text")]
                             String messageText, 
                             [JsonProperty("more_info")]
                             URI moreInfo, 
                             [JsonProperty("request_method")]
                             HttpMethod requestMethod, 
                             [JsonProperty("request_url")]
                             URI requestUrl, 
                             [JsonProperty("request_variables")]
                             String requestVariables, 
                             [JsonProperty("response_body")]
                             String responseBody, 
                             [JsonProperty("response_headers")]
                             String responseHeaders, 
                             [JsonProperty("sid")]
                             String sid, 
                             [JsonProperty("uri")]
                             String uri) {
            this.accountSid = accountSid;
            this.apiVersion = apiVersion;
            this.callSid = callSid;
            this.dateCreated = MarshalConverter.dateTimeFromString(dateCreated);
            this.dateUpdated = MarshalConverter.dateTimeFromString(dateUpdated);
            this.errorCode = errorCode;
            this.log = log;
            this.messageDate = MarshalConverter.dateTimeFromString(messageDate);
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
        public String GetAccountSid() {
            return this.accountSid;
        }
    
        /**
         * @return The version of the Twilio API in use
         */
        public String GetApiVersion() {
            return this.apiVersion;
        }
    
        /**
         * @return The string that uniquely identifies the call
         */
        public String GetCallSid() {
            return this.callSid;
        }
    
        /**
         * @return The date this resource was created
         */
        public DateTime GetDateCreated() {
            return this.dateCreated;
        }
    
        /**
         * @return The date this resource was last updated
         */
        public DateTime GetDateUpdated() {
            return this.dateUpdated;
        }
    
        /**
         * @return A unique error code corresponding to the notification
         */
        public String GetErrorCode() {
            return this.errorCode;
        }
    
        /**
         * @return An integer log level
         */
        public String GetLog() {
            return this.log;
        }
    
        /**
         * @return The date the notification was generated
         */
        public DateTime GetMessageDate() {
            return this.messageDate;
        }
    
        /**
         * @return The text of the notification.
         */
        public String GetMessageText() {
            return this.messageText;
        }
    
        /**
         * @return A URL for more information about the error code
         */
        public URI GetMoreInfo() {
            return this.moreInfo;
        }
    
        /**
         * @return HTTP method used with the request url
         */
        public HttpMethod GetRequestMethod() {
            return this.requestMethod;
        }
    
        /**
         * @return URL of the resource that generated the notification
         */
        public URI GetRequestUrl() {
            return this.requestUrl;
        }
    
        /**
         * @return Twilio-generated HTTP variables sent to the server
         */
        public String GetRequestVariables() {
            return this.requestVariables;
        }
    
        /**
         * @return The HTTP body returned by your server.
         */
        public String GetResponseBody() {
            return this.responseBody;
        }
    
        /**
         * @return The HTTP headers returned by your server.
         */
        public String GetResponseHeaders() {
            return this.responseHeaders;
        }
    
        /**
         * @return A string that uniquely identifies this notification
         */
        public String GetSid() {
            return this.sid;
        }
    
        /**
         * @return The URI for this resource
         */
        public String GetUri() {
            return this.uri;
        }
    }
}
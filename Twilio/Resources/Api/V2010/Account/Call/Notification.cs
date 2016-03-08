using Newtonsoft.Json;
using System;
using Twilio.Clients.TwilioRestClient;
using Twilio.Deleters.Api.V2010.Account.Call;
using Twilio.Exceptions;
using Twilio.Fetchers.Api.V2010.Account.Call;
using Twilio.Http;
using Twilio.Readers.Api.V2010.Account.Call;
using Twilio.Resources;
using com.twilio.sdk.converters.MarshalConverter;
using com.twilio.sdk.http.HttpMethod;
using java.net.URI;
using org.joda.time.DateTime;

namespace Twilio.Resources.Api.V2010.Account.Call {

    public class Notification : SidResource {
        /**
         * fetch
         * 
         * @param accountSid The account_sid
         * @param callSid The call_sid
         * @param sid The sid
         * @return NotificationFetcher capable of executing the fetch
         */
        public static NotificationFetcher fetch(String accountSid, String callSid, String sid) {
            return new NotificationFetcher(accountSid, callSid, sid);
        }
    
        /**
         * delete
         * 
         * @param accountSid The account_sid
         * @param callSid The call_sid
         * @param sid The sid
         * @return NotificationDeleter capable of executing the delete
         */
        public static NotificationDeleter delete(String accountSid, String callSid, String sid) {
            return new NotificationDeleter(accountSid, callSid, sid);
        }
    
        /**
         * read
         * 
         * @param accountSid The account_sid
         * @param callSid The call_sid
         * @return NotificationReader capable of executing the read
         */
        public static NotificationReader read(String accountSid, String callSid) {
            return new NotificationReader(accountSid, callSid);
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
        [JsonProperty("sid")]
        private readonly String sid;
        [JsonProperty("uri")]
        private readonly String uri;
        [JsonProperty("request_variables")]
        private readonly String requestVariables;
        [JsonProperty("response_body")]
        private readonly String responseBody;
        [JsonProperty("response_headers")]
        private readonly String responseHeaders;
    
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
                             [JsonProperty("sid")]
                             String sid, 
                             [JsonProperty("uri")]
                             String uri, 
                             [JsonProperty("request_variables")]
                             String requestVariables, 
                             [JsonProperty("response_body")]
                             String responseBody, 
                             [JsonProperty("response_headers")]
                             String responseHeaders) {
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
            this.sid = sid;
            this.uri = uri;
            this.requestVariables = requestVariables;
            this.responseBody = responseBody;
            this.responseHeaders = responseHeaders;
        }
    
        /**
         * @return The account_sid
         */
        public String GetAccountSid() {
            return this.accountSid;
        }
    
        /**
         * @return The api_version
         */
        public String GetApiVersion() {
            return this.apiVersion;
        }
    
        /**
         * @return The call_sid
         */
        public String GetCallSid() {
            return this.callSid;
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
         * @return The error_code
         */
        public String GetErrorCode() {
            return this.errorCode;
        }
    
        /**
         * @return The log
         */
        public String GetLog() {
            return this.log;
        }
    
        /**
         * @return The message_date
         */
        public DateTime GetMessageDate() {
            return this.messageDate;
        }
    
        /**
         * @return The message_text
         */
        public String GetMessageText() {
            return this.messageText;
        }
    
        /**
         * @return The more_info
         */
        public URI GetMoreInfo() {
            return this.moreInfo;
        }
    
        /**
         * @return The request_method
         */
        public HttpMethod GetRequestMethod() {
            return this.requestMethod;
        }
    
        /**
         * @return The request_url
         */
        public URI GetRequestUrl() {
            return this.requestUrl;
        }
    
        /**
         * @return The sid
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
    
        /**
         * @return The request_variables
         */
        public String GetRequestVariables() {
            return this.requestVariables;
        }
    
        /**
         * @return The response_body
         */
        public String GetResponseBody() {
            return this.responseBody;
        }
    
        /**
         * @return The response_headers
         */
        public String GetResponseHeaders() {
            return this.responseHeaders;
        }
    }
}
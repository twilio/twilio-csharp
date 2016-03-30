using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Deleters.Api.V2010.Account.Call;
using Twilio.Exceptions;
using Twilio.Fetchers.Api.V2010.Account.Call;
using Twilio.Http;
using Twilio.Readers.Api.V2010.Account.Call;
using Twilio.Resources;

namespace Twilio.Resources.Api.V2010.Account.Call {

    public class NotificationResource : SidResource {
        /**
         * fetch
         * 
         * @param accountSid The account_sid
         * @param callSid The call_sid
         * @param sid The sid
         * @return NotificationFetcher capable of executing the fetch
         */
        public static NotificationFetcher fetch(string accountSid, string callSid, string sid) {
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
        public static NotificationDeleter delete(string accountSid, string callSid, string sid) {
            return new NotificationDeleter(accountSid, callSid, sid);
        }
    
        /**
         * read
         * 
         * @param accountSid The account_sid
         * @param callSid The call_sid
         * @return NotificationReader capable of executing the read
         */
        public static NotificationReader read(string accountSid, string callSid) {
            return new NotificationReader(accountSid, callSid);
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
        private readonly System.Net.Http.HttpMethod requestMethod;
        [JsonProperty("request_url")]
        private readonly Uri requestUrl;
        [JsonProperty("sid")]
        private readonly string sid;
        [JsonProperty("uri")]
        private readonly string uri;
        [JsonProperty("request_variables")]
        private readonly string requestVariables;
        [JsonProperty("response_body")]
        private readonly string responseBody;
        [JsonProperty("response_headers")]
        private readonly string responseHeaders;
    
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
                                     System.Net.Http.HttpMethod requestMethod, 
                                     [JsonProperty("request_url")]
                                     Uri requestUrl, 
                                     [JsonProperty("sid")]
                                     string sid, 
                                     [JsonProperty("uri")]
                                     string uri, 
                                     [JsonProperty("request_variables")]
                                     string requestVariables, 
                                     [JsonProperty("response_body")]
                                     string responseBody, 
                                     [JsonProperty("response_headers")]
                                     string responseHeaders) {
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
            this.sid = sid;
            this.uri = uri;
            this.requestVariables = requestVariables;
            this.responseBody = responseBody;
            this.responseHeaders = responseHeaders;
        }
    
        /**
         * @return The account_sid
         */
        public string GetAccountSid() {
            return this.accountSid;
        }
    
        /**
         * @return The api_version
         */
        public string GetApiVersion() {
            return this.apiVersion;
        }
    
        /**
         * @return The call_sid
         */
        public string GetCallSid() {
            return this.callSid;
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
         * @return The error_code
         */
        public string GetErrorCode() {
            return this.errorCode;
        }
    
        /**
         * @return The log
         */
        public string GetLog() {
            return this.log;
        }
    
        /**
         * @return The message_date
         */
        public DateTime? GetMessageDate() {
            return this.messageDate;
        }
    
        /**
         * @return The message_text
         */
        public string GetMessageText() {
            return this.messageText;
        }
    
        /**
         * @return The more_info
         */
        public Uri GetMoreInfo() {
            return this.moreInfo;
        }
    
        /**
         * @return The request_method
         */
        public System.Net.Http.HttpMethod GetRequestMethod() {
            return this.requestMethod;
        }
    
        /**
         * @return The request_url
         */
        public Uri GetRequestUrl() {
            return this.requestUrl;
        }
    
        /**
         * @return The sid
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
    
        /**
         * @return The request_variables
         */
        public string GetRequestVariables() {
            return this.requestVariables;
        }
    
        /**
         * @return The response_body
         */
        public string GetResponseBody() {
            return this.responseBody;
        }
    
        /**
         * @return The response_headers
         */
        public string GetResponseHeaders() {
            return this.responseHeaders;
        }
    }
}
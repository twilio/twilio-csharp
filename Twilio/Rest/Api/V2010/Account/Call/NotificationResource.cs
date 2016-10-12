using Newtonsoft.Json;
using System;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Api.V2010.Account.Call {

    public class NotificationResource : SidResource {
        /// <summary>
        /// fetch
        /// </summary>
        ///
        /// <param name="accountSid"> The account_sid </param>
        /// <param name="callSid"> The call_sid </param>
        /// <param name="sid"> The sid </param>
        /// <returns> NotificationFetcher capable of executing the fetch </returns> 
        public static NotificationFetcher Fetcher(string accountSid, string callSid, string sid) {
            return new NotificationFetcher(accountSid, callSid, sid);
        }
    
        /// <summary>
        /// Create a NotificationFetcher to execute fetch.
        /// </summary>
        ///
        /// <param name="callSid"> The call_sid </param>
        /// <param name="sid"> The sid </param>
        /// <returns> NotificationFetcher capable of executing the fetch </returns> 
        public static NotificationFetcher Fetcher(string callSid, 
                                                  string sid) {
            return new NotificationFetcher(callSid, sid);
        }
    
        /// <summary>
        /// delete
        /// </summary>
        ///
        /// <param name="accountSid"> The account_sid </param>
        /// <param name="callSid"> The call_sid </param>
        /// <param name="sid"> The sid </param>
        /// <returns> NotificationDeleter capable of executing the delete </returns> 
        public static NotificationDeleter Deleter(string accountSid, string callSid, string sid) {
            return new NotificationDeleter(accountSid, callSid, sid);
        }
    
        /// <summary>
        /// Create a NotificationDeleter to execute delete.
        /// </summary>
        ///
        /// <param name="callSid"> The call_sid </param>
        /// <param name="sid"> The sid </param>
        /// <returns> NotificationDeleter capable of executing the delete </returns> 
        public static NotificationDeleter Deleter(string callSid, 
                                                  string sid) {
            return new NotificationDeleter(callSid, sid);
        }
    
        /// <summary>
        /// read
        /// </summary>
        ///
        /// <param name="accountSid"> The account_sid </param>
        /// <param name="callSid"> The call_sid </param>
        /// <returns> NotificationReader capable of executing the read </returns> 
        public static NotificationReader Reader(string accountSid, string callSid) {
            return new NotificationReader(accountSid, callSid);
        }
    
        /// <summary>
        /// Create a NotificationReader to execute read.
        /// </summary>
        ///
        /// <param name="callSid"> The call_sid </param>
        /// <returns> NotificationReader capable of executing the read </returns> 
        public static NotificationReader Reader(string callSid) {
            return new NotificationReader(callSid);
        }
    
        /// <summary>
        /// Converts a JSON string into a NotificationResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> NotificationResource object represented by the provided JSON </returns> 
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
    
        /// <returns> The account_sid </returns> 
        public string GetAccountSid() {
            return this.accountSid;
        }
    
        /// <returns> The api_version </returns> 
        public string GetApiVersion() {
            return this.apiVersion;
        }
    
        /// <returns> The call_sid </returns> 
        public string GetCallSid() {
            return this.callSid;
        }
    
        /// <returns> The date_created </returns> 
        public DateTime? GetDateCreated() {
            return this.dateCreated;
        }
    
        /// <returns> The date_updated </returns> 
        public DateTime? GetDateUpdated() {
            return this.dateUpdated;
        }
    
        /// <returns> The error_code </returns> 
        public string GetErrorCode() {
            return this.errorCode;
        }
    
        /// <returns> The log </returns> 
        public string GetLog() {
            return this.log;
        }
    
        /// <returns> The message_date </returns> 
        public DateTime? GetMessageDate() {
            return this.messageDate;
        }
    
        /// <returns> The message_text </returns> 
        public string GetMessageText() {
            return this.messageText;
        }
    
        /// <returns> The more_info </returns> 
        public Uri GetMoreInfo() {
            return this.moreInfo;
        }
    
        /// <returns> The request_method </returns> 
        public Twilio.Http.HttpMethod GetRequestMethod() {
            return this.requestMethod;
        }
    
        /// <returns> The request_url </returns> 
        public Uri GetRequestUrl() {
            return this.requestUrl;
        }
    
        /// <returns> The sid </returns> 
        public override string GetSid() {
            return this.sid;
        }
    
        /// <returns> The uri </returns> 
        public string GetUri() {
            return this.uri;
        }
    
        /// <returns> The request_variables </returns> 
        public string GetRequestVariables() {
            return this.requestVariables;
        }
    
        /// <returns> The response_body </returns> 
        public string GetResponseBody() {
            return this.responseBody;
        }
    
        /// <returns> The response_headers </returns> 
        public string GetResponseHeaders() {
            return this.responseHeaders;
        }
    }
}
using Newtonsoft.Json;
using System;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Api.V2010.Account {

    public class NotificationResource : SidResource {
        /// <summary>
        /// Fetch a notification belonging to the account used to make the request
        /// </summary>
        ///
        /// <param name="accountSid"> The account_sid </param>
        /// <param name="sid"> Fetch by unique notification Sid </param>
        /// <returns> NotificationFetcher capable of executing the fetch </returns> 
        public static NotificationFetcher Fetcher(string accountSid, string sid) {
            return new NotificationFetcher(accountSid, sid);
        }
    
        /// <summary>
        /// Create a NotificationFetcher to execute fetch.
        /// </summary>
        ///
        /// <param name="sid"> Fetch by unique notification Sid </param>
        /// <returns> NotificationFetcher capable of executing the fetch </returns> 
        public static NotificationFetcher Fetcher(string sid) {
            return new NotificationFetcher(sid);
        }
    
        /// <summary>
        /// Delete a notification identified by the NotificationSid from an accounts log
        /// </summary>
        ///
        /// <param name="accountSid"> The account_sid </param>
        /// <param name="sid"> Delete by unique notification Sid </param>
        /// <returns> NotificationDeleter capable of executing the delete </returns> 
        public static NotificationDeleter Deleter(string accountSid, string sid) {
            return new NotificationDeleter(accountSid, sid);
        }
    
        /// <summary>
        /// Create a NotificationDeleter to execute delete.
        /// </summary>
        ///
        /// <param name="sid"> Delete by unique notification Sid </param>
        /// <returns> NotificationDeleter capable of executing the delete </returns> 
        public static NotificationDeleter Deleter(string sid) {
            return new NotificationDeleter(sid);
        }
    
        /// <summary>
        /// Retrieve a list of notifications belonging to the account used to make the request
        /// </summary>
        ///
        /// <param name="accountSid"> The account_sid </param>
        /// <returns> NotificationReader capable of executing the read </returns> 
        public static NotificationReader Reader(string accountSid) {
            return new NotificationReader(accountSid);
        }
    
        /// <summary>
        /// Create a NotificationReader to execute read.
        /// </summary>
        ///
        /// <returns> NotificationReader capable of executing the read </returns> 
        public static NotificationReader Reader() {
            return new NotificationReader();
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
    
        /// <returns> The unique sid that identifies this account </returns> 
        public string GetAccountSid() {
            return this.accountSid;
        }
    
        /// <returns> The version of the Twilio API in use </returns> 
        public string GetApiVersion() {
            return this.apiVersion;
        }
    
        /// <returns> The string that uniquely identifies the call </returns> 
        public string GetCallSid() {
            return this.callSid;
        }
    
        /// <returns> The date this resource was created </returns> 
        public DateTime? GetDateCreated() {
            return this.dateCreated;
        }
    
        /// <returns> The date this resource was last updated </returns> 
        public DateTime? GetDateUpdated() {
            return this.dateUpdated;
        }
    
        /// <returns> A unique error code corresponding to the notification </returns> 
        public string GetErrorCode() {
            return this.errorCode;
        }
    
        /// <returns> An integer log level </returns> 
        public string GetLog() {
            return this.log;
        }
    
        /// <returns> The date the notification was generated </returns> 
        public DateTime? GetMessageDate() {
            return this.messageDate;
        }
    
        /// <returns> The text of the notification. </returns> 
        public string GetMessageText() {
            return this.messageText;
        }
    
        /// <returns> A URL for more information about the error code </returns> 
        public Uri GetMoreInfo() {
            return this.moreInfo;
        }
    
        /// <returns> HTTP method used with the request url </returns> 
        public Twilio.Http.HttpMethod GetRequestMethod() {
            return this.requestMethod;
        }
    
        /// <returns> URL of the resource that generated the notification </returns> 
        public Uri GetRequestUrl() {
            return this.requestUrl;
        }
    
        /// <returns> Twilio-generated HTTP variables sent to the server </returns> 
        public string GetRequestVariables() {
            return this.requestVariables;
        }
    
        /// <returns> The HTTP body returned by your server. </returns> 
        public string GetResponseBody() {
            return this.responseBody;
        }
    
        /// <returns> The HTTP headers returned by your server. </returns> 
        public string GetResponseHeaders() {
            return this.responseHeaders;
        }
    
        /// <returns> A string that uniquely identifies this notification </returns> 
        public override string GetSid() {
            return this.sid;
        }
    
        /// <returns> The URI for this resource </returns> 
        public string GetUri() {
            return this.uri;
        }
    }
}
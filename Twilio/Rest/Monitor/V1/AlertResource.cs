using Newtonsoft.Json;
using System;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Monitor.V1 {

    public class AlertResource : SidResource {
        /**
         * fetch
         * 
         * @param sid The sid
         * @return AlertFetcher capable of executing the fetch
         */
        public static AlertFetcher Fetcher(string sid) {
            return new AlertFetcher(sid);
        }
    
        /**
         * delete
         * 
         * @param sid The sid
         * @return AlertDeleter capable of executing the delete
         */
        public static AlertDeleter Deleter(string sid) {
            return new AlertDeleter(sid);
        }
    
        /**
         * read
         * 
         * @return AlertReader capable of executing the read
         */
        public static AlertReader Reader() {
            return new AlertReader();
        }
    
        /**
         * Converts a JSON string into a AlertResource object
         * 
         * @param json Raw JSON string
         * @return AlertResource object represented by the provided JSON
         */
        public static AlertResource FromJson(string json) {
            // Convert all checked exceptions to Runtime
            try {
                return JsonConvert.DeserializeObject<AlertResource>(json);
            } catch (JsonException e) {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("account_sid")]
        private readonly string accountSid;
        [JsonProperty("alert_text")]
        private readonly string alertText;
        [JsonProperty("api_version")]
        private readonly string apiVersion;
        [JsonProperty("date_created")]
        private readonly DateTime? dateCreated;
        [JsonProperty("date_generated")]
        private readonly DateTime? dateGenerated;
        [JsonProperty("date_updated")]
        private readonly DateTime? dateUpdated;
        [JsonProperty("error_code")]
        private readonly string errorCode;
        [JsonProperty("log_level")]
        private readonly string logLevel;
        [JsonProperty("more_info")]
        private readonly string moreInfo;
        [JsonProperty("request_method")]
        [JsonConverter(typeof(HttpMethodConverter))]
        private readonly Twilio.Http.HttpMethod requestMethod;
        [JsonProperty("request_url")]
        private readonly string requestUrl;
        [JsonProperty("request_variables")]
        private readonly string requestVariables;
        [JsonProperty("resource_sid")]
        private readonly string resourceSid;
        [JsonProperty("response_body")]
        private readonly string responseBody;
        [JsonProperty("response_headers")]
        private readonly string responseHeaders;
        [JsonProperty("sid")]
        private readonly string sid;
        [JsonProperty("url")]
        private readonly Uri url;
    
        public AlertResource() {
        
        }
    
        private AlertResource([JsonProperty("account_sid")]
                              string accountSid, 
                              [JsonProperty("alert_text")]
                              string alertText, 
                              [JsonProperty("api_version")]
                              string apiVersion, 
                              [JsonProperty("date_created")]
                              string dateCreated, 
                              [JsonProperty("date_generated")]
                              string dateGenerated, 
                              [JsonProperty("date_updated")]
                              string dateUpdated, 
                              [JsonProperty("error_code")]
                              string errorCode, 
                              [JsonProperty("log_level")]
                              string logLevel, 
                              [JsonProperty("more_info")]
                              string moreInfo, 
                              [JsonProperty("request_method")]
                              Twilio.Http.HttpMethod requestMethod, 
                              [JsonProperty("request_url")]
                              string requestUrl, 
                              [JsonProperty("request_variables")]
                              string requestVariables, 
                              [JsonProperty("resource_sid")]
                              string resourceSid, 
                              [JsonProperty("response_body")]
                              string responseBody, 
                              [JsonProperty("response_headers")]
                              string responseHeaders, 
                              [JsonProperty("sid")]
                              string sid, 
                              [JsonProperty("url")]
                              Uri url) {
            this.accountSid = accountSid;
            this.alertText = alertText;
            this.apiVersion = apiVersion;
            this.dateCreated = MarshalConverter.DateTimeFromString(dateCreated);
            this.dateGenerated = MarshalConverter.DateTimeFromString(dateGenerated);
            this.dateUpdated = MarshalConverter.DateTimeFromString(dateUpdated);
            this.errorCode = errorCode;
            this.logLevel = logLevel;
            this.moreInfo = moreInfo;
            this.requestMethod = requestMethod;
            this.requestUrl = requestUrl;
            this.requestVariables = requestVariables;
            this.resourceSid = resourceSid;
            this.responseBody = responseBody;
            this.responseHeaders = responseHeaders;
            this.sid = sid;
            this.url = url;
        }
    
        /**
         * @return The account_sid
         */
        public string GetAccountSid() {
            return this.accountSid;
        }
    
        /**
         * @return The alert_text
         */
        public string GetAlertText() {
            return this.alertText;
        }
    
        /**
         * @return The api_version
         */
        public string GetApiVersion() {
            return this.apiVersion;
        }
    
        /**
         * @return The date_created
         */
        public DateTime? GetDateCreated() {
            return this.dateCreated;
        }
    
        /**
         * @return The date_generated
         */
        public DateTime? GetDateGenerated() {
            return this.dateGenerated;
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
         * @return The log_level
         */
        public string GetLogLevel() {
            return this.logLevel;
        }
    
        /**
         * @return The more_info
         */
        public string GetMoreInfo() {
            return this.moreInfo;
        }
    
        /**
         * @return The request_method
         */
        public Twilio.Http.HttpMethod GetRequestMethod() {
            return this.requestMethod;
        }
    
        /**
         * @return The request_url
         */
        public string GetRequestUrl() {
            return this.requestUrl;
        }
    
        /**
         * @return The request_variables
         */
        public string GetRequestVariables() {
            return this.requestVariables;
        }
    
        /**
         * @return The resource_sid
         */
        public string GetResourceSid() {
            return this.resourceSid;
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
    
        /**
         * @return The sid
         */
        public override string GetSid() {
            return this.sid;
        }
    
        /**
         * @return The url
         */
        public Uri GetUrl() {
            return this.url;
        }
    }
}
using Newtonsoft.Json;
using System;
using Twilio.Clients.TwilioRestClient;
using Twilio.Deleters.Monitor.V1;
using Twilio.Exceptions;
using Twilio.Fetchers.Monitor.V1;
using Twilio.Http;
using Twilio.Readers.Monitor.V1;
using Twilio.Resources;
using com.twilio.sdk.converters.MarshalConverter;
using com.twilio.sdk.http.HttpMethod;
using java.net.URI;
using org.joda.time.DateTime;

namespace Twilio.Resources.Monitor.V1 {

    public class Alert : SidResource {
        /**
         * fetch
         * 
         * @param sid The sid
         * @return AlertFetcher capable of executing the fetch
         */
        public static AlertFetcher fetch(String sid) {
            return new AlertFetcher(sid);
        }
    
        /**
         * delete
         * 
         * @param sid The sid
         * @return AlertDeleter capable of executing the delete
         */
        public static AlertDeleter delete(String sid) {
            return new AlertDeleter(sid);
        }
    
        /**
         * read
         * 
         * @return AlertReader capable of executing the read
         */
        public static AlertReader read() {
            return new AlertReader();
        }
    
        /**
         * Converts a JSON string into a Alert object
         * 
         * @param json Raw JSON string
         * @return Alert object represented by the provided JSON
         */
        public static Alert fromJson(string json) {
            // Convert all checked exceptions to Runtime
            try {
                return JsonConvert.DeserializeObject<Alert>(json);
            } catch (JsonException e) {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("account_sid")]
        private readonly String accountSid;
        [JsonProperty("alert_text")]
        private readonly String alertText;
        [JsonProperty("api_version")]
        private readonly String apiVersion;
        [JsonProperty("date_created")]
        private readonly DateTime dateCreated;
        [JsonProperty("date_generated")]
        private readonly DateTime dateGenerated;
        [JsonProperty("date_updated")]
        private readonly DateTime dateUpdated;
        [JsonProperty("error_code")]
        private readonly String errorCode;
        [JsonProperty("log_level")]
        private readonly String logLevel;
        [JsonProperty("more_info")]
        private readonly String moreInfo;
        [JsonProperty("request_method")]
        private readonly HttpMethod requestMethod;
        [JsonProperty("request_url")]
        private readonly String requestUrl;
        [JsonProperty("request_variables")]
        private readonly String requestVariables;
        [JsonProperty("resource_sid")]
        private readonly String resourceSid;
        [JsonProperty("response_body")]
        private readonly String responseBody;
        [JsonProperty("response_headers")]
        private readonly String responseHeaders;
        [JsonProperty("sid")]
        private readonly String sid;
        [JsonProperty("url")]
        private readonly URI url;
    
        private Alert([JsonProperty("account_sid")]
                      String accountSid, 
                      [JsonProperty("alert_text")]
                      String alertText, 
                      [JsonProperty("api_version")]
                      String apiVersion, 
                      [JsonProperty("date_created")]
                      String dateCreated, 
                      [JsonProperty("date_generated")]
                      String dateGenerated, 
                      [JsonProperty("date_updated")]
                      String dateUpdated, 
                      [JsonProperty("error_code")]
                      String errorCode, 
                      [JsonProperty("log_level")]
                      String logLevel, 
                      [JsonProperty("more_info")]
                      String moreInfo, 
                      [JsonProperty("request_method")]
                      HttpMethod requestMethod, 
                      [JsonProperty("request_url")]
                      String requestUrl, 
                      [JsonProperty("request_variables")]
                      String requestVariables, 
                      [JsonProperty("resource_sid")]
                      String resourceSid, 
                      [JsonProperty("response_body")]
                      String responseBody, 
                      [JsonProperty("response_headers")]
                      String responseHeaders, 
                      [JsonProperty("sid")]
                      String sid, 
                      [JsonProperty("url")]
                      URI url) {
            this.accountSid = accountSid;
            this.alertText = alertText;
            this.apiVersion = apiVersion;
            this.dateCreated = MarshalConverter.dateTimeFromString(dateCreated);
            this.dateGenerated = MarshalConverter.dateTimeFromString(dateGenerated);
            this.dateUpdated = MarshalConverter.dateTimeFromString(dateUpdated);
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
        public String GetAccountSid() {
            return this.accountSid;
        }
    
        /**
         * @return The alert_text
         */
        public String GetAlertText() {
            return this.alertText;
        }
    
        /**
         * @return The api_version
         */
        public String GetApiVersion() {
            return this.apiVersion;
        }
    
        /**
         * @return The date_created
         */
        public DateTime GetDateCreated() {
            return this.dateCreated;
        }
    
        /**
         * @return The date_generated
         */
        public DateTime GetDateGenerated() {
            return this.dateGenerated;
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
         * @return The log_level
         */
        public String GetLogLevel() {
            return this.logLevel;
        }
    
        /**
         * @return The more_info
         */
        public String GetMoreInfo() {
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
        public String GetRequestUrl() {
            return this.requestUrl;
        }
    
        /**
         * @return The request_variables
         */
        public String GetRequestVariables() {
            return this.requestVariables;
        }
    
        /**
         * @return The resource_sid
         */
        public String GetResourceSid() {
            return this.resourceSid;
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
    
        /**
         * @return The sid
         */
        public String GetSid() {
            return this.sid;
        }
    
        /**
         * @return The url
         */
        public URI GetUrl() {
            return this.url;
        }
    }
}
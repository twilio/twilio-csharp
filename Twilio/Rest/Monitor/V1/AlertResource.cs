using Newtonsoft.Json;
using System;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Monitor.V1 {

    public class AlertResource : SidResource {
        /// <summary>
        /// fetch
        /// </summary>
        ///
        /// <param name="sid"> The sid </param>
        /// <returns> AlertFetcher capable of executing the fetch </returns> 
        public static AlertFetcher Fetcher(string sid) {
            return new AlertFetcher(sid);
        }
    
        /// <summary>
        /// delete
        /// </summary>
        ///
        /// <param name="sid"> The sid </param>
        /// <returns> AlertDeleter capable of executing the delete </returns> 
        public static AlertDeleter Deleter(string sid) {
            return new AlertDeleter(sid);
        }
    
        /// <summary>
        /// read
        /// </summary>
        ///
        /// <returns> AlertReader capable of executing the read </returns> 
        public static AlertReader Reader() {
            return new AlertReader();
        }
    
        /// <summary>
        /// Converts a JSON string into a AlertResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> AlertResource object represented by the provided JSON </returns> 
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
    
        /// <returns> The account_sid </returns> 
        public string GetAccountSid() {
            return this.accountSid;
        }
    
        /// <returns> The alert_text </returns> 
        public string GetAlertText() {
            return this.alertText;
        }
    
        /// <returns> The api_version </returns> 
        public string GetApiVersion() {
            return this.apiVersion;
        }
    
        /// <returns> The date_created </returns> 
        public DateTime? GetDateCreated() {
            return this.dateCreated;
        }
    
        /// <returns> The date_generated </returns> 
        public DateTime? GetDateGenerated() {
            return this.dateGenerated;
        }
    
        /// <returns> The date_updated </returns> 
        public DateTime? GetDateUpdated() {
            return this.dateUpdated;
        }
    
        /// <returns> The error_code </returns> 
        public string GetErrorCode() {
            return this.errorCode;
        }
    
        /// <returns> The log_level </returns> 
        public string GetLogLevel() {
            return this.logLevel;
        }
    
        /// <returns> The more_info </returns> 
        public string GetMoreInfo() {
            return this.moreInfo;
        }
    
        /// <returns> The request_method </returns> 
        public Twilio.Http.HttpMethod GetRequestMethod() {
            return this.requestMethod;
        }
    
        /// <returns> The request_url </returns> 
        public string GetRequestUrl() {
            return this.requestUrl;
        }
    
        /// <returns> The request_variables </returns> 
        public string GetRequestVariables() {
            return this.requestVariables;
        }
    
        /// <returns> The resource_sid </returns> 
        public string GetResourceSid() {
            return this.resourceSid;
        }
    
        /// <returns> The response_body </returns> 
        public string GetResponseBody() {
            return this.responseBody;
        }
    
        /// <returns> The response_headers </returns> 
        public string GetResponseHeaders() {
            return this.responseHeaders;
        }
    
        /// <returns> The sid </returns> 
        public override string GetSid() {
            return this.sid;
        }
    
        /// <returns> The url </returns> 
        public Uri GetUrl() {
            return this.url;
        }
    }
}
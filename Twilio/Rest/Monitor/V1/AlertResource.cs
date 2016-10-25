using Newtonsoft.Json;
using System;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Monitor.V1 
{

    public class AlertResource : Resource 
    {
        /// <summary>
        /// fetch
        /// </summary>
        ///
        /// <param name="sid"> The sid </param>
        /// <returns> AlertFetcher capable of executing the fetch </returns> 
        public static AlertFetcher Fetcher(string sid)
        {
            return new AlertFetcher(sid);
        }
    
        /// <summary>
        /// delete
        /// </summary>
        ///
        /// <param name="sid"> The sid </param>
        /// <returns> AlertDeleter capable of executing the delete </returns> 
        public static AlertDeleter Deleter(string sid)
        {
            return new AlertDeleter(sid);
        }
    
        /// <summary>
        /// read
        /// </summary>
        ///
        /// <param name="logLevel"> The log_level </param>
        /// <param name="startDate"> The start_date </param>
        /// <param name="endDate"> The end_date </param>
        /// <returns> AlertReader capable of executing the read </returns> 
        public static AlertReader Reader(string logLevel=null, DateTime? startDate=null, DateTime? endDate=null)
        {
            return new AlertReader(logLevel:logLevel, startDate:startDate, endDate:endDate);
        }
    
        /// <summary>
        /// Converts a JSON string into a AlertResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> AlertResource object represented by the provided JSON </returns> 
        public static AlertResource FromJson(string json)
        {
            // Convert all checked exceptions to Runtime
            try
            {
                return JsonConvert.DeserializeObject<AlertResource>(json);
            }
            catch (JsonException e)
            {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("account_sid")]
        public string accountSid { get; }
        [JsonProperty("alert_text")]
        public string alertText { get; }
        [JsonProperty("api_version")]
        public string apiVersion { get; }
        [JsonProperty("date_created")]
        public DateTime? dateCreated { get; }
        [JsonProperty("date_generated")]
        public DateTime? dateGenerated { get; }
        [JsonProperty("date_updated")]
        public DateTime? dateUpdated { get; }
        [JsonProperty("error_code")]
        public string errorCode { get; }
        [JsonProperty("log_level")]
        public string logLevel { get; }
        [JsonProperty("more_info")]
        public string moreInfo { get; }
        [JsonProperty("request_method")]
        [JsonConverter(typeof(HttpMethodConverter))]
        public Twilio.Http.HttpMethod requestMethod { get; }
        [JsonProperty("request_url")]
        public string requestUrl { get; }
        [JsonProperty("request_variables")]
        public string requestVariables { get; }
        [JsonProperty("resource_sid")]
        public string resourceSid { get; }
        [JsonProperty("response_body")]
        public string responseBody { get; }
        [JsonProperty("response_headers")]
        public string responseHeaders { get; }
        [JsonProperty("sid")]
        public string sid { get; }
        [JsonProperty("url")]
        public Uri url { get; }
    
        public AlertResource()
        {
        
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
                              Uri url)
                              {
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
    }
}
using Newtonsoft.Json;
using System;
using Twilio.Base;
using Twilio.Converters;
using Twilio.Exceptions;

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
        /// <returns> AlertReader capable of executing the read </returns> 
        public static AlertReader Reader()
        {
            return new AlertReader();
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
        public string AccountSid { get; set; }
        [JsonProperty("alert_text")]
        public string AlertText { get; set; }
        [JsonProperty("api_version")]
        public string ApiVersion { get; set; }
        [JsonProperty("date_created")]
        public DateTime? DateCreated { get; set; }
        [JsonProperty("date_generated")]
        public DateTime? DateGenerated { get; set; }
        [JsonProperty("date_updated")]
        public DateTime? DateUpdated { get; set; }
        [JsonProperty("error_code")]
        public string ErrorCode { get; set; }
        [JsonProperty("log_level")]
        public string LogLevel { get; set; }
        [JsonProperty("more_info")]
        public string MoreInfo { get; set; }
        [JsonProperty("request_method")]
        [JsonConverter(typeof(HttpMethodConverter))]
        public Twilio.Http.HttpMethod RequestMethod { get; set; }
        [JsonProperty("request_url")]
        public string RequestUrl { get; set; }
        [JsonProperty("request_variables")]
        public string RequestVariables { get; set; }
        [JsonProperty("resource_sid")]
        public string ResourceSid { get; set; }
        [JsonProperty("response_body")]
        public string ResponseBody { get; set; }
        [JsonProperty("response_headers")]
        public string ResponseHeaders { get; set; }
        [JsonProperty("sid")]
        public string Sid { get; set; }
        [JsonProperty("url")]
        public Uri Url { get; set; }
    
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
            AccountSid = accountSid;
            AlertText = alertText;
            ApiVersion = apiVersion;
            DateCreated = MarshalConverter.DateTimeFromString(dateCreated);
            DateGenerated = MarshalConverter.DateTimeFromString(dateGenerated);
            DateUpdated = MarshalConverter.DateTimeFromString(dateUpdated);
            ErrorCode = errorCode;
            LogLevel = logLevel;
            MoreInfo = moreInfo;
            RequestMethod = requestMethod;
            RequestUrl = requestUrl;
            RequestVariables = requestVariables;
            ResourceSid = resourceSid;
            ResponseBody = responseBody;
            ResponseHeaders = responseHeaders;
            Sid = sid;
            Url = url;
        }
    }
}
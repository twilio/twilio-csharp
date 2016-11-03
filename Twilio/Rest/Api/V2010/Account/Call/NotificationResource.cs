using Newtonsoft.Json;
using System;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Api.V2010.Account.Call 
{

    public class NotificationResource : Resource 
    {
        /// <summary>
        /// fetch
        /// </summary>
        ///
        /// <param name="callSid"> The call_sid </param>
        /// <param name="sid"> The sid </param>
        /// <returns> NotificationFetcher capable of executing the fetch </returns> 
        public static NotificationFetcher Fetcher(string callSid, string sid)
        {
            return new NotificationFetcher(callSid, sid);
        }
    
        /// <summary>
        /// delete
        /// </summary>
        ///
        /// <param name="callSid"> The call_sid </param>
        /// <param name="sid"> The sid </param>
        /// <returns> NotificationDeleter capable of executing the delete </returns> 
        public static NotificationDeleter Deleter(string callSid, string sid)
        {
            return new NotificationDeleter(callSid, sid);
        }
    
        /// <summary>
        /// read
        /// </summary>
        ///
        /// <param name="callSid"> The call_sid </param>
        /// <returns> NotificationReader capable of executing the read </returns> 
        public static NotificationReader Reader(string callSid)
        {
            return new NotificationReader(callSid);
        }
    
        /// <summary>
        /// Converts a JSON string into a NotificationResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> NotificationResource object represented by the provided JSON </returns> 
        public static NotificationResource FromJson(string json)
        {
            // Convert all checked exceptions to Runtime
            try
            {
                return JsonConvert.DeserializeObject<NotificationResource>(json);
            }
            catch (JsonException e)
            {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("account_sid")]
        public string accountSid { get; set; }
        [JsonProperty("api_version")]
        public string apiVersion { get; set; }
        [JsonProperty("call_sid")]
        public string callSid { get; set; }
        [JsonProperty("date_created")]
        public DateTime? dateCreated { get; set; }
        [JsonProperty("date_updated")]
        public DateTime? dateUpdated { get; set; }
        [JsonProperty("error_code")]
        public string errorCode { get; set; }
        [JsonProperty("log")]
        public string log { get; set; }
        [JsonProperty("message_date")]
        public DateTime? messageDate { get; set; }
        [JsonProperty("message_text")]
        public string messageText { get; set; }
        [JsonProperty("more_info")]
        public Uri moreInfo { get; set; }
        [JsonProperty("request_method")]
        [JsonConverter(typeof(HttpMethodConverter))]
        public Twilio.Http.HttpMethod requestMethod { get; set; }
        [JsonProperty("request_url")]
        public Uri requestUrl { get; set; }
        [JsonProperty("request_variables")]
        public string requestVariables { get; set; }
        [JsonProperty("response_body")]
        public string responseBody { get; set; }
        [JsonProperty("response_headers")]
        public string responseHeaders { get; set; }
        [JsonProperty("sid")]
        public string sid { get; set; }
        [JsonProperty("uri")]
        public string uri { get; set; }
    
        public NotificationResource()
        {
        
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
                                     string uri)
                                     {
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
    }
}
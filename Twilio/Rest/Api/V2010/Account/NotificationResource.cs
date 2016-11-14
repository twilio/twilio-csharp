using Newtonsoft.Json;
using System;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Api.V2010.Account 
{

    public class NotificationResource : Resource 
    {
        /// <summary>
        /// Fetch a notification belonging to the account used to make the request
        /// </summary>
        ///
        /// <param name="sid"> Fetch by unique notification Sid </param>
        /// <returns> NotificationFetcher capable of executing the fetch </returns> 
        public static NotificationFetcher Fetcher(string sid)
        {
            return new NotificationFetcher(sid);
        }
    
        /// <summary>
        /// Delete a notification identified by the NotificationSid from an accounts log
        /// </summary>
        ///
        /// <param name="sid"> Delete by unique notification Sid </param>
        /// <returns> NotificationDeleter capable of executing the delete </returns> 
        public static NotificationDeleter Deleter(string sid)
        {
            return new NotificationDeleter(sid);
        }
    
        /// <summary>
        /// Retrieve a list of notifications belonging to the account used to make the request
        /// </summary>
        ///
        /// <returns> NotificationReader capable of executing the read </returns> 
        public static NotificationReader Reader()
        {
            return new NotificationReader();
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
        public string AccountSid { get; set; }
        [JsonProperty("api_version")]
        public string ApiVersion { get; set; }
        [JsonProperty("call_sid")]
        public string CallSid { get; set; }
        [JsonProperty("date_created")]
        public DateTime? DateCreated { get; set; }
        [JsonProperty("date_updated")]
        public DateTime? DateUpdated { get; set; }
        [JsonProperty("error_code")]
        public string ErrorCode { get; set; }
        [JsonProperty("log")]
        public string Log { get; set; }
        [JsonProperty("message_date")]
        public DateTime? MessageDate { get; set; }
        [JsonProperty("message_text")]
        public string MessageText { get; set; }
        [JsonProperty("more_info")]
        public Uri MoreInfo { get; set; }
        [JsonProperty("request_method")]
        [JsonConverter(typeof(HttpMethodConverter))]
        public Twilio.Http.HttpMethod RequestMethod { get; set; }
        [JsonProperty("request_url")]
        public Uri RequestUrl { get; set; }
        [JsonProperty("request_variables")]
        public string RequestVariables { get; set; }
        [JsonProperty("response_body")]
        public string ResponseBody { get; set; }
        [JsonProperty("response_headers")]
        public string ResponseHeaders { get; set; }
        [JsonProperty("sid")]
        public string Sid { get; set; }
        [JsonProperty("uri")]
        public string Uri { get; set; }
    
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
            AccountSid = accountSid;
            ApiVersion = apiVersion;
            CallSid = callSid;
            DateCreated = MarshalConverter.DateTimeFromString(dateCreated);
            DateUpdated = MarshalConverter.DateTimeFromString(dateUpdated);
            ErrorCode = errorCode;
            Log = log;
            MessageDate = MarshalConverter.DateTimeFromString(messageDate);
            MessageText = messageText;
            MoreInfo = moreInfo;
            RequestMethod = requestMethod;
            RequestUrl = requestUrl;
            RequestVariables = requestVariables;
            ResponseBody = responseBody;
            ResponseHeaders = responseHeaders;
            Sid = sid;
            Uri = uri;
        }
    }
}
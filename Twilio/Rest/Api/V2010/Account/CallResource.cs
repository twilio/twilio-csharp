using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Types;

namespace Twilio.Rest.Api.V2010.Account 
{

    public class CallResource : Resource 
    {
        public sealed class Event : IStringEnum 
        {
            public const string Initiated = "initiated";
            public const string Ringing = "ringing";
            public const string Answered = "answered";
            public const string Completed = "completed";
        
            private string _value;
            
            public Event() {}
            
            public Event(string value)
            {
                _value = value;
            }
            
            public override string ToString()
            {
                return _value;
            }
            
            public static implicit operator Event(string value)
            {
                return new Event(value);
            }
            
            public static implicit operator string(Event value)
            {
                return value.ToString();
            }
            
            public void FromString(string value)
            {
                _value = value;
            }
        }
    
        public sealed class Status : IStringEnum 
        {
            public const string Queued = "queued";
            public const string Ringing = "ringing";
            public const string InProgress = "in-progress";
            public const string Completed = "completed";
            public const string Busy = "busy";
            public const string Failed = "failed";
            public const string NoAnswer = "no-answer";
            public const string Canceled = "canceled";
        
            private string _value;
            
            public Status() {}
            
            public Status(string value)
            {
                _value = value;
            }
            
            public override string ToString()
            {
                return _value;
            }
            
            public static implicit operator Status(string value)
            {
                return new Status(value);
            }
            
            public static implicit operator string(Status value)
            {
                return value.ToString();
            }
            
            public void FromString(string value)
            {
                _value = value;
            }
        }
    
        /// <summary>
        /// Create a new outgoing call to phones, SIP-enabled endpoints or Twilio Client connections
        /// </summary>
        ///
        /// <param name="to"> Phone number, SIP address or client identifier to call </param>
        /// <param name="from"> Twilio number from which to originate the call </param>
        /// <param name="url"> Url from which to fetch TwiML </param>
        /// <param name="accountSid"> The account_sid </param>
        /// <param name="applicationSid"> ApplicationSid that configures from where to fetch TwiML </param>
        /// <param name="method"> HTTP method to use to fetch TwiML </param>
        /// <param name="fallbackUrl"> Fallback URL in case of error </param>
        /// <param name="fallbackMethod"> HTTP Method to use with FallbackUrl </param>
        /// <param name="statusCallback"> Status Callback URL </param>
        /// <param name="statusCallbackEvent"> The status_callback_event </param>
        /// <param name="statusCallbackMethod"> HTTP Method to use with StatusCallback </param>
        /// <param name="sendDigits"> Digits to send </param>
        /// <param name="ifMachine"> Action to take if a machine has answered the call </param>
        /// <param name="timeout"> Number of seconds to wait for an answer </param>
        /// <param name="record"> Whether or not to record the Call </param>
        /// <param name="recordingChannels"> The recording_channels </param>
        /// <param name="recordingStatusCallback"> The recording_status_callback </param>
        /// <param name="recordingStatusCallbackMethod"> The recording_status_callback_method </param>
        /// <param name="sipAuthUsername"> The sip_auth_username </param>
        /// <param name="sipAuthPassword"> The sip_auth_password </param>
        /// <returns> CallCreator capable of executing the create </returns> 
        public static CallCreator Creator(IEndpoint to, Twilio.Types.PhoneNumber from, Uri url, string accountSid=null, string applicationSid=null, Twilio.Http.HttpMethod method=null, Uri fallbackUrl=null, Twilio.Http.HttpMethod fallbackMethod=null, Uri statusCallback=null, List<string> statusCallbackEvent=null, Twilio.Http.HttpMethod statusCallbackMethod=null, string sendDigits=null, string ifMachine=null, int? timeout=null, bool? record=null, string recordingChannels=null, string recordingStatusCallback=null, Twilio.Http.HttpMethod recordingStatusCallbackMethod=null, string sipAuthUsername=null, string sipAuthPassword=null)
        {
            return new CallCreator(to, from, url, accountSid:accountSid, applicationSid:applicationSid, method:method, fallbackUrl:fallbackUrl, fallbackMethod:fallbackMethod, statusCallback:statusCallback, statusCallbackEvent:statusCallbackEvent, statusCallbackMethod:statusCallbackMethod, sendDigits:sendDigits, ifMachine:ifMachine, timeout:timeout, record:record, recordingChannels:recordingChannels, recordingStatusCallback:recordingStatusCallback, recordingStatusCallbackMethod:recordingStatusCallbackMethod, sipAuthUsername:sipAuthUsername, sipAuthPassword:sipAuthPassword);
        }
    
        /// <summary>
        /// Create a new outgoing call to phones, SIP-enabled endpoints or Twilio Client connections
        /// </summary>
        ///
        /// <param name="to"> Phone number, SIP address or client identifier to call </param>
        /// <param name="from"> Twilio number from which to originate the call </param>
        /// <param name="applicationSid"> ApplicationSid that configures from where to fetch TwiML </param>
        /// <param name="accountSid"> The account_sid </param>
        /// <param name="url"> Url from which to fetch TwiML </param>
        /// <param name="method"> HTTP method to use to fetch TwiML </param>
        /// <param name="fallbackUrl"> Fallback URL in case of error </param>
        /// <param name="fallbackMethod"> HTTP Method to use with FallbackUrl </param>
        /// <param name="statusCallback"> Status Callback URL </param>
        /// <param name="statusCallbackEvent"> The status_callback_event </param>
        /// <param name="statusCallbackMethod"> HTTP Method to use with StatusCallback </param>
        /// <param name="sendDigits"> Digits to send </param>
        /// <param name="ifMachine"> Action to take if a machine has answered the call </param>
        /// <param name="timeout"> Number of seconds to wait for an answer </param>
        /// <param name="record"> Whether or not to record the Call </param>
        /// <param name="recordingChannels"> The recording_channels </param>
        /// <param name="recordingStatusCallback"> The recording_status_callback </param>
        /// <param name="recordingStatusCallbackMethod"> The recording_status_callback_method </param>
        /// <param name="sipAuthUsername"> The sip_auth_username </param>
        /// <param name="sipAuthPassword"> The sip_auth_password </param>
        /// <returns> CallCreator capable of executing the create </returns> 
        public static CallCreator Creator(IEndpoint to, Twilio.Types.PhoneNumber from, string applicationSid, string accountSid=null, Uri url=null, Twilio.Http.HttpMethod method=null, Uri fallbackUrl=null, Twilio.Http.HttpMethod fallbackMethod=null, Uri statusCallback=null, List<string> statusCallbackEvent=null, Twilio.Http.HttpMethod statusCallbackMethod=null, string sendDigits=null, string ifMachine=null, int? timeout=null, bool? record=null, string recordingChannels=null, string recordingStatusCallback=null, Twilio.Http.HttpMethod recordingStatusCallbackMethod=null, string sipAuthUsername=null, string sipAuthPassword=null)
        {
            return new CallCreator(to, from, applicationSid, accountSid:accountSid, url:url, method:method, fallbackUrl:fallbackUrl, fallbackMethod:fallbackMethod, statusCallback:statusCallback, statusCallbackEvent:statusCallbackEvent, statusCallbackMethod:statusCallbackMethod, sendDigits:sendDigits, ifMachine:ifMachine, timeout:timeout, record:record, recordingChannels:recordingChannels, recordingStatusCallback:recordingStatusCallback, recordingStatusCallbackMethod:recordingStatusCallbackMethod, sipAuthUsername:sipAuthUsername, sipAuthPassword:sipAuthPassword);
        }
    
        /// <summary>
        /// Once the record is deleted, it will no longer appear in the API and Account Portal logs.
        /// </summary>
        ///
        /// <param name="sid"> Call Sid that uniquely identifies the Call to delete </param>
        /// <param name="accountSid"> The account_sid </param>
        /// <returns> CallDeleter capable of executing the delete </returns> 
        public static CallDeleter Deleter(string sid, string accountSid=null)
        {
            return new CallDeleter(sid, accountSid:accountSid);
        }
    
        /// <summary>
        /// Fetch the Call specified by the provided Call Sid
        /// </summary>
        ///
        /// <param name="sid"> Call Sid that uniquely identifies the Call to fetch </param>
        /// <param name="accountSid"> The account_sid </param>
        /// <returns> CallFetcher capable of executing the fetch </returns> 
        public static CallFetcher Fetcher(string sid, string accountSid=null)
        {
            return new CallFetcher(sid, accountSid:accountSid);
        }
    
        /// <summary>
        /// Retrieves a collection of Calls made to and from your account
        /// </summary>
        ///
        /// <param name="accountSid"> The account_sid </param>
        /// <param name="to"> Phone number or Client identifier to filter `to` on </param>
        /// <param name="from"> Phone number or Client identifier to filter `from` on </param>
        /// <param name="parentCallSid"> Parent Call Sid to filter on </param>
        /// <param name="status"> Status to filter on </param>
        /// <param name="startTime"> StartTime to filter on </param>
        /// <param name="endTime"> EndTime to filter on </param>
        /// <returns> CallReader capable of executing the read </returns> 
        public static CallReader Reader(string accountSid=null, Twilio.Types.PhoneNumber to=null, Twilio.Types.PhoneNumber from=null, string parentCallSid=null, CallResource.Status status=null, string startTime=null, string endTime=null)
        {
            return new CallReader(accountSid:accountSid, to:to, from:from, parentCallSid:parentCallSid, status:status, startTime:startTime, endTime:endTime);
        }
    
        /// <summary>
        /// Initiates a call redirect or terminates a call
        /// </summary>
        ///
        /// <param name="sid"> Call Sid that uniquely identifies the Call to update </param>
        /// <param name="accountSid"> The account_sid </param>
        /// <param name="url"> URL that returns TwiML </param>
        /// <param name="method"> HTTP method to use to fetch TwiML </param>
        /// <param name="status"> Status to update the Call with </param>
        /// <param name="fallbackUrl"> Fallback URL in case of error </param>
        /// <param name="fallbackMethod"> HTTP Method to use with FallbackUrl </param>
        /// <param name="statusCallback"> Status Callback URL </param>
        /// <param name="statusCallbackMethod"> HTTP Method to use with StatusCallback </param>
        /// <returns> CallUpdater capable of executing the update </returns> 
        public static CallUpdater Updater(string sid, string accountSid=null, Uri url=null, Twilio.Http.HttpMethod method=null, CallResource.Status status=null, Uri fallbackUrl=null, Twilio.Http.HttpMethod fallbackMethod=null, Uri statusCallback=null, Twilio.Http.HttpMethod statusCallbackMethod=null)
        {
            return new CallUpdater(sid, accountSid:accountSid, url:url, method:method, status:status, fallbackUrl:fallbackUrl, fallbackMethod:fallbackMethod, statusCallback:statusCallback, statusCallbackMethod:statusCallbackMethod);
        }
    
        /// <summary>
        /// Converts a JSON string into a CallResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> CallResource object represented by the provided JSON </returns> 
        public static CallResource FromJson(string json)
        {
            // Convert all checked exceptions to Runtime
            try
            {
                return JsonConvert.DeserializeObject<CallResource>(json);
            }
            catch (JsonException e)
            {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("account_sid")]
        public string accountSid { get; }
        [JsonProperty("annotation")]
        public string annotation { get; }
        [JsonProperty("answered_by")]
        public string answeredBy { get; }
        [JsonProperty("api_version")]
        public string apiVersion { get; }
        [JsonProperty("caller_name")]
        public string callerName { get; }
        [JsonProperty("date_created")]
        public DateTime? dateCreated { get; }
        [JsonProperty("date_updated")]
        public DateTime? dateUpdated { get; }
        [JsonProperty("direction")]
        public string direction { get; }
        [JsonProperty("duration")]
        public string duration { get; }
        [JsonProperty("end_time")]
        public DateTime? endTime { get; }
        [JsonProperty("forwarded_from")]
        public string forwardedFrom { get; }
        [JsonProperty("from")]
        public string from { get; }
        [JsonProperty("from_formatted")]
        public string fromFormatted { get; }
        [JsonProperty("group_sid")]
        public string groupSid { get; }
        [JsonProperty("parent_call_sid")]
        public string parentCallSid { get; }
        [JsonProperty("phone_number_sid")]
        public string phoneNumberSid { get; }
        [JsonProperty("price")]
        public decimal? price { get; }
        [JsonProperty("price_unit")]
        public string priceUnit { get; }
        [JsonProperty("sid")]
        public string sid { get; }
        [JsonProperty("start_time")]
        public DateTime? startTime { get; }
        [JsonProperty("status")]
        [JsonConverter(typeof(StringEnumConverter))]
        public CallResource.Status status { get; }
        [JsonProperty("subresource_uris")]
        public Dictionary<string, string> subresourceUris { get; }
        [JsonProperty("to")]
        public string to { get; }
        [JsonProperty("to_formatted")]
        public string toFormatted { get; }
        [JsonProperty("uri")]
        public string uri { get; }
    
        public CallResource()
        {
        
        }
    
        private CallResource([JsonProperty("account_sid")]
                             string accountSid, 
                             [JsonProperty("annotation")]
                             string annotation, 
                             [JsonProperty("answered_by")]
                             string answeredBy, 
                             [JsonProperty("api_version")]
                             string apiVersion, 
                             [JsonProperty("caller_name")]
                             string callerName, 
                             [JsonProperty("date_created")]
                             string dateCreated, 
                             [JsonProperty("date_updated")]
                             string dateUpdated, 
                             [JsonProperty("direction")]
                             string direction, 
                             [JsonProperty("duration")]
                             string duration, 
                             [JsonProperty("end_time")]
                             string endTime, 
                             [JsonProperty("forwarded_from")]
                             string forwardedFrom, 
                             [JsonProperty("from")]
                             string from, 
                             [JsonProperty("from_formatted")]
                             string fromFormatted, 
                             [JsonProperty("group_sid")]
                             string groupSid, 
                             [JsonProperty("parent_call_sid")]
                             string parentCallSid, 
                             [JsonProperty("phone_number_sid")]
                             string phoneNumberSid, 
                             [JsonProperty("price")]
                             decimal? price, 
                             [JsonProperty("price_unit")]
                             string priceUnit, 
                             [JsonProperty("sid")]
                             string sid, 
                             [JsonProperty("start_time")]
                             string startTime, 
                             [JsonProperty("status")]
                             CallResource.Status status, 
                             [JsonProperty("subresource_uris")]
                             Dictionary<string, string> subresourceUris, 
                             [JsonProperty("to")]
                             string to, 
                             [JsonProperty("to_formatted")]
                             string toFormatted, 
                             [JsonProperty("uri")]
                             string uri)
                             {
            this.accountSid = accountSid;
            this.annotation = annotation;
            this.answeredBy = answeredBy;
            this.apiVersion = apiVersion;
            this.callerName = callerName;
            this.dateCreated = MarshalConverter.DateTimeFromString(dateCreated);
            this.dateUpdated = MarshalConverter.DateTimeFromString(dateUpdated);
            this.direction = direction;
            this.duration = duration;
            this.endTime = MarshalConverter.DateTimeFromString(endTime);
            this.forwardedFrom = forwardedFrom;
            this.from = from;
            this.fromFormatted = fromFormatted;
            this.groupSid = groupSid;
            this.parentCallSid = parentCallSid;
            this.phoneNumberSid = phoneNumberSid;
            this.price = price;
            this.priceUnit = priceUnit;
            this.sid = sid;
            this.startTime = MarshalConverter.DateTimeFromString(startTime);
            this.status = status;
            this.subresourceUris = subresourceUris;
            this.to = to;
            this.toFormatted = toFormatted;
            this.uri = uri;
        }
    }
}
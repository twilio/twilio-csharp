using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Types;

namespace Twilio.Rest.Api.V2010.Account 
{

    public class CallResource : Resource 
    {
        public sealed class EventEnum : StringEnum 
        {
            private EventEnum(string value) : base(value) {}
            public EventEnum() {}
        
            public static readonly EventEnum Initiated = new EventEnum("initiated");
            public static readonly EventEnum Ringing = new EventEnum("ringing");
            public static readonly EventEnum Answered = new EventEnum("answered");
            public static readonly EventEnum Completed = new EventEnum("completed");
        }
    
        public sealed class StatusEnum : StringEnum 
        {
            private StatusEnum(string value) : base(value) {}
            public StatusEnum() {}
        
            public static readonly StatusEnum Queued = new StatusEnum("queued");
            public static readonly StatusEnum Ringing = new StatusEnum("ringing");
            public static readonly StatusEnum InProgress = new StatusEnum("in-progress");
            public static readonly StatusEnum Completed = new StatusEnum("completed");
            public static readonly StatusEnum Busy = new StatusEnum("busy");
            public static readonly StatusEnum Failed = new StatusEnum("failed");
            public static readonly StatusEnum NoAnswer = new StatusEnum("no-answer");
            public static readonly StatusEnum Canceled = new StatusEnum("canceled");
        }
    
        /// <summary>
        /// Create a new outgoing call to phones, SIP-enabled endpoints or Twilio Client connections
        /// </summary>
        ///
        /// <param name="to"> Phone number, SIP address or client identifier to call </param>
        /// <param name="from"> Twilio number from which to originate the call </param>
        /// <param name="url"> Url from which to fetch TwiML </param>
        /// <returns> CallCreator capable of executing the create </returns> 
        public static CallCreator Creator(IEndpoint to, Types.PhoneNumber from, Uri url)
        {
            return new CallCreator(to, from, url);
        }
    
        /// <summary>
        /// Create a new outgoing call to phones, SIP-enabled endpoints or Twilio Client connections
        /// </summary>
        ///
        /// <param name="to"> Phone number, SIP address or client identifier to call </param>
        /// <param name="from"> Twilio number from which to originate the call </param>
        /// <param name="applicationSid"> ApplicationSid that configures from where to fetch TwiML </param>
        /// <returns> CallCreator capable of executing the create </returns> 
        public static CallCreator Creator(IEndpoint to, Types.PhoneNumber from, string applicationSid)
        {
            return new CallCreator(to, from, applicationSid);
        }
    
        /// <summary>
        /// Once the record is deleted, it will no longer appear in the API and Account Portal logs.
        /// </summary>
        ///
        /// <param name="sid"> Call Sid that uniquely identifies the Call to delete </param>
        /// <returns> CallDeleter capable of executing the delete </returns> 
        public static CallDeleter Deleter(string sid)
        {
            return new CallDeleter(sid);
        }
    
        /// <summary>
        /// Fetch the Call specified by the provided Call Sid
        /// </summary>
        ///
        /// <param name="sid"> Call Sid that uniquely identifies the Call to fetch </param>
        /// <returns> CallFetcher capable of executing the fetch </returns> 
        public static CallFetcher Fetcher(string sid)
        {
            return new CallFetcher(sid);
        }
    
        /// <summary>
        /// Retrieves a collection of Calls made to and from your account
        /// </summary>
        ///
        /// <returns> CallReader capable of executing the read </returns> 
        public static CallReader Reader()
        {
            return new CallReader();
        }
    
        /// <summary>
        /// Initiates a call redirect or terminates a call
        /// </summary>
        ///
        /// <param name="sid"> Call Sid that uniquely identifies the Call to update </param>
        /// <returns> CallUpdater capable of executing the update </returns> 
        public static CallUpdater Updater(string sid)
        {
            return new CallUpdater(sid);
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
        public string AccountSid { get; set; }
        [JsonProperty("annotation")]
        public string Annotation { get; set; }
        [JsonProperty("answered_by")]
        public string AnsweredBy { get; set; }
        [JsonProperty("api_version")]
        public string ApiVersion { get; set; }
        [JsonProperty("caller_name")]
        public string CallerName { get; set; }
        [JsonProperty("date_created")]
        public DateTime? DateCreated { get; set; }
        [JsonProperty("date_updated")]
        public DateTime? DateUpdated { get; set; }
        [JsonProperty("direction")]
        public string Direction { get; set; }
        [JsonProperty("duration")]
        public string Duration { get; set; }
        [JsonProperty("end_time")]
        public DateTime? EndTime { get; set; }
        [JsonProperty("forwarded_from")]
        public string ForwardedFrom { get; set; }
        [JsonProperty("from")]
        public string From { get; set; }
        [JsonProperty("from_formatted")]
        public string FromFormatted { get; set; }
        [JsonProperty("group_sid")]
        public string GroupSid { get; set; }
        [JsonProperty("parent_call_sid")]
        public string ParentCallSid { get; set; }
        [JsonProperty("phone_number_sid")]
        public string PhoneNumberSid { get; set; }
        [JsonProperty("price")]
        public decimal? Price { get; set; }
        [JsonProperty("price_unit")]
        public string PriceUnit { get; set; }
        [JsonProperty("sid")]
        public string Sid { get; set; }
        [JsonProperty("start_time")]
        public DateTime? StartTime { get; set; }
        [JsonProperty("status")]
        [JsonConverter(typeof(StringEnumConverter))]
        public CallResource.StatusEnum Status { get; set; }
        [JsonProperty("subresource_uris")]
        public Dictionary<string, string> SubresourceUris { get; set; }
        [JsonProperty("to")]
        public string To { get; set; }
        [JsonProperty("to_formatted")]
        public string ToFormatted { get; set; }
        [JsonProperty("uri")]
        public string Uri { get; set; }
    
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
                             CallResource.StatusEnum status, 
                             [JsonProperty("subresource_uris")]
                             Dictionary<string, string> subresourceUris, 
                             [JsonProperty("to")]
                             string to, 
                             [JsonProperty("to_formatted")]
                             string toFormatted, 
                             [JsonProperty("uri")]
                             string uri)
                             {
            AccountSid = accountSid;
            Annotation = annotation;
            AnsweredBy = answeredBy;
            ApiVersion = apiVersion;
            CallerName = callerName;
            DateCreated = MarshalConverter.DateTimeFromString(dateCreated);
            DateUpdated = MarshalConverter.DateTimeFromString(dateUpdated);
            Direction = direction;
            Duration = duration;
            EndTime = MarshalConverter.DateTimeFromString(endTime);
            ForwardedFrom = forwardedFrom;
            From = from;
            FromFormatted = fromFormatted;
            GroupSid = groupSid;
            ParentCallSid = parentCallSid;
            PhoneNumberSid = phoneNumberSid;
            Price = price;
            PriceUnit = priceUnit;
            Sid = sid;
            StartTime = MarshalConverter.DateTimeFromString(startTime);
            Status = status;
            SubresourceUris = subresourceUris;
            To = to;
            ToFormatted = toFormatted;
            Uri = uri;
        }
    }
}
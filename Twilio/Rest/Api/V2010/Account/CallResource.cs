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
        /// <returns> CallCreator capable of executing the create </returns> 
        public static CallCreator Creator(IEndpoint to, Twilio.Types.PhoneNumber from, Uri url)
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
        public static CallCreator Creator(IEndpoint to, Twilio.Types.PhoneNumber from, string applicationSid)
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
        public string accountSid { get; set; }
        [JsonProperty("annotation")]
        public string annotation { get; set; }
        [JsonProperty("answered_by")]
        public string answeredBy { get; set; }
        [JsonProperty("api_version")]
        public string apiVersion { get; set; }
        [JsonProperty("caller_name")]
        public string callerName { get; set; }
        [JsonProperty("date_created")]
        public DateTime? dateCreated { get; set; }
        [JsonProperty("date_updated")]
        public DateTime? dateUpdated { get; set; }
        [JsonProperty("direction")]
        public string direction { get; set; }
        [JsonProperty("duration")]
        public string duration { get; set; }
        [JsonProperty("end_time")]
        public DateTime? endTime { get; set; }
        [JsonProperty("forwarded_from")]
        public string forwardedFrom { get; set; }
        [JsonProperty("from")]
        public string from { get; set; }
        [JsonProperty("from_formatted")]
        public string fromFormatted { get; set; }
        [JsonProperty("group_sid")]
        public string groupSid { get; set; }
        [JsonProperty("parent_call_sid")]
        public string parentCallSid { get; set; }
        [JsonProperty("phone_number_sid")]
        public string phoneNumberSid { get; set; }
        [JsonProperty("price")]
        public decimal? price { get; set; }
        [JsonProperty("price_unit")]
        public string priceUnit { get; set; }
        [JsonProperty("sid")]
        public string sid { get; set; }
        [JsonProperty("start_time")]
        public DateTime? startTime { get; set; }
        [JsonProperty("status")]
        [JsonConverter(typeof(StringEnumConverter))]
        public CallResource.Status status { get; set; }
        [JsonProperty("subresource_uris")]
        public Dictionary<string, string> subresourceUris { get; set; }
        [JsonProperty("to")]
        public string to { get; set; }
        [JsonProperty("to_formatted")]
        public string toFormatted { get; set; }
        [JsonProperty("uri")]
        public string uri { get; set; }
    
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
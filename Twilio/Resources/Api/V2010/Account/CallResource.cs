using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Creators.Api.V2010.Account;
using Twilio.Deleters.Api.V2010.Account;
using Twilio.Exceptions;
using Twilio.Fetchers.Api.V2010.Account;
using Twilio.Http;
using Twilio.Readers.Api.V2010.Account;
using Twilio.Resources;
using Twilio.Updaters.Api.V2010.Account;

namespace Twilio.Resources.Api.V2010.Account {

    public class CallResource : SidResource {
        public sealed class Event : IStringEnum {
            public const string INITIATED="initiated";
            public const string RINGING="ringing";
            public const string ANSWERED="answered";
            public const string COMPLETED="completed";
        
            private string value;
            
            public Event() { }
            
            public Event(string value) {
                this.value = value;
            }
            
            public override string ToString() {
                return value;
            }
            
            public static implicit operator Event(string value) {
                return new Event(value);
            }
            
            public static implicit operator string(Event value) {
                return value.ToString();
            }
            
            public void FromString(string value) {
                this.value = value;
            }
        }
    
        public sealed class Status : IStringEnum {
            public const string QUEUED="queued";
            public const string RINGING="ringing";
            public const string IN_PROGRESS="in-progress";
            public const string COMPLETED="completed";
            public const string BUSY="busy";
            public const string FAILED="failed";
            public const string NO_ANSWER="no-answer";
            public const string CANCELED="canceled";
        
            private string value;
            
            public Status() { }
            
            public Status(string value) {
                this.value = value;
            }
            
            public override string ToString() {
                return value;
            }
            
            public static implicit operator Status(string value) {
                return new Status(value);
            }
            
            public static implicit operator string(Status value) {
                return value.ToString();
            }
            
            public void FromString(string value) {
                this.value = value;
            }
        }
    
        /**
         * Create a new outgoing call to phones, SIP-enabled endpoints or Twilio Client
         * connections
         * 
         * @param accountSid The account_sid
         * @param to Phone number, SIP address or client identifier to call
         * @param from Twilio number from which to originate the call
         * @param url Url from which to fetch TwiML
         * @return CallCreator capable of executing the create
         */
        public static CallCreator Create(string accountSid, Twilio.Types.PhoneNumber to, Twilio.Types.PhoneNumber from, Uri url) {
            return new CallCreator(accountSid, to, from, url);
        }
    
        /**
         * Create a new outgoing call to phones, SIP-enabled endpoints or Twilio Client
         * connections
         * 
         * @param accountSid The account_sid
         * @param to Phone number, SIP address or client identifier to call
         * @param from Twilio number from which to originate the call
         * @param applicationSid ApplicationSid that configures from where to fetch
         *                       TwiML
         * @return CallCreator capable of executing the create
         */
        public static CallCreator Create(string accountSid, Twilio.Types.PhoneNumber to, Twilio.Types.PhoneNumber from, string applicationSid) {
            return new CallCreator(accountSid, to, from, applicationSid);
        }
    
        /**
         * Once the record is deleted, it will no longer appear in the API and Account
         * Portal logs.
         * 
         * @param accountSid The account_sid
         * @param sid Call Sid that uniquely identifies the Call to delete
         * @return CallDeleter capable of executing the delete
         */
        public static CallDeleter Delete(string accountSid, string sid) {
            return new CallDeleter(accountSid, sid);
        }
    
        /**
         * Fetch the Call specified by the provided Call Sid
         * 
         * @param accountSid The account_sid
         * @param sid Call Sid that uniquely identifies the Call to fetch
         * @return CallFetcher capable of executing the fetch
         */
        public static CallFetcher Fetch(string accountSid, string sid) {
            return new CallFetcher(accountSid, sid);
        }
    
        /**
         * Retrieves a collection of Calls made to and from your account
         * 
         * @param accountSid The account_sid
         * @return CallReader capable of executing the read
         */
        public static CallReader Read(string accountSid) {
            return new CallReader(accountSid);
        }
    
        /**
         * Initiates a call redirect or terminates a call
         * 
         * @param accountSid The account_sid
         * @param sid Call Sid that uniquely identifies the Call to update
         * @return CallUpdater capable of executing the update
         */
        public static CallUpdater Update(string accountSid, string sid) {
            return new CallUpdater(accountSid, sid);
        }
    
        /**
         * Converts a JSON string into a CallResource object
         * 
         * @param json Raw JSON string
         * @return CallResource object represented by the provided JSON
         */
        public static CallResource FromJson(string json) {
            // Convert all checked exceptions to Runtime
            try {
                return JsonConvert.DeserializeObject<CallResource>(json);
            } catch (JsonException e) {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("account_sid")]
        private readonly string accountSid;
        [JsonProperty("annotation")]
        private readonly string annotation;
        [JsonProperty("answered_by")]
        private readonly string answeredBy;
        [JsonProperty("api_version")]
        private readonly string apiVersion;
        [JsonProperty("caller_name")]
        private readonly string callerName;
        [JsonProperty("date_created")]
        private readonly DateTime? dateCreated;
        [JsonProperty("date_updated")]
        private readonly DateTime? dateUpdated;
        [JsonProperty("direction")]
        private readonly string direction;
        [JsonProperty("duration")]
        private readonly string duration;
        [JsonProperty("end_time")]
        private readonly DateTime? endTime;
        [JsonProperty("forwarded_from")]
        private readonly string forwardedFrom;
        [JsonProperty("from")]
        private readonly string from;
        [JsonProperty("from_formatted")]
        private readonly string fromFormatted;
        [JsonProperty("group_sid")]
        private readonly string groupSid;
        [JsonProperty("parent_call_sid")]
        private readonly string parentCallSid;
        [JsonProperty("phone_number_sid")]
        private readonly string phoneNumberSid;
        [JsonProperty("price")]
        private readonly decimal? price;
        [JsonProperty("price_unit")]
        private readonly string priceUnit;
        [JsonProperty("sid")]
        private readonly string sid;
        [JsonProperty("start_time")]
        private readonly DateTime? startTime;
        [JsonProperty("status")]
        [JsonConverter(typeof(StringEnumConverter))]
        private readonly CallResource.Status status;
        [JsonProperty("subresource_uris")]
        private readonly Dictionary<string, string> subresourceUris;
        [JsonProperty("to")]
        private readonly string to;
        [JsonProperty("to_formatted")]
        private readonly string toFormatted;
        [JsonProperty("uri")]
        private readonly string uri;
    
        public CallResource() {
        
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
                             string uri) {
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
    
        /**
         * @return The unique id of the Account responsible for creating this Call
         */
        public string GetAccountSid() {
            return this.accountSid;
        }
    
        /**
         * @return The annotation provided for the Call
         */
        public string GetAnnotation() {
            return this.annotation;
        }
    
        /**
         * @return If this call was initiated with answering machine detection, either
         *         `human` or `machine`. Empty otherwise.
         */
        public string GetAnsweredBy() {
            return this.answeredBy;
        }
    
        /**
         * @return The API Version the Call was created through
         */
        public string GetApiVersion() {
            return this.apiVersion;
        }
    
        /**
         * @return If this call was an incoming call to a phone number with Caller ID
         *         Lookup enabled, the caller's name. Empty otherwise.
         */
        public string GetCallerName() {
            return this.callerName;
        }
    
        /**
         * @return The date that this resource was created
         */
        public DateTime? GetDateCreated() {
            return this.dateCreated;
        }
    
        /**
         * @return The date that this resource was last updated
         */
        public DateTime? GetDateUpdated() {
            return this.dateUpdated;
        }
    
        /**
         * @return A string describing the direction of the call. `inbound` for inbound
         *         calls, `outbound-api` for calls initiated via the REST API or
         *         `outbound-dial` for calls initiated by a `<Dial>` verb.
         */
        public string GetDirection() {
            return this.direction;
        }
    
        /**
         * @return The duration
         */
        public string GetDuration() {
            return this.duration;
        }
    
        /**
         * @return The end time of the Call. Null if the call did not complete
         *         successfully.
         */
        public DateTime? GetEndTime() {
            return this.endTime;
        }
    
        /**
         * @return If this Call was an incoming call forwarded from another number, the
         *         forwarding phone number (depends on carrier supporting forwarding).
         *         Empty otherwise.
         */
        public string GetForwardedFrom() {
            return this.forwardedFrom;
        }
    
        /**
         * @return The phone number, SIP address or Client identifier that made this
         *         Call. Phone numbers are in E.164 format (e.g. +16175551212). SIP
         *         addresses are formatted as `name@company.com`. Client identifiers are
         *         formatted `client:name`.
         */
        public string GetFrom() {
            return this.from;
        }
    
        /**
         * @return The phone number, SIP address or Client identifier that made this
         *         Call. Formatted for display.
         */
        public string GetFromFormatted() {
            return this.fromFormatted;
        }
    
        /**
         * @return A 34 character Group Sid associated with this Call. Empty if no
         *         Group is associated with the Call.
         */
        public string GetGroupSid() {
            return this.groupSid;
        }
    
        /**
         * @return A 34 character string that uniquely identifies the Call that created
         *         this leg.
         */
        public string GetParentCallSid() {
            return this.parentCallSid;
        }
    
        /**
         * @return If the call was inbound, this is the Sid of the IncomingPhoneNumber
         *         that received the call. If the call was outbound, it is the Sid of
         *         the OutgoingCallerId from which the call was placed.
         */
        public string GetPhoneNumberSid() {
            return this.phoneNumberSid;
        }
    
        /**
         * @return The charge for this call, in the currency associated with the
         *         account. Populated after the call is completed. May not be
         *         immediately available.
         */
        public decimal? GetPrice() {
            return this.price;
        }
    
        /**
         * @return The currency in which `Price` is measured.
         */
        public string GetPriceUnit() {
            return this.priceUnit;
        }
    
        /**
         * @return A 34 character string that uniquely identifies this resource.
         */
        public override string GetSid() {
            return this.sid;
        }
    
        /**
         * @return The start time of the Call. Null if the call has not yet been dialed.
         */
        public DateTime? GetStartTime() {
            return this.startTime;
        }
    
        /**
         * @return The status
         */
        public CallResource.Status GetStatus() {
            return this.status;
        }
    
        /**
         * @return Call Instance Subresources
         */
        public Dictionary<string, string> GetSubresourceUris() {
            return this.subresourceUris;
        }
    
        /**
         * @return The phone number, SIP address or Client identifier that received
         *         this Call. Phone numbers are in E.164 format (e.g. +16175551212). SIP
         *         addresses are formatted as `name@company.com`. Client identifiers are
         *         formatted `client:name`.
         */
        public string GetTo() {
            return this.to;
        }
    
        /**
         * @return The phone number, SIP address or Client identifier that received
         *         this Call. Formatted for display.
         */
        public string GetToFormatted() {
            return this.toFormatted;
        }
    
        /**
         * @return The URI for this resource, relative to `https://api.twilio.com`
         */
        public string GetUri() {
            return this.uri;
        }
    }
}
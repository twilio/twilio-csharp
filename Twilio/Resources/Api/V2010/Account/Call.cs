using Newtonsoft.Json;
using Newtonsoft.Json.JsonDeserialize;
using System;
using Twilio.Clients.TwilioRestClient;
using Twilio.Creators.Api.V2010.Account;
using Twilio.Deleters.Api.V2010.Account;
using Twilio.Exceptions;
using Twilio.Fetchers.Api.V2010.Account;
using Twilio.Http;
using Twilio.Readers.Api.V2010.Account;
using Twilio.Resources;
using Twilio.Updaters.Api.V2010.Account;
using com.twilio.sdk.converters.MarshalConverter;
using java.math.BigDecimal;
using java.net.URI;
using java.util.Currency;
using org.joda.time.DateTime;

namespace Twilio.Resources.Api.V2010.Account {

    public class Call : SidResource {
        public enum Event {
            INITIATED="initiated",
            RINGING="ringing",
            ANSWERED="answered",
            COMPLETED="completed"
        };
    
        public enum Status {
            QUEUED="queued",
            RINGING="ringing",
            IN_PROGRESS="in-progress",
            COMPLETED="completed",
            BUSY="busy",
            FAILED="failed",
            NO_ANSWER="no-answer",
            CANCELED="canceled"
        };
    
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
        public static CallCreator create(String accountSid, com.twilio.types.PhoneNumber to, com.twilio.types.PhoneNumber from, URI url) {
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
        public static CallCreator create(String accountSid, com.twilio.types.PhoneNumber to, com.twilio.types.PhoneNumber from, String applicationSid) {
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
        public static CallDeleter delete(String accountSid, String sid) {
            return new CallDeleter(accountSid, sid);
        }
    
        /**
         * Fetch the Call specified by the provided Call Sid
         * 
         * @param accountSid The account_sid
         * @param sid Call Sid that uniquely identifies the Call to fetch
         * @return CallFetcher capable of executing the fetch
         */
        public static CallFetcher fetch(String accountSid, String sid) {
            return new CallFetcher(accountSid, sid);
        }
    
        /**
         * Retrieves a collection of Calls made to and from your account
         * 
         * @param accountSid The account_sid
         * @return CallReader capable of executing the read
         */
        public static CallReader read(String accountSid) {
            return new CallReader(accountSid);
        }
    
        /**
         * Initiates a call redirect or terminates a call
         * 
         * @param accountSid The account_sid
         * @param sid Call Sid that uniquely identifies the Call to update
         * @return CallUpdater capable of executing the update
         */
        public static CallUpdater update(String accountSid, String sid) {
            return new CallUpdater(accountSid, sid);
        }
    
        /**
         * Converts a JSON string into a Call object
         * 
         * @param json Raw JSON string
         * @return Call object represented by the provided JSON
         */
        public static Call fromJson(string json) {
            // Convert all checked exceptions to Runtime
            try {
                return JsonConvert.DeserializeObject<Call>(json);
            } catch (JsonException e) {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("account_sid")]
        private readonly String accountSid;
        [JsonProperty("annotation")]
        private readonly String annotation;
        [JsonProperty("answered_by")]
        private readonly String answeredBy;
        [JsonProperty("api_version")]
        private readonly String apiVersion;
        [JsonProperty("caller_name")]
        private readonly String callerName;
        [JsonProperty("date_created")]
        private readonly DateTime dateCreated;
        [JsonProperty("date_updated")]
        private readonly DateTime dateUpdated;
        [JsonProperty("direction")]
        private readonly String direction;
        [JsonProperty("duration")]
        private readonly String duration;
        [JsonProperty("end_time")]
        private readonly DateTime endTime;
        [JsonProperty("forwarded_from")]
        private readonly String forwardedFrom;
        [JsonProperty("from")]
        private readonly String from;
        [JsonProperty("from_formatted")]
        private readonly String fromFormatted;
        [JsonProperty("group_sid")]
        private readonly String groupSid;
        [JsonProperty("parent_call_sid")]
        private readonly String parentCallSid;
        [JsonProperty("phone_number_sid")]
        private readonly String phoneNumberSid;
        [JsonProperty("price")]
        private readonly BigDecimal price;
        [JsonProperty("price_unit")]
        private readonly Currency priceUnit;
        [JsonProperty("sid")]
        private readonly String sid;
        [JsonProperty("start_time")]
        private readonly DateTime startTime;
        [JsonProperty("status")]
        private readonly Call.Status status;
        [JsonProperty("subresource_uris")]
        private readonly Map<String, String> subresourceUris;
        [JsonProperty("to")]
        private readonly String to;
        [JsonProperty("to_formatted")]
        private readonly String toFormatted;
        [JsonProperty("uri")]
        private readonly String uri;
    
        private Call([JsonProperty("account_sid")]
                     String accountSid, 
                     [JsonProperty("annotation")]
                     String annotation, 
                     [JsonProperty("answered_by")]
                     String answeredBy, 
                     [JsonProperty("api_version")]
                     String apiVersion, 
                     [JsonProperty("caller_name")]
                     String callerName, 
                     [JsonProperty("date_created")]
                     String dateCreated, 
                     [JsonProperty("date_updated")]
                     String dateUpdated, 
                     [JsonProperty("direction")]
                     String direction, 
                     [JsonProperty("duration")]
                     String duration, 
                     [JsonProperty("end_time")]
                     String endTime, 
                     [JsonProperty("forwarded_from")]
                     String forwardedFrom, 
                     [JsonProperty("from")]
                     String from, 
                     [JsonProperty("from_formatted")]
                     String fromFormatted, 
                     [JsonProperty("group_sid")]
                     String groupSid, 
                     [JsonProperty("parent_call_sid")]
                     String parentCallSid, 
                     [JsonProperty("phone_number_sid")]
                     String phoneNumberSid, 
                     [JsonProperty("price")]
                     BigDecimal price, 
                     [JsonProperty("price_unit")]
                     [JsonDeserialize(using = com.twilio.sdk.converters.CurrencyDeserializer.class)]
                     Currency priceUnit, 
                     [JsonProperty("sid")]
                     String sid, 
                     [JsonProperty("start_time")]
                     String startTime, 
                     [JsonProperty("status")]
                     Call.Status status, 
                     [JsonProperty("subresource_uris")]
                     Map<String, String> subresourceUris, 
                     [JsonProperty("to")]
                     String to, 
                     [JsonProperty("to_formatted")]
                     String toFormatted, 
                     [JsonProperty("uri")]
                     String uri) {
            this.accountSid = accountSid;
            this.annotation = annotation;
            this.answeredBy = answeredBy;
            this.apiVersion = apiVersion;
            this.callerName = callerName;
            this.dateCreated = MarshalConverter.dateTimeFromString(dateCreated);
            this.dateUpdated = MarshalConverter.dateTimeFromString(dateUpdated);
            this.direction = direction;
            this.duration = duration;
            this.endTime = MarshalConverter.dateTimeFromString(endTime);
            this.forwardedFrom = forwardedFrom;
            this.from = from;
            this.fromFormatted = fromFormatted;
            this.groupSid = groupSid;
            this.parentCallSid = parentCallSid;
            this.phoneNumberSid = phoneNumberSid;
            this.price = price;
            this.priceUnit = priceUnit;
            this.sid = sid;
            this.startTime = MarshalConverter.dateTimeFromString(startTime);
            this.status = status;
            this.subresourceUris = subresourceUris;
            this.to = to;
            this.toFormatted = toFormatted;
            this.uri = uri;
        }
    
        /**
         * @return The unique id of the Account responsible for creating this Call
         */
        public String GetAccountSid() {
            return this.accountSid;
        }
    
        /**
         * @return The annotation provided for the Call
         */
        public String GetAnnotation() {
            return this.annotation;
        }
    
        /**
         * @return If this call was initiated with answering machine detection, either
         *         `human` or `machine`. Empty otherwise.
         */
        public String GetAnsweredBy() {
            return this.answeredBy;
        }
    
        /**
         * @return The API Version the Call was created through
         */
        public String GetApiVersion() {
            return this.apiVersion;
        }
    
        /**
         * @return If this call was an incoming call to a phone number with Caller ID
         *         Lookup enabled, the caller's name. Empty otherwise.
         */
        public String GetCallerName() {
            return this.callerName;
        }
    
        /**
         * @return The date that this resource was created
         */
        public DateTime GetDateCreated() {
            return this.dateCreated;
        }
    
        /**
         * @return The date that this resource was last updated
         */
        public DateTime GetDateUpdated() {
            return this.dateUpdated;
        }
    
        /**
         * @return A string describing the direction of the call. `inbound` for inbound
         *         calls, `outbound-api` for calls initiated via the REST API or
         *         `outbound-dial` for calls initiated by a `<Dial>` verb.
         */
        public String GetDirection() {
            return this.direction;
        }
    
        /**
         * @return The duration
         */
        public String GetDuration() {
            return this.duration;
        }
    
        /**
         * @return The end time of the Call. Null if the call did not complete
         *         successfully.
         */
        public DateTime GetEndTime() {
            return this.endTime;
        }
    
        /**
         * @return If this Call was an incoming call forwarded from another number, the
         *         forwarding phone number (depends on carrier supporting forwarding).
         *         Empty otherwise.
         */
        public String GetForwardedFrom() {
            return this.forwardedFrom;
        }
    
        /**
         * @return The phone number, SIP address or Client identifier that made this
         *         Call. Phone numbers are in E.164 format (e.g. +16175551212). SIP
         *         addresses are formatted as `name@company.com`. Client identifiers are
         *         formatted `client:name`.
         */
        public String GetFrom() {
            return this.from;
        }
    
        /**
         * @return The phone number, SIP address or Client identifier that made this
         *         Call. Formatted for display.
         */
        public String GetFromFormatted() {
            return this.fromFormatted;
        }
    
        /**
         * @return A 34 character Group Sid associated with this Call. Empty if no
         *         Group is associated with the Call.
         */
        public String GetGroupSid() {
            return this.groupSid;
        }
    
        /**
         * @return A 34 character string that uniquely identifies the Call that created
         *         this leg.
         */
        public String GetParentCallSid() {
            return this.parentCallSid;
        }
    
        /**
         * @return If the call was inbound, this is the Sid of the IncomingPhoneNumber
         *         that received the call. If the call was outbound, it is the Sid of
         *         the OutgoingCallerId from which the call was placed.
         */
        public String GetPhoneNumberSid() {
            return this.phoneNumberSid;
        }
    
        /**
         * @return The charge for this call, in the currency associated with the
         *         account. Populated after the call is completed. May not be
         *         immediately available.
         */
        public BigDecimal GetPrice() {
            return this.price;
        }
    
        /**
         * @return The currency in which `Price` is measured.
         */
        public Currency GetPriceUnit() {
            return this.priceUnit;
        }
    
        /**
         * @return A 34 character string that uniquely identifies this resource.
         */
        public String GetSid() {
            return this.sid;
        }
    
        /**
         * @return The start time of the Call. Null if the call has not yet been dialed.
         */
        public DateTime GetStartTime() {
            return this.startTime;
        }
    
        /**
         * @return The status
         */
        public Call.Status GetStatus() {
            return this.status;
        }
    
        /**
         * @return Call Instance Subresources
         */
        public Map<String, String> GetSubresourceUris() {
            return this.subresourceUris;
        }
    
        /**
         * @return The phone number, SIP address or Client identifier that received
         *         this Call. Phone numbers are in E.164 format (e.g. +16175551212). SIP
         *         addresses are formatted as `name@company.com`. Client identifiers are
         *         formatted `client:name`.
         */
        public String GetTo() {
            return this.to;
        }
    
        /**
         * @return The phone number, SIP address or Client identifier that received
         *         this Call. Formatted for display.
         */
        public String GetToFormatted() {
            return this.toFormatted;
        }
    
        /**
         * @return The URI for this resource, relative to `https://api.twilio.com`
         */
        public String GetUri() {
            return this.uri;
        }
    }
}
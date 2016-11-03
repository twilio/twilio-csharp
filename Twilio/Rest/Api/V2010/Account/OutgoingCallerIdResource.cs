using Newtonsoft.Json;
using System;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Api.V2010.Account 
{

    public class OutgoingCallerIdResource : Resource 
    {
        /// <summary>
        /// Fetch an outgoing-caller-id belonging to the account used to make the request
        /// </summary>
        ///
        /// <param name="sid"> Fetch by unique outgoing-caller-id Sid </param>
        /// <returns> OutgoingCallerIdFetcher capable of executing the fetch </returns> 
        public static OutgoingCallerIdFetcher Fetcher(string sid)
        {
            return new OutgoingCallerIdFetcher(sid);
        }
    
        /// <summary>
        /// Updates the caller-id
        /// </summary>
        ///
        /// <param name="sid"> Update by unique outgoing-caller-id Sid </param>
        /// <returns> OutgoingCallerIdUpdater capable of executing the update </returns> 
        public static OutgoingCallerIdUpdater Updater(string sid)
        {
            return new OutgoingCallerIdUpdater(sid);
        }
    
        /// <summary>
        /// Delete the caller-id specified from the account
        /// </summary>
        ///
        /// <param name="sid"> Delete by unique outgoing-caller-id Sid </param>
        /// <returns> OutgoingCallerIdDeleter capable of executing the delete </returns> 
        public static OutgoingCallerIdDeleter Deleter(string sid)
        {
            return new OutgoingCallerIdDeleter(sid);
        }
    
        /// <summary>
        /// Retrieve a list of outgoing-caller-ids belonging to the account used to make the request
        /// </summary>
        ///
        /// <returns> OutgoingCallerIdReader capable of executing the read </returns> 
        public static OutgoingCallerIdReader Reader()
        {
            return new OutgoingCallerIdReader();
        }
    
        /// <summary>
        /// Converts a JSON string into a OutgoingCallerIdResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> OutgoingCallerIdResource object represented by the provided JSON </returns> 
        public static OutgoingCallerIdResource FromJson(string json)
        {
            // Convert all checked exceptions to Runtime
            try
            {
                return JsonConvert.DeserializeObject<OutgoingCallerIdResource>(json);
            }
            catch (JsonException e)
            {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("sid")]
        public string sid { get; set; }
        [JsonProperty("date_created")]
        public DateTime? dateCreated { get; set; }
        [JsonProperty("date_updated")]
        public DateTime? dateUpdated { get; set; }
        [JsonProperty("friendly_name")]
        public string friendlyName { get; set; }
        [JsonProperty("account_sid")]
        public string accountSid { get; set; }
        [JsonProperty("phone_number")]
        [JsonConverter(typeof(PhoneNumberConverter))]
        public Twilio.Types.PhoneNumber phoneNumber { get; set; }
        [JsonProperty("uri")]
        public string uri { get; set; }
    
        public OutgoingCallerIdResource()
        {
        
        }
    
        private OutgoingCallerIdResource([JsonProperty("sid")]
                                         string sid, 
                                         [JsonProperty("date_created")]
                                         string dateCreated, 
                                         [JsonProperty("date_updated")]
                                         string dateUpdated, 
                                         [JsonProperty("friendly_name")]
                                         string friendlyName, 
                                         [JsonProperty("account_sid")]
                                         string accountSid, 
                                         [JsonProperty("phone_number")]
                                         Twilio.Types.PhoneNumber phoneNumber, 
                                         [JsonProperty("uri")]
                                         string uri)
                                         {
            this.sid = sid;
            this.dateCreated = MarshalConverter.DateTimeFromString(dateCreated);
            this.dateUpdated = MarshalConverter.DateTimeFromString(dateUpdated);
            this.friendlyName = friendlyName;
            this.accountSid = accountSid;
            this.phoneNumber = phoneNumber;
            this.uri = uri;
        }
    }
}
using Newtonsoft.Json;
using System;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Types;

namespace Twilio.Rest.Api.V2010.Account.AvailablePhoneNumberCountry {

    public class MobileResource : Resource {
        /// <summary>
        /// read
        /// </summary>
        ///
        /// <param name="accountSid"> The account_sid </param>
        /// <param name="countryCode"> The country_code </param>
        /// <returns> MobileReader capable of executing the read </returns> 
        public static MobileReader Reader(string accountSid, string countryCode) {
            return new MobileReader(accountSid, countryCode);
        }
    
        /// <summary>
        /// Create a MobileReader to execute read.
        /// </summary>
        ///
        /// <param name="countryCode"> The country_code </param>
        /// <returns> MobileReader capable of executing the read </returns> 
        public static MobileReader Reader(string countryCode) {
            return new MobileReader(countryCode);
        }
    
        /// <summary>
        /// Converts a JSON string into a MobileResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> MobileResource object represented by the provided JSON </returns> 
        public static MobileResource FromJson(string json) {
            // Convert all checked exceptions to Runtime
            try {
                return JsonConvert.DeserializeObject<MobileResource>(json);
            } catch (JsonException e) {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("friendly_name")]
        [JsonConverter(typeof(PhoneNumberConverter))]
        public Twilio.Types.PhoneNumber friendlyName { get; }
        [JsonProperty("phone_number")]
        [JsonConverter(typeof(PhoneNumberConverter))]
        public Twilio.Types.PhoneNumber phoneNumber { get; }
        [JsonProperty("lata")]
        public string lata { get; }
        [JsonProperty("rate_center")]
        public string rateCenter { get; }
        [JsonProperty("latitude")]
        public decimal? latitude { get; }
        [JsonProperty("longitude")]
        public decimal? longitude { get; }
        [JsonProperty("region")]
        public string region { get; }
        [JsonProperty("postal_code")]
        public string postalCode { get; }
        [JsonProperty("iso_country")]
        public string isoCountry { get; }
        [JsonProperty("address_requirements")]
        public string addressRequirements { get; }
        [JsonProperty("beta")]
        public bool? beta { get; }
        [JsonProperty("capabilities")]
        public PhoneNumberCapabilities capabilities { get; }
    
        public MobileResource() {
        
        }
    
        private MobileResource([JsonProperty("friendly_name")]
                               Twilio.Types.PhoneNumber friendlyName, 
                               [JsonProperty("phone_number")]
                               Twilio.Types.PhoneNumber phoneNumber, 
                               [JsonProperty("lata")]
                               string lata, 
                               [JsonProperty("rate_center")]
                               string rateCenter, 
                               [JsonProperty("latitude")]
                               decimal? latitude, 
                               [JsonProperty("longitude")]
                               decimal? longitude, 
                               [JsonProperty("region")]
                               string region, 
                               [JsonProperty("postal_code")]
                               string postalCode, 
                               [JsonProperty("iso_country")]
                               string isoCountry, 
                               [JsonProperty("address_requirements")]
                               string addressRequirements, 
                               [JsonProperty("beta")]
                               bool? beta, 
                               [JsonProperty("capabilities")]
                               PhoneNumberCapabilities capabilities) {
            this.friendlyName = friendlyName;
            this.phoneNumber = phoneNumber;
            this.lata = lata;
            this.rateCenter = rateCenter;
            this.latitude = latitude;
            this.longitude = longitude;
            this.region = region;
            this.postalCode = postalCode;
            this.isoCountry = isoCountry;
            this.addressRequirements = addressRequirements;
            this.beta = beta;
            this.capabilities = capabilities;
        }
    }
}
using Newtonsoft.Json;
using System;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Types;

namespace Twilio.Rest.Api.V2010.Account.AvailablePhoneNumberCountry 
{

    public class MobileResource : Resource 
    {
        /// <summary>
        /// read
        /// </summary>
        ///
        /// <param name="countryCode"> The country_code </param>
        /// <returns> MobileReader capable of executing the read </returns> 
        public static MobileReader Reader(string countryCode)
        {
            return new MobileReader(countryCode);
        }
    
        /// <summary>
        /// Converts a JSON string into a MobileResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> MobileResource object represented by the provided JSON </returns> 
        public static MobileResource FromJson(string json)
        {
            // Convert all checked exceptions to Runtime
            try
            {
                return JsonConvert.DeserializeObject<MobileResource>(json);
            }
            catch (JsonException e)
            {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("friendly_name")]
        [JsonConverter(typeof(PhoneNumberConverter))]
        public Twilio.Types.PhoneNumber FriendlyName { get; set; }
        [JsonProperty("phone_number")]
        [JsonConverter(typeof(PhoneNumberConverter))]
        public Twilio.Types.PhoneNumber PhoneNumber { get; set; }
        [JsonProperty("lata")]
        public string Lata { get; set; }
        [JsonProperty("rate_center")]
        public string RateCenter { get; set; }
        [JsonProperty("latitude")]
        public decimal? Latitude { get; set; }
        [JsonProperty("longitude")]
        public decimal? Longitude { get; set; }
        [JsonProperty("region")]
        public string Region { get; set; }
        [JsonProperty("postal_code")]
        public string PostalCode { get; set; }
        [JsonProperty("iso_country")]
        public string IsoCountry { get; set; }
        [JsonProperty("address_requirements")]
        public string AddressRequirements { get; set; }
        [JsonProperty("beta")]
        public bool? Beta { get; set; }
        [JsonProperty("capabilities")]
        public PhoneNumberCapabilities Capabilities { get; set; }
    
        public MobileResource()
        {
        
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
                               PhoneNumberCapabilities capabilities)
                               {
            FriendlyName = friendlyName;
            PhoneNumber = phoneNumber;
            Lata = lata;
            RateCenter = rateCenter;
            Latitude = latitude;
            Longitude = longitude;
            Region = region;
            PostalCode = postalCode;
            IsoCountry = isoCountry;
            AddressRequirements = addressRequirements;
            Beta = beta;
            Capabilities = capabilities;
        }
    }
}
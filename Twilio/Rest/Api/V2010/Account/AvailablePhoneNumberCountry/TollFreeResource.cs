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

    public class TollFreeResource : Resource 
    {
        /// <summary>
        /// read
        /// </summary>
        ///
        /// <param name="countryCode"> The country_code </param>
        /// <param name="accountSid"> The account_sid </param>
        /// <param name="areaCode"> The area_code </param>
        /// <param name="contains"> The contains </param>
        /// <param name="smsEnabled"> The sms_enabled </param>
        /// <param name="mmsEnabled"> The mms_enabled </param>
        /// <param name="voiceEnabled"> The voice_enabled </param>
        /// <param name="excludeAllAddressRequired"> The exclude_all_address_required </param>
        /// <param name="excludeLocalAddressRequired"> The exclude_local_address_required </param>
        /// <param name="excludeForeignAddressRequired"> The exclude_foreign_address_required </param>
        /// <param name="beta"> The beta </param>
        /// <param name="nearNumber"> The near_number </param>
        /// <param name="nearLatLong"> The near_lat_long </param>
        /// <param name="distance"> The distance </param>
        /// <param name="inPostalCode"> The in_postal_code </param>
        /// <param name="inRegion"> The in_region </param>
        /// <param name="inRateCenter"> The in_rate_center </param>
        /// <param name="inLata"> The in_lata </param>
        /// <returns> TollFreeReader capable of executing the read </returns> 
        public static TollFreeReader Reader(string countryCode, string accountSid=null, int? areaCode=null, string contains=null, bool? smsEnabled=null, bool? mmsEnabled=null, bool? voiceEnabled=null, bool? excludeAllAddressRequired=null, bool? excludeLocalAddressRequired=null, bool? excludeForeignAddressRequired=null, bool? beta=null, Twilio.Types.PhoneNumber nearNumber=null, string nearLatLong=null, int? distance=null, string inPostalCode=null, string inRegion=null, string inRateCenter=null, string inLata=null)
        {
            return new TollFreeReader(countryCode, accountSid:accountSid, areaCode:areaCode, contains:contains, smsEnabled:smsEnabled, mmsEnabled:mmsEnabled, voiceEnabled:voiceEnabled, excludeAllAddressRequired:excludeAllAddressRequired, excludeLocalAddressRequired:excludeLocalAddressRequired, excludeForeignAddressRequired:excludeForeignAddressRequired, beta:beta, nearNumber:nearNumber, nearLatLong:nearLatLong, distance:distance, inPostalCode:inPostalCode, inRegion:inRegion, inRateCenter:inRateCenter, inLata:inLata);
        }
    
        /// <summary>
        /// Converts a JSON string into a TollFreeResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> TollFreeResource object represented by the provided JSON </returns> 
        public static TollFreeResource FromJson(string json)
        {
            // Convert all checked exceptions to Runtime
            try
            {
                return JsonConvert.DeserializeObject<TollFreeResource>(json);
            }
            catch (JsonException e)
            {
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
    
        public TollFreeResource()
        {
        
        }
    
        private TollFreeResource([JsonProperty("friendly_name")]
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
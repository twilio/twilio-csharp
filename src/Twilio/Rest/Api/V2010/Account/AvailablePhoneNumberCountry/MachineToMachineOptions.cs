/*
 * This code was generated by
 * ___ _ _ _ _ _    _ ____    ____ ____ _    ____ ____ _  _ ____ ____ ____ ___ __   __
 *  |  | | | | |    | |  | __ |  | |__| | __ | __ |___ |\ | |___ |__/ |__|  | |  | |__/
 *  |  |_|_| | |___ | |__|    |__| |  | |    |__] |___ | \| |___ |  \ |  |  | |__| |  \
 *
 * Twilio - Api
 * This is the public Twilio REST API.
 *
 * NOTE: This class is auto generated by OpenAPI Generator.
 * https://openapi-generator.tech
 * Do not edit the class manually.
 */


using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Converters;




namespace Twilio.Rest.Api.V2010.Account.AvailablePhoneNumberCountry
{
    /// <summary> read </summary>
    public class ReadMachineToMachineOptions : ReadOptions<MachineToMachineResource>
    {
    
        ///<summary> The [ISO-3166-1](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2) country code of the country from which to read phone numbers. </summary> 
        public string PathCountryCode { get; }

        ///<summary> The SID of the [Account](https://www.twilio.com/docs/iam/api/account) requesting the AvailablePhoneNumber resources. </summary> 
        public string PathAccountSid { get; set; }

        ///<summary> The area code of the phone numbers to read. Applies to only phone numbers in the US and Canada. </summary> 
        public int? AreaCode { get; set; }

        ///<summary> The pattern on which to match phone numbers. Valid characters are `*`, `0-9`, `a-z`, and `A-Z`. The `*` character matches any single digit. For examples, see [Example 2](https://www.twilio.com/docs/phone-numbers/api/availablephonenumber-resource#local-get-basic-example-2) and [Example 3](https://www.twilio.com/docs/phone-numbers/api/availablephonenumber-resource#local-get-basic-example-3). If specified, this value must have at least two characters. </summary> 
        public string Contains { get; set; }

        ///<summary> Whether the phone numbers can receive text messages. Can be: `true` or `false`. </summary> 
        public bool? SmsEnabled { get; set; }

        ///<summary> Whether the phone numbers can receive MMS messages. Can be: `true` or `false`. </summary> 
        public bool? MmsEnabled { get; set; }

        ///<summary> Whether the phone numbers can receive calls. Can be: `true` or `false`. </summary> 
        public bool? VoiceEnabled { get; set; }

        ///<summary> Whether to exclude phone numbers that require an [Address](https://www.twilio.com/docs/usage/api/address). Can be: `true` or `false` and the default is `false`. </summary> 
        public bool? ExcludeAllAddressRequired { get; set; }

        ///<summary> Whether to exclude phone numbers that require a local [Address](https://www.twilio.com/docs/usage/api/address). Can be: `true` or `false` and the default is `false`. </summary> 
        public bool? ExcludeLocalAddressRequired { get; set; }

        ///<summary> Whether to exclude phone numbers that require a foreign [Address](https://www.twilio.com/docs/usage/api/address). Can be: `true` or `false` and the default is `false`. </summary> 
        public bool? ExcludeForeignAddressRequired { get; set; }

        ///<summary> Whether to read phone numbers that are new to the Twilio platform. Can be: `true` or `false` and the default is `true`. </summary> 
        public bool? Beta { get; set; }

        ///<summary> Given a phone number, find a geographically close number within `distance` miles. Distance defaults to 25 miles. Applies to only phone numbers in the US and Canada. </summary> 
        public Types.PhoneNumber NearNumber { get; set; }

        ///<summary> Given a latitude/longitude pair `lat,long` find geographically close numbers within `distance` miles. Applies to only phone numbers in the US and Canada. </summary> 
        public string NearLatLong { get; set; }

        ///<summary> The search radius, in miles, for a `near_` query.  Can be up to `500` and the default is `25`. Applies to only phone numbers in the US and Canada. </summary> 
        public int? Distance { get; set; }

        ///<summary> Limit results to a particular postal code. Given a phone number, search within the same postal code as that number. Applies to only phone numbers in the US and Canada. </summary> 
        public string InPostalCode { get; set; }

        ///<summary> Limit results to a particular region, state, or province. Given a phone number, search within the same region as that number. Applies to only phone numbers in the US and Canada. </summary> 
        public string InRegion { get; set; }

        ///<summary> Limit results to a specific rate center, or given a phone number search within the same rate center as that number. Requires `in_lata` to be set as well. Applies to only phone numbers in the US and Canada. </summary> 
        public string InRateCenter { get; set; }

        ///<summary> Limit results to a specific local access and transport area ([LATA](https://en.wikipedia.org/wiki/Local_access_and_transport_area)). Given a phone number, search within the same [LATA](https://en.wikipedia.org/wiki/Local_access_and_transport_area) as that number. Applies to only phone numbers in the US and Canada. </summary> 
        public string InLata { get; set; }

        ///<summary> Limit results to a particular locality or city. Given a phone number, search within the same Locality as that number. </summary> 
        public string InLocality { get; set; }

        ///<summary> Whether the phone numbers can receive faxes. Can be: `true` or `false`. </summary> 
        public bool? FaxEnabled { get; set; }



        /// <summary> Construct a new ListAvailablePhoneNumberMachineToMachineOptions </summary>
        /// <param name="pathCountryCode"> The [ISO-3166-1](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2) country code of the country from which to read phone numbers. </param>
        public ReadMachineToMachineOptions(string pathCountryCode)
        {
            PathCountryCode = pathCountryCode;
        }

        
        /// <summary> Generate the necessary parameters </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            if (AreaCode != null)
            {
                p.Add(new KeyValuePair<string, string>("AreaCode", AreaCode.ToString()));
            }
            if (Contains != null)
            {
                p.Add(new KeyValuePair<string, string>("Contains", Contains));
            }
            if (SmsEnabled != null)
            {
                p.Add(new KeyValuePair<string, string>("SmsEnabled", SmsEnabled.Value.ToString().ToLower()));
            }
            if (MmsEnabled != null)
            {
                p.Add(new KeyValuePair<string, string>("MmsEnabled", MmsEnabled.Value.ToString().ToLower()));
            }
            if (VoiceEnabled != null)
            {
                p.Add(new KeyValuePair<string, string>("VoiceEnabled", VoiceEnabled.Value.ToString().ToLower()));
            }
            if (ExcludeAllAddressRequired != null)
            {
                p.Add(new KeyValuePair<string, string>("ExcludeAllAddressRequired", ExcludeAllAddressRequired.Value.ToString().ToLower()));
            }
            if (ExcludeLocalAddressRequired != null)
            {
                p.Add(new KeyValuePair<string, string>("ExcludeLocalAddressRequired", ExcludeLocalAddressRequired.Value.ToString().ToLower()));
            }
            if (ExcludeForeignAddressRequired != null)
            {
                p.Add(new KeyValuePair<string, string>("ExcludeForeignAddressRequired", ExcludeForeignAddressRequired.Value.ToString().ToLower()));
            }
            if (Beta != null)
            {
                p.Add(new KeyValuePair<string, string>("Beta", Beta.Value.ToString().ToLower()));
            }
            if (NearNumber != null)
            {
                p.Add(new KeyValuePair<string, string>("NearNumber", NearNumber.ToString()));
            }
            if (NearLatLong != null)
            {
                p.Add(new KeyValuePair<string, string>("NearLatLong", NearLatLong));
            }
            if (Distance != null)
            {
                p.Add(new KeyValuePair<string, string>("Distance", Distance.ToString()));
            }
            if (InPostalCode != null)
            {
                p.Add(new KeyValuePair<string, string>("InPostalCode", InPostalCode));
            }
            if (InRegion != null)
            {
                p.Add(new KeyValuePair<string, string>("InRegion", InRegion));
            }
            if (InRateCenter != null)
            {
                p.Add(new KeyValuePair<string, string>("InRateCenter", InRateCenter));
            }
            if (InLata != null)
            {
                p.Add(new KeyValuePair<string, string>("InLata", InLata));
            }
            if (InLocality != null)
            {
                p.Add(new KeyValuePair<string, string>("InLocality", InLocality));
            }
            if (FaxEnabled != null)
            {
                p.Add(new KeyValuePair<string, string>("FaxEnabled", FaxEnabled.Value.ToString().ToLower()));
            }
            if (PageSize != null)
            {
                p.Add(new KeyValuePair<string, string>("PageSize", PageSize.ToString()));
            }
            return p;
        }

    

    }

}


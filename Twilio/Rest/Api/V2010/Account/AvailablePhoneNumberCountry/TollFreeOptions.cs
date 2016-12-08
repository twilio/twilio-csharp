using System;
using System.Collections.Generic;
using Twilio.Base;

namespace Twilio.Rest.Api.V2010.Account.AvailablePhoneNumberCountry 
{

    public class ReadTollFreeOptions : ReadOptions<TollFreeResource> 
    {
        public string AccountSid { get; set; }
        public string CountryCode { get; }
        public int? AreaCode { get; set; }
        public string Contains { get; set; }
        public bool? SmsEnabled { get; set; }
        public bool? MmsEnabled { get; set; }
        public bool? VoiceEnabled { get; set; }
        public bool? ExcludeAllAddressRequired { get; set; }
        public bool? ExcludeLocalAddressRequired { get; set; }
        public bool? ExcludeForeignAddressRequired { get; set; }
        public bool? Beta { get; set; }
        public Types.PhoneNumber NearNumber { get; set; }
        public string NearLatLong { get; set; }
        public int? Distance { get; set; }
        public string InPostalCode { get; set; }
        public string InRegion { get; set; }
        public string InRateCenter { get; set; }
        public string InLata { get; set; }
    
        /// <summary>
        /// Construct a new ReadTollFreeOptions
        /// </summary>
        ///
        /// <param name="countryCode"> The country_code </param>
        public ReadTollFreeOptions(string countryCode)
        {
            CountryCode = countryCode;
        }
    
        /// <summary>
        /// Generate the necessary parameters
        /// </summary>
        public override List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();
            if (AreaCode != null)
            {
                p.Add(new KeyValuePair<string, string>("AreaCode", AreaCode.Value.ToString()));
            }
            
            if (Contains != null)
            {
                p.Add(new KeyValuePair<string, string>("Contains", Contains));
            }
            
            if (SmsEnabled != null)
            {
                p.Add(new KeyValuePair<string, string>("SmsEnabled", SmsEnabled.Value.ToString()));
            }
            
            if (MmsEnabled != null)
            {
                p.Add(new KeyValuePair<string, string>("MmsEnabled", MmsEnabled.Value.ToString()));
            }
            
            if (VoiceEnabled != null)
            {
                p.Add(new KeyValuePair<string, string>("VoiceEnabled", VoiceEnabled.Value.ToString()));
            }
            
            if (ExcludeAllAddressRequired != null)
            {
                p.Add(new KeyValuePair<string, string>("ExcludeAllAddressRequired", ExcludeAllAddressRequired.Value.ToString()));
            }
            
            if (ExcludeLocalAddressRequired != null)
            {
                p.Add(new KeyValuePair<string, string>("ExcludeLocalAddressRequired", ExcludeLocalAddressRequired.Value.ToString()));
            }
            
            if (ExcludeForeignAddressRequired != null)
            {
                p.Add(new KeyValuePair<string, string>("ExcludeForeignAddressRequired", ExcludeForeignAddressRequired.Value.ToString()));
            }
            
            if (Beta != null)
            {
                p.Add(new KeyValuePair<string, string>("Beta", Beta.Value.ToString()));
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
                p.Add(new KeyValuePair<string, string>("Distance", Distance.Value.ToString()));
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
            
            if (PageSize != null)
            {
                p.Add(new KeyValuePair<string, string>("PageSize", PageSize.ToString()));
            }
            
            return p;
        }
    }

}
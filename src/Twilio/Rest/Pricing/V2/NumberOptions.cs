/*
 * This code was generated by
 * ___ _ _ _ _ _    _ ____    ____ ____ _    ____ ____ _  _ ____ ____ ____ ___ __   __
 *  |  | | | | |    | |  | __ |  | |__| | __ | __ |___ |\ | |___ |__/ |__|  | |  | |__/
 *  |  |_|_| | |___ | |__|    |__| |  | |    |__] |___ | \| |___ |  \ |  |  | |__| |  \
 *
 * Twilio - Pricing
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




namespace Twilio.Rest.Pricing.V2
{
    /// <summary> Fetch pricing information for a specific destination and, optionally, origination phone number. </summary>
    public class FetchNumberOptions : IOptions<NumberResource>
    {
    
        ///<summary> The destination phone number, in [E.164](https://www.twilio.com/docs/glossary/what-e164) format, for which to fetch the origin-based voice pricing information. E.164 format consists of a + followed by the country code and subscriber number. </summary> 
        public Types.PhoneNumber PathDestinationNumber { get; }

        ///<summary> The origination phone number, in [E.164](https://www.twilio.com/docs/glossary/what-e164) format, for which to fetch the origin-based voice pricing information. E.164 format consists of a + followed by the country code and subscriber number. </summary> 
        public Types.PhoneNumber OriginationNumber { get; set; }



        /// <summary> Construct a new FetchTrunkingNumberOptions </summary>
        /// <param name="pathDestinationNumber"> The destination phone number, in [E.164](https://www.twilio.com/docs/glossary/what-e164) format, for which to fetch the origin-based voice pricing information. E.164 format consists of a + followed by the country code and subscriber number. </param>

        public FetchNumberOptions(Types.PhoneNumber pathDestinationNumber)
        {
            PathDestinationNumber = pathDestinationNumber;
        }

        
        /// <summary> Generate the necessary parameters </summary>
        public  List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            if (OriginationNumber != null)
            {
                p.Add(new KeyValuePair<string, string>("OriginationNumber", OriginationNumber.ToString()));
            }
            return p;
        }
        

    }


}


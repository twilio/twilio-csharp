/*
 * This code was generated by
 * ___ _ _ _ _ _    _ ____    ____ ____ _    ____ ____ _  _ ____ ____ ____ ___ __   __
 *  |  | | | | |    | |  | __ |  | |__| | __ | __ |___ |\ | |___ |__/ |__|  | |  | |__/
 *  |  |_|_| | |___ | |__|    |__| |  | |    |__] |___ | \| |___ |  \ |  |  | |__| |  \
 *
 * Twilio - Preview
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




namespace Twilio.Rest.Preview.TrustedComms
{
    /// <summary> Retrieve a current call given the originating and terminating number via `X-XCNAM-Sensitive-Phone-Number-From` and `X-XCNAM-Sensitive-Phone-Number-To` headers. </summary>
    public class FetchCurrentCallOptions : IOptions<CurrentCallResource>
    {
    
        ///<summary> The originating Phone Number, given in [E.164 format](https://www.twilio.com/docs/glossary/what-e164). This phone number should be a Twilio number, otherwise it will return an error with HTTP Status Code 400. </summary> 
        public string XXcnamSensitivePhoneNumberFrom { get; set; }

        ///<summary> The terminating Phone Number, given in [E.164 format](https://www.twilio.com/docs/glossary/what-e164). </summary> 
        public string XXcnamSensitivePhoneNumberTo { get; set; }




        
        /// <summary> Generate the necessary parameters </summary>
        public  List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            return p;
        }
        
    /// <summary> Generate the necessary header parameters </summary>
    public List<KeyValuePair<string, string>> GetHeaderParams()
    {
        var p = new List<KeyValuePair<string, string>>();
        if (XXcnamSensitivePhoneNumberFrom != null)
        {
            p.Add(new KeyValuePair<string, string>("X-Xcnam-Sensitive-Phone-Number-From", XXcnamSensitivePhoneNumberFrom));
        }
        if (XXcnamSensitivePhoneNumberTo != null)
        {
            p.Add(new KeyValuePair<string, string>("X-Xcnam-Sensitive-Phone-Number-To", XXcnamSensitivePhoneNumberTo));
        }
        return p;
    }

    }


}


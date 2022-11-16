/*
 * This code was generated by
 * ___ _ _ _ _ _    _ ____    ____ ____ _    ____ ____ _  _ ____ ____ ____ ___ __   __
 *  |  | | | | |    | |  | __ |  | |__| | __ | __ |___ |\ | |___ |__/ |__|  | |  | |__/
 *  |  |_|_| | |___ | |__|    |__| |  | |    |__] |___ | \| |___ |  \ |  |  | |__| |  \
 *
 * Twilio - Routes
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




namespace Twilio.Rest.Routes.V2
{
    /// <summary> Fetch the Inbound Processing Region assigned to a phone number. </summary>
    public class FetchPhoneNumberOptions : IOptions<PhoneNumberResource>
    {
    
        ///<summary> The phone number in E.164 format </summary> 
        public string PathPhoneNumber { get; }



        /// <summary> Construct a new FetchPhoneNumberOptions </summary>
        /// <param name="pathPhoneNumber"> The phone number in E.164 format </param>

        public FetchPhoneNumberOptions(string pathPhoneNumber)
        {
            PathPhoneNumber = pathPhoneNumber;
        }

        
        /// <summary> Generate the necessary parameters </summary>
        public  List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            return p;
        }
        

    }


    /// <summary> Assign an Inbound Processing Region to a phone number. </summary>
    public class UpdatePhoneNumberOptions : IOptions<PhoneNumberResource>
    {
    
        ///<summary> The phone number in E.164 format </summary> 
        public string PathPhoneNumber { get; }

        ///<summary> The Inbound Processing Region used for this phone number for voice </summary> 
        public string VoiceRegion { get; set; }

        ///<summary> A human readable description of this resource, up to 64 characters. </summary> 
        public string FriendlyName { get; set; }



        /// <summary> Construct a new UpdatePhoneNumberOptions </summary>
        /// <param name="pathPhoneNumber"> The phone number in E.164 format </param>

        public UpdatePhoneNumberOptions(string pathPhoneNumber)
        {
            PathPhoneNumber = pathPhoneNumber;
        }

        
        /// <summary> Generate the necessary parameters </summary>
        public  List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            if (VoiceRegion != null)
            {
                p.Add(new KeyValuePair<string, string>("VoiceRegion", VoiceRegion));
            }
            if (FriendlyName != null)
            {
                p.Add(new KeyValuePair<string, string>("FriendlyName", FriendlyName));
            }
            return p;
        }
        

    }


}


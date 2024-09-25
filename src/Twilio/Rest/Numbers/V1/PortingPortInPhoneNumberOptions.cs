/*
 * This code was generated by
 * ___ _ _ _ _ _    _ ____    ____ ____ _    ____ ____ _  _ ____ ____ ____ ___ __   __
 *  |  | | | | |    | |  | __ |  | |__| | __ | __ |___ |\ | |___ |__/ |__|  | |  | |__/
 *  |  |_|_| | |___ | |__|    |__| |  | |    |__] |___ | \| |___ |  \ |  |  | |__| |  \
 *
 * Twilio - Numbers
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




namespace Twilio.Rest.Numbers.V1
{
    /// <summary> Allows to cancel a port in request phone number by SID </summary>
    public class DeletePortingPortInPhoneNumberOptions : IOptions<PortingPortInPhoneNumberResource>
    {
        
        ///<summary> The SID of the Port In request. This is a unique identifier of the port in request. </summary> 
        public string PathPortInRequestSid { get; }

        ///<summary> The SID of the Port In request phone number. This is a unique identifier of the phone number. </summary> 
        public string PathPhoneNumberSid { get; }



        /// <summary> Construct a new DeletePortingPortInPhoneNumberOptions </summary>
        /// <param name="pathPortInRequestSid"> The SID of the Port In request. This is a unique identifier of the port in request. </param>
        /// <param name="pathPhoneNumberSid"> The SID of the Port In request phone number. This is a unique identifier of the phone number. </param>
        public DeletePortingPortInPhoneNumberOptions(string pathPortInRequestSid, string pathPhoneNumberSid)
        {
            PathPortInRequestSid = pathPortInRequestSid;
            PathPhoneNumberSid = pathPhoneNumberSid;
        }

        
        /// <summary> Generate the necessary parameters </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            return p;
        }

    

    }


    /// <summary> Fetch a phone number by port in request SID and phone number SID </summary>
    public class FetchPortingPortInPhoneNumberOptions : IOptions<PortingPortInPhoneNumberResource>
    {
    
        ///<summary> The SID of the Port In request. This is a unique identifier of the port in request. </summary> 
        public string PathPortInRequestSid { get; }

        ///<summary> The SID of the Phone number. This is a unique identifier of the phone number. </summary> 
        public string PathPhoneNumberSid { get; }



        /// <summary> Construct a new FetchPortingPortInPhoneNumberOptions </summary>
        /// <param name="pathPortInRequestSid"> The SID of the Port In request. This is a unique identifier of the port in request. </param>
        /// <param name="pathPhoneNumberSid"> The SID of the Phone number. This is a unique identifier of the phone number. </param>
        public FetchPortingPortInPhoneNumberOptions(string pathPortInRequestSid, string pathPhoneNumberSid)
        {
            PathPortInRequestSid = pathPortInRequestSid;
            PathPhoneNumberSid = pathPhoneNumberSid;
        }

        
        /// <summary> Generate the necessary parameters </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            return p;
        }

    

    }


}


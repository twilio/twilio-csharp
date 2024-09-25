/*
 * This code was generated by
 * ___ _ _ _ _ _    _ ____    ____ ____ _    ____ ____ _  _ ____ ____ ____ ___ __   __
 *  |  | | | | |    | |  | __ |  | |__| | __ | __ |___ |\ | |___ |__/ |__|  | |  | |__/
 *  |  |_|_| | |___ | |__|    |__| |  | |    |__] |___ | \| |___ |  \ |  |  | |__| |  \
 *
 * Twilio - Supersim
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




namespace Twilio.Rest.Supersim.V1.Sim
{
    /// <summary> Retrieve a list of IP Addresses for the given Super SIM. </summary>
    public class ReadSimIpAddressOptions : ReadOptions<SimIpAddressResource>
    {
    
        ///<summary> The SID of the Super SIM to list IP Addresses for. </summary> 
        public string PathSimSid { get; }



        /// <summary> Construct a new ListSimIpAddressOptions </summary>
        /// <param name="pathSimSid"> The SID of the Super SIM to list IP Addresses for. </param>
        public ReadSimIpAddressOptions(string pathSimSid)
        {
            PathSimSid = pathSimSid;
        }

        
        /// <summary> Generate the necessary parameters </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            if (PageSize != null)
            {
                p.Add(new KeyValuePair<string, string>("PageSize", PageSize.ToString()));
            }
            return p;
        }

    

    }

}


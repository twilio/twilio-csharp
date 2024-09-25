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




namespace Twilio.Rest.Supersim.V1
{
    /// <summary> Fetch a Network resource. </summary>
    public class FetchNetworkOptions : IOptions<NetworkResource>
    {
    
        ///<summary> The SID of the Network resource to fetch. </summary> 
        public string PathSid { get; }



        /// <summary> Construct a new FetchNetworkOptions </summary>
        /// <param name="pathSid"> The SID of the Network resource to fetch. </param>
        public FetchNetworkOptions(string pathSid)
        {
            PathSid = pathSid;
        }

        
        /// <summary> Generate the necessary parameters </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            return p;
        }

    

    }


    /// <summary> Retrieve a list of Network resources. </summary>
    public class ReadNetworkOptions : ReadOptions<NetworkResource>
    {
    
        ///<summary> The [ISO country code](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2) of the Network resources to read. </summary> 
        public string IsoCountry { get; set; }

        ///<summary> The 'mobile country code' of a country. Network resources with this `mcc` in their `identifiers` will be read. </summary> 
        public string Mcc { get; set; }

        ///<summary> The 'mobile network code' of a mobile operator network. Network resources with this `mnc` in their `identifiers` will be read. </summary> 
        public string Mnc { get; set; }




        
        /// <summary> Generate the necessary parameters </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            if (IsoCountry != null)
            {
                p.Add(new KeyValuePair<string, string>("IsoCountry", IsoCountry));
            }
            if (Mcc != null)
            {
                p.Add(new KeyValuePair<string, string>("Mcc", Mcc));
            }
            if (Mnc != null)
            {
                p.Add(new KeyValuePair<string, string>("Mnc", Mnc));
            }
            if (PageSize != null)
            {
                p.Add(new KeyValuePair<string, string>("PageSize", PageSize.ToString()));
            }
            return p;
        }

    

    }

}


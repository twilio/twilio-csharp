/*
 * This code was generated by
 * ___ _ _ _ _ _    _ ____    ____ ____ _    ____ ____ _  _ ____ ____ ____ ___ __   __
 *  |  | | | | |    | |  | __ |  | |__| | __ | __ |___ |\ | |___ |__/ |__|  | |  | |__/
 *  |  |_|_| | |___ | |__|    |__| |  | |    |__] |___ | \| |___ |  \ |  |  | |__| |  \
 *
 * Twilio - Flex
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




namespace Twilio.Rest.FlexApi.V2
{
    /// <summary> Fetch flex user for the given flex user sid </summary>
    public class FetchFlexUserOptions : IOptions<FlexUserResource>
    {
    
        ///<summary> The unique ID created by Twilio to identify a Flex instance. </summary> 
        public string PathInstanceSid { get; }

        ///<summary> The unique id for the flex user to be retrieved. </summary> 
        public string PathFlexUserSid { get; }



        /// <summary> Construct a new FetchFlexUserOptions </summary>
        /// <param name="pathInstanceSid"> The unique ID created by Twilio to identify a Flex instance. </param>
        /// <param name="pathFlexUserSid"> The unique id for the flex user to be retrieved. </param>
        public FetchFlexUserOptions(string pathInstanceSid, string pathFlexUserSid)
        {
            PathInstanceSid = pathInstanceSid;
            PathFlexUserSid = pathFlexUserSid;
        }

        
        /// <summary> Generate the necessary parameters </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            return p;
        }

        

    }


}


/*
 * This code was generated by
 * ___ _ _ _ _ _    _ ____    ____ ____ _    ____ ____ _  _ ____ ____ ____ ___ __   __
 *  |  | | | | |    | |  | __ |  | |__| | __ | __ |___ |\ | |___ |__/ |__|  | |  | |__/
 *  |  |_|_| | |___ | |__|    |__| |  | |    |__] |___ | \| |___ |  \ |  |  | |__| |  \
 *
 * Twilio - Messaging
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




namespace Twilio.Rest.Messaging.V1
{
    /// <summary> fetch </summary>
    public class FetchDomainConfigMessagingServiceOptions : IOptions<DomainConfigMessagingServiceResource>
    {
    
        ///<summary> Unique string used to identify the Messaging service that this domain should be associated with. </summary> 
        public string PathMessagingServiceSid { get; }



        /// <summary> Construct a new FetchDomainConfigMessagingServiceOptions </summary>
        /// <param name="pathMessagingServiceSid"> Unique string used to identify the Messaging service that this domain should be associated with. </param>
        public FetchDomainConfigMessagingServiceOptions(string pathMessagingServiceSid)
        {
            PathMessagingServiceSid = pathMessagingServiceSid;
        }

        
        /// <summary> Generate the necessary parameters </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            return p;
        }

    

    }


}


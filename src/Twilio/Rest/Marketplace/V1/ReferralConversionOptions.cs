/*
 * This code was generated by
 * ___ _ _ _ _ _    _ ____    ____ ____ _    ____ ____ _  _ ____ ____ ____ ___ __   __
 *  |  | | | | |    | |  | __ |  | |__| | __ | __ |___ |\ | |___ |__/ |__|  | |  | |__/
 *  |  |_|_| | |___ | |__|    |__| |  | |    |__] |___ | \| |___ |  \ |  |  | |__| |  \
 *
 * Twilio - Marketplace
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




namespace Twilio.Rest.Marketplace.V1
{

    /// <summary> create </summary>
    public class CreateReferralConversionOptions : IOptions<ReferralConversionResource>
    {
        
        
        public ReferralConversionResource.CreateReferralConversionRequest CreateReferralConversionRequest { get; }


        /// <summary> Construct a new CreateReferralConversionOptions </summary>
        /// <param name="createReferralConversionRequest">  </param>
        public CreateReferralConversionOptions(ReferralConversionResource.CreateReferralConversionRequest createReferralConversionRequest)
        {
            CreateReferralConversionRequest = createReferralConversionRequest;
        }

        
        /// <summary> Generate the request body </summary>
        public string GetBody()
        {
            string body = "";

            if (CreateReferralConversionRequest != null)
            {
                body = ReferralConversionResource.ToJson(CreateReferralConversionRequest);
            }
            return body;
        }
        

    }
}


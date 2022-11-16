/*
 * This code was generated by
 * ___ _ _ _ _ _    _ ____    ____ ____ _    ____ ____ _  _ ____ ____ ____ ___ __   __
 *  |  | | | | |    | |  | __ |  | |__| | __ | __ |___ |\ | |___ |__/ |__|  | |  | |__/
 *  |  |_|_| | |___ | |__|    |__| |  | |    |__] |___ | \| |___ |  \ |  |  | |__| |  \
 *
 * Twilio - Verify
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




namespace Twilio.Rest.Verify.V2
{
    /// <summary> Fetch a specific verification attempt. </summary>
    public class FetchVerificationAttemptOptions : IOptions<VerificationAttemptResource>
    {
    
        ///<summary> The unique SID identifier of a Verification Attempt </summary> 
        public string PathSid { get; }



        /// <summary> Construct a new FetchVerificationAttemptOptions </summary>
        /// <param name="pathSid"> The unique SID identifier of a Verification Attempt </param>

        public FetchVerificationAttemptOptions(string pathSid)
        {
            PathSid = pathSid;
        }

        
        /// <summary> Generate the necessary parameters </summary>
        public  List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            return p;
        }
        

    }


    /// <summary> List all the verification attempts for a given Account. </summary>
    public class ReadVerificationAttemptOptions : ReadOptions<VerificationAttemptResource>
    {
    
        ///<summary> Datetime filter used to query Verification Attempts created after this datetime. Given as GMT in RFC 2822 format. </summary> 
        public DateTime? DateCreatedAfter { get; set; }

        ///<summary> Datetime filter used to query Verification Attempts created before this datetime. Given as GMT in RFC 2822 format. </summary> 
        public DateTime? DateCreatedBefore { get; set; }

        ///<summary> Destination of a verification. It is phone number in E.164 format. </summary> 
        public string ChannelDataTo { get; set; }

        ///<summary> Filter used to query Verification Attempts sent to the specified destination country. </summary> 
        public string Country { get; set; }

        ///<summary> Filter used to query Verification Attempts by communication channel. Valid values are `SMS` and `CALL` </summary> 
        public VerificationAttemptResource.ChannelsEnum Channel { get; set; }

        ///<summary> Filter used to query Verification Attempts by verify service. Only attempts of the provided SID will be returned. </summary> 
        public string VerifyServiceSid { get; set; }

        ///<summary> Filter used to return all the Verification Attempts of a single verification. Only attempts of the provided verification SID will be returned. </summary> 
        public string VerificationSid { get; set; }

        ///<summary> Filter used to query Verification Attempts by conversion status. Valid values are `UNCONVERTED`, for attempts that were not converted, and `CONVERTED`, for attempts that were confirmed. </summary> 
        public VerificationAttemptResource.ConversionStatusEnum Status { get; set; }




        
        /// <summary> Generate the necessary parameters </summary>
        public  override List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            if (DateCreatedAfter != null)
            {
                p.Add(new KeyValuePair<string, string>("DateCreatedAfter", Serializers.DateTimeIso8601(DateCreatedAfter)));
            }
            if (DateCreatedBefore != null)
            {
                p.Add(new KeyValuePair<string, string>("DateCreatedBefore", Serializers.DateTimeIso8601(DateCreatedBefore)));
            }
            if (ChannelDataTo != null)
            {
                p.Add(new KeyValuePair<string, string>("ChannelDataTo", ChannelDataTo));
            }
            if (Country != null)
            {
                p.Add(new KeyValuePair<string, string>("Country", Country.ToString()));
            }
            if (Channel != null)
            {
                p.Add(new KeyValuePair<string, string>("Channel", Channel.ToString()));
            }
            if (VerifyServiceSid != null)
            {
                p.Add(new KeyValuePair<string, string>("VerifyServiceSid", VerifyServiceSid));
            }
            if (VerificationSid != null)
            {
                p.Add(new KeyValuePair<string, string>("VerificationSid", VerificationSid));
            }
            if (Status != null)
            {
                p.Add(new KeyValuePair<string, string>("Status", Status.ToString()));
            }
            if (PageSize != null)
            {
                p.Add(new KeyValuePair<string, string>("PageSize", PageSize.ToString()));
            }
            return p;
        }
        

    }

}


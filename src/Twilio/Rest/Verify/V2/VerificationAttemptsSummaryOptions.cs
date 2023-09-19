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
    /// <summary> Get a summary of how many attempts were made and how many were converted. </summary>
    public class FetchVerificationAttemptsSummaryOptions : IOptions<VerificationAttemptsSummaryResource>
    {
    
        ///<summary> Filter used to consider only Verification Attempts of the given verify service on the summary aggregation. </summary> 
        public string VerifyServiceSid { get; set; }

        ///<summary> Datetime filter used to consider only Verification Attempts created after this datetime on the summary aggregation. Given as GMT in ISO 8601 formatted datetime string: yyyy-MM-dd'T'HH:mm:ss'Z. </summary> 
        public DateTime? DateCreatedAfter { get; set; }

        ///<summary> Datetime filter used to consider only Verification Attempts created before this datetime on the summary aggregation. Given as GMT in ISO 8601 formatted datetime string: yyyy-MM-dd'T'HH:mm:ss'Z. </summary> 
        public DateTime? DateCreatedBefore { get; set; }

        ///<summary> Filter used to consider only Verification Attempts sent to the specified destination country on the summary aggregation. </summary> 
        public string Country { get; set; }

        ///<summary> Filter Verification Attempts considered on the summary aggregation by communication channel. Valid values are `SMS`, `CALL` and `WHATSAPP` </summary> 
        public VerificationAttemptsSummaryResource.ChannelsEnum Channel { get; set; }

        ///<summary> Filter the Verification Attempts considered on the summary aggregation by Destination prefix. It is the prefix of a phone number in E.164 format. </summary> 
        public string DestinationPrefix { get; set; }




        
        /// <summary> Generate the necessary parameters </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            if (VerifyServiceSid != null)
            {
                p.Add(new KeyValuePair<string, string>("VerifyServiceSid", VerifyServiceSid));
            }
            if (DateCreatedAfter != null)
            {
                p.Add(new KeyValuePair<string, string>("DateCreatedAfter", Serializers.DateTimeIso8601(DateCreatedAfter)));
            }
            if (DateCreatedBefore != null)
            {
                p.Add(new KeyValuePair<string, string>("DateCreatedBefore", Serializers.DateTimeIso8601(DateCreatedBefore)));
            }
            if (Country != null)
            {
                p.Add(new KeyValuePair<string, string>("Country", Country.ToString()));
            }
            if (Channel != null)
            {
                p.Add(new KeyValuePair<string, string>("Channel", Channel.ToString()));
            }
            if (DestinationPrefix != null)
            {
                p.Add(new KeyValuePair<string, string>("DestinationPrefix", DestinationPrefix));
            }
            return p;
        }
        

    }


}


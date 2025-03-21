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




namespace Twilio.Rest.Numbers.V2.AuthorizationDocument
{
    /// <summary> Retrieve a list of dependent HostedNumberOrders belonging to the AuthorizationDocument. </summary>
    public class ReadDependentHostedNumberOrderOptions : ReadOptions<DependentHostedNumberOrderResource>
    {
    
        ///<summary> A 34 character string that uniquely identifies the LOA document associated with this HostedNumberOrder. </summary> 
        public string PathSigningDocumentSid { get; }

        ///<summary> Status of an instance resource. It can hold one of the values: 1. opened 2. signing, 3. signed LOA, 4. canceled, 5. failed. See the section entitled [Status Values](https://www.twilio.com/docs/phone-numbers/hosted-numbers/hosted-numbers-api/authorization-document-resource#status-values) for more information on each of these statuses. </summary> 
        public DependentHostedNumberOrderResource.StatusEnum Status { get; set; }

        ///<summary> An E164 formatted phone number hosted by this HostedNumberOrder. </summary> 
        public Types.PhoneNumber PhoneNumber { get; set; }

        ///<summary> A 34 character string that uniquely identifies the IncomingPhoneNumber resource created by this HostedNumberOrder. </summary> 
        public string IncomingPhoneNumberSid { get; set; }

        ///<summary> A human readable description of this resource, up to 128 characters. </summary> 
        public string FriendlyName { get; set; }



        /// <summary> Construct a new ListDependentHostedNumberOrderOptions </summary>
        /// <param name="pathSigningDocumentSid"> A 34 character string that uniquely identifies the LOA document associated with this HostedNumberOrder. </param>
        public ReadDependentHostedNumberOrderOptions(string pathSigningDocumentSid)
        {
            PathSigningDocumentSid = pathSigningDocumentSid;
        }

        
        /// <summary> Generate the necessary parameters </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            if (Status != null)
            {
                p.Add(new KeyValuePair<string, string>("Status", Status.ToString()));
            }
            if (PhoneNumber != null)
            {
                p.Add(new KeyValuePair<string, string>("PhoneNumber", PhoneNumber.ToString()));
            }
            if (IncomingPhoneNumberSid != null)
            {
                p.Add(new KeyValuePair<string, string>("IncomingPhoneNumberSid", IncomingPhoneNumberSid));
            }
            if (FriendlyName != null)
            {
                p.Add(new KeyValuePair<string, string>("FriendlyName", FriendlyName));
            }
            if (PageSize != null)
            {
                p.Add(new KeyValuePair<string, string>("PageSize", PageSize.ToString()));
            }
            return p;
        }

    

    }

}


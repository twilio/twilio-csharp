/*
 * This code was generated by
 * ___ _ _ _ _ _    _ ____    ____ ____ _    ____ ____ _  _ ____ ____ ____ ___ __   __
 *  |  | | | | |    | |  | __ |  | |__| | __ | __ |___ |\ | |___ |__/ |__|  | |  | |__/
 *  |  |_|_| | |___ | |__|    |__| |  | |    |__] |___ | \| |___ |  \ |  |  | |__| |  \
 *
 * Twilio - Lookups
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




namespace Twilio.Rest.Lookups.V2
{
    /// <summary> fetch </summary>
    public class FetchPhoneNumberOptions : IOptions<PhoneNumberResource>
    {
    
        ///<summary> The phone number to lookup in E.164 or national format. Default country code is +1 (North America). </summary> 
        public string PathPhoneNumber { get; }

        ///<summary> A comma-separated list of fields to return. Possible values are validation, caller_name, sim_swap, call_forwarding, line_status, line_type_intelligence, identity_match, reassigned_number, sms_pumping_risk, phone_number_quality_score, pre_fill. </summary> 
        public string Fields { get; set; }

        ///<summary> The [country code](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2) used if the phone number provided is in national format. </summary> 
        public string CountryCode { get; set; }

        ///<summary> User’s first name. This query parameter is only used (optionally) for identity_match package requests. </summary> 
        public string FirstName { get; set; }

        ///<summary> User’s last name. This query parameter is only used (optionally) for identity_match package requests. </summary> 
        public string LastName { get; set; }

        ///<summary> User’s first address line. This query parameter is only used (optionally) for identity_match package requests. </summary> 
        public string AddressLine1 { get; set; }

        ///<summary> User’s second address line. This query parameter is only used (optionally) for identity_match package requests. </summary> 
        public string AddressLine2 { get; set; }

        ///<summary> User’s city. This query parameter is only used (optionally) for identity_match package requests. </summary> 
        public string City { get; set; }

        ///<summary> User’s country subdivision, such as state, province, or locality. This query parameter is only used (optionally) for identity_match package requests. </summary> 
        public string State { get; set; }

        ///<summary> User’s postal zip code. This query parameter is only used (optionally) for identity_match package requests. </summary> 
        public string PostalCode { get; set; }

        ///<summary> User’s country, up to two characters. This query parameter is only used (optionally) for identity_match package requests. </summary> 
        public string AddressCountryCode { get; set; }

        ///<summary> User’s national ID, such as SSN or Passport ID. This query parameter is only used (optionally) for identity_match package requests. </summary> 
        public string NationalId { get; set; }

        ///<summary> User’s date of birth, in YYYYMMDD format. This query parameter is only used (optionally) for identity_match package requests. </summary> 
        public string DateOfBirth { get; set; }

        ///<summary> The date you obtained consent to call or text the end-user of the phone number or a date on which you are reasonably certain that the end-user could still be reached at that number. This query parameter is only used (optionally) for reassigned_number package requests. </summary> 
        public string LastVerifiedDate { get; set; }

        ///<summary> The unique identifier associated with a verification process through verify API. This query parameter is only used (optionally) for pre_fill package requests. </summary> 
        public string VerificationSid { get; set; }

        ///<summary> The optional partnerSubId parameter to provide context for your sub-accounts, tenantIDs, sender IDs or other segmentation, enhancing the accuracy of the risk analysis. </summary> 
        public string PartnerSubId { get; set; }



        /// <summary> Construct a new FetchPhoneNumberOptions </summary>
        /// <param name="pathPhoneNumber"> The phone number to lookup in E.164 or national format. Default country code is +1 (North America). </param>
        public FetchPhoneNumberOptions(string pathPhoneNumber)
        {
            PathPhoneNumber = pathPhoneNumber;
        }

        
        /// <summary> Generate the necessary parameters </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            if (Fields != null)
            {
                p.Add(new KeyValuePair<string, string>("Fields", Fields));
            }
            if (CountryCode != null)
            {
                p.Add(new KeyValuePair<string, string>("CountryCode", CountryCode));
            }
            if (FirstName != null)
            {
                p.Add(new KeyValuePair<string, string>("FirstName", FirstName));
            }
            if (LastName != null)
            {
                p.Add(new KeyValuePair<string, string>("LastName", LastName));
            }
            if (AddressLine1 != null)
            {
                p.Add(new KeyValuePair<string, string>("AddressLine1", AddressLine1));
            }
            if (AddressLine2 != null)
            {
                p.Add(new KeyValuePair<string, string>("AddressLine2", AddressLine2));
            }
            if (City != null)
            {
                p.Add(new KeyValuePair<string, string>("City", City));
            }
            if (State != null)
            {
                p.Add(new KeyValuePair<string, string>("State", State));
            }
            if (PostalCode != null)
            {
                p.Add(new KeyValuePair<string, string>("PostalCode", PostalCode));
            }
            if (AddressCountryCode != null)
            {
                p.Add(new KeyValuePair<string, string>("AddressCountryCode", AddressCountryCode.ToString()));
            }
            if (NationalId != null)
            {
                p.Add(new KeyValuePair<string, string>("NationalId", NationalId));
            }
            if (DateOfBirth != null)
            {
                p.Add(new KeyValuePair<string, string>("DateOfBirth", DateOfBirth));
            }
            if (LastVerifiedDate != null)
            {
                p.Add(new KeyValuePair<string, string>("LastVerifiedDate", LastVerifiedDate));
            }
            if (VerificationSid != null)
            {
                p.Add(new KeyValuePair<string, string>("VerificationSid", VerificationSid));
            }
            if (PartnerSubId != null)
            {
                p.Add(new KeyValuePair<string, string>("PartnerSubId", PartnerSubId));
            }
            return p;
        }

    

    }


}


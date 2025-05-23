/*
 * This code was generated by
 * ___ _ _ _ _ _    _ ____    ____ ____ _    ____ ____ _  _ ____ ____ ____ ___ __   __
 *  |  | | | | |    | |  | __ |  | |__| | __ | __ |___ |\ | |___ |__/ |__|  | |  | |__/
 *  |  |_|_| | |___ | |__|    |__| |  | |    |__] |___ | \| |___ |  \ |  |  | |__| |  \
 *
 * Twilio - Preview
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
using System.Linq;



namespace Twilio.Rest.Preview.HostedNumbers
{

    /// <summary> Host a phone number's capability on Twilio's platform. </summary>
    public class CreateHostedNumberOrderOptions : IOptions<HostedNumberOrderResource>
    {
        
        ///<summary> The number to host in [+E.164](https://en.wikipedia.org/wiki/E.164) format </summary> 
        public Types.PhoneNumber PhoneNumber { get; }

        ///<summary> Used to specify that the SMS capability will be hosted on Twilio's platform. </summary> 
        public bool? SmsCapability { get; }

        ///<summary> This defaults to the AccountSid of the authorization the user is using. This can be provided to specify a subaccount to add the HostedNumberOrder to. </summary> 
        public string AccountSid { get; set; }

        ///<summary> A 64 character string that is a human readable text that describes this resource. </summary> 
        public string FriendlyName { get; set; }

        ///<summary> Optional. Provides a unique and addressable name to be assigned to this HostedNumberOrder, assigned by the developer, to be optionally used in addition to SID. </summary> 
        public string UniqueName { get; set; }

        ///<summary> Optional. A list of emails that the LOA document for this HostedNumberOrder will be carbon copied to. </summary> 
        public List<string> CcEmails { get; set; }

        ///<summary> The URL that Twilio should request when somebody sends an SMS to the phone number. This will be copied onto the IncomingPhoneNumber resource. </summary> 
        public Uri SmsUrl { get; set; }

        ///<summary> The HTTP method that should be used to request the SmsUrl. Must be either `GET` or `POST`.  This will be copied onto the IncomingPhoneNumber resource. </summary> 
        public Twilio.Http.HttpMethod SmsMethod { get; set; }

        ///<summary> A URL that Twilio will request if an error occurs requesting or executing the TwiML defined by SmsUrl. This will be copied onto the IncomingPhoneNumber resource. </summary> 
        public Uri SmsFallbackUrl { get; set; }

        ///<summary> The HTTP method that should be used to request the SmsFallbackUrl. Must be either `GET` or `POST`. This will be copied onto the IncomingPhoneNumber resource. </summary> 
        public Twilio.Http.HttpMethod SmsFallbackMethod { get; set; }

        ///<summary> Optional. The Status Callback URL attached to the IncomingPhoneNumber resource. </summary> 
        public Uri StatusCallbackUrl { get; set; }

        ///<summary> Optional. The Status Callback Method attached to the IncomingPhoneNumber resource. </summary> 
        public Twilio.Http.HttpMethod StatusCallbackMethod { get; set; }

        ///<summary> Optional. The 34 character sid of the application Twilio should use to handle SMS messages sent to this number. If a `SmsApplicationSid` is present, Twilio will ignore all of the SMS urls above and use those set on the application. </summary> 
        public string SmsApplicationSid { get; set; }

        ///<summary> Optional. A 34 character string that uniquely identifies the Address resource that represents the address of the owner of this phone number. </summary> 
        public string AddressSid { get; set; }

        ///<summary> Optional. Email of the owner of this phone number that is being hosted. </summary> 
        public string Email { get; set; }

        
        public HostedNumberOrderResource.VerificationTypeEnum VerificationType { get; set; }

        ///<summary> Optional. The unique sid identifier of the Identity Document that represents the document for verifying ownership of the number to be hosted. Required when VerificationType is phone-bill. </summary> 
        public string VerificationDocumentSid { get; set; }


        /// <summary> Construct a new CreateHostedNumbersHostedNumberOrderOptions </summary>
        /// <param name="phoneNumber"> The number to host in [+E.164](https://en.wikipedia.org/wiki/E.164) format </param>
        /// <param name="smsCapability"> Used to specify that the SMS capability will be hosted on Twilio's platform. </param>
        public CreateHostedNumberOrderOptions(Types.PhoneNumber phoneNumber, bool? smsCapability)
        {
            PhoneNumber = phoneNumber;
            SmsCapability = smsCapability;
            CcEmails = new List<string>();
        }

        
        /// <summary> Generate the necessary parameters </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            if (PhoneNumber != null)
            {
                p.Add(new KeyValuePair<string, string>("PhoneNumber", PhoneNumber.ToString()));
            }
            if (SmsCapability != null)
            {
                p.Add(new KeyValuePair<string, string>("SmsCapability", SmsCapability.Value.ToString().ToLower()));
            }
            if (AccountSid != null)
            {
                p.Add(new KeyValuePair<string, string>("AccountSid", AccountSid));
            }
            if (FriendlyName != null)
            {
                p.Add(new KeyValuePair<string, string>("FriendlyName", FriendlyName));
            }
            if (UniqueName != null)
            {
                p.Add(new KeyValuePair<string, string>("UniqueName", UniqueName));
            }
            if (CcEmails != null)
            {
                p.AddRange(CcEmails.Select(CcEmails => new KeyValuePair<string, string>("CcEmails", CcEmails)));
            }
            if (SmsUrl != null)
            {
                p.Add(new KeyValuePair<string, string>("SmsUrl", Serializers.Url(SmsUrl)));
            }
            if (SmsMethod != null)
            {
                p.Add(new KeyValuePair<string, string>("SmsMethod", SmsMethod.ToString()));
            }
            if (SmsFallbackUrl != null)
            {
                p.Add(new KeyValuePair<string, string>("SmsFallbackUrl", Serializers.Url(SmsFallbackUrl)));
            }
            if (SmsFallbackMethod != null)
            {
                p.Add(new KeyValuePair<string, string>("SmsFallbackMethod", SmsFallbackMethod.ToString()));
            }
            if (StatusCallbackUrl != null)
            {
                p.Add(new KeyValuePair<string, string>("StatusCallbackUrl", Serializers.Url(StatusCallbackUrl)));
            }
            if (StatusCallbackMethod != null)
            {
                p.Add(new KeyValuePair<string, string>("StatusCallbackMethod", StatusCallbackMethod.ToString()));
            }
            if (SmsApplicationSid != null)
            {
                p.Add(new KeyValuePair<string, string>("SmsApplicationSid", SmsApplicationSid));
            }
            if (AddressSid != null)
            {
                p.Add(new KeyValuePair<string, string>("AddressSid", AddressSid));
            }
            if (Email != null)
            {
                p.Add(new KeyValuePair<string, string>("Email", Email));
            }
            if (VerificationType != null)
            {
                p.Add(new KeyValuePair<string, string>("VerificationType", VerificationType.ToString()));
            }
            if (VerificationDocumentSid != null)
            {
                p.Add(new KeyValuePair<string, string>("VerificationDocumentSid", VerificationDocumentSid));
            }
            return p;
        }

        

    }
    /// <summary> Cancel the HostedNumberOrder (only available when the status is in `received`). </summary>
    public class DeleteHostedNumberOrderOptions : IOptions<HostedNumberOrderResource>
    {
        
        ///<summary> A 34 character string that uniquely identifies this HostedNumberOrder. </summary> 
        public string PathSid { get; }



        /// <summary> Construct a new DeleteHostedNumbersHostedNumberOrderOptions </summary>
        /// <param name="pathSid"> A 34 character string that uniquely identifies this HostedNumberOrder. </param>
        public DeleteHostedNumberOrderOptions(string pathSid)
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


    /// <summary> Fetch a specific HostedNumberOrder. </summary>
    public class FetchHostedNumberOrderOptions : IOptions<HostedNumberOrderResource>
    {
    
        ///<summary> A 34 character string that uniquely identifies this HostedNumberOrder. </summary> 
        public string PathSid { get; }



        /// <summary> Construct a new FetchHostedNumbersHostedNumberOrderOptions </summary>
        /// <param name="pathSid"> A 34 character string that uniquely identifies this HostedNumberOrder. </param>
        public FetchHostedNumberOrderOptions(string pathSid)
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


    /// <summary> Retrieve a list of HostedNumberOrders belonging to the account initiating the request. </summary>
    public class ReadHostedNumberOrderOptions : ReadOptions<HostedNumberOrderResource>
    {
    
        ///<summary> The Status of this HostedNumberOrder. One of `received`, `pending-verification`, `verified`, `pending-loa`, `carrier-processing`, `testing`, `completed`, `failed`, or `action-required`. </summary> 
        public HostedNumberOrderResource.StatusEnum Status { get; set; }

        ///<summary> An E164 formatted phone number hosted by this HostedNumberOrder. </summary> 
        public Types.PhoneNumber PhoneNumber { get; set; }

        ///<summary> A 34 character string that uniquely identifies the IncomingPhoneNumber resource created by this HostedNumberOrder. </summary> 
        public string IncomingPhoneNumberSid { get; set; }

        ///<summary> A human readable description of this resource, up to 64 characters. </summary> 
        public string FriendlyName { get; set; }

        ///<summary> Provides a unique and addressable name to be assigned to this HostedNumberOrder, assigned by the developer, to be optionally used in addition to SID. </summary> 
        public string UniqueName { get; set; }




        
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
            if (UniqueName != null)
            {
                p.Add(new KeyValuePair<string, string>("UniqueName", UniqueName));
            }
            if (PageSize != null)
            {
                p.Add(new KeyValuePair<string, string>("PageSize", PageSize.ToString()));
            }
            return p;
        }

    

    }

    /// <summary> Updates a specific HostedNumberOrder. </summary>
    public class UpdateHostedNumberOrderOptions : IOptions<HostedNumberOrderResource>
    {
    
        ///<summary> A 34 character string that uniquely identifies this HostedNumberOrder. </summary> 
        public string PathSid { get; }

        ///<summary> A 64 character string that is a human readable text that describes this resource. </summary> 
        public string FriendlyName { get; set; }

        ///<summary> Provides a unique and addressable name to be assigned to this HostedNumberOrder, assigned by the developer, to be optionally used in addition to SID. </summary> 
        public string UniqueName { get; set; }

        ///<summary> Email of the owner of this phone number that is being hosted. </summary> 
        public string Email { get; set; }

        ///<summary> Optional. A list of emails that LOA document for this HostedNumberOrder will be carbon copied to. </summary> 
        public List<string> CcEmails { get; set; }

        
        public HostedNumberOrderResource.StatusEnum Status { get; set; }

        ///<summary> A verification code that is given to the user via a phone call to the phone number that is being hosted. </summary> 
        public string VerificationCode { get; set; }

        
        public HostedNumberOrderResource.VerificationTypeEnum VerificationType { get; set; }

        ///<summary> Optional. The unique sid identifier of the Identity Document that represents the document for verifying ownership of the number to be hosted. Required when VerificationType is phone-bill. </summary> 
        public string VerificationDocumentSid { get; set; }

        ///<summary> Digits to dial after connecting the verification call. </summary> 
        public string Extension { get; set; }

        ///<summary> The number of seconds, between 0 and 60, to delay before initiating the verification call. Defaults to 0. </summary> 
        public int? CallDelay { get; set; }



        /// <summary> Construct a new UpdateHostedNumbersHostedNumberOrderOptions </summary>
        /// <param name="pathSid"> A 34 character string that uniquely identifies this HostedNumberOrder. </param>
        public UpdateHostedNumberOrderOptions(string pathSid)
        {
            PathSid = pathSid;
            CcEmails = new List<string>();
        }

        
        /// <summary> Generate the necessary parameters </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            if (FriendlyName != null)
            {
                p.Add(new KeyValuePair<string, string>("FriendlyName", FriendlyName));
            }
            if (UniqueName != null)
            {
                p.Add(new KeyValuePair<string, string>("UniqueName", UniqueName));
            }
            if (Email != null)
            {
                p.Add(new KeyValuePair<string, string>("Email", Email));
            }
            if (CcEmails != null)
            {
                p.AddRange(CcEmails.Select(CcEmails => new KeyValuePair<string, string>("CcEmails", CcEmails)));
            }
            if (Status != null)
            {
                p.Add(new KeyValuePair<string, string>("Status", Status.ToString()));
            }
            if (VerificationCode != null)
            {
                p.Add(new KeyValuePair<string, string>("VerificationCode", VerificationCode));
            }
            if (VerificationType != null)
            {
                p.Add(new KeyValuePair<string, string>("VerificationType", VerificationType.ToString()));
            }
            if (VerificationDocumentSid != null)
            {
                p.Add(new KeyValuePair<string, string>("VerificationDocumentSid", VerificationDocumentSid));
            }
            if (Extension != null)
            {
                p.Add(new KeyValuePair<string, string>("Extension", Extension));
            }
            if (CallDelay != null)
            {
                p.Add(new KeyValuePair<string, string>("CallDelay", CallDelay.ToString()));
            }
            return p;
        }

        

    }


}


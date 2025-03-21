/*
 * This code was generated by
 * ___ _ _ _ _ _    _ ____    ____ ____ _    ____ ____ _  _ ____ ____ ____ ___ __   __
 *  |  | | | | |    | |  | __ |  | |__| | __ | __ |___ |\ | |___ |__/ |__|  | |  | |__/
 *  |  |_|_| | |___ | |__|    |__| |  | |    |__] |___ | \| |___ |  \ |  |  | |__| |  \
 *
 * Twilio - Api
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




namespace Twilio.Rest.Api.V2010.Account.IncomingPhoneNumber
{

    /// <summary> create </summary>
    public class CreateLocalOptions : IOptions<LocalResource>
    {
        
        ///<summary> The phone number to purchase specified in [E.164](https://www.twilio.com/docs/glossary/what-e164) format.  E.164 phone numbers consist of a + followed by the country code and subscriber number without punctuation characters. For example, +14155551234. </summary> 
        public Types.PhoneNumber PhoneNumber { get; }

        ///<summary> The SID of the [Account](https://www.twilio.com/docs/iam/api/account) that will create the resource. </summary> 
        public string PathAccountSid { get; set; }

        ///<summary> The API version to use for incoming calls made to the new phone number. The default is `2010-04-01`. </summary> 
        public string ApiVersion { get; set; }

        ///<summary> A descriptive string that you created to describe the new phone number. It can be up to 64 characters long. By default, this is a formatted version of the phone number. </summary> 
        public string FriendlyName { get; set; }

        ///<summary> The SID of the application that should handle SMS messages sent to the new phone number. If an `sms_application_sid` is present, we ignore all of the `sms_*_url` urls and use those set on the application. </summary> 
        public string SmsApplicationSid { get; set; }

        ///<summary> The HTTP method that we should use to call `sms_fallback_url`. Can be: `GET` or `POST` and defaults to `POST`. </summary> 
        public Twilio.Http.HttpMethod SmsFallbackMethod { get; set; }

        ///<summary> The URL that we should call when an error occurs while requesting or executing the TwiML defined by `sms_url`. </summary> 
        public Uri SmsFallbackUrl { get; set; }

        ///<summary> The HTTP method that we should use to call `sms_url`. Can be: `GET` or `POST` and defaults to `POST`. </summary> 
        public Twilio.Http.HttpMethod SmsMethod { get; set; }

        ///<summary> The URL we should call when the new phone number receives an incoming SMS message. </summary> 
        public Uri SmsUrl { get; set; }

        ///<summary> The URL we should call using the `status_callback_method` to send status information to your application. </summary> 
        public Uri StatusCallback { get; set; }

        ///<summary> The HTTP method we should use to call `status_callback`. Can be: `GET` or `POST` and defaults to `POST`. </summary> 
        public Twilio.Http.HttpMethod StatusCallbackMethod { get; set; }

        ///<summary> The SID of the application we should use to handle calls to the new phone number. If a `voice_application_sid` is present, we ignore all of the voice urls and use only those set on the application. Setting a `voice_application_sid` will automatically delete your `trunk_sid` and vice versa. </summary> 
        public string VoiceApplicationSid { get; set; }

        ///<summary> Whether to lookup the caller's name from the CNAM database and post it to your app. Can be: `true` or `false` and defaults to `false`. </summary> 
        public bool? VoiceCallerIdLookup { get; set; }

        ///<summary> The HTTP method that we should use to call `voice_fallback_url`. Can be: `GET` or `POST` and defaults to `POST`. </summary> 
        public Twilio.Http.HttpMethod VoiceFallbackMethod { get; set; }

        ///<summary> The URL that we should call when an error occurs retrieving or executing the TwiML requested by `url`. </summary> 
        public Uri VoiceFallbackUrl { get; set; }

        ///<summary> The HTTP method that we should use to call `voice_url`. Can be: `GET` or `POST` and defaults to `POST`. </summary> 
        public Twilio.Http.HttpMethod VoiceMethod { get; set; }

        ///<summary> The URL that we should call to answer a call to the new phone number. The `voice_url` will not be called if a `voice_application_sid` or a `trunk_sid` is set. </summary> 
        public Uri VoiceUrl { get; set; }

        ///<summary> The SID of the Identity resource that we should associate with the new phone number. Some regions require an identity to meet local regulations. </summary> 
        public string IdentitySid { get; set; }

        ///<summary> The SID of the Address resource we should associate with the new phone number. Some regions require addresses to meet local regulations. </summary> 
        public string AddressSid { get; set; }

        
        public LocalResource.EmergencyStatusEnum EmergencyStatus { get; set; }

        ///<summary> The SID of the emergency address configuration to use for emergency calling from the new phone number. </summary> 
        public string EmergencyAddressSid { get; set; }

        ///<summary> The SID of the Trunk we should use to handle calls to the new phone number. If a `trunk_sid` is present, we ignore all of the voice urls and voice applications and use only those set on the Trunk. Setting a `trunk_sid` will automatically delete your `voice_application_sid` and vice versa. </summary> 
        public string TrunkSid { get; set; }

        
        public LocalResource.VoiceReceiveModeEnum VoiceReceiveMode { get; set; }

        ///<summary> The SID of the Bundle resource that you associate with the phone number. Some regions require a Bundle to meet local Regulations. </summary> 
        public string BundleSid { get; set; }


        /// <summary> Construct a new CreateIncomingPhoneNumberLocalOptions </summary>
        /// <param name="phoneNumber"> The phone number to purchase specified in [E.164](https://www.twilio.com/docs/glossary/what-e164) format.  E.164 phone numbers consist of a + followed by the country code and subscriber number without punctuation characters. For example, +14155551234. </param>
        public CreateLocalOptions(Types.PhoneNumber phoneNumber)
        {
            PhoneNumber = phoneNumber;
        }

        
        /// <summary> Generate the necessary parameters </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            if (PhoneNumber != null)
            {
                p.Add(new KeyValuePair<string, string>("PhoneNumber", PhoneNumber.ToString()));
            }
            if (ApiVersion != null)
            {
                p.Add(new KeyValuePair<string, string>("ApiVersion", ApiVersion));
            }
            if (FriendlyName != null)
            {
                p.Add(new KeyValuePair<string, string>("FriendlyName", FriendlyName));
            }
            if (SmsApplicationSid != null)
            {
                p.Add(new KeyValuePair<string, string>("SmsApplicationSid", SmsApplicationSid));
            }
            if (SmsFallbackMethod != null)
            {
                p.Add(new KeyValuePair<string, string>("SmsFallbackMethod", SmsFallbackMethod.ToString()));
            }
            if (SmsFallbackUrl != null)
            {
                p.Add(new KeyValuePair<string, string>("SmsFallbackUrl", Serializers.Url(SmsFallbackUrl)));
            }
            if (SmsMethod != null)
            {
                p.Add(new KeyValuePair<string, string>("SmsMethod", SmsMethod.ToString()));
            }
            if (SmsUrl != null)
            {
                p.Add(new KeyValuePair<string, string>("SmsUrl", Serializers.Url(SmsUrl)));
            }
            if (StatusCallback != null)
            {
                p.Add(new KeyValuePair<string, string>("StatusCallback", Serializers.Url(StatusCallback)));
            }
            if (StatusCallbackMethod != null)
            {
                p.Add(new KeyValuePair<string, string>("StatusCallbackMethod", StatusCallbackMethod.ToString()));
            }
            if (VoiceApplicationSid != null)
            {
                p.Add(new KeyValuePair<string, string>("VoiceApplicationSid", VoiceApplicationSid));
            }
            if (VoiceCallerIdLookup != null)
            {
                p.Add(new KeyValuePair<string, string>("VoiceCallerIdLookup", VoiceCallerIdLookup.Value.ToString().ToLower()));
            }
            if (VoiceFallbackMethod != null)
            {
                p.Add(new KeyValuePair<string, string>("VoiceFallbackMethod", VoiceFallbackMethod.ToString()));
            }
            if (VoiceFallbackUrl != null)
            {
                p.Add(new KeyValuePair<string, string>("VoiceFallbackUrl", Serializers.Url(VoiceFallbackUrl)));
            }
            if (VoiceMethod != null)
            {
                p.Add(new KeyValuePair<string, string>("VoiceMethod", VoiceMethod.ToString()));
            }
            if (VoiceUrl != null)
            {
                p.Add(new KeyValuePair<string, string>("VoiceUrl", Serializers.Url(VoiceUrl)));
            }
            if (IdentitySid != null)
            {
                p.Add(new KeyValuePair<string, string>("IdentitySid", IdentitySid));
            }
            if (AddressSid != null)
            {
                p.Add(new KeyValuePair<string, string>("AddressSid", AddressSid));
            }
            if (EmergencyStatus != null)
            {
                p.Add(new KeyValuePair<string, string>("EmergencyStatus", EmergencyStatus.ToString()));
            }
            if (EmergencyAddressSid != null)
            {
                p.Add(new KeyValuePair<string, string>("EmergencyAddressSid", EmergencyAddressSid));
            }
            if (TrunkSid != null)
            {
                p.Add(new KeyValuePair<string, string>("TrunkSid", TrunkSid));
            }
            if (VoiceReceiveMode != null)
            {
                p.Add(new KeyValuePair<string, string>("VoiceReceiveMode", VoiceReceiveMode.ToString()));
            }
            if (BundleSid != null)
            {
                p.Add(new KeyValuePair<string, string>("BundleSid", BundleSid));
            }
            return p;
        }

        

    }
    /// <summary> read </summary>
    public class ReadLocalOptions : ReadOptions<LocalResource>
    {
    
        ///<summary> The SID of the [Account](https://www.twilio.com/docs/iam/api/account) that created the resources to read. </summary> 
        public string PathAccountSid { get; set; }

        ///<summary> Whether to include phone numbers new to the Twilio platform. Can be: `true` or `false` and the default is `true`. </summary> 
        public bool? Beta { get; set; }

        ///<summary> A string that identifies the resources to read. </summary> 
        public string FriendlyName { get; set; }

        ///<summary> The phone numbers of the IncomingPhoneNumber resources to read. You can specify partial numbers and use '*' as a wildcard for any digit. </summary> 
        public Types.PhoneNumber PhoneNumber { get; set; }

        ///<summary> Whether to include phone numbers based on their origin. Can be: `twilio` or `hosted`. By default, phone numbers of all origin are included. </summary> 
        public string Origin { get; set; }




        
        /// <summary> Generate the necessary parameters </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            if (Beta != null)
            {
                p.Add(new KeyValuePair<string, string>("Beta", Beta.Value.ToString().ToLower()));
            }
            if (FriendlyName != null)
            {
                p.Add(new KeyValuePair<string, string>("FriendlyName", FriendlyName));
            }
            if (PhoneNumber != null)
            {
                p.Add(new KeyValuePair<string, string>("PhoneNumber", PhoneNumber.ToString()));
            }
            if (Origin != null)
            {
                p.Add(new KeyValuePair<string, string>("Origin", Origin));
            }
            if (PageSize != null)
            {
                p.Add(new KeyValuePair<string, string>("PageSize", PageSize.ToString()));
            }
            return p;
        }

    

    }

}


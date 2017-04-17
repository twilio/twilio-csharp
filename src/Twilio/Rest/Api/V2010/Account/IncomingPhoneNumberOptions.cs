using System;
using System.Collections.Generic;
using Twilio.Base;

namespace Twilio.Rest.Api.V2010.Account 
{

    /// <summary>
    /// Update an incoming-phone-number instance
    /// </summary>
    public class UpdateIncomingPhoneNumberOptions : IOptions<IncomingPhoneNumberResource> 
    {
        /// <summary>
        /// The new owner of the phone number
        /// </summary>
        public string PathAccountSid { get; set; }
        /// <summary>
        /// The sid
        /// </summary>
        public string PathSid { get; }
        /// <summary>
        /// The new owner of the phone number
        /// </summary>
        public string AccountSid { get; set; }
        /// <summary>
        /// The Twilio REST API version to use
        /// </summary>
        public string ApiVersion { get; set; }
        /// <summary>
        /// A human readable description of this resource
        /// </summary>
        public string FriendlyName { get; set; }
        /// <summary>
        /// Unique string that identifies the application
        /// </summary>
        public string SmsApplicationSid { get; set; }
        /// <summary>
        /// HTTP method used with sms fallback url
        /// </summary>
        public Twilio.Http.HttpMethod SmsFallbackMethod { get; set; }
        /// <summary>
        /// URL Twilio will request if an error occurs in executing TwiML
        /// </summary>
        public Uri SmsFallbackUrl { get; set; }
        /// <summary>
        /// HTTP method to use with sms url
        /// </summary>
        public Twilio.Http.HttpMethod SmsMethod { get; set; }
        /// <summary>
        /// URL Twilio will request when receiving an SMS
        /// </summary>
        public Uri SmsUrl { get; set; }
        /// <summary>
        /// URL Twilio will use to pass status parameters
        /// </summary>
        public Uri StatusCallback { get; set; }
        /// <summary>
        /// HTTP method twilio will use with status callback
        /// </summary>
        public Twilio.Http.HttpMethod StatusCallbackMethod { get; set; }
        /// <summary>
        /// The unique sid of the application to handle this number
        /// </summary>
        public string VoiceApplicationSid { get; set; }
        /// <summary>
        /// Look up the caller's caller-ID
        /// </summary>
        public bool? VoiceCallerIdLookup { get; set; }
        /// <summary>
        /// HTTP method used with fallback_url
        /// </summary>
        public Twilio.Http.HttpMethod VoiceFallbackMethod { get; set; }
        /// <summary>
        /// URL Twilio will request when an error occurs in TwiML
        /// </summary>
        public Uri VoiceFallbackUrl { get; set; }
        /// <summary>
        /// HTTP method used with the voice url
        /// </summary>
        public Twilio.Http.HttpMethod VoiceMethod { get; set; }
        /// <summary>
        /// URL Twilio will request when receiving a call
        /// </summary>
        public Uri VoiceUrl { get; set; }
        /// <summary>
        /// The emergency_status
        /// </summary>
        public IncomingPhoneNumberResource.EmergencyStatusEnum EmergencyStatus { get; set; }
        /// <summary>
        /// The emergency_address_sid
        /// </summary>
        public string EmergencyAddressSid { get; set; }
        /// <summary>
        /// Unique string to identify the trunk
        /// </summary>
        public string TrunkSid { get; set; }

        /// <summary>
        /// Construct a new UpdateIncomingPhoneNumberOptions
        /// </summary>
        ///
        /// <param name="pathSid"> The sid </param>
        public UpdateIncomingPhoneNumberOptions(string pathSid)
        {
            PathSid = pathSid;
        }

        /// <summary>
        /// Generate the necessary parameters
        /// </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();
            if (AccountSid != null)
            {
                p.Add(new KeyValuePair<string, string>("AccountSid", AccountSid.ToString()));
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
                p.Add(new KeyValuePair<string, string>("SmsApplicationSid", SmsApplicationSid.ToString()));
            }

            if (SmsFallbackMethod != null)
            {
                p.Add(new KeyValuePair<string, string>("SmsFallbackMethod", SmsFallbackMethod.ToString()));
            }

            if (SmsFallbackUrl != null)
            {
                p.Add(new KeyValuePair<string, string>("SmsFallbackUrl", SmsFallbackUrl.ToString()));
            }

            if (SmsMethod != null)
            {
                p.Add(new KeyValuePair<string, string>("SmsMethod", SmsMethod.ToString()));
            }

            if (SmsUrl != null)
            {
                p.Add(new KeyValuePair<string, string>("SmsUrl", SmsUrl.ToString()));
            }

            if (StatusCallback != null)
            {
                p.Add(new KeyValuePair<string, string>("StatusCallback", StatusCallback.ToString()));
            }

            if (StatusCallbackMethod != null)
            {
                p.Add(new KeyValuePair<string, string>("StatusCallbackMethod", StatusCallbackMethod.ToString()));
            }

            if (VoiceApplicationSid != null)
            {
                p.Add(new KeyValuePair<string, string>("VoiceApplicationSid", VoiceApplicationSid.ToString()));
            }

            if (VoiceCallerIdLookup != null)
            {
                p.Add(new KeyValuePair<string, string>("VoiceCallerIdLookup", VoiceCallerIdLookup.Value.ToString()));
            }

            if (VoiceFallbackMethod != null)
            {
                p.Add(new KeyValuePair<string, string>("VoiceFallbackMethod", VoiceFallbackMethod.ToString()));
            }

            if (VoiceFallbackUrl != null)
            {
                p.Add(new KeyValuePair<string, string>("VoiceFallbackUrl", VoiceFallbackUrl.ToString()));
            }

            if (VoiceMethod != null)
            {
                p.Add(new KeyValuePair<string, string>("VoiceMethod", VoiceMethod.ToString()));
            }

            if (VoiceUrl != null)
            {
                p.Add(new KeyValuePair<string, string>("VoiceUrl", VoiceUrl.ToString()));
            }

            if (EmergencyStatus != null)
            {
                p.Add(new KeyValuePair<string, string>("EmergencyStatus", EmergencyStatus.ToString()));
            }

            if (EmergencyAddressSid != null)
            {
                p.Add(new KeyValuePair<string, string>("EmergencyAddressSid", EmergencyAddressSid.ToString()));
            }

            if (TrunkSid != null)
            {
                p.Add(new KeyValuePair<string, string>("TrunkSid", TrunkSid.ToString()));
            }

            return p;
        }
    }

    /// <summary>
    /// Fetch an incoming-phone-number belonging to the account used to make the request
    /// </summary>
    public class FetchIncomingPhoneNumberOptions : IOptions<IncomingPhoneNumberResource> 
    {
        /// <summary>
        /// The account_sid
        /// </summary>
        public string PathAccountSid { get; set; }
        /// <summary>
        /// Fetch by unique incoming-phone-number Sid
        /// </summary>
        public string PathSid { get; }

        /// <summary>
        /// Construct a new FetchIncomingPhoneNumberOptions
        /// </summary>
        ///
        /// <param name="pathSid"> Fetch by unique incoming-phone-number Sid </param>
        public FetchIncomingPhoneNumberOptions(string pathSid)
        {
            PathSid = pathSid;
        }

        /// <summary>
        /// Generate the necessary parameters
        /// </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();
            return p;
        }
    }

    /// <summary>
    /// Delete a phone-numbers belonging to the account used to make the request
    /// </summary>
    public class DeleteIncomingPhoneNumberOptions : IOptions<IncomingPhoneNumberResource> 
    {
        /// <summary>
        /// The account_sid
        /// </summary>
        public string PathAccountSid { get; set; }
        /// <summary>
        /// Delete by unique phone-number Sid
        /// </summary>
        public string PathSid { get; }

        /// <summary>
        /// Construct a new DeleteIncomingPhoneNumberOptions
        /// </summary>
        ///
        /// <param name="pathSid"> Delete by unique phone-number Sid </param>
        public DeleteIncomingPhoneNumberOptions(string pathSid)
        {
            PathSid = pathSid;
        }

        /// <summary>
        /// Generate the necessary parameters
        /// </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();
            return p;
        }
    }

    /// <summary>
    /// Retrieve a list of incoming-phone-numbers belonging to the account used to make the request
    /// </summary>
    public class ReadIncomingPhoneNumberOptions : ReadOptions<IncomingPhoneNumberResource> 
    {
        /// <summary>
        /// The account_sid
        /// </summary>
        public string PathAccountSid { get; set; }
        /// <summary>
        /// Include new phone numbers
        /// </summary>
        public bool? Beta { get; set; }
        /// <summary>
        /// Filter by friendly name
        /// </summary>
        public string FriendlyName { get; set; }
        /// <summary>
        /// Filter by incoming phone number
        /// </summary>
        public Types.PhoneNumber PhoneNumber { get; set; }

        /// <summary>
        /// Generate the necessary parameters
        /// </summary>
        public override List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();
            if (Beta != null)
            {
                p.Add(new KeyValuePair<string, string>("Beta", Beta.Value.ToString()));
            }

            if (FriendlyName != null)
            {
                p.Add(new KeyValuePair<string, string>("FriendlyName", FriendlyName));
            }

            if (PhoneNumber != null)
            {
                p.Add(new KeyValuePair<string, string>("PhoneNumber", PhoneNumber.ToString()));
            }

            if (PageSize != null)
            {
                p.Add(new KeyValuePair<string, string>("PageSize", PageSize.ToString()));
            }

            return p;
        }
    }

    /// <summary>
    /// Purchase a phone-number for the account
    /// </summary>
    public class CreateIncomingPhoneNumberOptions : IOptions<IncomingPhoneNumberResource> 
    {
        /// <summary>
        /// The account_sid
        /// </summary>
        public string PathAccountSid { get; set; }
        /// <summary>
        /// The phone number
        /// </summary>
        public Types.PhoneNumber PhoneNumber { get; set; }
        /// <summary>
        /// The desired area code for the new number
        /// </summary>
        public string AreaCode { get; set; }
        /// <summary>
        /// The Twilio Rest API version to use
        /// </summary>
        public string ApiVersion { get; set; }
        /// <summary>
        /// A human readable description of this resource
        /// </summary>
        public string FriendlyName { get; set; }
        /// <summary>
        /// Unique string that identifies the application
        /// </summary>
        public string SmsApplicationSid { get; set; }
        /// <summary>
        /// HTTP method used with sms fallback url
        /// </summary>
        public Twilio.Http.HttpMethod SmsFallbackMethod { get; set; }
        /// <summary>
        /// URL Twilio will request if an error occurs in executing TwiML
        /// </summary>
        public Uri SmsFallbackUrl { get; set; }
        /// <summary>
        /// HTTP method to use with sms url
        /// </summary>
        public Twilio.Http.HttpMethod SmsMethod { get; set; }
        /// <summary>
        /// URL Twilio will request when receiving an SMS
        /// </summary>
        public Uri SmsUrl { get; set; }
        /// <summary>
        /// URL Twilio will use to pass status parameters
        /// </summary>
        public Uri StatusCallback { get; set; }
        /// <summary>
        /// HTTP method twilio will use with status callback
        /// </summary>
        public Twilio.Http.HttpMethod StatusCallbackMethod { get; set; }
        /// <summary>
        /// The unique sid of the application to handle this number
        /// </summary>
        public string VoiceApplicationSid { get; set; }
        /// <summary>
        /// Look up the caller's caller-ID
        /// </summary>
        public bool? VoiceCallerIdLookup { get; set; }
        /// <summary>
        /// HTTP method used with fallback_url
        /// </summary>
        public Twilio.Http.HttpMethod VoiceFallbackMethod { get; set; }
        /// <summary>
        /// URL Twilio will request when an error occurs in TwiML
        /// </summary>
        public Uri VoiceFallbackUrl { get; set; }
        /// <summary>
        /// HTTP method used with the voice url
        /// </summary>
        public Twilio.Http.HttpMethod VoiceMethod { get; set; }
        /// <summary>
        /// URL Twilio will request when receiving a call
        /// </summary>
        public Uri VoiceUrl { get; set; }
        /// <summary>
        /// The emergency_status
        /// </summary>
        public IncomingPhoneNumberResource.EmergencyStatusEnum EmergencyStatus { get; set; }
        /// <summary>
        /// The emergency_address_sid
        /// </summary>
        public string EmergencyAddressSid { get; set; }
        /// <summary>
        /// Unique string to identify the trunk
        /// </summary>
        public string TrunkSid { get; set; }

        /// <summary>
        /// Generate the necessary parameters
        /// </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();
            if (PhoneNumber != null)
            {
                p.Add(new KeyValuePair<string, string>("PhoneNumber", PhoneNumber.ToString()));
            }

            if (AreaCode != null)
            {
                p.Add(new KeyValuePair<string, string>("AreaCode", AreaCode));
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
                p.Add(new KeyValuePair<string, string>("SmsApplicationSid", SmsApplicationSid.ToString()));
            }

            if (SmsFallbackMethod != null)
            {
                p.Add(new KeyValuePair<string, string>("SmsFallbackMethod", SmsFallbackMethod.ToString()));
            }

            if (SmsFallbackUrl != null)
            {
                p.Add(new KeyValuePair<string, string>("SmsFallbackUrl", SmsFallbackUrl.ToString()));
            }

            if (SmsMethod != null)
            {
                p.Add(new KeyValuePair<string, string>("SmsMethod", SmsMethod.ToString()));
            }

            if (SmsUrl != null)
            {
                p.Add(new KeyValuePair<string, string>("SmsUrl", SmsUrl.ToString()));
            }

            if (StatusCallback != null)
            {
                p.Add(new KeyValuePair<string, string>("StatusCallback", StatusCallback.ToString()));
            }

            if (StatusCallbackMethod != null)
            {
                p.Add(new KeyValuePair<string, string>("StatusCallbackMethod", StatusCallbackMethod.ToString()));
            }

            if (VoiceApplicationSid != null)
            {
                p.Add(new KeyValuePair<string, string>("VoiceApplicationSid", VoiceApplicationSid.ToString()));
            }

            if (VoiceCallerIdLookup != null)
            {
                p.Add(new KeyValuePair<string, string>("VoiceCallerIdLookup", VoiceCallerIdLookup.Value.ToString()));
            }

            if (VoiceFallbackMethod != null)
            {
                p.Add(new KeyValuePair<string, string>("VoiceFallbackMethod", VoiceFallbackMethod.ToString()));
            }

            if (VoiceFallbackUrl != null)
            {
                p.Add(new KeyValuePair<string, string>("VoiceFallbackUrl", VoiceFallbackUrl.ToString()));
            }

            if (VoiceMethod != null)
            {
                p.Add(new KeyValuePair<string, string>("VoiceMethod", VoiceMethod.ToString()));
            }

            if (VoiceUrl != null)
            {
                p.Add(new KeyValuePair<string, string>("VoiceUrl", VoiceUrl.ToString()));
            }

            if (EmergencyStatus != null)
            {
                p.Add(new KeyValuePair<string, string>("EmergencyStatus", EmergencyStatus.ToString()));
            }

            if (EmergencyAddressSid != null)
            {
                p.Add(new KeyValuePair<string, string>("EmergencyAddressSid", EmergencyAddressSid.ToString()));
            }

            if (TrunkSid != null)
            {
                p.Add(new KeyValuePair<string, string>("TrunkSid", TrunkSid.ToString()));
            }

            return p;
        }
    }

}
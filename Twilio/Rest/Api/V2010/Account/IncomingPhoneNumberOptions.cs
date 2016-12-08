using System;
using System.Collections.Generic;
using Twilio.Base;

namespace Twilio.Rest.Api.V2010.Account 
{

    public class UpdateIncomingPhoneNumberOptions : IOptions<IncomingPhoneNumberResource> 
    {
        public string OwnerAccountSid { get; set; }
        public string Sid { get; }
        public string AccountSid { get; set; }
        public string ApiVersion { get; set; }
        public string FriendlyName { get; set; }
        public string SmsApplicationSid { get; set; }
        public Twilio.Http.HttpMethod SmsFallbackMethod { get; set; }
        public Uri SmsFallbackUrl { get; set; }
        public Twilio.Http.HttpMethod SmsMethod { get; set; }
        public Uri SmsUrl { get; set; }
        public Uri StatusCallback { get; set; }
        public Twilio.Http.HttpMethod StatusCallbackMethod { get; set; }
        public string TrunkSid { get; set; }
        public string VoiceApplicationSid { get; set; }
        public bool? VoiceCallerIdLookup { get; set; }
        public Twilio.Http.HttpMethod VoiceFallbackMethod { get; set; }
        public Uri VoiceFallbackUrl { get; set; }
        public Twilio.Http.HttpMethod VoiceMethod { get; set; }
        public Uri VoiceUrl { get; set; }
        public IncomingPhoneNumberResource.EmergencyStatusEnum EmergencyStatus { get; set; }
        public string EmergencyAddressSid { get; set; }
    
        /// <summary>
        /// Construct a new UpdateIncomingPhoneNumberOptions
        /// </summary>
        ///
        /// <param name="sid"> The sid </param>
        public UpdateIncomingPhoneNumberOptions(string sid)
        {
            Sid = sid;
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
            
            if (TrunkSid != null)
            {
                p.Add(new KeyValuePair<string, string>("TrunkSid", TrunkSid.ToString()));
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
            
            return p;
        }
    }

    public class FetchIncomingPhoneNumberOptions : IOptions<IncomingPhoneNumberResource> 
    {
        public string OwnerAccountSid { get; set; }
        public string Sid { get; }
    
        /// <summary>
        /// Construct a new FetchIncomingPhoneNumberOptions
        /// </summary>
        ///
        /// <param name="sid"> Fetch by unique incoming-phone-number Sid </param>
        public FetchIncomingPhoneNumberOptions(string sid)
        {
            Sid = sid;
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

    public class DeleteIncomingPhoneNumberOptions : IOptions<IncomingPhoneNumberResource> 
    {
        public string OwnerAccountSid { get; set; }
        public string Sid { get; }
    
        /// <summary>
        /// Construct a new DeleteIncomingPhoneNumberOptions
        /// </summary>
        ///
        /// <param name="sid"> Delete by unique phone-number Sid </param>
        public DeleteIncomingPhoneNumberOptions(string sid)
        {
            Sid = sid;
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

    public class ReadIncomingPhoneNumberOptions : ReadOptions<IncomingPhoneNumberResource> 
    {
        public string OwnerAccountSid { get; set; }
        public bool? Beta { get; set; }
        public string FriendlyName { get; set; }
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

    public class CreateIncomingPhoneNumberOptions : IOptions<IncomingPhoneNumberResource> 
    {
        public string OwnerAccountSid { get; set; }
        public Types.PhoneNumber PhoneNumber { get; set; }
        public string AreaCode { get; set; }
        public string ApiVersion { get; set; }
        public string FriendlyName { get; set; }
        public string SmsApplicationSid { get; set; }
        public Twilio.Http.HttpMethod SmsFallbackMethod { get; set; }
        public Uri SmsFallbackUrl { get; set; }
        public Twilio.Http.HttpMethod SmsMethod { get; set; }
        public Uri SmsUrl { get; set; }
        public Uri StatusCallback { get; set; }
        public Twilio.Http.HttpMethod StatusCallbackMethod { get; set; }
        public string TrunkSid { get; set; }
        public string VoiceApplicationSid { get; set; }
        public bool? VoiceCallerIdLookup { get; set; }
        public Twilio.Http.HttpMethod VoiceFallbackMethod { get; set; }
        public Uri VoiceFallbackUrl { get; set; }
        public Twilio.Http.HttpMethod VoiceMethod { get; set; }
        public Uri VoiceUrl { get; set; }
        public IncomingPhoneNumberResource.EmergencyStatusEnum EmergencyStatus { get; set; }
        public string EmergencyAddressSid { get; set; }
    
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
            
            if (TrunkSid != null)
            {
                p.Add(new KeyValuePair<string, string>("TrunkSid", TrunkSid.ToString()));
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
            
            return p;
        }
    }

}
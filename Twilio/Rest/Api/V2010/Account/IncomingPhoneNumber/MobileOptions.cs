using System;
using System.Collections.Generic;
using Twilio.Base;

namespace Twilio.Rest.Api.V2010.Account.IncomingPhoneNumber 
{

    public class ReadMobileOptions : ReadOptions<MobileResource> 
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
                p.Add(new KeyValuePair<string, string>("Beta", Beta.ToString()));
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

    public class CreateMobileOptions : IOptions<MobileResource> 
    {
        public string OwnerAccountSid { get; set; }
        public Types.PhoneNumber PhoneNumber { get; }
        public string ApiVersion { get; set; }
        public string FriendlyName { get; set; }
        public string SmsApplicationSid { get; set; }
        public Twilio.Http.HttpMethod SmsFallbackMethod { get; set; }
        public Uri SmsFallbackUrl { get; set; }
        public Twilio.Http.HttpMethod SmsMethod { get; set; }
        public Uri SmsUrl { get; set; }
        public Uri StatusCallback { get; set; }
        public Twilio.Http.HttpMethod StatusCallbackMethod { get; set; }
        public string VoiceApplicationSid { get; set; }
        public bool? VoiceCallerIdLookup { get; set; }
        public Twilio.Http.HttpMethod VoiceFallbackMethod { get; set; }
        public Uri VoiceFallbackUrl { get; set; }
        public Twilio.Http.HttpMethod VoiceMethod { get; set; }
        public Uri VoiceUrl { get; set; }
    
        /// <summary>
        /// Construct a new CreateMobileOptions
        /// </summary>
        ///
        /// <param name="phoneNumber"> The phone_number </param>
        public CreateMobileOptions(Types.PhoneNumber phoneNumber)
        {
            PhoneNumber = phoneNumber;
        }
    
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
                p.Add(new KeyValuePair<string, string>("VoiceApplicationSid", VoiceApplicationSid));
            }
            
            if (VoiceCallerIdLookup != null)
            {
                p.Add(new KeyValuePair<string, string>("VoiceCallerIdLookup", VoiceCallerIdLookup.ToString()));
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
            
            return p;
        }
    }

}
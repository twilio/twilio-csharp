/*
 * This code was generated by
 * ___ _ _ _ _ _    _ ____    ____ ____ _    ____ ____ _  _ ____ ____ ____ ___ __   __
 *  |  | | | | |    | |  | __ |  | |__| | __ | __ |___ |\ | |___ |__/ |__|  | |  | |__/
 *  |  |_|_| | |___ | |__|    |__| |  | |    |__] |___ | \| |___ |  \ |  |  | |__| |  \
 *
 * Twilio - Voice
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




namespace Twilio.Rest.Voice.V1
{

    /// <summary> create </summary>
    public class CreateByocTrunkOptions : IOptions<ByocTrunkResource>
    {
        
        ///<summary> A descriptive string that you create to describe the resource. It is not unique and can be up to 255 characters long. </summary> 
        public string FriendlyName { get; set; }

        ///<summary> The URL we should call when the BYOC Trunk receives a call. </summary> 
        public Uri VoiceUrl { get; set; }

        ///<summary> The HTTP method we should use to call `voice_url`. Can be: `GET` or `POST`. </summary> 
        public Twilio.Http.HttpMethod VoiceMethod { get; set; }

        ///<summary> The URL that we should call when an error occurs while retrieving or executing the TwiML from `voice_url`. </summary> 
        public Uri VoiceFallbackUrl { get; set; }

        ///<summary> The HTTP method we should use to call `voice_fallback_url`. Can be: `GET` or `POST`. </summary> 
        public Twilio.Http.HttpMethod VoiceFallbackMethod { get; set; }

        ///<summary> The URL that we should call to pass status parameters (such as call ended) to your application. </summary> 
        public Uri StatusCallbackUrl { get; set; }

        ///<summary> The HTTP method we should use to call `status_callback_url`. Can be: `GET` or `POST`. </summary> 
        public Twilio.Http.HttpMethod StatusCallbackMethod { get; set; }

        ///<summary> Whether Caller ID Name (CNAM) lookup is enabled for the trunk. If enabled, all inbound calls to the BYOC Trunk from the United States and Canada automatically perform a CNAM Lookup and display Caller ID data on your phone. See [CNAM Lookups](https://www.twilio.com/docs/sip-trunking#CNAM) for more information. </summary> 
        public bool? CnamLookupEnabled { get; set; }

        ///<summary> The SID of the Connection Policy that Twilio will use when routing traffic to your communications infrastructure. </summary> 
        public string ConnectionPolicySid { get; set; }

        ///<summary> The SID of the SIP Domain that should be used in the `From` header of originating calls sent to your SIP infrastructure. If your SIP infrastructure allows users to \\\"call back\\\" an incoming call, configure this with a [SIP Domain](https://www.twilio.com/docs/voice/api/sending-sip) to ensure proper routing. If not configured, the from domain will default to \\\"sip.twilio.com\\\". </summary> 
        public string FromDomainSid { get; set; }



        
        /// <summary> Generate the necessary parameters </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            if (FriendlyName != null)
            {
                p.Add(new KeyValuePair<string, string>("FriendlyName", FriendlyName));
            }
            if (VoiceUrl != null)
            {
                p.Add(new KeyValuePair<string, string>("VoiceUrl", Serializers.Url(VoiceUrl)));
            }
            if (VoiceMethod != null)
            {
                p.Add(new KeyValuePair<string, string>("VoiceMethod", VoiceMethod.ToString()));
            }
            if (VoiceFallbackUrl != null)
            {
                p.Add(new KeyValuePair<string, string>("VoiceFallbackUrl", Serializers.Url(VoiceFallbackUrl)));
            }
            if (VoiceFallbackMethod != null)
            {
                p.Add(new KeyValuePair<string, string>("VoiceFallbackMethod", VoiceFallbackMethod.ToString()));
            }
            if (StatusCallbackUrl != null)
            {
                p.Add(new KeyValuePair<string, string>("StatusCallbackUrl", Serializers.Url(StatusCallbackUrl)));
            }
            if (StatusCallbackMethod != null)
            {
                p.Add(new KeyValuePair<string, string>("StatusCallbackMethod", StatusCallbackMethod.ToString()));
            }
            if (CnamLookupEnabled != null)
            {
                p.Add(new KeyValuePair<string, string>("CnamLookupEnabled", CnamLookupEnabled.Value.ToString().ToLower()));
            }
            if (ConnectionPolicySid != null)
            {
                p.Add(new KeyValuePair<string, string>("ConnectionPolicySid", ConnectionPolicySid));
            }
            if (FromDomainSid != null)
            {
                p.Add(new KeyValuePair<string, string>("FromDomainSid", FromDomainSid));
            }
            return p;
        }

        

    }
    /// <summary> delete </summary>
    public class DeleteByocTrunkOptions : IOptions<ByocTrunkResource>
    {
        
        ///<summary> The Twilio-provided string that uniquely identifies the BYOC Trunk resource to delete. </summary> 
        public string PathSid { get; }



        /// <summary> Construct a new DeleteByocTrunkOptions </summary>
        /// <param name="pathSid"> The Twilio-provided string that uniquely identifies the BYOC Trunk resource to delete. </param>
        public DeleteByocTrunkOptions(string pathSid)
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


    /// <summary> fetch </summary>
    public class FetchByocTrunkOptions : IOptions<ByocTrunkResource>
    {
    
        ///<summary> The Twilio-provided string that uniquely identifies the BYOC Trunk resource to fetch. </summary> 
        public string PathSid { get; }



        /// <summary> Construct a new FetchByocTrunkOptions </summary>
        /// <param name="pathSid"> The Twilio-provided string that uniquely identifies the BYOC Trunk resource to fetch. </param>
        public FetchByocTrunkOptions(string pathSid)
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


    /// <summary> read </summary>
    public class ReadByocTrunkOptions : ReadOptions<ByocTrunkResource>
    {
    



        
        /// <summary> Generate the necessary parameters </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            if (PageSize != null)
            {
                p.Add(new KeyValuePair<string, string>("PageSize", PageSize.ToString()));
            }
            return p;
        }

    

    }

    /// <summary> update </summary>
    public class UpdateByocTrunkOptions : IOptions<ByocTrunkResource>
    {
    
        ///<summary> The Twilio-provided string that uniquely identifies the BYOC Trunk resource to update. </summary> 
        public string PathSid { get; }

        ///<summary> A descriptive string that you create to describe the resource. It is not unique and can be up to 255 characters long. </summary> 
        public string FriendlyName { get; set; }

        ///<summary> The URL we should call when the BYOC Trunk receives a call. </summary> 
        public Uri VoiceUrl { get; set; }

        ///<summary> The HTTP method we should use to call `voice_url` </summary> 
        public Twilio.Http.HttpMethod VoiceMethod { get; set; }

        ///<summary> The URL that we should call when an error occurs while retrieving or executing the TwiML requested by `voice_url`. </summary> 
        public Uri VoiceFallbackUrl { get; set; }

        ///<summary> The HTTP method we should use to call `voice_fallback_url`. Can be: `GET` or `POST`. </summary> 
        public Twilio.Http.HttpMethod VoiceFallbackMethod { get; set; }

        ///<summary> The URL that we should call to pass status parameters (such as call ended) to your application. </summary> 
        public Uri StatusCallbackUrl { get; set; }

        ///<summary> The HTTP method we should use to call `status_callback_url`. Can be: `GET` or `POST`. </summary> 
        public Twilio.Http.HttpMethod StatusCallbackMethod { get; set; }

        ///<summary> Whether Caller ID Name (CNAM) lookup is enabled for the trunk. If enabled, all inbound calls to the BYOC Trunk from the United States and Canada automatically perform a CNAM Lookup and display Caller ID data on your phone. See [CNAM Lookups](https://www.twilio.com/docs/sip-trunking#CNAM) for more information. </summary> 
        public bool? CnamLookupEnabled { get; set; }

        ///<summary> The SID of the Connection Policy that Twilio will use when routing traffic to your communications infrastructure. </summary> 
        public string ConnectionPolicySid { get; set; }

        ///<summary> The SID of the SIP Domain that should be used in the `From` header of originating calls sent to your SIP infrastructure. If your SIP infrastructure allows users to \\\"call back\\\" an incoming call, configure this with a [SIP Domain](https://www.twilio.com/docs/voice/api/sending-sip) to ensure proper routing. If not configured, the from domain will default to \\\"sip.twilio.com\\\". </summary> 
        public string FromDomainSid { get; set; }



        /// <summary> Construct a new UpdateByocTrunkOptions </summary>
        /// <param name="pathSid"> The Twilio-provided string that uniquely identifies the BYOC Trunk resource to update. </param>
        public UpdateByocTrunkOptions(string pathSid)
        {
            PathSid = pathSid;
        }

        
        /// <summary> Generate the necessary parameters </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            if (FriendlyName != null)
            {
                p.Add(new KeyValuePair<string, string>("FriendlyName", FriendlyName));
            }
            if (VoiceUrl != null)
            {
                p.Add(new KeyValuePair<string, string>("VoiceUrl", Serializers.Url(VoiceUrl)));
            }
            if (VoiceMethod != null)
            {
                p.Add(new KeyValuePair<string, string>("VoiceMethod", VoiceMethod.ToString()));
            }
            if (VoiceFallbackUrl != null)
            {
                p.Add(new KeyValuePair<string, string>("VoiceFallbackUrl", Serializers.Url(VoiceFallbackUrl)));
            }
            if (VoiceFallbackMethod != null)
            {
                p.Add(new KeyValuePair<string, string>("VoiceFallbackMethod", VoiceFallbackMethod.ToString()));
            }
            if (StatusCallbackUrl != null)
            {
                p.Add(new KeyValuePair<string, string>("StatusCallbackUrl", Serializers.Url(StatusCallbackUrl)));
            }
            if (StatusCallbackMethod != null)
            {
                p.Add(new KeyValuePair<string, string>("StatusCallbackMethod", StatusCallbackMethod.ToString()));
            }
            if (CnamLookupEnabled != null)
            {
                p.Add(new KeyValuePair<string, string>("CnamLookupEnabled", CnamLookupEnabled.Value.ToString().ToLower()));
            }
            if (ConnectionPolicySid != null)
            {
                p.Add(new KeyValuePair<string, string>("ConnectionPolicySid", ConnectionPolicySid));
            }
            if (FromDomainSid != null)
            {
                p.Add(new KeyValuePair<string, string>("FromDomainSid", FromDomainSid));
            }
            return p;
        }

        

    }


}


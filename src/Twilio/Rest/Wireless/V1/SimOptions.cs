/*
 * This code was generated by
 * ___ _ _ _ _ _    _ ____    ____ ____ _    ____ ____ _  _ ____ ____ ____ ___ __   __
 *  |  | | | | |    | |  | __ |  | |__| | __ | __ |___ |\ | |___ |__/ |__|  | |  | |__/
 *  |  |_|_| | |___ | |__|    |__| |  | |    |__] |___ | \| |___ |  \ |  |  | |__| |  \
 *
 * Twilio - Wireless
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




namespace Twilio.Rest.Wireless.V1
{
    /// <summary> Delete a Sim resource on your Account. </summary>
    public class DeleteSimOptions : IOptions<SimResource>
    {
        
        ///<summary> The SID or the `unique_name` of the Sim resource to delete. </summary> 
        public string PathSid { get; }



        /// <summary> Construct a new DeleteSimOptions </summary>
        /// <param name="pathSid"> The SID or the `unique_name` of the Sim resource to delete. </param>

        public DeleteSimOptions(string pathSid)
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


    /// <summary> Fetch a Sim resource on your Account. </summary>
    public class FetchSimOptions : IOptions<SimResource>
    {
    
        ///<summary> The SID or the `unique_name` of the Sim resource to fetch. </summary> 
        public string PathSid { get; }



        /// <summary> Construct a new FetchSimOptions </summary>
        /// <param name="pathSid"> The SID or the `unique_name` of the Sim resource to fetch. </param>

        public FetchSimOptions(string pathSid)
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


    /// <summary> Retrieve a list of Sim resources on your Account. </summary>
    public class ReadSimOptions : ReadOptions<SimResource>
    {
    
        ///<summary> Only return Sim resources with this status. </summary> 
        public SimResource.StatusEnum Status { get; set; }

        ///<summary> Only return Sim resources with this ICCID. This will return a list with a maximum size of 1. </summary> 
        public string Iccid { get; set; }

        ///<summary> The SID or unique name of a [RatePlan resource](https://www.twilio.com/docs/wireless/api/rateplan-resource). Only return Sim resources assigned to this RatePlan resource. </summary> 
        public string RatePlan { get; set; }

        ///<summary> Deprecated. </summary> 
        public string EId { get; set; }

        ///<summary> Only return Sim resources with this registration code. This will return a list with a maximum size of 1. </summary> 
        public string SimRegistrationCode { get; set; }




        
        /// <summary> Generate the necessary parameters </summary>
        public  override List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            if (Status != null)
            {
                p.Add(new KeyValuePair<string, string>("Status", Status.ToString()));
            }
            if (Iccid != null)
            {
                p.Add(new KeyValuePair<string, string>("Iccid", Iccid));
            }
            if (RatePlan != null)
            {
                p.Add(new KeyValuePair<string, string>("RatePlan", RatePlan));
            }
            if (EId != null)
            {
                p.Add(new KeyValuePair<string, string>("EId", EId));
            }
            if (SimRegistrationCode != null)
            {
                p.Add(new KeyValuePair<string, string>("SimRegistrationCode", SimRegistrationCode));
            }
            if (PageSize != null)
            {
                p.Add(new KeyValuePair<string, string>("PageSize", PageSize.ToString()));
            }
            return p;
        }
        

    }

    /// <summary> Updates the given properties of a Sim resource on your Account. </summary>
    public class UpdateSimOptions : IOptions<SimResource>
    {
    
        ///<summary> The SID or the `unique_name` of the Sim resource to update. </summary> 
        public string PathSid { get; }

        ///<summary> An application-defined string that uniquely identifies the resource. It can be used in place of the `sid` in the URL path to address the resource. </summary> 
        public string UniqueName { get; set; }

        ///<summary> The HTTP method we should use to call `callback_url`. Can be: `POST` or `GET`. The default is `POST`. </summary> 
        public Twilio.Http.HttpMethod CallbackMethod { get; set; }

        ///<summary> The URL we should call using the `callback_url` when the SIM has finished updating. When the SIM transitions from `new` to `ready` or from any status to `deactivated`, we call this URL when the status changes to an intermediate status (`ready` or `deactivated`) and again when the status changes to its final status (`active` or `canceled`). </summary> 
        public Uri CallbackUrl { get; set; }

        ///<summary> A descriptive string that you create to describe the Sim resource. It does not need to be unique. </summary> 
        public string FriendlyName { get; set; }

        ///<summary> The SID or unique name of the [RatePlan resource](https://www.twilio.com/docs/wireless/api/rateplan-resource) to which the Sim resource should be assigned. </summary> 
        public string RatePlan { get; set; }

        
        public SimResource.StatusEnum Status { get; set; }

        ///<summary> The HTTP method we should use to call `commands_callback_url`. Can be: `POST` or `GET`. The default is `POST`. </summary> 
        public Twilio.Http.HttpMethod CommandsCallbackMethod { get; set; }

        ///<summary> The URL we should call using the `commands_callback_method` when the SIM sends a [Command](https://www.twilio.com/docs/wireless/api/command-resource). Your server should respond with an HTTP status code in the 200 range; any response body is ignored. </summary> 
        public Uri CommandsCallbackUrl { get; set; }

        ///<summary> The HTTP method we should use to call `sms_fallback_url`. Can be: `GET` or `POST`. Default is `POST`. </summary> 
        public Twilio.Http.HttpMethod SmsFallbackMethod { get; set; }

        ///<summary> The URL we should call using the `sms_fallback_method` when an error occurs while retrieving or executing the TwiML requested from `sms_url`. </summary> 
        public Uri SmsFallbackUrl { get; set; }

        ///<summary> The HTTP method we should use to call `sms_url`. Can be: `GET` or `POST`. Default is `POST`. </summary> 
        public Twilio.Http.HttpMethod SmsMethod { get; set; }

        ///<summary> The URL we should call using the `sms_method` when the SIM-connected device sends an SMS message that is not a [Command](https://www.twilio.com/docs/wireless/api/command-resource). </summary> 
        public Uri SmsUrl { get; set; }

        ///<summary> Deprecated. </summary> 
        public Twilio.Http.HttpMethod VoiceFallbackMethod { get; set; }

        ///<summary> Deprecated. </summary> 
        public Uri VoiceFallbackUrl { get; set; }

        ///<summary> Deprecated. </summary> 
        public Twilio.Http.HttpMethod VoiceMethod { get; set; }

        ///<summary> Deprecated. </summary> 
        public Uri VoiceUrl { get; set; }

        
        public SimResource.ResetStatusEnum ResetStatus { get; set; }

        ///<summary> The SID of the [Account](https://www.twilio.com/docs/iam/api/account) to which the Sim resource should belong. The Account SID can only be that of the requesting Account or that of a [Subaccount](https://www.twilio.com/docs/iam/api/subaccounts) of the requesting Account. Only valid when the Sim resource's status is `new`. For more information, see the [Move SIMs between Subaccounts documentation](https://www.twilio.com/docs/wireless/api/sim-resource#move-sims-between-subaccounts). </summary> 
        public string AccountSid { get; set; }



        /// <summary> Construct a new UpdateSimOptions </summary>
        /// <param name="pathSid"> The SID or the `unique_name` of the Sim resource to update. </param>

        public UpdateSimOptions(string pathSid)
        {
            PathSid = pathSid;
        }

        
        /// <summary> Generate the necessary parameters </summary>
        public  List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            if (UniqueName != null)
            {
                p.Add(new KeyValuePair<string, string>("UniqueName", UniqueName));
            }
            if (CallbackMethod != null)
            {
                p.Add(new KeyValuePair<string, string>("CallbackMethod", CallbackMethod.ToString()));
            }
            if (CallbackUrl != null)
            {
                p.Add(new KeyValuePair<string, string>("CallbackUrl", Serializers.Url(CallbackUrl)));
            }
            if (FriendlyName != null)
            {
                p.Add(new KeyValuePair<string, string>("FriendlyName", FriendlyName));
            }
            if (RatePlan != null)
            {
                p.Add(new KeyValuePair<string, string>("RatePlan", RatePlan));
            }
            if (Status != null)
            {
                p.Add(new KeyValuePair<string, string>("Status", Status.ToString()));
            }
            if (CommandsCallbackMethod != null)
            {
                p.Add(new KeyValuePair<string, string>("CommandsCallbackMethod", CommandsCallbackMethod.ToString()));
            }
            if (CommandsCallbackUrl != null)
            {
                p.Add(new KeyValuePair<string, string>("CommandsCallbackUrl", Serializers.Url(CommandsCallbackUrl)));
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
            if (ResetStatus != null)
            {
                p.Add(new KeyValuePair<string, string>("ResetStatus", ResetStatus.ToString()));
            }
            if (AccountSid != null)
            {
                p.Add(new KeyValuePair<string, string>("AccountSid", AccountSid));
            }
            return p;
        }
        

    }


}


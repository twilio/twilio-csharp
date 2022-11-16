/*
 * This code was generated by
 * ___ _ _ _ _ _    _ ____    ____ ____ _    ____ ____ _  _ ____ ____ ____ ___ __   __
 *  |  | | | | |    | |  | __ |  | |__| | __ | __ |___ |\ | |___ |__/ |__|  | |  | |__/
 *  |  |_|_| | |___ | |__|    |__| |  | |    |__] |___ | \| |___ |  \ |  |  | |__| |  \
 *
 * Twilio - Supersim
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




namespace Twilio.Rest.Supersim.V1
{

    /// <summary> Send SMS Command to a Sim. </summary>
    public class CreateSmsCommandOptions : IOptions<SmsCommandResource>
    {
        
        ///<summary> The `sid` or `unique_name` of the [SIM](https://www.twilio.com/docs/iot/supersim/api/sim-resource) to send the SMS Command to. </summary> 
        public string Sim { get; }

        ///<summary> The message body of the SMS Command. </summary> 
        public string Payload { get; }

        ///<summary> The HTTP method we should use to call `callback_url`. Can be: `GET` or `POST` and the default is POST. </summary> 
        public Twilio.Http.HttpMethod CallbackMethod { get; set; }

        ///<summary> The URL we should call using the `callback_method` after we have sent the command. </summary> 
        public Uri CallbackUrl { get; set; }


        /// <summary> Construct a new CreateSmsCommandOptions </summary>
        /// <param name="sim"> The `sid` or `unique_name` of the [SIM](https://www.twilio.com/docs/iot/supersim/api/sim-resource) to send the SMS Command to. </param>
        /// <param name="payload"> The message body of the SMS Command. </param>

        public CreateSmsCommandOptions(string sim, string payload)
        {
            Sim = sim;
            Payload = payload;
        }

        
        /// <summary> Generate the necessary parameters </summary>
        public  List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            if (Sim != null)
            {
                p.Add(new KeyValuePair<string, string>("Sim", Sim));
            }
            if (Payload != null)
            {
                p.Add(new KeyValuePair<string, string>("Payload", Payload));
            }
            if (CallbackMethod != null)
            {
                p.Add(new KeyValuePair<string, string>("CallbackMethod", CallbackMethod.ToString()));
            }
            if (CallbackUrl != null)
            {
                p.Add(new KeyValuePair<string, string>("CallbackUrl", Serializers.Url(CallbackUrl)));
            }
            return p;
        }
        

    }
    /// <summary> Fetch SMS Command instance from your account. </summary>
    public class FetchSmsCommandOptions : IOptions<SmsCommandResource>
    {
    
        ///<summary> The SID of the SMS Command resource to fetch. </summary> 
        public string PathSid { get; }



        /// <summary> Construct a new FetchSmsCommandOptions </summary>
        /// <param name="pathSid"> The SID of the SMS Command resource to fetch. </param>

        public FetchSmsCommandOptions(string pathSid)
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


    /// <summary> Retrieve a list of SMS Commands from your account. </summary>
    public class ReadSmsCommandOptions : ReadOptions<SmsCommandResource>
    {
    
        ///<summary> The SID or unique name of the Sim resource that SMS Command was sent to or from. </summary> 
        public string Sim { get; set; }

        ///<summary> The status of the SMS Command. Can be: `queued`, `sent`, `delivered`, `received` or `failed`. See the [SMS Command Status Values](https://www.twilio.com/docs/wireless/api/smscommand-resource#status-values) for a description of each. </summary> 
        public SmsCommandResource.StatusEnum Status { get; set; }

        ///<summary> The direction of the SMS Command. Can be `to_sim` or `from_sim`. The value of `to_sim` is synonymous with the term `mobile terminated`, and `from_sim` is synonymous with the term `mobile originated`. </summary> 
        public SmsCommandResource.DirectionEnum Direction { get; set; }




        
        /// <summary> Generate the necessary parameters </summary>
        public  override List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            if (Sim != null)
            {
                p.Add(new KeyValuePair<string, string>("Sim", Sim));
            }
            if (Status != null)
            {
                p.Add(new KeyValuePair<string, string>("Status", Status.ToString()));
            }
            if (Direction != null)
            {
                p.Add(new KeyValuePair<string, string>("Direction", Direction.ToString()));
            }
            if (PageSize != null)
            {
                p.Add(new KeyValuePair<string, string>("PageSize", PageSize.ToString()));
            }
            return p;
        }
        

    }

}


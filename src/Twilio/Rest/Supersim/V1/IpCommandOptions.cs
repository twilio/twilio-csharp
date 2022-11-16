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

    /// <summary> Send an IP Command to a Super SIM. </summary>
    public class CreateIpCommandOptions : IOptions<IpCommandResource>
    {
        
        ///<summary> The `sid` or `unique_name` of the [Super SIM](https://www.twilio.com/docs/iot/supersim/api/sim-resource) to send the IP Command to. </summary> 
        public string Sim { get; }

        ///<summary> The payload to be delivered to the device. </summary> 
        public string Payload { get; }

        ///<summary> The device port to which the IP Command will be sent. </summary> 
        public int? DevicePort { get; }

        
        public IpCommandResource.PayloadTypeEnum PayloadType { get; set; }

        ///<summary> The URL we should call using the `callback_method` after we have sent the IP Command. </summary> 
        public Uri CallbackUrl { get; set; }

        ///<summary> The HTTP method we should use to call `callback_url`. Can be `GET` or `POST`, and the default is `POST`. </summary> 
        public Twilio.Http.HttpMethod CallbackMethod { get; set; }


        /// <summary> Construct a new CreateIpCommandOptions </summary>
        /// <param name="sim"> The `sid` or `unique_name` of the [Super SIM](https://www.twilio.com/docs/iot/supersim/api/sim-resource) to send the IP Command to. </param>
        /// <param name="payload"> The payload to be delivered to the device. </param>
        /// <param name="devicePort"> The device port to which the IP Command will be sent. </param>

        public CreateIpCommandOptions(string sim, string payload, int? devicePort)
        {
            Sim = sim;
            Payload = payload;
            DevicePort = devicePort;
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
            if (DevicePort != null)
            {
                p.Add(new KeyValuePair<string, string>("DevicePort", DevicePort.ToString()));
            }
            if (PayloadType != null)
            {
                p.Add(new KeyValuePair<string, string>("PayloadType", PayloadType.ToString()));
            }
            if (CallbackUrl != null)
            {
                p.Add(new KeyValuePair<string, string>("CallbackUrl", Serializers.Url(CallbackUrl)));
            }
            if (CallbackMethod != null)
            {
                p.Add(new KeyValuePair<string, string>("CallbackMethod", CallbackMethod.ToString()));
            }
            return p;
        }
        

    }
    /// <summary> Fetch IP Command instance from your account. </summary>
    public class FetchIpCommandOptions : IOptions<IpCommandResource>
    {
    
        ///<summary> The SID of the IP Command resource to fetch. </summary> 
        public string PathSid { get; }



        /// <summary> Construct a new FetchIpCommandOptions </summary>
        /// <param name="pathSid"> The SID of the IP Command resource to fetch. </param>

        public FetchIpCommandOptions(string pathSid)
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


    /// <summary> Retrieve a list of IP Commands from your account. </summary>
    public class ReadIpCommandOptions : ReadOptions<IpCommandResource>
    {
    
        ///<summary> The SID or unique name of the Sim resource that IP Command was sent to or from. </summary> 
        public string Sim { get; set; }

        ///<summary> The ICCID of the Sim resource that IP Command was sent to or from. </summary> 
        public string SimIccid { get; set; }

        ///<summary> The status of the IP Command. Can be: `queued`, `sent`, `received` or `failed`. See the [IP Command Status Values](https://www.twilio.com/docs/wireless/api/ipcommand-resource#status-values) for a description of each. </summary> 
        public IpCommandResource.StatusEnum Status { get; set; }

        ///<summary> The direction of the IP Command. Can be `to_sim` or `from_sim`. The value of `to_sim` is synonymous with the term `mobile terminated`, and `from_sim` is synonymous with the term `mobile originated`. </summary> 
        public IpCommandResource.DirectionEnum Direction { get; set; }




        
        /// <summary> Generate the necessary parameters </summary>
        public  override List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            if (Sim != null)
            {
                p.Add(new KeyValuePair<string, string>("Sim", Sim));
            }
            if (SimIccid != null)
            {
                p.Add(new KeyValuePair<string, string>("SimIccid", SimIccid));
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


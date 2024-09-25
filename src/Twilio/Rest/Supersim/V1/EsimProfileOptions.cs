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

    /// <summary> Order an eSIM Profile. </summary>
    public class CreateEsimProfileOptions : IOptions<EsimProfileResource>
    {
        
        ///<summary> The URL we should call using the `callback_method` when the status of the eSIM Profile changes. At this stage of the eSIM Profile pilot, the a request to the URL will only be called when the ESimProfile resource changes from `reserving` to `available`. </summary> 
        public string CallbackUrl { get; set; }

        ///<summary> The HTTP method we should use to call `callback_url`. Can be: `GET` or `POST` and the default is POST. </summary> 
        public Twilio.Http.HttpMethod CallbackMethod { get; set; }

        ///<summary> When set to `true`, a value for `Eid` does not need to be provided. Instead, when the eSIM profile is reserved, a matching ID will be generated and returned via the `matching_id` property. This identifies the specific eSIM profile that can be used by any capable device to claim and download the profile. </summary> 
        public bool? GenerateMatchingId { get; set; }

        ///<summary> Identifier of the eUICC that will claim the eSIM Profile. </summary> 
        public string Eid { get; set; }



        
        /// <summary> Generate the necessary parameters </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            if (CallbackUrl != null)
            {
                p.Add(new KeyValuePair<string, string>("CallbackUrl", CallbackUrl));
            }
            if (CallbackMethod != null)
            {
                p.Add(new KeyValuePair<string, string>("CallbackMethod", CallbackMethod.ToString()));
            }
            if (GenerateMatchingId != null)
            {
                p.Add(new KeyValuePair<string, string>("GenerateMatchingId", GenerateMatchingId.Value.ToString().ToLower()));
            }
            if (Eid != null)
            {
                p.Add(new KeyValuePair<string, string>("Eid", Eid));
            }
            return p;
        }

        

    }
    /// <summary> Fetch an eSIM Profile. </summary>
    public class FetchEsimProfileOptions : IOptions<EsimProfileResource>
    {
    
        ///<summary> The SID of the eSIM Profile resource to fetch. </summary> 
        public string PathSid { get; }



        /// <summary> Construct a new FetchEsimProfileOptions </summary>
        /// <param name="pathSid"> The SID of the eSIM Profile resource to fetch. </param>
        public FetchEsimProfileOptions(string pathSid)
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


    /// <summary> Retrieve a list of eSIM Profiles. </summary>
    public class ReadEsimProfileOptions : ReadOptions<EsimProfileResource>
    {
    
        ///<summary> List the eSIM Profiles that have been associated with an EId. </summary> 
        public string Eid { get; set; }

        ///<summary> Find the eSIM Profile resource related to a [Sim](https://www.twilio.com/docs/iot/supersim/api/sim-resource) resource by providing the SIM SID. Will always return an array with either 1 or 0 records. </summary> 
        public string SimSid { get; set; }

        ///<summary> List the eSIM Profiles that are in a given status. </summary> 
        public EsimProfileResource.StatusEnum Status { get; set; }




        
        /// <summary> Generate the necessary parameters </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            if (Eid != null)
            {
                p.Add(new KeyValuePair<string, string>("Eid", Eid));
            }
            if (SimSid != null)
            {
                p.Add(new KeyValuePair<string, string>("SimSid", SimSid));
            }
            if (Status != null)
            {
                p.Add(new KeyValuePair<string, string>("Status", Status.ToString()));
            }
            if (PageSize != null)
            {
                p.Add(new KeyValuePair<string, string>("PageSize", PageSize.ToString()));
            }
            return p;
        }

    

    }

}


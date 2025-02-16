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




namespace Twilio.Rest.Api.V2010.Account.Recording.AddOnResult
{
    /// <summary> Delete a payload from the result along with all associated Data </summary>
    public class DeletePayloadOptions : IOptions<PayloadResource>
    {
        
        ///<summary> The SID of the recording to which the AddOnResult resource that contains the payloads to delete belongs. </summary> 
        public string PathReferenceSid { get; }

        ///<summary> The SID of the AddOnResult to which the payloads to delete belongs. </summary> 
        public string PathAddOnResultSid { get; }

        ///<summary> The Twilio-provided string that uniquely identifies the Recording AddOnResult Payload resource to delete. </summary> 
        public string PathSid { get; }

        ///<summary> The SID of the [Account](https://www.twilio.com/docs/iam/api/account) that created the Recording AddOnResult Payload resources to delete. </summary> 
        public string PathAccountSid { get; set; }



        /// <summary> Construct a new DeleteRecordingAddOnResultPayloadOptions </summary>
        /// <param name="pathReferenceSid"> The SID of the recording to which the AddOnResult resource that contains the payloads to delete belongs. </param>
        /// <param name="pathAddOnResultSid"> The SID of the AddOnResult to which the payloads to delete belongs. </param>
        /// <param name="pathSid"> The Twilio-provided string that uniquely identifies the Recording AddOnResult Payload resource to delete. </param>
        public DeletePayloadOptions(string pathReferenceSid, string pathAddOnResultSid, string pathSid)
        {
            PathReferenceSid = pathReferenceSid;
            PathAddOnResultSid = pathAddOnResultSid;
            PathSid = pathSid;
        }

        
        /// <summary> Generate the necessary parameters </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            return p;
        }

    

    }


    /// <summary> Fetch an instance of a result payload </summary>
    public class FetchPayloadOptions : IOptions<PayloadResource>
    {
    
        ///<summary> The SID of the recording to which the AddOnResult resource that contains the payload to fetch belongs. </summary> 
        public string PathReferenceSid { get; }

        ///<summary> The SID of the AddOnResult to which the payload to fetch belongs. </summary> 
        public string PathAddOnResultSid { get; }

        ///<summary> The Twilio-provided string that uniquely identifies the Recording AddOnResult Payload resource to fetch. </summary> 
        public string PathSid { get; }

        ///<summary> The SID of the [Account](https://www.twilio.com/docs/iam/api/account) that created the Recording AddOnResult Payload resource to fetch. </summary> 
        public string PathAccountSid { get; set; }



        /// <summary> Construct a new FetchRecordingAddOnResultPayloadOptions </summary>
        /// <param name="pathReferenceSid"> The SID of the recording to which the AddOnResult resource that contains the payload to fetch belongs. </param>
        /// <param name="pathAddOnResultSid"> The SID of the AddOnResult to which the payload to fetch belongs. </param>
        /// <param name="pathSid"> The Twilio-provided string that uniquely identifies the Recording AddOnResult Payload resource to fetch. </param>
        public FetchPayloadOptions(string pathReferenceSid, string pathAddOnResultSid, string pathSid)
        {
            PathReferenceSid = pathReferenceSid;
            PathAddOnResultSid = pathAddOnResultSid;
            PathSid = pathSid;
        }

        
        /// <summary> Generate the necessary parameters </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            return p;
        }

    

    }


    /// <summary> Retrieve a list of payloads belonging to the AddOnResult </summary>
    public class ReadPayloadOptions : ReadOptions<PayloadResource>
    {
    
        ///<summary> The SID of the recording to which the AddOnResult resource that contains the payloads to read belongs. </summary> 
        public string PathReferenceSid { get; }

        ///<summary> The SID of the AddOnResult to which the payloads to read belongs. </summary> 
        public string PathAddOnResultSid { get; }

        ///<summary> The SID of the [Account](https://www.twilio.com/docs/iam/api/account) that created the Recording AddOnResult Payload resources to read. </summary> 
        public string PathAccountSid { get; set; }



        /// <summary> Construct a new ListRecordingAddOnResultPayloadOptions </summary>
        /// <param name="pathReferenceSid"> The SID of the recording to which the AddOnResult resource that contains the payloads to read belongs. </param>
        /// <param name="pathAddOnResultSid"> The SID of the AddOnResult to which the payloads to read belongs. </param>
        public ReadPayloadOptions(string pathReferenceSid, string pathAddOnResultSid)
        {
            PathReferenceSid = pathReferenceSid;
            PathAddOnResultSid = pathAddOnResultSid;
        }

        
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

}


/*
 * This code was generated by
 * ___ _ _ _ _ _    _ ____    ____ ____ _    ____ ____ _  _ ____ ____ ____ ___ __   __
 *  |  | | | | |    | |  | __ |  | |__| | __ | __ |___ |\ | |___ |__/ |__|  | |  | |__/
 *  |  |_|_| | |___ | |__|    |__| |  | |    |__] |___ | \| |___ |  \ |  |  | |__| |  \
 *
 * Twilio - Studio
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




namespace Twilio.Rest.Studio.V2.Flow.Execution
{
    /// <summary> Retrieve a Step. </summary>
    public class FetchExecutionStepOptions : IOptions<ExecutionStepResource>
    {
    
        ///<summary> The SID of the Flow with the Step to fetch. </summary> 
        public string PathFlowSid { get; }

        ///<summary> The SID of the Execution resource with the Step to fetch. </summary> 
        public string PathExecutionSid { get; }

        ///<summary> The SID of the ExecutionStep resource to fetch. </summary> 
        public string PathSid { get; }



        /// <summary> Construct a new FetchExecutionStepOptions </summary>
        /// <param name="pathFlowSid"> The SID of the Flow with the Step to fetch. </param>
        /// <param name="pathExecutionSid"> The SID of the Execution resource with the Step to fetch. </param>
        /// <param name="pathSid"> The SID of the ExecutionStep resource to fetch. </param>
        public FetchExecutionStepOptions(string pathFlowSid, string pathExecutionSid, string pathSid)
        {
            PathFlowSid = pathFlowSid;
            PathExecutionSid = pathExecutionSid;
            PathSid = pathSid;
        }

        
        /// <summary> Generate the necessary parameters </summary>
        public  List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            return p;
        }
        

    }


    /// <summary> Retrieve a list of all Steps for an Execution. </summary>
    public class ReadExecutionStepOptions : ReadOptions<ExecutionStepResource>
    {
    
        ///<summary> The SID of the Flow with the Steps to read. </summary> 
        public string PathFlowSid { get; }

        ///<summary> The SID of the Execution with the Steps to read. </summary> 
        public string PathExecutionSid { get; }



        /// <summary> Construct a new ListExecutionStepOptions </summary>
        /// <param name="pathFlowSid"> The SID of the Flow with the Steps to read. </param>
        /// <param name="pathExecutionSid"> The SID of the Execution with the Steps to read. </param>
        public ReadExecutionStepOptions(string pathFlowSid, string pathExecutionSid)
        {
            PathFlowSid = pathFlowSid;
            PathExecutionSid = pathExecutionSid;
        }

        
        /// <summary> Generate the necessary parameters </summary>
        public  override List<KeyValuePair<string, string>> GetParams()
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


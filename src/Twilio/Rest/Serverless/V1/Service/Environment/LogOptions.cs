/*
 * This code was generated by
 * ___ _ _ _ _ _    _ ____    ____ ____ _    ____ ____ _  _ ____ ____ ____ ___ __   __
 *  |  | | | | |    | |  | __ |  | |__| | __ | __ |___ |\ | |___ |__/ |__|  | |  | |__/
 *  |  |_|_| | |___ | |__|    |__| |  | |    |__] |___ | \| |___ |  \ |  |  | |__| |  \
 *
 * Twilio - Serverless
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




namespace Twilio.Rest.Serverless.V1.Service.Environment
{
    /// <summary> Retrieve a specific log. </summary>
    public class FetchLogOptions : IOptions<LogResource>
    {
    
        ///<summary> The SID of the Service to fetch the Log resource from. </summary> 
        public string PathServiceSid { get; }

        ///<summary> The SID of the environment with the Log resource to fetch. </summary> 
        public string PathEnvironmentSid { get; }

        ///<summary> The SID of the Log resource to fetch. </summary> 
        public string PathSid { get; }



        /// <summary> Construct a new FetchLogOptions </summary>
        /// <param name="pathServiceSid"> The SID of the Service to fetch the Log resource from. </param>
        /// <param name="pathEnvironmentSid"> The SID of the environment with the Log resource to fetch. </param>
        /// <param name="pathSid"> The SID of the Log resource to fetch. </param>

        public FetchLogOptions(string pathServiceSid, string pathEnvironmentSid, string pathSid)
        {
            PathServiceSid = pathServiceSid;
            PathEnvironmentSid = pathEnvironmentSid;
            PathSid = pathSid;
        }

        
        /// <summary> Generate the necessary parameters </summary>
        public  List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            return p;
        }
        

    }


    /// <summary> Retrieve a list of all logs. </summary>
    public class ReadLogOptions : ReadOptions<LogResource>
    {
    
        ///<summary> The SID of the Service to read the Log resource from. </summary> 
        public string PathServiceSid { get; }

        ///<summary> The SID of the environment with the Log resources to read. </summary> 
        public string PathEnvironmentSid { get; }

        ///<summary> The SID of the function whose invocation produced the Log resources to read. </summary> 
        public string FunctionSid { get; set; }

        ///<summary> The date/time (in GMT, ISO 8601) after which the Log resources must have been created. Defaults to 1 day prior to current date/time. </summary> 
        public DateTime? StartDate { get; set; }

        ///<summary> The date/time (in GMT, ISO 8601) before which the Log resources must have been created. Defaults to current date/time. </summary> 
        public DateTime? EndDate { get; set; }



        /// <summary> Construct a new ListLogOptions </summary>
        /// <param name="pathServiceSid"> The SID of the Service to read the Log resource from. </param>
        /// <param name="pathEnvironmentSid"> The SID of the environment with the Log resources to read. </param>

        public ReadLogOptions(string pathServiceSid, string pathEnvironmentSid)
        {
            PathServiceSid = pathServiceSid;
            PathEnvironmentSid = pathEnvironmentSid;
        }

        
        /// <summary> Generate the necessary parameters </summary>
        public  override List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            if (FunctionSid != null)
            {
                p.Add(new KeyValuePair<string, string>("FunctionSid", FunctionSid));
            }
            if (StartDate != null)
            {
                p.Add(new KeyValuePair<string, string>("StartDate", Serializers.DateTimeIso8601(StartDate)));
            }
            if (EndDate != null)
            {
                p.Add(new KeyValuePair<string, string>("EndDate", Serializers.DateTimeIso8601(EndDate)));
            }
            if (PageSize != null)
            {
                p.Add(new KeyValuePair<string, string>("PageSize", PageSize.ToString()));
            }
            return p;
        }
        

    }

}


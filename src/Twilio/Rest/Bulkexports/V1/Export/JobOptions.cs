/*
 * This code was generated by
 * ___ _ _ _ _ _    _ ____    ____ ____ _    ____ ____ _  _ ____ ____ ____ ___ __   __
 *  |  | | | | |    | |  | __ |  | |__| | __ | __ |___ |\ | |___ |__/ |__|  | |  | |__/
 *  |  |_|_| | |___ | |__|    |__| |  | |    |__] |___ | \| |___ |  \ |  |  | |__| |  \
 *
 * Twilio - Bulkexports
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




namespace Twilio.Rest.Bulkexports.V1.Export
{
    /// <summary> delete </summary>
    public class DeleteJobOptions : IOptions<JobResource>
    {
        
        ///<summary> The unique string that that we created to identify the Bulk Export job </summary> 
        public string PathJobSid { get; }



        /// <summary> Construct a new DeleteJobOptions </summary>
        /// <param name="pathJobSid"> The unique string that that we created to identify the Bulk Export job </param>

        public DeleteJobOptions(string pathJobSid)
        {
            PathJobSid = pathJobSid;
        }

        
        /// <summary> Generate the necessary parameters </summary>
        public  List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            return p;
        }
        

    }


    /// <summary> fetch </summary>
    public class FetchJobOptions : IOptions<JobResource>
    {
    
        ///<summary> The unique string that that we created to identify the Bulk Export job </summary> 
        public string PathJobSid { get; }



        /// <summary> Construct a new FetchJobOptions </summary>
        /// <param name="pathJobSid"> The unique string that that we created to identify the Bulk Export job </param>

        public FetchJobOptions(string pathJobSid)
        {
            PathJobSid = pathJobSid;
        }

        
        /// <summary> Generate the necessary parameters </summary>
        public  List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            return p;
        }
        

    }


}


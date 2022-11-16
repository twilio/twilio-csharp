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
    /// <summary> Fetch a specific Day. </summary>
    public class FetchDayOptions : IOptions<DayResource>
    {
    
        ///<summary> The type of communication – Messages, Calls, Conferences, and Participants </summary> 
        public string PathResourceType { get; }

        ///<summary> The ISO 8601 format date of the resources in the file, for a UTC day </summary> 
        public string PathDay { get; }



        /// <summary> Construct a new FetchDayOptions </summary>
        /// <param name="pathResourceType"> The type of communication – Messages, Calls, Conferences, and Participants </param>
        /// <param name="pathDay"> The ISO 8601 format date of the resources in the file, for a UTC day </param>
        public FetchDayOptions(string pathResourceType, string pathDay)
        {
            PathResourceType = pathResourceType;
            PathDay = pathDay;
        }

        
        /// <summary> Generate the necessary parameters </summary>
        public  List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            return p;
        }
        

    }


    /// <summary> Retrieve a list of all Days for a resource. </summary>
    public class ReadDayOptions : ReadOptions<DayResource>
    {
    
        ///<summary> The type of communication – Messages, Calls, Conferences, and Participants </summary> 
        public string PathResourceType { get; }



        /// <summary> Construct a new ListDayOptions </summary>
        /// <param name="pathResourceType"> The type of communication – Messages, Calls, Conferences, and Participants </param>
        public ReadDayOptions(string pathResourceType)
        {
            PathResourceType = pathResourceType;
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


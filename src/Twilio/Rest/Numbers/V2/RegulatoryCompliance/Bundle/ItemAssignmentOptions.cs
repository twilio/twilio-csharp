/*
 * This code was generated by
 * ___ _ _ _ _ _    _ ____    ____ ____ _    ____ ____ _  _ ____ ____ ____ ___ __   __
 *  |  | | | | |    | |  | __ |  | |__| | __ | __ |___ |\ | |___ |__/ |__|  | |  | |__/
 *  |  |_|_| | |___ | |__|    |__| |  | |    |__] |___ | \| |___ |  \ |  |  | |__| |  \
 *
 * Twilio - Numbers
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




namespace Twilio.Rest.Numbers.V2.RegulatoryCompliance.Bundle
{

    /// <summary> Create a new Assigned Item. </summary>
    public class CreateItemAssignmentOptions : IOptions<ItemAssignmentResource>
    {
        
        ///<summary> The unique string that we created to identify the Bundle resource. </summary> 
        public string PathBundleSid { get; }

        ///<summary> The SID of an object bag that holds information of the different items. </summary> 
        public string ObjectSid { get; }


        /// <summary> Construct a new CreateItemAssignmentOptions </summary>
        /// <param name="pathBundleSid"> The unique string that we created to identify the Bundle resource. </param>
        /// <param name="objectSid"> The SID of an object bag that holds information of the different items. </param>

        public CreateItemAssignmentOptions(string pathBundleSid, string objectSid)
        {
            PathBundleSid = pathBundleSid;
            ObjectSid = objectSid;
        }

        
        /// <summary> Generate the necessary parameters </summary>
        public  List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            if (ObjectSid != null)
            {
                p.Add(new KeyValuePair<string, string>("ObjectSid", ObjectSid));
            }
            return p;
        }
        

    }
    /// <summary> Remove an Assignment Item Instance. </summary>
    public class DeleteItemAssignmentOptions : IOptions<ItemAssignmentResource>
    {
        
        ///<summary> The unique string that we created to identify the Bundle resource. </summary> 
        public string PathBundleSid { get; }

        ///<summary> The unique string that we created to identify the Identity resource. </summary> 
        public string PathSid { get; }



        /// <summary> Construct a new DeleteItemAssignmentOptions </summary>
        /// <param name="pathBundleSid"> The unique string that we created to identify the Bundle resource. </param>
        /// <param name="pathSid"> The unique string that we created to identify the Identity resource. </param>

        public DeleteItemAssignmentOptions(string pathBundleSid, string pathSid)
        {
            PathBundleSid = pathBundleSid;
            PathSid = pathSid;
        }

        
        /// <summary> Generate the necessary parameters </summary>
        public  List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            return p;
        }
        

    }


    /// <summary> Fetch specific Assigned Item Instance. </summary>
    public class FetchItemAssignmentOptions : IOptions<ItemAssignmentResource>
    {
    
        ///<summary> The unique string that we created to identify the Bundle resource. </summary> 
        public string PathBundleSid { get; }

        ///<summary> The unique string that we created to identify the Identity resource. </summary> 
        public string PathSid { get; }



        /// <summary> Construct a new FetchItemAssignmentOptions </summary>
        /// <param name="pathBundleSid"> The unique string that we created to identify the Bundle resource. </param>
        /// <param name="pathSid"> The unique string that we created to identify the Identity resource. </param>

        public FetchItemAssignmentOptions(string pathBundleSid, string pathSid)
        {
            PathBundleSid = pathBundleSid;
            PathSid = pathSid;
        }

        
        /// <summary> Generate the necessary parameters </summary>
        public  List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            return p;
        }
        

    }


    /// <summary> Retrieve a list of all Assigned Items for an account. </summary>
    public class ReadItemAssignmentOptions : ReadOptions<ItemAssignmentResource>
    {
    
        ///<summary> The unique string that we created to identify the Bundle resource. </summary> 
        public string PathBundleSid { get; }



        /// <summary> Construct a new ListItemAssignmentOptions </summary>
        /// <param name="pathBundleSid"> The unique string that we created to identify the Bundle resource. </param>

        public ReadItemAssignmentOptions(string pathBundleSid)
        {
            PathBundleSid = pathBundleSid;
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


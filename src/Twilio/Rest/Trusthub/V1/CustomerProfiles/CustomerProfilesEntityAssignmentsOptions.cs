/*
 * This code was generated by
 * ___ _ _ _ _ _    _ ____    ____ ____ _    ____ ____ _  _ ____ ____ ____ ___ __   __
 *  |  | | | | |    | |  | __ |  | |__| | __ | __ |___ |\ | |___ |__/ |__|  | |  | |__/
 *  |  |_|_| | |___ | |__|    |__| |  | |    |__] |___ | \| |___ |  \ |  |  | |__| |  \
 *
 * Twilio - Trusthub
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




namespace Twilio.Rest.Trusthub.V1.CustomerProfiles
{

    /// <summary> Create a new Assigned Item. </summary>
    public class CreateCustomerProfilesEntityAssignmentsOptions : IOptions<CustomerProfilesEntityAssignmentsResource>
    {
        
        ///<summary> The unique string that we created to identify the CustomerProfile resource. </summary> 
        public string PathCustomerProfileSid { get; }

        ///<summary> The SID of an object bag that holds information of the different items. </summary> 
        public string ObjectSid { get; }


        /// <summary> Construct a new CreateCustomerProfileEntityAssignmentOptions </summary>
        /// <param name="pathCustomerProfileSid"> The unique string that we created to identify the CustomerProfile resource. </param>
        /// <param name="objectSid"> The SID of an object bag that holds information of the different items. </param>
        public CreateCustomerProfilesEntityAssignmentsOptions(string pathCustomerProfileSid, string objectSid)
        {
            PathCustomerProfileSid = pathCustomerProfileSid;
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
    public class DeleteCustomerProfilesEntityAssignmentsOptions : IOptions<CustomerProfilesEntityAssignmentsResource>
    {
        
        ///<summary> The unique string that we created to identify the CustomerProfile resource. </summary> 
        public string PathCustomerProfileSid { get; }

        ///<summary> The unique string that we created to identify the Identity resource. </summary> 
        public string PathSid { get; }



        /// <summary> Construct a new DeleteCustomerProfileEntityAssignmentOptions </summary>
        /// <param name="pathCustomerProfileSid"> The unique string that we created to identify the CustomerProfile resource. </param>
        /// <param name="pathSid"> The unique string that we created to identify the Identity resource. </param>
        public DeleteCustomerProfilesEntityAssignmentsOptions(string pathCustomerProfileSid, string pathSid)
        {
            PathCustomerProfileSid = pathCustomerProfileSid;
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
    public class FetchCustomerProfilesEntityAssignmentsOptions : IOptions<CustomerProfilesEntityAssignmentsResource>
    {
    
        ///<summary> The unique string that we created to identify the CustomerProfile resource. </summary> 
        public string PathCustomerProfileSid { get; }

        ///<summary> The unique string that we created to identify the Identity resource. </summary> 
        public string PathSid { get; }



        /// <summary> Construct a new FetchCustomerProfileEntityAssignmentOptions </summary>
        /// <param name="pathCustomerProfileSid"> The unique string that we created to identify the CustomerProfile resource. </param>
        /// <param name="pathSid"> The unique string that we created to identify the Identity resource. </param>
        public FetchCustomerProfilesEntityAssignmentsOptions(string pathCustomerProfileSid, string pathSid)
        {
            PathCustomerProfileSid = pathCustomerProfileSid;
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
    public class ReadCustomerProfilesEntityAssignmentsOptions : ReadOptions<CustomerProfilesEntityAssignmentsResource>
    {
    
        ///<summary> The unique string that we created to identify the CustomerProfile resource. </summary> 
        public string PathCustomerProfileSid { get; }



        /// <summary> Construct a new ListCustomerProfileEntityAssignmentOptions </summary>
        /// <param name="pathCustomerProfileSid"> The unique string that we created to identify the CustomerProfile resource. </param>
        public ReadCustomerProfilesEntityAssignmentsOptions(string pathCustomerProfileSid)
        {
            PathCustomerProfileSid = pathCustomerProfileSid;
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


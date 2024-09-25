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




namespace Twilio.Rest.Api.V2010.Account.IncomingPhoneNumber
{

    /// <summary> Assign an Add-on installation to the Number specified. </summary>
    public class CreateAssignedAddOnOptions : IOptions<AssignedAddOnResource>
    {
        
        ///<summary> The SID of the Phone Number to assign the Add-on. </summary> 
        public string PathResourceSid { get; }

        ///<summary> The SID that identifies the Add-on installation. </summary> 
        public string InstalledAddOnSid { get; }

        ///<summary> The SID of the [Account](https://www.twilio.com/docs/iam/api/account) that will create the resource. </summary> 
        public string PathAccountSid { get; set; }


        /// <summary> Construct a new CreateIncomingPhoneNumberAssignedAddOnOptions </summary>
        /// <param name="pathResourceSid"> The SID of the Phone Number to assign the Add-on. </param>
        /// <param name="installedAddOnSid"> The SID that identifies the Add-on installation. </param>
        public CreateAssignedAddOnOptions(string pathResourceSid, string installedAddOnSid)
        {
            PathResourceSid = pathResourceSid;
            InstalledAddOnSid = installedAddOnSid;
        }

        
        /// <summary> Generate the necessary parameters </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            if (InstalledAddOnSid != null)
            {
                p.Add(new KeyValuePair<string, string>("InstalledAddOnSid", InstalledAddOnSid));
            }
            return p;
        }

        

    }
    /// <summary> Remove the assignment of an Add-on installation from the Number specified. </summary>
    public class DeleteAssignedAddOnOptions : IOptions<AssignedAddOnResource>
    {
        
        ///<summary> The SID of the Phone Number to which the Add-on is assigned. </summary> 
        public string PathResourceSid { get; }

        ///<summary> The Twilio-provided string that uniquely identifies the resource to delete. </summary> 
        public string PathSid { get; }

        ///<summary> The SID of the [Account](https://www.twilio.com/docs/iam/api/account) that created the resources to delete. </summary> 
        public string PathAccountSid { get; set; }



        /// <summary> Construct a new DeleteIncomingPhoneNumberAssignedAddOnOptions </summary>
        /// <param name="pathResourceSid"> The SID of the Phone Number to which the Add-on is assigned. </param>
        /// <param name="pathSid"> The Twilio-provided string that uniquely identifies the resource to delete. </param>
        public DeleteAssignedAddOnOptions(string pathResourceSid, string pathSid)
        {
            PathResourceSid = pathResourceSid;
            PathSid = pathSid;
        }

        
        /// <summary> Generate the necessary parameters </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            return p;
        }

    

    }


    /// <summary> Fetch an instance of an Add-on installation currently assigned to this Number. </summary>
    public class FetchAssignedAddOnOptions : IOptions<AssignedAddOnResource>
    {
    
        ///<summary> The SID of the Phone Number to which the Add-on is assigned. </summary> 
        public string PathResourceSid { get; }

        ///<summary> The Twilio-provided string that uniquely identifies the resource to fetch. </summary> 
        public string PathSid { get; }

        ///<summary> The SID of the [Account](https://www.twilio.com/docs/iam/api/account) that created the resource to fetch. </summary> 
        public string PathAccountSid { get; set; }



        /// <summary> Construct a new FetchIncomingPhoneNumberAssignedAddOnOptions </summary>
        /// <param name="pathResourceSid"> The SID of the Phone Number to which the Add-on is assigned. </param>
        /// <param name="pathSid"> The Twilio-provided string that uniquely identifies the resource to fetch. </param>
        public FetchAssignedAddOnOptions(string pathResourceSid, string pathSid)
        {
            PathResourceSid = pathResourceSid;
            PathSid = pathSid;
        }

        
        /// <summary> Generate the necessary parameters </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            return p;
        }

    

    }


    /// <summary> Retrieve a list of Add-on installations currently assigned to this Number. </summary>
    public class ReadAssignedAddOnOptions : ReadOptions<AssignedAddOnResource>
    {
    
        ///<summary> The SID of the Phone Number to which the Add-on is assigned. </summary> 
        public string PathResourceSid { get; }

        ///<summary> The SID of the [Account](https://www.twilio.com/docs/iam/api/account) that created the resources to read. </summary> 
        public string PathAccountSid { get; set; }



        /// <summary> Construct a new ListIncomingPhoneNumberAssignedAddOnOptions </summary>
        /// <param name="pathResourceSid"> The SID of the Phone Number to which the Add-on is assigned. </param>
        public ReadAssignedAddOnOptions(string pathResourceSid)
        {
            PathResourceSid = pathResourceSid;
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


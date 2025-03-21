/*
 * This code was generated by
 * ___ _ _ _ _ _    _ ____    ____ ____ _    ____ ____ _  _ ____ ____ ____ ___ __   __
 *  |  | | | | |    | |  | __ |  | |__| | __ | __ |___ |\ | |___ |__/ |__|  | |  | |__/
 *  |  |_|_| | |___ | |__|    |__| |  | |    |__] |___ | \| |___ |  \ |  |  | |__| |  \
 *
 * Twilio - Marketplace
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




namespace Twilio.Rest.Marketplace.V1
{

    /// <summary> Install an Add-on for the Account specified. </summary>
    public class CreateInstalledAddOnOptions : IOptions<InstalledAddOnResource>
    {
        
        ///<summary> The SID of the AvaliableAddOn to install. </summary> 
        public string AvailableAddOnSid { get; }

        ///<summary> Whether the Terms of Service were accepted. </summary> 
        public bool? AcceptTermsOfService { get; }

        ///<summary> The JSON object that represents the configuration of the new Add-on being installed. </summary> 
        public object Configuration { get; set; }

        ///<summary> An application-defined string that uniquely identifies the resource. This value must be unique within the Account. </summary> 
        public string UniqueName { get; set; }


        /// <summary> Construct a new CreateInstalledAddOnOptions </summary>
        /// <param name="availableAddOnSid"> The SID of the AvaliableAddOn to install. </param>
        /// <param name="acceptTermsOfService"> Whether the Terms of Service were accepted. </param>
        public CreateInstalledAddOnOptions(string availableAddOnSid, bool? acceptTermsOfService)
        {
            AvailableAddOnSid = availableAddOnSid;
            AcceptTermsOfService = acceptTermsOfService;
        }

        
        /// <summary> Generate the necessary parameters </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            if (AvailableAddOnSid != null)
            {
                p.Add(new KeyValuePair<string, string>("AvailableAddOnSid", AvailableAddOnSid));
            }
            if (AcceptTermsOfService != null)
            {
                p.Add(new KeyValuePair<string, string>("AcceptTermsOfService", AcceptTermsOfService.Value.ToString().ToLower()));
            }
            if (Configuration != null)
            {
                p.Add(new KeyValuePair<string, string>("Configuration", Serializers.JsonObject(Configuration)));
            }
            if (UniqueName != null)
            {
                p.Add(new KeyValuePair<string, string>("UniqueName", UniqueName));
            }
            return p;
        }

        

    }
    /// <summary> Remove an Add-on installation from your account </summary>
    public class DeleteInstalledAddOnOptions : IOptions<InstalledAddOnResource>
    {
        
        ///<summary> The SID of the InstalledAddOn resource to delete. </summary> 
        public string PathSid { get; }



        /// <summary> Construct a new DeleteInstalledAddOnOptions </summary>
        /// <param name="pathSid"> The SID of the InstalledAddOn resource to delete. </param>
        public DeleteInstalledAddOnOptions(string pathSid)
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


    /// <summary> Fetch an instance of an Add-on currently installed on this Account. </summary>
    public class FetchInstalledAddOnOptions : IOptions<InstalledAddOnResource>
    {
    
        ///<summary> The SID of the InstalledAddOn resource to fetch. </summary> 
        public string PathSid { get; }



        /// <summary> Construct a new FetchInstalledAddOnOptions </summary>
        /// <param name="pathSid"> The SID of the InstalledAddOn resource to fetch. </param>
        public FetchInstalledAddOnOptions(string pathSid)
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


    /// <summary> Retrieve a list of Add-ons currently installed on this Account. </summary>
    public class ReadInstalledAddOnOptions : ReadOptions<InstalledAddOnResource>
    {
    



        
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

    /// <summary> Update an Add-on installation for the Account specified. </summary>
    public class UpdateInstalledAddOnOptions : IOptions<InstalledAddOnResource>
    {
    
        ///<summary> The SID of the InstalledAddOn resource to update. </summary> 
        public string PathSid { get; }

        ///<summary> Valid JSON object that conform to the configuration schema exposed by the associated AvailableAddOn resource. This is only required by Add-ons that need to be configured </summary> 
        public object Configuration { get; set; }

        ///<summary> An application-defined string that uniquely identifies the resource. This value must be unique within the Account. </summary> 
        public string UniqueName { get; set; }



        /// <summary> Construct a new UpdateInstalledAddOnOptions </summary>
        /// <param name="pathSid"> The SID of the InstalledAddOn resource to update. </param>
        public UpdateInstalledAddOnOptions(string pathSid)
        {
            PathSid = pathSid;
        }

        
        /// <summary> Generate the necessary parameters </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            if (Configuration != null)
            {
                p.Add(new KeyValuePair<string, string>("Configuration", Serializers.JsonObject(Configuration)));
            }
            if (UniqueName != null)
            {
                p.Add(new KeyValuePair<string, string>("UniqueName", UniqueName));
            }
            return p;
        }

        

    }


}


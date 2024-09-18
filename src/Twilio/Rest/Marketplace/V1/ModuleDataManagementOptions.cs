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
    /// <summary> This endpoint returns the data of a given Listing. To find a Listing's SID, use the [Available Add-ons resource](/docs/marketplace/api/available-add-ons) or view its Listing details page in the Console by visiting the [Catalog](https://console.twilio.com/us1/develop/add-ons/catalog) or the [My Listings tab](https://console.twilio.com/us1/develop/add-ons/publish/my-listings) and selecting the Listing. </summary>
    public class FetchModuleDataManagementOptions : IOptions<ModuleDataManagementResource>
    {
    
        ///<summary> The unique identifier of a Listing. </summary> 
        public string PathSid { get; }



        /// <summary> Construct a new FetchModuleDataManagementOptions </summary>
        /// <param name="pathSid"> The unique identifier of a Listing. </param>
        public FetchModuleDataManagementOptions(string pathSid)
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


    /// <summary> This endpoint updates the data of a given Listing. To find a Listing's SID, use the [Available Add-ons resource](https://www.twilio.com/docs/marketplace/api/available-add-ons) or view its Listing details page in the Console by visiting the [Catalog](https://console.twilio.com/us1/develop/add-ons/catalog) or the [My Listings tab](https://console.twilio.com/us1/develop/add-ons/publish/my-listings) and selecting the Listing. Only Listing owners are allowed to update the Listing. </summary>
    public class UpdateModuleDataManagementOptions : IOptions<ModuleDataManagementResource>
    {
    
        ///<summary> SID that uniquely identifies the Listing. </summary> 
        public string PathSid { get; }

        ///<summary> A JSON object containing essential attributes that define a Listing. </summary> 
        public string ModuleInfo { get; set; }

        ///<summary> A JSON object describing the Listing. You can define the main body of the description, highlight key features or aspects of the Listing, and provide code samples for developers if applicable. </summary> 
        public string Description { get; set; }

        ///<summary> A JSON object for providing comprehensive information, instructions, and resources related to the Listing. </summary> 
        public string Documentation { get; set; }

        ///<summary> A JSON object describing the Listing's privacy and legal policies. The maximum file size for Policies is 5MB. </summary> 
        public string Policies { get; set; }

        ///<summary> A JSON object containing information on how Marketplace users can obtain support for the Listing. Use this parameter to provide details such as contact information and support description. </summary> 
        public string Support { get; set; }

        ///<summary> A JSON object for providing Listing-specific configuration. Contains button setup, notification URL, and more. </summary> 
        public string Configuration { get; set; }

        ///<summary> A JSON object for providing Listing's purchase options. </summary> 
        public string Pricing { get; set; }



        /// <summary> Construct a new UpdateModuleDataManagementOptions </summary>
        /// <param name="pathSid"> SID that uniquely identifies the Listing. </param>
        public UpdateModuleDataManagementOptions(string pathSid)
        {
            PathSid = pathSid;
        }

        
        /// <summary> Generate the necessary parameters </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            if (ModuleInfo != null)
            {
                p.Add(new KeyValuePair<string, string>("ModuleInfo", ModuleInfo));
            }
            if (Description != null)
            {
                p.Add(new KeyValuePair<string, string>("Description", Description));
            }
            if (Documentation != null)
            {
                p.Add(new KeyValuePair<string, string>("Documentation", Documentation));
            }
            if (Policies != null)
            {
                p.Add(new KeyValuePair<string, string>("Policies", Policies));
            }
            if (Support != null)
            {
                p.Add(new KeyValuePair<string, string>("Support", Support));
            }
            if (Configuration != null)
            {
                p.Add(new KeyValuePair<string, string>("Configuration", Configuration));
            }
            if (Pricing != null)
            {
                p.Add(new KeyValuePair<string, string>("Pricing", Pricing));
            }
            return p;
        }

        

    }


}


/*
 * This code was generated by
 * ___ _ _ _ _ _    _ ____    ____ ____ _    ____ ____ _  _ ____ ____ ____ ___ __   __
 *  |  | | | | |    | |  | __ |  | |__| | __ | __ |___ |\ | |___ |__/ |__|  | |  | |__/
 *  |  |_|_| | |___ | |__|    |__| |  | |    |__] |___ | \| |___ |  \ |  |  | |__| |  \
 *
 * Twilio - Iam
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




namespace Twilio.Rest.Iam.V1
{
    /// <summary> Delete a specific Key. </summary>
    public class DeleteApiKeyOptions : IOptions<ApiKeyResource>
    {
        
        ///<summary> The Twilio-provided string that uniquely identifies the Key resource to delete. </summary> 
        public string PathSid { get; }



        /// <summary> Construct a new DeleteKeyOptions </summary>
        /// <param name="pathSid"> The Twilio-provided string that uniquely identifies the Key resource to delete. </param>
        public DeleteApiKeyOptions(string pathSid)
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


    /// <summary> Fetch a specific Key. </summary>
    public class FetchApiKeyOptions : IOptions<ApiKeyResource>
    {
    
        ///<summary> The Twilio-provided string that uniquely identifies the Key resource to fetch. </summary> 
        public string PathSid { get; }



        /// <summary> Construct a new FetchKeyOptions </summary>
        /// <param name="pathSid"> The Twilio-provided string that uniquely identifies the Key resource to fetch. </param>
        public FetchApiKeyOptions(string pathSid)
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


    /// <summary> Update a specific Key. </summary>
    public class UpdateApiKeyOptions : IOptions<ApiKeyResource>
    {
    
        ///<summary> The Twilio-provided string that uniquely identifies the Key resource to update. </summary> 
        public string PathSid { get; }

        ///<summary> A descriptive string that you create to describe the resource. It can be up to 64 characters long. </summary> 
        public string FriendlyName { get; set; }

        ///<summary> The \\\\`Policy\\\\` object is a collection that specifies the allowed Twilio permissions for the restricted key. For more information on the permissions available with restricted API keys, refer to the [Twilio documentation](https://www.twilio.com/docs/iam/api-keys/restricted-api-keys#permissions-available-with-restricted-api-keys). </summary> 
        public object Policy { get; set; }



        /// <summary> Construct a new UpdateKeyOptions </summary>
        /// <param name="pathSid"> The Twilio-provided string that uniquely identifies the Key resource to update. </param>
        public UpdateApiKeyOptions(string pathSid)
        {
            PathSid = pathSid;
        }

        
        /// <summary> Generate the necessary parameters </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            if (FriendlyName != null)
            {
                p.Add(new KeyValuePair<string, string>("FriendlyName", FriendlyName));
            }
            if (Policy != null)
            {
                p.Add(new KeyValuePair<string, string>("Policy", Serializers.JsonObject(Policy)));
            }
            return p;
        }

        

    }


}


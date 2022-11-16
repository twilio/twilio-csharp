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




namespace Twilio.Rest.Serverless.V1
{

    /// <summary> Create a new Service resource. </summary>
    public class CreateServiceOptions : IOptions<ServiceResource>
    {
        
        ///<summary> A user-defined string that uniquely identifies the Service resource. It can be used as an alternative to the `sid` in the URL path to address the Service resource. This value must be 50 characters or less in length and be unique. </summary> 
        public string UniqueName { get; }

        ///<summary> A descriptive string that you create to describe the Service resource. It can be a maximum of 255 characters. </summary> 
        public string FriendlyName { get; }

        ///<summary> Whether to inject Account credentials into a function invocation context. The default value is `true`. </summary> 
        public bool? IncludeCredentials { get; set; }

        ///<summary> Whether the Service's properties and subresources can be edited via the UI. The default value is `false`. </summary> 
        public bool? UiEditable { get; set; }


        /// <summary> Construct a new CreateServiceOptions </summary>
        /// <param name="uniqueName"> A user-defined string that uniquely identifies the Service resource. It can be used as an alternative to the `sid` in the URL path to address the Service resource. This value must be 50 characters or less in length and be unique. </param>
        /// <param name="friendlyName"> A descriptive string that you create to describe the Service resource. It can be a maximum of 255 characters. </param>

        public CreateServiceOptions(string uniqueName, string friendlyName)
        {
            UniqueName = uniqueName;
            FriendlyName = friendlyName;
        }

        
        /// <summary> Generate the necessary parameters </summary>
        public  List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            if (UniqueName != null)
            {
                p.Add(new KeyValuePair<string, string>("UniqueName", UniqueName));
            }
            if (FriendlyName != null)
            {
                p.Add(new KeyValuePair<string, string>("FriendlyName", FriendlyName));
            }
            if (IncludeCredentials != null)
            {
                p.Add(new KeyValuePair<string, string>("IncludeCredentials", IncludeCredentials.Value.ToString().ToLower()));
            }
            if (UiEditable != null)
            {
                p.Add(new KeyValuePair<string, string>("UiEditable", UiEditable.Value.ToString().ToLower()));
            }
            return p;
        }
        

    }
    /// <summary> Delete a Service resource. </summary>
    public class DeleteServiceOptions : IOptions<ServiceResource>
    {
        
        ///<summary> The `sid` or `unique_name` of the Service resource to delete. </summary> 
        public string PathSid { get; }



        /// <summary> Construct a new DeleteServiceOptions </summary>
        /// <param name="pathSid"> The `sid` or `unique_name` of the Service resource to delete. </param>

        public DeleteServiceOptions(string pathSid)
        {
            PathSid = pathSid;
        }

        
        /// <summary> Generate the necessary parameters </summary>
        public  List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            return p;
        }
        

    }


    /// <summary> Retrieve a specific Service resource. </summary>
    public class FetchServiceOptions : IOptions<ServiceResource>
    {
    
        ///<summary> The `sid` or `unique_name` of the Service resource to fetch. </summary> 
        public string PathSid { get; }



        /// <summary> Construct a new FetchServiceOptions </summary>
        /// <param name="pathSid"> The `sid` or `unique_name` of the Service resource to fetch. </param>

        public FetchServiceOptions(string pathSid)
        {
            PathSid = pathSid;
        }

        
        /// <summary> Generate the necessary parameters </summary>
        public  List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            return p;
        }
        

    }


    /// <summary> Retrieve a list of all Services. </summary>
    public class ReadServiceOptions : ReadOptions<ServiceResource>
    {
    



        
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

    /// <summary> Update a specific Service resource. </summary>
    public class UpdateServiceOptions : IOptions<ServiceResource>
    {
    
        ///<summary> The `sid` or `unique_name` of the Service resource to update. </summary> 
        public string PathSid { get; }

        ///<summary> Whether to inject Account credentials into a function invocation context. </summary> 
        public bool? IncludeCredentials { get; set; }

        ///<summary> A descriptive string that you create to describe the Service resource. It can be a maximum of 255 characters. </summary> 
        public string FriendlyName { get; set; }

        ///<summary> Whether the Service resource's properties and subresources can be edited via the UI. The default value is `false`. </summary> 
        public bool? UiEditable { get; set; }



        /// <summary> Construct a new UpdateServiceOptions </summary>
        /// <param name="pathSid"> The `sid` or `unique_name` of the Service resource to update. </param>

        public UpdateServiceOptions(string pathSid)
        {
            PathSid = pathSid;
        }

        
        /// <summary> Generate the necessary parameters </summary>
        public  List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            if (IncludeCredentials != null)
            {
                p.Add(new KeyValuePair<string, string>("IncludeCredentials", IncludeCredentials.Value.ToString().ToLower()));
            }
            if (FriendlyName != null)
            {
                p.Add(new KeyValuePair<string, string>("FriendlyName", FriendlyName));
            }
            if (UiEditable != null)
            {
                p.Add(new KeyValuePair<string, string>("UiEditable", UiEditable.Value.ToString().ToLower()));
            }
            return p;
        }
        

    }


}


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
using System.Linq;



namespace Twilio.Rest.Serverless.V1.Service
{

    /// <summary> Create a new Build resource. At least one function version or asset version is required. </summary>
    public class CreateBuildOptions : IOptions<BuildResource>
    {
        
        ///<summary> The SID of the Service to create the Build resource under. </summary> 
        public string PathServiceSid { get; }

        ///<summary> The list of Asset Version resource SIDs to include in the Build. </summary> 
        public List<string> AssetVersions { get; set; }

        ///<summary> The list of the Function Version resource SIDs to include in the Build. </summary> 
        public List<string> FunctionVersions { get; set; }

        ///<summary> A list of objects that describe the Dependencies included in the Build. Each object contains the `name` and `version` of the dependency. </summary> 
        public string Dependencies { get; set; }

        ///<summary> The Runtime version that will be used to run the Build resource when it is deployed. </summary> 
        public string Runtime { get; set; }


        /// <summary> Construct a new CreateBuildOptions </summary>
        /// <param name="pathServiceSid"> The SID of the Service to create the Build resource under. </param>

        public CreateBuildOptions(string pathServiceSid)
        {
            PathServiceSid = pathServiceSid;
            AssetVersions = new List<string>();
            FunctionVersions = new List<string>();
        }

        
        /// <summary> Generate the necessary parameters </summary>
        public  List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            if (AssetVersions != null)
            {
                p.AddRange(AssetVersions.Select(AssetVersions => new KeyValuePair<string, string>("AssetVersions", AssetVersions)));
            }
            if (FunctionVersions != null)
            {
                p.AddRange(FunctionVersions.Select(FunctionVersions => new KeyValuePair<string, string>("FunctionVersions", FunctionVersions)));
            }
            if (Dependencies != null)
            {
                p.Add(new KeyValuePair<string, string>("Dependencies", Dependencies));
            }
            if (Runtime != null)
            {
                p.Add(new KeyValuePair<string, string>("Runtime", Runtime));
            }
            return p;
        }
        

    }
    /// <summary> Delete a Build resource. </summary>
    public class DeleteBuildOptions : IOptions<BuildResource>
    {
        
        ///<summary> The SID of the Service to delete the Build resource from. </summary> 
        public string PathServiceSid { get; }

        ///<summary> The SID of the Build resource to delete. </summary> 
        public string PathSid { get; }



        /// <summary> Construct a new DeleteBuildOptions </summary>
        /// <param name="pathServiceSid"> The SID of the Service to delete the Build resource from. </param>
        /// <param name="pathSid"> The SID of the Build resource to delete. </param>

        public DeleteBuildOptions(string pathServiceSid, string pathSid)
        {
            PathServiceSid = pathServiceSid;
            PathSid = pathSid;
        }

        
        /// <summary> Generate the necessary parameters </summary>
        public  List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            return p;
        }
        

    }


    /// <summary> Retrieve a specific Build resource. </summary>
    public class FetchBuildOptions : IOptions<BuildResource>
    {
    
        ///<summary> The SID of the Service to fetch the Build resource from. </summary> 
        public string PathServiceSid { get; }

        ///<summary> The SID of the Build resource to fetch. </summary> 
        public string PathSid { get; }



        /// <summary> Construct a new FetchBuildOptions </summary>
        /// <param name="pathServiceSid"> The SID of the Service to fetch the Build resource from. </param>
        /// <param name="pathSid"> The SID of the Build resource to fetch. </param>

        public FetchBuildOptions(string pathServiceSid, string pathSid)
        {
            PathServiceSid = pathServiceSid;
            PathSid = pathSid;
        }

        
        /// <summary> Generate the necessary parameters </summary>
        public  List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            return p;
        }
        

    }


    /// <summary> Retrieve a list of all Builds. </summary>
    public class ReadBuildOptions : ReadOptions<BuildResource>
    {
    
        ///<summary> The SID of the Service to read the Build resources from. </summary> 
        public string PathServiceSid { get; }



        /// <summary> Construct a new ListBuildOptions </summary>
        /// <param name="pathServiceSid"> The SID of the Service to read the Build resources from. </param>

        public ReadBuildOptions(string pathServiceSid)
        {
            PathServiceSid = pathServiceSid;
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


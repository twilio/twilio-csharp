/*
 * This code was generated by
 * ___ _ _ _ _ _    _ ____    ____ ____ _    ____ ____ _  _ ____ ____ ____ ___ __   __
 *  |  | | | | |    | |  | __ |  | |__| | __ | __ |___ |\ | |___ |__/ |__|  | |  | |__/
 *  |  |_|_| | |___ | |__|    |__| |  | |    |__] |___ | \| |___ |  \ |  |  | |__| |  \
 *
 * Twilio - Supersim
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



namespace Twilio.Rest.Supersim.V1
{

    /// <summary> Create a new Network Access Profile </summary>
    public class CreateNetworkAccessProfileOptions : IOptions<NetworkAccessProfileResource>
    {
        
        ///<summary> An application-defined string that uniquely identifies the resource. It can be used in place of the resource's `sid` in the URL to address the resource. </summary> 
        public string UniqueName { get; set; }

        ///<summary> List of Network SIDs that this Network Access Profile will allow connections to. </summary> 
        public List<string> Networks { get; set; }



        
        /// <summary> Generate the necessary parameters </summary>
        public  List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            if (UniqueName != null)
            {
                p.Add(new KeyValuePair<string, string>("UniqueName", UniqueName));
            }
            if (Networks != null)
            {
                p.AddRange(Networks.Select(Networks => new KeyValuePair<string, string>("Networks", Networks)));
            }
            return p;
        }
        

    }
    /// <summary> Fetch a Network Access Profile instance from your account. </summary>
    public class FetchNetworkAccessProfileOptions : IOptions<NetworkAccessProfileResource>
    {
    
        ///<summary> The SID of the Network Access Profile resource to fetch. </summary> 
        public string PathSid { get; }



        /// <summary> Construct a new FetchNetworkAccessProfileOptions </summary>
        /// <param name="pathSid"> The SID of the Network Access Profile resource to fetch. </param>

        public FetchNetworkAccessProfileOptions(string pathSid)
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


    /// <summary> Retrieve a list of Network Access Profiles from your account. </summary>
    public class ReadNetworkAccessProfileOptions : ReadOptions<NetworkAccessProfileResource>
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

    /// <summary> Updates the given properties of a Network Access Profile in your account. </summary>
    public class UpdateNetworkAccessProfileOptions : IOptions<NetworkAccessProfileResource>
    {
    
        ///<summary> The SID of the Network Access Profile to update. </summary> 
        public string PathSid { get; }

        ///<summary> The new unique name of the Network Access Profile. </summary> 
        public string UniqueName { get; set; }



        /// <summary> Construct a new UpdateNetworkAccessProfileOptions </summary>
        /// <param name="pathSid"> The SID of the Network Access Profile to update. </param>

        public UpdateNetworkAccessProfileOptions(string pathSid)
        {
            PathSid = pathSid;
        }

        
        /// <summary> Generate the necessary parameters </summary>
        public  List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            if (UniqueName != null)
            {
                p.Add(new KeyValuePair<string, string>("UniqueName", UniqueName));
            }
            return p;
        }
        

    }


}


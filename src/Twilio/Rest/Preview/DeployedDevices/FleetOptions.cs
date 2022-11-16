/*
 * This code was generated by
 * ___ _ _ _ _ _    _ ____    ____ ____ _    ____ ____ _  _ ____ ____ ____ ___ __   __
 *  |  | | | | |    | |  | __ |  | |__| | __ | __ |___ |\ | |___ |__/ |__|  | |  | |__/
 *  |  |_|_| | |___ | |__|    |__| |  | |    |__] |___ | \| |___ |  \ |  |  | |__| |  \
 *
 * Twilio - Preview
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




namespace Twilio.Rest.Preview.DeployedDevices
{

    /// <summary> Create a new Fleet for scoping of deployed devices within your account. </summary>
    public class CreateFleetOptions : IOptions<FleetResource>
    {
        
        ///<summary> Provides a human readable descriptive text for this Fleet, up to 256 characters long. </summary> 
        public string FriendlyName { get; set; }



        
        /// <summary> Generate the necessary parameters </summary>
        public  List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            if (FriendlyName != null)
            {
                p.Add(new KeyValuePair<string, string>("FriendlyName", FriendlyName));
            }
            return p;
        }
        

    }
    /// <summary> Delete a specific Fleet from your account, also destroys all nested resources: Devices, Deployments, Certificates, Keys. </summary>
    public class DeleteFleetOptions : IOptions<FleetResource>
    {
        
        ///<summary> Provides a 34 character string that uniquely identifies the requested Fleet resource. </summary> 
        public string PathSid { get; }



        /// <summary> Construct a new DeleteDeployedDevicesFleetOptions </summary>
        /// <param name="pathSid"> Provides a 34 character string that uniquely identifies the requested Fleet resource. </param>

        public DeleteFleetOptions(string pathSid)
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


    /// <summary> Fetch information about a specific Fleet in your account. </summary>
    public class FetchFleetOptions : IOptions<FleetResource>
    {
    
        ///<summary> Provides a 34 character string that uniquely identifies the requested Fleet resource. </summary> 
        public string PathSid { get; }



        /// <summary> Construct a new FetchDeployedDevicesFleetOptions </summary>
        /// <param name="pathSid"> Provides a 34 character string that uniquely identifies the requested Fleet resource. </param>

        public FetchFleetOptions(string pathSid)
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


    /// <summary> Retrieve a list of all Fleets belonging to your account. </summary>
    public class ReadFleetOptions : ReadOptions<FleetResource>
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

    /// <summary> Update the friendly name property of a specific Fleet in your account. </summary>
    public class UpdateFleetOptions : IOptions<FleetResource>
    {
    
        ///<summary> Provides a 34 character string that uniquely identifies the requested Fleet resource. </summary> 
        public string PathSid { get; }

        ///<summary> Provides a human readable descriptive text for this Fleet, up to 256 characters long. </summary> 
        public string FriendlyName { get; set; }

        ///<summary> Provides a string identifier of a Deployment that is going to be used as a default one for this Fleet. </summary> 
        public string DefaultDeploymentSid { get; set; }



        /// <summary> Construct a new UpdateDeployedDevicesFleetOptions </summary>
        /// <param name="pathSid"> Provides a 34 character string that uniquely identifies the requested Fleet resource. </param>

        public UpdateFleetOptions(string pathSid)
        {
            PathSid = pathSid;
        }

        
        /// <summary> Generate the necessary parameters </summary>
        public  List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            if (FriendlyName != null)
            {
                p.Add(new KeyValuePair<string, string>("FriendlyName", FriendlyName));
            }
            if (DefaultDeploymentSid != null)
            {
                p.Add(new KeyValuePair<string, string>("DefaultDeploymentSid", DefaultDeploymentSid));
            }
            return p;
        }
        

    }


}


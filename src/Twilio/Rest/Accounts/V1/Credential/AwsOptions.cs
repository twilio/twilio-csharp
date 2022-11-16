/*
 * This code was generated by
 * ___ _ _ _ _ _    _ ____    ____ ____ _    ____ ____ _  _ ____ ____ ____ ___ __   __
 *  |  | | | | |    | |  | __ |  | |__| | __ | __ |___ |\ | |___ |__/ |__|  | |  | |__/
 *  |  |_|_| | |___ | |__|    |__| |  | |    |__] |___ | \| |___ |  \ |  |  | |__| |  \
 *
 * Twilio - Accounts
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




namespace Twilio.Rest.Accounts.V1.Credential
{

    /// <summary> Create a new AWS Credential </summary>
    public class CreateAwsOptions : IOptions<AwsResource>
    {
        
        ///<summary> A string that contains the AWS access credentials in the format `<AWS_ACCESS_KEY_ID>:<AWS_SECRET_ACCESS_KEY>`. For example, `AKIAIOSFODNN7EXAMPLE:wJalrXUtnFEMI/K7MDENG/bPxRfiCYEXAMPLEKEY` </summary> 
        public string Credentials { get; }

        ///<summary> A descriptive string that you create to describe the resource. It can be up to 64 characters long. </summary> 
        public string FriendlyName { get; set; }

        ///<summary> The SID of the Subaccount that this Credential should be associated with. Must be a valid Subaccount of the account issuing the request. </summary> 
        public string AccountSid { get; set; }


        /// <summary> Construct a new CreateCredentialAwsOptions </summary>
        /// <param name="credentials"> A string that contains the AWS access credentials in the format `<AWS_ACCESS_KEY_ID>:<AWS_SECRET_ACCESS_KEY>`. For example, `AKIAIOSFODNN7EXAMPLE:wJalrXUtnFEMI/K7MDENG/bPxRfiCYEXAMPLEKEY` </param>
        public CreateAwsOptions(string credentials)
        {
            Credentials = credentials;
        }

        
        /// <summary> Generate the necessary parameters </summary>
        public  List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            if (Credentials != null)
            {
                p.Add(new KeyValuePair<string, string>("Credentials", Credentials));
            }
            if (FriendlyName != null)
            {
                p.Add(new KeyValuePair<string, string>("FriendlyName", FriendlyName));
            }
            if (AccountSid != null)
            {
                p.Add(new KeyValuePair<string, string>("AccountSid", AccountSid));
            }
            return p;
        }
        

    }
    /// <summary> Delete a Credential from your account </summary>
    public class DeleteAwsOptions : IOptions<AwsResource>
    {
        
        ///<summary> The Twilio-provided string that uniquely identifies the AWS resource to delete. </summary> 
        public string PathSid { get; }



        /// <summary> Construct a new DeleteCredentialAwsOptions </summary>
        /// <param name="pathSid"> The Twilio-provided string that uniquely identifies the AWS resource to delete. </param>
        public DeleteAwsOptions(string pathSid)
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


    /// <summary> Fetch the AWS credentials specified by the provided Credential Sid </summary>
    public class FetchAwsOptions : IOptions<AwsResource>
    {
    
        ///<summary> The Twilio-provided string that uniquely identifies the AWS resource to fetch. </summary> 
        public string PathSid { get; }



        /// <summary> Construct a new FetchCredentialAwsOptions </summary>
        /// <param name="pathSid"> The Twilio-provided string that uniquely identifies the AWS resource to fetch. </param>
        public FetchAwsOptions(string pathSid)
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


    /// <summary> Retrieves a collection of AWS Credentials belonging to the account used to make the request </summary>
    public class ReadAwsOptions : ReadOptions<AwsResource>
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

    /// <summary> Modify the properties of a given Account </summary>
    public class UpdateAwsOptions : IOptions<AwsResource>
    {
    
        ///<summary> The Twilio-provided string that uniquely identifies the AWS resource to update. </summary> 
        public string PathSid { get; }

        ///<summary> A descriptive string that you create to describe the resource. It can be up to 64 characters long. </summary> 
        public string FriendlyName { get; set; }



        /// <summary> Construct a new UpdateCredentialAwsOptions </summary>
        /// <param name="pathSid"> The Twilio-provided string that uniquely identifies the AWS resource to update. </param>
        public UpdateAwsOptions(string pathSid)
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
            return p;
        }
        

    }


}


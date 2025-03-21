/*
 * This code was generated by
 * ___ _ _ _ _ _    _ ____    ____ ____ _    ____ ____ _  _ ____ ____ ____ ___ __   __
 *  |  | | | | |    | |  | __ |  | |__| | __ | __ |___ |\ | |___ |__/ |__|  | |  | |__/
 *  |  |_|_| | |___ | |__|    |__| |  | |    |__] |___ | \| |___ |  \ |  |  | |__| |  \
 *
 * Twilio - Conversations
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




namespace Twilio.Rest.Conversations.V1
{

    /// <summary> Add a new push notification credential to your account </summary>
    public class CreateCredentialOptions : IOptions<CredentialResource>
    {
        
        
        public CredentialResource.PushTypeEnum Type { get; }

        ///<summary> A descriptive string that you create to describe the new resource. It can be up to 64 characters long. </summary> 
        public string FriendlyName { get; set; }

        ///<summary> [APN only] The URL encoded representation of the certificate. For example,  `- - - - -BEGIN CERTIFICATE- - - - - MIIFnTCCBIWgAwIBAgIIAjy9H849+E8wDQYJKoZIhvcNAQEF.....A== - - - - -END CERTIFICATE- - - - -`. </summary> 
        public string Certificate { get; set; }

        ///<summary> [APN only] The URL encoded representation of the private key. For example, `- - - - -BEGIN RSA PRIVATE KEY- - - - - MIIEpQIBAAKCAQEAuyf/lNrH9ck8DmNyo3fG... - - - - -END RSA PRIVATE KEY- - - - -`. </summary> 
        public string PrivateKey { get; set; }

        ///<summary> [APN only] Whether to send the credential to sandbox APNs. Can be `true` to send to sandbox APNs or `false` to send to production. </summary> 
        public bool? Sandbox { get; set; }

        ///<summary> [GCM only] The API key for the project that was obtained from the Google Developer console for your GCM Service application credential. </summary> 
        public string ApiKey { get; set; }

        ///<summary> [FCM only] The **Server key** of your project from the Firebase console, found under Settings / Cloud messaging. </summary> 
        public string Secret { get; set; }


        /// <summary> Construct a new CreateCredentialOptions </summary>
        /// <param name="type">  </param>
        public CreateCredentialOptions(CredentialResource.PushTypeEnum type)
        {
            Type = type;
        }

        
        /// <summary> Generate the necessary parameters </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            if (Type != null)
            {
                p.Add(new KeyValuePair<string, string>("Type", Type.ToString()));
            }
            if (FriendlyName != null)
            {
                p.Add(new KeyValuePair<string, string>("FriendlyName", FriendlyName));
            }
            if (Certificate != null)
            {
                p.Add(new KeyValuePair<string, string>("Certificate", Certificate));
            }
            if (PrivateKey != null)
            {
                p.Add(new KeyValuePair<string, string>("PrivateKey", PrivateKey));
            }
            if (Sandbox != null)
            {
                p.Add(new KeyValuePair<string, string>("Sandbox", Sandbox.Value.ToString().ToLower()));
            }
            if (ApiKey != null)
            {
                p.Add(new KeyValuePair<string, string>("ApiKey", ApiKey));
            }
            if (Secret != null)
            {
                p.Add(new KeyValuePair<string, string>("Secret", Secret));
            }
            return p;
        }

        

    }
    /// <summary> Remove a push notification credential from your account </summary>
    public class DeleteCredentialOptions : IOptions<CredentialResource>
    {
        
        ///<summary> A 34 character string that uniquely identifies this resource. </summary> 
        public string PathSid { get; }



        /// <summary> Construct a new DeleteCredentialOptions </summary>
        /// <param name="pathSid"> A 34 character string that uniquely identifies this resource. </param>
        public DeleteCredentialOptions(string pathSid)
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


    /// <summary> Fetch a push notification credential from your account </summary>
    public class FetchCredentialOptions : IOptions<CredentialResource>
    {
    
        ///<summary> A 34 character string that uniquely identifies this resource. </summary> 
        public string PathSid { get; }



        /// <summary> Construct a new FetchCredentialOptions </summary>
        /// <param name="pathSid"> A 34 character string that uniquely identifies this resource. </param>
        public FetchCredentialOptions(string pathSid)
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


    /// <summary> Retrieve a list of all push notification credentials on your account </summary>
    public class ReadCredentialOptions : ReadOptions<CredentialResource>
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

    /// <summary> Update an existing push notification credential on your account </summary>
    public class UpdateCredentialOptions : IOptions<CredentialResource>
    {
    
        ///<summary> A 34 character string that uniquely identifies this resource. </summary> 
        public string PathSid { get; }

        
        public CredentialResource.PushTypeEnum Type { get; set; }

        ///<summary> A descriptive string that you create to describe the new resource. It can be up to 64 characters long. </summary> 
        public string FriendlyName { get; set; }

        ///<summary> [APN only] The URL encoded representation of the certificate. For example,  `- - - - -BEGIN CERTIFICATE- - - - - MIIFnTCCBIWgAwIBAgIIAjy9H849+E8wDQYJKoZIhvcNAQEF.....A== - - - - -END CERTIFICATE- - - - -`. </summary> 
        public string Certificate { get; set; }

        ///<summary> [APN only] The URL encoded representation of the private key. For example, `- - - - -BEGIN RSA PRIVATE KEY- - - - - MIIEpQIBAAKCAQEAuyf/lNrH9ck8DmNyo3fG... - - - - -END RSA PRIVATE KEY- - - - -`. </summary> 
        public string PrivateKey { get; set; }

        ///<summary> [APN only] Whether to send the credential to sandbox APNs. Can be `true` to send to sandbox APNs or `false` to send to production. </summary> 
        public bool? Sandbox { get; set; }

        ///<summary> [GCM only] The API key for the project that was obtained from the Google Developer console for your GCM Service application credential. </summary> 
        public string ApiKey { get; set; }

        ///<summary> [FCM only] The **Server key** of your project from the Firebase console, found under Settings / Cloud messaging. </summary> 
        public string Secret { get; set; }



        /// <summary> Construct a new UpdateCredentialOptions </summary>
        /// <param name="pathSid"> A 34 character string that uniquely identifies this resource. </param>
        public UpdateCredentialOptions(string pathSid)
        {
            PathSid = pathSid;
        }

        
        /// <summary> Generate the necessary parameters </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            if (Type != null)
            {
                p.Add(new KeyValuePair<string, string>("Type", Type.ToString()));
            }
            if (FriendlyName != null)
            {
                p.Add(new KeyValuePair<string, string>("FriendlyName", FriendlyName));
            }
            if (Certificate != null)
            {
                p.Add(new KeyValuePair<string, string>("Certificate", Certificate));
            }
            if (PrivateKey != null)
            {
                p.Add(new KeyValuePair<string, string>("PrivateKey", PrivateKey));
            }
            if (Sandbox != null)
            {
                p.Add(new KeyValuePair<string, string>("Sandbox", Sandbox.Value.ToString().ToLower()));
            }
            if (ApiKey != null)
            {
                p.Add(new KeyValuePair<string, string>("ApiKey", ApiKey));
            }
            if (Secret != null)
            {
                p.Add(new KeyValuePair<string, string>("Secret", Secret));
            }
            return p;
        }

        

    }


}


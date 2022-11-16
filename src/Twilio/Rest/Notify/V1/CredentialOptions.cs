/*
 * This code was generated by
 * ___ _ _ _ _ _    _ ____    ____ ____ _    ____ ____ _  _ ____ ____ ____ ___ __   __
 *  |  | | | | |    | |  | __ |  | |__| | __ | __ |___ |\ | |___ |__/ |__|  | |  | |__/
 *  |  |_|_| | |___ | |__|    |__| |  | |    |__] |___ | \| |___ |  \ |  |  | |__| |  \
 *
 * Twilio - Notify
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




namespace Twilio.Rest.Notify.V1
{

    /// <summary> create </summary>
    public class CreateCredentialOptions : IOptions<CredentialResource>
    {
        
        
        public CredentialResource.PushServiceEnum Type { get; }

        ///<summary> A descriptive string that you create to describe the resource. It can be up to 64 characters long. </summary> 
        public string FriendlyName { get; set; }

        ///<summary> [APN only] The URL-encoded representation of the certificate. Strip everything outside of the headers, e.g. `- - - - -BEGIN CERTIFICATE- - - - -MIIFnTCCBIWgAwIBAgIIAjy9H849+E8wDQYJKoZIhvcNAQEFBQAwgZYxCzAJBgNV.....A==- - - - -END CERTIFICATE- - - - -` </summary> 
        public string Certificate { get; set; }

        ///<summary> [APN only] The URL-encoded representation of the private key. Strip everything outside of the headers, e.g. `- - - - -BEGIN RSA PRIVATE KEY- - - - -MIIEpQIBAAKCAQEAuyf/lNrH9ck8DmNyo3fGgvCI1l9s+cmBY3WIz+cUDqmxiieR\\\\n.- - - - -END RSA PRIVATE KEY- - - - -` </summary> 
        public string PrivateKey { get; set; }

        ///<summary> [APN only] Whether to send the credential to sandbox APNs. Can be `true` to send to sandbox APNs or `false` to send to production. </summary> 
        public bool? Sandbox { get; set; }

        ///<summary> [GCM only] The `Server key` of your project from Firebase console under Settings / Cloud messaging. </summary> 
        public string ApiKey { get; set; }

        ///<summary> [FCM only] The `Server key` of your project from Firebase console under Settings / Cloud messaging. </summary> 
        public string Secret { get; set; }


        /// <summary> Construct a new CreateCredentialOptions </summary>
        /// <param name="type">  </param>

        public CreateCredentialOptions(CredentialResource.PushServiceEnum type)
        {
            Type = type;
        }

        
        /// <summary> Generate the necessary parameters </summary>
        public  List<KeyValuePair<string, string>> GetParams()
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
    /// <summary> delete </summary>
    public class DeleteCredentialOptions : IOptions<CredentialResource>
    {
        
        ///<summary> The Twilio-provided string that uniquely identifies the Credential resource to delete. </summary> 
        public string PathSid { get; }



        /// <summary> Construct a new DeleteCredentialOptions </summary>
        /// <param name="pathSid"> The Twilio-provided string that uniquely identifies the Credential resource to delete. </param>

        public DeleteCredentialOptions(string pathSid)
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


    /// <summary> fetch </summary>
    public class FetchCredentialOptions : IOptions<CredentialResource>
    {
    
        ///<summary> The Twilio-provided string that uniquely identifies the Credential resource to fetch. </summary> 
        public string PathSid { get; }



        /// <summary> Construct a new FetchCredentialOptions </summary>
        /// <param name="pathSid"> The Twilio-provided string that uniquely identifies the Credential resource to fetch. </param>

        public FetchCredentialOptions(string pathSid)
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


    /// <summary> read </summary>
    public class ReadCredentialOptions : ReadOptions<CredentialResource>
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

    /// <summary> update </summary>
    public class UpdateCredentialOptions : IOptions<CredentialResource>
    {
    
        ///<summary> The Twilio-provided string that uniquely identifies the Credential resource to update. </summary> 
        public string PathSid { get; }

        ///<summary> A descriptive string that you create to describe the resource. It can be up to 64 characters long. </summary> 
        public string FriendlyName { get; set; }

        ///<summary> [APN only] The URL-encoded representation of the certificate. Strip everything outside of the headers, e.g. `- - - - -BEGIN CERTIFICATE- - - - -MIIFnTCCBIWgAwIBAgIIAjy9H849+E8wDQYJKoZIhvcNAQEFBQAwgZYxCzAJBgNV.....A==- - - - -END CERTIFICATE- - - - -` </summary> 
        public string Certificate { get; set; }

        ///<summary> [APN only] The URL-encoded representation of the private key. Strip everything outside of the headers, e.g. `- - - - -BEGIN RSA PRIVATE KEY- - - - -MIIEpQIBAAKCAQEAuyf/lNrH9ck8DmNyo3fGgvCI1l9s+cmBY3WIz+cUDqmxiieR\\\\n.- - - - -END RSA PRIVATE KEY- - - - -` </summary> 
        public string PrivateKey { get; set; }

        ///<summary> [APN only] Whether to send the credential to sandbox APNs. Can be `true` to send to sandbox APNs or `false` to send to production. </summary> 
        public bool? Sandbox { get; set; }

        ///<summary> [GCM only] The `Server key` of your project from Firebase console under Settings / Cloud messaging. </summary> 
        public string ApiKey { get; set; }

        ///<summary> [FCM only] The `Server key` of your project from Firebase console under Settings / Cloud messaging. </summary> 
        public string Secret { get; set; }



        /// <summary> Construct a new UpdateCredentialOptions </summary>
        /// <param name="pathSid"> The Twilio-provided string that uniquely identifies the Credential resource to update. </param>

        public UpdateCredentialOptions(string pathSid)
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


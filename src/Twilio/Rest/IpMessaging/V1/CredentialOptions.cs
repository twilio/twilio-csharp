/*
 * This code was generated by
 * ___ _ _ _ _ _    _ ____    ____ ____ _    ____ ____ _  _ ____ ____ ____ ___ __   __
 *  |  | | | | |    | |  | __ |  | |__| | __ | __ |___ |\ | |___ |__/ |__|  | |  | |__/
 *  |  |_|_| | |___ | |__|    |__| |  | |    |__] |___ | \| |___ |  \ |  |  | |__| |  \
 *
 * Twilio - Ip_messaging
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




namespace Twilio.Rest.IpMessaging.V1
{

    /// <summary> create </summary>
    public class CreateCredentialOptions : IOptions<CredentialResource>
    {
        
        
        public CredentialResource.PushServiceEnum Type { get; }

        
        public string FriendlyName { get; set; }

        
        public string Certificate { get; set; }

        
        public string PrivateKey { get; set; }

        
        public bool? Sandbox { get; set; }

        
        public string ApiKey { get; set; }

        
        public string Secret { get; set; }


        /// <summary> Construct a new CreateCredentialOptions </summary>
        /// <param name="type">  </param>
        public CreateCredentialOptions(CredentialResource.PushServiceEnum type)
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
    /// <summary> delete </summary>
    public class DeleteCredentialOptions : IOptions<CredentialResource>
    {
        
        
        public string PathSid { get; }



        /// <summary> Construct a new DeleteCredentialOptions </summary>
        /// <param name="pathSid">  </param>
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


    /// <summary> fetch </summary>
    public class FetchCredentialOptions : IOptions<CredentialResource>
    {
    
        
        public string PathSid { get; }



        /// <summary> Construct a new FetchCredentialOptions </summary>
        /// <param name="pathSid">  </param>
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


    /// <summary> read </summary>
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

    /// <summary> update </summary>
    public class UpdateCredentialOptions : IOptions<CredentialResource>
    {
    
        
        public string PathSid { get; }

        
        public string FriendlyName { get; set; }

        
        public string Certificate { get; set; }

        
        public string PrivateKey { get; set; }

        
        public bool? Sandbox { get; set; }

        
        public string ApiKey { get; set; }

        
        public string Secret { get; set; }



        /// <summary> Construct a new UpdateCredentialOptions </summary>
        /// <param name="pathSid">  </param>
        public UpdateCredentialOptions(string pathSid)
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


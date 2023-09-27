/*
 * This code was generated by
 * ___ _ _ _ _ _    _ ____    ____ ____ _    ____ ____ _  _ ____ ____ ____ ___ __   __
 *  |  | | | | |    | |  | __ |  | |__| | __ | __ |___ |\ | |___ |__/ |__|  | |  | |__/
 *  |  |_|_| | |___ | |__|    |__| |  | |    |__] |___ | \| |___ |  \ |  |  | |__| |  \
 *
 * Twilio - Microvisor
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




namespace Twilio.Rest.Microvisor.V1
{

    /// <summary> Create a secret for an Account. </summary>
    public class CreateAccountSecretOptions : IOptions<AccountSecretResource>
    {
        
        ///<summary> The secret key; up to 100 characters. </summary> 
        public string Key { get; }

        ///<summary> The secret value; up to 4096 characters. </summary> 
        public string Value { get; }


        /// <summary> Construct a new CreateAccountSecretOptions </summary>
        /// <param name="key"> The secret key; up to 100 characters. </param>
        /// <param name="value"> The secret value; up to 4096 characters. </param>
        public CreateAccountSecretOptions(string key, string value)
        {
            Key = key;
            Value = value;
        }

        
        /// <summary> Generate the necessary parameters </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            if (Key != null)
            {
                p.Add(new KeyValuePair<string, string>("Key", Key));
            }
            if (Value != null)
            {
                p.Add(new KeyValuePair<string, string>("Value", Value));
            }
            return p;
        }

        

    }
    /// <summary> Delete a secret for an Account. </summary>
    public class DeleteAccountSecretOptions : IOptions<AccountSecretResource>
    {
        
        ///<summary> The secret key; up to 100 characters. </summary> 
        public string PathKey { get; }



        /// <summary> Construct a new DeleteAccountSecretOptions </summary>
        /// <param name="pathKey"> The secret key; up to 100 characters. </param>
        public DeleteAccountSecretOptions(string pathKey)
        {
            PathKey = pathKey;
        }

        
        /// <summary> Generate the necessary parameters </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            return p;
        }

        

    }


    /// <summary> Retrieve a Secret for an Account. </summary>
    public class FetchAccountSecretOptions : IOptions<AccountSecretResource>
    {
    
        ///<summary> The secret key; up to 100 characters. </summary> 
        public string PathKey { get; }



        /// <summary> Construct a new FetchAccountSecretOptions </summary>
        /// <param name="pathKey"> The secret key; up to 100 characters. </param>
        public FetchAccountSecretOptions(string pathKey)
        {
            PathKey = pathKey;
        }

        
        /// <summary> Generate the necessary parameters </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            return p;
        }

        

    }


    /// <summary> Retrieve a list of all Secrets for an Account. </summary>
    public class ReadAccountSecretOptions : ReadOptions<AccountSecretResource>
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

    /// <summary> Update a secret for an Account. </summary>
    public class UpdateAccountSecretOptions : IOptions<AccountSecretResource>
    {
    
        ///<summary> The secret key; up to 100 characters. </summary> 
        public string PathKey { get; }

        ///<summary> The secret value; up to 4096 characters. </summary> 
        public string Value { get; }



        /// <summary> Construct a new UpdateAccountSecretOptions </summary>
        /// <param name="pathKey"> The secret key; up to 100 characters. </param>
        /// <param name="value"> The secret value; up to 4096 characters. </param>
        public UpdateAccountSecretOptions(string pathKey, string value)
        {
            PathKey = pathKey;
            Value = value;
        }

        
        /// <summary> Generate the necessary parameters </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            if (Value != null)
            {
                p.Add(new KeyValuePair<string, string>("Value", Value));
            }
            return p;
        }

        

    }


}


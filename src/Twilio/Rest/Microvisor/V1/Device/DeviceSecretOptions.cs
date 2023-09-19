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




namespace Twilio.Rest.Microvisor.V1.Device
{

    /// <summary> Create a secret for a Microvisor Device. </summary>
    public class CreateDeviceSecretOptions : IOptions<DeviceSecretResource>
    {
        
        ///<summary> A 34-character string that uniquely identifies the Device. </summary> 
        public string PathDeviceSid { get; }

        ///<summary> The secret key; up to 100 characters. </summary> 
        public string Key { get; }

        ///<summary> The secret value; up to 4096 characters. </summary> 
        public string Value { get; }


        /// <summary> Construct a new CreateDeviceSecretOptions </summary>
        /// <param name="pathDeviceSid"> A 34-character string that uniquely identifies the Device. </param>
        /// <param name="key"> The secret key; up to 100 characters. </param>
        /// <param name="value"> The secret value; up to 4096 characters. </param>
        public CreateDeviceSecretOptions(string pathDeviceSid, string key, string value)
        {
            PathDeviceSid = pathDeviceSid;
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
    /// <summary> Delete a secret for a Microvisor Device. </summary>
    public class DeleteDeviceSecretOptions : IOptions<DeviceSecretResource>
    {
        
        ///<summary> A 34-character string that uniquely identifies the Device. </summary> 
        public string PathDeviceSid { get; }

        ///<summary> The secret key; up to 100 characters. </summary> 
        public string PathKey { get; }



        /// <summary> Construct a new DeleteDeviceSecretOptions </summary>
        /// <param name="pathDeviceSid"> A 34-character string that uniquely identifies the Device. </param>
        /// <param name="pathKey"> The secret key; up to 100 characters. </param>
        public DeleteDeviceSecretOptions(string pathDeviceSid, string pathKey)
        {
            PathDeviceSid = pathDeviceSid;
            PathKey = pathKey;
        }

        
        /// <summary> Generate the necessary parameters </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            return p;
        }
        

    }


    /// <summary> Retrieve a Secret for a Device. </summary>
    public class FetchDeviceSecretOptions : IOptions<DeviceSecretResource>
    {
    
        ///<summary> A 34-character string that uniquely identifies the Device. </summary> 
        public string PathDeviceSid { get; }

        ///<summary> The secret key; up to 100 characters. </summary> 
        public string PathKey { get; }



        /// <summary> Construct a new FetchDeviceSecretOptions </summary>
        /// <param name="pathDeviceSid"> A 34-character string that uniquely identifies the Device. </param>
        /// <param name="pathKey"> The secret key; up to 100 characters. </param>
        public FetchDeviceSecretOptions(string pathDeviceSid, string pathKey)
        {
            PathDeviceSid = pathDeviceSid;
            PathKey = pathKey;
        }

        
        /// <summary> Generate the necessary parameters </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            return p;
        }
        

    }


    /// <summary> Retrieve a list of all Secrets for a Device. </summary>
    public class ReadDeviceSecretOptions : ReadOptions<DeviceSecretResource>
    {
    
        ///<summary> A 34-character string that uniquely identifies the Device. </summary> 
        public string PathDeviceSid { get; }



        /// <summary> Construct a new ListDeviceSecretOptions </summary>
        /// <param name="pathDeviceSid"> A 34-character string that uniquely identifies the Device. </param>
        public ReadDeviceSecretOptions(string pathDeviceSid)
        {
            PathDeviceSid = pathDeviceSid;
        }

        
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

    /// <summary> Update a secret for a Microvisor Device. </summary>
    public class UpdateDeviceSecretOptions : IOptions<DeviceSecretResource>
    {
    
        ///<summary> A 34-character string that uniquely identifies the Device. </summary> 
        public string PathDeviceSid { get; }

        ///<summary> The secret key; up to 100 characters. </summary> 
        public string PathKey { get; }

        ///<summary> The secret value; up to 4096 characters. </summary> 
        public string Value { get; }



        /// <summary> Construct a new UpdateDeviceSecretOptions </summary>
        /// <param name="pathDeviceSid"> A 34-character string that uniquely identifies the Device. </param>
        /// <param name="pathKey"> The secret key; up to 100 characters. </param>
        /// <param name="value"> The secret value; up to 4096 characters. </param>
        public UpdateDeviceSecretOptions(string pathDeviceSid, string pathKey, string value)
        {
            PathDeviceSid = pathDeviceSid;
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


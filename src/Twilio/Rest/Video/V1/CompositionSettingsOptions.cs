/*
 * This code was generated by
 * ___ _ _ _ _ _    _ ____    ____ ____ _    ____ ____ _  _ ____ ____ ____ ___ __   __
 *  |  | | | | |    | |  | __ |  | |__| | __ | __ |___ |\ | |___ |__/ |__|  | |  | |__/
 *  |  |_|_| | |___ | |__|    |__| |  | |    |__] |___ | \| |___ |  \ |  |  | |__| |  \
 *
 * Twilio - Video
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




namespace Twilio.Rest.Video.V1
{

    /// <summary> create </summary>
    public class CreateCompositionSettingsOptions : IOptions<CompositionSettingsResource>
    {
        
        ///<summary> A descriptive string that you create to describe the resource and show to the user in the console </summary> 
        public string FriendlyName { get; }

        ///<summary> The SID of the stored Credential resource. </summary> 
        public string AwsCredentialsSid { get; set; }

        ///<summary> The SID of the Public Key resource to use for encryption. </summary> 
        public string EncryptionKeySid { get; set; }

        ///<summary> The URL of the AWS S3 bucket where the compositions should be stored. We only support DNS-compliant URLs like `https://documentation-example-twilio-bucket/compositions`, where `compositions` is the path in which you want the compositions to be stored. This URL accepts only URI-valid characters, as described in the <a href='https://tools.ietf.org/html/rfc3986#section-2'>RFC 3986</a>. </summary> 
        public Uri AwsS3Url { get; set; }

        ///<summary> Whether all compositions should be written to the `aws_s3_url`. When `false`, all compositions are stored in our cloud. </summary> 
        public bool? AwsStorageEnabled { get; set; }

        ///<summary> Whether all compositions should be stored in an encrypted form. The default is `false`. </summary> 
        public bool? EncryptionEnabled { get; set; }


        /// <summary> Construct a new CreateCompositionSettingsOptions </summary>
        /// <param name="friendlyName"> A descriptive string that you create to describe the resource and show to the user in the console </param>

        public CreateCompositionSettingsOptions(string friendlyName)
        {
            FriendlyName = friendlyName;
        }

        
        /// <summary> Generate the necessary parameters </summary>
        public  List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            if (FriendlyName != null)
            {
                p.Add(new KeyValuePair<string, string>("FriendlyName", FriendlyName));
            }
            if (AwsCredentialsSid != null)
            {
                p.Add(new KeyValuePair<string, string>("AwsCredentialsSid", AwsCredentialsSid));
            }
            if (EncryptionKeySid != null)
            {
                p.Add(new KeyValuePair<string, string>("EncryptionKeySid", EncryptionKeySid));
            }
            if (AwsS3Url != null)
            {
                p.Add(new KeyValuePair<string, string>("AwsS3Url", Serializers.Url(AwsS3Url)));
            }
            if (AwsStorageEnabled != null)
            {
                p.Add(new KeyValuePair<string, string>("AwsStorageEnabled", AwsStorageEnabled.Value.ToString().ToLower()));
            }
            if (EncryptionEnabled != null)
            {
                p.Add(new KeyValuePair<string, string>("EncryptionEnabled", EncryptionEnabled.Value.ToString().ToLower()));
            }
            return p;
        }
        

    }
    /// <summary> fetch </summary>
    public class FetchCompositionSettingsOptions : IOptions<CompositionSettingsResource>
    {
    



        
        /// <summary> Generate the necessary parameters </summary>
        public  List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            return p;
        }
        

    }


}


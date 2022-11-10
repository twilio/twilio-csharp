/// This code was generated by
/// \ / _    _  _|   _  _
///  | (_)\/(_)(_|\/| |(/_  v1.0.0
///       /       /

using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Converters;

namespace Twilio.Rest.Oauth.V1
{

    /// <summary>
    /// Issues a new Access token (optionally identity_token & refresh_token) in exchange of Oauth grant
    /// </summary>
    public class CreateTokenOptions : IOptions<TokenResource>
    {
        /// <summary>
        /// A way of representing resource owner's to obtain access token
        /// </summary>
        public string GrantType { get; }
        /// <summary>
        /// A string that uniquely identifies this oauth app
        /// </summary>
        public string ClientSid { get; }
        /// <summary>
        /// The credential for confidential OAuth App
        /// </summary>
        public string ClientSecret { get; set; }
        /// <summary>
        /// Jwt token
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// The cryptographically generated code
        /// </summary>
        public string CodeVerifier { get; set; }
        /// <summary>
        /// Jwt token
        /// </summary>
        public string DeviceCode { get; set; }
        /// <summary>
        /// Jwt token
        /// </summary>
        public string RefreshToken { get; set; }
        /// <summary>
        /// An Id of device
        /// </summary>
        public string DeviceId { get; set; }

        /// <summary>
        /// Construct a new CreateTokenOptions
        /// </summary>
        /// <param name="grantType"> A way of representing resource owner's to obtain access token </param>
        /// <param name="clientSid"> A string that uniquely identifies this oauth app </param>
        public CreateTokenOptions(string grantType, string clientSid)
        {
            GrantType = grantType;
            ClientSid = clientSid;
        }

        /// <summary>
        /// Generate the necessary parameters
        /// </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();
            if (GrantType != null)
            {
                p.Add(new KeyValuePair<string, string>("GrantType", GrantType));
            }

            if (ClientSid != null)
            {
                p.Add(new KeyValuePair<string, string>("ClientSid", ClientSid));
            }

            if (ClientSecret != null)
            {
                p.Add(new KeyValuePair<string, string>("ClientSecret", ClientSecret));
            }

            if (Code != null)
            {
                p.Add(new KeyValuePair<string, string>("Code", Code));
            }

            if (CodeVerifier != null)
            {
                p.Add(new KeyValuePair<string, string>("CodeVerifier", CodeVerifier));
            }

            if (DeviceCode != null)
            {
                p.Add(new KeyValuePair<string, string>("DeviceCode", DeviceCode));
            }

            if (RefreshToken != null)
            {
                p.Add(new KeyValuePair<string, string>("RefreshToken", RefreshToken));
            }

            if (DeviceId != null)
            {
                p.Add(new KeyValuePair<string, string>("DeviceId", DeviceId));
            }

            return p;
        }
    }

}
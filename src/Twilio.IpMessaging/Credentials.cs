using System;
using RestSharp;
using RestSharp.Extensions;
using RestSharp.Validation;
using Twilio.IpMessaging.Model;

namespace Twilio.IpMessaging
{
    public partial class IpMessagingClient
    {
        /// <summary>
        /// Retrieves all the Credentials belonging to a Service Sid.
        /// </summary>
        /// <returns>List of Credentials</returns>
        public virtual CredentialResult ListCredentials()
        {
            var request = new RestRequest(Method.GET);
            request.Resource = "/Credentials";

            return Execute<CredentialResult>(request);
        }

        /// <summary>
        /// Retrieves the Credential by Credential Sid.
        /// </summary>
        /// <param name="credentialSid">Credential Sid</param>
        /// <returns>Credential</returns>
        public virtual Credential GetCredential(string credentialSid)
        {
            Require.Argument("CredentialSid", credentialSid);

            var request = new RestRequest(Method.GET);
            request.Resource = "/Credentials/{CredentialSid}";

            request.AddUrlSegment("CredentialSid", credentialSid);

            return Execute<Credential>(request);
        }

        /// <summary>
        /// Creates a Credential.
        /// </summary>
        /// <param name="type">Credential type</param>
        /// <param name="friendlyName">Friendly Name for the Credential</param>
        /// <param name="certificate">Certificate</param>
        /// <param name="privateKey">Private Key</param>
        /// <param name="sandbox">Flag denotes if it is Sandbox or not</param>
        /// <param name="apiKey">API Key</param>
        /// <returns>A new Credential</returns>
        public virtual Credential CreateCredential(string type,
            string friendlyName, string certificate, string privateKey,
            string sandbox, string apiKey)
        {
            Require.Argument("Type", type);

            var request = new RestRequest(Method.POST);
            request.Resource = "/Credentials";

            request.AddParameter("Type", type);
            request.AddParameter("FriendlyName", friendlyName);
            request.AddParameter("Certificate", certificate);
            request.AddParameter("PrivateKey", privateKey);
            request.AddParameter("Sandbox", sandbox);
            request.AddParameter("ApiKey", apiKey);

            return Execute<Credential>(request);
        }

        /// <summary>
        /// Updates a Credential.
        /// </summary>
        /// <param name="type">Credential type</param>
        /// <param name="friendlyName">Friendly Name for the Credential</param>
        /// <param name="certificate">Certificate</param>
        /// <param name="privateKey">Private Key</param>
        /// <param name="sandbox">Flag denotes if it is Sandbox or not</param>
        /// <param name="apiKey">API Key</param>
        /// <returns>Updated Credential</returns>
        public virtual Credential UpdateCredential(string credentialSid,
            string type, string friendlyName, string certificate,
            string privateKey, string sandbox, string apiKey)
        {
            Require.Argument("CredentialSid", credentialSid);
            Require.Argument("Type", type);

            var request = new RestRequest(Method.POST);
            request.Resource = "/Credentials/{CredentialSid}";

            request.AddUrlSegment("CredentialSid", credentialSid);

            request.AddParameter("Type", type);
            request.AddParameter("FriendlyName", friendlyName);
            request.AddParameter("Certificate", certificate);
            request.AddParameter("PrivateKey", privateKey);
            request.AddParameter("Sandbox", sandbox);
            request.AddParameter("ApiKey", apiKey);

            return Execute<Credential>(request);
        }

        /// <summary>
        /// Deletes a Credential identified by Credential Sid.
        /// </summary>
        /// <param name="credentialSid">Credential Sid</param>
        /// <returns>Credential deletion status</returns>
        public virtual DeleteStatus DeleteCredential(string credentialSid)
        {
            Require.Argument("CredentialSid", credentialSid);

            var request = new RestRequest(Method.DELETE);
            request.Resource = "/Credentials/{CredentialSid}";

            request.AddUrlSegment("CredentialSid", credentialSid);

            var response = Execute(request);
            return response.StatusCode == System.Net.HttpStatusCode.NoContent ?
                DeleteStatus.Success :
                DeleteStatus.Failed;
        }
    }
}

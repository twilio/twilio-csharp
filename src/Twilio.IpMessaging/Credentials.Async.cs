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
		public virtual void ListCredentials(Action<CredentialResult> callback)
        {
            var request = new RestRequest(Method.GET);
            request.Resource = "/Credentials";

            ExecuteAsync<CredentialResult>(request, (response) =>
              callback(response));
        }

        /// <summary>
        /// Retrieves the Credential by Credential Sid.
        /// </summary>
        /// <param name="credentialSid">Credential Sid</param>
        public virtual void GetCredential(string credentialSid,
            Action<Credential> callback)
        {
            Require.Argument("CredentialSid", credentialSid);

            var request = new RestRequest(Method.GET);
            request.Resource = "/Credentials/{CredentialSid}";

            request.AddUrlSegment("CredentialSid", credentialSid);

            ExecuteAsync<Credential>(request, (response) => callback(response));
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
        public virtual void CreateCredential(string type, 
            string friendlyName, string certificate, string privateKey,
            string sandbox, string apiKey, Action<Credential> callback)
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

            ExecuteAsync<Credential>(request, (response) => callback(response));
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
        public virtual void UpdateCredential(string credentialSid,
            string type, string friendlyName, string certificate,
            string privateKey, string sandbox, string apiKey,
            Action<Credential> callback)
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

            ExecuteAsync<Credential>(request, (response) => callback(response));
        }

        /// <summary>
        /// Deletes a Credential identified by Credential Sid.
        /// </summary>
        /// <param name="credentialSid">Credential Sid</param>
        public virtual void DeleteCredential(string credentialSid,
            Action<DeleteStatus> callback)
        {
            Require.Argument("CredentialSid", credentialSid);

            var request = new RestRequest(Method.DELETE);
            request.Resource = "/Credentials/{CredentialSid}";

            request.AddUrlSegment("CredentialSid", credentialSid);

            ExecuteAsync(request, (response) => { callback(
              response.StatusCode == System.Net.HttpStatusCode.NoContent ?
                DeleteStatus.Success :
                DeleteStatus.Failed); });
        }
    }
}

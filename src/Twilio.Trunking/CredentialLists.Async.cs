using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestSharp;
using RestSharp.Extensions;
using RestSharp.Validation;
using Twilio.Trunking.Model;

namespace Twilio.Trunking
{
    public partial class TrunkingClient
    {
        /// <summary>
        /// Lists the credentialLists.
        /// </summary>
        /// <param name="trunkSid">Trunk sid.</param>
		public virtual void ListCredentialLists(string trunkSid, Action<CredentialListResult> callback)
        {
            Require.Argument("TrunkSid", trunkSid);
            var request = new RestRequest();
            request.Resource = "Trunks/{TrunkSid}/CredentialLists";

            request.AddUrlSegment("TrunkSid", trunkSid);

            ExecuteAsync<CredentialListResult>(request, (response) => { callback(response); });
        }

        /// <summary>
        /// Associates a credentialList to the trunk by its unique ID.
        /// </summary>
        /// <param name="trunkSid">Trunk sid.</param>
        /// <param name="credentialListSid">CredentialList sid.</param>
		public virtual void AssociateCredentialList(string trunkSid, string credentialListSid, Action<CredentialList> callback)
        {
          Require.Argument("TrunkSid", trunkSid);
          Require.Argument("CredentialListSid", credentialListSid);

          var request = new RestRequest(Method.POST);
          request.Resource = "Trunks/{TrunkSid}/CredentialLists";

          request.AddUrlSegment("TrunkSid", trunkSid);
          request.AddParameter("CredentialListSid", credentialListSid);

          ExecuteAsync<CredentialList>(request, (response) => { callback(response); });
        }

        /// <summary>
        /// Remove an associated credentialList from the trunk.
        /// </summary>
        /// <param name="trunkSid">Trunk sid.</param>
        /// <param name="credentialListSid">CredentialList sid.</param>
		public virtual void DeleteCredentialList(string trunkSid, string credentialListSid, Action<DeleteStatus> callback)
        {
          Require.Argument("TrunkSid", trunkSid);
          Require.Argument("CredentialListSid", credentialListSid);

            var request = new RestRequest(Method.DELETE);
            request.Resource = "Trunks/{TrunkSid}/CredentialLists/{CredentialListSid}";

            request.AddUrlSegment("TrunkSid", trunkSid);
            request.AddParameter("CredentialListSid", credentialListSid, ParameterType.UrlSegment);
      			ExecuteAsync(request, (response) => { callback(response.StatusCode == System.Net.HttpStatusCode.NoContent ? DeleteStatus.Success : DeleteStatus.Failed); });
        }
    }
}

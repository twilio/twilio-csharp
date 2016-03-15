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
		public virtual CredentialListResult ListCredentialLists(string trunkSid)
        {
            Require.Argument("TrunkSid", trunkSid);
            var request = new RestRequest();
            request.Resource = "Trunks/{TrunkSid}/CredentialLists";
            request.AddUrlSegment("TrunkSid", trunkSid);
            return Execute<CredentialListResult>(request);
        }

        /// <summary>
        /// Associates a credentialList to the trunk by its unique ID.
        /// </summary>
        /// <param name="trunkSid">Trunk sid.</param>
        /// <param name="credentialListSid">CredentialList sid.</param>
		public virtual CredentialList AssociateCredentialList(string trunkSid, string credentialListSid)
        {
            Require.Argument("TrunkSid", trunkSid);
            Require.Argument("CredentialListSid", credentialListSid);

            var request = new RestRequest(Method.POST);
            request.Resource = "Trunks/{TrunkSid}/CredentialLists";

            request.AddUrlSegment("TrunkSid", trunkSid);
            request.AddParameter("CredentialListSid", credentialListSid);

            return Execute<CredentialList>(request);
        }

        /// <summary>
        /// Remove an associated credentialList from the trunk.
        /// </summary>
        /// <param name="trunkSid">Trunk sid.</param>
        /// <param name="credentialListSid">CredentialList sid.</param>
		public virtual DeleteStatus DeleteCredentialList(string trunkSid, string credentialListSid)
        {
            Require.Argument("TrunkSid", trunkSid);
            Require.Argument("CredentialListSid", credentialListSid);

            var request = new RestRequest(Method.DELETE);
            request.Resource = "Trunks/{TrunkSid}/CredentialLists/{CredentialListSid}";

            request.AddUrlSegment("TrunkSid", trunkSid);
            request.AddParameter("CredentialListSid", credentialListSid, ParameterType.UrlSegment);
            var response = Execute(request);
            return response.StatusCode == System.Net.HttpStatusCode.NoContent ? DeleteStatus.Success : DeleteStatus.Failed;
        }
    }
}

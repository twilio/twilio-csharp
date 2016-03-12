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
        /// Lists the ipAccessControlLists.
        /// </summary>
        /// <param name="trunkSid">Trunk sid.</param>
        [System.Obsolete("page parameter is scheduled for end of life https://www.twilio.com/engineering/2015/04/16/replacing-absolute-paging-with-relative-paging")]
		public virtual IpAccessControlListResult ListIpAccessControlLists(string trunkSid)
        {
            Require.Argument("TrunkSid", trunkSid);
            var request = new RestRequest();
            request.Resource = "Trunks/{TrunkSid}/IpAccessControlLists";
            request.AddUrlSegment("TrunkSid", trunkSid);
            return Execute<IpAccessControlListResult>(request);
        }

        /// <summary>
        /// Associates a ipAccessControlList to the trunk by its unique ID.
        /// </summary>
        /// <param name="trunkSid">Trunk sid.</param>
        /// <param name="ipAccessControlListSid">IpAccessControlList sid.</param>
        [System.Obsolete("page parameter is scheduled for end of life https://www.twilio.com/engineering/2015/04/16/replacing-absolute-paging-with-relative-paging")]
		public virtual IpAccessControlList AssociateIpAccessControlList(string trunkSid, string ipAccessControlListSid)
        {
            Require.Argument("TrunkSid", trunkSid);
            Require.Argument("IpAccessControlListSid", ipAccessControlListSid);

            var request = new RestRequest(Method.POST);
            request.Resource = "Trunks/{TrunkSid}/IpAccessControlLists";

            request.AddUrlSegment("TrunkSid", trunkSid);
            request.AddParameter("IpAccessControlListSid", ipAccessControlListSid);

            return Execute<IpAccessControlList>(request);
        }

        /// <summary>
        /// Remove an associated ipAccessControlList from the trunk.
        /// </summary>
        /// <param name="trunkSid">Trunk sid.</param>
        /// <param name="ipAccessControlListSid">IpAccessControlList sid.</param>
        [System.Obsolete("page parameter is scheduled for end of life https://www.twilio.com/engineering/2015/04/16/replacing-absolute-paging-with-relative-paging")]
		public virtual DeleteStatus DeleteIpAccessControlList(string trunkSid, string ipAccessControlListSid)
        {
            Require.Argument("TrunkSid", trunkSid);
            Require.Argument("IpAccessControlListSid", ipAccessControlListSid);

            var request = new RestRequest(Method.DELETE);
            request.Resource = "Trunks/{TrunkSid}/IpAccessControlLists/{IpAccessControlListSid}";

            request.AddUrlSegment("TrunkSid", trunkSid);
            request.AddParameter("IpAccessControlListSid", ipAccessControlListSid, ParameterType.UrlSegment);
            var response = Execute(request);
            return response.StatusCode == System.Net.HttpStatusCode.NoContent ? DeleteStatus.Success : DeleteStatus.Failed;
        }
    }
}

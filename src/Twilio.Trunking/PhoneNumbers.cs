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
        /// Lists the phoneNumbers.
        /// </summary>
        /// <param name="trunkSid">Trunk sid.</param>
		public virtual PhoneNumberResult ListPhoneNumbers(string trunkSid)
        {
            Require.Argument("TrunkSid", trunkSid);
            var request = new RestRequest();
            request.Resource = "Trunks/{TrunkSid}/PhoneNumbers";
            request.AddUrlSegment("TrunkSid", trunkSid);
            return Execute<PhoneNumberResult>(request);
        }

        /// <summary>
        /// Associates a phoneNumber to the trunk by its unique ID.
        /// </summary>
        /// <param name="trunkSid">Trunk sid.</param>
        /// <param name="phoneNumberSid">PhoneNumber sid.</param>
        public virtual AssociatedPhoneNumber AssociatePhoneNumber(string trunkSid, string phoneNumberSid)
        {
            Require.Argument("TrunkSid", trunkSid);
            Require.Argument("PhoneNumberSid", phoneNumberSid);

            var request = new RestRequest(Method.POST);
            request.Resource = "Trunks/{TrunkSid}/PhoneNumbers";

            request.AddUrlSegment("TrunkSid", trunkSid);
            request.AddParameter("PhoneNumberSid", phoneNumberSid);

            return Execute<AssociatedPhoneNumber>(request);
        }

        /// <summary>
        /// Remove an associated phoneNumber from the trunk.
        /// </summary>
        /// <param name="trunkSid">Trunk sid.</param>
        /// <param name="phoneNumberSid">PhoneNumber sid.</param>
        public virtual DeleteStatus DeletePhoneNumber(string trunkSid, string phoneNumberSid)
        {
            Require.Argument("TrunkSid", trunkSid);
            Require.Argument("PhoneNumberSid", phoneNumberSid);

            var request = new RestRequest(Method.DELETE);
            request.Resource = "Trunks/{TrunkSid}/PhoneNumbers/{PhoneNumberSid}";

            request.AddUrlSegment("TrunkSid", trunkSid);
            request.AddParameter("PhoneNumberSid", phoneNumberSid, ParameterType.UrlSegment);
            var response = Execute(request);
            return response.StatusCode == System.Net.HttpStatusCode.NoContent ? DeleteStatus.Success : DeleteStatus.Failed;
        }
    }
}

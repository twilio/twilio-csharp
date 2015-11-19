using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestSharp;
using RestSharp.Extensions;
using RestSharp.Validation;

namespace Twilio
{
    public partial class TwilioRestClient
    {
        /// <summary>
        /// Retrieve a Key by its unique ID.
        /// </summary>
        /// <param name="sid">Key string ID</param>
        /// <returns>The Key resource</returns>
        public virtual Key GetKey(string sid)
        {
            Require.Argument("Sid", sid);
            var request = new RestRequest();
            request.Resource = "Accounts/{AccountSid}/Keys/{Sid}.json";

            request.AddParameter("Sid", sid, ParameterType.UrlSegment);
            return Execute<Key>(request);
        }

        /// <summary>
        /// Add a new Key.
        /// </summary>
        /// <returns>The created Key resource</returns>
        public virtual Key AddKey()
        {
            return AddKey(String.Empty);
        }

        /// <summary>
        /// Add a new Key with the specified FriendlyName.
        /// </summary>
        /// <param name="friendlyName">A human-readable name for this Key</param>
        /// <returns>The created Key resource</returns>
        public virtual Key AddKey(string friendlyName)
        {
            var request = new RestRequest(Method.POST);
            request.Resource = "Accounts/{AccountSid}/Keys.json";

            if (friendlyName.HasValue())
            {
                request.AddParameter("FriendlyName", friendlyName);
            }

            return Execute<Key>(request);
        }

        /// <summary>
        /// Update attributes of the specified Key
        /// </summary>
        /// <param name="sid">ID of the Key to update</param>
        /// <param name="friendlyName">Human-readable name for this Key</param>
        /// <returns>The updated Key resource</returns>
        public virtual Key UpdateKey(string sid, string friendlyName)
        {
            Require.Argument("Sid", sid);
            Require.Argument("FriendlyName", friendlyName);
            var request = new RestRequest(Method.POST);
            request.Resource = "Accounts/{AccountSid}/Keys/{Sid}.json";
            request.AddParameter("Sid", sid, ParameterType.UrlSegment);
            request.AddParameter("FriendlyName", friendlyName);

            return Execute<Key>(request);
        }

        /// <summary>
        /// Delete the specified Key.
        /// </summary>
        /// <param name="sid">ID of the key to delete</param>
        /// <returns>Whether the delete request succeeded</returns>
        public virtual DeleteStatus DeleteKey(string sid)
        {
            Require.Argument("Sid", sid);
            var request = new RestRequest(Method.DELETE);
            request.Resource = "Accounts/{AccountSid}/Keys/{Sid}.json";
            request.AddParameter("Sid", sid, ParameterType.UrlSegment);

            var result = Execute(request);
            return result.StatusCode == System.Net.HttpStatusCode.NoContent ? DeleteStatus.Success : DeleteStatus.Failed;
        }
    }
}

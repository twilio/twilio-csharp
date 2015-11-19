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
        public virtual void GetKey(string sid, Action<Key> callback)
        {
            Require.Argument("Sid", sid);
            var request = new RestRequest();
            request.Resource = "Accounts/{AccountSid}/Keys/{Sid}.json";
            request.AddParameter("Sid", sid, ParameterType.UrlSegment);

            ExecuteAsync<Key>(request, (response) => callback(response));
        }

        public virtual void AddKey(Action<Key> callback)
        {
            AddKey(null, callback);
        }

        public virtual void AddKey(string friendlyName, Action<Key> callback)
        {
            var request = new RestRequest(Method.POST);
            request.Resource = "Accounts/{AccountSid}/Keys.json";

            if (friendlyName.HasValue())
            {
                request.AddParameter("FriendlyName", friendlyName);
            }

            ExecuteAsync<Key>(request, (response) => callback(response));
        }

        public virtual void UpdateKey(string sid, string friendlyName, Action<Key> callback)
        {
            Require.Argument("Sid", sid);
            Require.Argument("FriendlyName", friendlyName);
            var request = new RestRequest(Method.POST);
            request.Resource = "Accounts/{AccountSid}/Keys/{Sid}.json";

            request.AddParameter("Sid", sid, ParameterType.UrlSegment);
            request.AddParameter("FriendlyName", friendlyName);

            ExecuteAsync<Key>(request, (response) => callback(response));
        }

        public virtual void DeleteKey(string sid, Action<DeleteStatus> callback)
        {
            Require.Argument("Sid", sid);
            var request = new RestRequest(Method.DELETE);
            request.Resource = "Accounts/{AccountSid}/Keys/{Sid}.json";
            request.AddParameter("Sid", sid, ParameterType.UrlSegment);

            ExecuteAsync(request, (response) => callback(response.StatusCode == System.Net.HttpStatusCode.NoContent ? DeleteStatus.Success : DeleteStatus.Failed));
        }
    }
}

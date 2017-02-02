using System;
using System.Collections.Generic;
using System.Net;

namespace Twilio.Jwt.Client
{
	public class OutgoingClientScope : IScope
	{
		private static readonly string Scope = "scope:client:outgoing";

		private readonly string _applicationSid;
		private readonly string _clientName;
		private readonly Dictionary<string, string> _parameters;

		public OutgoingClientScope(
			string applicationSid,
			string clientName = null,
			Dictionary<string, string> parameters = null
		)
		{
			this._applicationSid = applicationSid;
			this._clientName = clientName;
			this._parameters = parameters;
		}

		public string Payload
		{
			get
			{
				var queryArgs = new List<string>();
				queryArgs.Add(BuildParameter("appSid", _applicationSid));

				if (_clientName != null)
				{
					queryArgs.Add(BuildParameter("clientName", _clientName));
				}

				if (_parameters != null)
				{
					queryArgs.Add(BuildParameter("appParams", GetAppParams()));
				}

				var queryString = String.Join("&", queryArgs);
				return $"{Scope}?{queryString}";
			}
		}

		private string GetAppParams()
		{
			var queryParams = new List<string>();
			foreach (var entry in _parameters)
			{
				queryParams.Add(BuildParameter(entry.Key, entry.Value));
			}

			return String.Join("&", queryParams);
		}

		private string BuildParameter(string k, string v)
		{
			return WebUtility.UrlEncode(k) + "=" + WebUtility.UrlEncode(v);
		}
	}
}

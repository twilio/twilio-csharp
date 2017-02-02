using System;
using System.Net;
using System.Collections.Generic;

namespace Twilio.Jwt.Client
{
	public class EventStreamScope : IScope
	{
		private static readonly string Scope = "scope:stream:subscribe";

		private readonly Dictionary<string, string> _filters;

		public EventStreamScope(Dictionary<string, string> filters = null)
		{
			this._filters = filters;
		}

		public string Payload
		{
			get
			{
				var queryArgs = new List<string>();
				queryArgs.Add("path=/2010-04-01/Events");

				if (_filters != null)
				{
					var v = WebUtility.UrlEncode(GetFilterParams());
					queryArgs.Add($"appParams={v}");
				}

				var queryString = String.Join("&", queryArgs);
				return $"{Scope}?{queryString}";
			}
		}

		private string GetFilterParams()
		{
			var queryParams = new List<string>();
			foreach (var entry in _filters)
			{
				var k = WebUtility.UrlEncode(entry.Key);
				var v = WebUtility.UrlEncode(entry.Value);
				queryParams.Add($"{k}={v}");
			}

			return String.Join("&", queryParams);
		}
	}
}

using System;
using System.Linq;
using RestSharp;
using RestSharp.Extensions;
using System.Text;
using Twilio.Model;

#if WINDOWS_PHONE
using System.Windows;
#endif

namespace Twilio
{
	public abstract partial class TwilioClient
	{
		/// <summary>
		/// Execute a manual REST request
		/// </summary>
		/// <typeparam name="T">The type of object to create and populate with the returned data.</typeparam>
		/// <param name="request">The RestRequest to execute (will use client credentials)</param>
		/// <param name="callback">The callback function to execute when the async request completes</param>
        public virtual void ExecuteAsync<T>(IRestRequest request, Action<T> callback) where T : new()
		{
			request.OnBeforeDeserialization = (resp) =>
			{
				// for individual resources when there's an error to make
				// sure that RestException props are populated
				if (((int)resp.StatusCode) >= 400)
				{
					// have to read the bytes so .Content doesn't get populated
                    var restException = "{{ \"RestException\" : {0} }}";
                    var content = resp.RawBytes.AsString(); //get the response content
                    var newJson = string.Format(restException, content);

                    resp.Content = null;
                    resp.RawBytes = Encoding.UTF8.GetBytes(newJson.ToString());
                }
			};

			request.DateFormat = "ddd, dd MMM yyyy HH:mm:ss '+0000'";

			_client.ExecuteAsync<T>(request, (response) => callback(response.Data));
		}

		/// <summary>
		/// Execute a manual REST request
		/// </summary>
		/// <param name="request">The RestRequest to execute (will use client credentials)</param>
		/// <param name="callback">The callback function to execute when the async request completes</param>
        public virtual void ExecuteAsync(IRestRequest request, Action<IRestResponse> callback)
		{
			_client.ExecuteAsync(request, callback);
		}
	}

    public partial class TwilioRestClient : TwilioClient
    {
		public virtual void GetNextPage<T>(TwilioListBase resourceResult, Action<T> callback) where T : TwilioListBase, new()
        {
            var request = new RestRequest();
            request.Resource = resourceResult.NextPageUri.OriginalString.Replace("/" + ApiVersion, "");

			ExecuteAsync<T>(request, (response) => callback(response));
        }

		public virtual void GetPreviousPage<T>(TwilioListBase resourceResult, Action<T> callback) where T : TwilioListBase, new()
        {
            var request = new RestRequest();
            request.Resource = resourceResult.PreviousPageUri.OriginalString.Replace("/" + ApiVersion, "");

			ExecuteAsync<T>(request, (response) => callback(response));
        }
	}

//    public partial class NextGenClient : TwilioClient
//    {
//		#if !NOASYNCPAGING
//
//		public virtual void GetNextPage<T>(NextGenListBase resourceResult, Action<T> callback) where T : NextGenListBase, new()
//        {
//            var request = new RestRequest();
//            request.Resource = resourceResult.Meta.NextPageUrl.PathAndQuery.Replace("/" + ApiVersion, "");
//
//			ExecuteAsync<T>(request, (response) => callback(response));
//        }
//
//		public virtual void GetPreviousPage<T>(NextGenListBase resourceResult, Action<T> callback) where T : NextGenListBase, new()
//        {
//            var request = new RestRequest();
//            request.Resource = resourceResult.Meta.PreviousPageUrl.PathAndQuery.Replace("/" + ApiVersion, "");
//
//			ExecuteAsync<T>(request, (response) => callback(response));
//        }
//
//		#endif
//	}
}
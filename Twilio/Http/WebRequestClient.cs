using System;
using System.IO;
using System.Net;
using System.Reflection;
using System.Diagnostics;
using Twilio.Exceptions;
using Newtonsoft.Json;

#if NET40
using System.Threading.Tasks;
#endif

namespace Twilio.Http
{
	public class WebRequestClient : HttpClient
	{
        #if NET40
	    private const string PlatVersion = " (.NET 4+)";
        #elif NET35
		private const string PlatVersion = " (.NET 3.5)";
        #else
        private const string PlatVersion = " (unknown)";
        #endif

	    public override Response MakeRequest(Request request)
	    {
	        var httpRequest = BuildHttpRequest(request);
	        if (!Equals(request.Method, HttpMethod.Get))
	        {
	            var stream = GetStream(httpRequest);
	            stream.Write(request.EncodePostParams(), 0, request.EncodePostParams().Length);
	        }

	        try
	        {
	            var response = GetResponse(httpRequest);
	            var reader = new StreamReader(response.GetResponseStream());
	            return new Response(response.StatusCode, reader.ReadToEnd());
	        }
	        catch (WebException e)
	        {
	            throw HandleErrorResponse((HttpWebResponse) e.Response);
	        }
	    }

        #if NET40
	    public override async Task<Response> MakeRequestAysnc(Request request)
	    {
	        var httpRequest = BuildHttpRequest(request);
	        if (!Equals(request.Method, HttpMethod.Get))
	        {
	            var stream = await GetStreamAsync(httpRequest);
	            await stream.WriteAsync(request.EncodePostParams(), 0, request.EncodePostParams().Length);
	        }

	        try
	        {
	            var response = await GetResponseAsync(httpRequest);
	            var reader = new StreamReader(response.GetResponseStream());
	            return new Response(response.StatusCode, await reader.ReadToEndAsync());
	        }
	        catch (AggregateException ae)
	        {
	            ae.Handle ((x) =>
	            {
	                if (!(x is WebException))
	                {
	                    return false;
	                }

	                var e = (WebException) x;
	                throw HandleErrorResponse((HttpWebResponse) e.Response);
	            });
	            return null;
	        }
	    }
        #endif

	    private static Exception HandleErrorResponse(HttpWebResponse errorResponse)
	    {
	        if (errorResponse.StatusCode >= HttpStatusCode.InternalServerError &&
	            errorResponse.StatusCode < HttpStatusCode.HttpVersionNotSupported)
	        {
	            return new TwilioException("Internal Server error: " + errorResponse.StatusDescription);
	        }

	        var responseStream = errorResponse.GetResponseStream();
	        var errorReader = new StreamReader(responseStream);
	        var errorContent = errorReader.ReadToEnd();

	        try
	        {
	            var restEx = RestException.FromJson(errorContent);
	            return restEx ?? new TwilioException("Error: " + errorResponse.StatusDescription + " - " + errorContent);
	        }
	        catch (JsonReaderException)
	        {
	            return new TwilioException("Error: " + errorResponse.StatusDescription + " - " + errorContent);
	        }
	    }

	    private static void SetUserAgent(HttpWebRequest request)
	    {
            #if !__MonoCS__
	        var property = typeof(HttpWebRequest).GetRuntimeProperty("UserAgent");
	        const string libraryVersion = "twilio-csharp/" + AssemblyInfomation.AssemblyInformationalVersion + PlatVersion;
	        property.SetValue(request, libraryVersion, null);
            #endif
	    }

	    #if NET40
	    private static async Task<Stream> GetStreamAsync(WebRequest request)
	    {
	        return await Task.Factory.FromAsync(
	            request.BeginGetRequestStream,
	            request.EndGetRequestStream,
	            null
	        );
	    }
	    #endif

	    private static Stream GetStream(WebRequest request)
	    {
            #if NET40
	        var streamTask = GetStreamAsync(request);
	        streamTask.Wait();
	        return streamTask.Result;
            #else
            return request.GetRequestStream();
            #endif
	    }

	    #if NET40
	    private static async Task<HttpWebResponse> GetResponseAsync(WebRequest request)
	    {
	        return await Task.Factory.FromAsync(
	            request.BeginGetResponse,
	            (ar) => (HttpWebResponse) request.EndGetResponse(ar),
	            null
	        );
	    }
	    #endif

	    private static HttpWebResponse GetResponse(WebRequest request)
	    {
            #if NET40
	        var responseTask = GetResponseAsync(request);
	        responseTask.Wait();
	        return responseTask.Result;
            #else
            return (HttpWebResponse) request.GetResponse();
            #endif
	    }

	    private HttpWebRequest BuildHttpRequest(Request request)
	    {
	        var httpRequest = (HttpWebRequest) WebRequest.Create(request.ConstructUrl());
	        SetUserAgent(httpRequest);

	        httpRequest.Method = request.Method.ToString();
	        httpRequest.Accept = "application/json";
	        httpRequest.Headers["Accept-Encoding"] = "utf-8";

	        var authBytes = Authentication(request.Username, request.Password);
	        httpRequest.Headers["Authorization"] = "Basic " + authBytes;
	        httpRequest.ContentType = "application/x-www-form-urlencoded";

	        return httpRequest;
	    }
	}
}

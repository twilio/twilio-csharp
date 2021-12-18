
using System;
using System.Net;
using Newtonsoft.Json;
using Twilio.Exceptions;

#if !NET35
using System.Threading.Tasks;
#endif

using Twilio.Http;
#if NET35
using Twilio.Http.Net35;
#endif

namespace Twilio.Clients
{
  /// <summary>
  /// Implementation of a TwilioRestClient.
  /// </summary>
  public class TwilioRestClient : ITwilioRestClient
  {
    /// <summary>
    /// Client to make HTTP requests
    /// </summary>
    public HttpClient HttpClient { get; }

    /// <summary>
    /// Account SID to use for requests
    /// </summary>
    public string AccountSid { get; }

    /// <summary>
    /// Twilio region to make requests to
    /// </summary>
    public string Region { get; }

    /// <summary>
    /// Twilio edge to make requests to
    /// </summary>
    public string Edge { get; set; }

    /// <summary>
    /// Log level for logging
    /// </summary>
    public string LogLevel { get; set; } = Environment.GetEnvironmentVariable("TWILIO_LOG_LEVEL");
    private readonly string _username;
    private readonly string _password;

    /// <summary>
    /// Constructor for a TwilioRestClient
    /// </summary>
    ///
    /// <param name="username">username for requests</param>
    /// <param name="password">password for requests</param>
    /// <param name="accountSid">account sid to make requests for</param>
    /// <param name="region">region to make requests for</param>
    /// <param name="httpClient">http client used to make the requests</param>
    /// <param name="edge">edge to make requests for</param>
    public TwilioRestClient(
        string username,
        string password,
        string accountSid = null,
        string region = null,
        HttpClient httpClient = null,
        string edge = null
    )
    {
      _username = username;
      _password = password;

      AccountSid = accountSid ?? username;
      HttpClient = httpClient ?? DefaultClient();

      Region = region;
      Edge = edge;
    }

    /// <summary>
    /// Make a request to the Twilio API
    /// </summary>
    ///
    /// <param name="request">request to make</param>
    /// <returns>response of the request</returns>
    public Response Request(Request request)
    {
      request.SetAuth(_username, _password);

      if (LogLevel == "debug")
        LogRequest(request);

      if (Region != null)
        request.Region = Region;

      if (Edge != null)
        request.Edge = Edge;

      Response response;
      try
      {
        response = HttpClient.MakeRequest(request);
        if (LogLevel == "debug")
        {
          Console.WriteLine("response.status: " + response.StatusCode);
          Console.WriteLine("response.headers: " + response.Headers);
        }
      }
      catch (Exception clientException)
      {
        throw new ApiConnectionException(
            "Connection Error: " + request.Method + request.ConstructUrl(),
            clientException
        );
      }
      return ProcessResponse(response);
    }

#if !NET35
    /// <summary>
    /// Make a request to the Twilio API
    /// </summary>
    ///
    /// <param name="request">request to make</param>
    /// <returns>Task that resolves to the response of the request</returns>
    public async Task<Response> RequestAsync(Request request)
    {
      request.SetAuth(_username, _password);

      if (Region != null)
        request.Region = Region;

      if (Edge != null)
        request.Edge = Edge;

      Response response;
      try
      {
        response = await HttpClient.MakeRequestAsync(request);
      }
      catch (Exception clientException)
      {
        throw new ApiConnectionException(
            "Connection Error: " + request.Method + request.ConstructUrl(),
            clientException
        );
      }
      return ProcessResponse(response);
    }

    private static HttpClient DefaultClient()
    {
      return new SystemNetHttpClient();
    }
#else
        private static HttpClient DefaultClient()
        {
            return new WebRequestClient();
        }
#endif

    private static Response ProcessResponse(Response response)
    {
      if (response == null)
      {
        throw new ApiConnectionException("Connection Error: No response received.");
      }

      if (response.StatusCode >= HttpStatusCode.OK && response.StatusCode < HttpStatusCode.BadRequest)
      {
        return response;
      }

      // Deserialize and throw exception
      RestException restException = null;
      try
      {
        restException = RestException.FromJson(response.Content);
      }
      catch (JsonReaderException) { /* Allow null check below to handle */ }

      if (restException == null)
      {
        throw new ApiException("Api Error: " + response.StatusCode + " - " + (response.Content ?? "[no content]"));
      }

      throw new ApiException(
          restException.Code,
          (int)response.StatusCode,
          restException.Message ?? "Unable to make request, " + response.StatusCode,
          restException.MoreInfo,
          restException.Details
      );
    }

    /// <summary>
    /// Test that this application can use updated SSL certificates on
    /// api.twilio.com:8443. It's a bit easier to call this method from
    /// TwilioClient.ValidateSslCertificate().
    /// </summary>
    public static void ValidateSslCertificate()
    {
      ValidateSslCertificate(DefaultClient());
    }

    /// <summary>
    /// Test that this application can use updated SSL certificates on
    /// api.twilio.com:8443. Generally, you'll want to use the version of this
    /// function that takes no parameters unless you have a reason not to.
    /// </summary>
    ///
    /// <param name="client">HTTP Client to use for testing the request</param>
    public static void ValidateSslCertificate(HttpClient client)
    {
      Request request = new Request("GET", "api", ":8443/", null);

      try
      {
        Response response = client.MakeRequest(request);

        if (!response.StatusCode.Equals(HttpStatusCode.OK))
        {
          throw new CertificateValidationException(
              "Unexpected response from certificate endpoint",
              request,
              response
          );
        }
      }
      catch (CertificateValidationException e)
      {
        throw e;
      }
      catch (Exception e)
      {
        throw new CertificateValidationException(
            "Connection to api.twilio.com:8443 failed",
            e,
            request
        );
      }
    }

    /// <summary>
    /// Format request information when LogLevel is set to debug
    /// </summary>
    ///
    /// <param name="request">HTTP request</param>
    private static void LogRequest(Request request)
    {
      Console.WriteLine("-- BEGIN Twilio API Request --");
      Console.WriteLine("request.method: " + request.Method);
      Console.WriteLine("request.URI: " + request.Uri);

      if (request.QueryParams != null)
      {
        request.QueryParams.ForEach(parameter => Console.WriteLine(parameter.Key + ":" + parameter.Value));
      }

      if (request.HeaderParams != null)
      {
        for (int i = 0; i < request.HeaderParams.Count; i++)
        {
          var lowercaseHeader = request.HeaderParams[i].Key.ToLower();
          if (lowercaseHeader.Contains("authorization") == false)
          {
            Console.WriteLine(request.HeaderParams[i].Key + ":" + request.HeaderParams[i].Value);
          }
        }
      }

      Console.WriteLine("-- END Twilio API Request --");
    }
  }
}

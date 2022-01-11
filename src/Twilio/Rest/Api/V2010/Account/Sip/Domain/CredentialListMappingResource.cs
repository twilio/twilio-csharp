/// This code was generated by
/// \ / _    _  _|   _  _
///  | (_)\/(_)(_|\/| |(/_  v1.0.0
///       /       /
/// <summary>
/// CredentialListMappingResource
/// </summary>

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Api.V2010.Account.Sip.Domain
{

  public class CredentialListMappingResource : Resource
  {
    private static Request BuildCreateRequest(CreateCredentialListMappingOptions options, ITwilioRestClient client)
    {
      return new Request(
          HttpMethod.Post,
          Rest.Domain.Api,
          "/2010-04-01/Accounts/" + (options.PathAccountSid ?? client.AccountSid) + "/SIP/Domains/" + options.PathDomainSid + "/CredentialListMappings.json",
          postParams: options.GetParams(),
          headerParams: null
      );
    }

    /// <summary>
    /// Create a CredentialListMapping resource for an account.
    /// </summary>
    /// <param name="options"> Create CredentialListMapping parameters </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> A single instance of CredentialListMapping </returns>
    public static CredentialListMappingResource Create(CreateCredentialListMappingOptions options,
                                                       ITwilioRestClient client = null)
    {
      client = client ?? TwilioClient.GetRestClient();
      var response = client.Request(BuildCreateRequest(options, client));
      return FromJson(response.Content);
    }

#if !NET35
    /// <summary>
    /// Create a CredentialListMapping resource for an account.
    /// </summary>
    /// <param name="options"> Create CredentialListMapping parameters </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> Task that resolves to A single instance of CredentialListMapping </returns>
    public static async System.Threading.Tasks.Task<CredentialListMappingResource> CreateAsync(CreateCredentialListMappingOptions options,
                                                                                               ITwilioRestClient client = null)
    {
      client = client ?? TwilioClient.GetRestClient();
      var response = await client.RequestAsync(BuildCreateRequest(options, client));
      return FromJson(response.Content);
    }
#endif

    /// <summary>
    /// Create a CredentialListMapping resource for an account.
    /// </summary>
    /// <param name="pathDomainSid"> A string that identifies the SIP Domain for which the CredentialList resource will be
    ///                     mapped </param>
    /// <param name="credentialListSid"> A string that identifies the CredentialList resource to map to the SIP domain
    ///                         </param>
    /// <param name="pathAccountSid"> The unique sid that identifies this account </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> A single instance of CredentialListMapping </returns>
    public static CredentialListMappingResource Create(string pathDomainSid,
                                                       string credentialListSid,
                                                       string pathAccountSid = null,
                                                       ITwilioRestClient client = null)
    {
      var options = new CreateCredentialListMappingOptions(pathDomainSid, credentialListSid) { PathAccountSid = pathAccountSid };
      return Create(options, client);
    }

#if !NET35
    /// <summary>
    /// Create a CredentialListMapping resource for an account.
    /// </summary>
    /// <param name="pathDomainSid"> A string that identifies the SIP Domain for which the CredentialList resource will be
    ///                     mapped </param>
    /// <param name="credentialListSid"> A string that identifies the CredentialList resource to map to the SIP domain
    ///                         </param>
    /// <param name="pathAccountSid"> The unique sid that identifies this account </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> Task that resolves to A single instance of CredentialListMapping </returns>
    public static async System.Threading.Tasks.Task<CredentialListMappingResource> CreateAsync(string pathDomainSid,
                                                                                               string credentialListSid,
                                                                                               string pathAccountSid = null,
                                                                                               ITwilioRestClient client = null)
    {
      var options = new CreateCredentialListMappingOptions(pathDomainSid, credentialListSid) { PathAccountSid = pathAccountSid };
      return await CreateAsync(options, client);
    }
#endif

    private static Request BuildReadRequest(ReadCredentialListMappingOptions options, ITwilioRestClient client)
    {
      return new Request(
          HttpMethod.Get,
          Rest.Domain.Api,
          "/2010-04-01/Accounts/" + (options.PathAccountSid ?? client.AccountSid) + "/SIP/Domains/" + options.PathDomainSid + "/CredentialListMappings.json",
          queryParams: options.GetParams(),
          headerParams: null
      );
    }

    /// <summary>
    /// Read multiple CredentialListMapping resources from an account.
    /// </summary>
    /// <param name="options"> Read CredentialListMapping parameters </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> A single instance of CredentialListMapping </returns>
    public static ResourceSet<CredentialListMappingResource> Read(ReadCredentialListMappingOptions options,
                                                                  ITwilioRestClient client = null)
    {
      client = client ?? TwilioClient.GetRestClient();
      var response = client.Request(BuildReadRequest(options, client));

      var page = Page<CredentialListMappingResource>.FromJson("credential_list_mappings", response.Content);
      return new ResourceSet<CredentialListMappingResource>(page, options, client);
    }

#if !NET35
    /// <summary>
    /// Read multiple CredentialListMapping resources from an account.
    /// </summary>
    /// <param name="options"> Read CredentialListMapping parameters </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> Task that resolves to A single instance of CredentialListMapping </returns>
    public static async System.Threading.Tasks.Task<ResourceSet<CredentialListMappingResource>> ReadAsync(ReadCredentialListMappingOptions options,
                                                                                                          ITwilioRestClient client = null)
    {
      client = client ?? TwilioClient.GetRestClient();
      var response = await client.RequestAsync(BuildReadRequest(options, client));

      var page = Page<CredentialListMappingResource>.FromJson("credential_list_mappings", response.Content);
      return new ResourceSet<CredentialListMappingResource>(page, options, client);
    }
#endif

    /// <summary>
    /// Read multiple CredentialListMapping resources from an account.
    /// </summary>
    /// <param name="pathDomainSid"> A string that identifies the SIP Domain that includes the resource to read </param>
    /// <param name="pathAccountSid"> The unique sid that identifies this account </param>
    /// <param name="pageSize"> Page size </param>
    /// <param name="limit"> Record limit </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> A single instance of CredentialListMapping </returns>
    public static ResourceSet<CredentialListMappingResource> Read(string pathDomainSid,
                                                                  string pathAccountSid = null,
                                                                  int? pageSize = null,
                                                                  long? limit = null,
                                                                  ITwilioRestClient client = null)
    {
      var options = new ReadCredentialListMappingOptions(pathDomainSid) { PathAccountSid = pathAccountSid, PageSize = pageSize, Limit = limit };
      return Read(options, client);
    }

#if !NET35
    /// <summary>
    /// Read multiple CredentialListMapping resources from an account.
    /// </summary>
    /// <param name="pathDomainSid"> A string that identifies the SIP Domain that includes the resource to read </param>
    /// <param name="pathAccountSid"> The unique sid that identifies this account </param>
    /// <param name="pageSize"> Page size </param>
    /// <param name="limit"> Record limit </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> Task that resolves to A single instance of CredentialListMapping </returns>
    public static async System.Threading.Tasks.Task<ResourceSet<CredentialListMappingResource>> ReadAsync(string pathDomainSid,
                                                                                                          string pathAccountSid = null,
                                                                                                          int? pageSize = null,
                                                                                                          long? limit = null,
                                                                                                          ITwilioRestClient client = null)
    {
      var options = new ReadCredentialListMappingOptions(pathDomainSid) { PathAccountSid = pathAccountSid, PageSize = pageSize, Limit = limit };
      return await ReadAsync(options, client);
    }
#endif

    /// <summary>
    /// Fetch the target page of records
    /// </summary>
    /// <param name="targetUrl"> API-generated URL for the requested results page </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> The target page of records </returns>
    public static Page<CredentialListMappingResource> GetPage(string targetUrl, ITwilioRestClient client)
    {
      client = client ?? TwilioClient.GetRestClient();

      var request = new Request(
          HttpMethod.Get,
          targetUrl
      );

      var response = client.Request(request);
      return Page<CredentialListMappingResource>.FromJson("credential_list_mappings", response.Content);
    }

    /// <summary>
    /// Fetch the next page of records
    /// </summary>
    /// <param name="page"> current page of records </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> The next page of records </returns>
    public static Page<CredentialListMappingResource> NextPage(Page<CredentialListMappingResource> page,
                                                               ITwilioRestClient client)
    {
      var request = new Request(
          HttpMethod.Get,
          page.GetNextPageUrl(Rest.Domain.Api)
      );

      var response = client.Request(request);
      return Page<CredentialListMappingResource>.FromJson("credential_list_mappings", response.Content);
    }

    /// <summary>
    /// Fetch the previous page of records
    /// </summary>
    /// <param name="page"> current page of records </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> The previous page of records </returns>
    public static Page<CredentialListMappingResource> PreviousPage(Page<CredentialListMappingResource> page,
                                                                   ITwilioRestClient client)
    {
      var request = new Request(
          HttpMethod.Get,
          page.GetPreviousPageUrl(Rest.Domain.Api)
      );

      var response = client.Request(request);
      return Page<CredentialListMappingResource>.FromJson("credential_list_mappings", response.Content);
    }

    private static Request BuildFetchRequest(FetchCredentialListMappingOptions options, ITwilioRestClient client)
    {
      return new Request(
          HttpMethod.Get,
          Rest.Domain.Api,
          "/2010-04-01/Accounts/" + (options.PathAccountSid ?? client.AccountSid) + "/SIP/Domains/" + options.PathDomainSid + "/CredentialListMappings/" + options.PathSid + ".json",
          queryParams: options.GetParams(),
          headerParams: null
      );
    }

    /// <summary>
    /// Fetch a single CredentialListMapping resource from an account.
    /// </summary>
    /// <param name="options"> Fetch CredentialListMapping parameters </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> A single instance of CredentialListMapping </returns>
    public static CredentialListMappingResource Fetch(FetchCredentialListMappingOptions options,
                                                      ITwilioRestClient client = null)
    {
      client = client ?? TwilioClient.GetRestClient();
      var response = client.Request(BuildFetchRequest(options, client));
      return FromJson(response.Content);
    }

#if !NET35
    /// <summary>
    /// Fetch a single CredentialListMapping resource from an account.
    /// </summary>
    /// <param name="options"> Fetch CredentialListMapping parameters </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> Task that resolves to A single instance of CredentialListMapping </returns>
    public static async System.Threading.Tasks.Task<CredentialListMappingResource> FetchAsync(FetchCredentialListMappingOptions options,
                                                                                              ITwilioRestClient client = null)
    {
      client = client ?? TwilioClient.GetRestClient();
      var response = await client.RequestAsync(BuildFetchRequest(options, client));
      return FromJson(response.Content);
    }
#endif

    /// <summary>
    /// Fetch a single CredentialListMapping resource from an account.
    /// </summary>
    /// <param name="pathDomainSid"> A string that identifies the SIP Domain that includes the resource to fetch </param>
    /// <param name="pathSid"> A string that identifies the resource to fetch </param>
    /// <param name="pathAccountSid"> The unique sid that identifies this account </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> A single instance of CredentialListMapping </returns>
    public static CredentialListMappingResource Fetch(string pathDomainSid,
                                                      string pathSid,
                                                      string pathAccountSid = null,
                                                      ITwilioRestClient client = null)
    {
      var options = new FetchCredentialListMappingOptions(pathDomainSid, pathSid) { PathAccountSid = pathAccountSid };
      return Fetch(options, client);
    }

#if !NET35
    /// <summary>
    /// Fetch a single CredentialListMapping resource from an account.
    /// </summary>
    /// <param name="pathDomainSid"> A string that identifies the SIP Domain that includes the resource to fetch </param>
    /// <param name="pathSid"> A string that identifies the resource to fetch </param>
    /// <param name="pathAccountSid"> The unique sid that identifies this account </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> Task that resolves to A single instance of CredentialListMapping </returns>
    public static async System.Threading.Tasks.Task<CredentialListMappingResource> FetchAsync(string pathDomainSid,
                                                                                              string pathSid,
                                                                                              string pathAccountSid = null,
                                                                                              ITwilioRestClient client = null)
    {
      var options = new FetchCredentialListMappingOptions(pathDomainSid, pathSid) { PathAccountSid = pathAccountSid };
      return await FetchAsync(options, client);
    }
#endif

    private static Request BuildDeleteRequest(DeleteCredentialListMappingOptions options, ITwilioRestClient client)
    {
      return new Request(
          HttpMethod.Delete,
          Rest.Domain.Api,
          "/2010-04-01/Accounts/" + (options.PathAccountSid ?? client.AccountSid) + "/SIP/Domains/" + options.PathDomainSid + "/CredentialListMappings/" + options.PathSid + ".json",
          queryParams: options.GetParams(),
          headerParams: null
      );
    }

    /// <summary>
    /// Delete a CredentialListMapping resource from an account.
    /// </summary>
    /// <param name="options"> Delete CredentialListMapping parameters </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> A single instance of CredentialListMapping </returns>
    public static bool Delete(DeleteCredentialListMappingOptions options, ITwilioRestClient client = null)
    {
      client = client ?? TwilioClient.GetRestClient();
      var response = client.Request(BuildDeleteRequest(options, client));
      return response.StatusCode == System.Net.HttpStatusCode.NoContent;
    }

#if !NET35
    /// <summary>
    /// Delete a CredentialListMapping resource from an account.
    /// </summary>
    /// <param name="options"> Delete CredentialListMapping parameters </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> Task that resolves to A single instance of CredentialListMapping </returns>
    public static async System.Threading.Tasks.Task<bool> DeleteAsync(DeleteCredentialListMappingOptions options,
                                                                      ITwilioRestClient client = null)
    {
      client = client ?? TwilioClient.GetRestClient();
      var response = await client.RequestAsync(BuildDeleteRequest(options, client));
      return response.StatusCode == System.Net.HttpStatusCode.NoContent;
    }
#endif

    /// <summary>
    /// Delete a CredentialListMapping resource from an account.
    /// </summary>
    /// <param name="pathDomainSid"> A string that identifies the SIP Domain that includes the resource to delete </param>
    /// <param name="pathSid"> A string that identifies the resource to delete </param>
    /// <param name="pathAccountSid"> The unique sid that identifies this account </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> A single instance of CredentialListMapping </returns>
    public static bool Delete(string pathDomainSid,
                              string pathSid,
                              string pathAccountSid = null,
                              ITwilioRestClient client = null)
    {
      var options = new DeleteCredentialListMappingOptions(pathDomainSid, pathSid) { PathAccountSid = pathAccountSid };
      return Delete(options, client);
    }

#if !NET35
    /// <summary>
    /// Delete a CredentialListMapping resource from an account.
    /// </summary>
    /// <param name="pathDomainSid"> A string that identifies the SIP Domain that includes the resource to delete </param>
    /// <param name="pathSid"> A string that identifies the resource to delete </param>
    /// <param name="pathAccountSid"> The unique sid that identifies this account </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> Task that resolves to A single instance of CredentialListMapping </returns>
    public static async System.Threading.Tasks.Task<bool> DeleteAsync(string pathDomainSid,
                                                                      string pathSid,
                                                                      string pathAccountSid = null,
                                                                      ITwilioRestClient client = null)
    {
      var options = new DeleteCredentialListMappingOptions(pathDomainSid, pathSid) { PathAccountSid = pathAccountSid };
      return await DeleteAsync(options, client);
    }
#endif

    /// <summary>
    /// Converts a JSON string into a CredentialListMappingResource object
    /// </summary>
    /// <param name="json"> Raw JSON string </param>
    /// <returns> CredentialListMappingResource object represented by the provided JSON </returns>
    public static CredentialListMappingResource FromJson(string json)
    {
      // Convert all checked exceptions to Runtime
      try
      {
        return JsonConvert.DeserializeObject<CredentialListMappingResource>(json);
      }
      catch (JsonException e)
      {
        throw new ApiException(e.Message, e);
      }
    }

    /// <summary>
    /// The unique id of the Account that is responsible for this resource.
    /// </summary>
    [JsonProperty("account_sid")]
    public string AccountSid { get; private set; }
    /// <summary>
    /// The date that this resource was created, given as GMT in RFC 2822 format.
    /// </summary>
    [JsonProperty("date_created")]
    public DateTime? DateCreated { get; private set; }
    /// <summary>
    /// The date that this resource was last updated, given as GMT in RFC 2822 format.
    /// </summary>
    [JsonProperty("date_updated")]
    public DateTime? DateUpdated { get; private set; }
    /// <summary>
    /// The unique string that identifies the SipDomain resource.
    /// </summary>
    [JsonProperty("domain_sid")]
    public string DomainSid { get; private set; }
    /// <summary>
    /// A human readable descriptive text for this resource, up to 64 characters long.
    /// </summary>
    [JsonProperty("friendly_name")]
    public string FriendlyName { get; private set; }
    /// <summary>
    /// A 34 character string that uniquely identifies this resource.
    /// </summary>
    [JsonProperty("sid")]
    public string Sid { get; private set; }
    /// <summary>
    /// The URI for this resource, relative to https://api.twilio.com
    /// </summary>
    [JsonProperty("uri")]
    public string Uri { get; private set; }

    private CredentialListMappingResource()
    {

    }
  }

}
using System;
using RestSharp;
using RestSharp.Validation;
using RestSharp.Extensions;

namespace Twilio
{
    public partial class TwilioRestClient
    {
        /// <summary>
        /// Locates and returns a specific SIP Domain resource
        /// </summary>
        /// <param name="domainSid">The Sid of the SIP Domain to locate</param>
        /// <returns></returns>
        public virtual void GetDomain(string domainSid, Action<Domain> callback)
        {
            var request = new RestRequest();
            request.Resource = "Accounts/{AccountSid}/SIP/Domains/{DomainSid}.json";
            request.AddUrlSegment("DomainSid", domainSid);

            ExecuteAsync<Domain>(request, (response) => callback(response));
        }

        /// <summary>
        /// Return a list of all SIP Domain resources
        /// </summary>
        /// <returns></returns>
		public virtual void ListDomains(Action<DomainResult> callback)
        {
            ListDomains(null, null, callback);
        }

        /// <summary>
        /// Return a list of all SIP Domain resources
        /// </summary>

        /// <param name="pageNumber"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        [System.Obsolete("Use GetNextPage and GetPreviousPage for paging. Page parameter is scheduled for end of life https://www.twilio.com/engineering/2015/04/16/replacing-absolute-paging-with-relative-paging")]
		public virtual void ListDomains(int? pageNumber, int? count, Action<DomainResult> callback)
        {
            var request = new RestRequest();
            request.Resource = "Accounts/{AccountSid}/SIP/Domains.json";

            if (pageNumber.HasValue) request.AddParameter("Page", pageNumber.Value);
            if (count.HasValue) request.AddParameter("PageSize", count.Value);

            ExecuteAsync<DomainResult>(request, (response) => callback(response));
        }

        /// <summary>
        /// Creates a new SIP Domain resource
        /// </summary>
        /// <param name="domainName">The name of the SIP Domain to create.  You must pick a unique domain name that ends in ".sip.twilio.com"</param>
        /// <returns></returns>
        public virtual void CreateDomain(string domainName, Action<Domain> callback)
        {
            DomainOptions options = new DomainOptions() { DomainName = domainName };
            CreateDomain(options, callback);
        }

        /// <summary>
        /// Creates a new SIP Domain resource
        /// </summary>
        /// <param name="options">Optional parameters to use when creating a new SIP domain.  DomainName is required and you must pick a unique domain name that ends in ".sip.twilio.com"</param>
        /// <returns></returns>
        public virtual void CreateDomain(DomainOptions options, Action<Domain> callback)
        {
            var request = new RestRequest(Method.POST);
            request.Resource = "Accounts/{AccountSid}/SIP/Domains.json";

            AddDomainOptions(options, request);

            ExecuteAsync<Domain>(request, (response) => callback(response));
        }

        private static void AddDomainOptions(DomainOptions options, RestRequest request)
        {
            if (options.DomainName.HasValue()) request.AddParameter("DomainName", options.DomainName);

            if (options.AuthType.HasValue()) request.AddParameter("AuthType", options.AuthType);
            if (options.FriendlyName.HasValue()) request.AddParameter("FriendlyName", options.FriendlyName);
            if (options.VoiceFallbackMethod.HasValue()) request.AddParameter("VoiceFallbackMethod", options.VoiceFallbackMethod);
            if (options.VoiceFallbackUrl.HasValue()) request.AddParameter("VoiceFallbackUrl", options.VoiceFallbackUrl);
            if (options.VoiceMethod.HasValue()) request.AddParameter("VoiceMethod", options.VoiceMethod);
            if (options.VoiceStatusCallbackMethod.HasValue()) request.AddParameter("VoiceStatusCallbackMethod", options.VoiceStatusCallbackMethod);
            if (options.VoiceStatusCallbackUrl.HasValue()) request.AddParameter("VoiceStatusCallbackUrl", options.VoiceStatusCallbackUrl);
            if (options.VoiceUrl.HasValue()) request.AddParameter("VoiceUrl", options.VoiceUrl);
        }

        /// <summary>
        /// Updates a specific SIP Domain resource
        /// </summary>
        /// <param name="domainSid">The Sid of the SIP Domain to update</param>
        /// <param name="options">Optional parameters for a SIP domain</param>
        /// <returns></returns>
        public virtual void UpdateDomain(string domainSid, DomainOptions options, Action<Domain> callback)
        {
            Require.Argument("DomainSid", domainSid);

            var request = new RestRequest(Method.POST);
            request.Resource = "Accounts/{AccountSid}/SIP/Domains/{DomainSid}.json";

            request.AddParameter("DomainSid", domainSid, ParameterType.UrlSegment);

            AddDomainOptions(options, request);

            ExecuteAsync<Domain>(request, (response) => callback(response));
        }

        /// <summary>
        /// Deletes a specific SIP Domain resource
        /// </summary>
        /// <param name="domainSid">The Sid of the SIP Domain to delete</param>
        /// <returns></returns>
        public virtual void DeleteDomain(string domainSid, Action<DeleteStatus> callback)
        {
            Require.Argument("DomainSid", domainSid);
            var request = new RestRequest(Method.DELETE);
            request.Resource = "Accounts/{AccountSid}/SIP/Domains/{DomainSid}.json";

            request.AddParameter("DomainSid", domainSid, ParameterType.UrlSegment);

            ExecuteAsync(request, (response) => { callback(response.StatusCode == System.Net.HttpStatusCode.NoContent ? DeleteStatus.Success : DeleteStatus.Failed); });
        }


        /// <summary>
        /// Gets a specific IpAccessControlList mapping for a SIP Domain
        /// </summary>
        /// <param name="domainSid">The Sid of the mapped SIP Domain</param>
        /// <param name="ipAccessControlListMappingSid">The Sid of the mapped IpAccessControlList</param>
        /// <returns></returns>
		public virtual void GetIpAccessControlListMapping(string domainSid, string ipAccessControlListMappingSid, Action<IpAccessControlListMapping> callback)
        {
            var request = new RestRequest();
            request.Resource = "Accounts/{AccountSid}/SIP/Domains/{DomainSid}/IpAccessControlListMappings/{IpAccessControlListMappingSid}.json";
            request.AddUrlSegment("DomainSid", domainSid);
            request.AddUrlSegment("IpAccessControlListMappingSid", ipAccessControlListMappingSid);

            ExecuteAsync<IpAccessControlListMapping>(request, (response) => callback(response));
        }

        /// <summary>
        /// Lists all IpAccessControlLists mapped to a SIP Domain
        /// </summary>
        /// <param name="domainSid">The Sid of the SIP Domain to list mappings for</param>
        /// <returns></returns>
		public virtual void ListIpAccessControlListMappings(string domainSid, Action<IpAccessControlListMappingResult> callback)
        {
            ListIpAccessControlListMappings(domainSid, null, null, callback);
        }

        /// <summary>
        /// Lists all IpAccessControlLists mapped to a SIP Domain
        /// </summary>
        /// <param name="domainSid">The Sid of the SIP Domain to list mappings for</param>
        /// <param name="pageNumber"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        [System.Obsolete("Use GetNextPage and GetPreviousPage for paging. Page parameter is scheduled for end of life https://www.twilio.com/engineering/2015/04/16/replacing-absolute-paging-with-relative-paging")]
		public virtual void ListIpAccessControlListMappings(string domainSid, int? pageNumber, int? count, Action<IpAccessControlListMappingResult> callback)
        {
            Require.Argument("DomainSid", domainSid);

            var request = new RestRequest();
            request.Resource = "Accounts/{AccountSid}/SIP/Domains/{DomainSid}/IpAccessControlListMappings.json";
            request.AddUrlSegment("DomainSid", domainSid);

            if (pageNumber.HasValue) request.AddParameter("Page", pageNumber.Value);
            if (count.HasValue) request.AddParameter("PageSize", count.Value);

            ExecuteAsync<IpAccessControlListMappingResult>(request, (response) => callback(response));
        }

        /// <summary>
        /// Maps an IpAccessControlList to a specific SIP Domain
        /// </summary>
        /// <param name="domainSid">The Sid of the SIP Domain to map to</param>
        /// <param name="ipAccessControlListSid">The Sid of the IpAccessControlList to map to</param>
        /// <returns></returns>
		public virtual void CreateIpAccessControlListMapping(string domainSid, string ipAccessControlListSid, Action<IpAccessControlListMapping> callback)
        {
            Require.Argument("DomainSid", domainSid);

            var request = new RestRequest(Method.POST);
            request.Resource = "Accounts/{AccountSid}/SIP/Domains/{DomainSid}/IpAccessControlListMappings.json";
            request.AddUrlSegment("DomainSid", domainSid);

            request.AddParameter("IpAccessControlListSid", ipAccessControlListSid);

            ExecuteAsync<IpAccessControlListMapping>(request, (response) => callback(response));
        }

        /// <summary>
        /// Deletes a IpAccessControlListMapping from a SIP Domain
        /// </summary>
        /// <param name="domainSid">The Sid of the SIP Domain</param>
        /// <param name="ipAccessControlListMappingSid">The Sid of the IpAccessControlListMapping to delete</param>
        /// <returns></returns>
		public virtual void DeleteIpAccessControlListMapping(string domainSid, string ipAccessControlListMappingSid, Action<DeleteStatus> callback)
        {
            Require.Argument("DomainSid", domainSid);

            var request = new RestRequest(Method.DELETE);
            request.Resource = "Accounts/{AccountSid}/SIP/Domains/{DomainSid}/IpAccessControlListMappings/{IpAccessControlListMappingSid}.json";
            request.AddUrlSegment("DomainSid", domainSid);

            request.AddParameter("IpAccessControlListMappingSid", ipAccessControlListMappingSid, ParameterType.UrlSegment);

            ExecuteAsync(request, (response) => { callback(response.StatusCode == System.Net.HttpStatusCode.NoContent ? DeleteStatus.Success : DeleteStatus.Failed); });
        }

        /// <summary>
        /// Gets a specific CredentialList mapping for a SIP Domain
        /// </summary>
        /// <param name="domainSid">The Sid of the mapped SIP Domain</param>
        /// <param name="credentialListMappingSid">The Sid of the mapped CredentialList</param>
        /// <returns></returns>
		public virtual void GetCredentialListMapping(string domainSid, string credentialListMappingSid, Action<CredentialListMapping> callback)
        {
            var request = new RestRequest();
            request.Resource = "Accounts/{AccountSid}/SIP/Domains/{DomainSid}/CredentialListMappings/{CredentialListMappingSid}.json";
            request.AddUrlSegment("DomainSid", domainSid);
            request.AddUrlSegment("CredentialListMappingSid", credentialListMappingSid);

            ExecuteAsync<CredentialListMapping>(request, (response) => callback(response));
        }

        /// <summary>
        /// Lists all CredentialLists mapped to a SIP Domain
        /// </summary>
        /// <param name="domainSid">The Sid of the SIP Domain to list mappings for</param>
        /// <returns></returns>
		public virtual void ListCredentialListMappings(string domainSid, Action<CredentialListMappingResult> callback)
        {
            ListCredentialListMappings(domainSid, null, null, callback);
        }

        /// <summary>
        /// Lists all IpAccessControlLists mapped to a SIP Domain
        /// </summary>
        /// <param name="domainSid">The Sid of the SIP Domain to list mappings for</param>
        /// <param name="pageNumber"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        [System.Obsolete("Use GetNextPage and GetPreviousPage for paging. Page parameter is scheduled for end of life https://www.twilio.com/engineering/2015/04/16/replacing-absolute-paging-with-relative-paging")]
		public virtual void ListCredentialListMappings(string domainSid, int? pageNumber, int? count, Action<CredentialListMappingResult> callback)
        {
            var request = new RestRequest();
            request.Resource = "Accounts/{AccountSid}/SIP/Domains/{DomainSid}/CredentialListMappings.json";
            request.AddUrlSegment("DomainSid", domainSid);

            if (pageNumber.HasValue) request.AddParameter("Page", pageNumber.Value);
            if (count.HasValue) request.AddParameter("PageSize", count.Value);

            ExecuteAsync<CredentialListMappingResult>(request, (response) => callback(response));
        }

        /// <summary>
        /// Maps a CredentialList to a specific SIP Domain
        /// </summary>
        /// <param name="domainSid">The Sid of the SIP Domain to map to</param>
        /// <param name="credentialListSid">The Sid of the CredentialList to map to</param>
        /// <returns></returns>
		public virtual void CreateCredentialListMapping(string domainSid, string credentialListSid, Action<IpAccessControlListMapping> callback)
        {
            Require.Argument("DomainSid", domainSid);

            var request = new RestRequest(Method.POST);
            request.Resource = "Accounts/{AccountSid}/SIP/Domains/{DomainSid}/CredentialListMappings.json";
            request.AddUrlSegment("DomainSid", domainSid);

            request.AddParameter("CredentialListSid", credentialListSid);

            ExecuteAsync<IpAccessControlListMapping>(request, (response) => callback(response));
        }

        /// <summary>
        /// Deletes a CredentialListMapping from a SIP Domain
        /// </summary>
        /// <param name="domainSid">The Sid of the SIP Domain</param>
        /// <param name="credentialListMappingSid">The Sid of the CredentialListMapping to delete</param>
        /// <returns></returns>
		public virtual void DeleteCredentialListMapping(string domainSid, string credentialListMappingSid, Action<DeleteStatus> callback)
        {
            Require.Argument("DomainSid", domainSid);

            var request = new RestRequest(Method.DELETE);
            request.Resource = "Accounts/{AccountSid}/SIP/Domains/{DomainSid}/CredentialListMappings/{CredentialListMappingSid}.json";
            request.AddUrlSegment("DomainSid", domainSid);

            request.AddParameter("CredentialListMappingSid", credentialListMappingSid, ParameterType.UrlSegment);

            ExecuteAsync(request, (response) => { callback(response.StatusCode == System.Net.HttpStatusCode.NoContent ? DeleteStatus.Success : DeleteStatus.Failed); });
        }

        /// <summary>
        /// Gets a specific IpAccessControlList resource
        /// </summary>
        /// <param name="ipAccessControlListSid">The Sid of the IpAccessControlList resource</param>
        /// <returns></returns>
		public virtual void GetIpAccessControlList(string ipAccessControlListSid, Action<IpAccessControlList> callback)
        {
            var request = new RestRequest();
            request.Resource = "Accounts/{AccountSid}/SIP/IpAccessControlLists/{IpAccessControlListSid}.json";
            request.AddUrlSegment("IpAccessControlListSid", ipAccessControlListSid);

            ExecuteAsync<IpAccessControlList>(request, (response) => callback(response));
        }

        /// <summary>
        /// Lists all IpAccessControlLists for this account
        /// </summary>
        /// <returns></returns>
		public virtual void ListIpAccessControlLists(Action<IpAccessControlListResult> callback)
        {
            ListIpAccessControlLists(null, null, callback);
        }

        /// <summary>
        /// Lists all IpAccessControlLists for this account
        /// </summary>
        /// <param name="pageNumber"></param>

        /// <param name="count"></param>
        /// <returns></returns>
        [System.Obsolete("Use GetNextPage and GetPreviousPage for paging. Page parameter is scheduled for end of life https://www.twilio.com/engineering/2015/04/16/replacing-absolute-paging-with-relative-paging")]
		public virtual void ListIpAccessControlLists(int? pageNumber, int? count, Action<IpAccessControlListResult> callback)
        {
            var request = new RestRequest();
            request.Resource = "Accounts/{AccountSid}/SIP/IpAccessControlLists.json";

            if (pageNumber.HasValue) request.AddParameter("Page", pageNumber.Value);
            if (count.HasValue) request.AddParameter("PageSize", count.Value);

            ExecuteAsync<IpAccessControlListResult>(request, (response) => callback(response));
        }

        /// <summary>
        /// Creates a new IpAccessControlList resource
        /// </summary>
        /// <param name="friendlyName">The name of the IpAccessControlList to create.</param>
        /// <returns></returns>
		public virtual void CreateIpAccessControlList(string friendlyName, Action<IpAccessControlList> callback)
        {
            var request = new RestRequest(Method.POST);
            request.Resource = "Accounts/{AccountSid}/SIP/IpAccessControlLists.json";

            request.AddParameter("FriendlyName", friendlyName);

            ExecuteAsync<IpAccessControlList>(request, (response) => callback(response));
        }

        /// <summary>
        /// Updates a specific IpAccessControlList resource
        /// </summary>
        /// <param name="ipAccessControlListSid">The Sid of the IpAccessControlList to update</param>
        /// <param name="friendlyName">The name of the IpAccessControlList</param>
        /// <returns></returns>
		public virtual void UpdateIpAccessControlList(string ipAccessControlListSid, string friendlyName, Action<IpAccessControlList> callback)
        {
            var request = new RestRequest(Method.POST);
            request.Resource = "Accounts/{AccountSid}/SIP/IpAccessControlLists/{IpAccessControlListSid}.json";
            request.AddUrlSegment("IpAccessControlListSid", ipAccessControlListSid);

            request.AddParameter("FriendlyName", friendlyName);

            ExecuteAsync<IpAccessControlList>(request, (response) => callback(response));
        }

        /// <summary>
        /// Deletes a specific IpAccessControlList resource
        /// </summary>
        /// <param name="ipAccessControlListSid">The Sid of the IpAccessControlList Domain to delete</param>
        /// <returns></returns>
		public virtual void DeleteIpAccessControlList(string ipAccessControlListSid, Action<DeleteStatus> callback)
        {
            var request = new RestRequest(Method.DELETE);
            request.Resource = "Accounts/{AccountSid}/SIP/IpAccessControlLists/{IpAccessControlListSid}.json";

            request.AddParameter("IpAccessControlListSid", ipAccessControlListSid, ParameterType.UrlSegment);

            ExecuteAsync(request, (response) => { callback(response.StatusCode == System.Net.HttpStatusCode.NoContent ? DeleteStatus.Success : DeleteStatus.Failed); });
        }

        /// <summary>
        /// Locates and returns a specific IpAddress resource located in an IpAccessControlList
        /// </summary>
        /// <param name="ipAccessControlListSid">The Sid of the IpAccessControlList</param>
        /// <param name="ipAddressSid">The Sid of the IpAddress to locate</param>
        /// <returns></returns>
        public virtual void GetIpAddress(string ipAccessControlListSid, string ipAddressSid, Action<IpAddress> callback)
        {
            var request = new RestRequest();
            request.Resource = "Accounts/{AccountSid}/SIP/IpAccessControlLists/{IpAccessControlListSid}/Addresses/{IpAddressSid}.json";
            request.AddUrlSegment("IpAccessControlListSid", ipAccessControlListSid);
            request.AddUrlSegment("IpAddressSid", ipAddressSid);

            ExecuteAsync<IpAddress>(request, (response) => callback(response));
        }

        /// <summary>
        /// Return a lists all IpAddresses associated with an IpAccessControlList
        /// </summary>
        /// <param name="ipAccessControlListSid">The Sid of the IpAccessControlList</param>
        /// <returns></returns>
		public virtual void ListIpAddresses(string ipAccessControlListSid, Action<IpAddressResult> callback)
        {
            ListIpAddresses(ipAccessControlListSid, null, null, callback);
        }

        /// <summary>
        /// Return a lists all IpAddresses associated with an IpAccessControlList
        /// </summary>
        /// <param name="ipAccessControlListSid">The Sid of the IpAccessControlList</param>
        /// <param name="pageNumber"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        [System.Obsolete("Use GetNextPage and GetPreviousPage for paging. Page parameter is scheduled for end of life https://www.twilio.com/engineering/2015/04/16/replacing-absolute-paging-with-relative-paging")]
		public virtual void ListIpAddresses(string ipAccessControlListSid, int? pageNumber, int? count, Action<IpAddressResult> callback)
        {
            var request = new RestRequest();
            request.Resource = "Accounts/{AccountSid}/SIP/IpAccessControlLists/{IpAccessControlListSid}/Addresses.json";
            request.AddUrlSegment("IpAccessControlListSid", ipAccessControlListSid);

            if (pageNumber.HasValue) request.AddParameter("Page", pageNumber.Value);
            if (count.HasValue) request.AddParameter("PageSize", count.Value);

            ExecuteAsync<IpAddressResult>(request, (response) => callback(response));
        }

        /// <summary>
        /// Creates a new IpAddress resource
        /// </summary>
        /// <param name="ipAccessControlListSid">The Sid of the IpAccessControList to add the IpAddress to</param>
        /// <param name="friendlyName">The name of the IpAddress to create.</param>
        /// <param name="ipAddress">The address value of the IpAddress</param>
        /// <returns></returns>
        public virtual void CreateIpAddress(string ipAccessControlListSid, string friendlyName, string ipAddress, Action<IpAddress> callback)
        {
            var request = new RestRequest(Method.POST);
            request.Resource = "Accounts/{AccountSid}/SIP/IpAccessControlLists/{IpAccessControlListSid}/Addresses.json";
            request.AddUrlSegment("IpAccessControlListSid", ipAccessControlListSid);

            request.AddParameter("FriendlyName", friendlyName);
            request.AddParameter("IpAddress", ipAddress);

            ExecuteAsync<IpAddress>(request, (response) => callback(response));
        }

        /// <summary>
        /// Updates a specific IpAddress resource
        /// </summary>
        /// <param name="ipAccessControlListSid">The Sid of the IpAccessControlList</param>
        /// <param name="ipAddressSid">The Sid of the IpAddress to update</param>
        /// <param name="friendlyName">The name of the IpAddress</param>
        /// <param name="ipAddress">The address value of the IpAddress</param>
        /// <returns></returns>
        public virtual void UpdateIpAddress(string ipAccessControlListSid, string ipAddressSid, string friendlyName, string ipAddress, Action<IpAddress> callback)
        {
            var request = new RestRequest(Method.POST);
            request.Resource = "Accounts/{AccountSid}/SIP/IpAccessControlLists/{IpAccessControlListSid}/Addresses/{IpAddressSid}.json";
            request.AddUrlSegment("IpAccessControlListSid", ipAccessControlListSid);
            request.AddUrlSegment("IpAddressSid", ipAddressSid);

            request.AddParameter("FriendlyName", friendlyName);
            request.AddParameter("IpAddressSid", ipAddressSid);

            ExecuteAsync<IpAddress>(request, (response) => callback(response));
        }

        /// <summary>
        /// Deletes a specific IpAddress resource
        /// </summary>
        /// <param name="domainSid">The Sid of the IpAddress to delete</param>
        /// <returns></returns>
        public virtual void DeleteIpAddress(string ipAccessControlListSid, string ipAddressSid, Action<DeleteStatus> callback)
        {
            var request = new RestRequest(Method.DELETE);
            request.Resource = "Accounts/{AccountSid}/SIP/IpAccessControlLists/{IpAccessControlListSid}/Addresses/{IpAddressSid}.json";

            request.AddParameter("IpAccessControlListSid", ipAccessControlListSid, ParameterType.UrlSegment);
            request.AddParameter("IpAddressSid", ipAddressSid, ParameterType.UrlSegment);

            ExecuteAsync(request, (response) => { callback(response.StatusCode == System.Net.HttpStatusCode.NoContent ? DeleteStatus.Success : DeleteStatus.Failed); });
        }

        /// <summary>
        /// Locates and returns a specific CredentialList resource
        /// </summary>
        /// <param name="credentialListSid">The Sid of the CredentialList to locate</param>
        /// <returns></returns>
		public virtual void GetCredentialList(string credentialListSid, Action<CredentialList> callback)
        {
            var request = new RestRequest();
            request.Resource = "Accounts/{AccountSid}/SIP/CredentialLists/{CredentialListSid}.json";
            request.AddUrlSegment("CredentialListSid", credentialListSid);

            ExecuteAsync<CredentialList>(request, (response) => callback(response));
        }

        /// <summary>
        /// Return a list all CredentialsList resources
        /// </summary>
        /// <returns></returns>
		public virtual void ListCredentialLists(Action<CredentialListResult> callback)
        {
            ListCredentialLists(null, null, callback);
        }

        /// <summary>
        /// Return a list all CredentialsList resources
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        [System.Obsolete("Use GetNextPage and GetPreviousPage for paging. Page parameter is scheduled for end of life https://www.twilio.com/engineering/2015/04/16/replacing-absolute-paging-with-relative-paging")]
		public virtual void ListCredentialLists(int? pageNumber, int? count, Action<CredentialListResult> callback)
        {
            var request = new RestRequest();
            request.Resource = "Accounts/{AccountSid}/SIP/CredentialLists.json";

            if (pageNumber.HasValue) request.AddParameter("Page", pageNumber.Value);
            if (count.HasValue) request.AddParameter("PageSize", count.Value);

            ExecuteAsync<CredentialListResult>(request, (response) => callback(response));
        }

        /// <summary>
        /// Creates a new CredentialList resource
        /// </summary>
        /// <param name="friendlyName">The name of the CredentialList to create.</param>
        /// <returns></returns>
		public virtual void CreateCredentialList(string friendlyName, Action<CredentialList> callback)
        {
            var request = new RestRequest(Method.POST);
            request.Resource = "Accounts/{AccountSid}/SIP/CredentialLists.json";

            request.AddParameter("FriendlyName", friendlyName);

            ExecuteAsync<CredentialList>(request, (response) => callback(response));
        }

        /// <summary>
        /// Updates a specific CredentialList resource
        /// </summary>
        /// <param name="credentialListSid">The Sid of the CredentialList</param>
        /// <param name="friendlyName">The name of the CredentialList</param>
        /// <returns></returns>
		public virtual void UpdateCredentialList(string credentialListSid, string friendlyName, Action<CredentialList> callback)
        {
            var request = new RestRequest(Method.POST);
            request.Resource = "Accounts/{AccountSid}/SIP/CredentialLists/{CredentialListSid}.json";
            request.AddUrlSegment("CredentialListSid", credentialListSid);

            request.AddParameter("FriendlyName", friendlyName);

            ExecuteAsync<CredentialList>(request, (response) => callback(response));
        }

        /// <summary>
        /// Deletes a specific CredentialList resource
        /// </summary>
        /// <param name="domainSid">The Sid of the CredentialList to delete</param>
        /// <returns></returns>
		public virtual void DeleteCredentialList(string credentialListSid, Action<DeleteStatus> callback)
        {
            var request = new RestRequest(Method.DELETE);
            request.Resource = "Accounts/{AccountSid}/SIP/CredentialLists/{CredentialListSid}.json";

            request.AddParameter("CredentialListSid", credentialListSid, ParameterType.UrlSegment);

            ExecuteAsync(request, (response) => { callback(response.StatusCode == System.Net.HttpStatusCode.NoContent ? DeleteStatus.Success : DeleteStatus.Failed); });
        }

        /// <summary>
        /// Locates and returns a specific Credential in a CredentialList resource
        /// </summary>
        /// <param name="credentialListSid">The Sid of the CredentialList</param>
        /// <param name="credentialSid">The Sid of the Credential to locate</param>
        /// <returns></returns>
        public virtual void GetCredential(string credentialListSid, string credentialSid, Action<Credential> callback)
        {
            var request = new RestRequest();
            request.Resource = "Accounts/{AccountSid}/SIP/CredentialLists/{CredentialListSid}/Credentials/{CredentialSid}.json";
            request.AddUrlSegment("CredentialListSid", credentialListSid);
            request.AddUrlSegment("CredentialSid", credentialSid);

            ExecuteAsync<Credential>(request, (response) => callback(response));
        }

        /// <summary>
        /// List all Credentials for a CredentialList
        /// </summary>
        /// <param name="credentialListSid"></param>
        /// <returns></returns>
		public virtual void ListCredentials(string credentialListSid, Action<CredentialResult> callback)
        {
            ListCredentials(credentialListSid, null, null, callback);
        }

        /// <summary>
        /// List all Credentials for a CredentialList
        /// </summary>
        /// <param name="credentialListSid">The Sid of the CredentialList</param>
        /// <param name="pageNumber"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        [System.Obsolete("Use GetNextPage and GetPreviousPage for paging. Page parameter is scheduled for end of life https://www.twilio.com/engineering/2015/04/16/replacing-absolute-paging-with-relative-paging")]
		public virtual void ListCredentials(string credentialListSid, int? pageNumber, int? count, Action<CredentialResult> callback)
        {
            var request = new RestRequest();
            request.Resource = "Accounts/{AccountSid}/SIP/CredentialLists/{CredentialListSid}/Credentials.json";
            request.AddUrlSegment("CredentialListSid", credentialListSid);

            if (pageNumber.HasValue) request.AddParameter("Page", pageNumber.Value);
            if (count.HasValue) request.AddParameter("PageSize", count.Value);

            ExecuteAsync<CredentialResult>(request, (response) => callback(response));
        }

        /// <summary>
        /// Create a new Credential resource in a CredentialList
        /// </summary>
        /// <param name="credentialListSid">The Sid of the CredentialList to add the new Credential to</param>
        /// <param name="username">The Credential Username</param>
        /// <param name="password">The Credential Password</param>
        /// <returns></returns>
        public virtual void CreateCredential(string credentialListSid, string username, string password, Action<Credential> callback)
        {
            var request = new RestRequest(Method.POST);
            request.Resource = "Accounts/{AccountSid}/SIP/CredentialLists/{CredentialListSid}/Credentials.json";
            request.AddUrlSegment("CredentialListSid", credentialListSid);

            request.AddParameter("Username", username);
            request.AddParameter("Password", password);

            ExecuteAsync<Credential>(request, (response) => callback(response));
        }

        /// <summary>
        /// Updates a specific Credential resource
        /// </summary>
        /// <param name="credentialListSid">The Sid of the CredentialList that contains the Credential</param>
        /// <param name="credentialSid">The Sid of the Credential to update</param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public virtual void UpdateCredential(string credentialListSid, string credentialSid, string username, string password, Action<Credential> callback)
        {
            var request = new RestRequest(Method.POST);
            request.Resource = "Accounts/{AccountSid}/SIP/CredentialLists/{CredentialListSid}/Credentials/{CredentialSid}.json";
            request.AddUrlSegment("CredentialListSid", credentialListSid);
            request.AddUrlSegment("CredentialSid", credentialSid);

            request.AddParameter("Username", username);
            request.AddParameter("Password", password);

            ExecuteAsync<Credential>(request, (response) => callback(response));
        }

        /// <summary>
        /// Deletes a Credential from a CredentialList
        /// </summary>
        /// <param name="credentialListSid">The Sid of the CredentialList to delete from</param>
        /// <param name="credentialSid">The Sid of the Credential to delete</param>
        /// <returns></returns>
        public virtual void DeleteCredential(string credentialListSid, string credentialSid, Action<DeleteStatus> callback)
        {
            var request = new RestRequest(Method.DELETE);
            request.Resource = "Accounts/{AccountSid}/SIP/CredentialLists/{CredentialListSid}/Credentials/{CredentialSid}.json";

            request.AddParameter("CredentialListSid", credentialListSid, ParameterType.UrlSegment);
            request.AddParameter("CredentialSid", credentialSid, ParameterType.UrlSegment);

            ExecuteAsync(request, (response) => { callback(response.StatusCode == System.Net.HttpStatusCode.NoContent ? DeleteStatus.Success : DeleteStatus.Failed); });
        }
    }
}

using Simple;
using System.Threading.Tasks;

namespace Twilio
{
    public partial class TwilioRestClient
    {
        /// <summary>
        /// Locates and returns a specific SIP Domain resource
        /// </summary>
        /// <param name="domainSid">The Sid of the SIP Domain to locate</param>
        /// <returns></returns>
        public virtual async Task<Domain> GetDomain(string domainSid)
        {
            var request = new RestRequest();
            request.Resource = "Accounts/{AccountSid}/SIP/Domains/{DomainSid}.json";
            request.AddUrlSegment("DomainSid", domainSid);

            return await Execute<Domain>(request);
        }

        /// <summary>
        /// Return a list of all SIP Domain resources
        /// </summary>
        /// <returns></returns>
        public virtual async Task<DomainResult> ListDomains()
        {
            return await ListDomains(null, null);
        }

        /// <summary>
        /// Return a list of all SIP Domain resources
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public virtual async Task<DomainResult> ListDomains(int? pageNumber, int? count)
        {
            var request = new RestRequest();
            request.Resource = "Accounts/{AccountSid}/SIP/Domains.json";

            if (pageNumber.HasValue) request.AddParameter("Page", pageNumber.Value);
            if (count.HasValue) request.AddParameter("PageSize", count.Value);

            return await Execute<DomainResult>(request);
        }

        /// <summary>
        /// Creates a new SIP Domain resource
        /// </summary>
        /// <param name="domainName">The name of the SIP Domain to create.  You must pick a unique domain name that ends in ".sip.twilio.com"</param>
        /// <returns></returns>
        public virtual async Task<Domain> CreateDomain(string domainName)
        {
            DomainOptions options = new DomainOptions() { DomainName = domainName };
            return await CreateDomain(options);
        }

        /// <summary>
        /// Creates a new SIP Domain resource
        /// </summary>
        /// <param name="options">Optional parameters to use when creating a new SIP domain.  DomainName is required and you must pick a unique domain name that ends in ".sip.twilio.com"</param>
        /// <returns></returns>
        public virtual async Task<Domain> CreateDomain(DomainOptions options)
        {
            var request = new RestRequest(Method.POST);
            request.Resource = "Accounts/{AccountSid}/SIP/Domains.json";

            AddDomainOptions(options, request);

            return await Execute<Domain>(request);
        }
       
        /// <summary>
        /// Updates a specific SIP Domain resource
        /// </summary>
        /// <param name="domainSid">The Sid of the SIP Domain to update</param>
        /// <param name="options">Optional parameters for a SIP domain</param>
        /// <returns></returns>
        public virtual async Task<Domain> UpdateDomain(string domainSid, DomainOptions options)
        {
            Require.Argument("DomainSid", domainSid);

            var request = new RestRequest(Method.POST);
            request.Resource = "Accounts/{AccountSid}/SIP/Domains/{DomainSid}.json";

            request.AddUrlSegment("DomainSid", domainSid);
            AddDomainOptions(options, request);

            return await Execute<Domain>(request);
        }

        /// <summary>
        /// Deletes a specific SIP Domain resource
        /// </summary>
        /// <param name="domainSid">The Sid of the SIP Domain to delete</param>
        /// <returns></returns>
        public virtual async Task<DeleteStatus> DeleteDomain(string domainSid)
        {
            Require.Argument("DomainSid", domainSid);
            var request = new RestRequest(Method.DELETE);
            request.Resource = "Accounts/{AccountSid}/SIP/Domains/{DomainSid}.json";

            request.AddParameter("DomainSid", domainSid, ParameterType.UrlSegment);

            var response = await Execute(request);
            return response.StatusCode == System.Net.HttpStatusCode.NoContent ? DeleteStatus.Success : DeleteStatus.Failed;
        }


        /// <summary>
        /// Gets a specific IpAccessControlList mapping for a SIP Domain
        /// </summary>
        /// <param name="domainSid">The Sid of the mapped SIP Domain</param>
        /// <param name="ipAccessControlListMappingSid">The Sid of the mapped IpAccessControlList</param>
        /// <returns></returns>
        public virtual async Task<IpAccessControlListMapping> GetIpAccessControlListMapping(string domainSid, string ipAccessControlListMappingSid)
        {
            var request = new RestRequest();
            request.Resource = "Accounts/{AccountSid}/SIP/Domains/{DomainSid}/IpAccessControlListMappings/{IpAccessControlListMappingSid}.json";
            request.AddUrlSegment("DomainSid", domainSid);
            request.AddUrlSegment("IpAccessControlListMappingSid", ipAccessControlListMappingSid);

            return await Execute<IpAccessControlListMapping>(request);
        }

        /// <summary>
        /// Lists all IpAccessControlLists mapped to a SIP Domain
        /// </summary>
        /// <param name="domainSid">The Sid of the SIP Domain to list mappings for</param>
        /// <returns></returns>
        public virtual async Task<IpAccessControlListMappingResult> ListIpAccessControlListMappings(string domainSid)
        {
            return await ListIpAccessControlListMappings(domainSid, null, null);
        }

        /// <summary>
        /// Lists all IpAccessControlLists mapped to a SIP Domain
        /// </summary>
        /// <param name="domainSid">The Sid of the SIP Domain to list mappings for</param>
        /// <param name="pageNumber"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public virtual async Task<IpAccessControlListMappingResult> ListIpAccessControlListMappings(string domainSid, int? pageNumber, int? count)
        {
            Require.Argument("DomainSid", domainSid);

            var request = new RestRequest();
            request.Resource = "Accounts/{AccountSid}/SIP/Domains/{DomainSid}/IpAccessControlListMappings.json";
            request.AddUrlSegment("DomainSid", domainSid);

            if (pageNumber.HasValue) request.AddParameter("Page", pageNumber.Value);
            if (count.HasValue) request.AddParameter("PageSize", count.Value);

            return await Execute<IpAccessControlListMappingResult>(request);
        }

        /// <summary>
        /// Maps an IpAccessControlList to a specific SIP Domain
        /// </summary>
        /// <param name="domainSid">The Sid of the SIP Domain to map to</param>
        /// <param name="ipAccessControlListSid">The Sid of the IpAccessControlList to map to</param>
        /// <returns></returns>
        public virtual async Task<IpAccessControlListMapping> CreateIpAccessControlListMapping(string domainSid, string ipAccessControlListSid)
        {
            Require.Argument("DomainSid", domainSid);

            var request = new RestRequest(Method.POST);
            request.Resource = "Accounts/{AccountSid}/SIP/Domains/{DomainSid}/IpAccessControlListMappings.json";
            request.AddUrlSegment("DomainSid", domainSid);

            request.AddParameter("IpAccessControlListSid", ipAccessControlListSid);

            return await Execute<IpAccessControlListMapping>(request);
        }

        /// <summary>
        /// Deletes a IpAccessControlListMapping from a SIP Domain
        /// </summary>
        /// <param name="domainSid">The Sid of the SIP Domain</param>
        /// <param name="ipAccessControlListMappingSid">The Sid of the IpAccessControlListMapping to delete</param>
        /// <returns></returns>
        public virtual async Task<DeleteStatus> DeleteIpAccessControlListMapping(string domainSid, string ipAccessControlListMappingSid)
        {
            Require.Argument("DomainSid", domainSid);
            
            var request = new RestRequest(Method.DELETE);
            request.Resource = "Accounts/{AccountSid}/SIP/Domains/{DomainSid}/IpAccessControlListMappings/{IpAccessControlListMappingSid}.json";
            request.AddUrlSegment("DomainSid", domainSid);

            request.AddParameter("IpAccessControlListMappingSid", ipAccessControlListMappingSid, ParameterType.UrlSegment);

            var response = await Execute(request);
            return response.StatusCode == System.Net.HttpStatusCode.NoContent ? DeleteStatus.Success : DeleteStatus.Failed;
        }

        /// <summary>
        /// Gets a specific CredentialList mapping for a SIP Domain
        /// </summary>
        /// <param name="domainSid">The Sid of the mapped SIP Domain</param>
        /// <param name="credentialListMappingSid">The Sid of the mapped CredentialList</param>
        /// <returns></returns>
        public virtual async Task<CredentialListMapping> GetCredentialListMapping(string domainSid, string credentialListMappingSid)
        {
            var request = new RestRequest();
            request.Resource = "Accounts/{AccountSid}/SIP/Domains/{DomainSid}/CredentialListMappings/{CredentialListMappingSid}.json";
            request.AddUrlSegment("DomainSid", domainSid);
            request.AddUrlSegment("CredentialListMappingSid", credentialListMappingSid);

            return await Execute<CredentialListMapping>(request);
        }

        /// <summary>
        /// Lists all CredentialLists mapped to a SIP Domain
        /// </summary>
        /// <param name="domainSid">The Sid of the SIP Domain to list mappings for</param>
        /// <returns></returns>
        public virtual async Task<CredentialListMappingResult> ListCredentialListMappings(string domainSid)
        {
            return await ListCredentialListMappings(domainSid, null, null);
        }

        /// <summary>
        /// Lists all IpAccessControlLists mapped to a SIP Domain
        /// </summary>
        /// <param name="domainSid">The Sid of the SIP Domain to list mappings for</param>
        /// <param name="pageNumber"></param>        
        /// <param name="count"></param>
        /// <returns></returns>
        public virtual async Task<CredentialListMappingResult> ListCredentialListMappings(string domainSid, int? pageNumber, int? count)
        {
            var request = new RestRequest();
            request.Resource = "Accounts/{AccountSid}/SIP/Domains/{DomainSid}/CredentialListMappings.json";
            request.AddUrlSegment("DomainSid", domainSid);

            if (pageNumber.HasValue) request.AddParameter("Page", pageNumber.Value);
            if (count.HasValue) request.AddParameter("PageSize", count.Value);

            return await Execute<CredentialListMappingResult>(request);
        }

        /// <summary>
        /// Maps a CredentialList to a specific SIP Domain
        /// </summary>
        /// <param name="domainSid">The Sid of the SIP Domain to map to</param>
        /// <param name="credentialListSid">The Sid of the CredentialList to map to</param>
        /// <returns></returns>
        public virtual async Task<IpAccessControlListMapping> CreateCredentialListMapping(string domainSid, string credentialListSid)
        {
            Require.Argument("DomainSid", domainSid);

            var request = new RestRequest(Method.POST);
            request.Resource = "Accounts/{AccountSid}/SIP/Domains/{DomainSid}/CredentialListMappings.json";
            request.AddUrlSegment("DomainSid", domainSid);

            request.AddParameter("CredentialListSid", credentialListSid);

            return await Execute<IpAccessControlListMapping>(request);
        }

        /// <summary>
        /// Deletes a CredentialListMapping from a SIP Domain
        /// </summary>
        /// <param name="domainSid">The Sid of the SIP Domain</param>
        /// <param name="credentialListMappingSid">The Sid of the CredentialListMapping to delete</param>
        /// <returns></returns>
        public virtual async Task<DeleteStatus> DeleteCredentialListMapping(string domainSid, string credentialListMappingSid)
        {
            Require.Argument("DomainSid", domainSid);

            var request = new RestRequest(Method.DELETE);
            request.Resource = "Accounts/{AccountSid}/SIP/Domains/{DomainSid}/CredentialListMappings/{CredentialListMappingSid}.json";
            request.AddUrlSegment("DomainSid", domainSid);

            request.AddParameter("CredentialListMappingSid", credentialListMappingSid, ParameterType.UrlSegment);

            var response = await Execute(request);
            return response.StatusCode == System.Net.HttpStatusCode.NoContent ? DeleteStatus.Success : DeleteStatus.Failed;
        }

        /// <summary>
        /// Gets a specific IpAccessControlList resource
        /// </summary>
        /// <param name="ipAccessControlListSid">The Sid of the IpAccessControlList resource</param>
        /// <returns></returns>
        public virtual async Task<IpAccessControlList> GetIpAccessControlList(string ipAccessControlListSid)
        {
            var request = new RestRequest();
            request.Resource = "Accounts/{AccountSid}/SIP/IpAccessControlLists/{IpAccessControlListSid}.json";
            request.AddUrlSegment("IpAccessControlListSid", ipAccessControlListSid);

            return await Execute<IpAccessControlList>(request);
        }

        /// <summary>
        /// Lists all IpAccessControlLists for this account
        /// </summary>
        /// <returns></returns>
        public virtual async Task<IpAccessControlListResult> ListIpAccessControlLists() 
        {
            return await ListIpAccessControlLists(null, null);
        }

        /// <summary>
        /// Lists all IpAccessControlLists for this account
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public virtual async Task<IpAccessControlListResult> ListIpAccessControlLists(int? pageNumber, int? count)
        {
            var request = new RestRequest();
            request.Resource = "Accounts/{AccountSid}/SIP/IpAccessControlLists.json";

            if (pageNumber.HasValue) request.AddParameter("Page", pageNumber.Value);
            if (count.HasValue) request.AddParameter("PageSize", count.Value);

            return await Execute<IpAccessControlListResult>(request);
        }

        /// <summary>
        /// Creates a new IpAccessControlList resource
        /// </summary>
        /// <param name="friendlyName">The name of the IpAccessControlList to create.</param>
        /// <returns></returns>
        public virtual async Task<IpAccessControlList> CreateIpAccessControlList(string friendlyName)
        {
            var request = new RestRequest(Method.POST);
            request.Resource = "Accounts/{AccountSid}/SIP/IpAccessControlLists.json";

            request.AddParameter("FriendlyName", friendlyName);

            return await Execute<IpAccessControlList>(request);
        }

        /// <summary>
        /// Updates a specific IpAccessControlList resource
        /// </summary>
        /// <param name="ipAccessControlListSid">The Sid of the IpAccessControlList to update</param>
        /// <param name="friendlyName">The name of the IpAccessControlList</param>
        /// <returns></returns>
        public virtual async Task<IpAccessControlList> UpdateIpAccessControlList(string ipAccessControlListSid, string friendlyName)
        {
            var request = new RestRequest(Method.POST);
            request.Resource = "Accounts/{AccountSid}/SIP/IpAccessControlLists/{IpAccessControlListSid}.json";
            request.AddUrlSegment("IpAccessControlListSid", ipAccessControlListSid);

            request.AddParameter("FriendlyName", friendlyName);

            return await Execute<IpAccessControlList>(request);
        }

        /// <summary>
        /// Deletes a specific IpAccessControlList resource
        /// </summary>
        /// <param name="ipAccessControlListSid">The Sid of the IpAccessControlList Domain to delete</param>
        /// <returns></returns>
        public virtual async Task<DeleteStatus> DeleteIpAccessControlList(string ipAccessControlListSid)
        {
            var request = new RestRequest(Method.DELETE);
            request.Resource = "Accounts/{AccountSid}/SIP/IpAccessControlLists/{IpAccessControlListSid}.json";

            request.AddParameter("IpAccessControlListSid", ipAccessControlListSid, ParameterType.UrlSegment);

            var response = await Execute(request);
            return response.StatusCode == System.Net.HttpStatusCode.NoContent ? DeleteStatus.Success : DeleteStatus.Failed;
        }

        /// <summary>
        /// Locates and returns a specific IpAddress resource located in an IpAccessControlList
        /// </summary>
        /// <param name="ipAccessControlListSid">The Sid of the IpAccessControlList</param>
        /// <param name="ipAddressSid">The Sid of the IpAddress to locate</param>
        /// <returns></returns>
        public virtual async Task<IpAddress> GetIpAddress(string ipAccessControlListSid, string ipAddressSid)
        {
            var request = new RestRequest();
            request.Resource = "Accounts/{AccountSid}/SIP/IpAccessControlLists/{IpAccessControlListSid}/IpAddresses/{IpAddressSid}.json";
            request.AddUrlSegment("IpAccessControlListSid", ipAccessControlListSid);
            request.AddUrlSegment("IpAddressSid", ipAddressSid);

            return await Execute<IpAddress>(request);
        }

        /// <summary>
        /// Return a lists all IpAddresses associated with an IpAccessControlList
        /// </summary>
        /// <param name="ipAccessControlListSid">The Sid of the IpAccessControlList</param>
        /// <returns></returns>
        public virtual async Task<IpAddressResult> ListIpAddresses(string ipAccessControlListSid)
        {
            return await ListIpAddresses(ipAccessControlListSid, null, null);
        }

        /// <summary>
        /// Return a lists all IpAddresses associated with an IpAccessControlList
        /// </summary>
        /// <param name="ipAccessControlListSid">The Sid of the IpAccessControlList</param>
        /// <param name="pageNumber"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public virtual async Task<IpAddressResult> ListIpAddresses(string ipAccessControlListSid, int? pageNumber, int? count)
        {
            var request = new RestRequest();
            request.Resource = "Accounts/{AccountSid}/SIP/IpAccessControlLists/{IpAccessControlListSid}/IpAddresses.json";
            request.AddUrlSegment("IpAccessControlListSid", ipAccessControlListSid);

            if (pageNumber.HasValue) request.AddParameter("Page", pageNumber.Value);
            if (count.HasValue) request.AddParameter("PageSize", count.Value);

            return await Execute<IpAddressResult>(request);
        }

        /// <summary>
        /// Creates a new IpAddress resource
        /// </summary>
        /// <param name="ipAccessControlListSid">The Sid of the IpAccessControList to add the IpAddress to</param>
        /// <param name="friendlyName">The name of the IpAddress to create.</param>
        /// <param name="ipAddress">The address value of the IpAddress</param>
        /// <returns></returns>
        public virtual async Task<IpAddress> CreateIpAddress(string ipAccessControlListSid, string friendlyName, string ipAddress)
        {
            var request = new RestRequest(Method.POST);
            request.Resource = "Accounts/{AccountSid}/SIP/IpAccessControlLists/{IpAccessControlListSid}/IpAddresses.json";
            request.AddUrlSegment("IpAccessControlListSid", ipAccessControlListSid);

            request.AddParameter("FriendlyName", friendlyName);
            request.AddParameter("IpAddress", ipAddress);

            return await Execute<IpAddress>(request);
        }

        /// <summary>
        /// Updates a specific IpAddress resource
        /// </summary>
        /// <param name="ipAccessControlListSid">The Sid of the IpAccessControlList</param>
        /// <param name="ipAddressSid">The Sid of the IpAddress to update</param>
        /// <param name="friendlyName">The name of the IpAddress</param>
        /// <param name="ipAddress">The address value of the IpAddress</param>
        /// <returns></returns>
        public virtual async Task<IpAddress> UpdateIpAddress(string ipAccessControlListSid, string ipAddressSid, string friendlyName, string ipAddress)
        {
            var request = new RestRequest(Method.POST);
            request.Resource = "Accounts/{AccountSid}/SIP/IpAccessControlLists/{IpAccessControlListSid}/IpAddresses/{IpAddressSid}.json";
            request.AddUrlSegment("IpAccessControlListSid", ipAccessControlListSid);
            request.AddUrlSegment("IpAddressSid", ipAddressSid);

            if (friendlyName.HasValue()) request.AddParameter("FriendlyName", friendlyName);
            if (ipAddress.HasValue()) request.AddParameter("IpAddress", ipAddress);

            return await Execute<IpAddress>(request);
        }

        /// <summary>
        /// Deletes a specific IpAddress resource
        /// </summary>
        /// <param name="ipAccessControlListSid">The Sid of the IpAddress to delete</param>
        /// <param name="ipAddressSid"></param>
        /// <returns></returns>
        public virtual async Task<DeleteStatus> DeleteIpAddress(string ipAccessControlListSid, string ipAddressSid)
        {
            var request = new RestRequest(Method.DELETE);
            request.Resource = "Accounts/{AccountSid}/SIP/IpAccessControlLists/{IpAccessControlListSid}/IpAddresses/{IpAddressSid}.json";

            request.AddParameter("IpAccessControlListSid", ipAccessControlListSid, ParameterType.UrlSegment);
            request.AddParameter("IpAddressSid", ipAddressSid, ParameterType.UrlSegment);

            var response = await Execute(request);
            return response.StatusCode == System.Net.HttpStatusCode.NoContent ? DeleteStatus.Success : DeleteStatus.Failed;
        }

        /// <summary>
        /// Locates and returns a specific CredentialList resource
        /// </summary>
        /// <param name="credentialListSid">The Sid of the CredentialList to locate</param>
        /// <returns></returns>
        public virtual async Task<CredentialList> GetCredentialList(string credentialListSid)
        {
            var request = new RestRequest();
            request.Resource = "Accounts/{AccountSid}/SIP/CredentialLists/{CredentialListSid}.json";
            request.AddUrlSegment("CredentialListSid", credentialListSid);

            return await Execute<CredentialList>(request);
        }

        /// <summary>
        /// Return a list all CredentialsList resources
        /// </summary>
        /// <returns></returns>
        public virtual async Task<CredentialListResult> ListCredentialLists()
        {
            return await ListCredentialLists(null, null);
        }

        /// <summary>
        /// Return a list all CredentialsList resources
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public virtual async Task<CredentialListResult> ListCredentialLists(int? pageNumber, int? count)
        {
            var request = new RestRequest();
            request.Resource = "Accounts/{AccountSid}/SIP/CredentialLists.json";

            if (pageNumber.HasValue) request.AddParameter("Page", pageNumber.Value);
            if (count.HasValue) request.AddParameter("PageSize", count.Value);

            return await Execute<CredentialListResult>(request);
        }

        /// <summary>
        /// Creates a new CredentialList resource
        /// </summary>
        /// <param name="friendlyName">The name of the CredentialList to create.</param>
        /// <returns></returns>
        public virtual async Task<CredentialList> CreateCredentialList(string friendlyName)
        {
            var request = new RestRequest(Method.POST);
            request.Resource = "Accounts/{AccountSid}/SIP/CredentialLists.json";

            request.AddParameter("FriendlyName", friendlyName);

            return await Execute<CredentialList>(request);
        }

        /// <summary>
        /// Updates a specific CredentialList resource
        /// </summary>
        /// <param name="credentialListSid">The Sid of the CredentialList</param>
        /// <param name="friendlyName">The name of the CredentialList</param>
        /// <returns></returns>
        public virtual async Task<CredentialList> UpdateCredentialList(string credentialListSid, string friendlyName)
        {
            var request = new RestRequest(Method.POST);
            request.Resource = "Accounts/{AccountSid}/SIP/CredentialLists/{CredentialListSid}.json";
            request.AddUrlSegment("CredentialListSid", credentialListSid);

            request.AddParameter("FriendlyName", friendlyName);

            return await Execute<CredentialList>(request);
        }

        /// <summary>
        /// Deletes a specific CredentialList resource
        /// </summary>
        /// <param name="credentialListSid">The Sid of the CredentialList to delete</param>
        /// <returns></returns>
        public virtual async Task<DeleteStatus> DeleteCredentialList(string credentialListSid)
        {
            var request = new RestRequest(Method.DELETE);
            request.Resource = "Accounts/{AccountSid}/SIP/CredentialLists/{CredentialListSid}.json";

            request.AddParameter("CredentialListSid", credentialListSid, ParameterType.UrlSegment);

            var response = await Execute(request);
            return response.StatusCode == System.Net.HttpStatusCode.NoContent ? DeleteStatus.Success : DeleteStatus.Failed;
        }

        /// <summary>
        /// Locates and returns a specific Credential in a CredentialList resource
        /// </summary>
        /// <param name="credentialListSid">The Sid of the CredentialList</param>
        /// <param name="credentialSid">The Sid of the Credential to locate</param>
        /// <returns></returns>
        public virtual async Task<Credential> GetCredential(string credentialListSid, string credentialSid)
        {
            var request = new RestRequest();
            request.Resource = "Accounts/{AccountSid}/SIP/CredentialLists/{CredentialListSid}/Credentials/{CredentialSid}.json";
            request.AddUrlSegment("CredentialListSid", credentialListSid); 
            request.AddUrlSegment("CredentialSid", credentialSid);

            return await Execute<Credential>(request);
        }

        /// <summary>
        /// List all Credentials for a CredentialList
        /// </summary>
        /// <param name="credentialListSid"></param>
        /// <returns></returns>
        public virtual async Task<CredentialResult> ListCredentials(string credentialListSid)
        {
            return await ListCredentials(credentialListSid, null, null);
        }

        /// <summary>
        /// List all Credentials for a CredentialList
        /// </summary>
        /// <param name="credentialListSid">The Sid of the CredentialList</param>
        /// <param name="pageNumber"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public virtual async Task<CredentialResult> ListCredentials(string credentialListSid, int? pageNumber, int? count)
        {
            var request = new RestRequest();
            request.Resource = "Accounts/{AccountSid}/SIP/CredentialLists/{CredentialListSid}/Credentials.json";
            request.AddUrlSegment("CredentialListSid", credentialListSid); 

            if (pageNumber.HasValue) request.AddParameter("Page", pageNumber.Value);
            if (count.HasValue) request.AddParameter("PageSize", count.Value);

            return await Execute<CredentialResult>(request);
        }

        /// <summary>
        /// Create a new Credential resource in a CredentialList
        /// </summary>
        /// <param name="credentialListSid">The Sid of the CredentialList to add the new Credential to</param>
        /// <param name="username">The Credential Username</param>
        /// <param name="password">The Credential Password</param>
        /// <returns></returns>
        public virtual async Task<Credential> CreateCredential(string credentialListSid, string username, string password)
        {
            var request = new RestRequest(Method.POST);
            request.Resource = "Accounts/{AccountSid}/SIP/CredentialLists/{CredentialListSid}/Credentials.json";
            request.AddUrlSegment("CredentialListSid", credentialListSid); 

            request.AddParameter("Username", username);
            request.AddParameter("Password", password);

            return await Execute<Credential>(request);
        }

        /// <summary>
        /// Updates a specific Credential resource
        /// </summary>
        /// <param name="credentialListSid">The Sid of the CredentialList that contains the Credential</param>
        /// <param name="credentialSid">The Sid of the Credential to update</param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public virtual async Task<Credential> UpdateCredential(string credentialListSid, string credentialSid, string username, string password)
        {
            var request = new RestRequest(Method.POST);
            request.Resource = "Accounts/{AccountSid}/SIP/CredentialLists/{CredentialListSid}/Credentials/{CredentialSid}.json";
            request.AddUrlSegment("CredentialListSid", credentialListSid);
            request.AddUrlSegment("CredentialSid", credentialSid);

            if (username.HasValue()) request.AddParameter("Username", username);
            if (password.HasValue()) request.AddParameter("Password", password);

            return await Execute<Credential>(request);
        }

        /// <summary>
        /// Deletes a Credential from a CredentialList
        /// </summary>
        /// <param name="credentialListSid">The Sid of the CredentialList to delete from</param>
        /// <param name="credentialSid">The Sid of the Credential to delete</param>
        /// <returns></returns>
        public virtual async Task<DeleteStatus> DeleteCredential(string credentialListSid, string credentialSid)
        {
            var request = new RestRequest(Method.DELETE);
            request.Resource = "Accounts/{AccountSid}/SIP/CredentialLists/{CredentialListSid}/Credentials/{CredentialSid}.json";

            request.AddParameter("CredentialListSid", credentialListSid, ParameterType.UrlSegment);
            request.AddParameter("CredentialSid", credentialSid, ParameterType.UrlSegment);

            var response = await Execute(request);
            return response.StatusCode == System.Net.HttpStatusCode.NoContent ? DeleteStatus.Success : DeleteStatus.Failed;
        }
    }
}

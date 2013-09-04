using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        /// <param name="sipDomainSid">The Sid of the SIP Domain to locate</param>
        /// <returns></returns>
        public SipDomain GetSipDomain(string sipDomainSid)
        {
            var request = new RestRequest();
            request.Resource = "Accounts/{AccountSid}/SIP/Domains/{SipDomainSid}.json";
            request.AddUrlSegment("SipDomainSid", sipDomainSid);

            return Execute<SipDomain>(request);
        }

        /// <summary>
        /// Return a list of all SIP Domain resources
        /// </summary>
        /// <returns></returns>
        public SipDomainResult ListSipDomains()
        {
            return ListSipDomains(null, null, null);
        }

        /// <summary>
        /// Return a list of all SIP Domain resources
        /// </summary>
        /// <param name="dateSent"></param>
        /// <param name="pageNumber"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public SipDomainResult ListSipDomains(DateTime? dateSent, int? pageNumber, int? count)
        {
            var request = new RestRequest();
            request.Resource = "Accounts/{AccountSid}/SIP/Domains.json";

            if (dateSent.HasValue) request.AddParameter("DateSent", dateSent.Value.ToString("yyyy-MM-dd"));
            if (pageNumber.HasValue) request.AddParameter("Page", pageNumber.Value);
            if (count.HasValue) request.AddParameter("PageSize", count.Value);

            return Execute<SipDomainResult>(request);
        }

        /// <summary>
        /// Creates a new SIP Domain resource
        /// </summary>
        /// <param name="domainName">The name of the SIP Domain to create.  You must pick a unique domain name that ends in ".sip.twilio.com"</param>
        /// <returns></returns>
        public SipDomain CreateSipDomain(string domainName)
        {
            SipDomainOptions options = new SipDomainOptions() { DomainName = domainName };
            return CreateSipDomain(options);
        }

        /// <summary>
        /// Creates a new SIP Domain resource
        /// </summary>
        /// <param name="options">Optional parameters to use when creating a new SIP domain.  DomainName is required and you must pick a unique domain name that ends in ".sip.twilio.com"</param>
        /// <returns></returns>
        public SipDomain CreateSipDomain(SipDomainOptions options)
        {
            var request = new RestRequest(Method.POST);
            request.Resource = "Accounts/{AccountSid}/SIP/Domains.json";

            AddSipDomainOptions(options, request);

            return Execute<SipDomain>(request);
        }

        private static void AddSipDomainOptions(SipDomainOptions options, RestRequest request)
        {
            request.AddParameter("DomainName", options.DomainName);

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
        /// <param name="sipDomainSid">The Sid of the SIP Domain to update</param>
        /// <param name="options">Optional parameters for a SIP domain</param>
        /// <returns></returns>
        public SipDomain UpdateSipDomain(string sipDomainSid, SipDomainOptions options)
        {
            Require.Argument("SipDomainSid", sipDomainSid);

            var request = new RestRequest(Method.POST);
            request.Resource = "Accounts/{AccountSid}/SIP/Domains/{SipDomainSid}.json";

            request.AddParameter("SipDomainSid", sipDomainSid, ParameterType.UrlSegment);
            
            AddSipDomainOptions(options, request);

            return Execute<SipDomain>(request);
        }

        /// <summary>
        /// Deletes a specific SIP Domain resource
        /// </summary>
        /// <param name="sipDomainSid">The Sid of the SIP Domain to delete</param>
        /// <returns></returns>
        public DeleteStatus DeleteSipDomain(string sipDomainSid)
        {
            Require.Argument("SipDomainSid", sipDomainSid);
            var request = new RestRequest(Method.DELETE);
            request.Resource = "Accounts/{AccountSid}/SIP/Domains/{SipDomainSid}.json";

            request.AddParameter("SipDomainSid", sipDomainSid, ParameterType.UrlSegment);

            var response = Execute(request);
            return response.StatusCode == System.Net.HttpStatusCode.NoContent ? DeleteStatus.Success : DeleteStatus.Failed;
        }


        /// <summary>
        /// Gets a specific IpAccessControlList mapping for a SIP Domain
        /// </summary>
        /// <param name="sipDomainSid">The Sid of the mapped SIP Domain</param>
        /// <param name="ipAccessControlListMappingSid">The Sid of the mapped IpAccessControlList</param>
        /// <returns></returns>
        public IpAccessControlListMapping GetIpAccessControlListMapping(string sipDomainSid, string ipAccessControlListMappingSid)
        {
            var request = new RestRequest();
            request.Resource = "Accounts/{AccountSid}/SIP/Domains/{SipDomainSid}/IpAccessControlListMappings/{IpAccessControlListMappingSid}.json";
            request.AddUrlSegment("SipDomainSid", sipDomainSid);
            request.AddUrlSegment("IpAccessControlListMappingSid", ipAccessControlListMappingSid);

            return Execute<IpAccessControlListMapping>(request);
        }

        /// <summary>
        /// Lists all IpAccessControlLists mapped to a SIP Domain
        /// </summary>
        /// <param name="sipDomainSid">The Sid of the SIP Domain to list mappings for</param>
        /// <returns></returns>
        public IpAccessControlListMappingResult ListIpAccessControlListMappings(string sipDomainSid)
        {
            return ListIpAccessControlListMappings(sipDomainSid, null, null, null);
        }

        /// <summary>
        /// Lists all IpAccessControlLists mapped to a SIP Domain
        /// </summary>
        /// <param name="sipDomainSid">The Sid of the SIP Domain to list mappings for</param>
        /// <param name="dateSent"></param>
        /// <param name="pageNumber"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public IpAccessControlListMappingResult ListIpAccessControlListMappings(string sipDomainSid, DateTime? dateSent, int? pageNumber, int? count)
        {
            Require.Argument("SipDomainSid", sipDomainSid);

            var request = new RestRequest();
            request.Resource = "Accounts/{AccountSid}/SIP/Domains/{SipDomainSid}/IpAccessControlListMappings.json";
            request.AddUrlSegment("SipDomainSid", sipDomainSid);

            if (dateSent.HasValue) request.AddParameter("DateSent", dateSent.Value.ToString("yyyy-MM-dd"));
            if (pageNumber.HasValue) request.AddParameter("Page", pageNumber.Value);
            if (count.HasValue) request.AddParameter("PageSize", count.Value);

            return Execute<IpAccessControlListMappingResult>(request);
        }

        /// <summary>
        /// Maps an IpAccessControlList to a specific SIP Domain
        /// </summary>
        /// <param name="sipDomainSid">The Sid of the SIP Domain to map to</param>
        /// <param name="ipAccessControlListSid">The Sid of the IpAccessControlList to map to</param>
        /// <returns></returns>
        public IpAccessControlListMapping CreateIpAccessControlListMapping(string sipDomainSid, string ipAccessControlListSid)
        {
            Require.Argument("SipDomainSid", sipDomainSid);

            var request = new RestRequest(Method.POST);
            request.Resource = "Accounts/{AccountSid}/SIP/Domains/{SipDomainSid}/IpAccessControlListMappings.json";
            request.AddUrlSegment("SipDomainSid", sipDomainSid);

            request.AddParameter("IpAccessControlListSid", ipAccessControlListSid);

            return Execute<IpAccessControlListMapping>(request);
        }

        /// <summary>
        /// Deletes a IpAccessControlListMapping from a SIP Domain
        /// </summary>
        /// <param name="sipDomainSid">The Sid of the SIP Domain</param>
        /// <param name="ipAccessControlListMappingSid">The Sid of the IpAccessControlListMapping to delete</param>
        /// <returns></returns>
        public DeleteStatus DeleteIpAccessControlListMapping(string sipDomainSid, string ipAccessControlListMappingSid)
        {
            Require.Argument("SipDomainSid", sipDomainSid);
            
            var request = new RestRequest(Method.DELETE);
            request.Resource = "Accounts/{AccountSid}/SIP/Domains/{SipDomainSid}/IpAccessControlListMappings/{IpAccessControlListMappingSid}.json";
            request.AddUrlSegment("SipDomainSid", sipDomainSid);

            request.AddParameter("IpAccessControlListMappingSid", ipAccessControlListMappingSid, ParameterType.UrlSegment);

            var response = Execute(request);
            return response.StatusCode == System.Net.HttpStatusCode.NoContent ? DeleteStatus.Success : DeleteStatus.Failed;
        }

        /// <summary>
        /// Gets a specific CredentialList mapping for a SIP Domain
        /// </summary>
        /// <param name="sipDomainSid">The Sid of the mapped SIP Domain</param>
        /// <param name="ipAccessControlListMappingSid">The Sid of the mapped CredentialList</param>
        /// <returns></returns>
        public Message GetCredentialListMapping(string sipDomainSid, string credentialListMappingSid)
        {
            var request = new RestRequest();
            request.Resource = "Accounts/{AccountSid}/SIP/Domains/{SipDomainSid}/CredentialListMappings/{CredentialListMappingSid}.json";
            request.AddUrlSegment("SipDomainSid", sipDomainSid);
            request.AddUrlSegment("CredentialListMappingSid", credentialListMappingSid);

            return Execute<Message>(request);
        }

        /// <summary>
        /// Lists all CredentialLists mapped to a SIP Domain
        /// </summary>
        /// <param name="sipDomainSid">The Sid of the SIP Domain to list mappings for</param>
        /// <returns></returns>
        public CredentialListMappingResult ListCredentialListMappings(string sipDomainSid)
        {
            return ListCredentialListMappings(sipDomainSid, null, null, null);
        }

        /// <summary>
        /// Lists all IpAccessControlLists mapped to a SIP Domain
        /// </summary>
        /// <param name="sipDomainSid">The Sid of the SIP Domain to list mappings for</param>
        /// <param name="pageNumber"></param>
        /// <param name="dateSent"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public CredentialListMappingResult ListCredentialListMappings(string sipDomainSid, DateTime? dateSent, int? pageNumber, int? count)
        {
            var request = new RestRequest();
            request.Resource = "Accounts/{AccountSid}/SIP/Domains/{SipDomainSid}/CredentialListMappings.json";
            request.AddUrlSegment("SipDomainSid", sipDomainSid);

            if (dateSent.HasValue) request.AddParameter("DateSent", dateSent.Value.ToString("yyyy-MM-dd"));
            if (pageNumber.HasValue) request.AddParameter("Page", pageNumber.Value);
            if (count.HasValue) request.AddParameter("PageSize", count.Value);

            return Execute<CredentialListMappingResult>(request);
        }

        /// <summary>
        /// Maps a CredentialList to a specific SIP Domain
        /// </summary>
        /// <param name="sipDomainSid">The Sid of the SIP Domain to map to</param>
        /// <param name="credentialListSid">The Sid of the CredentialList to map to</param>
        /// <returns></returns>
        public IpAccessControlListMapping CreateCredentialListMapping(string sipDomainSid, string credentialListSid)
        {
            Require.Argument("SipDomainSid", sipDomainSid);

            var request = new RestRequest(Method.POST);
            request.Resource = "Accounts/{AccountSid}/SIP/Domains/{SipDomainSid}/CredentialListMappings.json";
            request.AddUrlSegment("SipDomainSid", sipDomainSid);

            request.AddParameter("CredentialListSid", credentialListSid);

            return Execute<IpAccessControlListMapping>(request);
        }

        /// <summary>
        /// Deletes a CredentialListMapping from a SIP Domain
        /// </summary>
        /// <param name="sipDomainSid">The Sid of the SIP Domain</param>
        /// <param name="credentialListMappingSid">The Sid of the CredentialListMapping to delete</param>
        /// <returns></returns>
        public DeleteStatus DeleteCredentialListMapping(string sipDomainSid, string credentialListMappingSid)
        {
            Require.Argument("SipDomainSid", sipDomainSid);

            var request = new RestRequest(Method.DELETE);
            request.Resource = "Accounts/{AccountSid}/SIP/Domains/{SipDomainSid}/CredentialListMappings/{CredentialListMappingSid}.json";
            request.AddUrlSegment("SipDomainSid", sipDomainSid);

            request.AddParameter("CredentialListMappingSid", credentialListMappingSid, ParameterType.UrlSegment);

            var response = Execute(request);
            return response.StatusCode == System.Net.HttpStatusCode.NoContent ? DeleteStatus.Success : DeleteStatus.Failed;
        }

        /// <summary>
        /// Gets a specific IpAccessControlList resource
        /// </summary>
        /// <param name="ipAccessControlListSid">The Sid of the IpAccessControlList resource</param>
        /// <returns></returns>
        public IpAccessControlList GetIpAccessControlList(string ipAccessControlListSid)
        {
            var request = new RestRequest();
            request.Resource = "Accounts/{AccountSid}/SIP/IpAccessControlLists/{IpAccessControlListSid}.json";
            request.AddUrlSegment("IpAccessControlListSid", ipAccessControlListSid);

            return Execute<IpAccessControlList>(request);
        }

        /// <summary>
        /// Lists all IpAccessControlLists for this account
        /// </summary>
        /// <returns></returns>
        public IpAccessControlListResult ListIpAccessControlLists() 
        {
            return ListIpAccessControlLists(null, null, null);
        }

        /// <summary>
        /// Lists all IpAccessControlLists for this account
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <param name="dateSent"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public IpAccessControlListResult ListIpAccessControlLists(DateTime? dateSent, int? pageNumber, int? count)
        {
            var request = new RestRequest();
            request.Resource = "Accounts/{AccountSid}/SIP/IpAccessControlLists.json";

            if (dateSent.HasValue) request.AddParameter("DateSent", dateSent.Value.ToString("yyyy-MM-dd"));
            if (pageNumber.HasValue) request.AddParameter("Page", pageNumber.Value);
            if (count.HasValue) request.AddParameter("PageSize", count.Value);

            return Execute<IpAccessControlListResult>(request);
        }

        public IpAccessControlList CreateIpAccessControlList(string friendlyName)
        {
            var request = new RestRequest(Method.POST);
            request.Resource = "Accounts/{AccountSid}/SIP/IpAccessControlLists.json";

            request.AddParameter("FriendlyName", friendlyName);

            return Execute<IpAccessControlList>(request);
        }

        public IpAccessControlList UpdateIpAccessControlList(string ipAccessControlListSid, string friendlyName)
        {
            var request = new RestRequest(Method.POST);
            request.Resource = "Accounts/{AccountSid}/SIP/IpAccessControlLists/{IpAccessControlListSid}.json";
            request.AddUrlSegment("IpAccessControlListSid", ipAccessControlListSid);

            request.AddParameter("FriendlyName", friendlyName);

            return Execute<IpAccessControlList>(request);
        }

        public DeleteStatus DeleteIpAccessControlList(string ipAccessControlListSid)
        {
            var request = new RestRequest(Method.DELETE);
            request.Resource = "Accounts/{AccountSid}/SIP/IpAccessControlLists/{IpAccessControlListSid}.json";

            request.AddParameter("IpAccessControlListSid", ipAccessControlListSid, ParameterType.UrlSegment);

            var response = Execute(request);
            return response.StatusCode == System.Net.HttpStatusCode.NoContent ? DeleteStatus.Success : DeleteStatus.Failed;
        }

        //ipaddress GET/POST/DELETE
        public IpAddress GetIpAddress(string ipAccessControlListSid, string ipAddressSid)
        {
            var request = new RestRequest();
            request.Resource = "Accounts/{AccountSid}/SIP/IpAccessControlLists/{IpAccessControlListSid}/Addresses/{IpAddressSid}.json";
            request.AddUrlSegment("IpAccessControlListSid", ipAccessControlListSid);
            request.AddUrlSegment("IpAddressSid", ipAddressSid);

            return Execute<IpAddress>(request);
        }

        public IpAddressResult ListIpAddresses(string ipAccessControlListSid)
        {
            return ListIpAddresses(ipAccessControlListSid, null, null, null);
        }

        public IpAddressResult ListIpAddresses(string ipAccessControlListSid, DateTime? dateSent, int? pageNumber, int? count)
        {
            var request = new RestRequest();
            request.Resource = "Accounts/{AccountSid}/SIP/IpAccessControlLists/{IpAccessControlListSid}/Addresses.json";
            request.AddUrlSegment("IpAccessControlListSid", ipAccessControlListSid);

            if (dateSent.HasValue) request.AddParameter("DateSent", dateSent.Value.ToString("yyyy-MM-dd"));
            if (pageNumber.HasValue) request.AddParameter("Page", pageNumber.Value);
            if (count.HasValue) request.AddParameter("PageSize", count.Value);

            return Execute<IpAddressResult>(request);
        }

        public IpAddress CreateIpAddress(string ipAccessControlListSid, string friendlyName, string ipAddress)
        {
            var request = new RestRequest(Method.POST);
            request.Resource = "Accounts/{AccountSid}/SIP/IpAccessControlLists/{IpAccessControlListSid}/Addresses.json";
            request.AddUrlSegment("IpAccessControlListSid", ipAccessControlListSid);

            request.AddParameter("FriendlyName", friendlyName);
            request.AddParameter("IpAddress", ipAddress);

            return Execute<IpAddress>(request);
        }

        public IpAddress UpdateIpAddress(string ipAccessControlListSid, string ipAddressSid, string friendlyName, string ipAddress)
        {
            var request = new RestRequest(Method.POST);
            request.Resource = "Accounts/{AccountSid}/SIP/IpAccessControlLists/{IpAccessControlListSid}/Addresses/{IpAddressSid}.json";
            request.AddUrlSegment("IpAccessControlListSid", ipAccessControlListSid);
            request.AddUrlSegment("IpAddressSid", ipAddressSid);

            request.AddParameter("FriendlyName", friendlyName);
            request.AddParameter("IpAddressSid", ipAddressSid);

            return Execute<IpAddress>(request);
        }

        public DeleteStatus DeleteIpAddress(string ipAccessControlListSid, string ipAddressSid)
        {
            var request = new RestRequest(Method.DELETE);
            request.Resource = "Accounts/{AccountSid}/SIP/IpAccessControlLists/{IpAccessControlListSid}/Addresses/{IpAddressSid}.json";

            request.AddParameter("IpAccessControlListSid", ipAccessControlListSid, ParameterType.UrlSegment);
            request.AddParameter("IpAddressSid", ipAddressSid, ParameterType.UrlSegment);

            var response = Execute(request);
            return response.StatusCode == System.Net.HttpStatusCode.NoContent ? DeleteStatus.Success : DeleteStatus.Failed;
        }

        //credentiallists GET/POST
        public CredentialList GetCredentialList(string credentialListSid)
        {
            var request = new RestRequest();
            request.Resource = "Accounts/{AccountSid}/SIP/CredentialLists/{CredentialListSid}.json";
            request.AddUrlSegment("CredentialListSid", credentialListSid);

            return Execute<CredentialList>(request);
        }

        public CredentialListResult ListCredentialLists()
        {
            return ListCredentialLists(null, null, null);
        }

        public CredentialListResult ListCredentialLists(DateTime? dateSent, int? pageNumber, int? count)
        {
            var request = new RestRequest();
            request.Resource = "Accounts/{AccountSid}/SIP/CredentialLists.json";

            if (dateSent.HasValue) request.AddParameter("DateSent", dateSent.Value.ToString("yyyy-MM-dd"));
            if (pageNumber.HasValue) request.AddParameter("Page", pageNumber.Value);
            if (count.HasValue) request.AddParameter("PageSize", count.Value);

            return Execute<CredentialListResult>(request);
        }

        public CredentialList CreateCredentialList(string friendlyName)
        {
            var request = new RestRequest(Method.POST);
            request.Resource = "Accounts/{AccountSid}/SIP/CredentialLists.json";

            request.AddParameter("FriendlyName", friendlyName);

            return Execute<CredentialList>(request);
        }

        public CredentialList UpdateCredentialList(string credentialListSid, string friendlyName)
        {
            var request = new RestRequest(Method.POST);
            request.Resource = "Accounts/{AccountSid}/SIP/CredentialLists/{CredentialListSid}.json";
            request.AddUrlSegment("CredentialListSid", credentialListSid);

            request.AddParameter("FriendlyName", friendlyName);

            return Execute<CredentialList>(request);
        }

        public DeleteStatus DeleteCredentialList(string credentialListSid)
        {
            var request = new RestRequest(Method.DELETE);
            request.Resource = "Accounts/{AccountSid}/SIP/CredentialLists/{CredentialListSid}.json";

            request.AddParameter("CredentialListSid", credentialListSid, ParameterType.UrlSegment);

            var response = Execute(request);
            return response.StatusCode == System.Net.HttpStatusCode.NoContent ? DeleteStatus.Success : DeleteStatus.Failed;
        }

        //credentials GET/POST/DELETE
        public Credential GetCredential(string credentialListSid, string credentialSid)
        {
            var request = new RestRequest();
            request.Resource = "Accounts/{AccountSid}/SIP/CredentialLists/{CredentialListSid}/Credentials/{CredentialSid}.json";
            request.AddUrlSegment("CredentialListSid", credentialListSid); 
            request.AddUrlSegment("CredentialSid", credentialSid);

            return Execute<Credential>(request);
        }

        public CredentialResult ListCredentials(string credentialListSid)
        {
            return ListCredentials(credentialListSid, null, null, null);
        }

        public CredentialResult ListCredentials(string credentialListSid, DateTime? dateSent, int? pageNumber, int? count)
        {
            var request = new RestRequest();
            request.Resource = "Accounts/{AccountSid}/SIP/CredentialLists/{CredentialListSid}/Credentials.json";
            request.AddUrlSegment("CredentialListSid", credentialListSid); 

            if (dateSent.HasValue) request.AddParameter("DateSent", dateSent.Value.ToString("yyyy-MM-dd"));
            if (pageNumber.HasValue) request.AddParameter("Page", pageNumber.Value);
            if (count.HasValue) request.AddParameter("PageSize", count.Value);

            return Execute<CredentialResult>(request);
        }

        public Credential CreateCredential(string credentialListSid, string username, string password)
        {
            var request = new RestRequest(Method.POST);
            request.Resource = "Accounts/{AccountSid}/SIP/CredentialLists/{CredentialListSid}/Credentials.json";
            request.AddUrlSegment("CredentialListSid", credentialListSid); 

            request.AddParameter("Username", username);
            request.AddParameter("Password", password);

            return Execute<Credential>(request);
        }

        public Credential UpdateCredential(string credentialListSid, string credentialSid, string username, string password)
        {
            var request = new RestRequest(Method.POST);
            request.Resource = "Accounts/{AccountSid}/SIP/CredentialLists/{CredentialListSid}/Credentials/{CredentialSid}.json";
            request.AddUrlSegment("CredentialListSid", credentialListSid);
            request.AddUrlSegment("CredentialSid", credentialSid);

            request.AddParameter("Username", username);
            request.AddParameter("Password", password);

            return Execute<Credential>(request);
        }

        public DeleteStatus DeleteCredential(string credentialListSid, string credentialSid)
        {
            var request = new RestRequest(Method.DELETE);
            request.Resource = "Accounts/{AccountSid}/SIP/CredentialLists/{CredentialListSid}/Credentials/{CredentialSid}.json";

            request.AddParameter("CredentialListSid", credentialListSid, ParameterType.UrlSegment);
            request.AddParameter("CredentialSid", credentialSid, ParameterType.UrlSegment);

            var response = Execute(request);
            return response.StatusCode == System.Net.HttpStatusCode.NoContent ? DeleteStatus.Success : DeleteStatus.Failed;
        }
    }
}

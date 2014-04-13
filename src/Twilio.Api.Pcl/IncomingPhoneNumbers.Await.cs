using System;
using Simple;
using System.Threading.Tasks;

namespace Twilio
{
    public partial class TwilioRestClient
    {
        /// <summary>
        /// Retrieve the details for an incoming phone number
        /// </summary>
        /// <param name="incomingPhoneNumberSid">The Sid of the number to retrieve</param>
        public virtual async Task<IncomingPhoneNumber> GetIncomingPhoneNumber(string incomingPhoneNumberSid)
        {
            var request = new RestRequest();
            request.Resource = "Accounts/{AccountSid}/IncomingPhoneNumbers/{IncomingPhoneNumberSid}.json";
            
            request.AddUrlSegment("IncomingPhoneNumberSid", incomingPhoneNumberSid);

            return await Execute<IncomingPhoneNumber>(request);
        }

        /// <summary>
        /// List all incoming phone numbers on current account
        /// </summary>
        public virtual async Task<IncomingPhoneNumberResult> ListIncomingPhoneNumbers()
        {
            return await ListIncomingPhoneNumbers(null, null, null, null);
        }

        /// <summary>
        /// List incoming phone numbers on current account with filters
        /// </summary>
        /// <param name="phoneNumber">Optional phone number to match</param>
        /// <param name="friendlyName">Optional friendly name to match</param>
        /// <param name="pageNumber">Page number to start retrieving results from</param>
        /// <param name="count">How many results to return</param>
        public virtual async Task<IncomingPhoneNumberResult> ListIncomingPhoneNumbers(string phoneNumber, string friendlyName, int? pageNumber, int? count)
        {
            var request = new RestRequest();
            request.Resource = "Accounts/{AccountSid}/IncomingPhoneNumbers.json";

            if (phoneNumber.HasValue()) request.AddParameter("PhoneNumber", phoneNumber);
            if (friendlyName.HasValue()) request.AddParameter("FriendlyName", friendlyName);

            if (pageNumber.HasValue) request.AddParameter("Page", pageNumber.Value);
            if (count.HasValue) request.AddParameter("PageSize", count.Value);

            return await Execute<IncomingPhoneNumberResult>(request);
        }

        /// <summary>
        /// List all incoming local phone numbers on current account
        /// </summary>
        public virtual async Task<IncomingPhoneNumberResult> ListIncomingLocalPhoneNumbers()
        {
            return await ListIncomingMobilePhoneNumbers(null, null, null, null);
        }

        /// <summary>
        /// List incoming local phone numbers on current account with filters
        /// </summary>
        /// <param name="phoneNumber">Optional phone number to match</param>
        /// <param name="friendlyName">Optional friendly name to match</param>
        /// <param name="pageNumber">Page number to start retrieving results from</param>
        /// <param name="count">How many results to return</param>
        public virtual async Task<IncomingPhoneNumberResult> ListIncomingLocalPhoneNumbers(string phoneNumber, string friendlyName, int? pageNumber, int? count)
        {
            var request = new RestRequest();
            request.Resource = "Accounts/{AccountSid}/IncomingPhoneNumbers/Local.json";

            if (phoneNumber.HasValue()) request.AddParameter("PhoneNumber", phoneNumber);
            if (friendlyName.HasValue()) request.AddParameter("FriendlyName", friendlyName);

            if (pageNumber.HasValue) request.AddParameter("Page", pageNumber.Value);
            if (count.HasValue) request.AddParameter("PageSize", count.Value);

            return await Execute<IncomingPhoneNumberResult>(request);
        }

        /// <summary>
        /// List all incoming toll free phone numbers on current account
        /// </summary>
        public virtual async Task<IncomingPhoneNumberResult> ListIncomingTollFreePhoneNumbers()
        {
            return await ListIncomingMobilePhoneNumbers(null, null, null, null);
        }

        /// <summary>
        /// List incoming toll free phone numbers on current account with filters
        /// </summary>
        /// <param name="phoneNumber">Optional phone number to match</param>
        /// <param name="friendlyName">Optional friendly name to match</param>
        /// <param name="pageNumber">Page number to start retrieving results from</param>
        /// <param name="count">How many results to return</param>
        public virtual async Task<IncomingPhoneNumberResult> ListIncomingTollFreePhoneNumbers(string phoneNumber, string friendlyName, int? pageNumber, int? count)
        {
            var request = new RestRequest();
            request.Resource = "Accounts/{AccountSid}/IncomingPhoneNumbers/TollFree.json";

            if (phoneNumber.HasValue()) request.AddParameter("PhoneNumber", phoneNumber);
            if (friendlyName.HasValue()) request.AddParameter("FriendlyName", friendlyName);

            if (pageNumber.HasValue) request.AddParameter("Page", pageNumber.Value);
            if (count.HasValue) request.AddParameter("PageSize", count.Value);

            return await Execute<IncomingPhoneNumberResult>(request);
        }

        /// <summary>
        /// List all incoming mobile phone numbers on current account
        /// </summary>
        public virtual async Task<IncomingPhoneNumberResult> ListIncomingMobilePhoneNumbers()
        {
            return await ListIncomingMobilePhoneNumbers(null, null, null, null);
        }

        /// <summary>
        /// List incoming mobile phone numbers on current account with filters
        /// </summary>
        /// <param name="phoneNumber">Optional phone number to match</param>
        /// <param name="friendlyName">Optional friendly name to match</param>
        /// <param name="pageNumber">Page number to start retrieving results from</param>
        /// <param name="count">How many results to return</param>
        public virtual async Task<IncomingPhoneNumberResult> ListIncomingMobilePhoneNumbers(string phoneNumber, string friendlyName, int? pageNumber, int? count)
        {
            var request = new RestRequest();
            request.Resource = "Accounts/{AccountSid}/IncomingPhoneNumbers/Mobile.json";

            if (phoneNumber.HasValue()) request.AddParameter("PhoneNumber", phoneNumber);
            if (friendlyName.HasValue()) request.AddParameter("FriendlyName", friendlyName);

            if (pageNumber.HasValue) request.AddParameter("Page", pageNumber.Value);
            if (count.HasValue) request.AddParameter("PageSize", count.Value);

            return await Execute<IncomingPhoneNumberResult>(request);
        }
        
        /// <summary>
        /// Purchase/provision a phone number
        /// </summary>
        /// <param name="options">Optional parameters to use when purchasing number</param>
        public virtual async Task<IncomingPhoneNumber> AddIncomingPhoneNumber(PhoneNumberOptions options)
        {
            var request = new RestRequest(Method.POST);
            request.Resource = "Accounts/{AccountSid}/IncomingPhoneNumbers.json";
            
            if (options.PhoneNumber.HasValue())
            {
                request.AddParameter("PhoneNumber", options.PhoneNumber);
            }
            else
            {
                if (options.AreaCode.HasValue()) request.AddParameter("AreaCode", options.AreaCode);
            }

            AddPhoneNumberOptionsToRequest(request, options);
            AddSmsOptionsToRequest(request, options);

            return await Execute<IncomingPhoneNumber>(request);
        }

        /// <summary>
        /// Purchase/provision a local phone number
        /// </summary>
        /// <param name="options">Optional parameters to use when purchasing number</param>
        public virtual async Task<IncomingPhoneNumber> AddIncomingLocalPhoneNumber(PhoneNumberOptions options)
        {
            Require.Argument("PhoneNumber", options.PhoneNumber);

            var request = new RestRequest(Method.POST);
            request.Resource = "Accounts/{AccountSid}/IncomingPhoneNumbers/Local.json";

            //PhoneNumber is required for this resource
            request.AddParameter("PhoneNumber", options.PhoneNumber);

            AddPhoneNumberOptionsToRequest(request, options);
            AddSmsOptionsToRequest(request, options);

            return await Execute<IncomingPhoneNumber>(request);
        }

        /// <summary>
        /// Purchase/provision a toll free phone number
        /// </summary>
        /// <param name="options">Optional parameters to use when purchasing number</param>
        public virtual async Task<IncomingPhoneNumber> AddIncomingTollFreePhoneNumber(PhoneNumberOptions options)
        {
            Require.Argument("PhoneNumber", options.PhoneNumber);

            var request = new RestRequest(Method.POST);
            request.Resource = "Accounts/{AccountSid}/IncomingPhoneNumbers/TollFree.json";

            //PhoneNumber is required for this resource
            request.AddParameter("PhoneNumber", options.PhoneNumber);

            AddPhoneNumberOptionsToRequest(request, options);
            AddSmsOptionsToRequest(request, options);

            return await Execute<IncomingPhoneNumber>(request);
        }

        /// <summary>
        /// Update the settings of an incoming phone number
        /// </summary>
        /// <param name="incomingPhoneNumberSid">The Sid of the phone number to update</param>
        /// <param name="options">Which settings to update. Only properties with values set will be updated.</param>
        public virtual async Task<IncomingPhoneNumber> UpdateIncomingPhoneNumber(string incomingPhoneNumberSid, PhoneNumberOptions options)
        {
            Require.Argument("IncomingPhoneNumberSid", incomingPhoneNumberSid);

            var request = new RestRequest(Method.POST);
            request.Resource = "Accounts/{AccountSid}/IncomingPhoneNumbers/{IncomingPhoneNumberSid}.json";
            
            request.AddParameter("IncomingPhoneNumberSid", incomingPhoneNumberSid, ParameterType.UrlSegment);
            AddPhoneNumberOptionsToRequest(request, options);
            AddSmsOptionsToRequest(request, options);

            return await Execute<IncomingPhoneNumber>(request);
        }

        /// <summary>
        /// Transfer phone numbes between master and sub accounts
        /// </summary>
        /// <param name="incomingPhoneNumberSid">The Sid of the phone number to move</param>
        /// <param name="sourceAccountSid">The AccountSid of the current owning account to move the phone number from</param>
        /// <param name="targetAccountSid">The AccountSid of the account to move the phone number to</param>
        public virtual async Task<IncomingPhoneNumber> TransferIncomingPhoneNumber(string incomingPhoneNumberSid, string sourceAccountSid, string targetAccountSid)
        {
            var request = new RestRequest(Method.POST);
            request.Resource = "Accounts/{AccountSid}/IncomingPhoneNumbers/{IncomingPhoneNumberSid}.json";

            request.AddParameter("AccountSid", sourceAccountSid, ParameterType.UrlSegment);
            request.AddParameter("IncomingPhoneNumberSid", incomingPhoneNumberSid, ParameterType.UrlSegment);
            request.AddParameter("AccountSid", targetAccountSid, ParameterType.GetOrPost);

            return await Execute<IncomingPhoneNumber>(request);
        }

        /// <summary>
        /// Remove (deprovision) a phone number from the current account
        /// </summary>
        /// <param name="incomingPhoneNumberSid">The Sid of the number to remove</param>
        public virtual async Task<DeleteStatus> DeleteIncomingPhoneNumber(string incomingPhoneNumberSid)
        {
            Require.Argument("IncomingPhoneNumberSid", incomingPhoneNumberSid);
            var request = new RestRequest(Method.DELETE);
            request.Resource = "Accounts/{AccountSid}/IncomingPhoneNumbers/{IncomingPhoneNumberSid}.json";

            request.AddParameter("IncomingPhoneNumberSid", incomingPhoneNumberSid, ParameterType.UrlSegment);

            var response = await Execute(request);
            return response.StatusCode == System.Net.HttpStatusCode.NoContent ? DeleteStatus.Success : DeleteStatus.Failed;
        }
    }
}
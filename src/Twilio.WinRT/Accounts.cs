using System;
using RestRT;
using Windows.Foundation;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;

namespace Twilio
{
	public sealed partial class TwilioRestClient
	{
		/// <summary>
		/// Retrieve the account details for the currently authenticated account. Makes a GET request to an Account Instance resource.
		/// </summary>
        public IAsyncOperation<Account> GetAccountAsync()
        {
            return (IAsyncOperation<Account>)AsyncInfo.Run((System.Threading.CancellationToken ct) => GetAccountAsyncInternal());
        }
        private async Task<Account> GetAccountAsyncInternal()
		{
			var request = new RestRequest();
			request.Resource = "Accounts/{AccountSid}.json";

            var result = await ExecuteAsync(request, typeof(Account));
            return (Account)result;
		}

		/// <summary>
		/// Retrieve the account details for a subaccount. Makes a GET request to an Account Instance resource.
		/// </summary>
		/// <param name="accountSid">The Sid of the subaccount to retrieve</param>
        public IAsyncOperation<Account> GetAccountAsync(string accountSid)
        {
            return (IAsyncOperation<Account>)AsyncInfo.Run((System.Threading.CancellationToken ct) => GetAccountAsyncInternal(accountSid));
        }
        private async Task<Account> GetAccountAsyncInternal(string accountSid)
		{
			var request = new RestRequest();
			request.Resource = "Accounts/{AccountSid}.json";
			
			request.AddUrlSegment("AccountSid", accountSid);

            var result = await ExecuteAsync(request, typeof(Account));
            return (Account)result;
        }

		/// <summary>
		/// List all subaccounts created for the authenticated account. Makes a GET request to the Account List resource.
		/// </summary>
        public IAsyncOperation<AccountResult> ListSubAccountsAsync()
        {
            return (IAsyncOperation<AccountResult>)AsyncInfo.Run((System.Threading.CancellationToken ct) => ListSubAccountsAsyncInternal());
        }
        private async Task<AccountResult> ListSubAccountsAsyncInternal()
		{
			var request = new RestRequest();
			request.Resource = "Accounts.json";

            var result = await ExecuteAsync(request, typeof(AccountResult));
            return (AccountResult)result;
        }

		/// <summary>
		/// Creates a new subaccount under the authenticated account. Makes a POST request to the Account List resource.
		/// </summary>
		/// <param name="friendlyName">Name associated with this account for your own reference (can be empty string)</param>
        public IAsyncOperation<Account> CreateSubAccountAsync(string friendlyName)
        {
            return (IAsyncOperation<Account>)AsyncInfo.Run((System.Threading.CancellationToken ct) => CreateSubAccountAsyncInternal(friendlyName));
        }
        private async Task<Account> CreateSubAccountAsyncInternal(string friendlyName)
		{
			var request = new RestRequest();
            request.Method = Method.POST;
			request.Resource = "Accounts.json";
			
			request.AddParameter("FriendlyName", friendlyName);

            var result = await ExecuteAsync(request, typeof(Account));
            return (Account)result;
		}

		/// <summary>
		/// Changes the status of a subaccount. You must be authenticated as the master account to call this method on a subaccount.
		/// WARNING: When closing an account, Twilio will release all phone numbers assigned to it and shut it down completely. 
		/// You can't ever use a closed account to make and receive phone calls or send and receive SMS messages. 
		/// It's closed, gone, kaput. It will still appear in your accounts list, and you will still have access to historical 
		/// data for that subaccount, but you cannot reopen a closed account.
		/// </summary>
		/// <param name="subAccountSid">The subaccount to change the status on</param>
		/// <param name="status">The status to change the subaccount to</param>
        public IAsyncOperation<Account> ChangeSubAccountStatusAsync(string subAccountSid, AccountStatus status)
        {
            return (IAsyncOperation<Account>)AsyncInfo.Run((System.Threading.CancellationToken ct) => ChangeSubAccountStatusAsyncInternal(subAccountSid, status));
        }
        private async Task<Account> ChangeSubAccountStatusAsyncInternal(string subAccountSid, AccountStatus status)
		{
			if (subAccountSid == AccountSid)
			{
				throw new InvalidOperationException("Subaccount status can only be changed when authenticated from the master account.");
			}

			var request = new RestRequest();
            request.Method = Method.POST;
			request.Resource = "Accounts/{AccountSid}.json";
			
			request.AddParameter("Status", status.ToString().ToLower());
			request.AddUrlSegment("AccountSid", subAccountSid);

            var result = await ExecuteAsync(request, typeof(Account));
            return (Account)result;
		}

		/// <summary>
		/// Update the friendly name associated with the currently authenticated account. Makes a POST request to an Account Instance resource.
		/// </summary>
		/// <param name="friendlyName">Name to use when updating</param>
        public IAsyncOperation<Account> UpdateAccountNameAsync(string friendlyName)
        {
            return (IAsyncOperation<Account>)AsyncInfo.Run((System.Threading.CancellationToken ct) => UpdateAccountNameAsyncInternal(friendlyName));
        }
        private async Task<Account> UpdateAccountNameAsyncInternal(string friendlyName)
		{
			var request = new RestRequest();
            request.Method = Method.POST;
			request.Resource = "Accounts/{AccountSid}.json";
			request.AddParameter("FriendlyName", friendlyName);

            var result = await ExecuteAsync(request, typeof(Account));
            return (Account)result;
		}
	}
}
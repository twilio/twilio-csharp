using System;
using RestSharp;
using RestSharp.Extensions;
using RestSharp.Validation;


namespace Twilio
{
	public partial class TwilioRestClient
	{
		/// <summary>
		/// Retrieve the details for an address instance. Makes a GET request to an Address Instance resource.
		/// </summary>
		/// <param name="addressSid">The Sid of the application to retrieve</param>
		/// <param name="callback">Method to call upon successful completion</param>
		public virtual void GetAddress(string addressSid, Action<Address> callback)
		{
			var request = new RestRequest();
			request.Resource = "Accounts/{AccountSid}/Addresses/{AddressSid}.json";
			request.AddUrlSegment("AddressSid", addressSid);

			ExecuteAsync<Address>(request, (response) => { callback(response); });
		}

		/// <summary>
		/// List addresses on the current account.
		/// </summary>
		/// <param name="callback">Method to call upon successful completion</param>
		public virtual void ListAddresses(Action<AddressResult> callback)
		{
			ListAddresses(new AddressListRequest(), callback);
		}

		/// <summary>
		/// List addresses on the current account, with filters.
		/// </summary>
		/// <param name="options">Filters to pass into the list request</param>
		/// <param name="callback">Method to call upon successful completion</param>
		public virtual void ListAddresses(AddressListRequest options, Action<AddressResult> callback)
		{
			var request = new RestRequest();
			request.Resource = "Accounts/{AccountSid}/Addresses.json";

			AddAddressListOptions(options, request);
			ExecuteAsync<AddressResult>(request, (response) => { callback(response); });
		}

		/// <summary>
		/// List incoming phone numbers on the current account that depend on the specified Address.
		/// </summary>
		/// <param name="addressSid">Sid of the address to retrieve numbers for</param>
		/// <param name="callback">Method to call upon successful completion</param>
		public virtual void ListDependentPhoneNumbers(string addressSid, Action<DependentPhoneNumberResult> callback)
		{
			var request = new RestRequest();
			request.Resource = "Accounts/{AccountSid}/Addresses/{AddressSid}/DependentPhoneNumbers.json";
			request.AddUrlSegment("AddressSid", addressSid);

			ExecuteAsync<DependentPhoneNumberResult>(request, (response) => { callback(response); });
		}

		/// <summary>
		/// Create a new Address.
		/// </summary>
		/// <param name="friendlyName">Friendly name (optional)</param>
		/// <param name="customerName">Customer name.</param>
		/// <param name="street">Street.</param>
		/// <param name="city">City.</param>
		/// <param name="region">Region.</param>
		/// <param name="postalCode">Postal code.</param>
		/// <param name="isoCountry">Iso country.</param>
		/// <param name="callback">Method to call upon successful completion.</param>
		public virtual void AddAddress(string friendlyName, string customerName, string street, string city, string region, string postalCode, string isoCountry, Action<Address> callback)
		{
			var request = new RestRequest(Method.POST);
			request.Resource = "Accounts/{AccountSid}/Addresses.json";

			Require.Argument("CustomerName", customerName);
			Require.Argument("Street", street);
			Require.Argument("City", city);
			Require.Argument("Region", region);
			Require.Argument("PostalCode", postalCode);
			Require.Argument("IsoCountry", isoCountry);

			if (friendlyName.HasValue()) {
				Validate.IsValidLength(friendlyName, 64);
				request.AddParameter("FriendlyName", friendlyName);
			}

			request.AddParameter("CustomerName", customerName);
			request.AddParameter("Street", street);
			request.AddParameter("City", city);
			request.AddParameter("Region", region);
			request.AddParameter("PostalCode", postalCode);
			request.AddParameter("IsoCountry", isoCountry);

			ExecuteAsync<Address>(request, (response) => {
				callback(response);
			});
		}

		/// <summary>
		/// Update an address on the current account.
		/// </summary>
		/// <param name="addressSid">Sid of the address to update</param>
		/// <param name="options">Attributes to update. Only properties with a value set will be updated.</param>
		/// <param name="callback">Method to call upon successful completion.</param>
		public virtual void UpdateAddress(string addressSid, AddressOptions options, Action<Address> callback)
		{
			Require.Argument("AddressSid", addressSid);
			var request = new RestRequest(Method.POST);
			request.Resource = "Accounts/{AccountSid}/Addresses/{AddressSid}.json";
			request.AddUrlSegment("AddressSid", addressSid);

			if (options.FriendlyName.HasValue())
				request.AddParameter("FriendlyName", options.FriendlyName);
			if (options.CustomerName.HasValue())
				request.AddParameter("CustomerName", options.CustomerName);
			if (options.Street.HasValue())
				request.AddParameter("Street", options.Street);
			if (options.City.HasValue())
				request.AddParameter("City", options.City);
			if (options.Region.HasValue())
				request.AddParameter("Region", options.Region);
			if (options.PostalCode.HasValue())
				request.AddParameter("PostalCode", options.PostalCode);

			ExecuteAsync<Address>(request, (response) => {
				callback(response);
			});
		}

		/// <summary>
		/// Delete an address from the current account.
		/// </summary>
		/// <param name="addressSid">Sid of the address to delete</param>
		/// <param name="callback">Method to call upon completion; should accept a DeleteStatus object indicating whether the request succeeded.</param>
		public virtual void DeleteAddress(string addressSid, Action<DeleteStatus> callback)
		{
            var request = new RestRequest(Method.DELETE);
			request.Resource = "Accounts/{AccountSid}/Addresses/{AddressSid}.json";
			request.AddUrlSegment("AddressSid", addressSid);

			ExecuteAsync(request, (response) => {
				callback(response.StatusCode == System.Net.HttpStatusCode.NoContent ? DeleteStatus.Success : DeleteStatus.Failed);
			});
		}

	}
}


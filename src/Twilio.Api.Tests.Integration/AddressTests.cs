using System;
using NUnit.Framework;
using System.Threading;
using Moq;
using RestSharp;
using System.Linq;

namespace Twilio.Api.Tests.Integration
{
    [TestFixture]
    public class AddressTests
    {
        private const string ADDRESS_SID = "AD123";

        ManualResetEvent manualResetEvent = null;

        private Mock<TwilioRestClient> mockClient;

        [SetUp]
        public void Setup()
        {
            mockClient = new Mock<TwilioRestClient>(Credentials.AccountSid, Credentials.AuthToken);
            mockClient.CallBase = true;
        }

        [Test]
        public void ShouldAddNewAddress()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.Execute<Address>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => savedRequest = request)
                .Returns(new Address());
            var client = mockClient.Object;
            var friendlyName = Utilities.MakeRandomFriendlyName();

            client.AddAddress(friendlyName, "Homer Simpson", "742 Evergreen Terrace", "Springfield", "MO", "65801", "US");

            mockClient.Verify(trc => trc.Execute<Address>(It.IsAny<IRestRequest>()), Times.Once);

            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Accounts/{AccountSid}/Addresses.json", savedRequest.Resource);
            Assert.AreEqual(Method.POST, savedRequest.Method);
            Assert.AreEqual(7, savedRequest.Parameters.Count);
            var friendlyNameParam = savedRequest.Parameters.Find(x => x.Name == "FriendlyName");
            Assert.IsNotNull(friendlyNameParam);
            Assert.AreEqual(friendlyName, friendlyNameParam.Value);
            var customerNameParam = savedRequest.Parameters.Find(x => x.Name == "CustomerName");
            Assert.IsNotNull(customerNameParam);
            Assert.AreEqual("Homer Simpson", customerNameParam.Value);
            var streetParam = savedRequest.Parameters.Find(x => x.Name == "Street");
            Assert.IsNotNull(streetParam);
            Assert.AreEqual("742 Evergreen Terrace", streetParam.Value);
            var cityParam = savedRequest.Parameters.Find(x => x.Name == "City");
            Assert.IsNotNull(cityParam);
            Assert.AreEqual("Springfield", cityParam.Value);
            var regionParam = savedRequest.Parameters.Find(x => x.Name == "Region");
            Assert.IsNotNull(regionParam);
            Assert.AreEqual("MO", regionParam.Value);
            var postalCodeParam = savedRequest.Parameters.Find(x => x.Name == "PostalCode");
            Assert.IsNotNull(postalCodeParam);
            Assert.AreEqual("65801", postalCodeParam.Value);
            var isoCountryParam = savedRequest.Parameters.Find(x => x.Name == "IsoCountry");
            Assert.IsNotNull(isoCountryParam);
            Assert.AreEqual("US", isoCountryParam.Value);
        }

        [Test]
        public void ShouldAddNewAddressAsynchronously()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.ExecuteAsync<Address>(It.IsAny<IRestRequest>(), It.IsAny<Action<Address>>()))
                .Callback<IRestRequest, Action<Address>>((request, action) => savedRequest = request);
            var client = mockClient.Object;
            manualResetEvent = new ManualResetEvent(false);
            var friendlyName = Utilities.MakeRandomFriendlyName();

            client.AddAddress(friendlyName, "Homer Simpson", "742 Evergreen Terrace", "Springfield", "MO", "65801", "US", address =>
                {
                    manualResetEvent.Set();
                });
            manualResetEvent.WaitOne(1);

            mockClient.Verify(trc => trc.ExecuteAsync<Address>(It.IsAny<IRestRequest>(), It.IsAny<Action<Address>>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Accounts/{AccountSid}/Addresses.json", savedRequest.Resource);
            Assert.AreEqual(Method.POST, savedRequest.Method);
            Assert.AreEqual(7, savedRequest.Parameters.Count);
            var friendlyNameParam = savedRequest.Parameters.Find(x => x.Name == "FriendlyName");
            Assert.IsNotNull(friendlyNameParam);
            Assert.AreEqual(friendlyName, friendlyNameParam.Value);
            var customerNameParam = savedRequest.Parameters.Find(x => x.Name == "CustomerName");
            Assert.IsNotNull(customerNameParam);
            Assert.AreEqual("Homer Simpson", customerNameParam.Value);
            var streetParam = savedRequest.Parameters.Find(x => x.Name == "Street");
            Assert.IsNotNull(streetParam);
            Assert.AreEqual("742 Evergreen Terrace", streetParam.Value);
            var cityParam = savedRequest.Parameters.Find(x => x.Name == "City");
            Assert.IsNotNull(cityParam);
            Assert.AreEqual("Springfield", cityParam.Value);
            var regionParam = savedRequest.Parameters.Find(x => x.Name == "Region");
            Assert.IsNotNull(regionParam);
            Assert.AreEqual("MO", regionParam.Value);
            var postalCodeParam = savedRequest.Parameters.Find(x => x.Name == "PostalCode");
            Assert.IsNotNull(postalCodeParam);
            Assert.AreEqual("65801", postalCodeParam.Value);
            var isoCountryParam = savedRequest.Parameters.Find(x => x.Name == "IsoCountry");
            Assert.IsNotNull(isoCountryParam);
            Assert.AreEqual("US", isoCountryParam.Value);
        }

        [Test]
        public void ShouldGetAddress()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.Execute<Address>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => savedRequest = request)
                .Returns(new Address());
            var client = mockClient.Object;

            client.GetAddress(ADDRESS_SID);

            mockClient.Verify(trc => trc.Execute<Address>(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Accounts/{AccountSid}/Addresses/{AddressSid}.json", savedRequest.Resource);
            Assert.AreEqual(Method.GET, savedRequest.Method);
            Assert.AreEqual(1, savedRequest.Parameters.Count);
            var addressSidParam = savedRequest.Parameters.Find(x => x.Name == "AddressSid");
            Assert.IsNotNull(addressSidParam);
            Assert.AreEqual(ADDRESS_SID, addressSidParam.Value);
        }

        [Test]
        public void ShouldGetAddressAsynchronously()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.ExecuteAsync<Address>(It.IsAny<IRestRequest>(), It.IsAny<Action<Address>>()))
                .Callback<IRestRequest, Action<Address>>((request, action) => savedRequest = request);
            var client = mockClient.Object;
            manualResetEvent = new ManualResetEvent(false);

            client.GetAddress(ADDRESS_SID, app => {
                manualResetEvent.Set();
            });
            manualResetEvent.WaitOne(1);

            mockClient.Verify(trc => trc.ExecuteAsync<Address>(It.IsAny<IRestRequest>(), It.IsAny<Action<Address>>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Accounts/{AccountSid}/Addresses/{AddressSid}.json", savedRequest.Resource);
            Assert.AreEqual(Method.GET, savedRequest.Method);
            Assert.AreEqual(1, savedRequest.Parameters.Count);
            var addressSidParam = savedRequest.Parameters.Find(x => x.Name == "AddressSid");
            Assert.IsNotNull(addressSidParam);
            Assert.AreEqual(ADDRESS_SID, addressSidParam.Value);
        }

        [Test]
        public void ShouldListAddresses()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.Execute<AddressResult>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => savedRequest = request)
                .Returns(new AddressResult());
            var client = mockClient.Object;

            client.ListAddresses();

            mockClient.Verify(trc => trc.Execute<AddressResult>(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Accounts/{AccountSid}/Addresses.json", savedRequest.Resource);
            Assert.AreEqual(Method.GET, savedRequest.Method);
            Assert.AreEqual(0, savedRequest.Parameters.Count);
        }

        [Test]
        public void ShouldListAddressesAsynchronously()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.ExecuteAsync<AddressResult>(It.IsAny<IRestRequest>(), It.IsAny<Action<AddressResult>>()))
                .Callback<IRestRequest, Action<AddressResult>>((request, action) => savedRequest = request);
            var client = mockClient.Object;
            manualResetEvent = new ManualResetEvent(false);

            client.ListAddresses(addresses => {
                manualResetEvent.Set();
            });
            manualResetEvent.WaitOne(1);

            mockClient.Verify(trc => trc.ExecuteAsync<AddressResult>(It.IsAny<IRestRequest>(), It.IsAny<Action<AddressResult>>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Accounts/{AccountSid}/Addresses.json", savedRequest.Resource);
            Assert.AreEqual(Method.GET, savedRequest.Method);
            Assert.AreEqual(0, savedRequest.Parameters.Count);
        }
        
        [Test]
        public void ShouldListAddressesUsingFilters()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.Execute<AddressResult>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => savedRequest = request)
                .Returns(new AddressResult());
            var client = mockClient.Object;
            var options = new AddressListRequest ();
            options.CustomerName = "Homer Simpson";
            options.FriendlyName = Utilities.MakeRandomFriendlyName();
            options.IsoCountry = "US";
            options.Page = 1;
            options.PageSize = 10;

            client.ListAddresses(options);

            mockClient.Verify(trc => trc.Execute<AddressResult>(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Accounts/{AccountSid}/Addresses.json", savedRequest.Resource);
            Assert.AreEqual(Method.GET, savedRequest.Method);
            Assert.AreEqual(5, savedRequest.Parameters.Count);
            var customerNameParam = savedRequest.Parameters.Find(x => x.Name == "CustomerName");
            Assert.IsNotNull(customerNameParam);
            Assert.AreEqual(options.CustomerName, customerNameParam.Value);
            var friendlyNameParam = savedRequest.Parameters.Find(x => x.Name == "FriendlyName");
            Assert.IsNotNull(friendlyNameParam);
            Assert.AreEqual(options.FriendlyName, friendlyNameParam.Value);
            var isoCountryParam = savedRequest.Parameters.Find(x => x.Name == "IsoCountry");
            Assert.IsNotNull(isoCountryParam);
            Assert.AreEqual(options.IsoCountry, isoCountryParam.Value);
            var pageParam = savedRequest.Parameters.Find(x => x.Name == "Page");
            Assert.IsNotNull(pageParam);
            Assert.AreEqual(options.Page, pageParam.Value);
            var pageSizeParam = savedRequest.Parameters.Find(x => x.Name == "PageSize");
            Assert.IsNotNull(pageSizeParam);
            Assert.AreEqual(options.PageSize, pageSizeParam.Value);
        }

        [Test]
        public void ShouldUpdateAddress()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.Execute<Address>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => savedRequest = request)
                .Returns(new Address());
            var client = mockClient.Object;
            var options = new AddressOptions();
            options.City = "Springfield";
            options.CustomerName = "Homer Simpson";
            options.FriendlyName = Utilities.MakeRandomFriendlyName ();
            options.PostalCode = "65801";
            options.Region = "MO";
            options.Street = "742 Evergreen Terrace";

            client.UpdateAddress(ADDRESS_SID, options);

            mockClient.Verify(trc => trc.Execute<Address>(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Accounts/{AccountSid}/Addresses/{AddressSid}.json", savedRequest.Resource);
            Assert.AreEqual(Method.POST, savedRequest.Method);
            Assert.AreEqual(7, savedRequest.Parameters.Count);
            var addressSidParam = savedRequest.Parameters.Find(x => x.Name == "AddressSid");
            Assert.IsNotNull(addressSidParam);
            Assert.AreEqual(ADDRESS_SID, addressSidParam.Value);
            var cityParam = savedRequest.Parameters.Find(x => x.Name == "City");
            Assert.IsNotNull(cityParam);
            Assert.AreEqual(options.City, cityParam.Value);
            var customerNameParam = savedRequest.Parameters.Find(x => x.Name == "CustomerName");
            Assert.IsNotNull(customerNameParam);
            Assert.AreEqual(options.CustomerName, customerNameParam.Value);
            var friendlyNameParam = savedRequest.Parameters.Find(x => x.Name == "FriendlyName");
            Assert.IsNotNull(friendlyNameParam);
            Assert.AreEqual(options.FriendlyName, friendlyNameParam.Value);
            var postalCodeParam = savedRequest.Parameters.Find(x => x.Name == "PostalCode");
            Assert.IsNotNull(postalCodeParam);
            Assert.AreEqual(options.PostalCode, postalCodeParam.Value);
            var regionParam = savedRequest.Parameters.Find(x => x.Name == "Region");
            Assert.IsNotNull(regionParam);
            Assert.AreEqual(options.Region, regionParam.Value);
            var streetParam = savedRequest.Parameters.Find(x => x.Name == "Street");
            Assert.IsNotNull(streetParam);
            Assert.AreEqual(options.Street, streetParam.Value);
        }

        [Test]
        public void ShouldUpdateAddressAsynchronously()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.ExecuteAsync<Address>(It.IsAny<IRestRequest>(), It.IsAny<Action<Address>>()))
                .Callback<IRestRequest, Action<Address>>((request, action) => savedRequest = request);
            var client = mockClient.Object;
            manualResetEvent = new ManualResetEvent(false);
            var options = new AddressOptions();
            options.City = "Springfield";
            options.CustomerName = "Homer Simpson";
            options.FriendlyName = Utilities.MakeRandomFriendlyName ();
            options.PostalCode = "65801";
            options.Region = "MO";
            options.Street = "742 Evergreen Terrace";

            client.UpdateAddress(ADDRESS_SID, options, address => {
                manualResetEvent.Set();
            });
            manualResetEvent.WaitOne(1);

            mockClient.Verify(trc => trc.ExecuteAsync<Address>(It.IsAny<IRestRequest>(), It.IsAny<Action<Address>>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Accounts/{AccountSid}/Addresses/{AddressSid}.json", savedRequest.Resource);
            Assert.AreEqual(Method.POST, savedRequest.Method);
            Assert.AreEqual(7, savedRequest.Parameters.Count);
            var addressSidParam = savedRequest.Parameters.Find(x => x.Name == "AddressSid");
            Assert.IsNotNull(addressSidParam);
            Assert.AreEqual(ADDRESS_SID, addressSidParam.Value);
            var cityParam = savedRequest.Parameters.Find(x => x.Name == "City");
            Assert.IsNotNull(cityParam);
            Assert.AreEqual(options.City, cityParam.Value);
            var customerNameParam = savedRequest.Parameters.Find(x => x.Name == "CustomerName");
            Assert.IsNotNull(customerNameParam);
            Assert.AreEqual(options.CustomerName, customerNameParam.Value);
            var friendlyNameParam = savedRequest.Parameters.Find(x => x.Name == "FriendlyName");
            Assert.IsNotNull(friendlyNameParam);
            Assert.AreEqual(options.FriendlyName, friendlyNameParam.Value);
            var postalCodeParam = savedRequest.Parameters.Find(x => x.Name == "PostalCode");
            Assert.IsNotNull(postalCodeParam);
            Assert.AreEqual(options.PostalCode, postalCodeParam.Value);
            var regionParam = savedRequest.Parameters.Find(x => x.Name == "Region");
            Assert.IsNotNull(regionParam);
            Assert.AreEqual(options.Region, regionParam.Value);
            var streetParam = savedRequest.Parameters.Find(x => x.Name == "Street");
            Assert.IsNotNull(streetParam);
            Assert.AreEqual(options.Street, streetParam.Value);
        }

        [Test]
        public void ShouldDeleteAddress()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.Execute(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => savedRequest = request)
                .Returns(new RestResponse());
            var client = mockClient.Object;

            client.DeleteAddress(ADDRESS_SID);

            mockClient.Verify(trc => trc.Execute(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Accounts/{AccountSid}/Addresses/{AddressSid}.json", savedRequest.Resource);
            Assert.AreEqual(Method.DELETE, savedRequest.Method);
            Assert.AreEqual(1, savedRequest.Parameters.Count);
            var addressSidParam = savedRequest.Parameters.Find(x => x.Name == "AddressSid");
            Assert.IsNotNull (addressSidParam);
            Assert.AreEqual (ADDRESS_SID, addressSidParam.Value);
        }

        [Test]
        public void ShouldDeleteAddressAsynchronously()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.ExecuteAsync(It.IsAny<IRestRequest>(), It.IsAny<Action<IRestResponse>>()))
                .Callback<IRestRequest, Action<IRestResponse>>((request, action) => savedRequest = request);
            var client = mockClient.Object;
            manualResetEvent = new ManualResetEvent(false);

            client.DeleteAddress(ADDRESS_SID, address => {
                manualResetEvent.Set();
            });
            manualResetEvent.WaitOne(1);

            mockClient.Verify(trc => trc.ExecuteAsync(It.IsAny<IRestRequest>(), It.IsAny<Action<IRestResponse>>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Accounts/{AccountSid}/Addresses/{AddressSid}.json", savedRequest.Resource);
            Assert.AreEqual(Method.DELETE, savedRequest.Method);
            Assert.AreEqual(1, savedRequest.Parameters.Count);
            var addressSidParam = savedRequest.Parameters.Find(x => x.Name == "AddressSid");
            Assert.IsNotNull (addressSidParam);
            Assert.AreEqual (ADDRESS_SID, addressSidParam.Value);
        }

		[Test]
		public void ShouldListDependentPhoneNumbers()
		{
			IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.Execute<DependentPhoneNumberResult>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => savedRequest = request)
                .Returns(new DependentPhoneNumberResult());
            var client = mockClient.Object;

            client.ListDependentPhoneNumbers(ADDRESS_SID);

            mockClient.Verify(trc => trc.Execute<DependentPhoneNumberResult>(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Accounts/{AccountSid}/Addresses/{AddressSid}/DependentPhoneNumbers.json", savedRequest.Resource);
            Assert.AreEqual(Method.GET, savedRequest.Method);
            Assert.AreEqual(1, savedRequest.Parameters.Count);
            var addressSidParam = savedRequest.Parameters.Find(x => x.Name == "AddressSid");
            Assert.IsNotNull(addressSidParam);
            Assert.AreEqual(ADDRESS_SID, addressSidParam.Value);
		}

		[Test]
		public void ShouldListDependentPhoneNumbersAsynchronously()
		{
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.ExecuteAsync<DependentPhoneNumberResult>(It.IsAny<IRestRequest>(), It.IsAny<Action<DependentPhoneNumberResult>>()))
                .Callback<IRestRequest, Action<DependentPhoneNumberResult>>((request, action) => savedRequest = request);
            var client = mockClient.Object;
            manualResetEvent = new ManualResetEvent(false);

            client.ListDependentPhoneNumbers(ADDRESS_SID, address => {
                manualResetEvent.Set();
            });
            manualResetEvent.WaitOne(1);

            mockClient.Verify(trc => trc.ExecuteAsync<DependentPhoneNumberResult>(It.IsAny<IRestRequest>(), It.IsAny<Action<DependentPhoneNumberResult>>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Accounts/{AccountSid}/Addresses/{AddressSid}/DependentPhoneNumbers.json", savedRequest.Resource);
            Assert.AreEqual(Method.GET, savedRequest.Method);
            Assert.AreEqual(1, savedRequest.Parameters.Count);
            var addressSidParam = savedRequest.Parameters.Find(x => x.Name == "AddressSid");
            Assert.IsNotNull(addressSidParam);
            Assert.AreEqual(ADDRESS_SID, addressSidParam.Value);
		}

    }
}

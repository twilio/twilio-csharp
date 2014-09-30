using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;
using System.Linq;
using Twilio;

namespace Twilio.Api.Tests.Integration
{
    [TestClass]
    public class AddressTests
    {
        ManualResetEvent manualResetEvent = null;

        [TestMethod]
        public void ShouldAddNewAddress()
        {
            var client = new TwilioRestClient(Credentials.AccountSid, Credentials.AuthToken);

			var result = client.AddAddress(Utilities.MakeRandomFriendlyName(), "Homer Simpson", "742 Evergreen Terrace", "Springfield", "MO", "65801", "US");

            Assert.IsNotNull(result);
            Assert.IsNull(result.RestException);
            Assert.IsNotNull(result.Sid);

            client.DeleteAddress(result.Sid); //cleanup
        }

        [TestMethod]
        public void ShouldAddNewAddressAsynchronously()
        {
            manualResetEvent = new ManualResetEvent(false);

            var client = new TwilioRestClient(Credentials.AccountSid, Credentials.AuthToken);

            Address result = null;
            client.AddAddress(Utilities.MakeRandomFriendlyName(), "Homer Simpson", "742 Evergreen Terrace", "Springfield", "MO", "65801", "US", app =>
            {
                result = app;
                manualResetEvent.Set();
            });

            manualResetEvent.WaitOne();

            Assert.IsNotNull(result);
            Assert.IsNull(result.RestException);
            Assert.IsNotNull(result.Sid);

            client.DeleteAddress(result.Sid); //cleanup
        }

        [TestMethod]
        public void ShouldGetAddress()
        {
            var client = new TwilioRestClient(Credentials.AccountSid, Credentials.AuthToken);


            var originalAddress = client.AddAddress(Utilities.MakeRandomFriendlyName(), "Homer Simpson", "742 Evergreen Terrace", "Springfield", "MO", "65801", "US");

            Assert.IsNotNull(originalAddress.Sid);

            var result = client.GetAddress(originalAddress.Sid);
            Assert.IsNotNull(result);
            Assert.IsNull(result.RestException);
            Assert.AreEqual(originalAddress.Sid, result.Sid);

            client.DeleteAddress(result.Sid); //cleanup
        }

        [TestMethod]
        public void ShouldGetAddressAsynchronously()
        {
            manualResetEvent = new ManualResetEvent(false);

            var client = new TwilioRestClient(Credentials.AccountSid, Credentials.AuthToken);

			var originalAddress = client.AddAddress(Utilities.MakeRandomFriendlyName(), "Homer Simpson", "742 Evergreen Terrace", "Springfield", "MO", "65801", "US");
            
            Assert.IsNotNull(originalAddress.Sid);

            Address result = null;

            client.GetAddress(originalAddress.Sid, app => {
                result = app;
                manualResetEvent.Set();
            });

            manualResetEvent.WaitOne();

            Assert.IsNotNull(result);
            Assert.IsNull(result.RestException);
            Assert.AreEqual(originalAddress.Sid, result.Sid);

            client.DeleteAddress(result.Sid); //cleanup
        }

        [TestMethod]
        public void ShouldListAddresses()
        {
            var client = new TwilioRestClient(Credentials.AccountSid, Credentials.AuthToken);

            var result = client.ListAddresses();

            Assert.IsNotNull(result);
            Assert.IsNull(result.RestException);
            Assert.IsNotNull(result.Addresses);
        }

        [TestMethod]
        public void ShouldListAddressesAsynchronously()
        {
            manualResetEvent = new ManualResetEvent(false);

            var client = new TwilioRestClient(Credentials.AccountSid, Credentials.AuthToken);

            AddressResult result = null;
            client.ListAddresses(addresses => {
                result = addresses;
                manualResetEvent.Set();
            });

            manualResetEvent.WaitOne();

            Assert.IsNotNull(result);
            Assert.IsNull(result.RestException);
            Assert.IsNotNull(result.Addresses);
        }
        
        [TestMethod]
        public void ShouldListAddressesUsingFilters()
        {
            var client = new TwilioRestClient(Credentials.AccountSid, Credentials.AuthToken);

			var originalAddressOne = client.AddAddress(Utilities.MakeRandomFriendlyName(), "Homer Simpson", "742 Evergreen Terrace", "Springfield", "MO", "65801", "US");
			var originalAddressTwo = client.AddAddress(Utilities.MakeRandomFriendlyName(), "Homer Simpson", "742 Evergreen Terrace", "Springfield", "MO", "65801", "US");
			var originalAddressThree = client.AddAddress(Utilities.MakeRandomFriendlyName(), "Homer Simpson", "742 Evergreen Terrace", "Springfield", "MO", "65801", "US");

            Assert.IsNotNull(originalAddressOne.Sid);
            Assert.IsNotNull(originalAddressTwo.Sid);
            Assert.IsNotNull(originalAddressThree.Sid);

			var listRequest = new AddressListRequest();
			listRequest.FriendlyName = originalAddressTwo.FriendlyName;
			var result = client.ListAddresses(originalAddressTwo.FriendlyName);

            Assert.IsNotNull(result);
            Assert.IsNull(result.RestException);
            Assert.IsNotNull(result.Addresses);
            Assert.IsNotNull(result.Addresses.FirstOrDefault(a=>a.FriendlyName==originalAddressTwo.FriendlyName));

            client.DeleteAddress(originalAddressOne.Sid); //cleanup
            client.DeleteAddress(originalAddressTwo.Sid); //cleanup
            client.DeleteAddress(originalAddressThree.Sid); //cleanup
        }

        [TestMethod]
        public void ShouldUpdateAddress()
        {
            var client = new TwilioRestClient(Credentials.AccountSid, Credentials.AuthToken);

			var originalAddress = client.AddAddress(Utilities.MakeRandomFriendlyName(), "Homer Simpson", "742 Evergreen Terrace", "Springfield", "MO", "65801", "US");

            Assert.IsNotNull(originalAddress.Sid);

            AddressOptions options = new AddressOptions();
			options.CustomerName = "Marge Simpson";
            var result = client.UpdateAddress(originalAddress.Sid, "", options);

            Assert.IsNotNull(result);
            Assert.IsNull(result.RestException);
            Assert.AreEqual(originalAddress.Sid, result.Sid);
			Assert.AreEqual(result.CustomerName, "Marge Simpson");

            client.DeleteAddress(result.Sid); //cleanup
        }

        [TestMethod]
        public void ShouldUpdateAddressAsynchronously()
        {
            manualResetEvent = new ManualResetEvent(false);

            var client = new TwilioRestClient(Credentials.AccountSid, Credentials.AuthToken);

			var originalAddress = client.AddAddress(Utilities.MakeRandomFriendlyName(), "Homer Simpson", "742 Evergreen Terrace", "Springfield", "MO", "65801", "US");

            Assert.IsNotNull(originalAddress.Sid);

            AddressOptions options = new AddressOptions();
            Address result = null;
            client.UpdateAddress(originalAddress.Sid, "", options, app => {
                result = app;
                manualResetEvent.Set();
            });

            manualResetEvent.WaitOne();

            Assert.IsNotNull(result);
            Assert.IsNull(result.RestException);
            Assert.AreEqual(originalAddress.Sid, result.Sid);

            client.DeleteAddress(result.Sid); //cleanup
        }

        [TestMethod]
        public void ShouldDeleteAddress()
        {
            var client = new TwilioRestClient(Credentials.AccountSid, Credentials.AuthToken);

			var originalAddress = client.AddAddress(Utilities.MakeRandomFriendlyName(), "Homer Simpson", "742 Evergreen Terrace", "Springfield", "MO", "65801", "US");

            Assert.IsNotNull(originalAddress.Sid);

            var status = client.DeleteAddress(originalAddress.Sid);
            Assert.AreEqual(DeleteStatus.Success, status);
        }

        [TestMethod]
        public void ShouldDeleteAddressAsynchronously()
        {
            manualResetEvent = new ManualResetEvent(false);

            var client = new TwilioRestClient(Credentials.AccountSid, Credentials.AuthToken);

			var originalAddress = client.AddAddress(Utilities.MakeRandomFriendlyName(), "Homer Simpson", "742 Evergreen Terrace", "Springfield", "MO", "65801", "US");

            Assert.IsNotNull(originalAddress.Sid);

            DeleteStatus status = DeleteStatus.Failed;
            client.DeleteAddress(originalAddress.Sid, app => {
                status = app;
                manualResetEvent.Set();
            });

            manualResetEvent.WaitOne();

            Assert.AreEqual(DeleteStatus.Success, status);
        }

		[TestMethod]
		public void ShouldListDependentPhoneNumbers()
		{
			var client = new TwilioRestClient(Credentials.AccountSid, Credentials.AuthToken);

			var originalAddress = client.AddAddress(Utilities.MakeRandomFriendlyName(), "Homer Simpson", "742 Evergreen Terrace", "Springfield", "MO", "65801", "US");

			Assert.IsNotNull(originalAddress.Sid);

			var result = client.ListDependentPhoneNumbers(originalAddress.Sid);

			Assert.IsNotNull(result);
			Assert.IsNull(result.RestException);
			Assert.IsNotNull(result.DependentPhoneNumbers);

			client.DeleteAddress(originalAddress.Sid); // cleanup
		}

		[TestMethod]
		public void ShouldListDependentPhoneNumbersAsynchronously()
		{
			manualResetEvent = new ManualResetEvent(false);

			var client = new TwilioRestClient(Credentials.AccountSid, Credentials.AuthToken);

			var originalAddress = client.AddAddress(Utilities.MakeRandomFriendlyName(), "Homer Simpson", "742 Evergreen Terrace", "Springfield", "MO", "65801", "US");

			Assert.IsNotNull(originalAddress.Sid);

			DependentPhoneNumberResult result = null;
			client.ListDependentPhoneNumbers(originalAddress.Sid, phoneNumbers => {
				result = phoneNumbers;
				manualResetEvent.Set();
			});

			manualResetEvent.WaitOne();

			Assert.IsNotNull(result);
			Assert.IsNull(result.RestException);
			Assert.IsNotNull(result.DependentPhoneNumbers);

			client.DeleteAddress(originalAddress.Sid); // cleanup
		}

    }
}
